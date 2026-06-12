using System.Threading;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private bool HandleEmoteFilters(IHandleableChatMessage message, ChatType chatType, string rawTextValue,
        string extractedTextValue, string normalizedText)
    {
        if ((chatType is ChatType.StandardEmote && !Configuration.FilterEmoteChannel) ||
            (chatType is ChatType.CustomEmote && !Configuration.FilterCustomEmoteChannel))
        {
            if (IsWhitelistedBlocked(message.Sender, message.Message, chatType, rawTextValue, extractedTextValue,
                    normalizedText))
            {
                LogBlockedChat(["CustomFilter (Block)"], message.Message.TextValue);
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
            }
            return true;
        }

        if (!Configuration.ShowOtherCustomEmotes &&
            !string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal) &&
            chatType is ChatType.CustomEmote)
        {
            if (!IsWhitelistedAllowed(message.Sender, message.Message, chatType, rawTextValue, extractedTextValue,
                    normalizedText))
            {
                LogBlockedChat(["HideOtherCustomEmotes"], message.Message.TextValue);
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
            }
            return true;
        }

        return false;
    }
}
