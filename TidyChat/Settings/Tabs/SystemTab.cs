using Dalamud.Interface.Components;
using ImGuiNET;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings.Tabs;

internal static class SystemTab
{
    public static void Draw(Configuration configuration)
    {
        var enableInverseMode = configuration.EnableInverseMode;
        if (ImGui.Checkbox(Languages.SystemTab_ExperimentalFeatureInverseMode, ref enableInverseMode))
        {
            configuration.EnableInverseMode = enableInverseMode;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.SystemTab_ExperimentalFeatureInverseModeHelpMarker);

        if (configuration.EnableInverseMode)
            ImGui.TextUnformatted(Languages.SystemTab_ExperimentalFeatureInverseModeWarningText);
        if (ImGui.CollapsingHeader(Languages.SystemTab_HideShownDefaultDropdownHeader))
        {
            var instanceMessage = configuration.ShowInstanceMessage;
            if (ImGui.Checkbox(Languages.SystemTab_HideInstanceMessage, ref instanceMessage))
            {
                configuration.ShowInstanceMessage = instanceMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideInstanceMessageHelpMarker);

            var showDebugTeleport = configuration.ShowDebugTeleport;
            if (ImGui.Checkbox(Languages.SystemTab_HideTeleportingToMessages, ref showDebugTeleport))
            {
                configuration.ShowDebugTeleport = showDebugTeleport;
                configuration.Save();
            }

            var sRankHunt = configuration.ShowSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_HideSRankSpawnAnnouncement, ref sRankHunt))
            {
                configuration.ShowSRankHunt = sRankHunt;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSRankSpawnAnnouncementHelpMarker);

            var ssRankHunt = configuration.ShowSSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_HideSSRankMinionSpawnAnnouncement, ref ssRankHunt))
            {
                configuration.ShowSSRankHunt = ssRankHunt;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSSRankMinionSpawnAnnouncementHelpMarker);

            var commendations = configuration.ShowCommendations;
            if (ImGui.Checkbox(Languages.SystemTab_HideReceivedCommendations, ref commendations))
            {
                configuration.ShowCommendations = commendations;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideReceivedCommendationsHelpMarker);

            var completedVenture = configuration.ShowCompletedVenture;
            if (ImGui.Checkbox(Languages.SystemTab_HideCompletedVenture, ref completedVenture))
            {
                configuration.ShowCompletedVenture = completedVenture;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideCompletedVentureHelpMarker);

            var showQuestReminder = configuration.ShowQuestReminder;
            if (ImGui.Checkbox(Languages.SystemTab_HideSayReminder, ref showQuestReminder))
            {
                configuration.ShowQuestReminder = showQuestReminder;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSayReminderHelpMarker);

            var showSpideySenses = configuration.ShowSpideySenses;
            if (ImGui.Checkbox(Languages.SystemTab_HideYouSenseSomethingMessages, ref showSpideySenses))
            {
                configuration.ShowSpideySenses = showSpideySenses;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideYouSenseSomethingMessagesHelpMarker);

            var showAetherCompass = configuration.ShowAetherCompass;
            if (ImGui.Checkbox(Languages.SystemTab_HideAetherCompassMessages, ref showAetherCompass))
            {
                configuration.ShowAetherCompass = showAetherCompass;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideAetherCompassMessagesHelpMarker);

            var showCountdownTime = configuration.ShowCountdownTime;
            if (ImGui.Checkbox(Languages.SystemTab_HideCountdownMessages, ref showCountdownTime))
            {
                configuration.ShowCountdownTime = showCountdownTime;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideCountdownMessagesHelpMarker);

            var showReadyChecks = configuration.ShowReadyChecks;
            if (ImGui.Checkbox(Languages.SystemTab_HideReadycheckMessages, ref showReadyChecks))
            {
                configuration.ShowReadyChecks = showReadyChecks;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideReadycheckMessagesHelpMarker);

            var showSearchForItemResults = configuration.ShowSearchForItemResults;
            if (ImGui.Checkbox(Languages.SystemTab_HideItemSearchResultsMessage, ref showSearchForItemResults))
            {
                configuration.ShowSearchForItemResults = showSearchForItemResults;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideItemSearchResultsMessageHelpMarker);

            var showVistaMessages = configuration.ShowVistaMessages;
            if (ImGui.Checkbox(Languages.SystemTab_HideVistaMessages, ref showVistaMessages))
            {
                configuration.ShowVistaMessages = showVistaMessages;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideVistaMessagesHelpMarker);

            var showTryOnGlamour = configuration.ShowTryOnGlamour;
            if (ImGui.Checkbox(Languages.SystemTab_HideTryOnGlamourMessages, ref showTryOnGlamour))
            {
                configuration.ShowTryOnGlamour = showTryOnGlamour;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideTryOnGlamourMessagesHelpMarker);

            var showPersonalMessageBook = configuration.ShowPersonalMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_HidePersonalMessageBookMessages, ref showPersonalMessageBook))
            {
                configuration.ShowPersonalMessageBook = showPersonalMessageBook;
                configuration.Save();
            }

            var showSpiritboundGear = configuration.ShowSpiritboundGear;
            if (ImGui.Checkbox(Languages.SystemTab_HideSpiritboundMessages, ref showSpiritboundGear))
            {
                configuration.ShowSpiritboundGear = showSpiritboundGear;
                configuration.Save();
            }

            var showEligibleForCoffers = configuration.ShowEligibleForCoffers;
            if (ImGui.Checkbox(Languages.SystemTab_HideNumberOfCoffers, ref showEligibleForCoffers))
            {
                configuration.ShowEligibleForCoffers = showEligibleForCoffers;
                configuration.Save();
            }

            var showNoviceNetworkFull = configuration.ShowNoviceNetworkFull;
            if (ImGui.Checkbox(Languages.SystemTab_HideUnableToJoinFullNoviceNetwork, ref showNoviceNetworkFull))
            {
                configuration.ShowNoviceNetworkFull = showNoviceNetworkFull;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_ShowHiddenMessagesDropdownHeader))
        {
            var showOnlineStatus = configuration.ShowOnlineStatus;
            if (ImGui.Checkbox(Languages.SystemTab_ShowOnlineStatusMessages, ref showOnlineStatus))
            {
                configuration.ShowOnlineStatus = showOnlineStatus;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowOnlineStatusMessagesHelpMarker);

            var showAttachToMail = configuration.ShowAttachToMail;
            if (ImGui.Checkbox(Languages.SystemTab_ShowMailAttachmentMessages, ref showAttachToMail))
            {
                configuration.ShowAttachToMail = showAttachToMail;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowMailAttachmentMessagesHelpMarker);

            var showRelicBookStep = configuration.ShowRelicBookStep;
            if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicProgressMessages, ref showRelicBookStep))
            {
                configuration.ShowRelicBookStep = showRelicBookStep;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowARRRelicProgressMessagesHelpMarker);

            var showRelicBookComplete = configuration.ShowRelicBookComplete;
            if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicBookStepMessages, ref showRelicBookComplete))
            {
                configuration.ShowRelicBookComplete = showRelicBookComplete;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowARRRelicBookStepMessagesHelpMarker);

            var showHuntSlain = configuration.ShowHuntSlain;
            if (ImGui.Checkbox(Languages.SystemTab_ShowHuntMarkSlainMessages, ref showHuntSlain))
            {
                configuration.ShowHuntSlain = showHuntSlain;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowHuntMarkSlainMessagesHelpMarker);

            var showCompletionTime = configuration.ShowCompletionTime;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCompletionTimeForUnrestrictedParty, ref showCompletionTime))
            {
                configuration.ShowCompletionTime = showCompletionTime;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowCompletionTimeForUnrestrictedPartyHelpMarker);

            var showVolumeControlMessage = configuration.ShowVolumeControlMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowVolumeControlMessages, ref showVolumeControlMessage))
            {
                configuration.ShowVolumeControlMessage = showVolumeControlMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowVolumeControlMessagesHelpMarker);

            var showGlamoursProjected = configuration.ShowGlamoursProjected;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGlamourPlateChangingMessages, ref showGlamoursProjected))
            {
                configuration.ShowGlamoursProjected = showGlamoursProjected;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowGlamourPlateChangingMessagesHelpMarker);

            var showGearsetEquipped = configuration.ShowGearsetEquipped;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGearsetChangingMessages, ref showGearsetEquipped))
            {
                configuration.ShowGearsetEquipped = showGearsetEquipped;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowGearsetChangingMessagesHelpMarker);

            var showNowLeaderOf = configuration.ShowNowLeaderOf;
            if (ImGui.Checkbox(Languages.SystemTab_ShowNowALeader, ref showNowLeaderOf))
            {
                configuration.ShowNowLeaderOf = showNowLeaderOf;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowNowALeaderHelpMarker);

            var showEverythingElse = configuration.ShowEverythingElse;
            if (ImGui.Checkbox(Languages.SystemTab_ShowEverythingElse, ref showEverythingElse))
            {
                configuration.ShowEverythingElse = showEverythingElse;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowEverythingElseHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_FreeCompanyDropdownHeader))
        {
            var showUserLogins = configuration.ShowUserLogins;
            if (ImGui.Checkbox(Languages.SystemTab_HideLoginMessages, ref showUserLogins))
            {
                configuration.ShowUserLogins = showUserLogins;
                configuration.Save();
            }

            var showUserLogouts = configuration.ShowUserLogouts;
            if (ImGui.Checkbox(Languages.SystemTab_HideLogoutMessages, ref showUserLogouts))
            {
                configuration.ShowUserLogouts = showUserLogouts;
                configuration.Save();
            }

            var showFreeCompanyMessageBook = configuration.ShowFreeCompanyMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_HideFreeCompanyMessageBookMessages,
                    ref showFreeCompanyMessageBook))
            {
                configuration.ShowFreeCompanyMessageBook = showFreeCompanyMessageBook;
                configuration.Save();
            }

            var showExploratoryVoyage = configuration.ShowExploratoryVoyage;
            if (ImGui.Checkbox(Languages.SystemTab_HideAirshipVoyageMessages, ref showExploratoryVoyage))
            {
                configuration.ShowExploratoryVoyage = showExploratoryVoyage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideAirshipVoyageMessagesHelpMarker);

            var showSubaquaticVoyage = configuration.ShowSubaquaticVoyage;
            if (ImGui.Checkbox(Languages.SystemTab_HideSubmarineVoyageMessages, ref showSubaquaticVoyage))
            {
                configuration.ShowSubaquaticVoyage = showSubaquaticVoyage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSubmarineVoyageMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_POTDHoHDropdownHeader))
        {
            var showObtainedPomander = configuration.ShowObtainedPomander;
            if (ImGui.Checkbox(Languages.SystemTab_ShowObtainedPomanderMessages, ref showObtainedPomander))
            {
                configuration.ShowObtainedPomander = showObtainedPomander;
                configuration.Save();
            }

            var showReturnedPomander = configuration.ShowReturnedPomander;
            if (ImGui.Checkbox(Languages.SystemTab_ShowReturnedPomanderMessages, ref showReturnedPomander))
            {
                configuration.ShowReturnedPomander = showReturnedPomander;
                configuration.Save();
            }

            var showCairnGlows = configuration.ShowCairnGlows;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCairnOfPassageGlowsMessages, ref showCairnGlows))
            {
                configuration.ShowCairnGlows = showCairnGlows;
                configuration.Save();
            }

            var showRestoresLifeToFallen = configuration.ShowRestoresLifeToFallen;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCairnOfReturnUsedMessages, ref showRestoresLifeToFallen))
            {
                configuration.ShowRestoresLifeToFallen = showRestoresLifeToFallen;
                configuration.Save();
            }

            var showCairnActivates = configuration.ShowCairnActivates;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCairnOfPassageActivatedMessages, ref showCairnActivates))
            {
                configuration.ShowCairnActivates = showCairnActivates;
                configuration.Save();
            }

            var showTransference = configuration.ShowTransference;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTransferenceMessages, ref showTransference))
            {
                configuration.ShowTransference = showTransference;
                configuration.Save();
            }

            var showAetherpoolIncrease = configuration.ShowAetherpoolIncrease;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetherpoolIncreasesMessages, ref showAetherpoolIncrease))
            {
                configuration.ShowAetherpoolIncrease = showAetherpoolIncrease;
                configuration.Save();
            }

            var showAetherpoolUnchanged = configuration.ShowAetherpoolUnchanged;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetherpoolRemainsUnchangedMessages,
                    ref showAetherpoolUnchanged))
            {
                configuration.ShowAetherpoolUnchanged = showAetherpoolUnchanged;
                configuration.Save();
            }

            var showPomanderOfSafety = configuration.ShowPomanderOfSafety;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPomanderOfSafetyUsedMessages, ref showPomanderOfSafety))
            {
                configuration.ShowPomanderOfSafety = showPomanderOfSafety;
                configuration.Save();
            }

            var showPomanderOfSight = configuration.ShowPomanderOfSight;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPomanderOfSightUsedMessages, ref showPomanderOfSight))
            {
                configuration.ShowPomanderOfSight = showPomanderOfSight;
                configuration.Save();
            }

            var showPomanderOfAffluence = configuration.ShowPomanderOfAffluence;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPomanderOfAffluenceUsedMessages, ref showPomanderOfAffluence))
            {
                configuration.ShowPomanderOfAffluence = showPomanderOfAffluence;
                configuration.Save();
            }

            var showPomanderOfFlight = configuration.ShowPomanderOfFlight;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPomanderOfFlightUsedMessages, ref showPomanderOfFlight))
            {
                configuration.ShowPomanderOfFlight = showPomanderOfFlight;
                configuration.Save();
            }

            var showPomanderOfAlteration = configuration.ShowPomanderOfAlteration;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPomanderOfAlterationUsedMessages,
                    ref showPomanderOfAlteration))
            {
                configuration.ShowPomanderOfAlteration = showPomanderOfAlteration;
                configuration.Save();
            }

            var showPomanderOfWitching = configuration.ShowPomanderOfWitching;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPomanderOfWitchingUsedMessages, ref showPomanderOfWitching))
            {
                configuration.ShowPomanderOfWitching = showPomanderOfWitching;
                configuration.Save();
            }

            var showPomanderOfSerenity = configuration.ShowPomanderOfSerenity;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPomanderOfSerenityUsedMessages, ref showPomanderOfSerenity))
            {
                configuration.ShowPomanderOfSerenity = showPomanderOfSerenity;
                configuration.Save();
            }

            var showFloorNumber = configuration.ShowFloorNumber;
            if (ImGui.Checkbox(Languages.SystemTab_ShowFloorNumberMessages, ref showFloorNumber))
            {
                configuration.ShowFloorNumber = showFloorNumber;
                configuration.Save();
            }

            var showSenseAccursedHoard = configuration.ShowSenseAccursedHoard;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAccursedHoardSensedMessages, ref showSenseAccursedHoard))
            {
                configuration.ShowSenseAccursedHoard = showSenseAccursedHoard;
                configuration.Save();
            }

            var showDoNotSenseAccursedHoard = configuration.ShowDoNotSenseAccursedHoard;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAccursedHoardNotSensedMessages,
                    ref showDoNotSenseAccursedHoard))
            {
                configuration.ShowDoNotSenseAccursedHoard = showDoNotSenseAccursedHoard;
                configuration.Save();
            }

            var showDiscoverAccursedHoard = configuration.ShowDiscoverAccursedHoard;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAccursedHoardDiscoveredMessages,
                    ref showDiscoverAccursedHoard))
            {
                configuration.ShowDiscoverAccursedHoard = showDiscoverAccursedHoard;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_PartyAndInviteDropdownHeader))
        {
            var showInviteSent = configuration.ShowInviteSent;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSentPartyInviteMessages, ref showInviteSent))
            {
                configuration.ShowInviteSent = showInviteSent;
                configuration.Save();
            }

            var showInviteeJoins = configuration.ShowInviteeJoins;
            if (ImGui.Checkbox(Languages.SystemTab_ShowJoiningPartyMessages, ref showInviteeJoins))
            {
                configuration.ShowInviteeJoins = showInviteeJoins;
                configuration.Save();
            }

            var showLeftParty = configuration.ShowLeftParty;
            if (ImGui.Checkbox(Languages.SystemTab_ShowLeftPartyMessages, ref showLeftParty))
            {
                configuration.ShowLeftParty = showLeftParty;
                configuration.Save();
            }

            var showPartyDisband = configuration.ShowPartyDisband;
            if (ImGui.Checkbox(Languages.SystemTab_ShowDisbandAndDissolveMessages, ref showPartyDisband))
            {
                configuration.ShowPartyDisband = showPartyDisband;
                configuration.ShowPartyDissolved = showPartyDisband;
                configuration.Save();
            }

            var showInvitedBy = configuration.ShowInvitedBy;
            if (ImGui.Checkbox(Languages.SystemTab_ShowReceivedPartyInvitationMessages, ref showInvitedBy))
            {
                configuration.ShowInvitedBy = showInvitedBy;
                configuration.Save();
            }

            var showJoinParty = configuration.ShowJoinParty;
            if (ImGui.Checkbox(Languages.SystemTab_ShowJoinedCrossworldPartyMessages, ref showJoinParty))
            {
                configuration.ShowJoinParty = showJoinParty;
                configuration.Save();
            }

            var showPartyInformation = configuration.ShowPartyInformation;
            if (ImGui.Checkbox(Languages.ShowPartyObjectiveAndPartyCommentWhenJoiningAParty, ref showPartyInformation))
            {
                configuration.ShowPartyInformation = showPartyInformation;
                configuration.Save();
            }

            var showOfferedTeleport = configuration.ShowOfferedTeleport;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTeleportOfferFromPartyMessages, ref showOfferedTeleport))
            {
                configuration.ShowOfferedTeleport = showOfferedTeleport;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_TradingDropdownHeader))
        {
            var showTradeSent = configuration.ShowTradeSent;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeRequestSentMessages, ref showTradeSent))
            {
                configuration.ShowTradeSent = showTradeSent;
                configuration.Save();
            }

            var showTradeCanceled = configuration.ShowTradeCanceled;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeCanceledMessages, ref showTradeCanceled))
            {
                configuration.ShowTradeCanceled = showTradeCanceled;
                configuration.Save();
            }

            var showAwaitingTradeConfirmation = configuration.ShowAwaitingTradeConfirmation;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAwaitingTradeConfirmationMessages,
                    ref showAwaitingTradeConfirmation))
            {
                configuration.ShowAwaitingTradeConfirmation = showAwaitingTradeConfirmation;
                configuration.Save();
            }

            var showTradeComplete = configuration.ShowTradeComplete;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeCompleteMessages, ref showTradeComplete))
            {
                configuration.ShowTradeComplete = showTradeComplete;
                configuration.Save();
            }
        }


        ImGui.EndTabItem();
    }
}