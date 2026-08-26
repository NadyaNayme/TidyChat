using ChatTwo.Code;
using Dalamud.Game.Text;
using TidyChat.Data;
namespace TidyChat;

internal static class PluginChatPassthroughHelper
{
    internal const string PassthroughRuleName = "Plugin passthrough";

    internal static bool ShouldAllow(
        ChatType chatType,
        XivChatRelationKind sourceKind,
        XivChatRelationKind targetKind,
        string senderText,
        string normalizedText,
        string? playerName,
        IEnumerable<string> partyMemberNames)
    {
        if (chatType is ChatType.StandardEmote or ChatType.CustomEmote)
        {
            return false;
        }

        if (sourceKind is not XivChatRelationKind.None || targetKind is not XivChatRelationKind.None)
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

            return true;
        }

        return LogMessageCatalog.IsLoaded && !LogMessageCatalog.MatchesAnySystemTemplate(normalizedText);
    }
}
