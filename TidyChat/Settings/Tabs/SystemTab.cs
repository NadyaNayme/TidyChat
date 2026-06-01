using System;
using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class SystemTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.SystemTab_HideShownDefaultDropdownHeader))
        {
            bool sanctuaryMessage = configuration.ShowSanctuaryMessage;
            if (ImGui.Checkbox(Languages.SystemTab_HideSanctuaryMessage, ref sanctuaryMessage))
            {
                configuration.ShowSanctuaryMessage = sanctuaryMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSanctuaryMessageHelpMarker);

            bool instanceMessage = configuration.ShowInstanceMessage;
            if (ImGui.Checkbox(Languages.SystemTab_HideInstanceMessage, ref instanceMessage))
            {
                configuration.ShowInstanceMessage = instanceMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideInstanceMessageHelpMarker);

            bool housingWardMessage = configuration.ShowHousingWardMessage;
            if (ImGui.Checkbox(Languages.SystemTab_HideHousingWardMessage, ref housingWardMessage))
            {
                configuration.ShowHousingWardMessage = housingWardMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideHousingWardMessageHelpMarker);

            bool sRankHunt = configuration.ShowSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_HideSRankSpawnAnnouncement, ref sRankHunt))
            {
                configuration.ShowSRankHunt = sRankHunt;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSRankSpawnAnnouncementHelpMarker);

            bool ssRankHunt = configuration.ShowSSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_HideSSRankMinionSpawnAnnouncement, ref ssRankHunt))
            {
                configuration.ShowSSRankHunt = ssRankHunt;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSSRankMinionSpawnAnnouncementHelpMarker);

            bool commendations = configuration.ShowCommendations;
            if (ImGui.Checkbox(Languages.SystemTab_HideReceivedCommendations, ref commendations))
            {
                configuration.ShowCommendations = commendations;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideReceivedCommendationsHelpMarker);

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

            bool showQuestReminder = configuration.ShowQuestReminder;
            if (ImGui.Checkbox(Languages.SystemTab_HideSayReminder, ref showQuestReminder))
            {
                configuration.ShowQuestReminder = showQuestReminder;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideSayReminderHelpMarker);

            bool showSpideySenses = configuration.ShowSpideySenses;
            if (ImGui.Checkbox(Languages.SystemTab_HideYouSenseSomethingMessages, ref showSpideySenses))
            {
                configuration.ShowSpideySenses = showSpideySenses;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideYouSenseSomethingMessagesHelpMarker);

            bool showAetherCompass = configuration.ShowAetherCompass;
            if (ImGui.Checkbox(Languages.SystemTab_HideAetherCompassMessages, ref showAetherCompass))
            {
                configuration.ShowAetherCompass = showAetherCompass;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideAetherCompassMessagesHelpMarker);

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

            bool showSearchForItemResults = configuration.ShowSearchForItemResults;
            if (ImGui.Checkbox(Languages.SystemTab_HideItemSearchResultsMessage, ref showSearchForItemResults))
            {
                configuration.ShowSearchForItemResults = showSearchForItemResults;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideItemSearchResultsMessageHelpMarker);

            bool showVistaMessages = configuration.ShowVistaMessages;
            if (ImGui.Checkbox(Languages.SystemTab_HideVistaMessages, ref showVistaMessages))
            {
                configuration.ShowVistaMessages = showVistaMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideVistaMessagesHelpMarker);

            bool showTryOnGlamour = configuration.ShowTryOnGlamour;
            if (ImGui.Checkbox(Languages.SystemTab_HideTryOnGlamourMessages, ref showTryOnGlamour))
            {
                configuration.ShowTryOnGlamour = showTryOnGlamour;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideTryOnGlamourMessagesHelpMarker);

            bool showPersonalMessageBook = configuration.ShowPersonalMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_HidePersonalMessageBookMessages, ref showPersonalMessageBook))
            {
                configuration.ShowPersonalMessageBook = showPersonalMessageBook;
                configuration.OnSettingChanged();
            }

            bool showSpiritboundGear = configuration.ShowSpiritboundGear;
            if (ImGui.Checkbox(Languages.SystemTab_HideSpiritboundMessages, ref showSpiritboundGear))
            {
                configuration.ShowSpiritboundGear = showSpiritboundGear;
                configuration.OnSettingChanged();
            }

            bool showEligibleForCoffers = configuration.ShowEligibleForCoffers;
            if (ImGui.Checkbox(Languages.SystemTab_HideNumberOfCoffers, ref showEligibleForCoffers))
            {
                configuration.ShowEligibleForCoffers = showEligibleForCoffers;
                configuration.OnSettingChanged();
            }

            bool showAetheryteTicket = configuration.ShowAetheryteTicket;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetheryteTicketMessage, ref showAetheryteTicket))
            {
                configuration.ShowAetheryteTicket = showAetheryteTicket;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowAetheryteTicketMessageHelpMarker);

            // TODO(#122): localize combo labels in satellite language resx files.
            string[] serverAnnouncementModes =
            [
                Languages.SystemTab_ServerAnnouncementMode_ShowAll,
                Languages.SystemTab_ServerAnnouncementMode_HideAll,
                Languages.SystemTab_ServerAnnouncementMode_Condensed,
                Languages.SystemTab_ServerAnnouncementMode_LoginOnly,
                Languages.SystemTab_ServerAnnouncementMode_LoginThenCondensed,
                Languages.SystemTab_ServerAnnouncementMode_HidePhishing
            ];
            int serverAnnouncementMode =
                Math.Clamp((int)configuration.ServerAnnouncementMode, 0, serverAnnouncementModes.Length - 1);
            ImGui.TextUnformatted(Languages.SystemTab_ServerAnnouncementsLabel);
            ImGui.SetNextItemWidth(320f);
            if (ImGui.BeginCombo("##serverAnnouncementMode", serverAnnouncementModes[serverAnnouncementMode]))
            {
                for (int i = 0; i < serverAnnouncementModes.Length; i++)
                {
                    if (ImGui.Selectable(serverAnnouncementModes[i], serverAnnouncementMode == i))
                    {
                        configuration.ServerAnnouncementMode = (ServerAnnouncementMode)i;
                        configuration.OnSettingChanged();
                    }
                }

                ImGui.EndCombo();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ServerAnnouncementsHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_ShowHiddenMessagesDropdownHeader))
        {
            bool showOnlineStatus = configuration.ShowOnlineStatus;
            if (ImGui.Checkbox(Languages.SystemTab_ShowOnlineStatusMessages, ref showOnlineStatus))
            {
                configuration.ShowOnlineStatus = showOnlineStatus;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowOnlineStatusMessagesHelpMarker);

            bool showAttachToMail = configuration.ShowAttachToMail;
            if (ImGui.Checkbox(Languages.SystemTab_ShowMailAttachmentMessages, ref showAttachToMail))
            {
                configuration.ShowAttachToMail = showAttachToMail;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowMailAttachmentMessagesHelpMarker);

            bool showRelicBookStep = configuration.ShowRelicBookStep;
            if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicProgressMessages, ref showRelicBookStep))
            {
                configuration.ShowRelicBookStep = showRelicBookStep;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowARRRelicProgressMessagesHelpMarker);

            bool showRelicBookComplete = configuration.ShowRelicBookComplete;
            if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicBookStepMessages, ref showRelicBookComplete))
            {
                configuration.ShowRelicBookComplete = showRelicBookComplete;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowARRRelicBookStepMessagesHelpMarker);

            bool showHuntSlain = configuration.ShowHuntSlain;
            if (ImGui.Checkbox(Languages.SystemTab_ShowHuntMarkSlainMessages, ref showHuntSlain))
            {
                configuration.ShowHuntSlain = showHuntSlain;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowHuntMarkSlainMessagesHelpMarker);

            bool showCompletionTime = configuration.ShowCompletionTime;
            if (ImGui.Checkbox(Languages.SystemTab_ShowCompletionTimeForUnrestrictedParty, ref showCompletionTime))
            {
                configuration.ShowCompletionTime = showCompletionTime;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowCompletionTimeForUnrestrictedPartyHelpMarker);

            bool showVolumeControlMessage = configuration.ShowVolumeControlMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowVolumeControlMessages, ref showVolumeControlMessage))
            {
                configuration.ShowVolumeControlMessage = showVolumeControlMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowVolumeControlMessagesHelpMarker);

            bool showGearsetEquipped = configuration.ShowGearsetEquipped;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGearsetChangingMessages, ref showGearsetEquipped))
            {
                configuration.ShowGearsetEquipped = showGearsetEquipped;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowGearsetChangingMessagesHelpMarker);

            bool showJobChange = configuration.ShowJobChange;
            if (ImGui.Checkbox(Languages.SystemTab_ShowJobChangeMessages, ref showJobChange))
            {
                configuration.ShowJobChange = showJobChange;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowJobChangeMessagesHelpMarker);

            bool showPortraitMessages = configuration.ShowPortraitMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPortraitMessages, ref showPortraitMessages))
            {
                configuration.ShowPortraitMessages = showPortraitMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowPortraitMessagesHelpMarker);

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

            bool showEverythingElse = configuration.ShowEverythingElse;
            if (ImGui.Checkbox(Languages.SystemTab_ShowEverythingElse, ref showEverythingElse))
            {
                configuration.ShowEverythingElse = showEverythingElse;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowEverythingElseHelpMarker);
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

        if (ImGui.CollapsingHeader(Languages.SystemTab_PartyAndInviteDropdownHeader))
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

            bool showDutyFinder = configuration.ShowDutyFinder;
            if (ImGui.Checkbox(Languages.SystemTab_ShowDutyFinderMessages, ref showDutyFinder))
            {
                configuration.ShowDutyFinder = showDutyFinder;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowDutyFinderMessagesHelpMarker);

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

        if (ImGui.CollapsingHeader(Languages.SystemTab_TradingDropdownHeader))
        {
            bool showVendorSellMessages = configuration.ShowVendorSellMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowVendorSellMessages, ref showVendorSellMessages))
            {
                configuration.ShowVendorSellMessages = showVendorSellMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowVendorSellMessagesHelpMarker);

            bool showVendorPurchaseMessages = configuration.ShowVendorPurchaseMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowVendorPurchaseMessages, ref showVendorPurchaseMessages))
            {
                configuration.ShowVendorPurchaseMessages = showVendorPurchaseMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowVendorPurchaseMessagesHelpMarker);

            bool showMarketBoardMessages = configuration.ShowMarketBoardMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowMarketBoardMessages, ref showMarketBoardMessages))
            {
                configuration.ShowMarketBoardMessages = showMarketBoardMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowMarketBoardMessagesHelpMarker);

            bool showGilWithdrawnMessage = configuration.ShowGilWithdrawnMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGilWithdrawnMessage, ref showGilWithdrawnMessage))
            {
                configuration.ShowGilWithdrawnMessage = showGilWithdrawnMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowGilWithdrawnMessageHelpMarker);

            bool showGilSpentMessage = configuration.ShowGilSpentMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGilSpentMessage, ref showGilSpentMessage))
            {
                configuration.ShowGilSpentMessage = showGilSpentMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowGilSpentMessageHelpMarker);

            bool showTradeSent = configuration.ShowTradeSent;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeRequestSentMessages, ref showTradeSent))
            {
                configuration.ShowTradeSent = showTradeSent;
                configuration.OnSettingChanged();
            }

            bool showTradeCanceled = configuration.ShowTradeCanceled;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeCanceledMessages, ref showTradeCanceled))
            {
                configuration.ShowTradeCanceled = showTradeCanceled;
                configuration.OnSettingChanged();
            }

            bool showAwaitingTradeConfirmation = configuration.ShowAwaitingTradeConfirmation;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAwaitingTradeConfirmationMessages,
                    ref showAwaitingTradeConfirmation))
            {
                configuration.ShowAwaitingTradeConfirmation = showAwaitingTradeConfirmation;
                configuration.OnSettingChanged();
            }

            bool showTradeComplete = configuration.ShowTradeComplete;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeCompleteMessages, ref showTradeComplete))
            {
                configuration.ShowTradeComplete = showTradeComplete;
                configuration.OnSettingChanged();
            }
        }


        if (ImGui.CollapsingHeader(Languages.SystemTab_OrchestrionDropdownHeader))
        {
            bool hideOrchestrionPlaying = configuration.HideOrchestrionPlaying;
            if (ImGui.Checkbox(Languages.SystemTab_HideOrchestrionPlaying, ref hideOrchestrionPlaying))
            {
                configuration.HideOrchestrionPlaying = hideOrchestrionPlaying;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideOrchestrionPlayingHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_ErrorMessagesDropdownHeader))
        {
            bool hideFateLevelSync = configuration.HideFateLevelSync;
            if (ImGui.Checkbox(Languages.SystemTab_HideFateLevelSyncMessages, ref hideFateLevelSync))
            {
                configuration.HideFateLevelSync = hideFateLevelSync;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideFateLevelSyncMessagesHelpMarker);

            bool hideCannotExecute = configuration.HideCannotExecute;
            if (ImGui.Checkbox(Languages.SystemTab_HideCannotExecuteMessages, ref hideCannotExecute))
            {
                configuration.HideCannotExecute = hideCannotExecute;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideCannotExecuteMessagesHelpMarker);

            bool showFateDiscovery = configuration.ShowFateDiscovery;
            if (ImGui.Checkbox(Languages.SystemTab_ShowFateDiscoveryMessages, ref showFateDiscovery))
            {
                configuration.ShowFateDiscovery = showFateDiscovery;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowFateDiscoveryMessagesHelpMarker);

            bool showFriendList = configuration.ShowFriendList;
            if (ImGui.Checkbox(Languages.SystemTab_ShowFriendListMessages, ref showFriendList))
            {
                configuration.ShowFriendList = showFriendList;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowFriendListMessagesHelpMarker);

            bool showActiveHelpEntry = configuration.ShowActiveHelpEntry;
            if (ImGui.Checkbox(Languages.SystemTab_ShowActiveHelpEntryMessages, ref showActiveHelpEntry))
            {
                configuration.ShowActiveHelpEntry = showActiveHelpEntry;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowActiveHelpEntryMessagesHelpMarker);
        }

        ImGui.EndTabItem();
    }
}
