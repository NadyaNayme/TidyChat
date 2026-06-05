using Dalamud.Interface;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using System.Diagnostics;
using System.Numerics;
using TidyChat.Settings.Search;
using TidyChat.Settings.Tabs;
namespace TidyChat.Settings.UI;

internal class PluginUI : Window, IDisposable
{
    private const float MinWindowHeight = 400f;
    private const float MinContentWidth = 380f;
    private const float WindowChromePadding = 28f;
    private const float SidebarExtraPadding = 12f;

    private static readonly (Func<string> GetLabel, Action<Configuration> Draw)[] TabDefinitions =
    [
        (() => Languages.ConfigWindow_GeneralTabHeader, GeneralTab.Draw),
        (() => Languages.ConfigWindow_EmotesTabHeader, EmotesTab.Draw),
        (() => Languages.ConfigWindow_SystemTabHeader, SystemTab.Draw),
        (() => Languages.ConfigWindow_ExplorationTabHeader, ExplorationTab.Draw),
        (() => Languages.ConfigWindow_HousingTabHeader, HousingTab.Draw),
        (() => Languages.ConfigWindow_GlamourTabHeader, GlamourTab.Draw),
        (() => Languages.ConfigWindow_PartyTabHeader, PartyTab.Draw),
        (() => Languages.ConfigWindow_DutyTabHeader, DutyTab.Draw),
        (() => Languages.ConfigWindow_DeepDungeonsTabHeader, DeepDungeonsTab.Draw),
        (() => Languages.ConfigWindow_FreeCompanyTabHeader, FreeCompanyTab.Draw),
        (() => Languages.ConfigWindow_EconomyTabHeader, EconomyTab.Draw),
        (() => Languages.ConfigWindow_CurrenciesTabHeader, CurrenciesTab.Draw),
        (() => Languages.ConfigWindow_AlliedSocietiesTabHeader, AlliedSocietiesTab.Draw),
        (() => Languages.ConfigWindow_GoldSaucerTabHeader, GoldSaucerTab.Draw),
        (() => Languages.ConfigWindow_ProgressTabHeader, ProgressTab.Draw),
        (() => Languages.ConfigWindow_CombatTabHeader, CombatTab.Draw),
        (() => Languages.ConfigWindow_CraftingTabHeader, CraftingTab.Draw),
        (() => Languages.ConfigWindow_DesynthesisTabHeader, DesynthesisTab.Draw),
        (() => Languages.ConfigWindow_GatheringTabHeader, GatheringTab.Draw),
        (() => Languages.ConfigWindow_MateriaTabHeader, MateriaTab.Draw),
        (() => Languages.ConfigWindow_ToolsTabHeader, ToolsTab.Draw)
    ];

    private readonly Configuration configuration;
    private bool appliedDefaultWidth;
    private string? cachedCultureName;

    private float cachedLayoutScale = -1f;
    private float? cachedMinWindowWidth;
    private Action<Configuration> selectedTab = GeneralTab.Draw;
    private (string Label, Action<Configuration> Draw)[]? sortedTabs;
    private string? sortedTabsCulture;
    public PluginUI(Configuration configuration) : base("Tidy Chat")
    {
        this.configuration = configuration;
        SizeCondition = ImGuiCond.FirstUseEver;

        TitleBarButtons.Add(new TitleBarButton
        {
            Icon = FontAwesomeIcon.Heart,
            ShowTooltip = () => ImGui.SetTooltip(Languages.ConfigWindow_KofiTitleBarTooltip),
            Click = _ => Process.Start(new ProcessStartInfo
            {
                FileName = "https://ko-fi.com/kagekazu",
                UseShellExecute = true
            })
        });
    }

    public void Dispose() { }

    public void InvalidateLayoutCache()
    {
        cachedLayoutScale = -1f;
        cachedCultureName = null;
        cachedMinWindowWidth = null;
        sortedTabs = null;
        sortedTabsCulture = null;
    }

    public override void OnClose()
    {
        configuration.PersistIfDirty();
        base.OnClose();
    }

    public override void PreDraw()
    {
        var minWidth = GetMinimumWindowWidth();

        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new(minWidth, MinWindowHeight),
            MaximumSize = new(10000f, 10000f)
        };

        ImGui.SetNextWindowSizeConstraints(
            new(minWidth, MinWindowHeight),
            new(10000f, 10000f));

        if (!appliedDefaultWidth && SizeCondition == ImGuiCond.FirstUseEver)
        {
            Size = new Vector2(minWidth, MinWindowHeight);
            appliedDefaultWidth = true;
        }

        var size = Size ?? new Vector2(minWidth, MinWindowHeight);
        if (size.X < minWidth)
        {
            Size = new Vector2(minWidth, Math.Max(size.Y, MinWindowHeight));
        }

    }

    public override void Draw()
    {
        SettingsSearch.DrawSearchBar();
        ImGui.Spacing();

        if (SettingsSearch.IsActive)
        {
            SettingsSearchIndex.DrawResults(configuration);
            TabFooter.Display(configuration);
            return;
        }

        var tabs = GetTabs();
        var selectedIndex = Array.FindIndex(tabs, tab => tab.Draw == selectedTab);
        if (selectedIndex < 0)
        {
            selectedTab = GeneralTab.Draw;
            selectedIndex = 0;
        }

        var sidebarWidth = GetSidebarWidth(tabs);
        var avail = ImGui.GetContentRegionAvail();

        ImGui.BeginChild("##tidychatConfigSidebar", new(sidebarWidth, avail.Y), true);
        ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0f, 2f));
        for (var i = 0; i < tabs.Length; i++)
        {
            if (ImGui.Selectable(tabs[i].Label, selectedIndex == i, ImGuiSelectableFlags.None,
                    new(sidebarWidth - ImGui.GetStyle().WindowPadding.X * 2f, 0f)))
            {
                selectedTab = tabs[i].Draw;
            }
        }

        ImGui.PopStyleVar();
        ImGui.EndChild();

        ImGui.SameLine(0f, ImGui.GetStyle().ItemInnerSpacing.X);

        ImGui.BeginChild("##tidychatConfigContent", new(0f, avail.Y));
        tabs[selectedIndex].Draw(configuration);
        TabFooter.Display(configuration);
        ImGui.EndChild();
    }

    private (string Label, Action<Configuration> Draw)[] GetTabs()
    {
        var cultureName = Languages.Culture?.Name ?? string.Empty;
        if (sortedTabs is { } cachedTabs &&
            string.Equals(sortedTabsCulture, cultureName, StringComparison.Ordinal))
        {
            return cachedTabs;
        }

        var general = TabDefinitions.Single(tab => tab.Draw == GeneralTab.Draw);
        var generalEntry = (general.GetLabel(), general.Draw);
        var others = TabDefinitions
            .Where(tab => tab.Draw != GeneralTab.Draw)
            .Select(tab => (tab.GetLabel(), tab.Draw))
            .OrderBy(tab => tab.Item1, StringComparer.CurrentCultureIgnoreCase)
            .ToArray();

        sortedTabs = [generalEntry, ..others];
        sortedTabsCulture = cultureName;
        return sortedTabs;
    }

    private float GetSidebarWidth((string Label, Action<Configuration> Draw)[] tabs)
    {
        InvalidateLayoutCacheIfNeeded();

        var style = ImGui.GetStyle();
        var maxLabelWidth = 0f;

        for (var i = 0; i < tabs.Length; i++)
        {
            maxLabelWidth = Math.Max(maxLabelWidth, ImGui.CalcTextSize(tabs[i].Label).X);
        }

        return maxLabelWidth + style.FramePadding.X * 2f + style.WindowPadding.X * 2f + SidebarExtraPadding;
    }

    private float GetMinimumWindowWidth()
    {
        InvalidateLayoutCacheIfNeeded();

        if (cachedMinWindowWidth is float width)
        {
            return width;
        }

        var style = ImGui.GetStyle();
        var scale = ImGuiHelpers.GlobalScale;

        var searchWidth = ImGui.CalcTextSize(Languages.ConfigWindow_SearchPlaceholder).X
                          + style.FramePadding.X * 2f
                          + style.WindowPadding.X * 2f;

        width = GetSidebarWidth(GetTabs())
                + style.ItemInnerSpacing.X
                + Math.Max(MinContentWidth, searchWidth)
                + style.WindowPadding.X * 2f
                + WindowChromePadding * scale;

        cachedMinWindowWidth = width;
        return width;
    }

    private void InvalidateLayoutCacheIfNeeded()
    {
        var layoutScale = ImGuiHelpers.GlobalScale * ImGui.GetIO().FontGlobalScale;
        var cultureName = Languages.Culture?.Name ?? string.Empty;

        if (Math.Abs(cachedLayoutScale - layoutScale) < 0.001f &&
            string.Equals(cachedCultureName, cultureName, StringComparison.Ordinal))
        {
            return;
        }

        cachedLayoutScale = layoutScale;
        cachedCultureName = cultureName;
        cachedMinWindowWidth = null;
        sortedTabs = null;
        sortedTabsCulture = null;
    }

}
