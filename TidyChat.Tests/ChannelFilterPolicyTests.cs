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
        Assert.That(ChannelFilterPolicy.IsCombatLogChannel(chatType), Is.True);

    [TestCase(ChatType.System)]
    [TestCase(ChatType.Progress)]
    [TestCase(ChatType.BattleSystem)]
    [TestCase(ChatType.Error)]
    public void Non_combat_channels_do_not_bypass_channel_rules(ChatType chatType) =>
        Assert.That(ChannelFilterPolicy.IsCombatLogChannel(chatType), Is.False);

    [Test]
    public void Every_player_channel_has_a_custom_filter_flag()
    {
        var missing = Enum.GetValues<ChatType>()
            .Where(t => TidyChat.Utility.LogMessageHelper.IsPlayerAuthoredChannel(t) &&
                        !t.ToString().StartsWith("Gm", StringComparison.Ordinal) &&
                        !TidyChat.Utility.ChatFlags.CheckFlags(-1, t))
            .ToArray();

        Assert.That(missing, Is.Empty);
    }
}
