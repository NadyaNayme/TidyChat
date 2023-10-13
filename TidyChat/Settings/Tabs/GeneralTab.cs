using Dalamud.Interface;
using Dalamud.Interface.Components;
using Dalamud.Interface.Utility;
using ImGuiNET;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings.Tabs;

internal static class GeneralTab
{
    public static void Draw(Configuration configuration)
    {
        ImGui.TextUnformatted(string.Format(localization.GeneralTab_BlockedMessages,
            configuration.TtlMessagesBlocked.ToString()));
        ImGuiComponents.HelpMarker(localization.GeneralTab_BlockCountHelpMarker);
        ImGui.Separator();

        var filterSystemMessages = configuration.FilterSystemMessages;
        if (ImGui.Checkbox(localization.GeneralTab_FilterSystemSpam, ref filterSystemMessages))
        {
            configuration.FilterSystemMessages = filterSystemMessages;
            configuration.Save();
        }

        var filterProgressSpam = configuration.FilterProgressSpam;
        if (ImGui.Checkbox(localization.GeneralTab_FilterProgressSpam, ref filterProgressSpam))
        {
            configuration.FilterProgressSpam = filterProgressSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.GeneralTab_FilterProgressSpamHelpMarker);

        var filterLootSpam = configuration.FilterLootSpam;
        if (ImGui.Checkbox(localization.GeneralTab_FilterLootSpam, ref filterLootSpam))
        {
            configuration.FilterLootSpam = filterLootSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.GeneralTab_FilterLootSpamHelpMarker);

        var filterObtainedSpam = configuration.FilterObtainedSpam;
        if (ImGui.Checkbox(localization.GeneralTab_FilterObtianedSpam, ref filterObtainedSpam))
        {
            configuration.FilterObtainedSpam = filterObtainedSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.GeneralTab_FilterObtainedSpamHelpMarker);

        var filterCraftingSpam = configuration.FilterCraftingSpam;
        if (ImGui.Checkbox(localization.GeneralTab_FilterCraftingSpam, ref filterCraftingSpam))
        {
            configuration.FilterCraftingSpam = filterCraftingSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.GeneralTab_FilterCraftingSpamHelpMarker);

        var filterGatheringSpam = configuration.FilterGatheringSpam;
        if (ImGui.Checkbox(localization.GeneralTab_FilterGatheringSpam, ref filterGatheringSpam))
        {
            configuration.FilterGatheringSpam = filterGatheringSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.GeneralTab_FilterGatheringSpamHelpMarker);

        if (ImGui.CollapsingHeader(localization.GeneralTab_EmoteFiltersHeaderDropdown)) EmotesTab.Draw(configuration);

        if (ImGui.CollapsingHeader(localization.GeneralTab_ImprovedMessagesHeader))
        {
            var includeChatTag = configuration.IncludeChatTag;
            if (ImGui.Checkbox(localization.GeneralTab_TidyChatTag, ref includeChatTag))
            {
                configuration.IncludeChatTag = includeChatTag;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.GeneralTab_TidyChatTagHelpMarker);

            var betterInstanceMessage = configuration.BetterInstanceMessage;
            if (ImGui.Checkbox(localization.GeneralTab_ImprovedInstanceMessaging, ref betterInstanceMessage))
            {
                configuration.BetterInstanceMessage = betterInstanceMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.GeneralTab_ImprovedInstanceMessagingHelpMarker);

            var useDTRBar = configuration.UseDTRBar;
            if (ImGui.Checkbox(localization.GeneralTab_InstanceInDTRBar, ref useDTRBar))
            {
                configuration.UseDTRBar = useDTRBar;
                configuration.DTRIsEnabled = useDTRBar;
                configuration.InstanceInDtrBar = useDTRBar;
                configuration.Save();
            }

            var betterCommendationMessage = configuration.BetterCommendationMessage;
            if (ImGui.Checkbox(localization.GeneralTab_ImprovedPlayerCommendations, ref betterCommendationMessage))
            {
                configuration.BetterCommendationMessage = betterCommendationMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.GeneralTab_ImprovedPlayerCommendationsHelpMarker);

            var includeDutyNameInComms = configuration.IncludeDutyNameInComms;
            if (ImGui.Checkbox(localization.GeneralTab_ImprovedCommendationsDutyName, ref includeDutyNameInComms))
            {
                configuration.IncludeDutyNameInComms = includeDutyNameInComms;
                if (!configuration.BetterCommendationMessage && configuration.IncludeDutyNameInComms)
                    configuration.BetterCommendationMessage = true;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.GeneralTab_ImprovedCommendationsDutyNameHelpMarker);

            var betterSayReminder = configuration.BetterSayReminder;
            if (ImGui.Checkbox(localization.GeneralTab_ImprovedSayMessages, ref betterSayReminder))
            {
                configuration.BetterSayReminder = betterSayReminder;
                if (!configuration.BetterSayReminder && configuration.CopyBetterSayReminder)
                    configuration.CopyBetterSayReminder = false;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.GeneralTab_ImprovedSayMessagesHelpMarker);

            var copyBetterSayReminder = configuration.CopyBetterSayReminder;
            if (ImGui.Checkbox(localization.GeneralTab_CopySayMessage, ref copyBetterSayReminder))
            {
                configuration.CopyBetterSayReminder = copyBetterSayReminder;
                if (!configuration.BetterSayReminder && configuration.CopyBetterSayReminder)
                    configuration.BetterSayReminder = true;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.GeneralTab_CopySayMessageHelpMarker);

            var betterNoviceNetworkMessage = configuration.BetterNoviceNetworkMessage;
            if (ImGui.Checkbox(localization.GeneralTab_ImprovedNoviceNetworkMessages, ref betterNoviceNetworkMessage))
            {
                configuration.BetterNoviceNetworkMessage = betterNoviceNetworkMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.GeneralTab_ImprovedNoviceNetworkMessagesHelpMarker);
        }

        ImGuiHelpers.ScaledDummy(30f);
        ImGui.Separator();
        ImGui.Spacing();

        var noCoffee = configuration.NoCoffee;
        if (ImGui.Checkbox(localization.GeneralTab_HideKofiButton, ref noCoffee))
        {
            configuration.NoCoffee = noCoffee;
            configuration.Save();
        }

        ImGui.EndTabItem();
    }
}
