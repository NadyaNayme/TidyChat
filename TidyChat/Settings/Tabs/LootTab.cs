using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class LootTab
    {
        public static void Draw(Configuration configuration)
{
            var filterLootSpam = configuration.FilterLootSpam;
            if (ImGui.Checkbox("Filters spammy Loot messages", ref filterLootSpam))
            {
                configuration.FilterLootSpam = filterLootSpam;
                configuration.Save();
            }

            ImGui.Separator();

            ImGui.TextUnformatted("The options below will allow you to override the spammy Loot messages filter.");
            var showCastLot = configuration.ShowCastLot;
            if (ImGui.Checkbox("Show \"You cast your lot\" messages", ref showCastLot))
            {
                configuration.ShowCastLot = showCastLot;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will show the message that occurs when you roll on loot.\neg. You cast your lot for the <item>");

            var showLootRoll = configuration.ShowLootRoll;
            if (ImGui.Checkbox("Show \"You rolled...\" messages", ref showLootRoll))
            {
                configuration.ShowLootRoll = showLootRoll;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will show the message that occurs after everyone has rolled on loot and you are given the result of your roll.\neg. You roll Need/Greed on the <item>. 63!");

            var showOthersCastLot = configuration.ShowOthersCastLot;
            if (ImGui.Checkbox("Show \"Another Player casts his/her lot <item>\" messages", ref showOthersCastLot))
            {
                configuration.ShowOthersCastLot = showOthersCastLot;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will show the message that occurs when another player in the party rolls for a loot drop.\neg. Some player casts her lot for <item>.");

            var showOthersLootRoll = configuration.ShowOthersLootRoll;
            if (ImGui.Checkbox("Show \"Another Player rolls Greed...\" messages", ref showOthersLootRoll))
            {
                configuration.ShowOthersLootRoll = showOthersLootRoll;
                configuration.Save();
            }

            var showOthersObtain = configuration.ShowOthersObtain;
            if (ImGui.Checkbox("Show \"Another Player obtains <item>\" messages", ref showOthersObtain))
            {
                configuration.ShowOthersObtain = showOthersObtain;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will show the message that occurs when another player in the party obtains a loot drop.\neg. Some player obtains an <item>!");

			ImGui.EndTabItem();
        }
    }
}
