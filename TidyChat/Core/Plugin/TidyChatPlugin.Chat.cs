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

        var logSync = LogMessageHelper.ParticipatesInLogMessageChatSync(chatType)
            ? ResolveLogMessageChatEffect(chatType, rawTextValue, extractedTextValue, normalizedText)
            : new LogMessageChatSyncResult(LogMessageChatEffect.None, null);
        if (logSync.Effect == LogMessageChatEffect.PreserveHidden)
        {
            if (ChannelFilterPolicy.IsCombatLogChannel(chatType))
            {
                logSync = new LogMessageChatSyncResult(LogMessageChatEffect.None, null);
            }
            else
            {
                var logMessageRules = LogMessageDebugRules(logSync.DecidingRuleName);
                LogBlockedChat(logMessageRules, message.Message.TextValue);
                if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                {
                    message.Message = BuildDebugString(chatType, message.Message, logMessageRules,
                        Configuration.DebugIncludeChannel, true);
                }
                else
                {
                    Interlocked.Increment(ref _sessionBlockedMessages);
                    message.PreventOriginal();
                }
                return;
            }
        }

        if (logSync.Effect != LogMessageChatEffect.PreserveVisible)
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

        List<string> rulesMatched = logSync.Effect == LogMessageChatEffect.PreserveVisible
            ? LogMessageDebugRules(logSync.DecidingRuleName)
            : [];
        bool isHandled;
        if (logSync.Effect == LogMessageChatEffect.PreserveVisible)
        {
            isHandled = false;
        }
        else if (ChannelFilterPolicy.ShouldBypassChannelRules(chatType))
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
