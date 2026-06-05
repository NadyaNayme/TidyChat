namespace TidyChat.Settings.Tabs;

internal static class PartyTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.PartyTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.PartyDutyTab_PartyAndInviteDropdownHeader, () => DrawPartyAndInvite(configuration)),
            (Languages.PartyDutyTab_PartyToolsDropdownHeader, () => DrawPartyTools(configuration)),
            (Languages.PartyDutyTab_PartyLeadershipDropdownHeader, () => DrawPartyLeadership(configuration)),
            (Languages.ObtainTab_LootingAndRollingDropdownHeader, () => DrawLootingAndRolling(configuration)));
    }

    private static void DrawPartyAndInvite(Configuration configuration)
    {
            var showInviteSent = configuration.ShowInviteSent;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSentPartyInviteMessages, ref showInviteSent))
            {
                configuration.ShowInviteSent = showInviteSent;
                configuration.OnSettingChanged();
            }

            var showInviteeJoins = configuration.ShowInviteeJoins;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowJoiningPartyMessages, ref showInviteeJoins))
            {
                configuration.ShowInviteeJoins = showInviteeJoins;
                configuration.OnSettingChanged();
            }

            var showLeftParty = configuration.ShowLeftParty;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowLeftPartyMessages, ref showLeftParty))
            {
                configuration.ShowLeftParty = showLeftParty;
                configuration.OnSettingChanged();
            }

            var showPartyDisband = configuration.ShowPartyDisband;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowDisbandAndDissolveMessages, ref showPartyDisband))
            {
                configuration.ShowPartyDisband = showPartyDisband;
                configuration.ShowPartyDissolved = showPartyDisband;
                configuration.OnSettingChanged();
            }

            var showInvitedBy = configuration.ShowInvitedBy;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowReceivedPartyInvitationMessages, ref showInvitedBy))
            {
                configuration.ShowInvitedBy = showInvitedBy;
                configuration.OnSettingChanged();
            }

            var showJoinParty = configuration.ShowJoinParty;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowJoinedCrossworldPartyMessages, ref showJoinParty))
            {
                configuration.ShowJoinParty = showJoinParty;
                configuration.OnSettingChanged();
            }

            var showPartyInformation = configuration.ShowPartyInformation;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowPartyObjectiveOnJoin, ref showPartyInformation))
            {
                configuration.ShowPartyInformation = showPartyInformation;
                configuration.OnSettingChanged();
            }

            var showOfferedTeleport = configuration.ShowOfferedTeleport;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowTeleportOfferFromPartyMessages, ref showOfferedTeleport))
            {
                configuration.ShowOfferedTeleport = showOfferedTeleport;
                configuration.OnSettingChanged();
            }
    }

    private static void DrawPartyTools(Configuration configuration)
    {
            var showCountdownTime = configuration.ShowCountdownTime;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCountdownMessages, ref showCountdownTime))
            {
                configuration.ShowCountdownTime = showCountdownTime;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowCountdownMessagesHelpMarker);

            var showReadyChecks = configuration.ShowReadyChecks;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowReadycheckMessages, ref showReadyChecks))
            {
                configuration.ShowReadyChecks = showReadyChecks;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowReadycheckMessagesHelpMarker);
    }

    private static void DrawPartyLeadership(Configuration configuration)
    {
            var showNowLeaderOf = configuration.ShowNowLeaderOf;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowNowALeader, ref showNowLeaderOf))
            {
                configuration.ShowNowLeaderOf = showNowLeaderOf;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowNowALeaderHelpMarker);

            var showSealedOff = configuration.ShowSealedOff;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSealedOffMessages, ref showSealedOff))
            {
                configuration.ShowSealedOff = showSealedOff;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowSealedOffMessagesHelpMarker);
    }

    private static void DrawLootingAndRolling(Configuration configuration)
    {
            var showCastLot = configuration.ShowCastLot;
            if (ImGui.Checkbox(Languages.ObtainTab_CastYourLotMessages, ref showCastLot))
            {
                configuration.ShowCastLot = showCastLot;
                configuration.OnSettingChanged();
            }

            UiHelp.LootFilterMarker(Languages.ObtainTab_CastYourLotHelpMarker);

            var showLootRoll = configuration.ShowLootRoll;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowYouRolledMessages, ref showLootRoll))
            {
                configuration.ShowLootRoll = showLootRoll;
                configuration.OnSettingChanged();
            }

            UiHelp.LootFilterMarker(Languages.ObtainTab_ShowYouRolledMessagesHelpMarker);

            var showOthersCastLot = configuration.ShowOthersCastLot;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerCastsLotMessages, ref showOthersCastLot))
            {
                configuration.ShowOthersCastLot = showOthersCastLot;
                configuration.OnSettingChanged();
            }

            UiHelp.LootFilterMarker(Languages.ObtainTab_ShowAnotherPlayerCastsLotMessagesHelpMarker);

            var showOthersLootRoll = configuration.ShowOthersLootRoll;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerRollsMessages, ref showOthersLootRoll))
            {
                configuration.ShowOthersLootRoll = showOthersLootRoll;
                configuration.OnSettingChanged();
            }

            UiHelp.LootFilterMarker(Languages.ObtainTab_ShowAnotherPlayerRollsMessagesHelpMarker);

            SettingsTabLayout.DrawNestedOptions(configuration.ShowOthersLootRoll, () =>
            {
                var showOnlyPartyMemberRolls = configuration.ShowOnlyPartyMemberRolls;
                if (ImGui.Checkbox(Languages.ObtainTab_ShowOnlyPartyMemberRolls, ref showOnlyPartyMemberRolls))
                {
                    configuration.ShowOnlyPartyMemberRolls = showOnlyPartyMemberRolls;
                    configuration.OnSettingChanged();
                }

                UiHelp.LootFilterMarker(Languages.ObtainTab_ShowOnlyPartyMemberRollsHelpMarker);
            });

            SettingsTabLayout.DrawIndependentOptions(() =>
            {
                var hideOthersObtain = configuration.HideOthersObtain;
                if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerObtainsItemMessages, ref hideOthersObtain))
                {
                    configuration.HideOthersObtain = hideOthersObtain;
                    configuration.OnSettingChanged();
                }

                UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowAnotherPlayerObtainsItemMessagesHelpMarker);
            });
    }
}
