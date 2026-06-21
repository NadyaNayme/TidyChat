using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Data;
using TidyChat.Localization.Data;

namespace TidyChat.Tests;

[TestFixture]
public class FriendListMatchingTests
{
    private const string FriendRequest = "you send a friend request to kage okeya";

    [SetUp]
    public void SetUp()
    {
        L10N.Language = ClientLanguage.English;
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>());
    }

    [Test]
    public void Friend_request_does_not_match_materia_retrieved_rules()
    {
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>
        {
            [1953] = "You attempt to remove the materia from .",
            [1954] = "You receive .",
            [7487] = "You send a friend request to <StringParameter(1)>."
        });

        foreach (var rule in Rules.AllRules.Where(r => r.Name == "ShowMateriaRetrieved"))
        {
            Assert.That(
                RuleMatcher.MatchesText(rule, FriendRequest, out var detail),
                Is.False,
                $"Rule should not match friend request (detail: {detail})");
        }
    }

    [Test]
    public void Friend_request_matches_friend_list_rule_with_catalog()
    {
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>
        {
            [10] = "You send a friend request to you.",
            [7487] = "You send a friend request to <StringParameter(1)>.",
            [78] = "you is now on your friend list.",
            [81] = "List updated."
        });

        var rule = Rules.AllRules.First(r => r.Name == "ShowFriendListMessages");

        Assert.That(RuleMatcher.MatchesText(rule, FriendRequest, out _), Is.True);
    }

    [Test]
    public void Friend_request_matches_friend_list_rule_without_catalog()
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowFriendListMessages" &&
            r.RegexChecks?.Contains(ChatStrings.FriendRequestSentRegex) == true);

        Assert.That(RuleMatcher.MatchesText(rule, FriendRequest, out _), Is.True);
    }

    [Test]
    public void Friend_list_updated_matches_friend_list_rule_without_catalog()
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowFriendListMessages" &&
            r.StringChecks?.Contains(ChatStrings.FriendListUpdated) == true);

        Assert.That(RuleMatcher.MatchesText(rule, "list updated.", out _), Is.True);
    }

    [Test]
    public void Friend_list_added_matches_without_player_name_prefix()
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowFriendListMessages" &&
            r.RegexChecks?.Contains(ChatStrings.FriendListAddedRegex) == true);

        Assert.That(RuleMatcher.MatchesText(rule, "is now on your friend list.", out _), Is.True);
        Assert.That(RuleMatcher.MatchesText(rule, "kage okeya is now on your friend list.", out _), Is.True);
    }

    [Test]
    public void Friend_request_does_not_match_materia_retrieved_regex()
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowMateriaRetrieved" &&
            r.RegexChecks?.Contains(ChatStrings.MateriaRetrievedRegex) == true);

        Assert.That(RuleMatcher.MatchesText(rule, FriendRequest, out _), Is.False);
    }
}
