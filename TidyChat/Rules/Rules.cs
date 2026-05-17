using System;
using System.Collections.Generic;
using ChatTwo.Code;
using TidyChat.Translation.Data;
namespace TidyChat;

#pragma warning disable MA0048
public enum PatternKind
{
    None,
    StringMatch,
    RegexMatch
}

public enum SettingTab
{
    Basic,
    System,
    LootObtain,
    Progress,
    CraftingGathering
}

public enum SettingCategory
{
    None,
    EmoteFilters,
    ImprovedMessages,
    FreeCompany,
    DeepDungeon,
    Party,
    Trading,
    Looting,
    CommonCurrency,
    BattleCurrency,
    BeastTribe,
    OtherObtain,
    Desynthesis,
    Materia,
    Crafting,
    Gathering,
    Fishing
}

public class LocalizedFilterRule
{
    public required string Name { get; set; }
    public required string SettingsTab { get; set; }
    public ChatType Channel { get; set; }
    public IList<LocalizedRegex>? RegexChecks { get; set; }
    public IList<LocalizedStrings>? StringChecks { get; set; }
    public PatternKind Pattern { get; set; } = PatternKind.None;
    public required bool IsActive { get; set; }
    public string? Error { get; set; }
    public uint[]? LogMessageIds { get; set; }

    /// <summary>
    ///     When true, the rule blocks messages when IsActive is true ("Hide*" semantics).
    ///     When false (default), the rule blocks when IsActive is false ("Show*" semantics).
    /// </summary>
    public bool BlockWhenActive { get; set; }

    public bool ShouldBlock => BlockWhenActive ? IsActive : !IsActive;
}

public static class Rules
{
    private static readonly List<LocalizedFilterRule> _rules =
    [
        #region System

        new()
        {
            Name = "ShowSRankHunt",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9331]
        },
        new()
        {
            Name = "ShowSSRankHunt",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9332]
        },
        new()
        {
            Name = "ShowCompletedVenture",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4341]
        },
        new()
        {
            Name = "ShowCommendations",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.PlayerCommendation],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowInstanceMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.InstancedArea],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowQuestReminder",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.SayQuestReminder],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowInviteSent",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1]
        },
        new()
        {
            Name = "ShowInviteeJoins",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [60]
        },
        new()
        {
            Name = "ShowLeftParty",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4, 69]
        },
        new()
        {
            Name = "ShowPartyDisband",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [73]
        },
        new()
        {
            Name = "ShowPartyDissolved",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [72]
        },
        new()
        {
            Name = "ShowInvitedBy",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3]
        },
        new()
        {
            Name = "ShowJoinParty",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [61, 7446]
        },
        new()
        {
            Name = "ShowHuntSlain",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4411]
        },
        new()
        {
            Name = "ShowRelicBookStep",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4402]
        },
        new()
        {
            Name = "ShowRelicBookComplete",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4400]
        },
        new()
        {
            Name = "ShowOnlineStatus",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [97]
        },
        new()
        {
            Name = "ShowAttachToMail",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [672, 673]
        },
        new()
        {
            Name = "ShowDesynthedItem",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4321]
        },
        new()
        {
            Name = "ShowDesynthesisObtains",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4322, 4323]
        },
        new()
        {
            Name = "ShowObtainedPomander",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7220, 7221]
        },
        new()
        {
            Name = "ShowReturnedPomander",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7222]
        },
        new()
        {
            Name = "ShowCairnGlows",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7242]
        },
        new()
        {
            Name = "ShowRestoresLifeToFallen",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7243]
        },
        new()
        {
            Name = "ShowCairnActivates",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7245]
        },
        new()
        {
            Name = "ShowTransference",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7246, 7247, 7248]
        },
        new()
        {
            Name = "ShowAetherpoolIncrease",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7250]
        },
        new()
        {
            Name = "ShowAetherpoolIncrease",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.AetherpoolIncrease],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowAetherpoolUnchanged",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7251]
        },
        new()
        {
            Name = "ShowPomanderOfSafety",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7255]
        },
        new()
        {
            Name = "ShowPomanderOfSight",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7256]
        },
        new()
        {
            Name = "ShowPomanderOfAffluence",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7259]
        },
        new()
        {
            Name = "ShowPomanderOfFlight",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7260]
        },
        new()
        {
            Name = "ShowPomanderOfAlteration",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7261]
        },
        new()
        {
            Name = "ShowPomanderOfWitching",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7264]
        },
        new()
        {
            Name = "ShowPomanderOfSerenity",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7265]
        },
        new()
        {
            Name = "ShowFloorNumber",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1531, 9218]
        },
        new()
        {
            Name = "ShowFloorNumber",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.FloorNumber],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowSenseAccursedHoard",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7272]
        },
        new()
        {
            Name = "ShowDoNotSenseAccursedHoard",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7273]
        },
        new()
        {
            Name = "ShowDiscoverAccursedHoard",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7274]
        },
        new()
        {
            Name = "ShowReadyChecks",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3790, 3794]
        },
        new()
        {
            Name = "ShowSpideySenses",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2600, 4791]
        },
        new()
        {
            Name = "ShowAetherCompass",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3712]
        },
        new()
        {
            Name = "ShowCountdownTime",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [5260]
        },
        new()
        {
            Name = "ShowCountdownTime",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [5264]
        },
        new()
        {
            Name = "ShowSpiritboundGear",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [744]
        },
        new()
        {
            Name = "ShowExploratoryVoyage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4163]
        },
        new()
        {
            Name = "ShowSubaquaticVoyage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6061]
        },
        new()
        {
            Name = "ShowVistaMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1272, 1273]
        },
        new()
        {
            Name = "ShowTryOnGlamour",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3911]
        },
        new()
        {
            Name = "ShowEligibleForCoffers",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4233, 4238, 4246]
        },
        new()
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3087, 6065]
        },
        new()
        {
            Name = "ShowPersonalMessageBook",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6066]
        },
        new()
        {
            Name = "BetterCommendationMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.BetterPlayerCommendation],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowTradeSent",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [33]
        },
        new()
        {
            Name = "ShowTradeCanceled",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [36]
        },
        new()
        {
            Name = "ShowAwaitingTradeConfirmation",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [32]
        },
        new()
        {
            Name = "ShowNowLeaderOf",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [15, 16, 23, 24, 367, 383, 9284, 9285, 9289, 9290, 9291, 9298]
        },
        new()
        {
            Name = "ShowFirstClearAward",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4225]
        },
        new()
        {
            Name = "ShowFirstClearAward",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.PartyMemberFirstClear],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowSecondChanceAward",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7975]
        },
        new()
        {
            Name = "ShowSecondChanceAward",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.PartyMemberFirstClear],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowTradeComplete",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [38]
        },

        #region Error Messages

        new()
        {
            Name = "HideFateLevelSync",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2735]
        },
        new()
        {
            Name = "HideFateLevelSync",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2736]
        },

        #endregion
        new()
        {
            Name = "ShowOfferedTeleport",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [440]
        },
        new()
        {
            Name = "ShowGearsetEquipped",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [700, 755]
        },
        new()
        {
            Name = "ShowMateriaRetrieved",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1954]
        },
        new()
        {
            Name = "ShowMateriaShatters",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1955]
        },
        new()
        {
            Name = "ShowVolumeControlMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3860, 3861, 3862, 3863, 3864, 3865, 3866]
        },
        new()
        {
            Name = "ShowAetherialReductionSands",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.AetherialReductionSands],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowSealedOff",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2012, 2013, 2014]
        },
        new()
        {
            Name = "ShowSearchForItemResults",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1630]
        },
        new()
        {
            Name = "Enabled",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1631]
        },
        new()
        {
            Name = "Enabled",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [859]
        },
        new()
        {
            Name = "ShowAetheryteTicket",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [503, 535]
        },

        #endregion

        #region Emote

        new()
        {
            Name = "FilterEmoteChannel",
            SettingsTab = "Emotes",
            Channel = ChatType.StandardEmote,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ContainsPlayerName],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowOtherCustomEmotes",
            SettingsTab = "Emotes",
            Channel = ChatType.CustomEmote,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.PlayerTargetedEmote],
            Pattern = PatternKind.RegexMatch
        },

        #endregion

        #region Crafting

        new()
        {
            Name = "ShowAttachedMateria",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1201]
        },
        new()
        {
            Name = "ShowOvermeldFailure",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1202]
        },
        new()
        {
            Name = "ShowMateriaExtract",
            SettingsTab = "SysCraftingtem",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1200]
        },
        new()
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [5902, 5904]
        },
        new()
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [5906]
        },
        new()
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [5907]
        },
        new()
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [5908]
        },
        new()
        {
            Name = "ShowOtherSynthesis",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1156]
        },
        new()
        {
            Name = "ShowCraftingSynthesisComplete",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            StringChecks = [ChatStrings.SynthesisComplete],
            Pattern = PatternKind.StringMatch
        },

        #endregion

        #region Gathering

        new()
        {
            Name = "ShowGatheringYield",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3537]
        },
        new()
        {
            Name = "ShowGatheringYield",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            StringChecks = [ChatStrings.LocationAffects, ChatStrings.GatheringYield],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGatheringAttempts",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            StringChecks = [ChatStrings.LocationAffects, ChatStrings.GatheringAttempts],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGatherersBoon",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1097]
        },
        new()
        {
            Name = "ShowGatherersBoon",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            StringChecks = [ChatStrings.LocationAffects, ChatStrings.GatherersBoon],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGatheringStartEnd",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1063, 1064, 1065, 1066, 1067, 1068, 1069, 1070]
        },
        new()
        {
            Name = "ShowGatheringSenses",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [1086, 3501]
        },
        new()
        {
            Name = "ShowGatheringSenses",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.SpideySenses],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowLocationAffects",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1098]
        },
        new()
        {
            Name = "ShowLocationAffects",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            StringChecks = [ChatStrings.LocationAffects],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowCaughtFish",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1114]
        },
        new()
        {
            Name = "ShowMooching",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1121]
        },
        new()
        {
            Name = "ShowCurrentFishingHole",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1110]
        },
        new()
        {
            Name = "ShowDiscoveredFishingHole",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1130]
        },
        new()
        {
            Name = "ShowDiscoveredFishingHole",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3513]
        },
        new()
        {
            Name = "ShowDiscoveredFishingHole",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3579]
        },
        new()
        {
            Name = "ShowMeasuringIlms",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3512]
        },
        new()
        {
            Name = "ShowLureMessages",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5566]
        },
        new()
        {
            Name = "ShowLureMessages",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5565, 5569]
        },

        #endregion

        #region FreeCompany

        new()
        {
            Name = "ShowUserLogins",
            SettingsTab = "System",
            Channel = ChatType.FreeCompanyLoginLogout,
            IsActive = true,
            LogMessageIds = [3085]
        },
        new()
        {
            Name = "ShowUserLogouts",
            SettingsTab = "System",
            Channel = ChatType.FreeCompanyLoginLogout,
            IsActive = true,
            LogMessageIds = [3086]
        },

        #endregion

        #region Orchestrion

        new()
        {
            Name = "HideOrchestrionPlaying",
            SettingsTab = "System",
            Channel = ChatType.Orchestrion,
            IsActive = false,
            BlockWhenActive = true,
            LogMessageIds = [3433]
        },

        #endregion

        #region Loot

        new()
        {
            Name = "ShowLootRoll",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.RollsNeedOrGreed],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowCastLot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.CastLot],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedShards",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedShards",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowOthersLootRoll",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.NotStartWithYou, ChatRegexStrings.OthersRollNeedOrGreed],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowOthersCastLot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.NotStartWithYou, ChatRegexStrings.OthersCastLot],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideOthersObtain",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.NotStartWithYou, ChatRegexStrings.OtherObtains],
            Pattern = PatternKind.RegexMatch
        },

        #endregion

        #region Obtain

        new()
        {
            Name = "HideRouletteBonus",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2246]
        },
        new()
        {
            Name = "HideAdventurerInNeedBonus",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2244]
        },
        new()
        {
            Name = "HideObtainedGil",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [657]
        },
        new()
        {
            Name = "HideObtainedMGP",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [4765]
        },
        new()
        {
            Name = "HideObtainedWolfMarks",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedWolfMarks],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedSeals],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedVenture",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedVenture],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedTribalCurrency",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedTribalCurrency],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedClusters",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedClusters],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedAlliedSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedAlliedSeals],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedCenturioSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedCenturioSeals],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedNuts",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedNuts],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedMaterials",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedMaterials],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedShardsFromLoot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideOthersObtainFromLoot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.NotStartWithYou, ChatRegexStrings.ObtainedMaterials],
            Pattern = PatternKind.RegexMatch
        },

        #endregion

        #region Progress

        new()
        {
            Name = "ShowCompletionTime",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [4679]
        },
        new()
        {
            Name = "ShowGainExperience",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [588, 589, 4466, 7300, 10953]
        },
        new()
        {
            Name = "ShowGainPvpExp",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [659]
        },
        new()
        {
            Name = "ShowEarnAchievement",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [952]
        },
        new()
        {
            Name = "ShowOtherEarnedAchievement",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            StringChecks = [ChatStrings.OtherEarnAchievement],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowLevelUps",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [590]
        },
        new()
        {
            Name = "ShowOtherLevelUps",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [3921, 9454]
        },
        new()
        {
            Name = "ShowAbilityUnlocks",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [552]
        },
        new()
        {
            Name = "ShowDesynthesisLevel",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [4325]
        },

        #endregion
    ];

    public static LocalizedFilterRule[] AllRules => [.. _rules];

    /// <summary>
    ///     Lookup from LogMessageId → list of rules that match that ID.
    ///     Built once at static init from rules that have LogMessageIds set.
    /// </summary>
    public static IReadOnlyDictionary<uint, IReadOnlyList<LocalizedFilterRule>> LogMessageIdToRules { get; private set; } = BuildLogMessageIdLookup();

    private static IReadOnlyDictionary<uint, IReadOnlyList<LocalizedFilterRule>> BuildLogMessageIdLookup()
    {
        // Build with mutable inner lists, then expose as read-only.
        var mutable = new Dictionary<uint, List<LocalizedFilterRule>>();
        foreach(LocalizedFilterRule rule in _rules)
        {
            if (rule.LogMessageIds is null) continue;
            foreach(var id in rule.LogMessageIds)
            {
                if (!mutable.TryGetValue(id, out List<LocalizedFilterRule>? list))
                {
                    list = [];
                    mutable[id] = list;
                }
                list.Add(rule);
            }
        }
        var result = new Dictionary<uint, IReadOnlyList<LocalizedFilterRule>>(mutable.Count);
        foreach(KeyValuePair<uint, List<LocalizedFilterRule>> kvp in mutable)
            result[kvp.Key] = kvp.Value;
        return result;
    }

    public static void UpdateIsActiveStates(Configuration config)
    {
        foreach(LocalizedFilterRule rule in _rules)
        {
            try
            {
                rule.IsActive = config.GetPropertyValue<bool>(config, rule.Name);
            }
            catch(Exception ex)
            {
                // If we don't know if a rule is True or False assume it is True
                rule.IsActive = true;
                rule.Error = ex.ToString();
                TidyChatPlugin.Log.Error(rule.Name);
            }
        }
    }
}
