using System;
using System.Linq;
using Dalamud.Logging;

namespace TidyChat;

public static class FilterSystemMessages
{
    public static bool IsFiltered(string input, Configuration configuration)
    {
        try
        {
            if (
                (!configuration.HideSRankHunt && L10N.Get(ChatStrings.PowerfulMark).All(input.Contains)) ||
                (!configuration.HideSSRankHunt &&
                 L10N.Get(ChatStrings.ExtraordinarilyPowerfulMark).All(input.Contains)) ||
                (!configuration.HideCompletedVenture && L10N.Get(ChatStrings.CompletedVenture).All(input.Contains)) ||
                (!configuration.HideCommendations && !configuration.BetterCommendationMessage &&
                 L10N.Get(ChatStrings.PlayerCommendation).All(input.Contains)) ||
                (!configuration.HideInstanceMessage && L10N.Get(ChatStrings.InstancedArea).All(input.Contains)) ||
                (!configuration.HideQuestReminder && L10N.Get(ChatStrings.SayQuestReminder).All(input.Contains)) ||
                (!configuration.HideReadyChecks && L10N.Get(ChatStrings.ReadyCheckComplete).All(input.Contains)) ||
                (!configuration.HideSpideySenses && L10N.Get(ChatRegexStrings.SpideySenses).IsMatch(input) &&
                 !L10N.Get(ChatStrings.UnsettlingPresence).All(input.Contains)) ||
                (!configuration.HideAetherCompass && L10N.Get(ChatStrings.AetherCompass).All(input.Contains)) ||
                (!configuration.HideCountdownTime && (L10N.Get(ChatStrings.CountdownTime).All(input.Contains) ||
                                                      L10N.Get(ChatStrings.CountdownEngage).All(input.Contains))) ||
                (!configuration.HideSpiritboundGear && L10N.Get(ChatRegexStrings.CompleteSpiritbond).IsMatch(input)) ||
                (!configuration.HideExploratoryVoyage && L10N.Get(ChatRegexStrings.ExploratoryVoyage).IsMatch(input)) ||
                (!configuration.HideSubaquaticVoyage && L10N.Get(ChatRegexStrings.SubaquaticVoyage).IsMatch(input)) ||
                (!configuration.HideVistaMessages && L10N.Get(ChatRegexStrings.VistaMessages).IsMatch(input)) ||
                (!configuration.HideTryOnGlamour && L10N.Get(ChatRegexStrings.TryOnGlamour).IsMatch(input)) ||
                (!configuration.HideEligibleForCoffers &&
                 L10N.Get(ChatRegexStrings.EligibleForCoffers).IsMatch(input)) ||
                (!configuration.HideFreeCompanyMessageBook &&
                 L10N.Get(ChatRegexStrings.FreeCompanyMessageBook).IsMatch(input)) ||
                (!configuration.HidePersonalMessageBook &&
                 L10N.Get(ChatRegexStrings.PersonalEstateMessageBook).IsMatch(input)) ||
                (configuration.BetterCommendationMessage &&
                 L10N.Get(ChatRegexStrings.BetterPlayerCommendation).IsMatch(input)) ||
                (configuration.ShowGlamoursProjected && L10N.Get(ChatStrings.GlamoursProjected).All(input.Contains)) ||
                (configuration.ShowTradeSent && L10N.Get(ChatStrings.TradeSent).All(input.Contains)) ||
                (configuration.ShowTradeCanceled && L10N.Get(ChatStrings.TradeCanceled).All(input.Contains)) ||
                (configuration.ShowAwaitingTradeConfirmation &&
                 L10N.Get(ChatStrings.AwaitingTradeConfirmation).All(input.Contains)) ||
                (configuration.ShowNowLeaderOf && L10N.Get(ChatRegexStrings.NowLeaderOf).IsMatch(input)) ||
                (configuration.ShowFirstClearAward && L10N.Get(ChatRegexStrings.FirstClearAward).IsMatch(input) &&
                 L10N.Get(ChatRegexStrings.PartyMemberFirstClear).IsMatch(input)) ||
                (configuration.ShowSecondChanceAward && L10N.Get(ChatRegexStrings.SecondChanceAward).IsMatch(input) &&
                 L10N.Get(ChatRegexStrings.PartyMemberFirstClear).IsMatch(input)) ||
                (configuration.ShowTradeComplete && L10N.Get(ChatStrings.TradeComplete).All(input.Contains)) ||
                (configuration.ShowOfferedTeleport && L10N.Get(ChatStrings.OfferedTeleport).All(input.Contains)) ||
                (configuration.ShowGearsetEquipped && L10N.Get(ChatRegexStrings.GearsetEquipped).IsMatch(input)) ||
                (configuration.ShowMateriaRetrieved && L10N.Get(ChatRegexStrings.MateriaRetrieved).IsMatch(input)) ||
                (configuration.ShowMateriaShatters && L10N.Get(ChatRegexStrings.MateriaShatters).IsMatch(input)) ||
                (configuration.ShowVolumeControlMessage && L10N.Get(ChatRegexStrings.VolumeControls).IsMatch(input)) ||
                (configuration.ShowAetherialReductionSands &&
                 L10N.Get(ChatRegexStrings.AetherialReductionSands).IsMatch(input)) ||
                (configuration.ShowSealedOff && L10N.Get(ChatRegexStrings.SealedOff).IsMatch(input)) ||
                (!configuration.HideSearchForItemResults &&
                 L10N.Get(ChatRegexStrings.SearchForItemResults).IsMatch(input)) ||
                (!configuration.HideQuestReminder && configuration.BetterSayReminder &&
                 L10N.Get(ChatStrings.SayQuestReminder).All(input.Contains)) ||
                (configuration.ShowInviteSent && L10N.Get(ChatStrings.InviteSent).All(input.Contains)) ||
                (configuration.ShowInviteeJoins && L10N.Get(ChatStrings.InviteeJoins).All(input.Contains)) ||
                (configuration.ShowLeftParty && L10N.Get(ChatStrings.LeftParty).All(input.Contains)) ||
                (configuration.ShowLeftParty && L10N.Get(ChatStrings.YouLeaveParty).All(input.Contains)) ||
                (configuration.ShowPartyDisband && L10N.Get(ChatStrings.PartyDisband).All(input.Contains)) ||
                (configuration.ShowPartyDissolved && L10N.Get(ChatStrings.PartyDissolved).All(input.Contains)) ||
                (configuration.ShowInvitedBy && L10N.Get(ChatStrings.InvitedBy).All(input.Contains)) ||
                (configuration.ShowJoinParty && L10N.Get(ChatStrings.JoinParty).All(input.Contains)) ||
                (configuration.ShowJoinParty && L10N.Get(ChatStrings.JoinCrossParty).All(input.Contains)) ||
                (configuration.ShowHuntSlain && L10N.Get(ChatStrings.HuntSlain).All(input.Contains)) ||
                (configuration.ShowRelicBookStep && L10N.Get(ChatStrings.RelicBookStep).All(input.Contains)) ||
                (configuration.ShowRelicBookComplete && L10N.Get(ChatStrings.RelicBookComplete).All(input.Contains)) ||
                (configuration.ShowDesynthedItem && L10N.Get(ChatRegexStrings.YouDesynth).IsMatch(input)) ||
                (configuration.ShowDesynthesisObtains && L10N.Get(ChatRegexStrings.YouObtainSystem).IsMatch(input)) ||
                (configuration.ShowOnlineStatus && L10N.Get(ChatStrings.OnlineStatus).All(input.Contains)) ||
                (configuration.ShowAttachToMail && L10N.Get(ChatStrings.AttachToMail).All(input.Contains)) ||
                (configuration.ShowDiscoveredFishingHole &&
                 L10N.Get(ChatRegexStrings.DiscoveredFishingHole).IsMatch(input)) ||
                // POTD & HoH filters
                (configuration.ShowObtainedPomander && L10N.Get(ChatRegexStrings.ObtainedPomander).IsMatch(input)) ||
                (configuration.ShowReturnedPomander && L10N.Get(ChatRegexStrings.ReturnedPomander).IsMatch(input)) ||
                (configuration.ShowCairnGlows && L10N.Get(ChatRegexStrings.CairnGlows).IsMatch(input)) ||
                (configuration.ShowRestoresLifeToFallen &&
                 L10N.Get(ChatRegexStrings.RestoresLifeToFallen).IsMatch(input)) ||
                (configuration.ShowCairnActivates && L10N.Get(ChatRegexStrings.CairnActivates).IsMatch(input)) ||
                (configuration.ShowTransference && L10N.Get(ChatRegexStrings.Transference).IsMatch(input)) ||
                (configuration.ShowAetherpoolIncrease &&
                 L10N.Get(ChatRegexStrings.AetherpoolIncrease).IsMatch(input)) ||
                (configuration.ShowAetherpoolUnchanged &&
                 L10N.Get(ChatRegexStrings.AetherpoolUnchanged).IsMatch(input)) ||
                (configuration.ShowPomanderOfSafety && L10N.Get(ChatRegexStrings.PomanderOfSafety).IsMatch(input)) ||
                (configuration.ShowPomanderOfSight && L10N.Get(ChatRegexStrings.PomanderOfSight).IsMatch(input)) ||
                (configuration.ShowPomanderOfAffluence &&
                 L10N.Get(ChatRegexStrings.PomanderOfAffluence).IsMatch(input)) ||
                (configuration.ShowPomanderOfFlight && L10N.Get(ChatRegexStrings.PomanderOfFlight).IsMatch(input)) ||
                (configuration.ShowPomanderOfAlteration &&
                 L10N.Get(ChatRegexStrings.PomanderOfAlteration).IsMatch(input)) ||
                (configuration.ShowPomanderOfWitching &&
                 L10N.Get(ChatRegexStrings.PomanderOfWitching).IsMatch(input)) ||
                (configuration.ShowPomanderOfSerenity &&
                 L10N.Get(ChatRegexStrings.PomanderOfSerenity).IsMatch(input)) ||
                (configuration.ShowFloorNumber && L10N.Get(ChatRegexStrings.FloorNumber).IsMatch(input)) ||
                (configuration.ShowSenseAccursedHoard &&
                 L10N.Get(ChatRegexStrings.SenseAccursedHoard).IsMatch(input)) ||
                (configuration.ShowDoNotSenseAccursedHoard &&
                 L10N.Get(ChatRegexStrings.DoNotSenseAccursedHoard).IsMatch(input)) ||
                (configuration.ShowDiscoverAccursedHoard &&
                 L10N.Get(ChatRegexStrings.DiscoverAccursedHoard).IsMatch(input)) ||
                // not optional so always run last
                L10N.Get(ChatRegexStrings.ItemSearchCommand).IsMatch(input) ||
                L10N.Get(ChatStrings.Playtime).All(input.Contains)
            )
                return false;
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