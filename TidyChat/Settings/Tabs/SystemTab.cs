using System;
using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
using TidyChat.Settings;
namespace TidyChat.Settings.Tabs;

internal static class SystemTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.SystemTab_ServerAnnouncementsDropdownHeader,
                ImGuiTreeNodeFlags.DefaultOpen))
        {
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

            bool housingWardMessage = configuration.ShowHousingWardMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowHousingWardMessage, ref housingWardMessage))
            {
                configuration.ShowHousingWardMessage = housingWardMessage;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowHousingWardMessageHelpMarker);
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

        if (ImGui.CollapsingHeader(Languages.SystemTab_RelicAndMailDropdownHeader))
        {
            bool showAttachToMail = configuration.ShowAttachToMail;
            if (ImGui.Checkbox(Languages.SystemTab_ShowMailAttachmentMessages, ref showAttachToMail))
            {
                configuration.ShowAttachToMail = showAttachToMail;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowMailAttachmentMessagesHelpMarker);

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
}
