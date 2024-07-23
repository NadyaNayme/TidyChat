using System;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Xml.Linq;
using ChatTwo.Code;
using Dalamud.Interface.Internal.Windows.Settings;
using TidyChat.Translation.Data;
using static FFXIVClientStructs.FFXIV.Client.Graphics.Kernel.VertexShader;

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
            StringChecks = [ChatStrings.PowerfulMark],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowSSRankHunt",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.ExtraordinarilyPowerfulMark],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowCompletedVenture",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.CompletedVenture],
            Pattern = PatternKind.StringMatch,
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
            Name = "ShowReadyChecks",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.ReadyCheckComplete],
            Pattern = PatternKind.StringMatch,
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
            RegexChecks = [ChatRegexStrings.SpideySenses],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowAetherCompass",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.AetherCompass],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowCountdownTime",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.CountdownTime],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowCountdownTime",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.CountdownEngage],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowSpiritboundGear",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.CompleteSpiritbond],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowExploratoryVoyage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ExploratoryVoyage],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowSubaquaticVoyage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.SubaquaticVoyage],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowVistaMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.VistaMessages],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowTryOnGlamour",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.TryOnGlamour],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowEligibleForCoffers",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.EligibleForCoffers],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.FreeCompanyMessageBook],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowPersonalMessageBook",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.PersonalEstateMessageBook],
            Pattern = PatternKind.RegexMatch,
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
            Name = "ShowGlamoursProjected",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GlamoursProjected],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowTradeSent",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.TradeSent],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowTradeCanceled",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.TradeCanceled],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowAwaitingTradeConfirmation",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.AwaitingTradeConfirmation],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowNowLeaderOf",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.NowLeaderOf],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowFirstClearAward",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.FirstClearAward],
            Pattern = PatternKind.RegexMatch,
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
            RegexChecks = [ChatRegexStrings.SecondChanceAward],
            Pattern = PatternKind.RegexMatch,
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
            StringChecks = [ChatStrings.TradeComplete],
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
            Name = "ShowGearsetEquipped",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GearsetEquipped],
            Pattern = PatternKind.StringMatch,
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
            StringChecks = [ChatStrings.Playtime],
            Pattern = PatternKind.StringMatch,
        },
        #endregion

        #region Emote
        new LocalizedFilterRule
        {
            Name = "ShowUsedEmotes",
            SettingsTab = "Emotes",
            Channel = ChatType.StandardEmote,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.StartsWithYou],
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
            RegexChecks = [ChatRegexStrings.TrialSynthesis],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.TrialQuality],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.TrialHQ],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.TrialCollectability],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowOtherSynthesis",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.OtherSynthesis],
            Pattern = PatternKind.RegexMatch,
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
            RegexChecks = [ChatRegexStrings.GatheringStartEnd],
            Pattern = PatternKind.RegexMatch,
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
            StringChecks = [ChatStrings.AddedToFishGuide],
            Pattern = PatternKind.StringMatch,
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
            RegexChecks = [ChatRegexStrings.CurrentFishingHole],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowDiscoveredFishingHole",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.DiscoveredFishingHole],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowDiscoveredFishingHole",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.DiscoveredFishingHoleARR],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowDiscoveredFishingHole",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.DataOnFishinghole],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowMeasuringIlms",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            StringChecks = [ChatStrings.MeasuringIlms],
            Pattern = PatternKind.StringMatch,
        },
        #endregion

        #region FreeCompany
        new LocalizedFilterRule
        {
            Name = "ShowUserLogins",
            SettingsTab = "System",
            Channel = ChatType.FreeCompanyLoginLogout,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.HasLoggedIn],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowUserLogouts",
            SettingsTab = "System",
            Channel = ChatType.FreeCompanyLoginLogout,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.HasLoggedOut],
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
            Name = "ShowObtainedShards",
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
            Name = "ShowOthersLootRoll",
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
            Name = "ShowRouletteBonus",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            StringChecks = [ChatStrings.RouletteBonus],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowAdventurerInNeedBonus",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            StringChecks = [ChatStrings.AdventurerInNeedBonus],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedGil",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedGil],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedMGP",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedMGP],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedWolfMarks",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedWolfMarks],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedSeals],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedVenture",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedVenture],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedTribalCurrency",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedTribalCurrency],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedShards",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedClusters",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedClusters],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedAlliedSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedAlliedSeals],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedCenturioSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedCenturioSeals],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedNuts",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedNuts],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowObtainedMaterials",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            RegexChecks= [ChatRegexStrings.ObtainedMaterials],
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowOthersObtain",
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
            StringChecks = [ChatStrings.CompletionTime],
            Pattern = PatternKind.StringMatch,
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
            StringChecks = [ChatStrings.GainPvpExp],
            Pattern = PatternKind.StringMatch,
        },
        new LocalizedFilterRule
        {
            Name = "ShowEarnAchievement",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            StringChecks = [ChatStrings.EarnAchievement],
            Pattern = PatternKind.StringMatch,
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
