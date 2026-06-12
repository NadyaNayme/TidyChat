using Lumina.Text.ReadOnly;
using System.Threading;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private void OnChat(IHandleableChatMessage message)
    {
        if (!Configuration.Enabled)
        {
            Log.Verbose("Tidy Chat is not enabled");
            return;
        }
        if (message.IsHandled)
        {
            return;
        }

        var chatType = FromDalamud(message.LogKind);
        var normalizedText = NormalizeInput.ToLowercase(message.Message);
        var rawTextValue = message.Message.TextValue;
        string extractedTextValue;
        try { extractedTextValue = new ReadOnlySeString(message.Message.Encode()).ExtractText(); }
        catch { extractedTextValue = rawTextValue; }
        if (Configuration.PlayerName != "")
        {
            normalizedText = NormalizeInput.ReplaceName(normalizedText, Configuration);
        }

        TryRewriteMarketBoardSaleMessage(message, chatType, normalizedText);

        var logEffect =
            ResolveLogMessageChatEffect(rawTextValue, extractedTextValue, normalizedText);
        if (logEffect == LogMessageChatEffect.PreserveHidden)
        {
            if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
            {
                message.Message = BuildDebugString(chatType, message.Message, ["LogMessage"], Configuration.DebugIncludeChannel, true);
            }
            else
            {
                Interlocked.Increment(ref _sessionBlockedMessages);
                message.PreventOriginal();
            }
            return;
        }

        if (logEffect != LogMessageChatEffect.PreserveVisible)
        {
            var protectedByShowRule =
                IsProtectedByActiveShowRule(chatType, normalizedText, message.Message.TextValue, out _);
            if (HandleServerAnnouncements(message, chatType, normalizedText, protectedByShowRule))
            {
                return;
            }
            if (!ChannelCanBeFiltered(chatType))
            {
                return;
            }
            if (HandleEmoteFilters(message, chatType, rawTextValue, extractedTextValue, normalizedText))
            {
                return;
            }
            if (HandleTemporaryFilterDisables(normalizedText))
            {
                return;
            }
            if (HandleBetterMessages(message, chatType, normalizedText))
            {
                return;
            }
        }

        List<string> rulesMatched = logEffect == LogMessageChatEffect.PreserveVisible ? ["LogMessage"] : [];
        bool isHandled;
        if (logEffect == LogMessageChatEffect.PreserveVisible)
        {
            isHandled = false;
        }
        else
        {
            var channelResult = EvaluateChannelRules(message, chatType, rawTextValue, extractedTextValue,
                normalizedText, out rulesMatched);
            isHandled = channelResult ?? false;
        }

        if (FinishChatHandling(message, chatType, rawTextValue, extractedTextValue, normalizedText, ref isHandled,
                rulesMatched))
        { }
    }
}
