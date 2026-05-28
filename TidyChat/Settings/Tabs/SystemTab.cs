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
            bool housingWardMessage = configuration.ShowHousingWardMessage;
            if (ImGui.Checkbox(Languages.SystemTab_HideHousingWardMessage, ref housingWardMessage))
            {
                configuration.ShowHousingWardMessage = housingWardMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideHousingWardMessageHelpMarker);

            bool completedVenture = configuration.ShowCompletedVenture;
            if (ImGui.Checkbox(Languages.SystemTab_HideCompletedVenture, ref completedVenture))
            {
                configuration.ShowCompletedVenture = completedVenture;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideCompletedVentureHelpMarker);

            bool showAetherCompass = configuration.ShowAetherCompass;
            if (ImGui.Checkbox(Languages.SystemTab_HideAetherCompassMessages, ref showAetherCompass))
            {
                configuration.ShowAetherCompass = showAetherCompass;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideAetherCompassMessagesHelpMarker);

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

            bool showRelicBookMessages = configuration.ShowRelicBookStep || configuration.ShowRelicBookComplete;
            if (ImGui.Checkbox(Languages.SystemTab_ShowRelicBookMessages, ref showRelicBookMessages))
            {
                configuration.ShowRelicBookStep = showRelicBookMessages;
                configuration.ShowRelicBookComplete = showRelicBookMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowRelicBookMessagesHelpMarker);

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

            bool showGearsetEquipped = configuration.ShowGearsetEquipped;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGearsetChangingMessages, ref showGearsetEquipped))
            {
                configuration.ShowGearsetEquipped = showGearsetEquipped;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowGearsetChangingMessagesHelpMarker);

            bool showNowLeaderOf = configuration.ShowNowLeaderOf;
            if (ImGui.Checkbox(Languages.SystemTab_ShowNowALeader, ref showNowLeaderOf))
            {
                configuration.ShowNowLeaderOf = showNowLeaderOf;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowNowALeaderHelpMarker);

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
            bool showFcLoginLogout = configuration.ShowUserLogins || configuration.ShowUserLogouts;
            if (ImGui.Checkbox(Languages.SystemTab_ShowFcLoginLogoutMessages, ref showFcLoginLogout))
            {
                configuration.ShowUserLogins = showFcLoginLogout;
                configuration.ShowUserLogouts = showFcLoginLogout;
                configuration.OnSettingChanged();
            }

            bool showFreeCompanyMessageBook = configuration.ShowFreeCompanyMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_HideFreeCompanyMessageBookMessages,
                    ref showFreeCompanyMessageBook))
            {
                configuration.ShowFreeCompanyMessageBook = showFreeCompanyMessageBook;
                configuration.OnSettingChanged();
            }

            bool showFcVoyageMessages = configuration.ShowExploratoryVoyage || configuration.ShowSubaquaticVoyage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowFcVoyageMessages, ref showFcVoyageMessages))
            {
                configuration.ShowExploratoryVoyage = showFcVoyageMessages;
                configuration.ShowSubaquaticVoyage = showFcVoyageMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowFcVoyageMessagesHelpMarker);
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

            bool showOfferedTeleport = configuration.ShowOfferedTeleport;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTeleportOfferFromPartyMessages, ref showOfferedTeleport))
            {
                configuration.ShowOfferedTeleport = showOfferedTeleport;
                configuration.OnSettingChanged();
            }
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_TradingDropdownHeader))
        {
            bool showTradeMessages = configuration.ShowTradeSent || configuration.ShowTradeCanceled
                                                                 || configuration.ShowAwaitingTradeConfirmation || configuration.ShowTradeComplete;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeMessages, ref showTradeMessages))
            {
                configuration.ShowTradeSent = showTradeMessages;
                configuration.ShowTradeCanceled = showTradeMessages;
                configuration.ShowAwaitingTradeConfirmation = showTradeMessages;
                configuration.ShowTradeComplete = showTradeMessages;
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
