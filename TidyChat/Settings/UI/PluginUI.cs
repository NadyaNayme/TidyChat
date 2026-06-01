using System;
using System.Numerics;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using TidyChat.Localization.Resources;
using TidyChat.Settings.Search;
using TidyChat.Settings.Tabs;

namespace TidyChat.Settings.UI;

internal class PluginUI : Window, IDisposable
{
    private const float MinWindowHeight = 400f;
    private const float WindowChromePadding = 28f;

    private static readonly ImGuiTabBarFlags TabBarFlags =
        ImGuiTabBarFlags.FittingPolicyScroll;

    private static readonly string[] TabLabels =
    [
        Languages.ConfigWindow_GeneralTabHeader,
        Languages.ConfigWindow_EmotesTabHeader,
        Languages.ConfigWindow_SystemTabHeader,
        Languages.ConfigWindow_PartyDutyTabHeader,
        Languages.ConfigWindow_EconomyTabHeader,
        Languages.ConfigWindow_ObtainTabHeader,
        Languages.ConfigWindow_ProgressTabHeader,
        Languages.ConfigWindow_CombatTabHeader,
        Languages.ConfigWindow_CraftingGatheringTabHeader,
        Languages.ConfigWindow_ToolsTabHeader
    ];

    private readonly Configuration configuration;

    private float cachedLayoutScale = -1f;
    private string? cachedCultureName;
    private float? cachedMinWindowWidth;
    private bool appliedDefaultWidth;

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
        float minWidth = GetMinimumWindowWidth();

        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(minWidth, MinWindowHeight),
            MaximumSize = new Vector2(10000f, 10000f)
        };

        ImGui.SetNextWindowSizeConstraints(
            new Vector2(minWidth, MinWindowHeight),
            new Vector2(10000f, 10000f));

        if (!appliedDefaultWidth && SizeCondition == ImGuiCond.FirstUseEver)
        {
            Size = new Vector2(minWidth, MinWindowHeight);
            appliedDefaultWidth = true;
        }

        Vector2 size = Size ?? new Vector2(minWidth, MinWindowHeight);
        if (size.X < minWidth)
            Size = new Vector2(minWidth, Math.Max(size.Y, MinWindowHeight));
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

        if (!ImGui.BeginTabBar("##tidychatConfigTabs", TabBarFlags))
            return;

        if (ImGui.BeginTabItem(Languages.ConfigWindow_GeneralTabHeader))
        {
            GeneralTab.Draw(configuration);
            TabFooter.Display(configuration);
            ImGui.EndTabItem();
        }

        if (ImGui.BeginTabItem(Languages.ConfigWindow_EmotesTabHeader))
        {
            EmotesTab.Draw(configuration);
            TabFooter.Display(configuration);
            ImGui.EndTabItem();
        }

        if (ImGui.BeginTabItem(Languages.ConfigWindow_SystemTabHeader))
        {
            SystemTab.Draw(configuration);
            TabFooter.Display(configuration);
            ImGui.EndTabItem();
        }

        if (ImGui.BeginTabItem(Languages.ConfigWindow_PartyDutyTabHeader))
        {
            PartyDutyTab.Draw(configuration);
            TabFooter.Display(configuration);
            ImGui.EndTabItem();
        }

        if (ImGui.BeginTabItem(Languages.ConfigWindow_EconomyTabHeader))
        {
            EconomyTab.Draw(configuration);
            TabFooter.Display(configuration);
            ImGui.EndTabItem();
        }

        if (ImGui.BeginTabItem(Languages.ConfigWindow_ObtainTabHeader))
        {
            ObtainTab.Draw(configuration);
            TabFooter.Display(configuration);
            ImGui.EndTabItem();
        }

        if (ImGui.BeginTabItem(Languages.ConfigWindow_ProgressTabHeader))
        {
            ProgressTab.Draw(configuration);
            TabFooter.Display(configuration);
            ImGui.EndTabItem();
        }

        if (ImGui.BeginTabItem(Languages.ConfigWindow_CombatTabHeader))
        {
            CombatTab.Draw(configuration);
            TabFooter.Display(configuration);
            ImGui.EndTabItem();
        }

        if (ImGui.BeginTabItem(Languages.ConfigWindow_CraftingGatheringTabHeader))
        {
            CraftingGatheringTab.Draw(configuration);
            TabFooter.Display(configuration);
            ImGui.EndTabItem();
        }

        if (ImGui.BeginTabItem(Languages.ConfigWindow_ToolsTabHeader))
        {
            ToolsTab.Draw(configuration);
            TabFooter.Display(configuration);
            ImGui.EndTabItem();
        }

        ImGui.EndTabBar();
    }

    private float GetMinimumWindowWidth()
    {
        InvalidateLayoutCacheIfNeeded();

        if (cachedMinWindowWidth is float width)
            return width;

        var style = ImGui.GetStyle();
        float scale = ImGuiHelpers.GlobalScale;

        float tabBarWidth = CalculateTabBarWidth(style);
        float searchWidth = ImGui.CalcTextSize(Languages.ConfigWindow_SearchPlaceholder).X
            + style.FramePadding.X * 2f
            + style.WindowPadding.X * 2f;

        width = Math.Max(tabBarWidth, searchWidth)
            + style.WindowPadding.X * 2f
            + WindowChromePadding * scale;

        cachedMinWindowWidth = width;
        return width;
    }

    private void InvalidateLayoutCacheIfNeeded()
    {
        float layoutScale = ImGuiHelpers.GlobalScale * ImGui.GetIO().FontGlobalScale;
        string cultureName = Languages.Culture?.Name ?? string.Empty;

        if (Math.Abs(cachedLayoutScale - layoutScale) < 0.001f &&
            string.Equals(cachedCultureName, cultureName, StringComparison.Ordinal))
            return;

        cachedLayoutScale = layoutScale;
        cachedCultureName = cultureName;
        cachedMinWindowWidth = null;
    }

    private static float CalculateTabBarWidth(ImGuiStylePtr style)
    {
        float width = 0f;

        for (int i = 0; i < TabLabels.Length; i++)
        {
            width += ImGui.CalcTextSize(TabLabels[i]).X + style.FramePadding.X * 2f;

            if (i < TabLabels.Length - 1)
                width += style.ItemInnerSpacing.X;
        }

        return width + style.WindowPadding.X * 2f + style.ItemInnerSpacing.X;
    }
}
