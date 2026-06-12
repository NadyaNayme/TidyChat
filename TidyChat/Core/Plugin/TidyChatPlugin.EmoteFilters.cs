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
                if (Configuration.EnableDebugMode)
                {
                    Log.Verbose($"Filtered an emote: {message.Message}");
                }
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
            }
            return true;
        }

        return false;
    }
}
