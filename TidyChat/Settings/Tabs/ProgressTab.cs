using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class ProgressTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.ProgressTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.ProgressTab_ExperienceAndLevelsDropdownHeader, () => DrawExperienceAndLevels(configuration)),
            (Languages.ProgressTab_DutyRewardsDropdownHeader, () => DrawDutyRewards(configuration)),
            (Languages.ProgressTab_QuestAndAchievementsDropdownHeader, () => DrawQuestAndAchievements(configuration)),
            (Languages.ProgressTab_UnlocksDropdownHeader, () => DrawUnlocks(configuration)));
    }

    private static void DrawExperienceAndLevels(Configuration configuration)
    {
        var showGainExperience = configuration.ShowGainExperience;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowExperienceGainMessages, ref showGainExperience))
        {
            configuration.ShowGainExperience = showGainExperience;
            configuration.OnSettingChanged();
        }

        UiHelp.ProgressFilterMarker(Languages.ProgressTab_ShowExperienceGainMessagesHelpMarker);

        var showGainPvpExp = configuration.ShowGainPvpExp;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowPvpExpGainMessages, ref showGainPvpExp))
        {
            configuration.ShowGainPvpExp = showGainPvpExp;
            configuration.OnSettingChanged();
        }

        UiHelp.ProgressFilterMarker(Languages.ProgressTab_ShowPvpExpGainMessagesHelpMarker);

        var showGainPvpRank = configuration.ShowGainPvpRank;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowPvpRankMessages, ref showGainPvpRank))
        {
            configuration.ShowGainPvpRank = showGainPvpRank;
            configuration.OnSettingChanged();
        }

        UiHelp.ProgressFilterMarker(Languages.ProgressTab_ShowPvpRankMessagesHelpMarker);

        var showGainSeriesExp = configuration.ShowGainSeriesExp;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowSeriesProgressMessages, ref showGainSeriesExp))
        {
            configuration.ShowGainSeriesExp = showGainSeriesExp;
            configuration.OnSettingChanged();
        }

        UiHelp.ProgressFilterMarker(Languages.ProgressTab_ShowSeriesProgressMessagesHelpMarker);

        var showPvpZoneAnnouncements = configuration.ShowPvpZoneAnnouncements;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowPvpZoneAnnouncements, ref showPvpZoneAnnouncements))
        {
            configuration.ShowPvpZoneAnnouncements = showPvpZoneAnnouncements;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ProgressTab_ShowPvpZoneAnnouncementsHelpMarker);

        var showLevelUps = configuration.ShowLevelUps;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowLevelUpMessages, ref showLevelUps))
        {
            configuration.ShowLevelUps = showLevelUps;
            configuration.OnSettingChanged();
        }

        UiHelp.ProgressFilterMarker(Languages.ProgressTab_ShowLevelUpMessagesHelpMarker);

        var showOtherLevelUps = configuration.ShowOtherLevelUps;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowOtherPlayersLevelUpMessages, ref showOtherLevelUps))
        {
            configuration.ShowOtherLevelUps = showOtherLevelUps;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ProgressTab_ShowOtherPlayerLevelUpMessagesHelpMarker);
    }

    private static void DrawDutyRewards(Configuration configuration)
    {
        var showFirstClearAward = configuration.ShowFirstClearAward;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowFirstClearAward, ref showFirstClearAward))
        {
            configuration.ShowFirstClearAward = showFirstClearAward;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ProgressTab_ShowFirstClearAwardHelpMarker);

        var showSecondChanceAward = configuration.ShowSecondChanceAward;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowSecondChanceAward, ref showSecondChanceAward))
        {
            configuration.ShowSecondChanceAward = showSecondChanceAward;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ProgressTab_ShowSecondChanceAwardHelpMarker);

        var hideRouletteBonus = configuration.HideRouletteBonus;
        if (ImGui.Checkbox(Languages.ProgressTab_HideBonusAwardForDutyRouletteMessages,
                ref hideRouletteBonus))
        {
            configuration.HideRouletteBonus = hideRouletteBonus;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedHideFilterMarker(Languages.ProgressTab_HideBonusAwardForDutyRouletteMessagesHelpMarker);

        var hideAdventurerInNeedBonus = configuration.HideAdventurerInNeedBonus;
        if (ImGui.Checkbox(Languages.ProgressTab_HideAdventurerInNeedAwardMessages, ref hideAdventurerInNeedBonus))
        {
            configuration.HideAdventurerInNeedBonus = hideAdventurerInNeedBonus;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedHideFilterMarker(Languages.ProgressTab_HideAdventurerInNeedAwardMessagesHelpMarker);
    }

    private static void DrawQuestAndAchievements(Configuration configuration)
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

        UiHelp.ProgressFilterMarker(Languages.ProgressTab_ShowEarnedAchievementMessagesHelpMarker);

        var showOtherEarnedAchievement = configuration.ShowOtherEarnedAchievement;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowOtherPlayersEarnedAchievementMessages,
                ref showOtherEarnedAchievement))
        {
            configuration.ShowOtherEarnedAchievement = showOtherEarnedAchievement;
            configuration.OnSettingChanged();
        }

        UiHelp.ProgressFilterMarker(Languages.ProgressTab_ShowOtherPlayersEarnedAchievementMessagesHelpMarker);
    }

    private static void DrawUnlocks(Configuration configuration)
    {
        var showAbilityUnlocks = configuration.ShowAbilityUnlocks;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowLearnedAbilityMessages, ref showAbilityUnlocks))
        {
            configuration.ShowAbilityUnlocks = showAbilityUnlocks;
            configuration.OnSettingChanged();
        }

        UiHelp.ProgressAndSystemFilterMarker(Languages.ProgressTab_ShowLearnedAbilityMessagesHelpMarker);

        var showMountMessages = configuration.ShowMountMessages;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowMountMessages, ref showMountMessages))
        {
            configuration.ShowMountMessages = showMountMessages;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowMountMessagesHelpMarker);
    }
}
