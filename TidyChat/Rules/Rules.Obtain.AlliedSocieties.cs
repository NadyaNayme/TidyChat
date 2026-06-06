namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] AlliedSocietiesTribalHideRules =
    [
        new()
        {
            Name = "HideObtainedTribalCurrency",
            SettingsTab = "Allied Societies",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyTribal = true
        },
    ];

    private static readonly LocalizedFilterRule[] AlliedSocietiesMaterialsHideRules =
    [
        new()
        {
            Name = "HideObtainedMaterials",
            SettingsTab = "Allied Societies",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainMaterialsMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerMaterials = true
        },
    ];
}