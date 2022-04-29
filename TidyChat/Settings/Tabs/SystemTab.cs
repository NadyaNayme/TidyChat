using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class SystemTab
    {
        public static void Draw(Configuration configuration)
        {
            var enableInverseMode = configuration.EnableInverseMode;
            if (ImGui.Checkbox("Experimental Feature: Inverse mode", ref enableInverseMode))
            {
                configuration.EnableInverseMode = enableInverseMode;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker($"No longer blocks System messages by default.\nHide filters become Show filters and Show filters become Hide filters.");

            if (configuration.EnableInverseMode)
            {
                ImGui.TextUnformatted("If you have enabled Inverse mode you are on your own and will not receive any support.\nIt is assumed you know what you are doing.");
            }
            if (ImGui.CollapsingHeader("Hide System messages Tidy Chat shows by default"))
            {
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
                if (ImGui.Checkbox("Hide /countdown messages", ref hideCountdownTime))
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

                var hideExploratoryVoyage = configuration.HideExploratoryVoyage;
                if (ImGui.Checkbox("Hide Airship voyage messages", ref hideExploratoryVoyage))
                {
                    configuration.HideExploratoryVoyage = hideExploratoryVoyage;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. A new exploratory voyage destination...has been discovered!");

                var hideSubaquaticVoyage = configuration.HideSubaquaticVoyage;
                if (ImGui.Checkbox("Hide Submarine voyage messages", ref hideSubaquaticVoyage))
                {
                    configuration.HideSubaquaticVoyage = hideSubaquaticVoyage;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. A new subaquatic voyage destination...has been discovered!");

                var hideVistaMessages = configuration.HideVistaMessages;
                if (ImGui.Checkbox("Hide vista arrival and stray messages", ref hideVistaMessages))
                {
                    configuration.HideVistaMessages = hideVistaMessages;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You have arrived at a vista! and You have strayed too far from the vista.");

            }

            if (ImGui.CollapsingHeader("Show System messages Tidy Chat hides by default"))
            {
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

            if (ImGui.CollapsingHeader("POTD & HoH"))
            {

                var showObtainedPomander = configuration.ShowObtainedPomander;
                if (ImGui.Checkbox("Show when the party obtains a pomander", ref showObtainedPomander))
                {
                    configuration.ShowObtainedPomander = showObtainedPomander;
                    configuration.Save();
                }

                var showReturnedPomander = configuration.ShowReturnedPomander;
                if (ImGui.Checkbox("Show when you return a pomander to the coffer", ref showReturnedPomander))
                {
                    configuration.ShowReturnedPomander = showReturnedPomander;
                    configuration.Save();
                }

                var showCairnGlows = configuration.ShowCairnGlows;
                if (ImGui.Checkbox("Show when the Cairn of Passage begins to glow", ref showCairnGlows))
                {
                    configuration.ShowCairnGlows = showCairnGlows;
                    configuration.Save();
                }

                var showRestoresLifeToFallen = configuration.ShowRestoresLifeToFallen;
                if (ImGui.Checkbox("Show when Cairn of Return is used", ref showRestoresLifeToFallen))
                {
                    configuration.ShowRestoresLifeToFallen = showRestoresLifeToFallen;
                    configuration.Save();
                }

                var showCairnActivates = configuration.ShowCairnActivates;
                if (ImGui.Checkbox("Show when the Cairn of Passage is activated", ref showCairnActivates))
                {
                    configuration.ShowCairnActivates = showCairnActivates;
                    configuration.Save();
                }

                var showTransference = configuration.ShowTransference;
                if (ImGui.Checkbox("Show transference messages", ref showTransference))
                {
                    configuration.ShowTransference = showTransference;
                    configuration.Save();
                }

                var showAetherpoolIncrease = configuration.ShowAetherpoolIncrease;
                if (ImGui.Checkbox("Show Aetherpool increases", ref showAetherpoolIncrease))
                {
                    configuration.ShowAetherpoolIncrease = showAetherpoolIncrease;
                    configuration.Save();
                }

                var showAetherpoolUnchanged = configuration.ShowAetherpoolUnchanged;
                if (ImGui.Checkbox("Show Aetherpool remains unchanged...", ref showAetherpoolUnchanged))
                {
                    configuration.ShowAetherpoolUnchanged = showAetherpoolUnchanged;
                    configuration.Save();
                }

                var showPomanderOfSafety = configuration.ShowPomanderOfSafety;
                if (ImGui.Checkbox("Show when Pomander of Safety is used", ref showPomanderOfSafety))
                {
                    configuration.ShowPomanderOfSafety = showPomanderOfSafety;
                    configuration.Save();
                }

                var showPomanderOfSight = configuration.ShowPomanderOfSight;
                if (ImGui.Checkbox("Show when Pomander of Sight is used", ref showPomanderOfSight))
                {
                    configuration.ShowPomanderOfSight = showPomanderOfSight;
                    configuration.Save();
                }

                var showPomanderOfAffluence = configuration.ShowPomanderOfAffluence;
                if (ImGui.Checkbox("Show when Pomander of Affluence is used", ref showPomanderOfAffluence))
                {
                    configuration.ShowPomanderOfAffluence = showPomanderOfAffluence;
                    configuration.Save();
                }

                var showPomanderOfFlight = configuration.ShowPomanderOfFlight;
                if (ImGui.Checkbox("Show when Pomander of Flight is used", ref showPomanderOfFlight))
                {
                    configuration.ShowPomanderOfFlight = showPomanderOfFlight;
                    configuration.Save();
                }

                var showPomanderOfAlteration = configuration.ShowPomanderOfAlteration;
                if (ImGui.Checkbox("Show when Pomander of Alteration is used", ref showPomanderOfAlteration))
                {
                    configuration.ShowPomanderOfAlteration = showPomanderOfAlteration;
                    configuration.Save();
                }

                var showPomanderOfWitching = configuration.ShowPomanderOfWitching;
                if (ImGui.Checkbox("Show when Pomander of Witching is used", ref showPomanderOfWitching))
                {
                    configuration.ShowPomanderOfWitching = showPomanderOfWitching;
                    configuration.Save();
                }

                var showPomanderOfSerenity = configuration.ShowPomanderOfSerenity;
                if (ImGui.Checkbox("Show when Pomander of Serenity is used", ref showPomanderOfSerenity))
                {
                    configuration.ShowPomanderOfSerenity = showPomanderOfSerenity;
                    configuration.Save();
                }

                var showFloorNumber = configuration.ShowFloorNumber;
                if (ImGui.Checkbox("Show floor number when entering a new floor", ref showFloorNumber))
                {
                    configuration.ShowFloorNumber = showFloorNumber;
                    configuration.Save();
                }

                var showSenseAccursedHoard = configuration.ShowSenseAccursedHoard;
                if (ImGui.Checkbox("Show when Accursed Hoard is sensed", ref showSenseAccursedHoard))
                {
                    configuration.ShowSenseAccursedHoard = showSenseAccursedHoard;
                    configuration.Save();
                }

                var showDoNotSenseAccursedHoard = configuration.ShowDoNotSenseAccursedHoard;
                if (ImGui.Checkbox("Show when Accursed Hoard is not sensed on the current floor", ref showDoNotSenseAccursedHoard))
                {
                    configuration.ShowDoNotSenseAccursedHoard = showDoNotSenseAccursedHoard;
                    configuration.Save();
                }

                var showDiscoverAccursedHoard = configuration.ShowDiscoverAccursedHoard;
                if (ImGui.Checkbox("Show when Accursed Hoard is discovered", ref showDiscoverAccursedHoard))
                {
                    configuration.ShowDiscoverAccursedHoard = showDiscoverAccursedHoard;
                    configuration.Save();
                }

            }

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
