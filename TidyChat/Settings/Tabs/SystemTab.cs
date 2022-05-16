using Dalamud.Interface.Components;
using ImGuiNET;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings.Tabs;

internal static class SystemTab
{
    public static void Draw(Configuration configuration)
    {
        var enableInverseMode = configuration.EnableInverseMode;
        if (ImGui.Checkbox(localization.SystemTab_ExperimentalFeatureInverseMode, ref enableInverseMode))
        {
            configuration.EnableInverseMode = enableInverseMode;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.SystemTab_ExperimentalFeatureInverseModeHelpMarker);

        if (configuration.EnableInverseMode)
            ImGui.TextUnformatted(localization.SystemTab_ExperimentalFeatureInverseModeWarningText);
        if (ImGui.CollapsingHeader(localization.SystemTab_HideShownDefaultDropdownHeader))
        {
            var instanceMessage = configuration.HideInstanceMessage;
            if (ImGui.Checkbox(localization.SystemTab_HideInstanceMessage, ref instanceMessage))
            {
                configuration.HideInstanceMessage = instanceMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideInstanceMessageHelpMarker);

            var sRankHunt = configuration.HideSRankHunt;
            if (ImGui.Checkbox(localization.SystemTab_HideSRankSpawnAnnouncement, ref sRankHunt))
            {
                configuration.HideSRankHunt = sRankHunt;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideSRankSpawnAnnouncementHelpMarker);

            var ssRankHunt = configuration.HideSSRankHunt;
            if (ImGui.Checkbox(localization.SystemTab_HideSSRankMinionSpawnAnnouncement, ref ssRankHunt))
            {
                configuration.HideSSRankHunt = ssRankHunt;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideSSRankMinionSpawnAnnouncementHelpMarker);

            var commendations = configuration.HideCommendations;
            if (ImGui.Checkbox(localization.SystemTab_HideReceivedCommendations, ref commendations))
            {
                configuration.HideCommendations = commendations;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideReceivedCommendationsHelpMarker);

            var completedVenture = configuration.HideCompletedVenture;
            if (ImGui.Checkbox(localization.SystemTab_HideCompletedVenture, ref completedVenture))
            {
                configuration.HideCompletedVenture = completedVenture;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideCompletedVentureHelpMarker);

            var hideQuestReminder = configuration.HideQuestReminder;
            if (ImGui.Checkbox(localization.SystemTab_HideSayReminder, ref hideQuestReminder))
            {
                configuration.HideQuestReminder = hideQuestReminder;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideSayReminderHelpMarker);

            var hideSpideySenses = configuration.HideSpideySenses;
            if (ImGui.Checkbox(localization.SystemTab_HideYouSenseSomethingMessages, ref hideSpideySenses))
            {
                configuration.HideSpideySenses = hideSpideySenses;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideYouSenseSomethingMessagesHelpMarker);

            var hideAetherCompass = configuration.HideAetherCompass;
            if (ImGui.Checkbox(localization.SystemTab_HideAetherCompassMessages, ref hideAetherCompass))
            {
                configuration.HideAetherCompass = hideAetherCompass;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideAetherCompassMessagesHelpMarker);

            var hideCountdownTime = configuration.HideCountdownTime;
            if (ImGui.Checkbox(localization.SystemTab_HideCountdownMessages, ref hideCountdownTime))
            {
                configuration.HideCountdownTime = hideCountdownTime;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideCountdownMessagesHelpMarker);

            var hideReadyChecks = configuration.HideReadyChecks;
            if (ImGui.Checkbox(localization.SystemTab_HideReadycheckMessages, ref hideReadyChecks))
            {
                configuration.HideReadyChecks = hideReadyChecks;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideReadycheckMessagesHelpMarker);

            var hideSearchForItemResults = configuration.HideSearchForItemResults;
            if (ImGui.Checkbox(localization.SystemTab_HideItemSearchResultsMessage, ref hideSearchForItemResults))
            {
                configuration.HideSearchForItemResults = hideSearchForItemResults;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideItemSearchResultsMessageHelpMarker);

            var hideExploratoryVoyage = configuration.HideExploratoryVoyage;
            if (ImGui.Checkbox(localization.SystemTab_HideAirshipVoyageMessages, ref hideExploratoryVoyage))
            {
                configuration.HideExploratoryVoyage = hideExploratoryVoyage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideAirshipVoyageMessagesHelpMarker);

            var hideSubaquaticVoyage = configuration.HideSubaquaticVoyage;
            if (ImGui.Checkbox(localization.SystemTab_HideSubmarineVoyageMessages, ref hideSubaquaticVoyage))
            {
                configuration.HideSubaquaticVoyage = hideSubaquaticVoyage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideSubmarineVoyageMessagesHelpMarker);

            var hideVistaMessages = configuration.HideVistaMessages;
            if (ImGui.Checkbox(localization.SystemTab_HideVistaMessages, ref hideVistaMessages))
            {
                configuration.HideVistaMessages = hideVistaMessages;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideVistaMessagesHelpMarker);

            var hideTryOnGlamour = configuration.HideTryOnGlamour;
            if (ImGui.Checkbox(localization.SystemTab_HideTryOnGlamourMessages, ref hideTryOnGlamour))
            {
                configuration.HideTryOnGlamour = hideTryOnGlamour;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_HideTryOnGlamourMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(localization.SystemTab_ShowHiddenMessagesDropdownHeader))
        {
            var showOnlineStatus = configuration.ShowOnlineStatus;
            if (ImGui.Checkbox(localization.SystemTab_ShowOnlineStatusMessages, ref showOnlineStatus))
            {
                configuration.ShowOnlineStatus = showOnlineStatus;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_ShowOnlineStatusMessagesHelpMarker);

            var showAttachToMail = configuration.ShowAttachToMail;
            if (ImGui.Checkbox(localization.SystemTab_ShowMailAttachmentMessages, ref showAttachToMail))
            {
                configuration.ShowAttachToMail = showAttachToMail;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_ShowMailAttachmentMessagesHelpMarker);

            var showRelicBookStep = configuration.ShowRelicBookStep;
            if (ImGui.Checkbox(localization.SystemTab_ShowARRRelicProgressMessages, ref showRelicBookStep))
            {
                configuration.ShowRelicBookStep = showRelicBookStep;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_ShowARRRelicProgressMessagesHelpMarker);

            var showRelicBookComplete = configuration.ShowRelicBookComplete;
            if (ImGui.Checkbox(localization.SystemTab_ShowARRRelicBookStepMessages, ref showRelicBookComplete))
            {
                configuration.ShowRelicBookComplete = showRelicBookComplete;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_ShowARRRelicBookStepMessagesHelpMarker);

            var showHuntSlain = configuration.ShowHuntSlain;
            if (ImGui.Checkbox(localization.SystemTab_ShowHuntMarkSlainMessages, ref showHuntSlain))
            {
                configuration.ShowHuntSlain = showHuntSlain;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_ShowHuntMarkSlainMessagesHelpMarker);

            var showCompletionTime = configuration.ShowCompletionTime;
            if (ImGui.Checkbox(localization.SystemTab_ShowCompletionTimeForUnrestrictedParty, ref showCompletionTime))
            {
                configuration.ShowCompletionTime = showCompletionTime;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_ShowCompletionTimeForUnrestrictedPartyHelpMarker);

            var showVolumeControlMessage = configuration.ShowVolumeControlMessage;
            if (ImGui.Checkbox(localization.SystemTab_ShowVolumeControlMessages, ref showVolumeControlMessage))
            {
                configuration.ShowVolumeControlMessage = showVolumeControlMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_ShowVolumeControlMessagesHelpMarker);

            var showGlamoursProjected = configuration.ShowGlamoursProjected;
            if (ImGui.Checkbox(localization.SystemTab_ShowGlamourPlateChangingMessages, ref showGlamoursProjected))
            {
                configuration.ShowGlamoursProjected = showGlamoursProjected;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_ShowGlamourPlateChangingMessagesHelpMarker);

            var showGearsetEquipped = configuration.ShowGearsetEquipped;
            if (ImGui.Checkbox(localization.SystemTab_ShowGearsetChangingMessages, ref showGearsetEquipped))
            {
                configuration.ShowGearsetEquipped = showGearsetEquipped;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(localization.SystemTab_ShowGearsetChangingMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(localization.SystemTab_POTDHoHDropdownHeader))
        {
            var showObtainedPomander = configuration.ShowObtainedPomander;
            if (ImGui.Checkbox(localization.SystemTab_ShowObtainedPomanderMessages, ref showObtainedPomander))
            {
                configuration.ShowObtainedPomander = showObtainedPomander;
                configuration.Save();
            }

            var showReturnedPomander = configuration.ShowReturnedPomander;
            if (ImGui.Checkbox(localization.SystemTab_ShowReturnedPomanderMessages, ref showReturnedPomander))
            {
                configuration.ShowReturnedPomander = showReturnedPomander;
                configuration.Save();
            }

            var showCairnGlows = configuration.ShowCairnGlows;
            if (ImGui.Checkbox(localization.SystemTab_ShowCairnOfPassageGlowsMessages, ref showCairnGlows))
            {
                configuration.ShowCairnGlows = showCairnGlows;
                configuration.Save();
            }

            var showRestoresLifeToFallen = configuration.ShowRestoresLifeToFallen;
            if (ImGui.Checkbox(localization.SystemTab_ShowCairnOfReturnUsedMessages, ref showRestoresLifeToFallen))
            {
                configuration.ShowRestoresLifeToFallen = showRestoresLifeToFallen;
                configuration.Save();
            }

            var showCairnActivates = configuration.ShowCairnActivates;
            if (ImGui.Checkbox(localization.SystemTab_ShowCairnOfPassageActivatedMessages, ref showCairnActivates))
            {
                configuration.ShowCairnActivates = showCairnActivates;
                configuration.Save();
            }

            var showTransference = configuration.ShowTransference;
            if (ImGui.Checkbox(localization.SystemTab_ShowTransferenceMessages, ref showTransference))
            {
                configuration.ShowTransference = showTransference;
                configuration.Save();
            }

            var showAetherpoolIncrease = configuration.ShowAetherpoolIncrease;
            if (ImGui.Checkbox(localization.SystemTab_ShowAetherpoolIncreasesMessages, ref showAetherpoolIncrease))
            {
                configuration.ShowAetherpoolIncrease = showAetherpoolIncrease;
                configuration.Save();
            }

            var showAetherpoolUnchanged = configuration.ShowAetherpoolUnchanged;
            if (ImGui.Checkbox(localization.SystemTab_ShowAetherpoolRemainsUnchangedMessages,
                    ref showAetherpoolUnchanged))
            {
                configuration.ShowAetherpoolUnchanged = showAetherpoolUnchanged;
                configuration.Save();
            }

            var showPomanderOfSafety = configuration.ShowPomanderOfSafety;
            if (ImGui.Checkbox(localization.SystemTab_ShowPomanderOfSafetyUsedMessages, ref showPomanderOfSafety))
            {
                configuration.ShowPomanderOfSafety = showPomanderOfSafety;
                configuration.Save();
            }

            var showPomanderOfSight = configuration.ShowPomanderOfSight;
            if (ImGui.Checkbox(localization.SystemTab_ShowPomanderOfSightUsedMessages, ref showPomanderOfSight))
            {
                configuration.ShowPomanderOfSight = showPomanderOfSight;
                configuration.Save();
            }

            var showPomanderOfAffluence = configuration.ShowPomanderOfAffluence;
            if (ImGui.Checkbox(localization.SystemTab_ShowPomanderOfAffluenceUsedMessages, ref showPomanderOfAffluence))
            {
                configuration.ShowPomanderOfAffluence = showPomanderOfAffluence;
                configuration.Save();
            }

            var showPomanderOfFlight = configuration.ShowPomanderOfFlight;
            if (ImGui.Checkbox(localization.SystemTab_ShowPomanderOfFlightUsedMessages, ref showPomanderOfFlight))
            {
                configuration.ShowPomanderOfFlight = showPomanderOfFlight;
                configuration.Save();
            }

            var showPomanderOfAlteration = configuration.ShowPomanderOfAlteration;
            if (ImGui.Checkbox(localization.SystemTab_ShowPomanderOfAlterationUsedMessages,
                    ref showPomanderOfAlteration))
            {
                configuration.ShowPomanderOfAlteration = showPomanderOfAlteration;
                configuration.Save();
            }

            var showPomanderOfWitching = configuration.ShowPomanderOfWitching;
            if (ImGui.Checkbox(localization.SystemTab_ShowPomanderOfWitchingUsedMessages, ref showPomanderOfWitching))
            {
                configuration.ShowPomanderOfWitching = showPomanderOfWitching;
                configuration.Save();
            }

            var showPomanderOfSerenity = configuration.ShowPomanderOfSerenity;
            if (ImGui.Checkbox(localization.SystemTab_ShowPomanderOfSerenityUsedMessages, ref showPomanderOfSerenity))
            {
                configuration.ShowPomanderOfSerenity = showPomanderOfSerenity;
                configuration.Save();
            }

            var showFloorNumber = configuration.ShowFloorNumber;
            if (ImGui.Checkbox(localization.SystemTab_ShowFloorNumberMessages, ref showFloorNumber))
            {
                configuration.ShowFloorNumber = showFloorNumber;
                configuration.Save();
            }

            var showSenseAccursedHoard = configuration.ShowSenseAccursedHoard;
            if (ImGui.Checkbox(localization.SystemTab_ShowAccursedHoardSensedMessages, ref showSenseAccursedHoard))
            {
                configuration.ShowSenseAccursedHoard = showSenseAccursedHoard;
                configuration.Save();
            }

            var showDoNotSenseAccursedHoard = configuration.ShowDoNotSenseAccursedHoard;
            if (ImGui.Checkbox(localization.SystemTab_ShowAccursedHoardNotSensedMessages,
                    ref showDoNotSenseAccursedHoard))
            {
                configuration.ShowDoNotSenseAccursedHoard = showDoNotSenseAccursedHoard;
                configuration.Save();
            }

            var showDiscoverAccursedHoard = configuration.ShowDiscoverAccursedHoard;
            if (ImGui.Checkbox(localization.SystemTab_ShowAccursedHoardDiscoveredMessages,
                    ref showDiscoverAccursedHoard))
            {
                configuration.ShowDiscoverAccursedHoard = showDiscoverAccursedHoard;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(localization.SystemTab_PartyAndInviteDropdownHeader))
        {
            var showInviteSent = configuration.ShowInviteSent;
            if (ImGui.Checkbox(localization.SystemTab_ShowSentPartyInviteMessages, ref showInviteSent))
            {
                configuration.ShowInviteSent = showInviteSent;
                configuration.Save();
            }

            var showInviteeJoins = configuration.ShowInviteeJoins;
            if (ImGui.Checkbox(localization.SystemTab_ShowJoiningPartyMessages, ref showInviteeJoins))
            {
                configuration.ShowInviteeJoins = showInviteeJoins;
                configuration.Save();
            }

            var showLeftParty = configuration.ShowLeftParty;
            if (ImGui.Checkbox(localization.SystemTab_ShowLeftPartyMessages, ref showLeftParty))
            {
                configuration.ShowLeftParty = showLeftParty;
                configuration.Save();
            }

            var showPartyDisband = configuration.ShowPartyDisband;
            if (ImGui.Checkbox(localization.SystemTab_ShowDisbandAndDissolveMessages, ref showPartyDisband))
            {
                configuration.ShowPartyDisband = showPartyDisband;
                configuration.ShowPartyDissolved = showPartyDisband;
                configuration.Save();
            }

            var showInvitedBy = configuration.ShowInvitedBy;
            if (ImGui.Checkbox(localization.SystemTab_ShowReceivedPartyInvitationMessages, ref showInvitedBy))
            {
                configuration.ShowInvitedBy = showInvitedBy;
                configuration.Save();
            }

            var showJoinParty = configuration.ShowJoinParty;
            if (ImGui.Checkbox(localization.SystemTab_ShowJoinedCrossworldPartyMessages, ref showJoinParty))
            {
                configuration.ShowJoinParty = showJoinParty;
                configuration.Save();
            }

            var showOfferedTeleport = configuration.ShowOfferedTeleport;
            if (ImGui.Checkbox(localization.SystemTab_ShowTeleportOfferFromPartyMessages, ref showOfferedTeleport))
            {
                configuration.ShowOfferedTeleport = showOfferedTeleport;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(localization.SystemTab_TradingDropdownHeader))
        {
            var showTradeSent = configuration.ShowTradeSent;
            if (ImGui.Checkbox(localization.SystemTab_ShowTradeRequestSentMessages, ref showTradeSent))
            {
                configuration.ShowTradeSent = showTradeSent;
                configuration.Save();
            }

            var showTradeCanceled = configuration.ShowTradeCanceled;
            if (ImGui.Checkbox(localization.SystemTab_ShowTradeCanceledMessages, ref showTradeCanceled))
            {
                configuration.ShowTradeCanceled = showTradeCanceled;
                configuration.Save();
            }

            var showAwaitingTradeConfirmation = configuration.ShowAwaitingTradeConfirmation;
            if (ImGui.Checkbox(localization.SystemTab_ShowAwaitingTradeConfirmationMessages,
                    ref showAwaitingTradeConfirmation))
            {
                configuration.ShowAwaitingTradeConfirmation = showAwaitingTradeConfirmation;
                configuration.Save();
            }

            var showTradeComplete = configuration.ShowTradeComplete;
            if (ImGui.Checkbox(localization.SystemTab_ShowTradeCompleteMessages, ref showTradeComplete))
            {
                configuration.ShowTradeComplete = showTradeComplete;
                configuration.Save();
            }
        }


        ImGui.EndTabItem();
    }
}