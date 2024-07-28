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

        var hideRouletteBonus = configuration.HideRouletteBonus;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowBonusAwardForDutyRouletteMessages,
                ref hideRouletteBonus))
        {
            configuration.HideRouletteBonus = hideRouletteBonus;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowBonusAwardForDutyRouletteMessagesHelpMarker);

        var hideAdventurerInNeedBonus = configuration.HideAdventurerInNeedBonus;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowAdventurerInNeedAwardMessages, ref hideAdventurerInNeedBonus))
        {
            configuration.HideAdventurerInNeedBonus = hideAdventurerInNeedBonus;
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