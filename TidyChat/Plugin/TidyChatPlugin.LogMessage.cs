using System.Collections.Generic;
using System.Threading;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private void OnLogMessage(ILogMessage message)
    {
        if (!Configuration.Enabled || message.IsHandled)
        {
            return;
        }
        Rules.UpdateIsActiveStates(Configuration);

        if (Configuration.Whitelist.Count > 0)
        {
            foreach (var entry in Configuration.Whitelist)
            {
                if (!entry.IsLogMessageId)
                {
                    continue;
                }
                var ids = entry.GetLogMessageIds();
                if (ids.Length == 0)
                {
                    continue;
                }
                var idMatches = false;
                foreach (var id in ids)
                {
                    if (id == message.LogMessageId)
                    {
                        idMatches = true;
                        break;
                    }
                }
                if (!idMatches)
                {
                    continue;
                }

                if (!entry.AllowMessage)
                {
                    if (Configuration.EnableDebugMode)
                    {
                        Log.Debug($"[LogMessage] BLOCKED by custom filter \"{entry.FirstName}\" (ID: {message.LogMessageId})");
                    }
                    message.PreventOriginal();
                    Interlocked.Increment(ref _sessionBlockedMessages);
                    return;
                }
                try
                {
                    var text = message.FormatLogMessageForDebugging().ExtractText();
                    RememberLogMessageChatMatchTexts(_allowedByLogMessage, text);
                    RememberCustomFilterLogMessageAllow(message.LogMessageId);
                }
                catch { }
                if (Configuration.EnableDebugMode)
                {
                    Log.Debug($"[LogMessage] ALLOWED by custom filter \"{entry.FirstName}\" (ID: {message.LogMessageId})");
                }
                return;
            }
        }

        if (!Rules.LogMessageIdToRules.TryGetValue(message.LogMessageId, out var matchingRules))
        {
            if (TryBlockHiddenTomestoneLogMessage(message))
            {
                return;
            }

            if (Configuration.EnableDebugMode && _loggedUnmatchedLogMessageIds.Add(message.LogMessageId))
            {
                try
                {
                    var formatted = message.FormatLogMessageForDebugging();
                    Log.Debug($"[LogMessage] Unmatched ID: {message.LogMessageId} | Params: {message.ParameterCount} | Text: {formatted.ExtractText()}");
                }
                catch
                {
                    Log.Debug($"[LogMessage] Unmatched ID: {message.LogMessageId} | Params: {message.ParameterCount}");
                }
            }

            return;
        }

        if (!TryGetNormalizedLogMessageText(message, out var normalizedLogText))
        {
            if (ShouldDefaultBlockDedicatedShowLogMessage(message.LogMessageId, matchingRules, Configuration))
            {
                ApplyLogMessageBlock(message, "Show rule off (ID-only)");
            }
            return;
        }

        if (!TryResolveLogMessageAllow(message.LogMessageId, normalizedLogText, matchingRules,
                out var shouldAllow, out var decidingRuleName))
        {
            if (ShouldDefaultBlockDedicatedShowLogMessage(message.LogMessageId, matchingRules, Configuration))
            {
                ApplyLogMessageBlock(message, matchingRules[0].Name);
            }
            return;
        }

        if (shouldAllow)
        {
            if (TryBlockHiddenTomestoneLogMessage(message))
            {
                return;
            }

            RememberLogMessageAllowDecision(message, decidingRuleName);
            return;
        }

        ApplyLogMessageBlock(message, decidingRuleName);
        if (Configuration.BetterNoviceNetworkMessage && !Configuration.EnableDebugMode)
        {
            if (message.LogMessageId == 7027 || message.LogMessageId == 7011)
            {
                ChatGui.Print(Better.NoviceNetworkJoinMessage(Configuration));
            }
            else if (message.LogMessageId == 7030)
            {
                ChatGui.Print(Better.NoviceNetworkLeaveMessage(Configuration));
            }
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

        var activeHideMatch = false;
        string? activeHideRule = null;
        var activeShowMatch = false;
        string? activeShowRule = null;
        var inactiveShowMatch = false;
        string? inactiveShowRule = null;

        foreach (var rule in matchingRules)
        {
            if (!LogMessageRuleApplies(logMessageId, normalizedText, rule, configuration.EnableDebugMode))
            {
                continue;
            }

            if (rule.BlockWhenActive)
            {
                if (!rule.IsActive)
                {
                    continue;
                }
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

            if (LogMessageCatalog.GetChatTypeForId(logMessageId) is ChatType.LootNotice &&
                ObtainCurrencyHelper.ShouldAllowLootNoticeObtain(configuration, normalizedText,
                    TidyChatPlugin.Tomestones, configuration.HideTomestoneById))
            {
                shouldAllow = true;
                decidingRuleName = "ObtainCurrency (hide off)";
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

        if (ObtainCurrencyHelper.ShouldAllowLootNoticeObtain(configuration, normalizedText,
                TidyChatPlugin.Tomestones, configuration.HideTomestoneById))
        {
            shouldAllow = true;
            decidingRuleName = "ObtainCurrency (hide off)";
            return true;
        }

        return false;
    }

    private void ApplyLogMessageBlock(ILogMessage message, string? decidingRuleName)
    {
        try
        {
            var text = message.FormatLogMessageForDebugging().ExtractText();
            RememberLogMessageChatMatchTexts(_blockedByLogMessage, text);
        }
        catch { }

        RememberLogMessageBlock(message.LogMessageId);

        if (Configuration.EnableDebugMode)
        {
            Log.Debug($"[LogMessage] BLOCKED by {decidingRuleName} (ID: {message.LogMessageId})");
            return;
        }

        message.PreventOriginal();
        Interlocked.Increment(ref _sessionBlockedMessages);
    }

    private static bool HasDedicatedShowRuleForLogMessageId(uint logMessageId,
        IReadOnlyList<LocalizedFilterRule> matchingRules)
    {
        foreach (var rule in matchingRules)
        {
            if (rule.BlockWhenActive)
            {
                continue;
            }
            if (rule.LogMessageIds?.Contains(logMessageId) == true)
            {
                return true;
            }
        }

        return false;
    }

    private static bool ShouldDefaultBlockDedicatedShowLogMessage(uint logMessageId,
        IReadOnlyList<LocalizedFilterRule> matchingRules, Configuration configuration)
    {
        Rules.UpdateIsActiveStates(configuration);
        var hasDedicatedShowRule = false;
        foreach (var rule in matchingRules)
        {
            if (rule.BlockWhenActive)
            {
                continue;
            }
            if (rule.LogMessageIds?.Contains(logMessageId) != true)
            {
                continue;
            }
            hasDedicatedShowRule = true;
            if (!rule.ShouldBlock)
            {
                return false;
            }
        }

        return hasDedicatedShowRule;
    }

    private void RememberLogMessageAllowDecision(ILogMessage message, string? decidingRuleName)
    {
        try
        {
            var text = message.FormatLogMessageForDebugging().ExtractText();
            RememberLogMessageChatMatchTexts(_allowedByLogMessage, text);
            RememberLogMessageAllow(message.LogMessageId);
        }
        catch { }

        if (Configuration.EnableDebugMode)
        {
            Log.Debug($"[LogMessage] ALLOWED by {decidingRuleName} (ID: {message.LogMessageId})");
        }
    }

    private bool LogMessageRuleApplies(ILogMessage message, LocalizedFilterRule rule)
    {
        if (!TryGetNormalizedLogMessageText(message, out var normalizedText))
        {
            return LogMessageRuleApplies(message.LogMessageId, string.Empty, rule, Configuration.EnableDebugMode);
        }

        return LogMessageRuleApplies(message.LogMessageId, normalizedText, rule, Configuration.EnableDebugMode);
    }

    private static bool LogMessageRuleApplies(uint logMessageId, string normalizedText, LocalizedFilterRule rule,
        bool debugMode)
    {
        if (rule.Pattern == PatternKind.None)
        {
            if (LogMessageCatalog.GetChatTypeForId(logMessageId) is ChatType sheetChannel)
            {
                return rule.Channel == sheetChannel;
            }
            return rule.LogMessageIds?.Contains(logMessageId) == true;
        }

        var idMatches = rule.LogMessageIds?.Contains(logMessageId) == true;
        var obtainMarkerRule = ObtainCurrencyHelper.HasObtainMarkerConstraint(rule);

        if (idMatches && rule.ShouldBlock && !obtainMarkerRule)
        {
            if (LogMessageCatalog.IsLoaded && LogMessageCatalog.HasTemplate(logMessageId))
            {
                return true;
            }
            if (normalizedText.Length == 0)
            {
                return true;
            }
        }

        if (normalizedText.Length == 0)
        {
            return rule.ShouldBlock && idMatches &&
                   LogMessageCatalog.IsLoaded && LogMessageCatalog.HasTemplate(logMessageId);
        }

        if (LogMessageCatalog.IsLoaded && idMatches && !obtainMarkerRule &&
            LogMessageCatalog.Matches(logMessageId, normalizedText))
        {
            return true;
        }

        if (RuleMatcher.MatchesText(rule, normalizedText, debugMode))
        {
            return true;
        }

        if (debugMode)
        {
            Log.Debug($"[LogMessage] ID {logMessageId} matched {rule.Name} but text check failed");
        }
        return false;
    }
    private void RememberLogMessageTexts(HashSet<string> target, string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        lock (_logMessageLock)
        {
            if (target.Count >= MaxLogMessageSetSize)
            {
                target.Clear();
            }
            target.Add(text);
            var trimmed = text.Trim();
            if (trimmed.Length > 0)
            {
                target.Add(trimmed);
            }
            var lower = trimmed.ToLower(CultureInfo.CurrentCulture);
            if (lower.Length > 0)
            {
                target.Add(lower);
            }
        }
    }

    private void RememberLogMessageChatMatchTexts(HashSet<string> target, string text)
    {
        RememberLogMessageTexts(target, text);
        if (string.IsNullOrWhiteSpace(Configuration.PlayerName))
        {
            return;
        }

        var lower = text.Trim().ToLower(CultureInfo.CurrentCulture);
        if (lower.Length == 0)
        {
            return;
        }
        RememberLogMessageTexts(target, NormalizeInput.ReplaceName(lower, Configuration));
    }

    private void RememberCustomFilterLogMessageAllow(uint logMessageId)
    {
        lock (_logMessageLock)
        {
            _pendingCustomFilterLogMessageIds.TryGetValue(logMessageId, out var count);
            _pendingCustomFilterLogMessageIds[logMessageId] = count + 1;
        }
    }

    public static void ClearPendingLogMessageAllows()
    {
        if (Instance is not { } plugin)
        {
            return;
        }
        lock (plugin._logMessageLock)
        {
            plugin._pendingAllowedLogMessageIds.Clear();
            plugin._pendingBlockedLogMessageIds.Clear();
            plugin._pendingCustomFilterLogMessageIds.Clear();
        }
    }

    private void RememberLogMessageBlock(uint logMessageId)
    {
        lock (_logMessageLock)
        {
            _pendingBlockedLogMessageIds.TryGetValue(logMessageId, out var count);
            _pendingBlockedLogMessageIds[logMessageId] = count + 1;
        }
    }

    private void RememberLogMessageAllow(uint logMessageId)
    {
        lock (_logMessageLock)
        {
            _pendingAllowedLogMessageIds.TryGetValue(logMessageId, out var count);
            _pendingAllowedLogMessageIds[logMessageId] = count + 1;
        }
    }

    private bool TryConsumePendingLogMessageAllow(string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(normalizedText))
        {
            return false;
        }

        lock (_logMessageLock)
        {
            if (TryConsumePendingLogMessageAllowFrom(_pendingCustomFilterLogMessageIds, normalizedText,
                    false))
            {
                return true;
            }

            return TryConsumePendingLogMessageAllowFrom(_pendingAllowedLogMessageIds, normalizedText,
                true);
        }
    }

    private bool TryConsumePendingLogMessageBlock(string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(normalizedText))
        {
            return false;
        }

        lock (_logMessageLock)
        {
            return TryConsumePendingLogMessageBlockFrom(_pendingBlockedLogMessageIds, normalizedText,
                true);
        }
    }

    private bool TryConsumePendingLogMessageBlockFrom(Dictionary<uint, int> pendingById, string normalizedText,
        bool requireShowRuleStillBlock)
    {
        if (pendingById.Count == 0)
        {
            return false;
        }

        var pendingIds = pendingById.Keys.ToArray();
        foreach (var id in pendingIds)
        {
            if (!pendingById.TryGetValue(id, out var count) || count <= 0)
            {
                continue;
            }
            if (!PendingLogMessageTextMatches(id, normalizedText))
            {
                continue;
            }
            if (requireShowRuleStillBlock &&
                (!Rules.LogMessageIdToRules.TryGetValue(id, out var pendingRules) ||
                 !TryResolveLogMessageAllow(id, normalizedText, pendingRules, Configuration, out var shouldAllow,
                     out _) ||
                 shouldAllow))
            {
                continue;
            }

            if (count == 1)
            {
                pendingById.Remove(id);
            }
            else
            {
                pendingById[id] = count - 1;
            }
            return true;
        }

        return false;
    }

    private bool TryConsumePendingLogMessageAllowFrom(Dictionary<uint, int> pendingById, string normalizedText,
        bool requireShowRuleAllow)
    {
        if (pendingById.Count == 0)
        {
            return false;
        }

        var pendingIds = pendingById.Keys.ToArray();
        foreach (var id in pendingIds)
        {
            if (!pendingById.TryGetValue(id, out var count) || count <= 0)
            {
                continue;
            }
            if (!PendingLogMessageTextMatches(id, normalizedText))
            {
                continue;
            }
            if (requireShowRuleAllow &&
                (!Rules.LogMessageIdToRules.TryGetValue(id, out var pendingRules) ||
                 !TryResolveLogMessageAllow(id, normalizedText, pendingRules, Configuration, out var stillAllow,
                     out _) ||
                 !stillAllow))
            {
                continue;
            }

            if (count == 1)
            {
                pendingById.Remove(id);
            }
            else
            {
                pendingById[id] = count - 1;
            }
            return true;
        }

        return false;
    }

    private static bool PendingLogMessageTextMatches(uint logMessageId, string normalizedText)
    {
        if (LogMessageCatalog.IsLoaded && LogMessageCatalog.HasTemplate(logMessageId) &&
            LogMessageCatalog.Matches(logMessageId, normalizedText))
        {
            return true;
        }

        if (!Rules.LogMessageIdToRules.TryGetValue(logMessageId, out var matchingRules))
        {
            return false;
        }

        foreach (var rule in matchingRules)
        {
            if (LogMessageCatalog.IsLoaded && rule.LogMessageIds is not null &&
                LogMessageCatalog.Matches(logMessageId, normalizedText))
            {
                return true;
            }
            if (RuleMatcher.MatchesText(rule, normalizedText, false))
            {
                return true;
            }
        }

        return false;
    }

    private static bool TryRemoveFromLogMessageSet(HashSet<string> target, IReadOnlyList<string> candidates)
    {
        foreach (var candidate in candidates)
        {
            if (string.IsNullOrWhiteSpace(candidate))
            {
                continue;
            }
            if (target.Remove(candidate))
            {
                return true;
            }

            var trimmed = candidate.Trim();
            if (trimmed.Length > 0 && target.Remove(trimmed))
            {
                return true;
            }

            var lower = trimmed.ToLower(CultureInfo.CurrentCulture);
            if (lower.Length > 0 && target.Remove(lower))
            {
                return true;
            }
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
        if (!TryGetNormalizedLogMessageText(message, out var normalizedText))
        {
            return false;
        }
        if (!ObtainCurrencyHelper.ShouldHideTomestone(normalizedText, Tomestones, Configuration.HideTomestoneById))
        {
            return false;
        }

        if (Configuration.EnableDebugMode)
        {
            Log.Debug($"[LogMessage] BLOCKED by tomestone hide (ID: {message.LogMessageId})");
            try
            {
                var text = message.FormatLogMessageForDebugging().ExtractText();
                RememberLogMessageChatMatchTexts(_blockedByLogMessage, text);
            }
            catch { }

            return true;
        }

        message.PreventOriginal();
        Interlocked.Increment(ref _sessionBlockedMessages);
        return true;
    }
}
