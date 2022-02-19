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
                     !configuration.HideSRankHunt && Localization.Get(ChatStrings.PowerfulMark).All(input.Contains) ||
                     !configuration.HideSSRankHunt && ChatStrings.ExtraordinarilyPowerfulMark.All(input.Contains) ||
                     !configuration.HideCompletedVenture && Localization.Get(ChatStrings.CompletedVenture).All(input.Contains) ||
                     !configuration.HideCommendations && !configuration.BetterCommendationMessage && Localization.Get(ChatStrings.PlayerCommendation).All(input.Contains) ||
                     configuration.BetterCommendationMessage && Localization.Get(ChatRegexStrings.BetterPlayerCommendation).IsMatch(input) ||
                     !configuration.HideInstanceMessage && Localization.Get(ChatStrings.InstancedArea).All(input.Contains) ||
                     !configuration.HideQuestReminder && Localization.Get(ChatStrings.SayQuestReminder).All(input.Contains) ||
                     !configuration.HideReadyChecks && Localization.Get(ChatStrings.ReadyCheckComplete).All(input.Contains) ||
                     !configuration.HideSpideySenses && Localization.Get(ChatStrings.SpideySenses).All(input.Contains) ||
                     !configuration.HideAetherCompass && Localization.Get(ChatStrings.AetherCompass).All(input.Contains) ||
                     !configuration.HideCountdownTime && Localization.Get(ChatStrings.CountdownTime).All(input.Contains) ||
                     configuration.ShowGlamoursProjected && Localization.Get(ChatStrings.GlamoursProjected).All(input.Contains) ||
                     configuration.ShowTradeSent && Localization.Get(ChatStrings.TradeSent).All(input.Contains) ||
                     configuration.ShowTradeCanceled && Localization.Get(ChatStrings.TradeCanceled).All(input.Contains) ||
                     configuration.ShowAwaitingTradeConfirmation && Localization.Get(ChatStrings.AwaitingTradeConfirmation).All(input.Contains) ||
                     configuration.ShowTradeComplete && Localization.Get(ChatStrings.TradeComplete).All(input.Contains) ||
                     configuration.ShowOfferedTeleport && Localization.Get(ChatStrings.OfferedTeleport).All(input.Contains) ||
                     configuration.ShowGearsetEquipped && Localization.Get(ChatRegexStrings.GearsetEquipped).IsMatch(input) ||
                     configuration.ShowMateriaRetrieved && Localization.Get(ChatRegexStrings.MateriaRetrieved).IsMatch(input) ||
                     configuration.ShowMateriaShatters && Localization.Get(ChatRegexStrings.MateriaShatters).IsMatch(input) ||
                     configuration.ShowVolumeControlMessage && Localization.Get(ChatRegexStrings.VolumeControls).IsMatch(input) ||
                     configuration.ShowAetherialReductionSands && Localization.Get(ChatRegexStrings.AetherialReductionSands).IsMatch(input) ||
                     configuration.ShowSealedOff && Localization.Get(ChatRegexStrings.SealedOff).IsMatch(input) ||
                     !configuration.HideSearchForItemResults && Localization.Get(ChatRegexStrings.SearchForItemResults).IsMatch(input) ||
                     !configuration.HideQuestReminder && configuration.BetterSayReminder && Localization.Get(ChatStrings.SayQuestReminder).All(input.Contains) ||
                     configuration.ShowInviteSent && Localization.Get(ChatStrings.InviteSent).All(input.Contains) ||
                     configuration.ShowInviteeJoins && Localization.Get(ChatStrings.InviteeJoins).All(input.Contains) ||
                     configuration.ShowLeftParty && Localization.Get(ChatStrings.LeftParty).All(input.Contains) ||
                     configuration.ShowLeftParty && Localization.Get(ChatStrings.YouLeaveParty).All(input.Contains) ||
                     configuration.ShowPartyDisband && Localization.Get(ChatStrings.PartyDisband).All(input.Contains) ||
                     configuration.ShowPartyDissolved && Localization.Get(ChatStrings.PartyDissolved).All(input.Contains) ||
                     configuration.ShowInvitedBy && Localization.Get(ChatStrings.InvitedBy).All(input.Contains) ||
                     configuration.ShowJoinParty && Localization.Get(ChatStrings.JoinParty).All(input.Contains) ||
                     configuration.ShowJoinParty && Localization.Get(ChatStrings.JoinCrossParty).All(input.Contains) ||
                     configuration.ShowRelicBookStep && Localization.Get(ChatStrings.RelicBookStep).All(input.Contains) ||
                     configuration.ShowRelicBookComplete && Localization.Get(ChatStrings.RelicBookComplete).All(input.Contains) ||
                     // not optional so always run last
                     Localization.Get(ChatRegexStrings.ItemSearchCommand).IsMatch(input)
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
