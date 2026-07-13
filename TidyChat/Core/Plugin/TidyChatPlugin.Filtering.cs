using Dalamud.Game.Text.SeStringHandling.Payloads;
using System.Text;
using System.Threading;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private static void TrackMatchedRule(List<string> matchedRules, string ruleName)
    {
        if (!matchedRules.Contains(ruleName))
        {
            matchedRules.Add(ruleName);
        }
    }

    private LogMessageChatSyncResult ResolveLogMessageChatEffect(ChatType chatType, string rawTextValue,
        string extractedTextValue, string normalizedText)
    {
        string[] textCandidates = [rawTextValue, extractedTextValue, normalizedText];

        bool wasAllowedByLog;
        lock (_logMessageLock)
        {
            wasAllowedByLog = _allowedByLogMessage.Count > 0 &&
                              TryRemoveFromLogMessageSet(_allowedByLogMessage, textCandidates);
        }
        if (wasAllowedByLog)
        {
            return new(LogMessageChatEffect.PreserveVisible, "LogMessage");
        }

        bool wasBlockedByLog;
        string? blockedByRuleName = null;
        lock (_logMessageLock)
        {
            wasBlockedByLog = _blockedByLogMessage.Count > 0 &&
                              TryRemoveFromLogMessageSet(_blockedByLogMessage, textCandidates,
                                  _logMessageBlockRuleByText, out blockedByRuleName);
        }
        if (wasBlockedByLog)
        {
            if (Configuration.ShowObtainedItems && ObtainCurrencyHelper.IsGenericItemObtainLine(normalizedText))
            {
                return new(LogMessageChatEffect.None, null);
            }

            return new(LogMessageChatEffect.PreserveHidden, blockedByRuleName ?? "LogMessage");
        }

        if (TryConsumeInventoryAddedLogMessageBlock(normalizedText, out var inventoryRuleName))
        {
            return new(LogMessageChatEffect.PreserveHidden, inventoryRuleName);
        }

        if (TryConsumePendingLogMessageAllow(chatType, normalizedText))
        {
            return new(LogMessageChatEffect.PreserveVisible, "LogMessage");
        }

        if (TryConsumePendingLogMessageBlock(chatType, normalizedText, out var pendingBlockRuleName))
        {
            return new(LogMessageChatEffect.PreserveHidden, pendingBlockRuleName);
        }

        return new(LogMessageChatEffect.None, null);
    }

    private static List<string> LogMessageDebugRules(string? ruleName) =>
        string.IsNullOrEmpty(ruleName) ? ["LogMessage"] : [ruleName];

    private bool FinishChatHandling(IHandleableChatMessage message, ChatType chatType, string rawTextValue,
        string extractedTextValue, string normalizedText, ref bool isHandled, List<string> rulesMatched)
    {
        ApplyFilterOverrides(message, chatType, normalizedText, ref isHandled, rulesMatched);
        var handledBeforeWhitelist = isHandled;
        ApplyWhitelist(message, chatType, rawTextValue, extractedTextValue, normalizedText, ref isHandled);
        if (handledBeforeWhitelist != isHandled)
        {
            TrackMatchedRule(rulesMatched, isHandled ? "CustomFilter (Block)" : "CustomFilter (Allow)");
        }
        if (chatType is ChatType.Echo)
        {
            isHandled = false;
            TrackMatchedRule(rulesMatched, EchoPassthroughRuleName);
        }

        if (CheckChatHistory(message, chatType, ref isHandled, rulesMatched))
        {
            return true;
        }

        if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
        {
            if (Configuration.DebugIncludeChannel || isHandled)
            {
                message.Message = BuildDebugString(chatType, message.Message, rulesMatched, Configuration.DebugIncludeChannel, isHandled);
            }
            isHandled = false;
        }

        if (!isHandled)
        {
            TryApplyChatHighlight(message, chatType, rawTextValue, extractedTextValue, normalizedText);
        }

        if (isHandled)
        {
            Interlocked.Increment(ref _sessionBlockedMessages);
            LogBlockedChat(rulesMatched, message.Message.TextValue);
            message.PreventOriginal();
        }

        return false;
    }

    private bool IsProtectedByActiveShowRule(ChatType chatType, string normalizedText, string displayText,
        out List<string> protectingRules)
    {
        protectingRules = [];
        if (CosmicExplorationFilterHelper.IsCosmicMessageAllowed(Configuration, normalizedText))
        {
            TrackMatchedRule(protectingRules, CosmicExplorationFilterHelper.GetActiveCosmicRuleName(Configuration, normalizedText)!);
            return true;
        }

        if (MarketBoardSaleHelper.ShouldAllowImprovedMarketSale(Configuration, normalizedText, displayText))
        {
            TrackMatchedRule(protectingRules, nameof(Configuration.BetterMarketBoardSaleMessage));
            return true;
        }

        Rules.UpdateIsActiveStates(Configuration);
        foreach (var rule in Rules.AllRules)
        {
            if (FilterMasterAccessors.IsDisabledByMasterToggle(rule, Configuration))
            {
                continue;
            }

            if (rule.ShouldBlock)
            {
                continue;
            }
            if (!LogMessageCatalog.RuleAppliesOnChannel(rule, chatType, normalizedText))
            {
                continue;
            }
            if (RuleMatcher.MatchesText(rule, normalizedText, false))
            {
                TrackMatchedRule(protectingRules, rule.Name);
            }
        }

        return protectingRules.Count > 0;
    }
    private bool? EvaluateChannelRules(IHandleableChatMessage message, ChatType chatType, string rawTextValue,
        string extractedTextValue, string normalizedText, out List<string> rulesMatched)
    {
        var matchedRules = new List<string>();
        Rules.UpdateIsActiveStates(Configuration);
        var rules = Rules.AllRules;

        var isBlocked = ChannelIsSpammy(chatType);
        var errorChannelOnlyHideRules = chatType is ChatType.Error;
        if (errorChannelOnlyHideRules)
        {
            isBlocked = false;
        }

        if ((chatType is ChatType.System or ChatType.RetainerSale && !Configuration.FilterSystemMessages) ||
            (chatType is ChatType.Progress or ChatType.BattleSystem && !Configuration.FilterProgressSpam) ||
            (chatType is ChatType.LootRoll && !Configuration.FilterLootSpam) ||
            (chatType is ChatType.LootNotice && !Configuration.FilterObtainedSpam) ||
            (chatType is ChatType.Gathering or ChatType.GatheringSystem && !Configuration.FilterGatheringSpam) ||
            (chatType is ChatType.Crafting && !Configuration.FilterCraftingSpam))
        {
            if (IsWhitelistedBlocked(message.Sender, message.Message, chatType, rawTextValue, extractedTextValue,
                    normalizedText))
            {
                LogBlockedChat(["CustomFilter (Block)"], message.Message.TextValue);
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
            }
            rulesMatched = matchedRules;
            return null; // sentinel: caller should return immediately
        }

        var showEverythingElse = false;
        if ((chatType is ChatType.System or ChatType.RetainerSale && Configuration.ShowEverythingElse) ||
            (chatType is ChatType.Crafting && Configuration.ShowAllOtherCrafting) ||
            (chatType is ChatType.Gathering or ChatType.GatheringSystem && Configuration.ShowAllOtherGathering))
        {
            isBlocked = !isBlocked;
            showEverythingElse = true;
        }
        var defaultBlocked = isBlocked;

        List<string>? rulesSkipped = Configuration.EnableDebugMode ? [] : null;
        List<string>? rulesFailed = Configuration.EnableDebugMode ? [] : null;
        foreach (var rule in rules)
        {
            if (rule.Error is not null)
            {
                Log.Error($"Error: {rule.Error}");
            }

            if (FilterMasterAccessors.IsDisabledByMasterToggle(rule, Configuration))
            {
                rulesSkipped?.Add(rule.Name);
                continue;
            }

            if (!rule.IsActive && !rule.BlockWhenActive && rule.LogMessageIds is { Length: > 0 } &&
                LogMessageCatalog.IsLoaded &&
                LogMessageCatalog.RuleAppliesOnChannel(rule, chatType, normalizedText) &&
                RuleMatcher.MatchesText(rule, normalizedText, false) &&
                !ObtainCurrencyHelper.ShouldDeferObtainRuleToGeneral(Configuration, rule, normalizedText) &&
                !(chatType is ChatType.LootNotice &&
                  ObtainCurrencyHelper.ShouldAllowLootNoticeObtain(Configuration, normalizedText, Tomestones,
                      Configuration.HideTomestoneById, TribalCurrencies, Configuration.HideTribalCurrencyById)))
            {
                if (errorChannelOnlyHideRules)
                {
                    continue;
                }

                TrackMatchedRule(matchedRules, rule.Name);
                isBlocked = chatType is not ChatType.LootNotice;
                if (Configuration.EnableDebugMode)
                {
                    Log.Verbose($"BLOCKING CHECK: {rule.Name} is off for this LogMessage line");
                }
                continue;
            }

            if (rule.IsActive == showEverythingElse &&
                !(chatType is ChatType.LootNotice && !rule.BlockWhenActive))
            {
                if (Configuration.EnableDebugMode)
                {
                    Log.Verbose($"SKIPPING CHECK: {rule.Name} is {(showEverythingElse ? "active" : "inactive")}");
                }
                rulesSkipped?.Add(rule.Name);
                continue;
            }
            if (!LogMessageCatalog.RuleAppliesOnChannel(rule, chatType, normalizedText))
            {
                if (Configuration.EnableDebugMode)
                {
                    Log.Verbose($"SKIPPING CHECK: Message was sent to {chatType} but the rule's filter is for {rule.Channel}");
                }
                rulesSkipped?.Add(rule.Name);
                continue;
            }

            if (RuleMatcher.MatchesText(rule, normalizedText, out _))
            {
                if (ObtainCurrencyHelper.ShouldDeferObtainRuleToGeneral(Configuration, rule, normalizedText))
                {
                    if (Configuration.EnableDebugMode)
                    {
                        rulesFailed?.Add(rule.Name);
                    }
                    continue;
                }

                if (!CosmicExplorationFilterHelper.IsCosmicRuleName(rule.Name) &&
                    !CosmicExplorationFilterHelper.IsStellarGpRuleName(rule.Name) &&
                    (CosmicExplorationFilterHelper.ShouldDeferNonCosmicRule(Configuration, normalizedText) ||
                     CosmicExplorationFilterHelper.ShouldDeferToStellarGpRecovery(Configuration, normalizedText) ||
                     LootFilterHelper.ShouldDeferSelfLootRollOrCastLotRule(normalizedText, rule) ||
                     LootFilterHelper.ShouldDeferGenericObtainShowRule(normalizedText, rule)))
                {
                    if (Configuration.EnableDebugMode)
                    {
                        rulesFailed?.Add(rule.Name);
                    }
                    continue;
                }

                TrackMatchedRule(matchedRules, rule.Name);
                if (errorChannelOnlyHideRules)
                {
                    if (rule.BlockWhenActive && rule.IsActive)
                    {
                        isBlocked = true;
                    }
                }
                else if (chatType is ChatType.LootNotice && !rule.BlockWhenActive)
                {
                    // LootNotice show-rules use the rule's IsActive directly (active = show, inactive = hide).
                    isBlocked = rule.IsActive;
                }
                else if (rule.BlockWhenActive)
                {
                    // Hide-rule matched: keep the message unless the channel default was already hiding it on LootNotice.
                    isBlocked = chatType is not ChatType.LootNotice || !defaultBlocked;
                }
                else
                {
                    // Show-rule matched: allow the line. Spammy channels default to hidden (flip via false);
                    // non-spammy combat channels (GainBuff, etc.) also land here — !defaultBlocked was wrong
                    // and hid lines when a show toggle was enabled.
                    isBlocked = false;
                }
            }
            else if (!matchedRules.Contains(rule.Name))
            {
                rulesFailed?.Add(rule.Name);
            }
        }

        if (chatType is ChatType.LootNotice &&
            ObtainCurrencyHelper.ShouldAllowLootNoticeObtain(Configuration, normalizedText, Tomestones,
                Configuration.HideTomestoneById, TribalCurrencies, Configuration.HideTribalCurrencyById))
        {
            isBlocked = true;
            if (Configuration.EnableDebugMode)
            {
                var allowRule = ObtainCurrencyHelper.GetAllowBecauseHideOffRuleName(Configuration, normalizedText) ??
                                "ObtainCurrency";
                TrackMatchedRule(matchedRules, $"{allowRule} (hide off)");
            }
        }

        if (CosmicExplorationFilterHelper.IsCosmicMessageAllowed(Configuration, normalizedText))
        {
            isBlocked = chatType is ChatType.LootNotice;
            if (Configuration.EnableDebugMode)
            {
                var cosmicRule = CosmicExplorationFilterHelper.GetActiveCosmicRuleName(Configuration, normalizedText);
                if (cosmicRule is not null)
                {
                    TrackMatchedRule(matchedRules, cosmicRule);
                }
            }
        }

        if (CosmicExplorationFilterHelper.IsGpRecoveryAllowed(Configuration, normalizedText))
        {
            isBlocked = chatType is ChatType.LootNotice;
            if (Configuration.EnableDebugMode)
            {
                TrackMatchedRule(matchedRules, "ShowStellarGpRecovery");
            }
        }

        if (MarketBoardSaleHelper.ShouldAllowImprovedMarketSale(Configuration, normalizedText, message.Message.TextValue))
        {
            isBlocked = false;
            if (Configuration.EnableDebugMode)
            {
                TrackMatchedRule(matchedRules, nameof(Configuration.BetterMarketBoardSaleMessage));
            }
        }

        if (LootFilterHelper.ShouldShowOtherPlayerObtain(Configuration, chatType, normalizedText))
        {
            isBlocked = chatType is ChatType.LootNotice;
            if (Configuration.EnableDebugMode)
            {
                TrackMatchedRule(matchedRules, "HideOthersObtain (show on)");
            }
        }
        else if (chatType is ChatType.LootRoll &&
                 LootFilterHelper.ShouldShowOtherPlayerLootRoll(Configuration, 1231, normalizedText))
        {
            isBlocked = false;
            if (Configuration.EnableDebugMode)
            {
                TrackMatchedRule(matchedRules, "ShowOthersLootRoll");
            }
        }
        else if (chatType is ChatType.LootRoll &&
                 LootFilterHelper.ShouldShowOtherPlayerCastLot(Configuration, 5180, normalizedText))
        {
            isBlocked = false;
            if (Configuration.EnableDebugMode)
            {
                TrackMatchedRule(matchedRules, "ShowOthersCastLot");
            }
        }

        if (PluginChatPassthroughHelper.ShouldAllow(message.SourceKind, message.TargetKind))
        {
            var allowedIsBlocked = chatType is ChatType.LootNotice;
            if (isBlocked != allowedIsBlocked)
            {
                isBlocked = allowedIsBlocked;
                TrackMatchedRule(matchedRules, PluginChatPassthroughHelper.PassthroughRuleName);
            }
        }

        var isHandled = chatType is ChatType.LootNotice ? !isBlocked : isBlocked;

        if (Configuration.EnableDebugMode && matchedRules.Count > 0)
        {
            Log.Debug($"{matchedRules.Count} Rules Matched: {string.Join(", ", matchedRules)}");
            if (rulesSkipped!.Count > 0)
            {
                Log.Debug($"{rulesSkipped.Count} Rules Skipped: {string.Join(", ", rulesSkipped)}");
            }
            if (rulesFailed!.Count > 0)
            {
                Log.Debug($"{rulesFailed.Count} Rules Failed: {string.Join(", ", rulesFailed)}");
            }
        }

        if (Configuration.EnableDebugMode && !isHandled)
        {
            Log.Debug($"ALLOWED: {message.Message}");
        }

        rulesMatched = matchedRules;
        return isHandled;
    }

    private void ApplyFilterOverrides(IHandleableChatMessage message, ChatType chatType, string normalizedText,
        ref bool isHandled, List<string> rulesMatched)
    {
        if (chatType is ChatType.System or ChatType.RetainerSale &&
            MarketBoardSaleHelper.ShouldBlockGilEntrusted(Configuration, normalizedText))
        {
            TrackMatchedRule(rulesMatched, "MarketGilEntrusted");
            isHandled = true;
        }

        if (chatType is ChatType.CustomEmote &&
            string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
        {
            if (Configuration.EnableDebugMode)
            {
                Log.Information("Allowing custom emote used by player");
            }
            isHandled = false;
        }

        if (!Configuration.ShowSelfUsedEmotes &&
            chatType is ChatType.StandardEmote or ChatType.CustomEmote &&
            string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
        {
            TrackMatchedRule(rulesMatched, "HideSelfUsedEmotes");
            isHandled = true;
        }

        if (chatType is ChatType.LootRoll && !isHandled &&
            FilterMasterAccessors.OnlyPartyMemberLootRolls(Configuration) && PartyList.Length > 0)
        {
            var isPlayerMessage = normalizedText.StartsWith("you ", StringComparison.Ordinal);
            var isPartyMember = isPlayerMessage || PartyList.Any(member =>
                normalizedText.StartsWith(
                    member.Name.TextValue.ToLower(CultureInfo.InvariantCulture) + " ",
                    StringComparison.Ordinal));
            if (!isPartyMember)
            {
                TrackMatchedRule(rulesMatched, "OnlyPartyMemberLootRolls");
                isHandled = true;
            }
        }

        if (chatType is ChatType.Gathering && isHandled && Configuration.ShowFishingFlavorText &&
            FishingFlavorMessages.Count > 0 && FishingFlavorMessages.Contains(normalizedText))
        {
            if (Configuration.EnableDebugMode)
            {
                Log.Debug($"ALLOWED (fishing flavor): {message.Message}");
            }
            isHandled = false;
        }

        if (ObtainCurrencyHelper.ShouldHideTomestone(normalizedText, Tomestones, Configuration.HideTomestoneById))
        {
            TrackMatchedRule(rulesMatched, "HideTomestone");
            isHandled = true;
        }

        if (Configuration.HideTomestoneWeeklyCap &&
            ObtainCurrencyHelper.IsTomestoneWeeklyCapMessage(normalizedText))
        {
            TrackMatchedRule(rulesMatched, "HideTomestoneWeeklyCap");
            isHandled = true;
        }

        if (chatType is ChatType.LootNotice &&
            ObtainCurrencyHelper.ShouldHideTribalCurrency(Configuration, normalizedText, TribalCurrencies,
                Configuration.HideTribalCurrencyById))
        {
            TrackMatchedRule(rulesMatched, "HideTribalCurrency");
            isHandled = true;
        }
    }
    private static bool ChannelIsSpammy(ChatType chatType) => chatType switch
    {
        ChatType.System or
            ChatType.RetainerSale or
            ChatType.StandardEmote or
            ChatType.CustomEmote or
            ChatType.Crafting or
            ChatType.Gathering or
            ChatType.GatheringSystem or
            ChatType.LootNotice or
            ChatType.LootRoll or
            ChatType.Progress or
            ChatType.FreeCompanyLoginLogout or
            ChatType.GlamourNotifications or
            ChatType.BattleSystem => true,
        _ => false
    };

    private static bool ChannelCanBeFiltered(ChatType chatType)
    {
        if (ChannelIsSpammy(chatType))
        {
            return true;
        }
        return chatType switch
        {
            ChatType.Item or
                ChatType.Action or
                ChatType.Damage or
                ChatType.Miss or
                ChatType.Healing or
                ChatType.GainBuff or
                ChatType.GainDebuff or
                ChatType.LoseBuff or
                ChatType.LoseDebuff or
                ChatType.FreeCompanyAnnouncement or
                ChatType.MessageBook or
                ChatType.Error or
                ChatType.Say or
                ChatType.Shout or
                ChatType.Yell or
                ChatType.TellIncoming or
                ChatType.PvpTeam or
                ChatType.NoviceNetwork or
                ChatType.NoviceNetworkSystem or
                ChatType.FreeCompany or
                ChatType.PeriodicRecruitmentNotification or
                ChatType.Party or
                ChatType.CrossParty or
                ChatType.Alliance or
                ChatType.Linkshell1 or
                ChatType.Linkshell2 or
                ChatType.Linkshell3 or
                ChatType.Linkshell4 or
                ChatType.Linkshell5 or
                ChatType.Linkshell6 or
                ChatType.Linkshell7 or
                ChatType.Linkshell8 or
                ChatType.CrossLinkshell1 or
                ChatType.CrossLinkshell2 or
                ChatType.CrossLinkshell3 or
                ChatType.CrossLinkshell4 or
                ChatType.CrossLinkshell5 or
                ChatType.CrossLinkshell6 or
                ChatType.CrossLinkshell7 or
                ChatType.CrossLinkshell8 or
                ChatType.Orchestrion => true,
            _ => false
        };
    }

    private static SeString SmolMessage(SeString msg)
    {
        var payloads = msg.Payloads;
        SeStringBuilder stringBuilder = new();
        payloads.ForEach(payload =>
        {
            if (payload.Type is not PayloadType.RawText)
            {
                stringBuilder.Add(payload);
            }
            else if (payload is TextPayload { Text: not null } textPayload)
            {
                var sb = new StringBuilder(textPayload.Text.Length);
                foreach (int i in textPayload.Text)
                {
                    sb.Append(i is >= 65 and <= 90
                        ? (char)(i + 32) // 65='A', 90='Z' (91='[', not a letter)
                        : (char)i);
                }
                stringBuilder.AddText(sb.ToString());
            }
        });
        msg = stringBuilder.Build();
        msg.EncodeWithNullTerminator();
        return msg;
    }

    private static SeString DeblockMessage(SeString msg)
    {
        var payloads = msg.Payloads;
        SeStringBuilder stringBuilder = new();
        payloads.ForEach(payload =>
        {
            if (payload.Type is not PayloadType.RawText)
            {
                stringBuilder.Add(payload);
            }
            else if (payload is TextPayload { Text: not null } textPayload)
            {
                var sb = new StringBuilder(textPayload.Text.Length);
                foreach (int i in textPayload.Text)
                {
                    var c = i switch
                    {
                        >= 57457 and <= 57483 => (char)(i - 57392), // A-Z Blocks
                        >= 57487 and <= 57496 => (char)(i - 57439), // Number Blocks
                        >= 57521 and <= 57529 => (char)(i - 57472), // Hexgonical Numbers
                        >= 57440 and <= 57449 => (char)(i - 57392), // Monospace Numbers
                        _ => (char)i
                    };
                    sb.Append(c);
                }
                stringBuilder.AddText(sb.ToString());
            }
        });
        msg = stringBuilder.Build();
        msg.EncodeWithNullTerminator();
        return msg;
    }

    private enum LogMessageChatEffect
    {
        None,
        PreserveVisible,
        PreserveHidden
    }

    private readonly record struct LogMessageChatSyncResult(LogMessageChatEffect Effect, string? DecidingRuleName);
}
