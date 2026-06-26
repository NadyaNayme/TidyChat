namespace TidyChat;

internal static class LootFilterHelper
{
    // HideOthersObtain only governs the loot/obtained channels (its rules live on LootRoll/LootNotice).
    // Gathering yields render in third person ("Ren S. obtains 21 wind crystals.") and must stay under
    // HideObtainedShards rather than being force-shown by the other-player-obtain override.
    public static bool ShouldShowOtherPlayerObtain(Configuration configuration, ChatType? chatType,
        string normalizedText) =>
        chatType is ChatType.LootRoll or ChatType.LootNotice &&
        !configuration.HideOthersObtain &&
        LogMessageCatalog.MatchesOtherPlayerObtain(normalizedText);

    public static bool ShouldShowOtherPlayerLootRoll(Configuration configuration, uint logMessageId,
        string normalizedText) =>
        configuration.ShowOthersLootRoll && logMessageId == 1231 &&
        L10N.Get(ChatStrings.OthersRollNeedOrGreed).IsMatch(normalizedText);

    public static bool ShouldShowOtherPlayerCastLot(Configuration configuration, uint logMessageId,
        string normalizedText) =>
        configuration.ShowOthersCastLot && logMessageId == 5180 &&
        L10N.Get(ChatStrings.OthersCastLot).IsMatch(normalizedText);

    public static bool IsSelfOnlyLootRollOrCastLotRule(LocalizedFilterRule rule) =>
        rule.Name is "ShowLootRoll" or "ShowCastLot";

    public static bool ShouldDeferSelfLootRollOrCastLotRule(string normalizedText, LocalizedFilterRule rule)
    {
        if (!IsSelfOnlyLootRollOrCastLotRule(rule))
        {
            return false;
        }

        return normalizedText.Length > 0 && !normalizedText.StartsWith("you ", StringComparison.Ordinal);
    }

    public static bool ShouldDeferGenericObtainShowRule(string normalizedText, LocalizedFilterRule rule) =>
        ObtainCurrencyHelper.IsGenericObtainShowRule(rule) &&
        LogMessageCatalog.MatchesOtherPlayerObtain(normalizedText);
}
