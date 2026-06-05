using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
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

    private static readonly (string Label, Action<Configuration> Draw)[] Tabs =
    [
        (Languages.ConfigWindow_GeneralTabHeader, GeneralTab.Draw),
        (Languages.ConfigWindow_EmotesTabHeader, EmotesTab.Draw),
        (Languages.ConfigWindow_SystemTabHeader, SystemTab.Draw),
        (Languages.ConfigWindow_ExplorationTabHeader, ExplorationTab.Draw),
        (Languages.ConfigWindow_HousingTabHeader, HousingTab.Draw),
        (Languages.ConfigWindow_GlamourTabHeader, GlamourTab.Draw),
        (Languages.ConfigWindow_PartyDutyTabHeader, PartyDutyTab.Draw),
        (Languages.ConfigWindow_DeepDungeonsTabHeader, DeepDungeonsTab.Draw),
        (Languages.ConfigWindow_FreeCompanyTabHeader, FreeCompanyTab.Draw),
        (Languages.ConfigWindow_EconomyTabHeader, EconomyTab.Draw),
        (Languages.ConfigWindow_GoldSaucerTabHeader, GoldSaucerTab.Draw),
        (Languages.ConfigWindow_ObtainTabHeader, ObtainTab.Draw),
        (Languages.ConfigWindow_ProgressTabHeader, ProgressTab.Draw),
        (Languages.ConfigWindow_CombatTabHeader, CombatTab.Draw),
        (Languages.ConfigWindow_CraftingTabHeader, CraftingTab.Draw),
        (Languages.ConfigWindow_GatheringTabHeader, GatheringTab.Draw),
        (Languages.ConfigWindow_ToolsTabHeader, ToolsTab.Draw),
    ];

    private readonly Configuration configuration;
    private bool appliedDefaultWidth;
    private string? cachedCultureName;
    private int selectedTabIndex;

    private float cachedLayoutScale = -1f;
    private float? cachedMinWindowWidth;

    public PluginUI(Configuration configuration) : base("Tidy Chat")
    {
        this.configuration = configuration;
        SizeCondition = ImGuiCond.FirstUseEver;
    }

    public void Dispose() { }

    public void InvalidateLayoutCache()
    {
        cachedLayoutScale = -1f;
        cachedCultureName = null;
        cachedMinWindowWidth = null;
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

        selectedTabIndex = Math.Clamp(selectedTabIndex, 0, Tabs.Length - 1);

        var sidebarWidth = GetSidebarWidth();
        var avail = ImGui.GetContentRegionAvail();

        ImGui.BeginChild("##tidychatConfigSidebar", new Vector2(sidebarWidth, avail.Y), true);
        ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0f, 2f));
        for (var i = 0; i < Tabs.Length; i++)
        {
            if (ImGui.Selectable(Tabs[i].Label, selectedTabIndex == i, ImGuiSelectableFlags.None,
                    new Vector2(sidebarWidth - ImGui.GetStyle().WindowPadding.X * 2f, 0f)))
            {
                selectedTabIndex = i;
            }
        }

        ImGui.PopStyleVar();
        ImGui.EndChild();

        ImGui.SameLine(0f, ImGui.GetStyle().ItemInnerSpacing.X);

        ImGui.BeginChild("##tidychatConfigContent", new Vector2(0f, avail.Y), false);
        Tabs[selectedTabIndex].Draw(configuration);
        TabFooter.Display(configuration);
        ImGui.EndChild();
    }

    private float GetSidebarWidth()
    {
        InvalidateLayoutCacheIfNeeded();

        var style = ImGui.GetStyle();
        var maxLabelWidth = 0f;

        for (var i = 0; i < Tabs.Length; i++)
        {
            maxLabelWidth = Math.Max(maxLabelWidth, ImGui.CalcTextSize(Tabs[i].Label).X);
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

        width = GetSidebarWidth()
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
    }
}
