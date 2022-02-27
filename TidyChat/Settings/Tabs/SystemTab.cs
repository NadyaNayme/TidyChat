using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class SystemTab
    {
        public static void Draw(Configuration configuration)
        {
            var filterSystemMessages = configuration.FilterSystemMessages;
            if (ImGui.Checkbox("Filter spammy system messages", ref filterSystemMessages))
            {
                configuration.FilterSystemMessages = filterSystemMessages;
                configuration.Save();
            }

            ImGui.Separator();
            ImGui.Spacing();

            if (ImGui.CollapsingHeader("\"Not Spam\" Filters"))
            {
                ImGui.TextUnformatted("Hide messages Tidy Chat does not consider to be spam.");

                var instanceMessage = configuration.HideInstanceMessage;
                if (ImGui.Checkbox("Hide /instance message", ref instanceMessage))
                {
                    configuration.HideInstanceMessage = instanceMessage;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You are now in the instanced area Old Sharlayan .\nCurrent instance can be confirmed at any time using the / instance text command.");


                var sRankHunt = configuration.HideSRankHunt;
                if (ImGui.Checkbox("Hide S Rank Hunt spawn announcement", ref sRankHunt))
                {
                    configuration.HideSRankHunt = sRankHunt;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You sense the presence of a powerful mark...");

                var ssRankHunt = configuration.HideSSRankHunt;
                if (ImGui.Checkbox("Hide SS Rank Minion announcements", ref ssRankHunt))
                {
                    configuration.HideSSRankHunt = ssRankHunt;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. The minions of an extraordinarily powerful mark are on the hunt for prey...\nThe minions of an extraordinarily powerful mark have withdrawn...");

                var commendations = configuration.HideCommendations;
                if (ImGui.Checkbox("Hide Received Commendations", ref commendations))
                {
                    configuration.HideCommendations = commendations;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You received a player commendation!");

                var completedVenture = configuration.HideCompletedVenture;
                if (ImGui.Checkbox("Hide Completed Venture", ref completedVenture))
                {
                    configuration.HideCompletedVenture = completedVenture;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. RetainerName has completed a venture!");

                var hideQuestReminder = configuration.HideQuestReminder;
                if (ImGui.Checkbox("Hide reminders of what to /say in chat during quests.", ref hideQuestReminder))
                {
                    configuration.HideQuestReminder = hideQuestReminder;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. With the chat mode in Say, enter a phrase containing “Tataru” at the destination point.");

                var hideSpideySenses = configuration.HideSpideySenses;
                if (ImGui.Checkbox("Hide \"You sense something...\" messages", ref hideSpideySenses))
                {
                    configuration.HideSpideySenses = hideSpideySenses;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You sense something to the far, far southwest...");

                var hideAetherCompass = configuration.HideAetherCompass;
                if (ImGui.Checkbox("Hide Aether Compass message", ref hideAetherCompass))
                {
                    configuration.HideAetherCompass = hideAetherCompass;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. The compass detects a current approximately 143 yalms to the West...");

                var hideCountdownTime = configuration.HideCountdownTime;
                if (ImGui.Checkbox("Hide /countdown message", ref hideCountdownTime))
                {
                    configuration.HideCountdownTime = hideCountdownTime;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. Battle commencing in 18 seconds!");

                var hideReadyChecks = configuration.HideReadyChecks;
                if (ImGui.Checkbox("Hide /readycheck message", ref hideReadyChecks))
                {
                    configuration.HideReadyChecks = hideReadyChecks;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. Ready check complete.");

                var hideSearchForItemResults = configuration.HideSearchForItemResults;
                if (ImGui.Checkbox("Hide \"Search for items\" results message", ref hideSearchForItemResults))
                {
                    configuration.HideSearchForItemResults = hideSearchForItemResults;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. 1 item found in the 4th tab of your inventory.");
            }

            ImGui.Spacing();

            if (ImGui.CollapsingHeader("\"Spam\" Filters"))
            {
                ImGui.TextUnformatted("Show messages Tidy Chat considers to be spam");

                var showOnlineStatus = configuration.ShowOnlineStatus;
                if (ImGui.Checkbox("Show online status updates", ref showOnlineStatus))
                {
                    configuration.ShowOnlineStatus = showOnlineStatus;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. Updating online status to Away from Keyboard.");

                var showAttachToMail = configuration.ShowAttachToMail;
                if (ImGui.Checkbox("Show items attached to sent mail", ref showAttachToMail))
                {
                    configuration.ShowAttachToMail = showAttachToMail;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You attach 2 pots of Dalamud Red Dye to the letter.");

                var showRelicBookStep = configuration.ShowRelicBookStep;
                if (ImGui.Checkbox("Show ARR Relic book step progress messages", ref showRelicBookStep))
                {
                    configuration.ShowRelicBookStep = showRelicBookStep;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. Record of Ouranos kill (1/1) added for <Relic Weapon> - Strength +2.");

                var showRelicBookComplete = configuration.ShowRelicBookComplete;
                if (ImGui.Checkbox("Show ARR Relic book step completed messages", ref showRelicBookComplete))
                {
                    configuration.ShowRelicBookComplete = showRelicBookComplete;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. All objectives under the category Dungeons for <Relic Weapon> - Strength +2 complete!");

                var showHuntSlain = configuration.ShowHuntSlain;
                if (ImGui.Checkbox("Show hunt mark slain messages", ref showHuntSlain))
                {
                    configuration.ShowHuntSlain = showHuntSlain;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. Hunt mark <mark> slain! 1/3");

                var showCompletionTime = configuration.ShowCompletionTime;
                if (ImGui.Checkbox("Show completion time when unrestricted party is active", ref showCompletionTime))
                {
                    configuration.ShowCompletionTime = showCompletionTime;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. <Duty> completion time: 00:30");

                var showVolumeControlMessage = configuration.ShowVolumeControlMessage;
                if (ImGui.Checkbox("Show volume control messages", ref showVolumeControlMessage))
                {
                    configuration.ShowVolumeControlMessage = showVolumeControlMessage;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. Master Volume muted, BGM volume set to 50.");

                var showGlamoursProjected = configuration.ShowGlamoursProjected;
                if (ImGui.Checkbox("Show message when changing glamour plates", ref showGlamoursProjected))
                {
                    configuration.ShowGlamoursProjected = showGlamoursProjected;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("\neg. Glamours projected from plate 10.");

                var showGearsetEquipped = configuration.ShowGearsetEquipped;
                if (ImGui.Checkbox("Show message when changing gearsets", ref showGearsetEquipped))
                {
                    configuration.ShowGearsetEquipped = showGearsetEquipped;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("\neg. “RDM (530)” equipped.");
            }

            ImGui.Spacing();

            if (ImGui.CollapsingHeader("Party & Invite Messages"))
            {
                var showInviteSent = configuration.ShowInviteSent;
                if (ImGui.Checkbox("Show sent party invites", ref showInviteSent))
                {
                    configuration.ShowInviteSent = showInviteSent;
                    configuration.Save();
                }

                var showInviteeJoins = configuration.ShowInviteeJoins;
                if (ImGui.Checkbox("Show players joining party", ref showInviteeJoins))
                {
                    configuration.ShowInviteeJoins = showInviteeJoins;
                    configuration.Save();
                }

                var showLeftParty = configuration.ShowLeftParty;
                if (ImGui.Checkbox("Show players leaving party", ref showLeftParty))
                {
                    configuration.ShowLeftParty = showLeftParty;
                    configuration.Save();
                }

                var showPartyDisband = configuration.ShowPartyDisband;
                if (ImGui.Checkbox("Show party disbands and dissolves", ref showPartyDisband))
                {
                    configuration.ShowPartyDisband = showPartyDisband;
                    configuration.ShowPartyDissolved = showPartyDisband;
                    configuration.Save();
                }

                var showInvitedBy = configuration.ShowInvitedBy;
                if (ImGui.Checkbox("Show received party invitations", ref showInvitedBy))
                {
                    configuration.ShowInvitedBy = showInvitedBy;
                    configuration.Save();
                }

                var showJoinParty = configuration.ShowJoinParty;
                if (ImGui.Checkbox("Show joined party/cross-party message", ref showJoinParty))
                {
                    configuration.ShowJoinParty = showJoinParty;
                    configuration.Save();
                }

                var showOfferedTeleport = configuration.ShowOfferedTeleport;
                if (ImGui.Checkbox("Show teleport offers from party members", ref showOfferedTeleport))
                {
                    configuration.ShowOfferedTeleport = showOfferedTeleport;
                    configuration.Save();
                }
            }

            ImGui.Spacing();

            if (ImGui.CollapsingHeader("Trading Messages"))
            {
                var showTradeSent = configuration.ShowTradeSent;
                if (ImGui.Checkbox("Show \"Trade request sent to\" message", ref showTradeSent))
                {
                    configuration.ShowTradeSent = showTradeSent;
                    configuration.Save();
                }

                var showTradeCanceled = configuration.ShowTradeCanceled;
                if (ImGui.Checkbox("Show \"Trade canceled.\" message", ref showTradeCanceled))
                {
                    configuration.ShowTradeCanceled = showTradeCanceled;
                    configuration.Save();
                }

                var showAwaitingTradeConfirmation = configuration.ShowAwaitingTradeConfirmation;
                if (ImGui.Checkbox("Show \"Awaiting trade confirmation\" message", ref showAwaitingTradeConfirmation))
                {
                    configuration.ShowAwaitingTradeConfirmation = showAwaitingTradeConfirmation;
                    configuration.Save();
                }

                var showTradeComplete = configuration.ShowTradeComplete;
                if (ImGui.Checkbox("Show \"Trade complete.\" message", ref showTradeComplete))
                {
                    configuration.ShowTradeComplete = showTradeComplete;
                    configuration.Save();
                }
            }
            ImGui.EndTabItem();
        }
    }
}
