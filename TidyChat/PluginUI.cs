using System;
using System.Numerics;
using Dalamud.Interface.Utility;
using ImGuiNET;
using TidyChat.Settings.Tabs;
using TidyStrings = TidyChat.Utility.InternalStrings;
using TidyChat.Resources.Languages;

namespace TidyChat;

internal class PluginUI(Configuration configuration) : IDisposable
{
    private readonly Configuration configuration = configuration;

    public void Dispose()
    {
        // Have around in case we need it
    }

    public void Draw()
    {
        if (!SettingsVisible) return;
        try
        {
            ImGui.SetNextWindowSize(new Vector2(600, 450), ImGuiCond.FirstUseEver | ImGuiCond.Appearing);
            if (!ImGui.Begin("Tidy Chat", ref settingsVisible)) return;

            if (ImGui.BeginTabBar("##tidychatConfigTabs"))
            {
                float width = ImGui.CalcTextSize(TidyStrings.Version).X + (20.0f * ImGuiHelpers.GlobalScale);
                ImGui.SameLine(ImGui.GetWindowWidth() - width);
                Vector4 ColorGray = new(0.45f, 0.45f, 0.45f, 1);
                ImGui.TextColored(ColorGray, TidyStrings.Version);
                if (ImGui.BeginTabItem(Languages.ConfigWindow_SettingsTabHeader))
                {
                    GeneralTab.Draw(configuration);
                    TabFooter.Display(configuration, ref settingsVisible);
                }

                if (ImGui.BeginTabItem(Languages.ConfigWindow_AdvancedSettingsTabHeader))
                {
                    AdvancedTab.Draw(configuration);
                    TabFooter.Display(configuration, ref settingsVisible);
                }

                ImGui.EndTabBar();
            }
        }
        finally
        {
            ImGui.End();
        }
    }

#pragma warning disable
    private bool settingsVisible;
    public bool SettingsVisible
    {
        get => settingsVisible;
        set => settingsVisible = value;
    }
#pragma warning restore
}
