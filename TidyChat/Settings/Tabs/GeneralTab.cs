using Dalamud.Interface.Components;
using Dalamud.Interface.Utility;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class GeneralTab
{
    public static void Draw(Configuration configuration)
    {
        ImGui.TextUnformatted(string.Format(Languages.GeneralTab_BlockedMessages,
            configuration.TtlMessagesBlocked.ToString()));
        ImGuiComponents.HelpMarker(Languages.GeneralTab_BlockCountHelpMarker);
        ImGui.Separator();

        bool filterSystemMessages = configuration.FilterSystemMessages;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterSystemSpam, ref filterSystemMessages))
        {
            configuration.FilterSystemMessages = filterSystemMessages;
            configuration.Save();
        }

        bool filterProgressSpam = configuration.FilterProgressSpam;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterProgressSpam, ref filterProgressSpam))
        {
            configuration.FilterProgressSpam = filterProgressSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterProgressSpamHelpMarker);

        bool filterLootSpam = configuration.FilterLootSpam;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterLootSpam, ref filterLootSpam))
        {
            configuration.FilterLootSpam = filterLootSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterLootSpamHelpMarker);

        bool filterObtainedSpam = configuration.FilterObtainedSpam;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterObtianedSpam, ref filterObtainedSpam))
        {
            configuration.FilterObtainedSpam = filterObtainedSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterObtainedSpamHelpMarker);

        bool filterCraftingSpam = configuration.FilterCraftingSpam;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterCraftingSpam, ref filterCraftingSpam))
        {
            configuration.FilterCraftingSpam = filterCraftingSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterCraftingSpamHelpMarker);

        bool filterGatheringSpam = configuration.FilterGatheringSpam;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterGatheringSpam, ref filterGatheringSpam))
        {
            configuration.FilterGatheringSpam = filterGatheringSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterGatheringSpamHelpMarker);

        if (ImGui.CollapsingHeader(Languages.GeneralTab_EmoteFiltersHeaderDropdown)) EmotesTab.Draw(configuration);

        if (ImGui.CollapsingHeader(Languages.GeneralTab_ImprovedMessagesHeader))
        {
            bool includeChatTag = configuration.IncludeChatTag;
            if (ImGui.Checkbox(Languages.GeneralTab_TidyChatTag, ref includeChatTag))
            {
                configuration.IncludeChatTag = includeChatTag;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_TidyChatTagHelpMarker);

            bool enableSmolMode = configuration.EnableSmolMode;
            if (ImGui.Checkbox(Languages.EnableTinyChat, ref enableSmolMode))
            {
                configuration.EnableSmolMode = enableSmolMode;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.AllMessagesWillBeLowercased);

            bool normalizeBlocks = configuration.NormalizeBlocks;
            if (ImGui.Checkbox(Languages.NormalizeSpecialCharactersExceptInPartyOrAllianceChannels, ref normalizeBlocks))
            {
                configuration.NormalizeBlocks = normalizeBlocks;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ReplacesSpecialCharactersSuchAsWithA);

            bool alwaysNormalizeBlocks = configuration.AlwaysNormalizeBlocks;
            if (ImGui.Checkbox(Languages.AlwaysNormalizeSpecialCharacters, ref alwaysNormalizeBlocks))
            {
                configuration.AlwaysNormalizeBlocks = alwaysNormalizeBlocks;
                configuration.Save();
            }

            bool betterInstanceMessage = configuration.BetterInstanceMessage;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedInstanceMessaging, ref betterInstanceMessage))
            {
                configuration.BetterInstanceMessage = betterInstanceMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedInstanceMessagingHelpMarker);

            bool instanceInDtrBar = configuration.InstanceInDtrBar;
            if (ImGui.Checkbox(Languages.GeneralTab_InstanceInDTRBar, ref instanceInDtrBar))
            {
                configuration.InstanceInDtrBar = instanceInDtrBar;
                configuration.Save();
            }

            bool betterCommendationMessage = configuration.BetterCommendationMessage;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedPlayerCommendations, ref betterCommendationMessage))
            {
                configuration.BetterCommendationMessage = betterCommendationMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedPlayerCommendationsHelpMarker);

            bool includeDutyNameInComms = configuration.IncludeDutyNameInComms;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedCommendationsDutyName, ref includeDutyNameInComms))
            {
                configuration.IncludeDutyNameInComms = includeDutyNameInComms;
                if (!configuration.BetterCommendationMessage && configuration.IncludeDutyNameInComms)
                    configuration.BetterCommendationMessage = true;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedCommendationsDutyNameHelpMarker);

            bool betterSayReminder = configuration.BetterSayReminder;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedSayMessages, ref betterSayReminder))
            {
                configuration.BetterSayReminder = betterSayReminder;
                if (!configuration.BetterSayReminder && configuration.CopyBetterSayReminder)
                    configuration.CopyBetterSayReminder = false;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedSayMessagesHelpMarker);

            bool copyBetterSayReminder = configuration.CopyBetterSayReminder;
            if (ImGui.Checkbox(Languages.GeneralTab_CopySayMessage, ref copyBetterSayReminder))
            {
                configuration.CopyBetterSayReminder = copyBetterSayReminder;
                if (!configuration.BetterSayReminder && configuration.CopyBetterSayReminder)
                    configuration.BetterSayReminder = true;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_CopySayMessageHelpMarker);

            bool betterNoviceNetworkMessage = configuration.BetterNoviceNetworkMessage;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedNoviceNetworkMessages, ref betterNoviceNetworkMessage))
            {
                configuration.BetterNoviceNetworkMessage = betterNoviceNetworkMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedNoviceNetworkMessagesHelpMarker);

            bool betterTreasureDungeonMessage = configuration.BetterTreasureDungeonMessage;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedTreasureDungeonMessages, ref betterTreasureDungeonMessage))
            {
                configuration.BetterTreasureDungeonMessage = betterTreasureDungeonMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedTreasureDungeonMessagesHelpMarker);
        }

        ImGuiHelpers.ScaledDummy(30f);
        ImGui.Separator();
        ImGui.Spacing();

        bool noCoffee = configuration.NoCoffee;
        if (ImGui.Checkbox(Languages.GeneralTab_HideKofiButton, ref noCoffee))
        {
            configuration.NoCoffee = noCoffee;
            configuration.Save();
        }

        ImGui.EndTabItem();
    }
}
