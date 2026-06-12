using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class PartyTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.PartyTab_FilteringNote);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterSystemMessages, Languages.GeneralTab_FilterSystemSpam);

        SettingsTabLayout.DrawSections(true,
            (Languages.PartyTab_PartyAndInviteDropdownHeader, () => DrawPartyAndInvite(configuration)),
            (Languages.PartyTab_LootingAndRollingDropdownHeader, () => DrawLootingAndRolling(configuration)));
    }

    private static void DrawPartyAndInvite(Configuration configuration)
    {
        // Joining a party
        var showInvitedBy = configuration.ShowInvitedBy;
        if (ImGui.Checkbox(Languages.PartyTab_ShowReceivedPartyInvitationMessages, ref showInvitedBy))
        {
            configuration.ShowInvitedBy = showInvitedBy;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyTab_ShowReceivedPartyInvitationMessagesHelpMarker);

        var showJoinParty = configuration.ShowJoinParty;
        if (ImGui.Checkbox(Languages.PartyTab_ShowJoinedCrossworldPartyMessages, ref showJoinParty))
        {
            configuration.ShowJoinParty = showJoinParty;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyTab_ShowJoinedCrossworldPartyMessagesHelpMarker);

        var showPartyInformation = configuration.ShowPartyInformation;
        if (ImGui.Checkbox(Languages.PartyTab_ShowPartyObjectiveOnJoin, ref showPartyInformation))
        {
            configuration.ShowPartyInformation = showPartyInformation;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.PartyTab_ShowPartyObjectiveOnJoinHelpMarker);

        // Inviting others
        var showInviteSent = configuration.ShowInviteSent;
        if (ImGui.Checkbox(Languages.PartyTab_ShowSentPartyInviteMessages, ref showInviteSent))
        {
            configuration.ShowInviteSent = showInviteSent;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyTab_ShowSentPartyInviteMessagesHelpMarker);

        var showInviteeJoins = configuration.ShowInviteeJoins;
        if (ImGui.Checkbox(Languages.PartyTab_ShowJoiningPartyMessages, ref showInviteeJoins))
        {
            configuration.ShowInviteeJoins = showInviteeJoins;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyTab_ShowJoiningPartyMessagesHelpMarker);

        // Mid-party events
        var showOfferedTeleport = configuration.ShowOfferedTeleport;
        if (ImGui.Checkbox(Languages.PartyTab_ShowTeleportOfferFromPartyMessages, ref showOfferedTeleport))
        {
            configuration.ShowOfferedTeleport = showOfferedTeleport;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyTab_ShowTeleportOfferFromPartyMessagesHelpMarker);

        var showLeftParty = configuration.ShowLeftParty;
        if (ImGui.Checkbox(Languages.PartyTab_ShowLeftPartyMessages, ref showLeftParty))
        {
            configuration.ShowLeftParty = showLeftParty;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyTab_ShowLeftPartyMessagesHelpMarker);

        var showPartyDisband = configuration.ShowPartyDisband;
        if (ImGui.Checkbox(Languages.PartyTab_ShowDisbandAndDissolveMessages, ref showPartyDisband))
        {
            configuration.ShowPartyDisband = showPartyDisband;
            configuration.ShowPartyDissolved = showPartyDisband;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyTab_ShowDisbandAndDissolveMessagesHelpMarker);

        var commendations = configuration.ShowCommendations;
        if (ImGui.Checkbox(Languages.PartyTab_ShowReceivedCommendations, ref commendations))
        {
            configuration.ShowCommendations = commendations;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyTab_ShowReceivedCommendationsHelpMarker);
    }

    private static void DrawLootingAndRolling(Configuration configuration)
    {
        var showCastLot = configuration.ShowCastLot;
        if (ImGui.Checkbox(Languages.PartyTab_CastYourLotMessages, ref showCastLot))
        {
            configuration.ShowCastLot = showCastLot;
            configuration.OnSettingChanged();
        }

        UiHelp.LootFilterMarker(Languages.PartyTab_CastYourLotHelpMarker);

        var showLootRoll = configuration.ShowLootRoll;
        if (ImGui.Checkbox(Languages.PartyTab_ShowYouRolledMessages, ref showLootRoll))
        {
            configuration.ShowLootRoll = showLootRoll;
            configuration.OnSettingChanged();
        }

        UiHelp.LootFilterMarker(Languages.PartyTab_ShowYouRolledMessagesHelpMarker);

        var showOthersCastLot = configuration.ShowOthersCastLot;
        if (ImGui.Checkbox(Languages.PartyTab_ShowAnotherPlayerCastsLotMessages, ref showOthersCastLot))
        {
            configuration.ShowOthersCastLot = showOthersCastLot;
            configuration.OnSettingChanged();
        }

        UiHelp.LootFilterMarker(Languages.PartyTab_ShowAnotherPlayerCastsLotMessagesHelpMarker);

        var showOthersLootRoll = configuration.ShowOthersLootRoll;
        if (ImGui.Checkbox(Languages.PartyTab_ShowAnotherPlayerRollsMessages, ref showOthersLootRoll))
        {
            configuration.ShowOthersLootRoll = showOthersLootRoll;
            configuration.OnSettingChanged();
        }

        UiHelp.LootFilterMarker(Languages.PartyTab_ShowAnotherPlayerRollsMessagesHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowOthersLootRoll, () =>
        {
            var showOnlyPartyMemberRolls = configuration.ShowOnlyPartyMemberRolls;
            if (ImGui.Checkbox(Languages.PartyTab_ShowOnlyPartyMemberRolls, ref showOnlyPartyMemberRolls))
            {
                configuration.ShowOnlyPartyMemberRolls = showOnlyPartyMemberRolls;
                configuration.OnSettingChanged();
            }

            UiHelp.LootFilterMarker(Languages.PartyTab_ShowOnlyPartyMemberRollsHelpMarker);
        });

        SettingsTabLayout.DrawIndependentOptions(() =>
        {
            var showOthersObtain = !configuration.HideOthersObtain;
            if (ImGui.Checkbox(Languages.PartyTab_HideAnotherPlayerObtainsItemMessages, ref showOthersObtain))
            {
                configuration.HideOthersObtain = !showOthersObtain;
                configuration.OnSettingChanged();
            }

            UiHelp.LootFilterMarker(Languages.PartyTab_HideAnotherPlayerObtainsItemMessagesHelpMarker);
        });
    }
}
