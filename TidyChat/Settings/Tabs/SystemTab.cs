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
            var serverAnnouncementMode =
                Math.Clamp((int)configuration.ServerAnnouncementMode, 0, serverAnnouncementModes.Length - 1);
            ImGui.TextUnformatted(Languages.SystemTab_ServerAnnouncementsLabel);
            ImGui.SetNextItemWidth(320f);
            if (ImGui.BeginCombo("##serverAnnouncementMode", serverAnnouncementModes[serverAnnouncementMode]))
            {
                for (var i = 0; i < serverAnnouncementModes.Length; i++)
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
            var sanctuaryMessage = configuration.ShowSanctuaryMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSanctuaryMessage, ref sanctuaryMessage))
            {
                configuration.ShowSanctuaryMessage = sanctuaryMessage;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSanctuaryMessageHelpMarker);

            var instanceMessage = configuration.ShowInstanceMessage;
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
                var housingWardMessage = configuration.ShowHousingWardMessage;
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
            var sRankHunt = configuration.ShowSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSRankSpawnAnnouncement, ref sRankHunt))
            {
                configuration.ShowSRankHunt = sRankHunt;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSRankSpawnAnnouncementHelpMarker);

            var ssRankHunt = configuration.ShowSSRankHunt;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSSRankMinionSpawnAnnouncement, ref ssRankHunt))
            {
                configuration.ShowSSRankHunt = ssRankHunt;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSSRankMinionSpawnAnnouncementHelpMarker);

            var showHuntSlain = configuration.ShowHuntSlain;
            if (ImGui.Checkbox(Languages.SystemTab_ShowHuntMarkSlainMessages, ref showHuntSlain))
            {
                configuration.ShowHuntSlain = showHuntSlain;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowHuntMarkSlainMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_ExplorationDropdownHeader))
        {
            var showQuestReminder = configuration.ShowQuestReminder;
            if (ImGui.Checkbox(Languages.SystemTab_ShowSayReminder, ref showQuestReminder))
            {
                configuration.ShowQuestReminder = showQuestReminder;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSayReminderHelpMarker);

            var showSpideySenses = configuration.ShowSpideySenses;
            if (ImGui.Checkbox(Languages.SystemTab_ShowYouSenseSomethingMessages, ref showSpideySenses))
            {
                configuration.ShowSpideySenses = showSpideySenses;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowYouSenseSomethingMessagesHelpMarker);

            SettingsTabLayout.DrawIndependentOptions(() =>
            {
                var showLocationDiscovered = configuration.ShowLocationDiscovered;
                if (ImGui.Checkbox(Languages.SystemTab_ShowLocationDiscoveredMessages, ref showLocationDiscovered))
                {
                    configuration.ShowLocationDiscovered = showLocationDiscovered;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.SystemTab_ShowLocationDiscoveredMessagesHelpMarker);

                var showHostilePresence = configuration.ShowHostilePresence;
                if (ImGui.Checkbox(Languages.SystemTab_ShowHostilePresenceMessages, ref showHostilePresence))
                {
                    configuration.ShowHostilePresence = showHostilePresence;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.SystemTab_ShowHostilePresenceMessagesHelpMarker);
            });

            var showAetherCompass = configuration.ShowAetherCompass;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetherCompassMessages, ref showAetherCompass))
            {
                configuration.ShowAetherCompass = showAetherCompass;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowAetherCompassMessagesHelpMarker);

            var showVistaMessages = configuration.ShowVistaMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowVistaMessages, ref showVistaMessages))
            {
                configuration.ShowVistaMessages = showVistaMessages;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowVistaMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_GlamourAndGearDropdownHeader))
        {
            var showTryOnGlamour = configuration.ShowTryOnGlamour;
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
                var showSpiritboundGear = configuration.ShowSpiritboundGear;
                if (ImGui.Checkbox(Languages.SystemTab_ShowSpiritboundMessages, ref showSpiritboundGear))
                {
                    configuration.ShowSpiritboundGear = showSpiritboundGear;
                    configuration.OnSettingChanged();
                }

                var showEligibleForCoffers = configuration.ShowEligibleForCoffers;
                if (ImGui.Checkbox(Languages.SystemTab_ShowNumberOfCoffers, ref showEligibleForCoffers))
                {
                    configuration.ShowEligibleForCoffers = showEligibleForCoffers;
                    configuration.OnSettingChanged();
                }
            });
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_SocialAndMiscDropdownHeader))
        {
            var commendations = configuration.ShowCommendations;
            if (ImGui.Checkbox(Languages.SystemTab_ShowReceivedCommendations, ref commendations))
            {
                configuration.ShowCommendations = commendations;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowReceivedCommendationsHelpMarker);

            var showPersonalMessageBook = configuration.ShowPersonalMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPersonalMessageBookMessages, ref showPersonalMessageBook))
            {
                configuration.ShowPersonalMessageBook = showPersonalMessageBook;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowPersonalMessageBookMessagesHelpMarker);

            var showAetheryteTicket = configuration.ShowAetheryteTicket;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetheryteTicketMessage, ref showAetheryteTicket))
            {
                configuration.ShowAetheryteTicket = showAetheryteTicket;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowAetheryteTicketMessageHelpMarker);

            var showAttuneAetheryte = configuration.ShowAttuneAetheryte;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAttuneAetheryteMessage, ref showAttuneAetheryte))
            {
                configuration.ShowAttuneAetheryte = showAttuneAetheryte;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowAttuneAetheryteMessageHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_CharacterAndGearDropdownHeader))
        {
            var showGearsetEquipped = configuration.ShowGearsetEquipped;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGearsetChangingMessages, ref showGearsetEquipped))
            {
                configuration.ShowGearsetEquipped = showGearsetEquipped;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGearsetChangingMessagesHelpMarker);

            var showGearItemsRepaired = configuration.ShowGearItemsRepaired;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGearItemsRepaired, ref showGearItemsRepaired))
            {
                configuration.ShowGearItemsRepaired = showGearItemsRepaired;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGearItemsRepairedHelpMarker);

            var showJobChange = configuration.ShowJobChange;
            if (ImGui.Checkbox(Languages.SystemTab_ShowJobChangeMessages, ref showJobChange))
            {
                configuration.ShowJobChange = showJobChange;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowJobChangeMessagesHelpMarker);

            var showPortraitMessages = configuration.ShowPortraitMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowPortraitMessages, ref showPortraitMessages))
            {
                configuration.ShowPortraitMessages = showPortraitMessages;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowPortraitMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_MailDropdownHeader))
        {
            var showAttachToMail = configuration.ShowAttachToMail;
            if (ImGui.Checkbox(Languages.SystemTab_ShowMailAttachmentMessages, ref showAttachToMail))
            {
                configuration.ShowAttachToMail = showAttachToMail;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowMailAttachmentMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_RelicDropdownHeader))
        {
            var showRelicBookStep = configuration.ShowRelicBookStep;
            if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicProgressMessages, ref showRelicBookStep))
            {
                configuration.ShowRelicBookStep = showRelicBookStep;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowARRRelicProgressMessagesHelpMarker);

            var showRelicBookComplete = configuration.ShowRelicBookComplete;
            if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicBookStepMessages, ref showRelicBookComplete))
            {
                configuration.ShowRelicBookComplete = showRelicBookComplete;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowARRRelicBookStepMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_SocialStatusDropdownHeader))
        {
            var showOnlineStatus = configuration.ShowOnlineStatus;
            if (ImGui.Checkbox(Languages.SystemTab_ShowOnlineStatusMessages, ref showOnlineStatus))
            {
                configuration.ShowOnlineStatus = showOnlineStatus;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowOnlineStatusMessagesHelpMarker);

            var showSearchForItemResults = configuration.ShowSearchForItemResults;
            if (ImGui.Checkbox(Languages.SystemTab_ShowItemSearchResultsMessage, ref showSearchForItemResults))
            {
                configuration.ShowSearchForItemResults = showSearchForItemResults;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowItemSearchResultsMessageHelpMarker);

            SettingsTabLayout.DrawNestedOptions(configuration.ShowSearchForItemResults, () =>
            {
                var showItemSearchResults = configuration.ShowItemSearchResults;
                if (ImGui.Checkbox(Languages.SystemTab_ShowInventoryItemSearchResults, ref showItemSearchResults))
                {
                    configuration.ShowItemSearchResults = showItemSearchResults;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.SystemTab_ShowInventoryItemSearchResultsHelpMarker);

                var showLocationSearchResults = configuration.ShowLocationSearchResults;
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
            var showEverythingElse = configuration.ShowEverythingElse;
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
            var hideOrchestrionPlaying = configuration.HideOrchestrionPlaying;
            if (ImGui.Checkbox(Languages.SystemTab_ShowOrchestrionPlaying, ref hideOrchestrionPlaying))
            {
                configuration.HideOrchestrionPlaying = hideOrchestrionPlaying;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowOrchestrionPlayingHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_ErrorMessagesDropdownHeader))
        {
            var hideFateLevelSync = configuration.HideFateLevelSync;
            if (ImGui.Checkbox(Languages.SystemTab_ShowFateLevelSyncMessages, ref hideFateLevelSync))
            {
                configuration.HideFateLevelSync = hideFateLevelSync;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowFateLevelSyncMessagesHelpMarker);

            var showActiveHelpEntry = configuration.ShowActiveHelpEntry;
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
        var showInstancedArea = configuration.ShowInstancedAreaMessages;
        if (ImGui.Checkbox(Languages.SystemTab_ShowInstancedAreaMessages, ref showInstancedArea))
        {
            configuration.ShowInstancedAreaMessages = showInstancedArea;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowInstancedAreaMessagesHelpMarker);

        var showDutyEnded = configuration.ShowDutyEndedMessage;
        if (ImGui.Checkbox(Languages.SystemTab_ShowDutyEndedMessage, ref showDutyEnded))
        {
            configuration.ShowDutyEndedMessage = showDutyEnded;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowDutyEndedMessageHelpMarker);

        var showGuildhestEnded = configuration.ShowGuildhestEndedMessage;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGuildhestEndedMessage, ref showGuildhestEnded))
        {
            configuration.ShowGuildhestEndedMessage = showGuildhestEnded;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGuildhestEndedMessageHelpMarker);

        var showLevelNoLongerSynced = configuration.ShowLevelNoLongerSynced;
        if (ImGui.Checkbox(Languages.SystemTab_ShowLevelNoLongerSynced, ref showLevelNoLongerSynced))
        {
            configuration.ShowLevelNoLongerSynced = showLevelNoLongerSynced;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowLevelNoLongerSyncedHelpMarker);

        var showDutyMechanic = configuration.ShowDutyMechanicMessages;
        if (ImGui.Checkbox(Languages.SystemTab_ShowDutyMechanicMessages, ref showDutyMechanic))
        {
            configuration.ShowDutyMechanicMessages = showDutyMechanic;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowDutyMechanicMessagesHelpMarker);

        var showDutyObjectiveBonus = configuration.ShowDutyObjectiveBonus;
        if (ImGui.Checkbox(Languages.SystemTab_ShowDutyObjectiveBonus, ref showDutyObjectiveBonus))
        {
            configuration.ShowDutyObjectiveBonus = showDutyObjectiveBonus;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowDutyObjectiveBonusHelpMarker);
    }

    private static void DrawGlamourSubOptions(Configuration configuration)
    {
        var showTryOnCast = configuration.ShowTryOnGlamourCast;
        if (ImGui.Checkbox(Languages.SystemTab_ShowTryOnGlamourCast, ref showTryOnCast))
        {
            configuration.ShowTryOnGlamourCast = showTryOnCast;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowTryOnGlamourCastHelpMarker);

        var showPlateProjected = configuration.ShowGlamourPlateProjected;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGlamourPlateProjected, ref showPlateProjected))
        {
            configuration.ShowGlamourPlateProjected = showPlateProjected;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGlamourPlateProjectedHelpMarker);

        var showPartialApply = configuration.ShowGlamourPlatePartialApply;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGlamourPlatePartialApply, ref showPartialApply))
        {
            configuration.ShowGlamourPlatePartialApply = showPartialApply;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGlamourPlatePartialApplyHelpMarker);

        var showGearDye = configuration.ShowGearDyeApplied;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGearDyeApplied, ref showGearDye))
        {
            configuration.ShowGearDyeApplied = showGearDye;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGearDyeAppliedHelpMarker);

        var showRestoreFailed = configuration.ShowGearsetGlamourRestoreFailed;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGearsetGlamourRestoreFailed, ref showRestoreFailed))
        {
            configuration.ShowGearsetGlamourRestoreFailed = showRestoreFailed;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGearsetGlamourRestoreFailedHelpMarker);

        var showGlamourAltered = configuration.ShowGlamourAltered;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGlamourAltered, ref showGlamourAltered))
        {
            configuration.ShowGlamourAltered = showGlamourAltered;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGlamourAlteredHelpMarker);
    }

    private static void DrawMiscSystemSubOptions(Configuration configuration)
    {
        var showChangesDiscarded = configuration.ShowChangesDiscarded;
        if (ImGui.Checkbox(Languages.SystemTab_ShowChangesDiscarded, ref showChangesDiscarded))
        {
            configuration.ShowChangesDiscarded = showChangesDiscarded;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowChangesDiscardedHelpMarker);

        var showChangesLost = configuration.ShowChangesLost;
        if (ImGui.Checkbox(Languages.SystemTab_ShowChangesLost, ref showChangesLost))
        {
            configuration.ShowChangesLost = showChangesLost;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowChangesLostHelpMarker);

        var showTripleTriadAllowed = configuration.ShowTripleTriadAllowed;
        if (ImGui.Checkbox(Languages.SystemTab_ShowTripleTriadAllowed, ref showTripleTriadAllowed))
        {
            configuration.ShowTripleTriadAllowed = showTripleTriadAllowed;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowTripleTriadAllowedHelpMarker);

        var showTripleTriadNotAllowed = configuration.ShowTripleTriadNotAllowed;
        if (ImGui.Checkbox(Languages.SystemTab_ShowTripleTriadNotAllowed, ref showTripleTriadNotAllowed))
        {
            configuration.ShowTripleTriadNotAllowed = showTripleTriadNotAllowed;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowTripleTriadNotAllowedHelpMarker);
    }
}
