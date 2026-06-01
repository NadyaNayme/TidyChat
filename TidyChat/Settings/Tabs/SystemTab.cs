using System;
using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
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
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_HuntMessagesDropdownHeader))
        {
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

            bool showHuntSlain = configuration.ShowHuntSlain;
            if (ImGui.Checkbox(Languages.SystemTab_ShowHuntMarkSlainMessages, ref showHuntSlain))
            {
                configuration.ShowHuntSlain = showHuntSlain;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowHuntMarkSlainMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_ExplorationDropdownHeader))
        {
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

            bool showVistaMessages = configuration.ShowVistaMessages;
            if (ImGui.Checkbox(Languages.SystemTab_HideVistaMessages, ref showVistaMessages))
            {
                configuration.ShowVistaMessages = showVistaMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideVistaMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_GlamourAndGearDropdownHeader))
        {
            bool showTryOnGlamour = configuration.ShowTryOnGlamour;
            if (ImGui.Checkbox(Languages.SystemTab_HideTryOnGlamourMessages, ref showTryOnGlamour))
            {
                configuration.ShowTryOnGlamour = showTryOnGlamour;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideTryOnGlamourMessagesHelpMarker);

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
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_SocialAndMiscDropdownHeader))
        {
            bool commendations = configuration.ShowCommendations;
            if (ImGui.Checkbox(Languages.SystemTab_HideReceivedCommendations, ref commendations))
            {
                configuration.ShowCommendations = commendations;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideReceivedCommendationsHelpMarker);

            bool showPersonalMessageBook = configuration.ShowPersonalMessageBook;
            if (ImGui.Checkbox(Languages.SystemTab_HidePersonalMessageBookMessages, ref showPersonalMessageBook))
            {
                configuration.ShowPersonalMessageBook = showPersonalMessageBook;
                configuration.OnSettingChanged();
            }

            bool showAetheryteTicket = configuration.ShowAetheryteTicket;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAetheryteTicketMessage, ref showAetheryteTicket))
            {
                configuration.ShowAetheryteTicket = showAetheryteTicket;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowAetheryteTicketMessageHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_CharacterAndGearDropdownHeader))
        {
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
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_RelicAndMailDropdownHeader))
        {
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
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_SocialStatusDropdownHeader))
        {
            bool showOnlineStatus = configuration.ShowOnlineStatus;
            if (ImGui.Checkbox(Languages.SystemTab_ShowOnlineStatusMessages, ref showOnlineStatus))
            {
                configuration.ShowOnlineStatus = showOnlineStatus;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowOnlineStatusMessagesHelpMarker);

            bool showSearchForItemResults = configuration.ShowSearchForItemResults;
            if (ImGui.Checkbox(Languages.SystemTab_HideItemSearchResultsMessage, ref showSearchForItemResults))
            {
                configuration.ShowSearchForItemResults = showSearchForItemResults;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideItemSearchResultsMessageHelpMarker);
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
            if (ImGui.Checkbox(Languages.SystemTab_HideOrchestrionPlaying, ref hideOrchestrionPlaying))
            {
                configuration.HideOrchestrionPlaying = hideOrchestrionPlaying;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_HideOrchestrionPlayingHelpMarker);

            bool showVolumeControlMessage = configuration.ShowVolumeControlMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowVolumeControlMessages, ref showVolumeControlMessage))
            {
                configuration.ShowVolumeControlMessage = showVolumeControlMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowVolumeControlMessagesHelpMarker);
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
    }
}
