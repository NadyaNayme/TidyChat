using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class CraftingTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.CraftingTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.CraftingGatheringTab_CraftingDropdownHeader, () => DrawCraftingOptions(configuration)));
    }

    private static void DrawCraftingOptions(Configuration configuration)
    {
        var showCraftingSynthesisComplete = configuration.ShowCraftingSynthesisComplete;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCraftingSynthesisComplete, ref showCraftingSynthesisComplete))
        {
            configuration.ShowCraftingSynthesisComplete = showCraftingSynthesisComplete;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.CraftingGatheringTab_ShowCraftingSynthesisCompleteHelpMarker);

        var showTrialMessages = configuration.ShowTrialMessages;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowTrialSynthesisMessages, ref showTrialMessages))
        {
            configuration.ShowTrialMessages = showTrialMessages;
            configuration.OnSettingChanged();
        }

        var showOtherSynthesis = configuration.ShowOtherSynthesis;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowOtherPlayerCompletedSynthesisMessages,
                ref showOtherSynthesis))
        {
            configuration.ShowOtherSynthesis = showOtherSynthesis;
            configuration.OnSettingChanged();
        }

        var showAllOtherCrafting = configuration.ShowAllOtherCrafting;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowAllOtherCrafting, ref showAllOtherCrafting))
        {
            configuration.ShowAllOtherCrafting = showAllOtherCrafting;
            configuration.OnSettingChanged();
        }

        UiHelp.CraftingFilterMarker(Languages.CraftingGatheringTab_ShowAllOtherCraftingHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowAllOtherCrafting, () =>
        {
            var showCraftingBuff = configuration.ShowCraftingBuffEffectGain;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCraftingBuffEffectGain, ref showCraftingBuff))
            {
                configuration.ShowCraftingBuffEffectGain = showCraftingBuff;
                configuration.OnSettingChanged();
            }

            UiHelp.CraftingFilterMarker(Languages.CraftingGatheringTab_ShowCraftingBuffEffectGainHelpMarker);

            var showCraftingExecute = configuration.ShowCraftingAbleToExecute;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCraftingAbleToExecute, ref showCraftingExecute))
            {
                configuration.ShowCraftingAbleToExecute = showCraftingExecute;
                configuration.OnSettingChanged();
            }

            UiHelp.GatheringFilterMarker(Languages.CraftingGatheringTab_ShowCraftingAbleToExecuteHelpMarker);
        });
    }
}
