using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class PartyDutyTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.SystemTab_PartyAndInviteDropdownHeader, ImGuiTreeNodeFlags.DefaultOpen))
        {
            bool showInviteSent = configuration.ShowInviteSent;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSentPartyInviteMessages, ref showInviteSent))
            {
                configuration.ShowInviteSent = showInviteSent;
                configuration.OnSettingChanged();
            }

            bool showInviteeJoins = configuration.ShowInviteeJoins;
            if (ImGui.Checkbox(Languages.SystemTab_ShowJoiningPartyMessages, ref showInviteeJoins))
            {
                configuration.ShowInviteeJoins = showInviteeJoins;
                configuration.OnSettingChanged();
            }

            bool showLeftParty = configuration.ShowLeftParty;
            if (ImGui.Checkbox(Languages.SystemTab_ShowLeftPartyMessages, ref showLeftParty))
            {
                configuration.ShowLeftParty = showLeftParty;
                configuration.OnSettingChanged();
            }

            bool showPartyDisband = configuration.ShowPartyDisband;
            if (ImGui.Checkbox(Languages.SystemTab_ShowDisbandAndDissolveMessages, ref showPartyDisband))
            {
                configuration.ShowPartyDisband = showPartyDisband;
                configuration.ShowPartyDissolved = showPartyDisband;
                configuration.OnSettingChanged();
            }

            bool showInvitedBy = configuration.ShowInvitedBy;
            if (ImGui.Checkbox(Languages.SystemTab_ShowReceivedPartyInvitationMessages, ref showInvitedBy))
            {
                configuration.ShowInvitedBy = showInvitedBy;
                configuration.OnSettingChanged();
            }

            bool showJoinParty = configuration.ShowJoinParty;
            if (ImGui.Checkbox(Languages.SystemTab_ShowJoinedCrossworldPartyMessages, ref showJoinParty))
            {
                configuration.ShowJoinParty = showJoinParty;
                configuration.OnSettingChanged();
            }

            bool showPartyInformation = configuration.ShowPartyInformation;
            if (ImGui.Checkbox(Languages.ShowPartyObjectiveAndPartyCommentWhenJoiningAParty, ref showPartyInformation))
            {
                configuration.ShowPartyInformation = showPartyInformation;
                configuration.OnSettingChanged();
            }

            bool showOfferedTeleport = configuration.ShowOfferedTeleport;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTeleportOfferFromPartyMessages, ref showOfferedTeleport))
            {
                configuration.ShowOfferedTeleport = showOfferedTeleport;
                configuration.OnSettingChanged();
            }
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_PartyToolsDropdownHeader))
        {
            bool showCountdownTime = configuration.ShowCountdownTime;
            if (ImGui.Checkbox(Languages.SystemTab_HideCountdownMessages, ref showCountdownTime))
            {
                configuration.ShowCountdownTime = showCountdownTime;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideCountdownMessagesHelpMarker);

            bool showReadyChecks = configuration.ShowReadyChecks;
            if (ImGui.Checkbox(Languages.SystemTab_HideReadycheckMessages, ref showReadyChecks))
            {
                configuration.ShowReadyChecks = showReadyChecks;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideReadycheckMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_PartyLeadershipDropdownHeader))
        {
            bool showNowLeaderOf = configuration.ShowNowLeaderOf;
            if (ImGui.Checkbox(Languages.SystemTab_ShowNowALeader, ref showNowLeaderOf))
            {
                configuration.ShowNowLeaderOf = showNowLeaderOf;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowNowALeaderHelpMarker);

            bool showSealedOff = configuration.ShowSealedOff;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSealedOffMessages, ref showSealedOff))
            {
                configuration.ShowSealedOff = showSealedOff;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowSealedOffMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_DutyFinderDropdownHeader))
        {
            bool showDutyFinder = configuration.ShowDutyFinder;
            if (ImGui.Checkbox(Languages.SystemTab_ShowDutyFinderMessages, ref showDutyFinder))
            {
                configuration.ShowDutyFinder = showDutyFinder;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowDutyFinderMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_DutyCompletionDropdownHeader))
        {
            bool showCompletionTime = configuration.ShowCompletionTime;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCompletionTimeForUnrestrictedParty, ref showCompletionTime))
            {
                configuration.ShowCompletionTime = showCompletionTime;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowCompletionTimeForUnrestrictedPartyHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_RetainerAndVentureDropdownHeader))
        {
            bool completedVenture = configuration.ShowCompletedVenture;
            if (ImGui.Checkbox(Languages.SystemTab_HideCompletedVenture, ref completedVenture))
            {
                configuration.ShowCompletedVenture = completedVenture;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideCompletedVentureHelpMarker);

            bool retainerVentureMessages = configuration.ShowRetainerVentureMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowRetainerVentureMessages, ref retainerVentureMessages))
            {
                configuration.ShowRetainerVentureMessages = retainerVentureMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowRetainerVentureMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_FreeCompanyDropdownHeader))
        {
            bool showUserLogins = configuration.ShowUserLogins;
            if (ImGui.Checkbox(Languages.SystemTab_HideLoginMessages, ref showUserLogins))
            {
                configuration.ShowUserLogins = showUserLogins;
                configuration.OnSettingChanged();
            }

            bool showUserLogouts = configuration.ShowUserLogouts;
            if (ImGui.Checkbox(Languages.SystemTab_HideLogoutMessages, ref showUserLogouts))
            {
                configuration.ShowUserLogouts = showUserLogouts;
                configuration.OnSettingChanged();
            }

            bool showFreeCompanyMessageBook = configuration.ShowFreeCompanyMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_HideFreeCompanyMessageBookMessages,
                    ref showFreeCompanyMessageBook))
            {
                configuration.ShowFreeCompanyMessageBook = showFreeCompanyMessageBook;
                configuration.OnSettingChanged();
            }

            bool showExploratoryVoyage = configuration.ShowExploratoryVoyage;
            if (ImGui.Checkbox(Languages.SystemTab_HideAirshipVoyageMessages, ref showExploratoryVoyage))
            {
                configuration.ShowExploratoryVoyage = showExploratoryVoyage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideAirshipVoyageMessagesHelpMarker);

            bool showSubaquaticVoyage = configuration.ShowSubaquaticVoyage;
            if (ImGui.Checkbox(Languages.SystemTab_HideSubmarineVoyageMessages, ref showSubaquaticVoyage))
            {
                configuration.ShowSubaquaticVoyage = showSubaquaticVoyage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSubmarineVoyageMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_DeepDungeonsDropdownHeader))
        {
            bool showCairnGlows = configuration.ShowCairnGlows;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCairnOfPassageGlowsMessages, ref showCairnGlows))
            {
                configuration.ShowCairnGlows = showCairnGlows;
                configuration.OnSettingChanged();
            }

            bool showRestoresLifeToFallen = configuration.ShowRestoresLifeToFallen;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCairnOfReturnUsedMessages, ref showRestoresLifeToFallen))
            {
                configuration.ShowRestoresLifeToFallen = showRestoresLifeToFallen;
                configuration.OnSettingChanged();
            }

            bool showCairnActivates = configuration.ShowCairnActivates;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCairnOfPassageActivatedMessages, ref showCairnActivates))
            {
                configuration.ShowCairnActivates = showCairnActivates;
                configuration.OnSettingChanged();
            }

            bool showTransference = configuration.ShowTransference;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTransferenceMessages, ref showTransference))
            {
                configuration.ShowTransference = showTransference;
                configuration.OnSettingChanged();
            }

            bool showAetherpoolIncrease = configuration.ShowAetherpoolIncrease;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetherpoolIncreasesMessages, ref showAetherpoolIncrease))
            {
                configuration.ShowAetherpoolIncrease = showAetherpoolIncrease;
                configuration.OnSettingChanged();
            }

            bool showAetherpoolUnchanged = configuration.ShowAetherpoolUnchanged;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetherpoolRemainsUnchangedMessages,
                    ref showAetherpoolUnchanged))
            {
                configuration.ShowAetherpoolUnchanged = showAetherpoolUnchanged;
                configuration.OnSettingChanged();
            }

            bool showObtainedPomander = configuration.ShowObtainedPomander;
            if (ImGui.Checkbox(Languages.SystemTab_ShowObtainedPomanderMessages, ref showObtainedPomander))
            {
                configuration.ShowObtainedPomander = showObtainedPomander;
                configuration.OnSettingChanged();
            }

            bool showTrapTriggered = configuration.ShowTrapTriggered;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTrapTriggeredMessages, ref showTrapTriggered))
            {
                configuration.ShowTrapTriggered = showTrapTriggered;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowTrapTriggeredMessagesHelpMarker);

            bool showPomanderEffects = configuration.ShowPomanderEffects;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPomanderEffectsMessages, ref showPomanderEffects))
            {
                configuration.ShowPomanderEffects = showPomanderEffects;
                configuration.OnSettingChanged();
            }

            bool showFloorNumber = configuration.ShowFloorNumber;
            if (ImGui.Checkbox(Languages.SystemTab_ShowFloorNumberMessages, ref showFloorNumber))
            {
                configuration.ShowFloorNumber = showFloorNumber;
                configuration.OnSettingChanged();
            }

            bool showSenseAccursedHoard = configuration.ShowSenseAccursedHoard;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAccursedHoardSensedMessages, ref showSenseAccursedHoard))
            {
                configuration.ShowSenseAccursedHoard = showSenseAccursedHoard;
                configuration.OnSettingChanged();
            }

            bool showDoNotSenseAccursedHoard = configuration.ShowDoNotSenseAccursedHoard;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAccursedHoardNotSensedMessages,
                    ref showDoNotSenseAccursedHoard))
            {
                configuration.ShowDoNotSenseAccursedHoard = showDoNotSenseAccursedHoard;
                configuration.OnSettingChanged();
            }

            bool showDiscoverAccursedHoard = configuration.ShowDiscoverAccursedHoard;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAccursedHoardDiscoveredMessages,
                    ref showDiscoverAccursedHoard))
            {
                configuration.ShowDiscoverAccursedHoard = showDiscoverAccursedHoard;
                configuration.OnSettingChanged();
            }
        }
    }
}
