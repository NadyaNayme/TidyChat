using System;
using System.Linq;

namespace TidyChat
{
    public class FilterSystemMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (
                    (ChatStrings.PowerfulMark.All(input.Contains) && !configuration.HideSRankHunt) ||
                    (ChatStrings.CompletedVenture.All(input.Contains) && !configuration.HideCompletedVenture) ||
                    (ChatStrings.PlayerCommendation.All(input.Contains) && !configuration.HideCommendations && !configuration.BetterCommendationMessage) ||
                    (ChatRegexStrings.BetterPlayerCommendation.IsMatch(input) && configuration.BetterCommendationMessage) ||
                    (ChatStrings.InstancedArea.All(input.Contains) && !configuration.HideInstanceMessage) ||
                    (ChatStrings.SayQuestReminder.All(input.Contains) && !configuration.HideQuestReminder) ||
                    (ChatStrings.ReadyCheckComplete.All(input.Contains) && !configuration.HideReadyChecks) ||
                    (ChatStrings.SpideySenses.All(input.Contains) && !configuration.HideSpideySenses) ||
                    (ChatStrings.AetherCompass.All(input.Contains) && !configuration.HideAetherCompass) ||
                    (ChatStrings.CountdownTime.All(input.Contains) && !configuration.HideCountdownTime) ||
                    (ChatStrings.GlamoursProjected.All(input.Contains) && configuration.ShowGlamoursProjected) ||
                    (ChatStrings.TradeSent.All(input.Contains) && configuration.ShowTradeSent) ||
                    (ChatStrings.TradeCanceled.All(input.Contains) && configuration.ShowTradeCanceled) ||
                    (ChatStrings.AwaitingTradeConfirmation.All(input.Contains) && configuration.ShowAwaitingTradeConfirmation) ||
                    (ChatStrings.TradeComplete.All(input.Contains) && configuration.ShowTradeComplete) ||
                    (ChatStrings.OfferedTeleport.All(input.Contains) && configuration.ShowOfferedTeleport) ||
                    (ChatRegexStrings.GearsetEquipped.IsMatch(input) && configuration.ShowGearsetEquipped) ||
                    (ChatRegexStrings.MateriaRetrieved.IsMatch(input) && configuration.ShowMateriaRetrieved) ||
                    (ChatRegexStrings.MateriaShatters.IsMatch(input) && configuration.ShowMateriaShatters) ||
                    (ChatRegexStrings.VolumeControls.IsMatch(input) && configuration.ShowVolumeControlMessage) ||
                    (ChatRegexStrings.AetherialReductionSands.IsMatch(input) && configuration.ShowAetherialReductionSands) ||
                    (ChatRegexStrings.SealedOff.IsMatch(input) && configuration.ShowSealedOff) ||
                    (ChatRegexStrings.ItemSearchCommand.IsMatch(input)) ||
                    (ChatRegexStrings.SearchForItemResults.IsMatch(input) && !configuration.HideSearchForItemResults) ||
                    (ChatStrings.SayQuestReminder.All(input.Contains) && !configuration.HideQuestReminder && configuration.BetterSayReminder) ||
                    (ChatStrings.InviteSent.All(input.Contains) && configuration.ShowInviteSent) ||
                    (ChatStrings.InviteeJoins.All(input.Contains) && configuration.ShowInviteeJoins) ||
                    (ChatStrings.LeftParty.All(input.Contains) && configuration.ShowLeftParty) ||
                    (ChatStrings.YouLeaveParty.All(input.Contains) && configuration.ShowLeftParty) ||
                    (ChatStrings.PartyDisband.All(input.Contains) && configuration.ShowPartyDisband) ||
                    (ChatStrings.PartyDissolved.All(input.Contains) && configuration.ShowPartyDissolved) ||
                    (ChatStrings.InvitedBy.All(input.Contains) && configuration.ShowInvitedBy) ||
                    (ChatStrings.JoinParty.All(input.Contains) && configuration.ShowJoinParty) ||
                    (ChatStrings.JoinCrossParty.All(input.Contains) && configuration.ShowJoinParty) ||
                    (ChatStrings.RelicBookStep.All(input.Contains) && configuration.ShowRelicBookStep) ||
                    (ChatStrings.RelicBookComplete.All(input.Contains) && configuration.ShowRelicBookComplete)
                   )
                {
                    return false;
                }

                // We hit the end of our whitelist - block the message
                return true;
            }
            // If we somehow encounter an error - block the message
            catch (Exception)
            {
                return true;
            }
        }
    }
}
