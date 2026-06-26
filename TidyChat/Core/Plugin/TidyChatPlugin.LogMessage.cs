using System.Threading;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private void OnLogMessage(ILogMessage message)
    {
        try
        {
            OnLogMessageInner(message);
        }
        catch (Exception ex)
        {
            Log.Warning(ex, "TidyChat failed to handle LogMessage {LogMessageId}", message.LogMessageId);
        }
    }

    private void OnLogMessageInner(ILogMessage message)
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
                    if (LogMessageHelper.TryExtractText(message, out var blockedText))
                    {
                        RememberLogMessageChatMatchTexts(_blockedByLogMessage, blockedText);
                    }
                    RememberLogMessageBlock(message.LogMessageId);
                    EmitBlockedXllog(
                        $"[LogMessage] BLOCKED by custom filter \"{entry.FirstName}\" (ID: {message.LogMessageId})");
                    if (Configuration.EnableDebugMode)
                    {
                        return;
                    }
                    message.PreventOriginal();
                    Interlocked.Increment(ref _sessionBlockedMessages);
                    return;
                }
                if (LogMessageHelper.TryExtractText(message, out var allowedText))
                {
                    RememberLogMessageChatMatchTexts(_allowedByLogMessage, allowedText);
                }
                RememberCustomFilterLogMessageAllow(message.LogMessageId);
                EmitDebugXllog(
                    $"[LogMessage] ALLOWED by custom filter \"{entry.FirstName}\" (ID: {message.LogMessageId})");
                return;
            }
        }

        if (TryApplyLogMessageTextCustomFilters(message))
        {
            return;
        }

        if (TryGetNormalizedLogMessageText(message, out var normalizedTomestoneText) &&
            ObtainCurrencyHelper.TryResolveTomestoneLogMessage(normalizedTomestoneText, Tomestones,
                Configuration.HideTomestoneById, out var tomestoneAllow, out var tomestoneRule))
        {
            if (tomestoneAllow)
            {
                RememberLogMessageAllowDecision(message, tomestoneRule);
            }
            else
            {
                ApplyLogMessageBlock(message, tomestoneRule);
            }

            return;
        }

        if (!Rules.LogMessageIdToRules.TryGetValue(message.LogMessageId, out var matchingRules))
        {
            if (TryBlockHiddenTomestoneLogMessage(message) || TryBlockHiddenTribalCurrencyLogMessage(message))
            {
                return;
            }

            if (Configuration.EnableDebugMode && _loggedUnmatchedLogMessageIds.Add(message.LogMessageId))
            {
                if (LogMessageHelper.TryExtractText(message, out var unmatchedText))
                {
                    Log.Debug(
                        $"[LogMessage] Unmatched ID: {message.LogMessageId} | Params: {message.ParameterCount} | Text: {unmatchedText}");
                }
                else
                {
                    Log.Debug($"[LogMessage] Unmatched ID: {message.LogMessageId} | Params: {message.ParameterCount}");
                }
            }

            return;
        }

        if (!TryGetNormalizedLogMessageText(message, out var normalizedLogText))
        {
            if (TryResolveLogMessageAllow(message.LogMessageId, string.Empty, matchingRules,
                    out var idOnlyShouldAllow, out var idOnlyRuleName, out var idOnlyMatchDetail) &&
                !idOnlyShouldAllow)
            {
                ApplyLogMessageBlock(message, idOnlyRuleName, idOnlyMatchDetail);
            }
            else if (ShouldDefaultBlockDedicatedShowLogMessage(message.LogMessageId, matchingRules, Configuration))
            {
                ApplyLogMessageBlock(message, "Show rule off (ID-only)");
            }
            return;
        }

        if (!TryResolveLogMessageAllow(message.LogMessageId, normalizedLogText, matchingRules,
                out var shouldAllow, out var decidingRuleName, out var decidingMatchDetail))
        {
            if (ShouldDefaultBlockDedicatedShowLogMessage(message.LogMessageId, matchingRules, Configuration))
            {
                ApplyLogMessageBlock(message, matchingRules[0].Name);
            }
            return;
        }

        if (shouldAllow)
        {
            if (TryBlockHiddenTomestoneLogMessage(message) || TryBlockHiddenTribalCurrencyLogMessage(message))
            {
                return;
            }

            RememberLogMessageAllowDecision(message, decidingRuleName, decidingMatchDetail);
            return;
        }

        ApplyLogMessageBlock(message, decidingRuleName, decidingMatchDetail);
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
        out string? decidingRuleName,
        out string? decidingMatchDetail) =>
        TryResolveLogMessageAllow(logMessageId, normalizedText, matchingRules, Configuration, out shouldAllow,
            out decidingRuleName, out decidingMatchDetail);

    private static bool TryResolveLogMessageAllow(
        uint logMessageId,
        string normalizedText,
        IReadOnlyList<LocalizedFilterRule> matchingRules,
        Configuration configuration,
        out bool shouldAllow,
        out string? decidingRuleName,
        out string? decidingMatchDetail)
    {
        shouldAllow = false;
        decidingRuleName = null;
        decidingMatchDetail = null;

        if (CosmicExplorationFilterHelper.IsCosmicMessageAllowed(configuration, normalizedText))
        {
            shouldAllow = true;
            decidingRuleName = CosmicExplorationFilterHelper.GetActiveCosmicRuleName(configuration, normalizedText);
            return true;
        }

        if (CosmicExplorationFilterHelper.IsGpRecoveryLogMessageAllowed(configuration, logMessageId, normalizedText))
        {
            shouldAllow = true;
            decidingRuleName = "ShowStellarGpRecovery";
            return true;
        }

        if (LootFilterHelper.ShouldShowOtherPlayerObtain(configuration,
                LogMessageCatalog.GetChatTypeForId(logMessageId), normalizedText))
        {
            shouldAllow = true;
            decidingRuleName = "HideOthersObtain";
            decidingMatchDetail = "other-player obtain (show on)";
            return true;
        }

        if (LootFilterHelper.ShouldShowOtherPlayerLootRoll(configuration, logMessageId, normalizedText))
        {
            shouldAllow = true;
            decidingRuleName = "ShowOthersLootRoll";
            return true;
        }

        if (LootFilterHelper.ShouldShowOtherPlayerCastLot(configuration, logMessageId, normalizedText))
        {
            shouldAllow = true;
            decidingRuleName = "ShowOthersCastLot";
            return true;
        }

        var activeHideMatch = false;
        string? activeHideRule = null;
        string? activeHideMatchDetail = null;
        var activeShowMatch = false;
        string? activeShowRule = null;
        string? activeShowMatchDetail = null;
        var inactiveShowMatch = false;
        string? inactiveShowRule = null;
        string? inactiveShowMatchDetail = null;

        foreach (var rule in matchingRules)
        {
            if (FilterMasterAccessors.IsDisabledByMasterToggle(rule, configuration))
            {
                continue;
            }

            if (!LogMessageRuleApplies(logMessageId, normalizedText, rule, out var ruleMatchDetail))
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
                if (activeHideRule is null)
                {
                    activeHideRule = rule.Name;
                    activeHideMatchDetail = ruleMatchDetail;
                }
            }
            else if (rule.IsActive)
            {
                activeShowMatch = true;
                if (activeShowRule is null)
                {
                    activeShowRule = rule.Name;
                    activeShowMatchDetail = ruleMatchDetail;
                }
            }
            else
            {
                inactiveShowMatch = true;
                if (inactiveShowRule is null)
                {
                    inactiveShowRule = rule.Name;
                    inactiveShowMatchDetail = ruleMatchDetail;
                }
            }
        }

        if (activeHideMatch)
        {
            shouldAllow = false;
            decidingRuleName = activeHideRule;
            decidingMatchDetail = activeHideMatchDetail;
            return true;
        }

        if (activeShowMatch)
        {
            shouldAllow = true;
            decidingRuleName = activeShowRule;
            decidingMatchDetail = activeShowMatchDetail;
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
                decidingMatchDetail = inactiveShowMatchDetail;
                return true;
            }

            if (LogMessageCatalog.GetChatTypeForId(logMessageId) is ChatType.LootNotice &&
                ObtainCurrencyHelper.ShouldAllowLootNoticeObtain(configuration, normalizedText,
                    Tomestones, configuration.HideTomestoneById, TribalCurrencies,
                    configuration.HideTribalCurrencyById))
            {
                shouldAllow = true;
                decidingRuleName = "ObtainCurrency (hide off)";
                return true;
            }

            if (configuration.ShowObtainedItems &&
                ObtainCurrencyHelper.IsGenericItemObtainLine(normalizedText) &&
                inactiveShowRule is not null &&
                ObtainCurrencyHelper.DefersObtainRuleToGeneral(inactiveShowRule))
            {
                shouldAllow = true;
                decidingRuleName = "ShowObtainedItems";
                return true;
            }

            shouldAllow = false;
            decidingRuleName = inactiveShowRule;
            decidingMatchDetail = inactiveShowMatchDetail;
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
                Tomestones, configuration.HideTomestoneById, TribalCurrencies,
                configuration.HideTribalCurrencyById))
        {
            shouldAllow = true;
            decidingRuleName = "ObtainCurrency (hide off)";
            return true;
        }

        return false;
    }

    private void ApplyLogMessageBlock(ILogMessage message, string? decidingRuleName, string? matchDetail = null)
    {
        if (LogMessageHelper.TryExtractText(message, out var blockedText))
        {
            RememberLogMessageChatMatchTexts(_blockedByLogMessage, blockedText);
        }

        RememberLogMessageBlock(message.LogMessageId);

        EmitBlockedXllog(
            FormatLogMessageDecision("BLOCKED", decidingRuleName, message.LogMessageId, matchDetail));

        if (RuleUsesSoftLogMessageHide(decidingRuleName))
        {
            return;
        }

        if (Configuration.EnableDebugMode)
        {
            return;
        }

        message.PreventOriginal();
        Interlocked.Increment(ref _sessionBlockedMessages);
    }

    private static bool RuleUsesSoftLogMessageHide(string? decidingRuleName)
    {
        if (string.IsNullOrEmpty(decidingRuleName))
        {
            return false;
        }

        foreach (var rule in Rules.AllRules)
        {
            if (rule.SoftHideLogMessage &&
                string.Equals(rule.Name, decidingRuleName, StringComparison.Ordinal))
            {
                return true;
            }
        }

        return false;
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

    private void RememberLogMessageAllowDecision(ILogMessage message, string? decidingRuleName,
        string? matchDetail = null)
    {
        if (LogMessageHelper.TryExtractText(message, out var allowedText))
        {
            RememberLogMessageChatMatchTexts(_allowedByLogMessage, allowedText);
        }
        RememberLogMessageAllow(message.LogMessageId);

        EmitDebugXllog(
            FormatLogMessageDecision("ALLOWED", decidingRuleName, message.LogMessageId, matchDetail));
    }

    private static string FormatLogMessageDecision(string verb, string? ruleName, uint logMessageId,
        string? matchDetail)
    {
        var line = $"[LogMessage] {verb} by {ruleName} (ID: {logMessageId})";
        return string.IsNullOrEmpty(matchDetail) ? line : $"{line} | {matchDetail}";
    }

    private bool LogMessageRuleApplies(ILogMessage message, LocalizedFilterRule rule, out string? matchDetail)
    {
        if (!TryGetNormalizedLogMessageText(message, out var normalizedText))
        {
            return LogMessageRuleApplies(message.LogMessageId, string.Empty, rule, out matchDetail);
        }

        return LogMessageRuleApplies(message.LogMessageId, normalizedText, rule, out matchDetail);
    }

    private static bool LogMessageRuleApplies(uint logMessageId, string normalizedText, LocalizedFilterRule rule,
        out string? matchDetail)
    {
        matchDetail = null;

        if (LootFilterHelper.ShouldDeferSelfLootRollOrCastLotRule(normalizedText, rule) ||
            LootFilterHelper.ShouldDeferGenericObtainShowRule(normalizedText, rule))
        {
            return false;
        }

        if (rule.Pattern == PatternKind.None)
        {
            if (rule.LogMessageIds?.Contains(logMessageId) == true)
            {
                matchDetail = "ID match";
                return true;
            }

            return false;
        }

        var idMatches = rule.LogMessageIds?.Contains(logMessageId) == true;
        var obtainMarkerRule = ObtainCurrencyHelper.HasObtainMarkerConstraint(rule);

        if (idMatches && rule.ShouldBlock && !obtainMarkerRule && !RuleUsesTextChecks(rule))
        {
            if (LogMessageCatalog.IsLoaded && LogMessageCatalog.HasTemplate(logMessageId))
            {
                matchDetail = "LUMINA template";
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
            LogMessageCatalog.Matches(logMessageId, normalizedText) &&
            !RuleUsesTextChecks(rule))
        {
            matchDetail = "LUMINA catalog";
            return true;
        }

        return RuleMatcher.MatchesText(rule, normalizedText, out matchDetail);
    }

    private static bool RuleUsesTextChecks(LocalizedFilterRule rule) =>
        rule.Pattern switch
        {
            PatternKind.StringMatch => rule.StringChecks is { Count: > 0 },
            PatternKind.RegexMatch => rule.RegexChecks is { Count: > 0 },
            _ => false
        };
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

    private bool TryConsumePendingLogMessageAllow(ChatType chatType, string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(normalizedText))
        {
            return false;
        }

        lock (_logMessageLock)
        {
            if (TryConsumePendingLogMessageAllowFrom(_pendingCustomFilterLogMessageIds, chatType, normalizedText,
                    false))
            {
                return true;
            }

            return TryConsumePendingLogMessageAllowFrom(_pendingAllowedLogMessageIds, chatType, normalizedText,
                true);
        }
    }

    private bool TryConsumePendingLogMessageBlock(ChatType chatType, string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(normalizedText))
        {
            return false;
        }

        lock (_logMessageLock)
        {
            return TryConsumePendingLogMessageBlockFrom(_pendingBlockedLogMessageIds, chatType, normalizedText,
                true);
        }
    }

    private bool TryConsumePendingLogMessageBlockFrom(Dictionary<uint, int> pendingById, ChatType chatType,
        string normalizedText, bool requireShowRuleStillBlock)
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
            if (!PendingLogMessageTextMatches(id, chatType, normalizedText))
            {
                continue;
            }
            if (requireShowRuleStillBlock &&
                (!Rules.LogMessageIdToRules.TryGetValue(id, out var pendingRules) ||
                 !TryResolveLogMessageAllow(id, normalizedText, pendingRules, Configuration, out var shouldAllow,
                     out _, out _) ||
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

    private bool TryConsumePendingLogMessageAllowFrom(Dictionary<uint, int> pendingById, ChatType chatType,
        string normalizedText, bool requireShowRuleAllow)
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
            if (!PendingLogMessageTextMatches(id, chatType, normalizedText))
            {
                continue;
            }
            if (requireShowRuleAllow &&
                (!Rules.LogMessageIdToRules.TryGetValue(id, out var pendingRules) ||
                 !TryResolveLogMessageAllow(id, normalizedText, pendingRules, Configuration, out var stillAllow,
                     out _, out _) ||
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

    private static bool PendingLogMessageTextMatches(uint logMessageId, ChatType chatType, string normalizedText) =>
        LogMessageHelper.PendingTextMatchesOnChannel(logMessageId, chatType, normalizedText);

    private bool TryConsumeInventoryAddedLogMessageBlock(string normalizedText)
    {
        if (!Configuration.HideInventoryItemAdded ||
            !LogMessageHelper.MatchesInventoryAddedLine(normalizedText))
        {
            return false;
        }

        lock (_logMessageLock)
        {
            return TryConsumePendingLogMessageId(_pendingBlockedLogMessageIds,
                LogMessageHelper.InventoryItemAddedLogMessageId);
        }
    }

    private static bool TryConsumePendingLogMessageId(Dictionary<uint, int> pendingById, uint logMessageId)
    {
        if (!pendingById.TryGetValue(logMessageId, out var count) || count <= 0)
        {
            return false;
        }

        if (count == 1)
        {
            pendingById.Remove(logMessageId);
        }
        else
        {
            pendingById[logMessageId] = count - 1;
        }

        return true;
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
    private static bool TryGetNormalizedLogMessageText(ILogMessage message, out string normalizedText) =>
        LogMessageHelper.TryExtractNormalizedText(message, out normalizedText);

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

        if (LogMessageHelper.TryExtractText(message, out var blockedText))
        {
            RememberLogMessageChatMatchTexts(_blockedByLogMessage, blockedText);
        }

        EmitBlockedXllog($"[LogMessage] BLOCKED by tomestone hide (ID: {message.LogMessageId})");
        if (Configuration.EnableDebugMode)
        {
            return true;
        }

        message.PreventOriginal();
        Interlocked.Increment(ref _sessionBlockedMessages);
        return true;
    }

    private bool TryBlockHiddenTribalCurrencyLogMessage(ILogMessage message)
    {
        if (!TryGetNormalizedLogMessageText(message, out var normalizedText))
        {
            return false;
        }

        if (!ObtainCurrencyHelper.ShouldHideTribalCurrency(Configuration, normalizedText, TribalCurrencies,
                Configuration.HideTribalCurrencyById))
        {
            return false;
        }

        if (LogMessageHelper.TryExtractText(message, out var blockedText))
        {
            RememberLogMessageChatMatchTexts(_blockedByLogMessage, blockedText);
        }

        EmitBlockedXllog(
            $"[LogMessage] BLOCKED by allied society currency hide (ID: {message.LogMessageId})");
        if (Configuration.EnableDebugMode)
        {
            return true;
        }

        message.PreventOriginal();
        Interlocked.Increment(ref _sessionBlockedMessages);
        return true;
    }
}
