using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Localization.Data;
using TidyChat.Settings;
using TidyChat.Utility;

namespace TidyChat.Tests;

[TestFixture]
public class QuestSayReminderMatchingTests
{
    private const string CurrentKeyboardLine =
        "with the chat mode set to say, use the keyboard or the software keyboard to enter \"the chair is uncomfortable\" to get huy's attention.";

    private const string LegacyPhraseContainingLine =
        "with the chat mode in say, enter a phrase containing “tataru” at the destination point.";

    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Current_keyboard_wording_matches_show_rule()
    {
        var rule = FindSayReminderRule();
        Assert.That(RuleMatcher.MatchesText(rule, CurrentKeyboardLine, out _), Is.True);
    }

    [Test]
    public void Legacy_phrase_containing_wording_still_matches()
    {
        var rule = FindSayReminderRule();
        Assert.That(RuleMatcher.MatchesText(rule, LegacyPhraseContainingLine, out _), Is.True);
    }

    [Test]
    public void Old_token_set_misses_current_keyboard_wording()
    {
        string[] oldTokens = ["with", "the", "chat", "mode", "in", "enter", "phrase", "containing"];
        Assert.That(oldTokens.All(token => CurrentKeyboardLine.Contains(token, StringComparison.Ordinal)), Is.False);
    }

    [Test]
    public void Unrelated_system_line_does_not_match()
    {
        var rule = FindSayReminderRule();
        Assert.That(
            RuleMatcher.MatchesText(rule, "you change to paladin.", out _),
            Is.False);
    }

    [Test]
    public void Improved_say_extracts_ascii_quoted_phrase()
    {
        var rewritten = BetterStrings.SayReminder(
            CurrentKeyboardLine,
            new Configuration { CopyBetterSayReminder = false });
        Assert.That(rewritten.TextValue, Is.EqualTo("/say the chair is uncomfortable"));
    }

    [Test]
    public void Improved_say_extracts_curly_quoted_phrase()
    {
        var rewritten = BetterStrings.SayReminder(
            "With the chat mode in Say, enter a phrase containing “Tataru” at the destination point.",
            new Configuration { CopyBetterSayReminder = false });
        Assert.That(rewritten.TextValue, Is.EqualTo("/say Tataru"));
    }

    private static LocalizedFilterRule FindSayReminderRule() =>
        Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowQuestReminder", StringComparison.Ordinal) &&
            rule.RegexChecks?.Contains(ChatStrings.SayQuestReminderRegex) == true);
}
