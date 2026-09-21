using NUnit.Framework;
using TidyChat.Settings.Search;

namespace TidyChat.Tests;

[TestFixture]
public class SettingsSearchTests
{
    [Test]
    public void Numeric_query_matches_exact_log_message_id()
    {
        var matches = SettingsSearchIndex.FindMatchingIds("1119");

        Assert.That(matches, Does.Contain("ShowLoseBait"));
        Assert.That(matches, Does.Not.Contain("ShowStellarMissionMessages"));
    }

    [Test]
    public void Hash_prefixed_numeric_query_matches_exact_log_message_id()
    {
        var matches = SettingsSearchIndex.FindMatchingIds("#1117");

        Assert.That(matches, Does.Contain("ShowLoseBait"));
        Assert.That(matches, Does.Not.Contain("ShowStellarMissionMessages"));
    }

    [Test]
    public void Numeric_query_does_not_substring_match_longer_ids()
    {
        var matches = SettingsSearchIndex.FindMatchingIds("1119");

        Assert.That(matches, Does.Not.Contain("ShowStellarMissionMessages"));
        Assert.That(matches.Count, Is.EqualTo(1));
    }
}
