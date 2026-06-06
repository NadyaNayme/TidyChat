namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] LootPartyEarlyRules =
    [
        new()
        {
            Name = "ShowLootRoll",
            SettingsTab = "Party",
            Channel = ChatType.LootRoll,
            IsActive = true,
            LogMessageIds = [1231],
            StringChecks = [ChatStrings.LootRoll],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCastLot",
            SettingsTab = "Party",
            Channel = ChatType.LootRoll,
            IsActive = true,
            LogMessageIds = [5180],
            StringChecks = [ChatStrings.CastLot],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
    ];

    private static readonly LocalizedFilterRule[] LootPartyLateRules =
    [
        new()
        {
            Name = "ShowOthersLootRoll",
            SettingsTab = "Party",
            Channel = ChatType.LootRoll,
            IsActive = true,
            LogMessageIds = [1231],
            RegexChecks = [ChatStrings.NotStartWithYou, ChatStrings.OthersRollNeedOrGreed],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowOthersCastLot",
            SettingsTab = "Party",
            Channel = ChatType.LootRoll,
            IsActive = true,
            LogMessageIds = [5180],
            RegexChecks = [ChatStrings.OthersCastLot],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideOthersObtain",
            SettingsTab = "Party",
            Channel = ChatType.LootRoll,
            IsActive = true,
            BlockWhenActive = true,
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerOtherPlayer = true,
            ExcludePlayerObtain = true,
            StringChecks = [ChatStrings.OtherObtainMarker]
        },
        new()
        {
            Name = "HideOthersObtain",
            SettingsTab = "Party",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainMaterialsMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerMaterials = true,
            ExcludePlayerObtain = true
        }
    ];
}