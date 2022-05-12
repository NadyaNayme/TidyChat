using Dalamud.Logging;
using System;
using System.Linq;

namespace TidyChat
{
    public static class FilterSystemMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (
                    !configuration.HideSRankHunt && Localization.Get(ChatStrings.PowerfulMark).All(input.Contains) ||
                    !configuration.HideSSRankHunt && Localization.Get(ChatStrings.ExtraordinarilyPowerfulMark).All(input.Contains) ||
                    !configuration.HideCompletedVenture && Localization.Get(ChatStrings.CompletedVenture).All(input.Contains) ||
                    !configuration.HideCommendations && !configuration.BetterCommendationMessage && Localization.Get(ChatStrings.PlayerCommendation).All(input.Contains) ||
                    !configuration.HideInstanceMessage && Localization.Get(ChatStrings.InstancedArea).All(input.Contains) ||
                    !configuration.HideQuestReminder && Localization.Get(ChatStrings.SayQuestReminder).All(input.Contains) ||
                    !configuration.HideReadyChecks && Localization.Get(ChatStrings.ReadyCheckComplete).All(input.Contains) ||
                    !configuration.HideSpideySenses && Localization.Get(ChatStrings.SpideySenses).All(input.Contains) && !Localization.Get(ChatStrings.UnsettlingPresence).All(input.Contains) ||
                    !configuration.HideAetherCompass && Localization.Get(ChatStrings.AetherCompass).All(input.Contains) ||
                    !configuration.HideCountdownTime && (Localization.Get(ChatStrings.CountdownTime).All(input.Contains) || Localization.Get(ChatStrings.CountdownEngage).All(input.Contains)) ||
                    !configuration.HideExploratoryVoyage && Localization.Get(ChatRegexStrings.ExploratoryVoyage).IsMatch(input) ||
                    !configuration.HideSubaquaticVoyage && Localization.Get(ChatRegexStrings.SubaquaticVoyage).IsMatch(input) ||
                    !configuration.HideVistaMessages && Localization.Get(ChatRegexStrings.VistaMessages).IsMatch(input) ||
                    !configuration.HideTryOnGlamour && Localization.Get(ChatRegexStrings.TryOnGlamour).IsMatch(input) ||
                    configuration.BetterCommendationMessage && Localization.Get(ChatRegexStrings.BetterPlayerCommendation).IsMatch(input) ||
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
                    configuration.ShowHuntSlain && Localization.Get(ChatStrings.HuntSlain).All(input.Contains) ||
                    configuration.ShowRelicBookStep && Localization.Get(ChatStrings.RelicBookStep).All(input.Contains) ||
                    configuration.ShowRelicBookComplete && Localization.Get(ChatStrings.RelicBookComplete).All(input.Contains) ||
                    configuration.ShowDesynthesisObtains && Localization.Get(ChatRegexStrings.YouObtainSystem).IsMatch(input) ||
                    configuration.ShowOnlineStatus && Localization.Get(ChatStrings.OnlineStatus).All(input.Contains) ||
                    configuration.ShowAttachToMail && Localization.Get(ChatStrings.AttachToMail).All(input.Contains) ||
                    // POTD & HoH filters
                    configuration.ShowObtainedPomander && Localization.Get(ChatRegexStrings.ObtainedPomander).IsMatch(input) ||
                    configuration.ShowReturnedPomander && Localization.Get(ChatRegexStrings.ReturnedPomander).IsMatch(input) ||
                    configuration.ShowCairnGlows && Localization.Get(ChatRegexStrings.CairnGlows).IsMatch(input) ||
                    configuration.ShowRestoresLifeToFallen && Localization.Get(ChatRegexStrings.RestoresLifeToFallen).IsMatch(input) ||
                    configuration.ShowCairnActivates && Localization.Get(ChatRegexStrings.CairnActivates).IsMatch(input) ||
                    configuration.ShowTransference && Localization.Get(ChatRegexStrings.Transference).IsMatch(input) ||
                    configuration.ShowAetherpoolIncrease && Localization.Get(ChatRegexStrings.AetherpoolIncrease).IsMatch(input) ||
                    configuration.ShowAetherpoolUnchanged && Localization.Get(ChatRegexStrings.AetherpoolUnchanged).IsMatch(input) ||
                    configuration.ShowPomanderOfSafety && Localization.Get(ChatRegexStrings.PomanderOfSafety).IsMatch(input) ||
                    configuration.ShowPomanderOfSight && Localization.Get(ChatRegexStrings.PomanderOfSight).IsMatch(input) ||
                    configuration.ShowPomanderOfAffluence && Localization.Get(ChatRegexStrings.PomanderOfAffluence).IsMatch(input) ||
                    configuration.ShowPomanderOfFlight && Localization.Get(ChatRegexStrings.PomanderOfFlight).IsMatch(input) ||
                    configuration.ShowPomanderOfAlteration && Localization.Get(ChatRegexStrings.PomanderOfAlteration).IsMatch(input) ||
                    configuration.ShowPomanderOfWitching && Localization.Get(ChatRegexStrings.PomanderOfWitching).IsMatch(input) ||
                    configuration.ShowPomanderOfSerenity && Localization.Get(ChatRegexStrings.PomanderOfSerenity).IsMatch(input) ||
                    configuration.ShowFloorNumber && Localization.Get(ChatRegexStrings.FloorNumber).IsMatch(input) ||
                    configuration.ShowSenseAccursedHoard && Localization.Get(ChatRegexStrings.SenseAccursedHoard).IsMatch(input) ||
                    configuration.ShowDoNotSenseAccursedHoard && Localization.Get(ChatRegexStrings.DoNotSenseAccursedHoard).IsMatch(input) ||
                    configuration.ShowDiscoverAccursedHoard && Localization.Get(ChatRegexStrings.DiscoverAccursedHoard).IsMatch(input) ||
                    // not optional so always run last
                    Localization.Get(ChatRegexStrings.ItemSearchCommand).IsMatch(input) ||
                    Localization.Get(ChatStrings.Playtime).All(input.Contains)
                )
                {
                    return false;
                }
                // We hit the end of our whitelist - block the message
                return true;
            }
            // If we somehow encounter an error - block the message
            catch (Exception e)
            {
                PluginLog.LogDebug("Encountered error: " + e);
                return true;
            }
        }
    }
}
