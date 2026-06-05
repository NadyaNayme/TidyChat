using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class ProgressTab
{
    public static void Draw(Configuration configuration)
    {
        ImGui.TextWrapped(Languages.ProgressTab_FilteringNote);
        ImGui.Spacing();

        if (ImGui.CollapsingHeader(Languages.ProgressTab_ExperienceAndLevelsDropdownHeader,
                ImGuiTreeNodeFlags.DefaultOpen))
        {
            var showGainExperience = configuration.ShowGainExperience;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowExperienceGainMessages, ref showGainExperience))
            {
                configuration.ShowGainExperience = showGainExperience;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowExperienceGainMessagesHelpMarker);

            var showGainPvpExp = configuration.ShowGainPvpExp;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowPVPExpGainMessages, ref showGainPvpExp))
            {
                configuration.ShowGainPvpExp = showGainPvpExp;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowPVPExpGainMessagesHelpMarker);

            var showLevelUps = configuration.ShowLevelUps;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowLevelUpMessages, ref showLevelUps))
            {
                configuration.ShowLevelUps = showLevelUps;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowLevelUpMessagesHelpMarker);

            var showOtherLevelUps = configuration.ShowOtherLevelUps;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowOtherPlayersLevelUpMessages, ref showOtherLevelUps))
            {
                configuration.ShowOtherLevelUps = showOtherLevelUps;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.ProgressTab_ShowOtherPlayerLevelUpMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ProgressTab_DutyRewardsDropdownHeader))
        {
            var showFirstClearAward = configuration.ShowFirstClearAward;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowFirstClearAward, ref showFirstClearAward))
            {
                configuration.ShowFirstClearAward = showFirstClearAward;
                configuration.OnSettingChanged();
            }

            var showSecondChanceAward = configuration.ShowSecondChanceAward;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowSecondChanceAward, ref showSecondChanceAward))
            {
                configuration.ShowSecondChanceAward = showSecondChanceAward;
                configuration.OnSettingChanged();
            }

            var hideRouletteBonus = configuration.HideRouletteBonus;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowBonusAwardForDutyRouletteMessages,
                    ref hideRouletteBonus))
            {
                configuration.HideRouletteBonus = hideRouletteBonus;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.ProgressTab_ShowBonusAwardForDutyRouletteMessagesHelpMarker);

            var hideAdventurerInNeedBonus = configuration.HideAdventurerInNeedBonus;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowAdventurerInNeedAwardMessages, ref hideAdventurerInNeedBonus))
            {
                configuration.HideAdventurerInNeedBonus = hideAdventurerInNeedBonus;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.ProgressTab_ShowAdventurerInNeedAwardMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ProgressTab_QuestAndAchievementsDropdownHeader))
        {
            var showQuestProgress = configuration.ShowQuestProgress;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowQuestProgressMessages, ref showQuestProgress))
            {
                configuration.ShowQuestProgress = showQuestProgress;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.ProgressTab_ShowQuestProgressMessagesHelpMarker);

            var showEarnAchievement = configuration.ShowEarnAchievement;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowEarnedAchievementMessages, ref showEarnAchievement))
            {
                configuration.ShowEarnAchievement = showEarnAchievement;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowEarnedAchievementMessagesHelpMarker);

            var showOtherEarnedAchievement = configuration.ShowOtherEarnedAchievement;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowOtherPlayersEarnedAchievementMessages,
                    ref showOtherEarnedAchievement))
            {
                configuration.ShowOtherEarnedAchievement = showOtherEarnedAchievement;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowOtherPlayersEarnedAchievementMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ProgressTab_UnlocksDropdownHeader))
        {
            var showAbilityUnlocks = configuration.ShowAbilityUnlocks;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowLearnedAbilityMessages, ref showAbilityUnlocks))
            {
                configuration.ShowAbilityUnlocks = showAbilityUnlocks;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.ProgressTab_ShowLearnedAbilityMessagesHelpMarker);

            var showMountMessages = configuration.ShowMountMessages;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowMountMessages, ref showMountMessages))
            {
                configuration.ShowMountMessages = showMountMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowMountMessagesHelpMarker);
        }
    }
}
