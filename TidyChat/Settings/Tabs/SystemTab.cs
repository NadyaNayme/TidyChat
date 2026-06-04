using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class SystemTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.SystemTab_ServerAnnouncementsDropdownHeader,
                ImGuiTreeNodeFlags.DefaultOpen))
        {
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

        if (ImGui.CollapsingHeader(Languages.SystemTab_WorldAndInstancesDropdownHeader))
        {
            bool sanctuaryMessage = configuration.ShowSanctuaryMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSanctuaryMessage, ref sanctuaryMessage))
            {
                configuration.ShowSanctuaryMessage = sanctuaryMessage;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSanctuaryMessageHelpMarker);

            bool instanceMessage = configuration.ShowInstanceMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowInstanceMessage, ref instanceMessage))
            {
                configuration.ShowInstanceMessage = instanceMessage;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowInstanceMessageHelpMarker);

            SettingsTabLayout.DrawNestedOptions(configuration.ShowInstanceMessage,
                () => DrawInstanceMessageSubOptions(configuration));

            SettingsTabLayout.DrawIndependentOptions(() =>
            {
                bool housingWardMessage = configuration.ShowHousingWardMessage;
                if (ImGui.Checkbox(Languages.SystemTab_ShowHousingWardMessage, ref housingWardMessage))
                {
                    configuration.ShowHousingWardMessage = housingWardMessage;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.SystemTab_ShowHousingWardMessageHelpMarker);
            });
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_HuntMessagesDropdownHeader))
        {
            bool sRankHunt = configuration.ShowSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSRankSpawnAnnouncement, ref sRankHunt))
            {
                configuration.ShowSRankHunt = sRankHunt;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSRankSpawnAnnouncementHelpMarker);

            bool ssRankHunt = configuration.ShowSSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSSRankMinionSpawnAnnouncement, ref ssRankHunt))
            {
                configuration.ShowSSRankHunt = ssRankHunt;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSSRankMinionSpawnAnnouncementHelpMarker);

            bool showHuntSlain = configuration.ShowHuntSlain;
            if (ImGui.Checkbox(Languages.SystemTab_ShowHuntMarkSlainMessages, ref showHuntSlain))
            {
                configuration.ShowHuntSlain = showHuntSlain;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowHuntMarkSlainMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_ExplorationDropdownHeader))
        {
            bool showQuestReminder = configuration.ShowQuestReminder;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSayReminder, ref showQuestReminder))
            {
                configuration.ShowQuestReminder = showQuestReminder;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSayReminderHelpMarker);

            bool showSpideySenses = configuration.ShowSpideySenses;
            if (ImGui.Checkbox(Languages.SystemTab_ShowYouSenseSomethingMessages, ref showSpideySenses))
            {
                configuration.ShowSpideySenses = showSpideySenses;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowYouSenseSomethingMessagesHelpMarker);

            SettingsTabLayout.DrawIndependentOptions(() =>
            {
                bool showLocationDiscovered = configuration.ShowLocationDiscovered;
                if (ImGui.Checkbox(Languages.SystemTab_ShowLocationDiscoveredMessages, ref showLocationDiscovered))
                {
                    configuration.ShowLocationDiscovered = showLocationDiscovered;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.SystemTab_ShowLocationDiscoveredMessagesHelpMarker);

                bool showHostilePresence = configuration.ShowHostilePresence;
                if (ImGui.Checkbox(Languages.SystemTab_ShowHostilePresenceMessages, ref showHostilePresence))
                {
                    configuration.ShowHostilePresence = showHostilePresence;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.SystemTab_ShowHostilePresenceMessagesHelpMarker);
            });

            bool showAetherCompass = configuration.ShowAetherCompass;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetherCompassMessages, ref showAetherCompass))
            {
                configuration.ShowAetherCompass = showAetherCompass;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowAetherCompassMessagesHelpMarker);

            bool showVistaMessages = configuration.ShowVistaMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowVistaMessages, ref showVistaMessages))
            {
                configuration.ShowVistaMessages = showVistaMessages;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowVistaMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_GlamourAndGearDropdownHeader))
        {
            bool showTryOnGlamour = configuration.ShowTryOnGlamour;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTryOnGlamourMessages, ref showTryOnGlamour))
            {
                configuration.ShowTryOnGlamour = showTryOnGlamour;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowTryOnGlamourMessagesHelpMarker);

            SettingsTabLayout.DrawNestedOptions(configuration.ShowTryOnGlamour,
                () => DrawGlamourSubOptions(configuration));

            SettingsTabLayout.DrawIndependentOptions(() =>
            {
                bool showSpiritboundGear = configuration.ShowSpiritboundGear;
                if (ImGui.Checkbox(Languages.SystemTab_ShowSpiritboundMessages, ref showSpiritboundGear))
                {
                    configuration.ShowSpiritboundGear = showSpiritboundGear;
                    configuration.OnSettingChanged();
                }

                bool showEligibleForCoffers = configuration.ShowEligibleForCoffers;
                if (ImGui.Checkbox(Languages.SystemTab_ShowNumberOfCoffers, ref showEligibleForCoffers))
                {
                    configuration.ShowEligibleForCoffers = showEligibleForCoffers;
                    configuration.OnSettingChanged();
                }
            });
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_SocialAndMiscDropdownHeader))
        {
            bool commendations = configuration.ShowCommendations;
            if (ImGui.Checkbox(Languages.SystemTab_ShowReceivedCommendations, ref commendations))
            {
                configuration.ShowCommendations = commendations;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowReceivedCommendationsHelpMarker);

            bool showPersonalMessageBook = configuration.ShowPersonalMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPersonalMessageBookMessages, ref showPersonalMessageBook))
            {
                configuration.ShowPersonalMessageBook = showPersonalMessageBook;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowPersonalMessageBookMessagesHelpMarker);

            bool showAetheryteTicket = configuration.ShowAetheryteTicket;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetheryteTicketMessage, ref showAetheryteTicket))
            {
                configuration.ShowAetheryteTicket = showAetheryteTicket;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowAetheryteTicketMessageHelpMarker);

            bool showAttuneAetheryte = configuration.ShowAttuneAetheryte;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAttuneAetheryteMessage, ref showAttuneAetheryte))
            {
                configuration.ShowAttuneAetheryte = showAttuneAetheryte;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowAttuneAetheryteMessageHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_CharacterAndGearDropdownHeader))
        {
            bool showGearsetEquipped = configuration.ShowGearsetEquipped;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGearsetChangingMessages, ref showGearsetEquipped))
            {
                configuration.ShowGearsetEquipped = showGearsetEquipped;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGearsetChangingMessagesHelpMarker);

            bool showJobChange = configuration.ShowJobChange;
            if (ImGui.Checkbox(Languages.SystemTab_ShowJobChangeMessages, ref showJobChange))
            {
                configuration.ShowJobChange = showJobChange;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowJobChangeMessagesHelpMarker);

            bool showPortraitMessages = configuration.ShowPortraitMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPortraitMessages, ref showPortraitMessages))
            {
                configuration.ShowPortraitMessages = showPortraitMessages;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowPortraitMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_MailDropdownHeader))
        {
            bool showAttachToMail = configuration.ShowAttachToMail;
            if (ImGui.Checkbox(Languages.SystemTab_ShowMailAttachmentMessages, ref showAttachToMail))
            {
                configuration.ShowAttachToMail = showAttachToMail;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowMailAttachmentMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_RelicDropdownHeader))
        {
            bool showRelicBookStep = configuration.ShowRelicBookStep;
            if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicProgressMessages, ref showRelicBookStep))
            {
                configuration.ShowRelicBookStep = showRelicBookStep;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowARRRelicProgressMessagesHelpMarker);

            bool showRelicBookComplete = configuration.ShowRelicBookComplete;
            if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicBookStepMessages, ref showRelicBookComplete))
            {
                configuration.ShowRelicBookComplete = showRelicBookComplete;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowARRRelicBookStepMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_SocialStatusDropdownHeader))
        {
            bool showOnlineStatus = configuration.ShowOnlineStatus;
            if (ImGui.Checkbox(Languages.SystemTab_ShowOnlineStatusMessages, ref showOnlineStatus))
            {
                configuration.ShowOnlineStatus = showOnlineStatus;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowOnlineStatusMessagesHelpMarker);

            bool showSearchForItemResults = configuration.ShowSearchForItemResults;
            if (ImGui.Checkbox(Languages.SystemTab_ShowItemSearchResultsMessage, ref showSearchForItemResults))
            {
                configuration.ShowSearchForItemResults = showSearchForItemResults;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowItemSearchResultsMessageHelpMarker);

            SettingsTabLayout.DrawNestedOptions(configuration.ShowSearchForItemResults, () =>
            {
                bool showItemSearchResults = configuration.ShowItemSearchResults;
                if (ImGui.Checkbox(Languages.SystemTab_ShowInventoryItemSearchResults, ref showItemSearchResults))
                {
                    configuration.ShowItemSearchResults = showItemSearchResults;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.SystemTab_ShowInventoryItemSearchResultsHelpMarker);

                bool showLocationSearchResults = configuration.ShowLocationSearchResults;
                if (ImGui.Checkbox(Languages.SystemTab_ShowLocationSearchResults, ref showLocationSearchResults))
                {
                    configuration.ShowLocationSearchResults = showLocationSearchResults;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.SystemTab_ShowLocationSearchResultsHelpMarker);
            });
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_CatchAllDropdownHeader))
        {
            bool showEverythingElse = configuration.ShowEverythingElse;
            if (ImGui.Checkbox(Languages.SystemTab_ShowEverythingElse, ref showEverythingElse))
            {
                configuration.ShowEverythingElse = showEverythingElse;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowEverythingElseHelpMarker);

            SettingsTabLayout.DrawNestedOptions(configuration.ShowEverythingElse,
                () => DrawMiscSystemSubOptions(configuration));
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_OrchestrionDropdownHeader))
        {
            bool hideOrchestrionPlaying = configuration.HideOrchestrionPlaying;
            if (ImGui.Checkbox(Languages.SystemTab_ShowOrchestrionPlaying, ref hideOrchestrionPlaying))
            {
                configuration.HideOrchestrionPlaying = hideOrchestrionPlaying;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowOrchestrionPlayingHelpMarker);

            bool showVolumeControlMessage = configuration.ShowVolumeControlMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowVolumeControlMessages, ref showVolumeControlMessage))
            {
                configuration.ShowVolumeControlMessage = showVolumeControlMessage;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowVolumeControlMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_ErrorMessagesDropdownHeader))
        {
            bool hideFateLevelSync = configuration.HideFateLevelSync;
            if (ImGui.Checkbox(Languages.SystemTab_ShowFateLevelSyncMessages, ref hideFateLevelSync))
            {
                configuration.HideFateLevelSync = hideFateLevelSync;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowFateLevelSyncMessagesHelpMarker);

            bool showActiveHelpEntry = configuration.ShowActiveHelpEntry;
            if (ImGui.Checkbox(Languages.SystemTab_ShowActiveHelpEntryMessages, ref showActiveHelpEntry))
            {
                configuration.ShowActiveHelpEntry = showActiveHelpEntry;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowActiveHelpEntryMessagesHelpMarker);
        }
    }

    private static void DrawInstanceMessageSubOptions(Configuration configuration)
    {
        bool showInstancedArea = configuration.ShowInstancedAreaMessages;
        if (ImGui.Checkbox(Languages.SystemTab_ShowInstancedAreaMessages, ref showInstancedArea))
        {
            configuration.ShowInstancedAreaMessages = showInstancedArea;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowInstancedAreaMessagesHelpMarker);

        bool showDutyEnded = configuration.ShowDutyEndedMessage;
        if (ImGui.Checkbox(Languages.SystemTab_ShowDutyEndedMessage, ref showDutyEnded))
        {
            configuration.ShowDutyEndedMessage = showDutyEnded;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowDutyEndedMessageHelpMarker);

        bool showGuildhestEnded = configuration.ShowGuildhestEndedMessage;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGuildhestEndedMessage, ref showGuildhestEnded))
        {
            configuration.ShowGuildhestEndedMessage = showGuildhestEnded;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGuildhestEndedMessageHelpMarker);

        bool showLevelNoLongerSynced = configuration.ShowLevelNoLongerSynced;
        if (ImGui.Checkbox(Languages.SystemTab_ShowLevelNoLongerSynced, ref showLevelNoLongerSynced))
        {
            configuration.ShowLevelNoLongerSynced = showLevelNoLongerSynced;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowLevelNoLongerSyncedHelpMarker);

        bool showDutyMechanic = configuration.ShowDutyMechanicMessages;
        if (ImGui.Checkbox(Languages.SystemTab_ShowDutyMechanicMessages, ref showDutyMechanic))
        {
            configuration.ShowDutyMechanicMessages = showDutyMechanic;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowDutyMechanicMessagesHelpMarker);

        bool showDutyObjectiveBonus = configuration.ShowDutyObjectiveBonus;
        if (ImGui.Checkbox(Languages.SystemTab_ShowDutyObjectiveBonus, ref showDutyObjectiveBonus))
        {
            configuration.ShowDutyObjectiveBonus = showDutyObjectiveBonus;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowDutyObjectiveBonusHelpMarker);
    }

    private static void DrawGlamourSubOptions(Configuration configuration)
    {
        bool showTryOnCast = configuration.ShowTryOnGlamourCast;
        if (ImGui.Checkbox(Languages.SystemTab_ShowTryOnGlamourCast, ref showTryOnCast))
        {
            configuration.ShowTryOnGlamourCast = showTryOnCast;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowTryOnGlamourCastHelpMarker);

        bool showPlateProjected = configuration.ShowGlamourPlateProjected;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGlamourPlateProjected, ref showPlateProjected))
        {
            configuration.ShowGlamourPlateProjected = showPlateProjected;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGlamourPlateProjectedHelpMarker);

        bool showPartialApply = configuration.ShowGlamourPlatePartialApply;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGlamourPlatePartialApply, ref showPartialApply))
        {
            configuration.ShowGlamourPlatePartialApply = showPartialApply;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGlamourPlatePartialApplyHelpMarker);

        bool showGearDye = configuration.ShowGearDyeApplied;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGearDyeApplied, ref showGearDye))
        {
            configuration.ShowGearDyeApplied = showGearDye;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGearDyeAppliedHelpMarker);

        bool showRestoreFailed = configuration.ShowGearsetGlamourRestoreFailed;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGearsetGlamourRestoreFailed, ref showRestoreFailed))
        {
            configuration.ShowGearsetGlamourRestoreFailed = showRestoreFailed;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGearsetGlamourRestoreFailedHelpMarker);

        bool showGlamourAltered = configuration.ShowGlamourAltered;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGlamourAltered, ref showGlamourAltered))
        {
            configuration.ShowGlamourAltered = showGlamourAltered;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGlamourAlteredHelpMarker);
    }

    private static void DrawMiscSystemSubOptions(Configuration configuration)
    {
        bool showChangesDiscarded = configuration.ShowChangesDiscarded;
        if (ImGui.Checkbox(Languages.SystemTab_ShowChangesDiscarded, ref showChangesDiscarded))
        {
            configuration.ShowChangesDiscarded = showChangesDiscarded;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowChangesDiscardedHelpMarker);

        bool showChangesLost = configuration.ShowChangesLost;
        if (ImGui.Checkbox(Languages.SystemTab_ShowChangesLost, ref showChangesLost))
        {
            configuration.ShowChangesLost = showChangesLost;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowChangesLostHelpMarker);

        bool showTripleTriadAllowed = configuration.ShowTripleTriadAllowed;
        if (ImGui.Checkbox(Languages.SystemTab_ShowTripleTriadAllowed, ref showTripleTriadAllowed))
        {
            configuration.ShowTripleTriadAllowed = showTripleTriadAllowed;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowTripleTriadAllowedHelpMarker);

        bool showTripleTriadNotAllowed = configuration.ShowTripleTriadNotAllowed;
        if (ImGui.Checkbox(Languages.SystemTab_ShowTripleTriadNotAllowed, ref showTripleTriadNotAllowed))
        {
            configuration.ShowTripleTriadNotAllowed = showTripleTriadNotAllowed;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowTripleTriadNotAllowedHelpMarker);
    }
}
