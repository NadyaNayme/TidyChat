using System;
using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class SystemTab
{
    public static void Draw(Configuration configuration)
    {
        bool enableInverseMode = configuration.EnableInverseMode;
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
            bool instanceMessage = configuration.ShowInstanceMessage;
            if (ImGui.Checkbox(Languages.SystemTab_HideInstanceMessage, ref instanceMessage))
            {
                configuration.ShowInstanceMessage = instanceMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideInstanceMessageHelpMarker);

            bool sRankHunt = configuration.ShowSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_HideSRankSpawnAnnouncement, ref sRankHunt))
            {
                configuration.ShowSRankHunt = sRankHunt;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSRankSpawnAnnouncementHelpMarker);

            bool ssRankHunt = configuration.ShowSSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_HideSSRankMinionSpawnAnnouncement, ref ssRankHunt))
            {
                configuration.ShowSSRankHunt = ssRankHunt;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSSRankMinionSpawnAnnouncementHelpMarker);

            bool commendations = configuration.ShowCommendations;
            if (ImGui.Checkbox(Languages.SystemTab_HideReceivedCommendations, ref commendations))
            {
                configuration.ShowCommendations = commendations;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideReceivedCommendationsHelpMarker);

            bool completedVenture = configuration.ShowCompletedVenture;
            if (ImGui.Checkbox(Languages.SystemTab_HideCompletedVenture, ref completedVenture))
            {
                configuration.ShowCompletedVenture = completedVenture;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideCompletedVentureHelpMarker);

            bool showQuestReminder = configuration.ShowQuestReminder;
            if (ImGui.Checkbox(Languages.SystemTab_HideSayReminder, ref showQuestReminder))
            {
                configuration.ShowQuestReminder = showQuestReminder;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSayReminderHelpMarker);

            bool showSpideySenses = configuration.ShowSpideySenses;
            if (ImGui.Checkbox(Languages.SystemTab_HideYouSenseSomethingMessages, ref showSpideySenses))
            {
                configuration.ShowSpideySenses = showSpideySenses;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideYouSenseSomethingMessagesHelpMarker);

            bool showAetherCompass = configuration.ShowAetherCompass;
            if (ImGui.Checkbox(Languages.SystemTab_HideAetherCompassMessages, ref showAetherCompass))
            {
                configuration.ShowAetherCompass = showAetherCompass;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideAetherCompassMessagesHelpMarker);

            bool showCountdownTime = configuration.ShowCountdownTime;
            if (ImGui.Checkbox(Languages.SystemTab_HideCountdownMessages, ref showCountdownTime))
            {
                configuration.ShowCountdownTime = showCountdownTime;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideCountdownMessagesHelpMarker);

            bool showReadyChecks = configuration.ShowReadyChecks;
            if (ImGui.Checkbox(Languages.SystemTab_HideReadycheckMessages, ref showReadyChecks))
            {
                configuration.ShowReadyChecks = showReadyChecks;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideReadycheckMessagesHelpMarker);

            bool showSearchForItemResults = configuration.ShowSearchForItemResults;
            if (ImGui.Checkbox(Languages.SystemTab_HideItemSearchResultsMessage, ref showSearchForItemResults))
            {
                configuration.ShowSearchForItemResults = showSearchForItemResults;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideItemSearchResultsMessageHelpMarker);

            bool showVistaMessages = configuration.ShowVistaMessages;
            if (ImGui.Checkbox(Languages.SystemTab_HideVistaMessages, ref showVistaMessages))
            {
                configuration.ShowVistaMessages = showVistaMessages;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideVistaMessagesHelpMarker);

            bool showTryOnGlamour = configuration.ShowTryOnGlamour;
            if (ImGui.Checkbox(Languages.SystemTab_HideTryOnGlamourMessages, ref showTryOnGlamour))
            {
                configuration.ShowTryOnGlamour = showTryOnGlamour;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideTryOnGlamourMessagesHelpMarker);

            bool showPersonalMessageBook = configuration.ShowPersonalMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_HidePersonalMessageBookMessages, ref showPersonalMessageBook))
            {
                configuration.ShowPersonalMessageBook = showPersonalMessageBook;
                configuration.Save();
            }

            bool showSpiritboundGear = configuration.ShowSpiritboundGear;
            if (ImGui.Checkbox(Languages.SystemTab_HideSpiritboundMessages, ref showSpiritboundGear))
            {
                configuration.ShowSpiritboundGear = showSpiritboundGear;
                configuration.Save();
            }

            bool showEligibleForCoffers = configuration.ShowEligibleForCoffers;
            if (ImGui.Checkbox(Languages.SystemTab_HideNumberOfCoffers, ref showEligibleForCoffers))
            {
                configuration.ShowEligibleForCoffers = showEligibleForCoffers;
                configuration.Save();
            }

            bool showAetheryteTicket = configuration.ShowAetheryteTicket;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetheryteTicketMessage, ref showAetheryteTicket))
            {
                configuration.ShowAetheryteTicket = showAetheryteTicket;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowAetheryteTicketMessageHelpMarker);

            // TODO(#122): hardcoded English labels — move to Languages resources once finalized.
            string[] serverAnnouncementModes =
            [
                "Show all",
                "Hide all",
                "Condensed (keep \"Welcome to <world>\")",
                "Login only (hide on world-hop)",
                "Login full, condensed on world-hop",
                "Hide phishing warning only"
            ];
            int serverAnnouncementMode =
                Math.Clamp((int)configuration.ServerAnnouncementMode, 0, serverAnnouncementModes.Length - 1);
            ImGui.TextUnformatted("Server announcements (login / world-travel)");
            ImGui.SetNextItemWidth(320f);
            if (ImGui.BeginCombo("##serverAnnouncementMode", serverAnnouncementModes[serverAnnouncementMode]))
            {
                for (int i = 0; i < serverAnnouncementModes.Length; i++)
                {
                    if (ImGui.Selectable(serverAnnouncementModes[i], serverAnnouncementMode == i))
                    {
                        configuration.ServerAnnouncementMode = (ServerAnnouncementMode)i;
                        configuration.Save();
                    }
                }

                ImGui.EndCombo();
            }

            ImGuiComponents.HelpMarker(
                "How to handle the server message block shown on login / world travel " +
                "(welcome headers, in-game event promos, congestion notices, phishing warning).\n\n" +
                "Show all - unchanged.\n" +
                "Hide all - suppress the whole block.\n" +
                "Condensed - keep only the \"Welcome to <world>!\" line.\n" +
                "Login only - full block on login, nothing on world-hops.\n" +
                "Login full, condensed on world-hop - full block on login, only the " +
                "\"Welcome to <world>!\" line on world-hops.\n" +
                "Hide phishing warning only - keeps greeting + event text, removes the " +
                "phishing/congestion warning and its URL.\n\n" +
                "Fully supported on English clients; on JP/DE/FR only the sqex.to link lines are affected.");
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_ShowHiddenMessagesDropdownHeader))
        {
            bool showOnlineStatus = configuration.ShowOnlineStatus;
            if (ImGui.Checkbox(Languages.SystemTab_ShowOnlineStatusMessages, ref showOnlineStatus))
            {
                configuration.ShowOnlineStatus = showOnlineStatus;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowOnlineStatusMessagesHelpMarker);

            bool showAttachToMail = configuration.ShowAttachToMail;
            if (ImGui.Checkbox(Languages.SystemTab_ShowMailAttachmentMessages, ref showAttachToMail))
            {
                configuration.ShowAttachToMail = showAttachToMail;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowMailAttachmentMessagesHelpMarker);

            bool showRelicBookStep = configuration.ShowRelicBookStep;
            if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicProgressMessages, ref showRelicBookStep))
            {
                configuration.ShowRelicBookStep = showRelicBookStep;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowARRRelicProgressMessagesHelpMarker);

            bool showRelicBookComplete = configuration.ShowRelicBookComplete;
            if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicBookStepMessages, ref showRelicBookComplete))
            {
                configuration.ShowRelicBookComplete = showRelicBookComplete;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowARRRelicBookStepMessagesHelpMarker);

            bool showHuntSlain = configuration.ShowHuntSlain;
            if (ImGui.Checkbox(Languages.SystemTab_ShowHuntMarkSlainMessages, ref showHuntSlain))
            {
                configuration.ShowHuntSlain = showHuntSlain;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowHuntMarkSlainMessagesHelpMarker);

            bool showCompletionTime = configuration.ShowCompletionTime;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCompletionTimeForUnrestrictedParty, ref showCompletionTime))
            {
                configuration.ShowCompletionTime = showCompletionTime;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowCompletionTimeForUnrestrictedPartyHelpMarker);

            bool showVolumeControlMessage = configuration.ShowVolumeControlMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowVolumeControlMessages, ref showVolumeControlMessage))
            {
                configuration.ShowVolumeControlMessage = showVolumeControlMessage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowVolumeControlMessagesHelpMarker);

            bool showGearsetEquipped = configuration.ShowGearsetEquipped;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGearsetChangingMessages, ref showGearsetEquipped))
            {
                configuration.ShowGearsetEquipped = showGearsetEquipped;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowGearsetChangingMessagesHelpMarker);

            bool showNowLeaderOf = configuration.ShowNowLeaderOf;
            if (ImGui.Checkbox(Languages.SystemTab_ShowNowALeader, ref showNowLeaderOf))
            {
                configuration.ShowNowLeaderOf = showNowLeaderOf;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowNowALeaderHelpMarker);

            bool showSealedOff = configuration.ShowSealedOff;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSealedOffMessages, ref showSealedOff))
            {
                configuration.ShowSealedOff = showSealedOff;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowSealedOffMessagesHelpMarker);

            bool showEverythingElse = configuration.ShowEverythingElse;
            if (ImGui.Checkbox(Languages.SystemTab_ShowEverythingElse, ref showEverythingElse))
            {
                configuration.ShowEverythingElse = showEverythingElse;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowEverythingElseHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_FreeCompanyDropdownHeader))
        {
            bool showUserLogins = configuration.ShowUserLogins;
            if (ImGui.Checkbox(Languages.SystemTab_HideLoginMessages, ref showUserLogins))
            {
                configuration.ShowUserLogins = showUserLogins;
                configuration.Save();
            }

            bool showUserLogouts = configuration.ShowUserLogouts;
            if (ImGui.Checkbox(Languages.SystemTab_HideLogoutMessages, ref showUserLogouts))
            {
                configuration.ShowUserLogouts = showUserLogouts;
                configuration.Save();
            }

            bool showFreeCompanyMessageBook = configuration.ShowFreeCompanyMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_HideFreeCompanyMessageBookMessages,
                    ref showFreeCompanyMessageBook))
            {
                configuration.ShowFreeCompanyMessageBook = showFreeCompanyMessageBook;
                configuration.Save();
            }

            bool showExploratoryVoyage = configuration.ShowExploratoryVoyage;
            if (ImGui.Checkbox(Languages.SystemTab_HideAirshipVoyageMessages, ref showExploratoryVoyage))
            {
                configuration.ShowExploratoryVoyage = showExploratoryVoyage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideAirshipVoyageMessagesHelpMarker);

            bool showSubaquaticVoyage = configuration.ShowSubaquaticVoyage;
            if (ImGui.Checkbox(Languages.SystemTab_HideSubmarineVoyageMessages, ref showSubaquaticVoyage))
            {
                configuration.ShowSubaquaticVoyage = showSubaquaticVoyage;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSubmarineVoyageMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_POTDHoHDropdownHeader))
        {
            bool showCairnGlows = configuration.ShowCairnGlows;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCairnOfPassageGlowsMessages, ref showCairnGlows))
            {
                configuration.ShowCairnGlows = showCairnGlows;
                configuration.Save();
            }

            bool showRestoresLifeToFallen = configuration.ShowRestoresLifeToFallen;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCairnOfReturnUsedMessages, ref showRestoresLifeToFallen))
            {
                configuration.ShowRestoresLifeToFallen = showRestoresLifeToFallen;
                configuration.Save();
            }

            bool showCairnActivates = configuration.ShowCairnActivates;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCairnOfPassageActivatedMessages, ref showCairnActivates))
            {
                configuration.ShowCairnActivates = showCairnActivates;
                configuration.Save();
            }

            bool showTransference = configuration.ShowTransference;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTransferenceMessages, ref showTransference))
            {
                configuration.ShowTransference = showTransference;
                configuration.Save();
            }

            bool showAetherpoolIncrease = configuration.ShowAetherpoolIncrease;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetherpoolIncreasesMessages, ref showAetherpoolIncrease))
            {
                configuration.ShowAetherpoolIncrease = showAetherpoolIncrease;
                configuration.Save();
            }

            bool showAetherpoolUnchanged = configuration.ShowAetherpoolUnchanged;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetherpoolRemainsUnchangedMessages,
                    ref showAetherpoolUnchanged))
            {
                configuration.ShowAetherpoolUnchanged = showAetherpoolUnchanged;
                configuration.Save();
            }

            bool showObtainedPomander = configuration.ShowObtainedPomander;
            if (ImGui.Checkbox(Languages.SystemTab_ShowObtainedPomanderMessages, ref showObtainedPomander))
            {
                configuration.ShowObtainedPomander = showObtainedPomander;
                configuration.Save();
            }

            bool showPomanderEffects = configuration.ShowPomanderEffects;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPomanderEffectsMessages, ref showPomanderEffects))
            {
                configuration.ShowPomanderEffects = showPomanderEffects;
                configuration.Save();
            }
            bool showFloorNumber = configuration.ShowFloorNumber;
            if (ImGui.Checkbox(Languages.SystemTab_ShowFloorNumberMessages, ref showFloorNumber))
            {
                configuration.ShowFloorNumber = showFloorNumber;
                configuration.Save();
            }

            bool showSenseAccursedHoard = configuration.ShowSenseAccursedHoard;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAccursedHoardSensedMessages, ref showSenseAccursedHoard))
            {
                configuration.ShowSenseAccursedHoard = showSenseAccursedHoard;
                configuration.Save();
            }

            bool showDoNotSenseAccursedHoard = configuration.ShowDoNotSenseAccursedHoard;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAccursedHoardNotSensedMessages,
                    ref showDoNotSenseAccursedHoard))
            {
                configuration.ShowDoNotSenseAccursedHoard = showDoNotSenseAccursedHoard;
                configuration.Save();
            }

            bool showDiscoverAccursedHoard = configuration.ShowDiscoverAccursedHoard;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAccursedHoardDiscoveredMessages,
                    ref showDiscoverAccursedHoard))
            {
                configuration.ShowDiscoverAccursedHoard = showDiscoverAccursedHoard;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_PartyAndInviteDropdownHeader))
        {
            bool showInviteSent = configuration.ShowInviteSent;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSentPartyInviteMessages, ref showInviteSent))
            {
                configuration.ShowInviteSent = showInviteSent;
                configuration.Save();
            }

            bool showInviteeJoins = configuration.ShowInviteeJoins;
            if (ImGui.Checkbox(Languages.SystemTab_ShowJoiningPartyMessages, ref showInviteeJoins))
            {
                configuration.ShowInviteeJoins = showInviteeJoins;
                configuration.Save();
            }

            bool showLeftParty = configuration.ShowLeftParty;
            if (ImGui.Checkbox(Languages.SystemTab_ShowLeftPartyMessages, ref showLeftParty))
            {
                configuration.ShowLeftParty = showLeftParty;
                configuration.Save();
            }

            bool showPartyDisband = configuration.ShowPartyDisband;
            if (ImGui.Checkbox(Languages.SystemTab_ShowDisbandAndDissolveMessages, ref showPartyDisband))
            {
                configuration.ShowPartyDisband = showPartyDisband;
                configuration.ShowPartyDissolved = showPartyDisband;
                configuration.Save();
            }

            bool showInvitedBy = configuration.ShowInvitedBy;
            if (ImGui.Checkbox(Languages.SystemTab_ShowReceivedPartyInvitationMessages, ref showInvitedBy))
            {
                configuration.ShowInvitedBy = showInvitedBy;
                configuration.Save();
            }

            bool showJoinParty = configuration.ShowJoinParty;
            if (ImGui.Checkbox(Languages.SystemTab_ShowJoinedCrossworldPartyMessages, ref showJoinParty))
            {
                configuration.ShowJoinParty = showJoinParty;
                configuration.Save();
            }

            bool showPartyInformation = configuration.ShowPartyInformation;
            if (ImGui.Checkbox(Languages.ShowPartyObjectiveAndPartyCommentWhenJoiningAParty, ref showPartyInformation))
            {
                configuration.ShowPartyInformation = showPartyInformation;
                configuration.Save();
            }

            bool showOfferedTeleport = configuration.ShowOfferedTeleport;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTeleportOfferFromPartyMessages, ref showOfferedTeleport))
            {
                configuration.ShowOfferedTeleport = showOfferedTeleport;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_TradingDropdownHeader))
        {
            bool showTradeSent = configuration.ShowTradeSent;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeRequestSentMessages, ref showTradeSent))
            {
                configuration.ShowTradeSent = showTradeSent;
                configuration.Save();
            }

            bool showTradeCanceled = configuration.ShowTradeCanceled;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeCanceledMessages, ref showTradeCanceled))
            {
                configuration.ShowTradeCanceled = showTradeCanceled;
                configuration.Save();
            }

            bool showAwaitingTradeConfirmation = configuration.ShowAwaitingTradeConfirmation;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAwaitingTradeConfirmationMessages,
                    ref showAwaitingTradeConfirmation))
            {
                configuration.ShowAwaitingTradeConfirmation = showAwaitingTradeConfirmation;
                configuration.Save();
            }

            bool showTradeComplete = configuration.ShowTradeComplete;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeCompleteMessages, ref showTradeComplete))
            {
                configuration.ShowTradeComplete = showTradeComplete;
                configuration.Save();
            }
        }


        if (ImGui.CollapsingHeader(Languages.SystemTab_OrchestrionDropdownHeader))
        {
            bool hideOrchestrionPlaying = configuration.HideOrchestrionPlaying;
            if (ImGui.Checkbox(Languages.SystemTab_HideOrchestrionPlaying, ref hideOrchestrionPlaying))
            {
                configuration.HideOrchestrionPlaying = hideOrchestrionPlaying;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideOrchestrionPlayingHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_ErrorMessagesDropdownHeader))
        {
            bool hideFateLevelSync = configuration.HideFateLevelSync;
            if (ImGui.Checkbox(Languages.SystemTab_HideFateLevelSyncMessages, ref hideFateLevelSync))
            {
                configuration.HideFateLevelSync = hideFateLevelSync;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideFateLevelSyncMessagesHelpMarker);
        }

        ImGui.EndTabItem();
    }
}
