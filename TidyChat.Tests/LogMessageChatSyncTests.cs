using ChatTwo.Code;
using NUnit.Framework;
using TidyChat.Utility;

namespace TidyChat.Tests;

[TestFixture]
public class LogMessageHelperTests
{
    private static readonly ChatType[] PlayerChannels =
    [
        ChatType.Say,
        ChatType.Shout,
        ChatType.Yell,
        ChatType.TellIncoming,
        ChatType.TellOutgoing,
        ChatType.Party,
        ChatType.CrossParty,
        ChatType.Alliance,
        ChatType.FreeCompany,
        ChatType.NoviceNetwork,
        ChatType.PvpTeam,
        ChatType.CustomEmote,
        ChatType.Linkshell1,
        ChatType.Linkshell2,
        ChatType.Linkshell3,
        ChatType.Linkshell4,
        ChatType.Linkshell5,
        ChatType.Linkshell6,
        ChatType.Linkshell7,
        ChatType.Linkshell8,
        ChatType.CrossLinkshell1,
        ChatType.CrossLinkshell2,
        ChatType.CrossLinkshell3,
        ChatType.CrossLinkshell4,
        ChatType.CrossLinkshell5,
        ChatType.CrossLinkshell6,
        ChatType.CrossLinkshell7,
        ChatType.CrossLinkshell8,
        ChatType.GmTell,
        ChatType.GmSay,
        ChatType.GmShout,
        ChatType.GmYell,
        ChatType.GmParty,
        ChatType.GmFreeCompany,
        ChatType.GmNoviceNetwork,
        ChatType.GmLinkshell1,
        ChatType.GmLinkshell2,
        ChatType.GmLinkshell3,
        ChatType.GmLinkshell4,
        ChatType.GmLinkshell5,
        ChatType.GmLinkshell6,
        ChatType.GmLinkshell7,
        ChatType.GmLinkshell8
    ];

    private static readonly ChatType[] LogMessageChannels =
    [
        ChatType.System,
        ChatType.RetainerSale,
        ChatType.StandardEmote,
        ChatType.Crafting,
        ChatType.Gathering,
        ChatType.GatheringSystem,
        ChatType.LootNotice,
        ChatType.LootRoll,
        ChatType.Progress,
        ChatType.FreeCompanyLoginLogout,
        ChatType.GlamourNotifications,
        ChatType.BattleSystem,
        ChatType.Echo,
        ChatType.Item,
        ChatType.Action,
        ChatType.Damage,
        ChatType.Miss,
        ChatType.Healing,
        ChatType.GainBuff,
        ChatType.GainDebuff,
        ChatType.LoseBuff,
        ChatType.LoseDebuff,
        ChatType.Error,
        ChatType.NpcDialogue,
        ChatType.NpcAnnouncement,
        ChatType.FreeCompanyAnnouncement,
        ChatType.MessageBook,
        ChatType.NoviceNetworkSystem,
        ChatType.PeriodicRecruitmentNotification,
        ChatType.Orchestrion,
        ChatType.PvpTeamAnnouncement,
        ChatType.PvpTeamLoginLogout,
        ChatType.Urgent,
        ChatType.Notice,
        ChatType.Alarm,
        ChatType.Sign,
        ChatType.RandomNumber,
        ChatType.Debug
    ];

    [Test]
    public void Player_channels_do_not_participate_in_log_message_chat_sync()
    {
        foreach (var chatType in PlayerChannels)
        {
            Assert.That(LogMessageHelper.IsPlayerAuthoredChannel(chatType), Is.True,
                () => $"{chatType} should be classified as player-authored");
            Assert.That(LogMessageHelper.ParticipatesInLogMessageChatSync(chatType), Is.False,
                () => $"{chatType} must not inherit LogMessage blocks");
        }
    }

    [Test]
    public void Pending_log_message_sync_skips_player_authored_channels()
    {
        Assert.That(
            LogMessageHelper.PendingTextMatchesOnChannel(
                1232,
                ChatType.Say,
                "is there a way to get the big spider tank as a mount?"),
            Is.False);
    }

    [Test]
    public void Log_message_channels_participate_in_chat_sync()
    {
        foreach (var chatType in LogMessageChannels)
        {
            Assert.That(LogMessageHelper.ParticipatesInLogMessageChatSync(chatType), Is.True,
                () => $"{chatType} must inherit LogMessage allow/block on chat");
        }
    }

    [Test]
    public void Every_chat_type_is_classified_for_log_message_sync()
    {
        var all = Enum.GetValues<ChatType>();
        var classified = PlayerChannels.Concat(LogMessageChannels).ToHashSet();
        foreach (var chatType in Enum.GetValues<ChatType>())
        {
            if (LogMessageHelper.IsPlayerAuthoredChannel(chatType))
            {
                classified.Add(chatType);
            }
        }

        var missing = all.Where(t => !classified.Contains(t)).ToArray();

        Assert.That(missing, Is.Empty,
            "Add new ChatType values to LogMessageHelper and this test: " +
            string.Join(", ", missing));
    }
}
