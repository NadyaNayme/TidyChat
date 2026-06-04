using System.Collections.Generic;
using System.Threading;
using Lumina.Text.ReadOnly;
using TidyChat.Utility;
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
            if (TryBlockHiddenTomestoneLogMessage(message))
                return;

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

        if (!TryGetNormalizedLogMessageText(message, out string normalizedLogText))
        {
            if (ShouldDefaultBlockDedicatedShowLogMessage(message.LogMessageId, matchingRules, Configuration))
                ApplyLogMessageBlock(message, "Show rule off (ID-only)");
            return;
        }

        if (!TryResolveLogMessageAllow(message.LogMessageId, normalizedLogText, matchingRules,
                out bool shouldAllow, out string? decidingRuleName))
        {
            if (ShouldDefaultBlockDedicatedShowLogMessage(message.LogMessageId, matchingRules, Configuration))
                ApplyLogMessageBlock(message, matchingRules[0].Name);
            return;
        }

        if (shouldAllow)
        {
            if (TryBlockHiddenTomestoneLogMessage(message))
                return;

            RememberLogMessageAllowDecision(message, decidingRuleName);
            return;
        }

        ApplyLogMessageBlock(message, decidingRuleName);
        if (Configuration.BetterNoviceNetworkMessage && !Configuration.EnableDebugMode)
        {
            if (message.LogMessageId == 7027 || message.LogMessageId == 7011)
                ChatGui.Print(Better.NoviceNetworkJoinMessage(Configuration));
            else if (message.LogMessageId == 7030)
                ChatGui.Print(Better.NoviceNetworkLeaveMessage(Configuration));
        }
    }

    private bool TryResolveLogMessageAllow(
        uint logMessageId,
        string normalizedText,
        IReadOnlyList<LocalizedFilterRule> matchingRules,
        out bool shouldAllow,
        out string? decidingRuleName) =>
        TryResolveLogMessageAllow(logMessageId, normalizedText, matchingRules, Configuration, out shouldAllow,
            out decidingRuleName);

    private static bool TryResolveLogMessageAllow(
        uint logMessageId,
        string normalizedText,
        IReadOnlyList<LocalizedFilterRule> matchingRules,
        Configuration configuration,
        out bool shouldAllow,
        out string? decidingRuleName)
    {
        shouldAllow = false;
        decidingRuleName = null;

        if (CosmicShowRuleHelper.IsCosmicMessageAllowed(configuration, normalizedText))
        {
            shouldAllow = true;
            decidingRuleName = CosmicShowRuleHelper.GetActiveCosmicRuleName(configuration, normalizedText);
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
            if (!LogMessageRuleApplies(logMessageId, normalizedText, rule, configuration.EnableDebugMode)) continue;

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
            // Generic error lines stay visible; dedicated show toggles still block when off.
            if (LogMessageCatalog.GetChatTypeForId(logMessageId) is ChatType.Error &&
                !HasDedicatedShowRuleForLogMessageId(logMessageId, matchingRules))
            {
                shouldAllow = true;
                decidingRuleName = inactiveShowRule;
                return true;
            }

            shouldAllow = false;
            decidingRuleName = inactiveShowRule;
            return true;
        }

        if (ShouldDefaultBlockDedicatedShowLogMessage(logMessageId, matchingRules, configuration))
        {
            shouldAllow = false;
            decidingRuleName = matchingRules.FirstOrDefault(r => r.ShouldBlock && !r.BlockWhenActive)?.Name ??
                               matchingRules[0].Name;
            return true;
        }

        return false;
    }

    private void ApplyLogMessageBlock(ILogMessage message, string? decidingRuleName)
    {
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
    }

    private static bool HasDedicatedShowRuleForLogMessageId(uint logMessageId,
        IReadOnlyList<LocalizedFilterRule> matchingRules)
    {
        foreach(LocalizedFilterRule rule in matchingRules)
        {
            if (rule.BlockWhenActive) continue;
            if (rule.LogMessageIds?.Contains(logMessageId) == true) return true;
        }

        return false;
    }

    private static bool ShouldDefaultBlockDedicatedShowLogMessage(uint logMessageId,
        IReadOnlyList<LocalizedFilterRule> matchingRules, Configuration configuration)
    {
        Rules.UpdateIsActiveStates(configuration);
        bool hasDedicatedShowRule = false;
        foreach(LocalizedFilterRule rule in matchingRules)
        {
            if (rule.BlockWhenActive) continue;
            if (rule.LogMessageIds?.Contains(logMessageId) != true) continue;
            hasDedicatedShowRule = true;
            if (!rule.ShouldBlock) return false;
        }

        return hasDedicatedShowRule;
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
        if (!TryGetNormalizedLogMessageText(message, out string normalizedText))
            return LogMessageRuleApplies(message.LogMessageId, string.Empty, rule, Configuration.EnableDebugMode);

        return LogMessageRuleApplies(message.LogMessageId, normalizedText, rule, Configuration.EnableDebugMode);
    }

    private static bool LogMessageRuleApplies(uint logMessageId, string normalizedText, LocalizedFilterRule rule,
        bool debugMode)
    {
        if (rule.Pattern == PatternKind.None)
        {
            if (LogMessageCatalog.GetChatTypeForId(logMessageId) is ChatType sheetChannel)
                return rule.Channel == sheetChannel;
            return rule.LogMessageIds?.Contains(logMessageId) == true;
        }

        bool idMatches = rule.LogMessageIds?.Contains(logMessageId) == true;

        if (idMatches && rule.ShouldBlock)
        {
            if (LogMessageCatalog.IsLoaded && LogMessageCatalog.HasTemplate(logMessageId))
                return true;
            if (normalizedText.Length == 0)
                return true;
        }

        if (normalizedText.Length == 0)
            return !rule.ShouldBlock && idMatches;

        if (LogMessageCatalog.IsLoaded && idMatches && LogMessageCatalog.Matches(logMessageId, normalizedText))
            return true;

        if (RuleMatchesText(rule, normalizedText, debugMode))
            return true;

        if (!rule.ShouldBlock && idMatches)
            return true;

        if (debugMode)
            Log.Debug($"[LogMessage] ID {logMessageId} matched {rule.Name} but text check failed");
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

    public static void ClearPendingLogMessageAllows()
    {
        if (TidyChatPlugin.Instance is not { } plugin) return;
        lock(plugin._logMessageLock)
        {
            plugin._pendingAllowedLogMessageIds.Clear();
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
                if (!Rules.LogMessageIdToRules.TryGetValue(id, out IReadOnlyList<LocalizedFilterRule>? pendingRules) ||
                    !TryResolveLogMessageAllow(id, normalizedText, pendingRules, Configuration, out bool stillAllow,
                        out _) ||
                    !stillAllow)
                    continue;

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

    private bool TryBlockHiddenTomestoneLogMessage(ILogMessage message)
    {
        if (!TryGetNormalizedLogMessageText(message, out string normalizedText)) return false;
        if (!TomestoneHideHelper.ShouldHide(normalizedText, Tomestones, Configuration.HideTomestoneById))
            return false;

        if (Configuration.EnableDebugMode)
        {
            Log.Debug($"[LogMessage] BLOCKED by tomestone hide (ID: {message.LogMessageId})");
            try
            {
                string text = message.FormatLogMessageForDebugging().ExtractText();
                RememberLogMessageTexts(_blockedByLogMessage, text);
            }
            catch
            {
                /* non-critical */
            }

            return true;
        }

        message.PreventOriginal();
        Interlocked.Increment(ref _sessionBlockedMessages);
        return true;
    }
}
