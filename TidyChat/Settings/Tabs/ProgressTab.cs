using Dalamud.Interface.Components;
using ImGuiNET;
using TidyChat.Resources.Languages;

namespace TidyChat.Settings.Tabs;

internal static class ProgressTab
{
    public static void Draw(Configuration configuration)
    {
        var showGainExperience = configuration.ShowGainExperience;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowExperienceGainMessages, ref showGainExperience))
        {
            configuration.ShowGainExperience = showGainExperience;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowExperienceGainMessagesHelpMarker);

        var showFirstClearAward = configuration.ShowFirstClearAward;
        if (ImGui.Checkbox(Languages.SystemTab_ShowFirstClearAward, ref showFirstClearAward))
        {
            configuration.ShowFirstClearAward = showFirstClearAward;
            configuration.Save();
        }

        var showSecondChanceAward = configuration.ShowSecondChanceAward;
        if (ImGui.Checkbox(Languages.SystemTab_ShowSecondChanceAward, ref showSecondChanceAward))
        {
            configuration.ShowSecondChanceAward = showSecondChanceAward;
            configuration.Save();
        }

        var showRouletteBonusExperiencePoints = configuration.ShowRouletteBonus;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowBonusAwardForDutyRouletteMessages,
                ref showRouletteBonusExperiencePoints))
        {
            configuration.ShowRouletteBonus = showRouletteBonusExperiencePoints;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowBonusAwardForDutyRouletteMessagesHelpMarker);

        var showAdventurerInNeedBonus = configuration.ShowAdventurerInNeedBonus;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowAdventurerInNeedAwardMessages, ref showAdventurerInNeedBonus))
        {
            configuration.ShowAdventurerInNeedBonus = showAdventurerInNeedBonus;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowAdventurerInNeedAwardMessagesHelpMarker);

        var showGainPvpExp = configuration.ShowGainPvpExp;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowPVPExpGainMessages, ref showGainPvpExp))
        {
            configuration.ShowGainPvpExp = showGainPvpExp;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowPVPExpGainMessagesHelpMarker);

        var showEarnAchievement = configuration.ShowEarnAchievement;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowEarnedAchievementMessages, ref showEarnAchievement))
        {
            configuration.ShowEarnAchievement = showEarnAchievement;
            configuration.Save();
        }

        var showOtherEarnedAchievement = configuration.ShowOtherEarnedAchievement;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowOtherPlayersEarnedAchievementMessages,
                ref showOtherEarnedAchievement))
        {
            configuration.ShowOtherEarnedAchievement = showOtherEarnedAchievement;
            configuration.Save();
        }

        var showLevelUps = configuration.ShowLevelUps;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowLevelUpMessages, ref showLevelUps))
        {
            configuration.ShowLevelUps = showLevelUps;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowLevelUpMessagesHelpMarker);

        var showOtherLevelUps = configuration.ShowOtherLevelUps;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowOtherPlayersLevelUpMessages, ref showOtherLevelUps))
        {
            configuration.ShowOtherLevelUps = showOtherLevelUps;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowOtherPlayerLevelUpMessagesHelpMarker);

        var showAbilityUnlocks = configuration.ShowAbilityUnlocks;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowLearnedAbilityMessages, ref showAbilityUnlocks))
        {
            configuration.ShowAbilityUnlocks = showAbilityUnlocks;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowLearnedAbilityMessagesHelpMarker);

        ImGui.EndTabItem();
    }
}