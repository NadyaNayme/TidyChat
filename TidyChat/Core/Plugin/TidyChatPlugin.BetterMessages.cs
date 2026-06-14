using System.Threading;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private bool HandleTemporaryFilterDisables(string normalizedText)
    {
        if (L10N.Get(ChatStrings.QuestionMarkCommandResponse).IsMatch(normalizedText) && Configuration.FilterSystemMessages)
        {
            Better.TemporarilyDisableSystemFilter(Configuration);
            return true;
        }

        if (TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.JoinParty) && Configuration.ShowJoinParty &&
            Configuration is { ShowPartyInformation: true, FilterSystemMessages: true })
        {
            Better.TemporarilyDisableSystemFilter(Configuration);
            return true;
        }

        return false;
    }

    private void TryRewriteMarketBoardSaleMessage(IHandleableChatMessage message, ChatType chatType, string normalizedText)
    {
        if (!Configuration.BetterMarketBoardSaleMessage)
        {
            return;
        }
        if (chatType is not ChatType.System and not ChatType.RetainerSale)
        {
            return;
        }
        if (!MarketBoardSaleHelper.IsMarketItemSoldText(normalizedText))
        {
            return;
        }

        if (MarketBoardSaleHelper.TryRewriteSaleMessage(message.Message, Configuration, normalizedText) is SeString rewritten)
        {
            message.Message = rewritten;
        }
    }

    private bool HandleBetterMessages(IHandleableChatMessage message, ChatType chatType, string normalizedText)
    {
        if (chatType is ChatType.Action && TryCondenseEnemyCastLog(message, normalizedText))
        {
            return true;
        }

        // Anchored regex rather than 1531 catalog tokens: the template tokens are just
        // "has begun", which also matches event lines that continue past the verb.
        if (Configuration.BetterDutyCommenceMessage && chatType is ChatType.System &&
            L10N.Get(ChatStrings.DutyHasBegunRegex).IsMatch(normalizedText))
        {
            message.Message = Better.DutyCommence(message.Message, Configuration, normalizedText);
            return false;
        }

        if (Configuration.BetterInstanceMessage && chatType is ChatType.System &&
            LogMessageCatalog.MatchesWithFallback(1350, normalizedText, ChatStrings.InstancedArea))
        {
            message.Message = Better.Instances(message.Message, Configuration);
            if (Configuration.InstanceInDtrBar)
            {
                InstanceDtrBarUpdate(Configuration);
            }
            return false;
        }

        if (Configuration.BetterMarkBillMessage && chatType is ChatType.System)
        {
            if (TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.MarkBillDetails))
            {
                LogBlockedChat(["BetterMarkBillMessage"], message.Message.TextValue);
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
                return true;
            }

            if (LogMessageCatalog.MatchesWithFallback(4415, normalizedText, ChatStrings.MarkBillObtain) ||
                L10N.Get(ChatStrings.MarkBillObtainRegex).IsMatch(normalizedText))
            {
                message.Message = Better.MarkBillObtain(message.Message, Configuration, normalizedText);
                return false;
            }
        }

        if (Configuration.BetterCommendationMessage && chatType is ChatType.System &&
            LogMessageCatalog.MatchesWithFallback(926, normalizedText, ChatStrings.PlayerCommendation))
        {
            LogBlockedChat(["BetterCommendationMessage"], message.Message.TextValue);
            message.PreventOriginal();
            Interlocked.Increment(ref _sessionBlockedMessages);
            return true;
        }

        if (Configuration.BetterSayReminder &&
            chatType is ChatType.System &&
            TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.SayQuestReminder))
        {
            message.Message = Better.SayReminder(message.Message, Configuration);
            return false;
        }

        if (Configuration.BetterTreasureDungeonMessage && chatType is ChatType.System)
        {
            if (L10N.Get(ChatStrings.ChamberOpens).IsMatch(normalizedText))
            {
                var match = L10N.Get(ChatStrings.ChamberOpens).Match(normalizedText);
                if (match.Groups["chamber"].Success &&
                    TreasureDungeonHelper.TryParseChamber(match.Groups["chamber"].Value, out var floor))
                {
                    TreasureDungeonHelper.RecordGateOpened(floor);
                }

                return false;
            }

            if (L10N.Get(ChatStrings.TrapTriggered).IsMatch(normalizedText))
            {
                if (TreasureDungeonHelper.TryGetExpulsionChamber(out var chamber))
                {
                    message.Message = Better.TreasureDungeon(Configuration, chamber);
                }

                return false;
            }

            TreasureDungeonHelper.ClearGateAdvance();
        }

        if (Configuration.NormalizeBlocks &&
            (Configuration.AlwaysNormalizeBlocks || chatType is not ChatType.Party and not ChatType.Alliance))
        {
            message.Message = DeblockMessage(message.Message);
        }

        if (Configuration.EnableSmolMode)
        {
            message.Message = SmolMessage(message.Message);
        }

        return false;
    }
}
