using System.Collections.Generic;
using System.Threading;
using Lumina.Text.ReadOnly;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private void OnLogMessage(ILogMessage message)
    {
        if (!Configuration.Enabled || message.IsHandled) return;
        Rules.UpdateIsActiveStates(Configuration);

        if (Configuration.Whitelist.Count > 0)
        {
            foreach(PlayerName entry in Configuration.Whitelist)
            {
                if (!entry.IsLogMessageId) continue;
                uint[] ids = entry.GetLogMessageIds();
                if (ids.Length == 0) continue;
                bool idMatches = false;
                foreach(uint id in ids)
                {
                    if (id == message.LogMessageId)
                    {
                        idMatches = true;
                        break;
                    }
                }
                if (!idMatches) continue;

                if (!entry.AllowMessage)
                {
                    if (Configuration.EnableDebugMode)
                        Log.Debug($"[LogMessage] BLOCKED by custom filter \"{entry.FirstName}\" (ID: {message.LogMessageId})");
                    message.PreventOriginal();
                    Interlocked.Increment(ref _sessionBlockedMessages);
                    return;
                }
                try
                {
                    string text = message.FormatLogMessageForDebugging().ExtractText();
                    RememberLogMessageTexts(_allowedByLogMessage, text);
                    RememberLogMessageAllow(message.LogMessageId);
                }
                catch
                {
                    /* non-critical */
                }
                if (Configuration.EnableDebugMode)
                    Log.Debug($"[LogMessage] ALLOWED by custom filter \"{entry.FirstName}\" (ID: {message.LogMessageId})");
                return;
            }
        }

        if (!Rules.LogMessageIdToRules.TryGetValue(message.LogMessageId, out IReadOnlyList<LocalizedFilterRule>? matchingRules))
        {
            if (Configuration.EnableDebugMode && _loggedUnmatchedLogMessageIds.Add(message.LogMessageId))
            {
                try
                {
                    ReadOnlySeString formatted = message.FormatLogMessageForDebugging();
                    Log.Debug($"[LogMessage] Unmatched ID: {message.LogMessageId} | Params: {message.ParameterCount} | Text: {formatted.ExtractText()}");
                }
                catch
                {
                    Log.Debug($"[LogMessage] Unmatched ID: {message.LogMessageId} | Params: {message.ParameterCount}");
                }
            }

            return;
        }

        if (!TryResolveLogMessageFilter(message, matchingRules, out bool shouldAllow, out string? decidingRuleName))
            return;

        if (shouldAllow)
        {
            RememberLogMessageAllowDecision(message, decidingRuleName);
            return;
        }

        if (Configuration.EnableDebugMode)
        {
            Log.Debug($"[LogMessage] BLOCKED by {decidingRuleName} (ID: {message.LogMessageId})");
            try
            {
                string text = message.FormatLogMessageForDebugging().ExtractText();
                RememberLogMessageTexts(_blockedByLogMessage, text);
            }
            catch
            {
                /* non-critical */
            }
            return;
        }

        message.PreventOriginal();
        Interlocked.Increment(ref _sessionBlockedMessages);
        if (Configuration.BetterNoviceNetworkMessage)
        {
            if (message.LogMessageId == 7027 || message.LogMessageId == 7011)
                ChatGui.Print(Better.NoviceNetworkJoinMessage(Configuration));
            else if (message.LogMessageId == 7030)
                ChatGui.Print(Better.NoviceNetworkLeaveMessage(Configuration));
        }
    }

    private bool TryResolveLogMessageFilter(
        ILogMessage message,
        IReadOnlyList<LocalizedFilterRule> matchingRules,
        out bool shouldAllow,
        out string? decidingRuleName)
    {
        shouldAllow = false;
        decidingRuleName = null;

        if (TryGetNormalizedLogMessageText(message, out string normalizedText) &&
            CosmicShowRuleHelper.IsCosmicMessageAllowed(Configuration, normalizedText))
        {
            shouldAllow = true;
            decidingRuleName = CosmicShowRuleHelper.GetActiveCosmicRuleName(Configuration, normalizedText);
            return true;
        }

        bool activeHideMatch = false;
        string? activeHideRule = null;
        bool activeShowMatch = false;
        string? activeShowRule = null;
        bool inactiveShowMatch = false;
        string? inactiveShowRule = null;

        foreach(LocalizedFilterRule rule in matchingRules)
        {
            if (!LogMessageRuleApplies(message, rule)) continue;

            if (rule.BlockWhenActive)
            {
                if (!rule.IsActive) continue;
                activeHideMatch = true;
                activeHideRule ??= rule.Name;
            }
            else if (rule.IsActive)
            {
                activeShowMatch = true;
                activeShowRule ??= rule.Name;
            }
            else
            {
                inactiveShowMatch = true;
                inactiveShowRule ??= rule.Name;
            }
        }

        if (activeHideMatch)
        {
            shouldAllow = false;
            decidingRuleName = activeHideRule;
            return true;
        }

        if (activeShowMatch)
        {
            shouldAllow = true;
            decidingRuleName = activeShowRule;
            return true;
        }

        if (inactiveShowMatch)
        {
            shouldAllow = false;
            decidingRuleName = inactiveShowRule;
            return true;
        }

        return false;
    }

    private void RememberLogMessageAllowDecision(ILogMessage message, string? decidingRuleName)
    {
        try
        {
            string text = message.FormatLogMessageForDebugging().ExtractText();
            RememberLogMessageTexts(_allowedByLogMessage, text);
            RememberLogMessageAllow(message.LogMessageId);
        }
        catch
        {
            /* Safe to ignore — worst case OnChat re-evaluates the message */
        }

        if (Configuration.EnableDebugMode)
            Log.Debug($"[LogMessage] ALLOWED by {decidingRuleName} (ID: {message.LogMessageId})");
    }

    private bool LogMessageRuleApplies(ILogMessage message, LocalizedFilterRule rule)
    {
        if (rule.Pattern == PatternKind.None)
        {
            if (LogMessageCatalog.GetChatTypeForId(message.LogMessageId) is ChatType sheetChannel)
                return rule.Channel == sheetChannel;
            return rule.LogMessageIds?.Contains(message.LogMessageId) == true;
        }

        bool idMatches = rule.LogMessageIds?.Contains(message.LogMessageId) == true;

        if (!TryGetNormalizedLogMessageText(message, out string normalizedText))
            return !rule.ShouldBlock && idMatches;

        if (LogMessageCatalog.IsLoaded && idMatches && LogMessageCatalog.Matches(message.LogMessageId, normalizedText))
            return true;

        if (RuleMatchesText(rule, normalizedText, Configuration.EnableDebugMode))
            return true;

        if (!rule.ShouldBlock && idMatches)
            return true;

        if (Configuration.EnableDebugMode)
            Log.Debug($"[LogMessage] ID {message.LogMessageId} matched {rule.Name} but text check failed");
        return false;
    }
    private void RememberLogMessageTexts(HashSet<string> target, string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return;

        lock(_logMessageLock)
        {
            if (target.Count >= MaxLogMessageSetSize) target.Clear();
            target.Add(text);
            string trimmed = text.Trim();
            if (trimmed.Length > 0) target.Add(trimmed);
            string lower = trimmed.ToLower(CultureInfo.CurrentCulture);
            if (lower.Length > 0) target.Add(lower);
        }
    }

    private void RememberLogMessageAllow(uint logMessageId)
    {
        lock(_logMessageLock)
        {
            _pendingAllowedLogMessageIds.TryGetValue(logMessageId, out int count);
            _pendingAllowedLogMessageIds[logMessageId] = count + 1;
        }
    }

    private bool TryConsumePendingLogMessageAllow(string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(normalizedText)) return false;

        lock(_logMessageLock)
        {
            if (_pendingAllowedLogMessageIds.Count == 0) return false;

            uint[] pendingIds = _pendingAllowedLogMessageIds.Keys.ToArray();
            foreach(uint id in pendingIds)
            {
                if (!_pendingAllowedLogMessageIds.TryGetValue(id, out int count) || count <= 0) continue;
                if (!PendingLogMessageTextMatches(id, normalizedText)) continue;

                if (count == 1) _pendingAllowedLogMessageIds.Remove(id);
                else _pendingAllowedLogMessageIds[id] = count - 1;
                return true;
            }
        }

        return false;
    }

    private static bool PendingLogMessageTextMatches(uint logMessageId, string normalizedText)
    {
        if (LogMessageCatalog.IsLoaded && LogMessageCatalog.HasTemplate(logMessageId) &&
            LogMessageCatalog.Matches(logMessageId, normalizedText))
            return true;

        if (!Rules.LogMessageIdToRules.TryGetValue(logMessageId, out IReadOnlyList<LocalizedFilterRule>? matchingRules))
            return false;

        foreach(LocalizedFilterRule rule in matchingRules)
        {
            if (LogMessageCatalog.IsLoaded && rule.LogMessageIds is not null &&
                LogMessageCatalog.Matches(logMessageId, normalizedText))
                return true;
            if (RuleMatchesText(rule, normalizedText, false)) return true;
        }

        return false;
    }

    private static bool TryRemoveFromLogMessageSet(HashSet<string> target, IReadOnlyList<string> candidates)
    {
        foreach(string candidate in candidates)
        {
            if (string.IsNullOrWhiteSpace(candidate)) continue;
            if (target.Remove(candidate)) return true;

            string trimmed = candidate.Trim();
            if (trimmed.Length > 0 && target.Remove(trimmed)) return true;

            string lower = trimmed.ToLower(CultureInfo.CurrentCulture);
            if (lower.Length > 0 && target.Remove(lower)) return true;
        }

        return false;
    }
    private static bool TryGetNormalizedLogMessageText(ILogMessage message, out string normalizedText)
    {
        normalizedText = string.Empty;
        try
        {
            normalizedText = message.FormatLogMessageForDebugging().ExtractText()
                .ToLower(CultureInfo.CurrentCulture);
            return normalizedText.Length > 0;
        }
        catch
        {
            return false;
        }
    }
}
