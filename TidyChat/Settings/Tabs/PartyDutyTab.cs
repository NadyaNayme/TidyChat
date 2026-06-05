namespace TidyChat.Settings.Tabs;

internal static class PartyDutyTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_PartyAndInviteDropdownHeader, ImGuiTreeNodeFlags.DefaultOpen))
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

        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_PartyToolsDropdownHeader))
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

        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_PartyLeadershipDropdownHeader))
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

        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_DutyFinderDropdownHeader))
        {
            var showDutyFinder = configuration.ShowDutyFinder;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowDutyFinderMessages, ref showDutyFinder))
            {
                configuration.ShowDutyFinder = showDutyFinder;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowDutyFinderMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_DutyCompletionDropdownHeader))
        {
            var showCompletionTime = configuration.ShowCompletionTime;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCompletionTimeForUnrestrictedParty, ref showCompletionTime))
            {
                configuration.ShowCompletionTime = showCompletionTime;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowCompletionTimeForUnrestrictedPartyHelpMarker);
        }
    }
}
