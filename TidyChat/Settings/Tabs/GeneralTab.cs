using Dalamud.Interface.Components;
using Dalamud.Interface.Utility;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class GeneralTab
{
    public static void Draw(Configuration configuration)
    {
        bool filterSystemMessages = configuration.FilterSystemMessages;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterSystemSpam, ref filterSystemMessages))
        {
            configuration.FilterSystemMessages = filterSystemMessages;
            configuration.OnSettingChanged();
        }

        bool filterProgressSpam = configuration.FilterProgressSpam;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterProgressSpam, ref filterProgressSpam))
        {
            configuration.FilterProgressSpam = filterProgressSpam;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterProgressSpamHelpMarker);

        bool filterLootSpam = configuration.FilterLootSpam;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterLootSpam, ref filterLootSpam))
        {
            configuration.FilterLootSpam = filterLootSpam;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterLootSpamHelpMarker);

        bool filterObtainedSpam = configuration.FilterObtainedSpam;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterObtainedSpam, ref filterObtainedSpam))
        {
            configuration.FilterObtainedSpam = filterObtainedSpam;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterObtainedSpamHelpMarker);

        bool filterCraftingSpam = configuration.FilterCraftingSpam;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterCraftingSpam, ref filterCraftingSpam))
        {
            configuration.FilterCraftingSpam = filterCraftingSpam;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterCraftingSpamHelpMarker);

        bool filterGatheringSpam = configuration.FilterGatheringSpam;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterGatheringSpam, ref filterGatheringSpam))
        {
            configuration.FilterGatheringSpam = filterGatheringSpam;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterGatheringSpamHelpMarker);

        if (ImGui.CollapsingHeader(Languages.GeneralTab_DisplayOptionsHeader))
        {
            bool includeChatTag = configuration.IncludeChatTag;
            if (ImGui.Checkbox(Languages.GeneralTab_TidyChatTag, ref includeChatTag))
            {
                configuration.IncludeChatTag = includeChatTag;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_TidyChatTagHelpMarker);

            bool enableSmolMode = configuration.EnableSmolMode;
            if (ImGui.Checkbox(Languages.EnableTinyChat, ref enableSmolMode))
            {
                configuration.EnableSmolMode = enableSmolMode;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.AllMessagesWillBeLowercased);

            bool normalizeBlocks = configuration.NormalizeBlocks;
            if (ImGui.Checkbox(Languages.NormalizeSpecialCharactersExceptInPartyOrAllianceChannels, ref normalizeBlocks))
            {
                configuration.NormalizeBlocks = normalizeBlocks;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.ReplacesSpecialCharactersSuchAsWithA);

            bool alwaysNormalizeBlocks = configuration.AlwaysNormalizeBlocks;
            if (ImGui.Checkbox(Languages.AlwaysNormalizeSpecialCharacters, ref alwaysNormalizeBlocks))
            {
                configuration.AlwaysNormalizeBlocks = alwaysNormalizeBlocks;
                configuration.OnSettingChanged();
            }
        }

        if (ImGui.CollapsingHeader(Languages.GeneralTab_ImprovedMessagesHeader))
        {
            bool betterInstanceMessage = configuration.BetterInstanceMessage;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedInstanceMessaging, ref betterInstanceMessage))
            {
                configuration.BetterInstanceMessage = betterInstanceMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedInstanceMessagingHelpMarker);

            bool betterDutyCommenceMessage = configuration.BetterDutyCommenceMessage;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedDutyCommenceMessaging, ref betterDutyCommenceMessage))
            {
                configuration.BetterDutyCommenceMessage = betterDutyCommenceMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedDutyCommenceMessagingHelpMarker);

            bool instanceInDtrBar = configuration.InstanceInDtrBar;
            if (ImGui.Checkbox(Languages.GeneralTab_InstanceInDTRBar, ref instanceInDtrBar))
            {
                configuration.InstanceInDtrBar = instanceInDtrBar;
                configuration.OnSettingChanged();
            }

            bool betterCommendationMessage = configuration.BetterCommendationMessage;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedPlayerCommendations, ref betterCommendationMessage))
            {
                configuration.BetterCommendationMessage = betterCommendationMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedPlayerCommendationsHelpMarker);

            bool includeDutyNameInComms = configuration.IncludeDutyNameInComms;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedCommendationsDutyName, ref includeDutyNameInComms))
            {
                configuration.IncludeDutyNameInComms = includeDutyNameInComms;
                if (!configuration.BetterCommendationMessage && configuration.IncludeDutyNameInComms)
                    configuration.BetterCommendationMessage = true;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedCommendationsDutyNameHelpMarker);

            bool betterSayReminder = configuration.BetterSayReminder;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedSayMessages, ref betterSayReminder))
            {
                configuration.BetterSayReminder = betterSayReminder;
                if (!configuration.BetterSayReminder && configuration.CopyBetterSayReminder)
                    configuration.CopyBetterSayReminder = false;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedSayMessagesHelpMarker);

            bool copyBetterSayReminder = configuration.CopyBetterSayReminder;
            if (ImGui.Checkbox(Languages.GeneralTab_CopySayMessage, ref copyBetterSayReminder))
            {
                configuration.CopyBetterSayReminder = copyBetterSayReminder;
                if (!configuration.BetterSayReminder && configuration.CopyBetterSayReminder)
                    configuration.BetterSayReminder = true;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_CopySayMessageHelpMarker);

            bool betterNoviceNetworkMessage = configuration.BetterNoviceNetworkMessage;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedNoviceNetworkMessages, ref betterNoviceNetworkMessage))
            {
                configuration.BetterNoviceNetworkMessage = betterNoviceNetworkMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.GeneralTab_ImprovedNoviceNetworkMessagesHelpMarker);

            bool betterTreasureDungeonMessage = configuration.BetterTreasureDungeonMessage;
            if (ImGui.Checkbox(Languages.GeneralTab_ImprovedTreasureDungeonMessages, ref betterTreasureDungeonMessage))
            {
                configuration.BetterTreasureDungeonMessage = betterTreasureDungeonMessage;
                configuration.OnSettingChanged();
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
            configuration.OnSettingChanged();
        }

        ImGui.Spacing();
        ImGui.TextUnformatted(string.Format(Languages.GeneralTab_BlockedMessages,
            configuration.TtlMessagesBlocked.ToString()));
        ImGuiComponents.HelpMarker(Languages.GeneralTab_BlockCountHelpMarker);
    }
}
