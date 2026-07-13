using ChatTwo.Code;
using Dalamud.Game.Text;
using NUnit.Framework;
namespace TidyChat.Tests;

[TestFixture]
public class PluginChatPassthroughTests
{
    [Test]
    public void Allows_dalamud_print_on_system_channel()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            XivChatRelationKind.None,
            XivChatRelationKind.None), Is.True);
    }

    [Test]
    public void Allows_dalamud_print_even_when_a_rule_matched()
    {
        Assert.That(PluginChatPassthroughHelper.IsDalamudPluginPrint(
            XivChatRelationKind.None,
            XivChatRelationKind.None), Is.True);
    }

    [Test]
    public void Blocks_game_chat_with_packed_relation_kinds()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            XivChatRelationKind.LocalPlayer,
            XivChatRelationKind.None), Is.False);
    }

    [Test]
    public void Blocks_party_member_sourced_game_chat()
    {
        Assert.That(PluginChatPassthroughHelper.ShouldAllow(
            XivChatRelationKind.PartyMember,
            XivChatRelationKind.LocalPlayer), Is.False);
    }
}
