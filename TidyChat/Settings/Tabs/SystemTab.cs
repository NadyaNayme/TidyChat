using Dalamud.Interface.Components;
using ImGuiNET;
using TidyChat.Resources.Languages;

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
            var instanceMessage = configuration.HideInstanceMessage;
            if (ImGui.Checkbox(Languages.SystemTab_HideInstanceMessage, ref instanceMessage))
            {
                configuration.HideInstanceMessage = instanceMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideInstanceMessageHelpMarker);

            var hideDebugTeleport = configuration.HideDebugTeleport;
            if (ImGui.Checkbox(Languages.SystemTab_HideTeleportingToMessages, ref hideDebugTeleport))
            {
                configuration.HideDebugTeleport = hideDebugTeleport;
                configuration.Save();
            }

            var sRankHunt = configuration.HideSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_HideSRankSpawnAnnouncement, ref sRankHunt))
            {
                configuration.HideSRankHunt = sRankHunt;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSRankSpawnAnnouncementHelpMarker);

            var ssRankHunt = configuration.HideSSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_HideSSRankMinionSpawnAnnouncement, ref ssRankHunt))
            {
                configuration.HideSSRankHunt = ssRankHunt;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSSRankMinionSpawnAnnouncementHelpMarker);

            var commendations = configuration.HideCommendations;
            if (ImGui.Checkbox(Languages.SystemTab_HideReceivedCommendations, ref commendations))
            {
                configuration.HideCommendations = commendations;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideReceivedCommendationsHelpMarker);

            var completedVenture = configuration.HideCompletedVenture;
            if (ImGui.Checkbox(Languages.SystemTab_HideCompletedVenture, ref completedVenture))
            {
                configuration.HideCompletedVenture = completedVenture;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideCompletedVentureHelpMarker);

            var hideQuestReminder = configuration.HideQuestReminder;
            if (ImGui.Checkbox(Languages.SystemTab_HideSayReminder, ref hideQuestReminder))
            {
                configuration.HideQuestReminder = hideQuestReminder;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSayReminderHelpMarker);

            var hideSpideySenses = configuration.HideSpideySenses;
            if (ImGui.Checkbox(Languages.SystemTab_HideYouSenseSomethingMessages, ref hideSpideySenses))
            {
                configuration.HideSpideySenses = hideSpideySenses;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideYouSenseSomethingMessagesHelpMarker);

            var hideAetherCompass = configuration.HideAetherCompass;
            if (ImGui.Checkbox(Languages.SystemTab_HideAetherCompassMessages, ref hideAetherCompass))
            {
                configuration.HideAetherCompass = hideAetherCompass;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideAetherCompassMessagesHelpMarker);

            var hideCountdownTime = configuration.HideCountdownTime;
            if (ImGui.Checkbox(Languages.SystemTab_HideCountdownMessages, ref hideCountdownTime))
            {
                configuration.HideCountdownTime = hideCountdownTime;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideCountdownMessagesHelpMarker);

            var hideReadyChecks = configuration.HideReadyChecks;
            if (ImGui.Checkbox(Languages.SystemTab_HideReadycheckMessages, ref hideReadyChecks))
            {
                configuration.HideReadyChecks = hideReadyChecks;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideReadycheckMessagesHelpMarker);

            var hideSearchForItemResults = configuration.HideSearchForItemResults;
            if (ImGui.Checkbox(Languages.SystemTab_HideItemSearchResultsMessage, ref hideSearchForItemResults))
            {
                configuration.HideSearchForItemResults = hideSearchForItemResults;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideItemSearchResultsMessageHelpMarker);

            var hideVistaMessages = configuration.HideVistaMessages;
            if (ImGui.Checkbox(Languages.SystemTab_HideVistaMessages, ref hideVistaMessages))
            {
                configuration.HideVistaMessages = hideVistaMessages;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideVistaMessagesHelpMarker);

            var hideTryOnGlamour = configuration.HideTryOnGlamour;
            if (ImGui.Checkbox(Languages.SystemTab_HideTryOnGlamourMessages, ref hideTryOnGlamour))
            {
                configuration.HideTryOnGlamour = hideTryOnGlamour;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideTryOnGlamourMessagesHelpMarker);

            var hidePersonalMessageBook = configuration.HidePersonalMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_HidePersonalMessageBookMessages, ref hidePersonalMessageBook))
            {
                configuration.HidePersonalMessageBook = hidePersonalMessageBook;
                configuration.Save();
            }

            var hideSpiritboundGear = configuration.HideSpiritboundGear;
            if (ImGui.Checkbox(Languages.SystemTab_HideSpiritboundMessages, ref hideSpiritboundGear))
            {
                configuration.HideSpiritboundGear = hideSpiritboundGear;
                configuration.Save();
            }

            var hideEligibleForCoffers = configuration.HideEligibleForCoffers;
            if (ImGui.Checkbox(Languages.SystemTab_HideNumberOfCoffers, ref hideEligibleForCoffers))
            {
                configuration.HideEligibleForCoffers = hideEligibleForCoffers;
                configuration.Save();
            }

            var hideNoviceNetworkFull = configuration.HideNoviceNetworkFull;
            if (ImGui.Checkbox(Languages.SystemTab_HideUnableToJoinFullNoviceNetwork, ref hideNoviceNetworkFull))
            {
                configuration.HideNoviceNetworkFull = hideNoviceNetworkFull;
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
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_FreeCompanyDropdownHeader))
        {
            var hideUserLogins = configuration.HideUserLogins;
            if (ImGui.Checkbox(Languages.SystemTab_HideLoginMessages, ref hideUserLogins))
            {
                configuration.HideUserLogins = hideUserLogins;
                configuration.Save();
            }

            var hideUserLogouts = configuration.HideUserLogouts;
            if (ImGui.Checkbox(Languages.SystemTab_HideLogoutMessages, ref hideUserLogouts))
            {
                configuration.HideUserLogouts = hideUserLogouts;
                configuration.Save();
            }

            var hideFreeCompanyMessageBook = configuration.HideFreeCompanyMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_HideFreeCompanyMessageBookMessages,
                    ref hideFreeCompanyMessageBook))
            {
                configuration.HideFreeCompanyMessageBook = hideFreeCompanyMessageBook;
                configuration.Save();
            }

            var hideExploratoryVoyage = configuration.HideExploratoryVoyage;
            if (ImGui.Checkbox(Languages.SystemTab_HideAirshipVoyageMessages, ref hideExploratoryVoyage))
            {
                configuration.HideExploratoryVoyage = hideExploratoryVoyage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideAirshipVoyageMessagesHelpMarker);

            var hideSubaquaticVoyage = configuration.HideSubaquaticVoyage;
            if (ImGui.Checkbox(Languages.SystemTab_HideSubmarineVoyageMessages, ref hideSubaquaticVoyage))
            {
                configuration.HideSubaquaticVoyage = hideSubaquaticVoyage;
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