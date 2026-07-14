using Dalamud.Game.Text;
using TidyChat.Data;
namespace TidyChat;

/// <summary>
///     Dalamud <c>IChatGui.Print</c> queues messages with a bare channel id, so both relation kinds stay
///     <see cref="XivChatRelationKind.None" />. Many game System lines share that shape on the chat path, so
///     passthrough also requires a plugin sender name or text that matches no Lumina LogMessage template.
/// </summary>
internal static class PluginChatPassthroughHelper
{
    internal const string PassthroughRuleName = "Plugin passthrough";

    internal static bool IsDalamudPluginPrint(XivChatRelationKind sourceKind, XivChatRelationKind targetKind) =>
        sourceKind is XivChatRelationKind.None && targetKind is XivChatRelationKind.None;

    internal static bool ShouldAllow(
        XivChatRelationKind sourceKind,
        XivChatRelationKind targetKind,
        string senderText,
        string normalizedText,
        string? playerName,
        IEnumerable<string> partyMemberNames)
    {
        if (!IsDalamudPluginPrint(sourceKind, targetKind))
        {
            return false;
        }

        if (!string.IsNullOrWhiteSpace(senderText))
        {
            if (!string.IsNullOrEmpty(playerName) &&
                string.Equals(senderText, playerName, StringComparison.Ordinal))
            {
                return false;
            }

            if (partyMemberNames.Any(name =>
                    string.Equals(senderText, name, StringComparison.Ordinal)))
            {
                return false;
            }

            // Sonar and similar plugins set XivChatEntry.Name (e.g. "Sonar").
            return true;
        }

        // Which Mount and similar plugins use Print(string) with no Name on the entry.
        return LogMessageCatalog.IsLoaded && !LogMessageCatalog.MatchesAnyTemplate(normalizedText);
    }
}
