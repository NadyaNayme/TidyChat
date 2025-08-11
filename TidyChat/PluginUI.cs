using System;
using System.Numerics;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using TidyChat.Localization.Resources;
using TidyChat.Settings.Tabs;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat;

internal class PluginUI : Window, IDisposable
{
    private readonly Configuration configuration;

    public PluginUI(Configuration configuration) : base("Tidy Chat")
    {
        this.configuration = configuration;
        Size = new Vector2(600, 450);
        SizeCondition = ImGuiCond.FirstUseEver;
    }
    
    public void Dispose()
    {
        // Have around in case we need it
    }

    public override void Draw()
    {
        if (!ImGui.BeginTabBar("##tidychatConfigTabs"))
            return;
        
        float width = ImGui.CalcTextSize(TidyStrings.Version).X + (20.0f * ImGuiHelpers.GlobalScale);
        ImGui.SameLine(ImGui.GetWindowWidth() - width);
        Vector4 ColorGray = new(0.45f, 0.45f, 0.45f, 1);
        ImGui.TextColored(ColorGray, TidyStrings.Version);
        if (ImGui.BeginTabItem(Languages.ConfigWindow_SettingsTabHeader))
        {
            GeneralTab.Draw(configuration);
            if (TabFooter.Display(configuration))
            {
                IsOpen = false;
            }
        }

        if (ImGui.BeginTabItem(Languages.ConfigWindow_AdvancedSettingsTabHeader))
        {
            AdvancedTab.Draw(configuration);
            if (TabFooter.Display(configuration))
            {
                IsOpen = false;
            }
        }

        ImGui.EndTabBar();
    }
}
