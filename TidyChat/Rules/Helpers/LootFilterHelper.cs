using TidyChat.Data;
namespace TidyChat;

internal static class LootFilterHelper
{
    // third-person gathering yields ("ren s. obtains 21 wind crystals.") stay under HideObtainedShards
    public static bool ShouldShowOtherPlayerObtain(Configuration configuration, ChatType? chatType,
        string normalizedText) =>
        chatType is ChatType.LootRoll or ChatType.LootNotice &&
        !configuration.HideOthersObtain &&
        !ObtainCurrencyHelper.IsGatheringObtainFailureLine(normalizedText) &&
        !IsHiddenByElementalObtainRule(configuration, normalizedText) &&
        LogMessageCatalog.MatchesOtherPlayerObtain(normalizedText);

    // the other-player-obtain override must not resurrect hidden shards/crystals/clusters
    private static bool IsHiddenByElementalObtainRule(Configuration configuration, string normalizedText) =>
        configuration.HideObtainedShards &&
        ItemMarkerCatalog.MatchesAny(ItemMarkerCatalog.Items.ElementalAll, normalizedText);

    public static bool ShouldShowOtherPlayerLootRoll(Configuration configuration, uint logMessageId,
        string normalizedText) =>
        configuration.ShowOthersLootRoll && logMessageId == 1231 &&
        L10N.Get(ChatStrings.OthersRollNeedOrGreed).IsMatch(normalizedText);

    public static bool ShouldShowOtherPlayerCastLot(Configuration configuration, uint logMessageId,
        string normalizedText) =>
        configuration.ShowOthersCastLot && logMessageId == 5180 &&
        L10N.Get(ChatStrings.OthersCastLot).IsMatch(normalizedText);

    public static bool ShouldDeferSelfLootRollOrCastLotRule(string normalizedText, LocalizedFilterRule rule) =>
        rule.Name is "ShowLootRoll" or "ShowCastLot" &&
        normalizedText.Length > 0 &&
        !normalizedText.StartsWith("you ", StringComparison.Ordinal);

    public static bool ShouldDeferGenericObtainShowRule(string normalizedText, LocalizedFilterRule rule) =>
        ObtainCurrencyHelper.IsGenericObtainShowRule(rule) &&
        LogMessageCatalog.MatchesOtherPlayerObtain(normalizedText);
}
