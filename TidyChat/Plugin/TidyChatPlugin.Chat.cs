using System;
using System.Threading;
using System.Collections.Generic;
using Dalamud.Game.Text;
using Lumina.Text.ReadOnly;

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
        if (message.IsHandled) return;

        ChatType chatType = FromDalamud(message.LogKind);
        string normalizedText = NormalizeInput.ToLowercase(message.Message);
        string rawTextValue = message.Message.TextValue;
        string extractedTextValue;
        try { extractedTextValue = new ReadOnlySeString(message.Message.Encode()).ExtractText(); }
        catch { extractedTextValue = rawTextValue; }
        if (Configuration.PlayerName != "") normalizedText = NormalizeInput.ReplaceName(normalizedText, Configuration);

        // Rewrite while text still matches LogMessage templates (before allow-path short-circuit).
        TryRewriteMarketBoardSaleMessage(message, chatType, normalizedText);

        // Each handler returns true if OnChat should stop processing.
        // Respect OnLogMessage allow/block before server-announcement filtering (#122 / open issue #1).
        if (CheckLogMessageDecision(message, chatType, rawTextValue, extractedTextValue, normalizedText)) return;
        bool protectedByShowRule = IsProtectedByActiveShowRule(chatType, normalizedText, out _);
        if (HandleServerAnnouncements(message, chatType, normalizedText, protectedByShowRule)) return;
        if (!ChannelCanBeFiltered(chatType)) return;
        if (HandleEmoteFilters(message, chatType)) return;
        if (HandleTemporaryFilterDisables(normalizedText)) return;
        if (HandleBetterMessages(message, chatType, normalizedText)) return;

        bool? channelResult = EvaluateChannelRules(message, chatType, normalizedText, out List<string> rulesMatched);
        if (channelResult is null) return; // null sentinel: EvaluateChannelRules handled the early-return internally
        bool isHandled = channelResult.Value;
        ApplyFilterOverrides(message, chatType, normalizedText, ref isHandled);
        ApplyWhitelist(message, chatType, ref isHandled);
        if (CheckChatHistory(message, chatType, ref isHandled)) return;

        if (chatType is ChatType.Echo) isHandled = false;

        if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
        {
            if (Configuration.DebugIncludeChannel || isHandled)
                message.Message = BuildDebugString(chatType, message.Message, rulesMatched, Configuration.DebugIncludeChannel, isHandled);
            isHandled = false;
        }

        if (isHandled)
        {
            Interlocked.Increment(ref _sessionBlockedMessages);
            message.PreventOriginal();
        }
    }
}
