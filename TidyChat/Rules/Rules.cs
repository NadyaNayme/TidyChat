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
    RegexMatch,
}

public enum SettingTab
{
    Basic,
    System,
    LootObtain,
    Progress,
    CraftingGathering,
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
    Fishing,
}

public class LocalizedFilterRule
{
    public required string Name { get; set; }
    public required string SettingsTab { get; set; }

    public ChatType Channel { get; set; }
    public IList<LocalizedRegex>? RegexChecks { get; set; }
    public IList<LocalizedStrings>? StringChecks { get; set; }
    public PatternKind Pattern { get; set; } = PatternKind.None;
    public SettingTab SettingTab { get; set; } = SettingTab.Basic;
    public SettingCategory SettingCategory { get; set; } = SettingCategory.None;
    public required Boolean IsActive { get; set; } = false;
    public string? Error { get; set; }
    
    public uint[]? LogMessageIds { get; set; }

    /// <summary>
    /// When true, the rule blocks messages when IsActive is true ("Hide*" semantics).
    /// When false (default), the rule blocks when IsActive is false ("Show*" semantics).
    /// </summary>
    public bool BlockWhenActive { get; set; } = false;
    
    public bool ShouldBlock => BlockWhenActive ? IsActive : !IsActive;
}
public static class Rules
{
    private static readonly List<LocalizedFilterRule> _rules =
    [
        #region System
        new LocalizedFilterRule
        {
            Name = "ShowSRankHunt",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9331]
        },
        new LocalizedFilterRule
        {
            Name = "ShowSSRankHunt",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9332]
        },
        new LocalizedFilterRule
        {
            Name = "ShowCompletedVenture",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4341]
        },
        new LocalizedFilterRule
        {
            Name = "ShowCommendations",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.PlayerCommendation],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowInstanceMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.InstancedArea],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowQuestReminder",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.SayQuestReminder],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowInviteSent",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1]
        },
        new LocalizedFilterRule
        {
            Name = "ShowInviteeJoins",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.InviteeJoins],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowLeftParty",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.LeftParty],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowLeftParty",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4]
        },
        new LocalizedFilterRule
        {
            Name = "ShowPartyDisband",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [73]
        },
        new LocalizedFilterRule
        {
            Name = "ShowPartyDissolved",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [72]
        },
        new LocalizedFilterRule
        {
            Name = "ShowInvitedBy",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.InvitedBy],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowJoinParty",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.JoinParty],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowJoinParty",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7446]
        },
        new LocalizedFilterRule
        {
            Name = "ShowHuntSlain",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4411]
        },
        new LocalizedFilterRule
        {
            Name = "ShowRelicBookStep",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4402]
        },
        new LocalizedFilterRule
        {
            Name = "ShowRelicBookComplete",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4400]
        },
        new LocalizedFilterRule
        {
            Name = "ShowOnlineStatus",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [97]
        },
        new LocalizedFilterRule
        {
            Name = "ShowAttachToMail",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [672, 673]
        },
        new LocalizedFilterRule
        {
            Name = "ShowDesynthedItem",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.YouDesynth],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowDesynthesisObtains",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.YouObtainSystem],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedPomander",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7221]
        },
        new LocalizedFilterRule
        {
            Name = "ShowReturnedPomander",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7222]
        },
        new LocalizedFilterRule
        {
            Name = "ShowCairnGlows",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7242]
        },
        new LocalizedFilterRule
        {
            Name = "ShowRestoresLifeToFallen",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7243]
        },
        new LocalizedFilterRule
        {
            Name = "ShowCairnActivates",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7245]
        },
        new LocalizedFilterRule
        {
            Name = "ShowTransference",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7246, 7247, 7248]
        },
        new LocalizedFilterRule
        {
            Name = "ShowAetherpoolIncrease",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.AetherpoolIncrease],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowAetherpoolUnchanged",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7251]
        },
        new LocalizedFilterRule
        {
            Name = "ShowPomanderOfSafety",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7255]
        },
        new LocalizedFilterRule
        {
            Name = "ShowPomanderOfSight",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7256]
        },
        new LocalizedFilterRule
        {
            Name = "ShowPomanderOfAffluence",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7259]
        },
        new LocalizedFilterRule
        {
            Name = "ShowPomanderOfFlight",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7260]
        },
        new LocalizedFilterRule
        {
            Name = "ShowPomanderOfAlteration",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7261]
        },
        new LocalizedFilterRule
        {
            Name = "ShowPomanderOfWitching",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7264]
        },
        new LocalizedFilterRule
        {
            Name = "ShowPomanderOfSerenity",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7265]
        },
        new LocalizedFilterRule
        {
            Name = "ShowFloorNumber",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.FloorNumber],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowSenseAccursedHoard",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7272]
        },
        new LocalizedFilterRule
        {
            Name = "ShowDoNotSenseAccursedHoard",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7273]
        },
        new LocalizedFilterRule
        {
            Name = "ShowDiscoverAccursedHoard",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7274]
        },
        new LocalizedFilterRule
        {
            Name = "ShowReadyChecks",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3794]
        },
        new LocalizedFilterRule
        {
            Name = "ShowReadyChecks",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.InitiatedReadyCheck],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowSpideySenses",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2600, 4791]
        },
        new LocalizedFilterRule
        {
            Name = "ShowAetherCompass",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3712]
        },
        new LocalizedFilterRule
        {
            Name = "ShowCountdownTime",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [5260]
        },
        new LocalizedFilterRule
        {
            Name = "ShowCountdownTime",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [5264]
        },
        new LocalizedFilterRule
        {
            Name = "ShowSpiritboundGear",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [744]
        },
        new LocalizedFilterRule
        {
            Name = "ShowExploratoryVoyage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4163]
        },
        new LocalizedFilterRule
        {
            Name = "ShowSubaquaticVoyage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6061]
        },
        new LocalizedFilterRule
        {
            Name = "ShowVistaMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1272, 1273]
        },
        new LocalizedFilterRule
        {
            Name = "ShowTryOnGlamour",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3911]
        },
        new LocalizedFilterRule
        {
            Name = "ShowEligibleForCoffers",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4233, 4238, 4246]
        },
        new LocalizedFilterRule
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6065]
        },
        new LocalizedFilterRule
        {
            Name = "ShowPersonalMessageBook",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6066]
        },
        new LocalizedFilterRule
        {
            Name = "BetterCommendationMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.BetterPlayerCommendation],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowTradeSent",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [33]
        },
        new LocalizedFilterRule
        {
            Name = "ShowTradeCanceled",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [36]
        },
        new LocalizedFilterRule
        {
            Name = "ShowAwaitingTradeConfirmation",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [32]
        },
        new LocalizedFilterRule
        {
            Name = "ShowNowLeaderOf",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [15, 16, 23, 24, 367, 383, 9284, 9285, 9289, 9290, 9291, 9298]
        },
        new LocalizedFilterRule
        {
            Name = "ShowFirstClearAward",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4225]
        },
        new LocalizedFilterRule
        {
            Name = "ShowFirstClearAward",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.PartyMemberFirstClear],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowSecondChanceAward",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7975]
        },
        new LocalizedFilterRule
        {
            Name = "ShowSecondChanceAward",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.PartyMemberFirstClear],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowTradeComplete",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [38]
        },

        #region Error Messages

        new LocalizedFilterRule
        {
            Name = "HideFateLevelSync",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2735]
        },
        new LocalizedFilterRule
        {
            Name = "HideFateLevelSync",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2736]
        },

        #endregion
        new LocalizedFilterRule
        {
            Name = "ShowOfferedTeleport",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [440]
        },
        new LocalizedFilterRule
        {
            Name = "ShowGearsetEquipped",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [700]
        },
        new LocalizedFilterRule
        {
            Name = "ShowGearsetEquipped",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GearsetEquipped],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowOfferedTeleport",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.OfferedTeleport],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowGearsetEquipped",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.GearsetEquipped],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowMateriaRetrieved",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.MateriaRetrieved],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowMateriaShatters",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.MateriaShatters],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowVolumeControlMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3860, 3861, 3862, 3863, 3864, 3865, 3866]
        },
        new LocalizedFilterRule
        {
            Name = "ShowAetherialReductionSands",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.AetherialReductionSands],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowSealedOff",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2012, 2013, 2014]
        },
        new LocalizedFilterRule
        {
            Name = "ShowSearchForItemResults",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.SearchForItemResults],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "Enabled",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ItemSearchCommand],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "Enabled",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [859]
        },
        new LocalizedFilterRule
        {
            Name = "ShowAetheryteTicket",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.AetheryteTicket],
            Pattern = PatternKind.StringMatch,
        },
        #endregion

        #region Emote
        new LocalizedFilterRule
        {
            Name = "FilterEmoteChannel",
            SettingsTab = "Emotes",
            Channel = ChatType.StandardEmote,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ContainsPlayerName],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowOtherCustomEmotes",
            SettingsTab = "Emotes",
            Channel = ChatType.CustomEmote,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.PlayerTargetedEmote],
            Pattern = PatternKind.RegexMatch,
        },
        #endregion

        #region Crafting
        new LocalizedFilterRule
        {
            Name = "FilterCraftingSpam",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            StringChecks = [ChatStrings.YouSynthesize],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowAttachedMateria",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.AttachedMateria],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowOvermeldFailure",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            StringChecks = [ChatStrings.OvermeldFailure],
            Pattern = PatternKind.StringMatch,
        },

        new LocalizedFilterRule
        {
            Name = "ShowMateriaExtract",
            SettingsTab = "SysCraftingtem",
            Channel = ChatType.Crafting,
            IsActive = true,
            StringChecks = [ChatStrings.MateriaExtract],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [5902, 5904]
        },
        new LocalizedFilterRule
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [5906]
        },
        new LocalizedFilterRule
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [5907]
        },
        new LocalizedFilterRule
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [5908]
        },
        new LocalizedFilterRule
        {
            Name = "ShowOtherSynthesis",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1156]
        },
        #endregion

        #region Gathering
        new LocalizedFilterRule
        {
            Name = "ShowGatheringYield",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            StringChecks = [ChatStrings.LocationAffects, ChatStrings.GatheringYield],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowGatheringAttempts",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            StringChecks = [ChatStrings.LocationAffects, ChatStrings.GatheringAttempts],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowGatherersBoon",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            StringChecks = [ChatStrings.LocationAffects, ChatStrings.GatherersBoon],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowGatheringStartEnd",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1063, 1064, 1065, 1066, 1067, 1068, 1069, 1070]
        },
        new LocalizedFilterRule
        {
            Name = "ShowGatheringSenses",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.SpideySenses],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowLocationAffects",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            StringChecks = [ChatStrings.LocationAffects],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowCaughtFish",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1114]
        },
        new LocalizedFilterRule
        {
            Name = "ShowMooching",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.Mooching],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowCurrentFishingHole",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1110]
        },
        new LocalizedFilterRule
        {
            Name = "ShowDiscoveredFishingHole",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1130]
        },
        new LocalizedFilterRule
        {
            Name = "ShowDiscoveredFishingHole",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3513]
        },
        new LocalizedFilterRule
        {
            Name = "ShowDiscoveredFishingHole",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3579]
        },
        new LocalizedFilterRule
        {
            Name = "ShowMeasuringIlms",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3512]
        },
        new LocalizedFilterRule
        {
            Name = "ShowLureMessages",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.LureAttempt],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowLureMessages",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.LureBite],
            Pattern = PatternKind.RegexMatch,
        },
        #endregion

        #region FreeCompany
        new LocalizedFilterRule
        {
            Name = "ShowUserLogins",
            SettingsTab = "System",
            Channel = ChatType.FreeCompanyLoginLogout,
            IsActive = true,
            LogMessageIds = [3085]
        },
        new LocalizedFilterRule
        {
            Name = "ShowUserLogouts",
            SettingsTab = "System",
            Channel = ChatType.FreeCompanyLoginLogout,
            IsActive = true,
            LogMessageIds = [3086]
        },
        #endregion

        #region Orchestrion
        new LocalizedFilterRule
        {
            Name = "HideOrchestrionPlaying",
            SettingsTab = "System",
            Channel = ChatType.Orchestrion,
            IsActive = false,
            RegexChecks = [ChatRegexStrings.OrchestrionPlaying],
            Pattern = PatternKind.RegexMatch,
        },
        #endregion

        #region Loot
        new LocalizedFilterRule
        {
            Name = "ShowLootRoll",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.RollsNeedOrGreed],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowCastLot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.CastLot],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedShards",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedShards",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowOthersLootRoll",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.NotStartWithYou,ChatRegexStrings.OthersRollNeedOrGreed],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowOthersCastLot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.NotStartWithYou,ChatRegexStrings.OthersCastLot],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideOthersObtain",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.NotStartWithYou,ChatRegexStrings.OtherObtains],
            Pattern = PatternKind.RegexMatch,
        },
        #endregion

        #region Obtain
        new LocalizedFilterRule
        {
            Name = "HideRouletteBonus",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2246]
        },
        new LocalizedFilterRule
        {
            Name = "HideAdventurerInNeedBonus",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2244]
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedGil",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [657]
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedMGP",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedMGP],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedWolfMarks",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedWolfMarks],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedSeals],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedVenture",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedVenture],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedTribalCurrency",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedTribalCurrency],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedShards",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedClusters",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedClusters],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedAlliedSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedAlliedSeals],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedCenturioSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedCenturioSeals],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedNuts",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedNuts],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideObtainedMaterials",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedMaterials],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "HideOthersObtain",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.NotStartWithYou, ChatRegexStrings.ObtainedMaterials],
            Pattern = PatternKind.RegexMatch,
        },
        #endregion

        #region Progress
        new LocalizedFilterRule
        {
            Name = "ShowCompletionTime",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [4679]
        },
        new LocalizedFilterRule
        {
            Name = "ShowGainExperience",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.GainExperiencePoints],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowGainPvpExp",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [659]
        },
        new LocalizedFilterRule
        {
            Name = "ShowEarnAchievement",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [952]
        },
        new LocalizedFilterRule
        {
            Name = "ShowOtherEarnedAchievement",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            StringChecks = [ChatStrings.OtherEarnAchievement],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowLevelUps",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            StringChecks = [ChatStrings.YouAttainLevel],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowOtherLevelUps",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            StringChecks = [ChatStrings.OtherAttainsLevel],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowAbilityUnlocks",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            StringChecks = [ChatStrings.YouLearnAbility],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowDesynthesisLevel",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            StringChecks = [ChatStrings.DesynthesisLevel],
            Pattern = PatternKind.StringMatch,
        },
        #endregion

    ];

    public static LocalizedFilterRule[] AllRules => [.. _rules];

    /// <summary>
    /// Lookup from LogMessageId → list of rules that match that ID.
    /// Built once at static init from rules that have LogMessageIds set.
    /// </summary>
    public static Dictionary<uint, List<LocalizedFilterRule>> LogMessageIdToRules { get; private set; } = BuildLogMessageIdLookup();

    private static Dictionary<uint, List<LocalizedFilterRule>> BuildLogMessageIdLookup()
    {
        var lookup = new Dictionary<uint, List<LocalizedFilterRule>>();
        foreach (var rule in _rules)
        {
            if (rule.LogMessageIds is null) continue;
            foreach (uint id in rule.LogMessageIds)
            {
                if (!lookup.TryGetValue(id, out var list))
                {
                    list = [];
                    lookup[id] = list;
                }
                list.Add(rule);
            }
        }
        return lookup;
    }

    public static void UpdateIsActiveStates(Configuration config)
    {
        foreach (var rule in _rules)
        {
            try
            {
                rule.IsActive = config.GetPropertyValue<Boolean>(config, rule.Name);
            }
            catch (Exception ex)
            {
                // If we don't know if a rule is True or False assume it is True
                rule.IsActive = true;
                rule.Error = ex.ToString();
                TidyChatPlugin.Log.Error(rule.Name);
            }
        }
    }
}
