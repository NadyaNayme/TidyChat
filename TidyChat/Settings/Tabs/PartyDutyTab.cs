namespace TidyChat.Settings.Tabs;

internal static class PartyDutyTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_PartyAndInviteDropdownHeader, ImGuiTreeNodeFlags.DefaultOpen))
        {
            bool showInviteSent = configuration.ShowInviteSent;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSentPartyInviteMessages, ref showInviteSent))
            {
                configuration.ShowInviteSent = showInviteSent;
                configuration.OnSettingChanged();
            }

            bool showInviteeJoins = configuration.ShowInviteeJoins;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowJoiningPartyMessages, ref showInviteeJoins))
            {
                configuration.ShowInviteeJoins = showInviteeJoins;
                configuration.OnSettingChanged();
            }

            bool showLeftParty = configuration.ShowLeftParty;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowLeftPartyMessages, ref showLeftParty))
            {
                configuration.ShowLeftParty = showLeftParty;
                configuration.OnSettingChanged();
            }

            bool showPartyDisband = configuration.ShowPartyDisband;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowDisbandAndDissolveMessages, ref showPartyDisband))
            {
                configuration.ShowPartyDisband = showPartyDisband;
                configuration.ShowPartyDissolved = showPartyDisband;
                configuration.OnSettingChanged();
            }

            bool showInvitedBy = configuration.ShowInvitedBy;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowReceivedPartyInvitationMessages, ref showInvitedBy))
            {
                configuration.ShowInvitedBy = showInvitedBy;
                configuration.OnSettingChanged();
            }

            bool showJoinParty = configuration.ShowJoinParty;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowJoinedCrossworldPartyMessages, ref showJoinParty))
            {
                configuration.ShowJoinParty = showJoinParty;
                configuration.OnSettingChanged();
            }

            bool showPartyInformation = configuration.ShowPartyInformation;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowPartyObjectiveOnJoin, ref showPartyInformation))
            {
                configuration.ShowPartyInformation = showPartyInformation;
                configuration.OnSettingChanged();
            }

            bool showOfferedTeleport = configuration.ShowOfferedTeleport;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowTeleportOfferFromPartyMessages, ref showOfferedTeleport))
            {
                configuration.ShowOfferedTeleport = showOfferedTeleport;
                configuration.OnSettingChanged();
            }
        }

        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_PartyToolsDropdownHeader))
        {
            bool showCountdownTime = configuration.ShowCountdownTime;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCountdownMessages, ref showCountdownTime))
            {
                configuration.ShowCountdownTime = showCountdownTime;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowCountdownMessagesHelpMarker);

            bool showReadyChecks = configuration.ShowReadyChecks;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowReadycheckMessages, ref showReadyChecks))
            {
                configuration.ShowReadyChecks = showReadyChecks;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowReadycheckMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_PartyLeadershipDropdownHeader))
        {
            bool showNowLeaderOf = configuration.ShowNowLeaderOf;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowNowALeader, ref showNowLeaderOf))
            {
                configuration.ShowNowLeaderOf = showNowLeaderOf;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowNowALeaderHelpMarker);

            bool showSealedOff = configuration.ShowSealedOff;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSealedOffMessages, ref showSealedOff))
            {
                configuration.ShowSealedOff = showSealedOff;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowSealedOffMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_DutyFinderDropdownHeader))
        {
            bool showDutyFinder = configuration.ShowDutyFinder;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowDutyFinderMessages, ref showDutyFinder))
            {
                configuration.ShowDutyFinder = showDutyFinder;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowDutyFinderMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_DutyCompletionDropdownHeader))
        {
            bool showCompletionTime = configuration.ShowCompletionTime;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCompletionTimeForUnrestrictedParty, ref showCompletionTime))
            {
                configuration.ShowCompletionTime = showCompletionTime;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowCompletionTimeForUnrestrictedPartyHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_RetainerAndVentureDropdownHeader))
        {
            bool completedVenture = configuration.ShowCompletedVenture;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCompletedVenture, ref completedVenture))
            {
                configuration.ShowCompletedVenture = completedVenture;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowCompletedVentureHelpMarker);

            bool retainerVentureMessages = configuration.ShowRetainerVentureMessages;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowRetainerVentureMessages, ref retainerVentureMessages))
            {
                configuration.ShowRetainerVentureMessages = retainerVentureMessages;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowRetainerVentureMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_FreeCompanyDropdownHeader))
        {
            bool showUserLogins = configuration.ShowUserLogins;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowLoginMessages, ref showUserLogins))
            {
                configuration.ShowUserLogins = showUserLogins;
                configuration.OnSettingChanged();
            }

            bool showUserLogouts = configuration.ShowUserLogouts;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowLogoutMessages, ref showUserLogouts))
            {
                configuration.ShowUserLogouts = showUserLogouts;
                configuration.OnSettingChanged();
            }

            bool showFreeCompanyMessageBook = configuration.ShowFreeCompanyMessageBook;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowFreeCompanyMessageBookMessages,
                    ref showFreeCompanyMessageBook))
            {
                configuration.ShowFreeCompanyMessageBook = showFreeCompanyMessageBook;
                configuration.OnSettingChanged();
            }

            bool showExploratoryVoyage = configuration.ShowExploratoryVoyage;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAirshipVoyageMessages, ref showExploratoryVoyage))
            {
                configuration.ShowExploratoryVoyage = showExploratoryVoyage;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowAirshipVoyageMessagesHelpMarker);

            bool showSubaquaticVoyage = configuration.ShowSubaquaticVoyage;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSubmarineVoyageMessages, ref showSubaquaticVoyage))
            {
                configuration.ShowSubaquaticVoyage = showSubaquaticVoyage;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowSubmarineVoyageMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.PartyDutyTab_DeepDungeonsDropdownHeader))
        {
            bool showCairnGlows = configuration.ShowCairnGlows;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCairnOfPassageGlowsMessages, ref showCairnGlows))
            {
                configuration.ShowCairnGlows = showCairnGlows;
                configuration.OnSettingChanged();
            }

            bool showRestoresLifeToFallen = configuration.ShowRestoresLifeToFallen;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCairnOfReturnUsedMessages, ref showRestoresLifeToFallen))
            {
                configuration.ShowRestoresLifeToFallen = showRestoresLifeToFallen;
                configuration.OnSettingChanged();
            }

            bool showCairnActivates = configuration.ShowCairnActivates;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCairnOfPassageActivatedMessages, ref showCairnActivates))
            {
                configuration.ShowCairnActivates = showCairnActivates;
                configuration.OnSettingChanged();
            }

            bool showTransference = configuration.ShowTransference;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowTransferenceMessages, ref showTransference))
            {
                configuration.ShowTransference = showTransference;
                configuration.OnSettingChanged();
            }

            bool showAetherpoolIncrease = configuration.ShowAetherpoolIncrease;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAetherpoolIncreasesMessages, ref showAetherpoolIncrease))
            {
                configuration.ShowAetherpoolIncrease = showAetherpoolIncrease;
                configuration.OnSettingChanged();
            }

            bool showAetherpoolUnchanged = configuration.ShowAetherpoolUnchanged;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAetherpoolRemainsUnchangedMessages,
                    ref showAetherpoolUnchanged))
            {
                configuration.ShowAetherpoolUnchanged = showAetherpoolUnchanged;
                configuration.OnSettingChanged();
            }

            bool showObtainedPomander = configuration.ShowObtainedPomander;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowObtainedPomanderMessages, ref showObtainedPomander))
            {
                configuration.ShowObtainedPomander = showObtainedPomander;
                configuration.OnSettingChanged();
            }

            bool showTrapTriggered = configuration.ShowTrapTriggered;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowTrapTriggeredMessages, ref showTrapTriggered))
            {
                configuration.ShowTrapTriggered = showTrapTriggered;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowTrapTriggeredMessagesHelpMarker);

            bool showPomanderEffects = configuration.ShowPomanderEffects;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowPomanderEffectsMessages, ref showPomanderEffects))
            {
                configuration.ShowPomanderEffects = showPomanderEffects;
                configuration.OnSettingChanged();
            }

            bool showFloorNumber = configuration.ShowFloorNumber;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowFloorNumberMessages, ref showFloorNumber))
            {
                configuration.ShowFloorNumber = showFloorNumber;
                configuration.OnSettingChanged();
            }

            bool showSenseAccursedHoard = configuration.ShowSenseAccursedHoard;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAccursedHoardSensedMessages, ref showSenseAccursedHoard))
            {
                configuration.ShowSenseAccursedHoard = showSenseAccursedHoard;
                configuration.OnSettingChanged();
            }

            bool showDoNotSenseAccursedHoard = configuration.ShowDoNotSenseAccursedHoard;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAccursedHoardNotSensedMessages,
                    ref showDoNotSenseAccursedHoard))
            {
                configuration.ShowDoNotSenseAccursedHoard = showDoNotSenseAccursedHoard;
                configuration.OnSettingChanged();
            }

            bool showDiscoverAccursedHoard = configuration.ShowDiscoverAccursedHoard;
            if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAccursedHoardDiscoveredMessages,
                    ref showDiscoverAccursedHoard))
            {
                configuration.ShowDiscoverAccursedHoard = showDiscoverAccursedHoard;
                configuration.OnSettingChanged();
            }
        }
    }
}
