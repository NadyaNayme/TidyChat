using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using TidyChat.Utility;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private bool HandleServerAnnouncements(IHandleableChatMessage message, ChatType chatType, string normalizedText,
        bool protectedByShowRule)
    {
        if (protectedByShowRule) return false;
        if (Configuration.ServerAnnouncementMode == ServerAnnouncementMode.ShowAll) return false;

        bool isWorldGreeting = ServerAnnouncementCatalog.IsWorldGreeting(normalizedText);
        bool isGenericGameWelcome = ServerAnnouncementCatalog.IsGenericGameWelcome(normalizedText);
        bool isAnnouncement = ServerAnnouncementCatalog.IsAnnouncement(normalizedText);
        if (!isWorldGreeting && !isAnnouncement) return false;

        bool isPhishing = ServerAnnouncementCatalog.IsPhishingWarning(normalizedText);
        // Login announcements usually use System; some clients also deliver them on Notice/Urgent (#24).
        if (chatType is not ChatType.System && chatType is not ChatType.Notice and not ChatType.Urgent)
            return false;

        bool withinLoginWindow = DateTime.UtcNow < _serverAnnouncementLoginGraceEnd;
        bool keepGenericGameWelcome =
            Configuration.ServerAnnouncementMode is ServerAnnouncementMode.HidePhishing ||
            (withinLoginWindow && Configuration.ServerAnnouncementMode is ServerAnnouncementMode.LoginOnly
                or ServerAnnouncementMode.LoginThenCondensed);

        bool suppress = Configuration.ServerAnnouncementMode switch
        {
            ServerAnnouncementMode.HideAll => true,
            ServerAnnouncementMode.Condensed => !isWorldGreeting,
            ServerAnnouncementMode.LoginOnly => !withinLoginWindow,
            ServerAnnouncementMode.LoginThenCondensed => !withinLoginWindow && !isWorldGreeting,
            ServerAnnouncementMode.HidePhishing => isPhishing,
            _ => false
        };
        if (isGenericGameWelcome && !keepGenericGameWelcome)
            suppress = true;

        if (suppress)
        {
            if (Configuration.EnableDebugMode)
            {
                Log.Debug($"BLOCKED (server announcement): {message.Message}");
                if (!message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                    message.Message = BuildDebugString(chatType, message.Message, ["ServerAnnouncement"], Configuration.DebugIncludeChannel, true);
                return true;
            }
            message.PreventOriginal();
            Interlocked.Increment(ref _sessionBlockedMessages);
            return true;
        }

        if (Configuration.EnableDebugMode)
        {
            if (!message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                message.Message = BuildDebugString(chatType, message.Message, ["ServerAnnouncement"], Configuration.DebugIncludeChannel, false);
            return true;
        }

        bool isCondensing = Configuration.ServerAnnouncementMode switch
        {
            ServerAnnouncementMode.Condensed => true,
            ServerAnnouncementMode.LoginThenCondensed => !withinLoginWindow,
            ServerAnnouncementMode.HidePhishing => true,
            _ => false
        };
        if (isCondensing && Configuration.IncludeChatTag)
        {
            SeStringBuilder tagBuilder = new();
            Better.AddTidyChatTag(tagBuilder);
            tagBuilder.AddText(message.Message.TextValue);
            message.Message = tagBuilder.BuiltString;
        }

        return true;
    }

    private bool HandleEmoteFilters(IHandleableChatMessage message, ChatType chatType)
    {
        if ((chatType is ChatType.StandardEmote && !Configuration.FilterEmoteChannel) ||
            (chatType is ChatType.CustomEmote && !Configuration.FilterCustomEmoteChannel))
        {
            if (IsWhitelistedBlocked(message.Sender, message.Message, chatType))
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
            if (!IsWhitelistedAllowed(message.Sender, message.Message, chatType))
            {
                if (Configuration.EnableDebugMode) Log.Verbose($"Filtered an emote: {message.Message}");
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
            }
            return true;
        }

        return false;
    }

    private bool HandleTemporaryFilterDisables(string normalizedText)
    {
        if (L10N.Get(ChatRegexStrings.QuestionMarkCommandResponse).IsMatch(normalizedText) && Configuration.FilterSystemMessages)
        {
            Better.TemporarilyDisableSystemFilter(Configuration);
            return true;
        }

        if (L10N.Get(ChatStrings.JoinParty).All(normalizedText.Contains) && Configuration.ShowJoinParty &&
            Configuration is { ShowPartyInformation: true, FilterSystemMessages: true })
        {
            Better.TemporarilyDisableSystemFilter(Configuration);
            return true;
        }

        return false;
    }

    private void TryRewriteMarketBoardSaleMessage(IHandleableChatMessage message, ChatType chatType, string normalizedText)
    {
        if (!Configuration.BetterMarketBoardSaleMessage) return;
        if (chatType is not ChatType.System and not ChatType.RetainerSale) return;
        if (!LogMessageCatalog.MatchesWithFallback(748, normalizedText, ChatStrings.MarketItemSold) &&
            !L10N.Get(ChatRegexStrings.MarketItemSold).IsMatch(normalizedText))
            return;

        if (Better.MarketItemSold(message.Message, Configuration, normalizedText) is SeString rewritten)
            message.Message = rewritten;
    }

    private bool HandleBetterMessages(IHandleableChatMessage message, ChatType chatType, string normalizedText)
    {
        if (Configuration.BetterDutyCommenceMessage && chatType is ChatType.System &&
            LogMessageCatalog.MatchesWithFallback(1531, normalizedText, ChatStrings.DutyHasBegun))
        {
            message.Message = Better.DutyCommence(message.Message, Configuration, normalizedText);
            return true;
        }

        if (Configuration.BetterInstanceMessage && chatType is ChatType.System &&
            LogMessageCatalog.MatchesWithFallback(1350, normalizedText, ChatStrings.InstancedArea))
        {
            message.Message = Better.Instances(message.Message, Configuration);
            if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(Configuration);
            return true;
        }

        if (Configuration.BetterCommendationMessage && chatType is ChatType.System &&
            LogMessageCatalog.MatchesWithFallback(926, normalizedText, ChatStrings.PlayerCommendation))
        {
            message.PreventOriginal();
            Interlocked.Increment(ref _sessionBlockedMessages);
            return true;
        }

        if (Configuration.BetterSayReminder &&
            chatType is ChatType.System &&
            L10N.Get(ChatStrings.SayQuestReminder).All(normalizedText.Contains))
        {
            message.Message = Better.SayReminder(message.Message, Configuration);
            return true;
        }

        if (Configuration.BetterTreasureDungeonMessage && chatType is ChatType.System)
        {
            if (L10N.Get(ChatRegexStrings.ChamberOpens).IsMatch(normalizedText))
            {
                Match match = L10N.Get(ChatRegexStrings.ChamberOpens).Match(normalizedText);
                if (match.Groups["chamber"].Success)
                    TidyStrings.LastTreasureDungeonChamber = match.Groups["chamber"].Value;
                return true;
            }
            if (L10N.Get(ChatRegexStrings.TrapTriggered).IsMatch(normalizedText))
            {
                if (TidyStrings.LastTreasureDungeonChamber.Length > 0)
                    message.Message = Better.TreasureDungeon(Configuration);
                return true;
            }
        }

        if (Configuration.NormalizeBlocks &&
            (Configuration.AlwaysNormalizeBlocks || chatType is not ChatType.Party and not ChatType.Alliance))
            message.Message = DeblockMessage(message.Message);

        if (Configuration.EnableSmolMode)
            message.Message = SmolMessage(message.Message);

        return false;
    }

    private bool CheckLogMessageDecision(IHandleableChatMessage message, ChatType chatType, string rawTextValue, string extractedTextValue, string normalizedText)
    {
        string[] textCandidates = [rawTextValue, extractedTextValue, normalizedText];

        bool wasAllowedByLog;
        lock(_logMessageLock)
        {
            wasAllowedByLog = _allowedByLogMessage.Count > 0 &&
                              TryRemoveFromLogMessageSet(_allowedByLogMessage, textCandidates);
        }
        if (wasAllowedByLog)
        {
            if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                message.Message = BuildDebugString(chatType, message.Message, ["LogMessage"], Configuration.DebugIncludeChannel, false);
            return true;
        }

        bool wasBlockedByLog;
        lock(_logMessageLock)
        {
            wasBlockedByLog = _blockedByLogMessage.Count > 0 &&
                              TryRemoveFromLogMessageSet(_blockedByLogMessage, textCandidates);
        }
        if (wasBlockedByLog)
        {
            if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                message.Message = BuildDebugString(chatType, message.Message, ["LogMessage"], Configuration.DebugIncludeChannel, true);
            return true;
        }

        if (TryConsumePendingLogMessageAllow(normalizedText))
        {
            if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                message.Message = BuildDebugString(chatType, message.Message, ["LogMessage"], Configuration.DebugIncludeChannel, false);
            return true;
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
        foreach(LocalizedFilterRule rule in Rules.AllRules)
        {
            if (rule.ShouldBlock) continue;
            if (!LogMessageCatalog.RuleAppliesOnChannel(rule, chatType, normalizedText)) continue;
            if (RuleMatchesText(rule, normalizedText, false))
                protectingRules.Add(rule.Name);
        }

        return protectingRules.Count > 0;
    }
    private bool? EvaluateChannelRules(IHandleableChatMessage message, ChatType chatType, string normalizedText, out List<string> rulesMatched)
    {
        rulesMatched = [];
        Rules.UpdateIsActiveStates(Configuration);
        LocalizedFilterRule[] rules = Rules.AllRules;

        bool isBlocked = ChannelIsSpammy(chatType);
        bool errorChannelOnlyHideRules = chatType is ChatType.Error;
        if (errorChannelOnlyHideRules)
            isBlocked = false;

        if ((chatType is ChatType.System or ChatType.RetainerSale && !Configuration.FilterSystemMessages) ||
            (chatType is ChatType.Progress && !Configuration.FilterProgressSpam) ||
            (chatType is ChatType.LootRoll && !Configuration.FilterLootSpam) ||
            (chatType is ChatType.LootNotice && !Configuration.FilterObtainedSpam) ||
            (chatType is ChatType.Gathering or ChatType.GatheringSystem && !Configuration.FilterGatheringSpam) ||
            (chatType is ChatType.Crafting && !Configuration.FilterCraftingSpam))
        {
            if (IsWhitelistedBlocked(message.Sender, message.Message, chatType))
            {
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
            }
            return null; // sentinel: caller should return immediately
        }

        bool showEverythingElse = false;
        if ((chatType is ChatType.System or ChatType.RetainerSale && Configuration.ShowEverythingElse) ||
            (chatType is ChatType.Crafting && Configuration.ShowAllOtherCrafting) ||
            (chatType is ChatType.Gathering or ChatType.GatheringSystem && Configuration.ShowAllOtherGathering))
        {
            isBlocked = !isBlocked;
            showEverythingElse = true;
        }
        bool defaultBlocked = isBlocked;

        List<string>? rulesSkipped = Configuration.EnableDebugMode ? [] : null;
        List<string>? rulesFailed = Configuration.EnableDebugMode ? [] : null;
        foreach(LocalizedFilterRule rule in rules)
        {
            if (rule.Error is not null) Log.Error($"Error: {rule.Error}");

            if (!rule.IsActive && !rule.BlockWhenActive && rule.LogMessageIds is { Length: > 0 } &&
                LogMessageCatalog.IsLoaded &&
                LogMessageCatalog.MatchesAny(rule.LogMessageIds, normalizedText) &&
                LogMessageCatalog.RuleAppliesOnChannel(rule, chatType, normalizedText))
            {
                rulesMatched.Add(rule.Name);
                isBlocked = chatType is not ChatType.LootNotice;
                if (Configuration.EnableDebugMode)
                    Log.Verbose($"BLOCKING CHECK: {rule.Name} is off for this LogMessage line");
                continue;
            }

            if (rule.IsActive == showEverythingElse &&
                !(chatType is ChatType.LootNotice && !rule.BlockWhenActive))
            {
                if (Configuration.EnableDebugMode) Log.Verbose($"SKIPPING CHECK: {rule.Name} is {(showEverythingElse ? "active" : "inactive")}");
                rulesSkipped?.Add(rule.Name);
                continue;
            }
            if (!LogMessageCatalog.RuleAppliesOnChannel(rule, chatType, normalizedText))
            {
                if (Configuration.EnableDebugMode) Log.Verbose($"SKIPPING CHECK: Message was sent to {chatType} but the rule's filter is for {rule.Channel}");
                rulesSkipped?.Add(rule.Name);
                continue;
            }

            if (rule.Channel == ChatType.Echo)
            {
                if (RuleMatchesText(rule, normalizedText, Configuration.EnableDebugMode))
                    rulesMatched.Add(rule.Name);
                else if (Configuration.EnableDebugMode)
                    Log.Debug("/echo message failed to match any rules");
                continue;
            }

            if (RuleMatchesText(rule, normalizedText, Configuration.EnableDebugMode))
            {
                if (!CosmicShowRuleHelper.IsCosmicRuleName(rule.Name) &&
                    CosmicShowRuleHelper.ShouldDeferNonCosmicRule(Configuration, normalizedText))
                {
                    if (Configuration.EnableDebugMode) rulesFailed?.Add(rule.Name);
                    continue;
                }

                rulesMatched.Add(rule.Name);
                if (errorChannelOnlyHideRules)
                {
                    if (rule.BlockWhenActive && rule.IsActive)
                        isBlocked = true;
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
            else if (rulesMatched is null || !rulesMatched.Contains(rule.Name))
            {
                rulesFailed?.Add(rule.Name);
            }
        }

        if (CosmicShowRuleHelper.IsCosmicMessageAllowed(Configuration, normalizedText))
        {
            isBlocked = chatType is ChatType.LootNotice;
            if (Configuration.EnableDebugMode)
            {
                string? cosmicRule = CosmicShowRuleHelper.GetActiveCosmicRuleName(Configuration, normalizedText);
                if (cosmicRule is not null && !rulesMatched.Contains(cosmicRule))
                    rulesMatched.Add(cosmicRule);
            }
        }

        if (MarketBoardSaleHelper.ShouldAllowImprovedMarketSale(Configuration, normalizedText, message.Message.TextValue))
        {
            isBlocked = false;
            if (Configuration.EnableDebugMode && !rulesMatched.Contains(nameof(Configuration.BetterMarketBoardSaleMessage)))
                rulesMatched.Add(nameof(Configuration.BetterMarketBoardSaleMessage));
        }

        bool isHandled = chatType is ChatType.LootNotice ? !isBlocked : isBlocked;

        if (Configuration.EnableDebugMode && (rulesMatched.Count > 0 || isHandled))
        {
            Log.Debug($"{rulesMatched.Count} Rules Matched: {string.Join(", ", rulesMatched)}");
            if (rulesSkipped!.Count > 0)
                Log.Debug($"{rulesSkipped.Count} Rules Skipped: {string.Join(", ", rulesSkipped)}");
            if (rulesFailed!.Count > 0)
                Log.Debug($"{rulesFailed.Count} Rules Failed: {string.Join(", ", rulesFailed)}");
            Log.Debug($"{(isHandled ? "BLOCKED" : "ALLOWED")}: {message.Message}");
        }

        return isHandled;
    }

    private void ApplyFilterOverrides(IHandleableChatMessage message, ChatType chatType, string normalizedText, ref bool isHandled)
    {
        if (chatType is ChatType.System or ChatType.RetainerSale &&
            MarketBoardSaleHelper.ShouldBlockGilEntrusted(Configuration, normalizedText))
        {
            if (Configuration.EnableDebugMode)
                Log.Debug("BLOCKED (market gil entrusted): " + message.Message);
            isHandled = true;
        }

        if (chatType is ChatType.CustomEmote &&
            string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
        {
            if (Configuration.EnableDebugMode) Log.Information("Allowing custom emote used by player");
            isHandled = false;
        }

        if (!Configuration.ShowSelfUsedEmotes &&
            chatType is ChatType.StandardEmote or ChatType.CustomEmote &&
            string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
            isHandled = true;

        if (chatType is ChatType.LootRoll && !isHandled &&
            Configuration.ShowOnlyPartyMemberRolls && PartyList.Length > 0)
        {
            bool isPlayerMessage = normalizedText.StartsWith("you ", StringComparison.Ordinal);
            bool isPartyMember = isPlayerMessage || PartyList.Any(member =>
                normalizedText.StartsWith(
                    member.Name.TextValue.ToLower(CultureInfo.InvariantCulture) + " ",
                    StringComparison.Ordinal));
            if (!isPartyMember)
            {
                if (Configuration.EnableDebugMode) Log.Debug($"BLOCKED (non-party loot): {message.Message}");
                isHandled = true;
            }
        }

        if (chatType is ChatType.Gathering && isHandled && Configuration.ShowFishingFlavorText &&
            FishingFlavorMessages.Count > 0 && FishingFlavorMessages.Contains(normalizedText))
        {
            if (Configuration.EnableDebugMode) Log.Debug($"ALLOWED (fishing flavor): {message.Message}");
            isHandled = false;
        }

        if (chatType is ChatType.LootNotice &&
            TomestoneHideHelper.ShouldHide(normalizedText, Tomestones, Configuration.HideTomestoneById))
        {
            if (Configuration.EnableDebugMode) Log.Debug($"BLOCKED (tomestone): {message.Message}");
            isHandled = true;
        }
    }
    private static bool ChannelIsSpammy(ChatType chatType)
    {
        return chatType switch
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
    }

    private static bool ChannelCanBeFiltered(ChatType chatType)
    {
        if (ChannelIsSpammy(chatType)) return true;
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
        List<Payload> payloads = msg.Payloads;
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
                foreach(int i in textPayload.Text)
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
        List<Payload> payloads = msg.Payloads;
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
                foreach(int i in textPayload.Text)
                {
                    char c = i switch
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
}
