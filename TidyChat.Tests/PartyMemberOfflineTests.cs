using ChatTwo.Code;
using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Settings;
namespace TidyChat.Tests;

[TestFixture]
public class PartyMemberOfflineTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Gone_offline_rule_is_its_own_party_setting_not_fc_logouts()
    {
        // #133: hiding FC logouts must not hide "x has gone offline." from party members
        var rule = Rules.AllRules.Single(r => r.LogMessageIds?.Contains(84u) == true);

        Assert.That(rule.Name, Is.EqualTo("ShowPartyMemberOffline"));
        Assert.That(rule.Channel, Is.EqualTo(ChatType.System));
        Assert.That(RuleMatcher.MatchesText(rule, "raven reaver has gone offline.", out _), Is.True);
    }

    [Test]
    public void Fc_logout_rule_only_covers_the_fc_channel()
    {
        var rules = Rules.AllRules.Where(r => r.Name == "ShowUserLogouts").ToArray();

        Assert.That(rules, Is.Not.Empty);
        Assert.That(rules.All(r => r.Channel == ChatType.FreeCompanyLoginLogout), Is.True);
    }

    [Test]
    public void Text_allow_filter_on_matching_channel_defers_log_message_blocks()
    {
        PlayerName[] whitelist = [new() { FirstName = "has gone offline.", AllowMessage = true }];

        Assert.That(TidyChatPlugin.HasTextAllowCustomFilterFor(whitelist, ChatType.System), Is.True);
        Assert.That(TidyChatPlugin.HasTextAllowCustomFilterFor(whitelist, ChatType.Crafting), Is.False);
    }

    [Test]
    public void Block_and_log_message_id_filters_do_not_defer()
    {
        PlayerName[] whitelist =
        [
            new() { FirstName = "has gone offline.", AllowMessage = false },
            new() { FirstName = "#84", AllowMessage = true }
        ];

        Assert.That(TidyChatPlugin.HasTextAllowCustomFilterFor(whitelist, ChatType.System), Is.False);
    }
}
