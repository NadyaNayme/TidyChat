namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] ObtainSystemClusterHideRules =
    [
        new()
        {
            Name = "HideObtainedClusters",
            SettingsTab = "System",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainClusterMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true,
            ObtainMarkerClustersOnly = true
        }
    ];
}
