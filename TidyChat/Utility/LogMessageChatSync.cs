namespace TidyChat.Utility;

internal static class LogMessageChatSync
{
    internal const uint InventoryItemAddedLogMessageId = 789;

    internal static bool StrictCatalogMatch(uint logMessageId, string normalizedText) =>
        LogMessageCatalog.IsLoaded &&
        LogMessageCatalog.HasTemplate(logMessageId) &&
        LogMessageCatalog.Matches(logMessageId, normalizedText);

    internal static bool MatchesInventoryAddedLine(string normalizedText) =>
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.InventoryItemAdded);
}
