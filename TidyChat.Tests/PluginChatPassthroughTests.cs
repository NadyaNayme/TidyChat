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
            [646] = "You mount .",
            [720] = "You obtain a {item}.",
            [1603] = " objective fulfilled!",
            [4578] = "Gil earned from market sales has been entrusted to your retainer.",
            [9331] = "You sense the presence of a powerful mark..."
        }, logKind: (byte)ChatType.System);

    [Test]
    public void Allows_which_mount_style_lines_with_empty_sender()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            ChatType.System,
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            string.Empty,
            "no mount is currently active.",
            "Player Name",
            []), Is.True);
    }

    [Test]
    public void Allows_which_mount_header_after_replace_name_despite_action_template()
    {
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>
        {
            [646] = "You mount .",
            [1603] = " objective fulfilled!",
        }, logKind: (byte)ChatType.Action);

        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            ChatType.System,
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            string.Empty,
            "you's mount: construct vi-s core",
            "Player Name",
            []), Is.True);
    }

    [Test]
    public void Allows_which_mount_detail_lines_with_empty_sender()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            ChatType.System,
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            string.Empty,
            "has actions: no",
            "Player Name",
            []), Is.True);
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            ChatType.System,
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            string.Empty,
            "number of seats: 1",
            "Player Name",
            []), Is.True);
    }

    [Test]
    public void Allows_sonar_style_lines_with_plugin_sender_name()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            ChatType.System,
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
            ChatType.System,
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
            ChatType.System,
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
            ChatType.System,
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
            ChatType.System,
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
            ChatType.System,
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
            ChatType.System,
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            "Player Name",
            "no mount is currently active.",
            "Player Name",
            []), Is.False);
    }

    [Test]
    public void Does_not_passthrough_emote_channels()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            ChatType.StandardEmote,
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            "Other Player",
            "other player waves at you.",
            "Player Name",
            []), Is.False);
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            ChatType.CustomEmote,
            XivChatRelationKind.None,
            XivChatRelationKind.None,
            "Other Player",
            "other player does a thing.",
            "Player Name",
            []), Is.False);
    }
}
