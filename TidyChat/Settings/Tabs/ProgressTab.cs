using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class ProgressTab
{
    public static void Draw(Configuration configuration)
    {
        bool showGainExperience = configuration.ShowGainExperience;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowExperienceGainMessages, ref showGainExperience))
        {
            configuration.ShowGainExperience = showGainExperience;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowExperienceGainMessagesHelpMarker);

        bool showFirstClearAward = configuration.ShowFirstClearAward;
        if (ImGui.Checkbox(Languages.SystemTab_ShowFirstClearAward, ref showFirstClearAward))
        {
            configuration.ShowFirstClearAward = showFirstClearAward;
            configuration.OnSettingChanged();
        }

        bool showSecondChanceAward = configuration.ShowSecondChanceAward;
        if (ImGui.Checkbox(Languages.SystemTab_ShowSecondChanceAward, ref showSecondChanceAward))
        {
            configuration.ShowSecondChanceAward = showSecondChanceAward;
            configuration.OnSettingChanged();
        }

        bool hideRouletteBonus = configuration.HideRouletteBonus || configuration.HideAdventurerInNeedBonus;
        if (ImGui.Checkbox(Languages.ProgressTab_HideDutyRouletteBonusMessages, ref hideRouletteBonus))
        {
            configuration.HideRouletteBonus = hideRouletteBonus;
            configuration.HideAdventurerInNeedBonus = hideRouletteBonus;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_HideDutyRouletteBonusMessagesHelpMarker);

        bool showGainPvpExp = configuration.ShowGainPvpExp;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowPVPExpGainMessages, ref showGainPvpExp))
        {
            configuration.ShowGainPvpExp = showGainPvpExp;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowPVPExpGainMessagesHelpMarker);

        bool showAchievementMessages = configuration.ShowEarnAchievement || configuration.ShowOtherEarnedAchievement;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowAchievementMessages, ref showAchievementMessages))
        {
            if (!showAchievementMessages)
            {
                configuration.ShowEarnAchievement = false;
                configuration.ShowOtherEarnedAchievement = false;
            }
            else
            {
                configuration.ShowEarnAchievement = true;
                configuration.ShowOtherEarnedAchievement = true;
            }

            configuration.OnSettingChanged();
        }

        if (showAchievementMessages)
        {
            ImGui.Indent();

            bool showEarnAchievement = configuration.ShowEarnAchievement;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowEarnedAchievementMessages, ref showEarnAchievement))
            {
                configuration.ShowEarnAchievement = showEarnAchievement;
                configuration.OnSettingChanged();
            }

            bool showOtherEarnedAchievement = configuration.ShowOtherEarnedAchievement;
            if (ImGui.Checkbox(Languages.ProgressTab_ShowOtherPlayersEarnedAchievementMessages,
                    ref showOtherEarnedAchievement))
            {
                configuration.ShowOtherEarnedAchievement = showOtherEarnedAchievement;
                configuration.OnSettingChanged();
            }

            ImGui.Unindent();
        }

        bool showLevelUps = configuration.ShowLevelUps;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowLevelUpMessages, ref showLevelUps))
        {
            configuration.ShowLevelUps = showLevelUps;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowLevelUpMessagesHelpMarker);

        bool showOtherLevelUps = configuration.ShowOtherLevelUps;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowOtherPlayersLevelUpMessages, ref showOtherLevelUps))
        {
            configuration.ShowOtherLevelUps = showOtherLevelUps;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowOtherPlayerLevelUpMessagesHelpMarker);

        bool showMountMessages = configuration.ShowMountMessages;
        if (ImGui.Checkbox(Languages.ProgressTab_ShowMountMessages, ref showMountMessages))
        {
            configuration.ShowMountMessages = showMountMessages;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ProgressTab_ShowMountMessagesHelpMarker);

        ImGui.EndTabItem();
    }
}
