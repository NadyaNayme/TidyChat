using Dalamud.Interface.Components;
using ImGuiNET;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings.Tabs;

internal static class ProgressTab
{
    public static void Draw(Configuration configuration)
    {
        var showGainExperience = configuration.ShowGainExperience;
        if (ImGui.Checkbox(localization.ProgressTab_ShowExperienceGainMessages, ref showGainExperience))
        {
            configuration.ShowGainExperience = showGainExperience;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.ProgressTab_ShowExperienceGainMessagesHelpMarker);

        var showRouletteBonusExperiencePoints = configuration.ShowRouletteBonus;
        if (ImGui.Checkbox(localization.ProgressTab_ShowBonusAwardForDutyRouletteMessages,
                ref showRouletteBonusExperiencePoints))
        {
            configuration.ShowRouletteBonus = showRouletteBonusExperiencePoints;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.ProgressTab_ShowBonusAwardForDutyRouletteMessagesHelpMarker);

        var showAdventurerInNeedBonus = configuration.ShowAdventurerInNeedBonus;
        if (ImGui.Checkbox(localization.ProgressTab_ShowAdventurerInNeedAwardMessages, ref showAdventurerInNeedBonus))
        {
            configuration.ShowAdventurerInNeedBonus = showAdventurerInNeedBonus;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.ProgressTab_ShowAdventurerInNeedAwardMessagesHelpMarker);

        var showGainPvpExp = configuration.ShowGainPvpExp;
        if (ImGui.Checkbox(localization.ProgressTab_ShowPVPExpGainMessages, ref showGainPvpExp))
        {
            configuration.ShowGainPvpExp = showGainPvpExp;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.ProgressTab_ShowPVPExpGainMessagesHelpMarker);

        var showEarnAchievement = configuration.ShowEarnAchievement;
        if (ImGui.Checkbox(localization.ProgressTab_ShowEarnedAchievementMessages, ref showEarnAchievement))
        {
            configuration.ShowEarnAchievement = showEarnAchievement;
            configuration.Save();
        }

        var showOtherEarnedAchievement = configuration.ShowOtherEarnedAchievement;
        if (ImGui.Checkbox(localization.ProgressTab_ShowOtherPlayersEarnedAchievementMessages,
                ref showOtherEarnedAchievement))
        {
            configuration.ShowOtherEarnedAchievement = showOtherEarnedAchievement;
            configuration.Save();
        }

        var showLevelUps = configuration.ShowLevelUps;
        if (ImGui.Checkbox(localization.ProgressTab_ShowLevelUpMessages, ref showLevelUps))
        {
            configuration.ShowLevelUps = showLevelUps;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.ProgressTab_ShowLevelUpMessagesHelpMarker);

        var showOtherLevelUps = configuration.ShowOtherLevelUps;
        if (ImGui.Checkbox(localization.ProgressTab_ShowOtherPlayersLevelUpMessages, ref showOtherLevelUps))
        {
            configuration.ShowOtherLevelUps = showOtherLevelUps;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.ProgressTab_ShowOtherPlayerLevelUpMessagesHelpMarker);

        var showAbilityUnlocks = configuration.ShowAbilityUnlocks;
        if (ImGui.Checkbox(localization.ProgressTab_ShowLearnedAbilityMessages, ref showAbilityUnlocks))
        {
            configuration.ShowAbilityUnlocks = showAbilityUnlocks;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.ProgressTab_ShowLearnedAbilityMessagesHelpMarker);

        ImGui.EndTabItem();
    }
}