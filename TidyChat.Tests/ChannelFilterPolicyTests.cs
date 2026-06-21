using ChatTwo.Code;
using NUnit.Framework;
namespace TidyChat.Tests;

[TestFixture]
public class ChannelFilterPolicyTests
{
    [TestCase(ChatType.Damage)]
    [TestCase(ChatType.Action)]
    [TestCase(ChatType.Miss)]
    [TestCase(ChatType.Healing)]
    [TestCase(ChatType.GainBuff)]
    [TestCase(ChatType.GainDebuff)]
    [TestCase(ChatType.LoseBuff)]
    [TestCase(ChatType.LoseDebuff)]
    [TestCase(ChatType.Item)]
    public void Combat_log_channels_bypass_channel_rules(ChatType chatType) =>
        Assert.That(ChannelFilterPolicy.ShouldBypassChannelRules(chatType), Is.True);

    [TestCase(ChatType.System)]
    [TestCase(ChatType.Progress)]
    [TestCase(ChatType.BattleSystem)]
    [TestCase(ChatType.Error)]
    public void Non_combat_channels_do_not_bypass_channel_rules(ChatType chatType) =>
        Assert.That(ChannelFilterPolicy.ShouldBypassChannelRules(chatType), Is.False);
}
