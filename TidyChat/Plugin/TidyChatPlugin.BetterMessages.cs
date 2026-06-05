using System.Threading;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private bool HandleTemporaryFilterDisables(string normalizedText)
    {
        if (L10N.Get(ChatRegexStrings.QuestionMarkCommandResponse).IsMatch(normalizedText) && Configuration.FilterSystemMessages)
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
            if (Configuration.InstanceInDtrBar)
            {
                InstanceDtrBarUpdate(Configuration);
            }
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
            TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.SayQuestReminder))
        {
            message.Message = Better.SayReminder(message.Message, Configuration);
            return true;
        }

        if (Configuration.BetterTreasureDungeonMessage && chatType is ChatType.System)
        {
            if (L10N.Get(ChatRegexStrings.ChamberOpens).IsMatch(normalizedText))
            {
                var match = L10N.Get(ChatRegexStrings.ChamberOpens).Match(normalizedText);
                if (match.Groups["chamber"].Success)
                {
                    TidyStrings.LastTreasureDungeonChamber = match.Groups["chamber"].Value;
                }
                return true;
            }
            if (L10N.Get(ChatRegexStrings.TrapTriggered).IsMatch(normalizedText))
            {
                if (TidyStrings.LastTreasureDungeonChamber.Length > 0)
                {
                    message.Message = Better.TreasureDungeon(Configuration);
                }
                return true;
            }
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
