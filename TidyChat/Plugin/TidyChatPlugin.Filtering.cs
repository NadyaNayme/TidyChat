using Dalamud.Game.Text.SeStringHandling.Payloads;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private LogMessageChatEffect ResolveLogMessageChatEffect(string rawTextValue, string extractedTextValue,
        string normalizedText)
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
            return LogMessageChatEffect.PreserveVisible;
        }

        bool wasBlockedByLog;
        lock (_logMessageLock)
        {
            wasBlockedByLog = _blockedByLogMessage.Count > 0 &&
                              TryRemoveFromLogMessageSet(_blockedByLogMessage, textCandidates);
        }
        if (wasBlockedByLog)
        {
            return LogMessageChatEffect.PreserveHidden;
        }

        if (TryConsumePendingLogMessageAllow(normalizedText))
        {
            return LogMessageChatEffect.PreserveVisible;
        }

        if (TryConsumePendingLogMessageBlock(normalizedText))
        {
            return LogMessageChatEffect.PreserveHidden;
        }

        return LogMessageChatEffect.None;
    }

    private bool FinishChatHandling(IHandleableChatMessage message, ChatType chatType, string rawTextValue,
        string extractedTextValue, string normalizedText, ref bool isHandled, List<string> rulesMatched)
    {
        ApplyFilterOverrides(message, chatType, normalizedText, ref isHandled);
        ApplyWhitelist(message, chatType, rawTextValue, extractedTextValue, normalizedText, ref isHandled);
        if (CheckChatHistory(message, chatType, ref isHandled))
        {
            return true;
        }

        if (chatType is ChatType.Echo)
        {
            isHandled = false;
        }

        if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
        {
            if (Configuration.DebugIncludeChannel || isHandled)
            {
                message.Message = BuildDebugString(chatType, message.Message, rulesMatched, Configuration.DebugIncludeChannel, isHandled);
            }
            isHandled = false;
        }

        if (isHandled)
        {
            Interlocked.Increment(ref _sessionBlockedMessages);
            message.PreventOriginal();
        }

        return false;
    }

    private bool IsProtectedByActiveShowRule(ChatType chatType, string normalizedText, string displayText,
        out List<string> protectingRules)
    {
        protectingRules = [];
        if (CosmicShowRuleHelper.IsCosmicMessageAllowed(Configuration, normalizedText))
        {
            protectingRules.Add(CosmicShowRuleHelper.GetActiveCosmicRuleName(Configuration, normalizedText)!);
            return true;
        }

        if (MarketBoardSaleHelper.ShouldAllowImprovedMarketSale(Configuration, normalizedText, displayText))
        {
            protectingRules.Add(nameof(Configuration.BetterMarketBoardSaleMessage));
            return true;
        }

        Rules.UpdateIsActiveStates(Configuration);
        foreach (var rule in Rules.AllRules)
        {
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
                protectingRules.Add(rule.Name);
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
            (chatType is ChatType.Progress && !Configuration.FilterProgressSpam) ||
            (chatType is ChatType.LootRoll && !Configuration.FilterLootSpam) ||
            (chatType is ChatType.LootNotice && !Configuration.FilterObtainedSpam) ||
            (chatType is ChatType.Gathering or ChatType.GatheringSystem && !Configuration.FilterGatheringSpam) ||
            (chatType is ChatType.Crafting && !Configuration.FilterCraftingSpam))
        {
            if (IsWhitelistedBlocked(message.Sender, message.Message, chatType, rawTextValue, extractedTextValue,
                    normalizedText))
            {
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

            if (!rule.IsActive && !rule.BlockWhenActive && rule.LogMessageIds is { Length: > 0 } &&
                LogMessageCatalog.IsLoaded &&
                LogMessageCatalog.RuleAppliesOnChannel(rule, chatType, normalizedText) &&
                RuleMatcher.MatchesText(rule, normalizedText, false) &&
                !(chatType is ChatType.LootNotice &&
                  ObtainCurrencyHelper.ShouldAllowLootNoticeObtain(Configuration, normalizedText, Tomestones,
                      Configuration.HideTomestoneById)))
            {
                matchedRules.Add(rule.Name);
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

            if (rule.Channel == ChatType.Echo)
            {
                if (RuleMatcher.MatchesText(rule, normalizedText, Configuration.EnableDebugMode))
                {
                    matchedRules.Add(rule.Name);
                }
                else if (Configuration.EnableDebugMode)
                {
                    Log.Debug("/echo message failed to match any rules");
                }
                continue;
            }

            if (RuleMatcher.MatchesText(rule, normalizedText, Configuration.EnableDebugMode))
            {
                if (!CosmicShowRuleHelper.IsCosmicRuleName(rule.Name) &&
                    CosmicShowRuleHelper.ShouldDeferNonCosmicRule(Configuration, normalizedText))
                {
                    if (Configuration.EnableDebugMode)
                    {
                        rulesFailed?.Add(rule.Name);
                    }
                    continue;
                }

                matchedRules.Add(rule.Name);
                if (errorChannelOnlyHideRules)
                {
                    if (rule.BlockWhenActive && rule.IsActive)
                    {
                        isBlocked = true;
                    }
                }
                else
                {
                    isBlocked = chatType is ChatType.LootNotice && !rule.BlockWhenActive
                        ? rule.IsActive
                        : rule.BlockWhenActive
                            ? chatType is ChatType.LootNotice || !defaultBlocked
                                ? !defaultBlocked
                                : defaultBlocked
                            : !defaultBlocked;
                }
            }
            else if (!matchedRules.Contains(rule.Name))
            {
                rulesFailed?.Add(rule.Name);
            }
        }

        if (chatType is ChatType.LootNotice &&
            ObtainCurrencyHelper.ShouldAllowLootNoticeObtain(Configuration, normalizedText, Tomestones,
                Configuration.HideTomestoneById))
        {
            isBlocked = true;
            if (Configuration.EnableDebugMode)
            {
                const string allowTag = "ObtainCurrency (hide off)";
                if (!matchedRules.Contains(allowTag))
                {
                    matchedRules.Add(allowTag);
                }
            }
        }

        if (CosmicShowRuleHelper.IsCosmicMessageAllowed(Configuration, normalizedText))
        {
            isBlocked = chatType is ChatType.LootNotice;
            if (Configuration.EnableDebugMode)
            {
                var cosmicRule = CosmicShowRuleHelper.GetActiveCosmicRuleName(Configuration, normalizedText);
                if (cosmicRule is not null && !matchedRules.Contains(cosmicRule))
                {
                    matchedRules.Add(cosmicRule);
                }
            }
        }

        if (MarketBoardSaleHelper.ShouldAllowImprovedMarketSale(Configuration, normalizedText, message.Message.TextValue))
        {
            isBlocked = false;
            if (Configuration.EnableDebugMode && !matchedRules.Contains(nameof(Configuration.BetterMarketBoardSaleMessage)))
            {
                matchedRules.Add(nameof(Configuration.BetterMarketBoardSaleMessage));
            }
        }

        var isHandled = chatType is ChatType.LootNotice ? !isBlocked : isBlocked;

        if (Configuration.EnableDebugMode && (matchedRules.Count > 0 || isHandled))
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
            Log.Debug($"{(isHandled ? "BLOCKED" : "ALLOWED")}: {message.Message}");
        }

        rulesMatched = matchedRules;
        return isHandled;
    }

    private void ApplyFilterOverrides(IHandleableChatMessage message, ChatType chatType, string normalizedText, ref bool isHandled)
    {
        if (chatType is ChatType.System or ChatType.RetainerSale &&
            MarketBoardSaleHelper.ShouldBlockGilEntrusted(Configuration, normalizedText))
        {
            if (Configuration.EnableDebugMode)
            {
                Log.Debug("BLOCKED (market gil entrusted): " + message.Message);
            }
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
                if (Configuration.EnableDebugMode)
                {
                    Log.Debug($"BLOCKED (non-party loot): {message.Message}");
                }
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

        if (chatType is ChatType.LootNotice &&
            ObtainCurrencyHelper.ShouldHideTomestone(normalizedText, Tomestones, Configuration.HideTomestoneById))
        {
            if (Configuration.EnableDebugMode)
            {
                Log.Debug($"BLOCKED (tomestone): {message.Message}");
            }
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
            ChatType.BattleSystem or
            ChatType.Echo => true,
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
}
