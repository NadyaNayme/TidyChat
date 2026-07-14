using ChatTwo.Code;
using Dalamud.Game.Text;
using NUnit.Framework;
using TidyChat.Data;
namespace TidyChat.Tests;

[TestFixture]
public class PluginChatPassthroughTests
{
    [SetUp]
    public void SetUp() =>
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>
        {
            [401] = "Asking price updated.",
            [402] = "You entrusted {IntegerParameter(1)} type of item to your retainer.",
            [720] = "You obtain a {item}.",
            [1603] = " objective fulfilled!",
            [4578] = "Gil earned from market sales has been entrusted to your retainer.",
            [9331] = "You sense the presence of a powerful mark..."
        }, logKind: (byte)ChatType.System);

    [Test]
    public void Allows_which_mount_style_lines_with_empty_sender()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            string.Empty,
            "no mount is currently active.",
            "Player Name",
            []), Is.True);
    }

    [Test]
    public void Allows_sonar_style_lines_with_plugin_sender_name()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            "Sonar",
            "rank s: odin outer la noscea ( 20 , 20 ) balmung",
            "Player Name",
            []), Is.True);
    }

    [Test]
    public void Blocks_catalog_system_lines_with_empty_sender()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            string.Empty,
            "\"gulal generosity\" objective fulfilled!",
            "Player Name",
            []), Is.False);
    }

    [Test]
    public void Blocks_market_board_system_lines_with_empty_sender()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            string.Empty,
            "asking price updated.",
            "Player Name",
            []), Is.False);
    }

    [Test]
    public void Blocks_retainer_entrust_lines_with_empty_sender()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            string.Empty,
            "you entrusted 1 type of item to your retainer.",
            "Player Name",
            []), Is.False);
    }

    [Test]
    public void Blocks_game_chat_with_packed_relation_kinds()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            XivChatRelationKind.LocalPlayer,
            XivChatRelationKind.None,
            string.Empty,
            "no mount is currently active.",
            "Player Name",
            []), Is.False);
    }

    [Test]
    public void Blocks_party_member_sourced_game_chat()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            XivChatRelationKind.PartyMember,
            XivChatRelationKind.LocalPlayer,
            string.Empty,
            "no mount is currently active.",
            "Player Name",
            []), Is.False);
    }

    [Test]
    public void Does_not_treat_player_sender_as_plugin_output()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            "Player Name",
            "no mount is currently active.",
            "Player Name",
            []), Is.False);
    }
}
