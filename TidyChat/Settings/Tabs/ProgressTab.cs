using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class ProgressTab
    {
        public static void Draw(Configuration configuration)
        {
            var showGainExperience = configuration.ShowGainExperience;
            if (ImGui.Checkbox("Show experience gain messages", ref showGainExperience))
            {
                configuration.ShowGainExperience = showGainExperience;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("eg. You gain 2,388 Experience Points.");

            var showRouletteBonusExperiencePoints = configuration.ShowRouletteBonus;
            if (ImGui.Checkbox("Show bonus award for using duty roulette", ref showRouletteBonusExperiencePoints))
            {
                configuration.ShowRouletteBonus = showRouletteBonusExperiencePoints;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("eg. A bonus of 4,252,498 experience points and 12,000 gil has been awarded for using the duty roulette.");

            var showAdventurerInNeedBonus = configuration.ShowAdventurerInNeedBonus;
            if (ImGui.Checkbox("Show bonus awarded for being an adventurer in need", ref showAdventurerInNeedBonus))
            {
                configuration.ShowAdventurerInNeedBonus = showAdventurerInNeedBonus;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("eg. A bonus of 7,200 gil has been awarded for being an adventurer in need.");

            var showGainPvpExp = configuration.ShowGainPvpExp;
            if (ImGui.Checkbox("Show PVP EXP gain messages", ref showGainPvpExp))
            {
                configuration.ShowGainPvpExp = showGainPvpExp;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("eg. You acquire 500 PvP EXP.");

            var showEarnAchievement = configuration.ShowEarnAchievement;
            if (ImGui.Checkbox("Show earned achievement messages", ref showEarnAchievement))
            {
                configuration.ShowEarnAchievement = showEarnAchievement;
                configuration.Save();
            }

            var showOtherEarnedAchievement = configuration.ShowOtherEarnedAchievement;
            if (ImGui.Checkbox("Show other player's earned achievement messages", ref showOtherEarnedAchievement))
            {
                configuration.ShowOtherEarnedAchievement = showOtherEarnedAchievement;
                configuration.Save();
            }

            var showLevelUps = configuration.ShowLevelUps;
            if (ImGui.Checkbox("Show level up messages", ref showLevelUps))
            {
                configuration.ShowLevelUps = showLevelUps;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will show the message that occurs when you level up.\nIt can be considered spammy in Palace of the Dead and Heaven On High.");

            var showOtherLevelUps = configuration.ShowOtherLevelUps;
            if (ImGui.Checkbox("Show other player's level up messages", ref showOtherLevelUps))
            {
                configuration.ShowOtherLevelUps = showOtherLevelUps;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will show the message that occurs when others level up.\n eg. Player attains level 33!");

            var showAbilityUnlocks = configuration.ShowAbilityUnlocks;
            if (ImGui.Checkbox("Show learned ability messages", ref showAbilityUnlocks))
            {
                configuration.ShowAbilityUnlocks = showAbilityUnlocks;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will show the message that occurs when you learn a new ability.\nIt can be considered spammy in Palace of the Dead and Heaven On High.");

            ImGui.EndTabItem();
        }
    }
}
