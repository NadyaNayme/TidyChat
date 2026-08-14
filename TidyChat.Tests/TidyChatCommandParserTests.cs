using NUnit.Framework;

namespace TidyChat.Tests;

[TestFixture]
public class TidyChatCommandParserTests
{
    [TestCase(null, "OpenSettings", false)]
    [TestCase("", "OpenSettings", false)]
    [TestCase("   ", "OpenSettings", false)]
    [TestCase("debug", "ToggleDebug", false)]
    [TestCase("DEBUG", "ToggleDebug", false)]
    [TestCase("debug toggle", "ToggleDebug", false)]
    [TestCase("debug on", "SetDebug", true)]
    [TestCase("debug enable", "SetDebug", true)]
    [TestCase("debug 1", "SetDebug", true)]
    [TestCase("debug off", "SetDebug", false)]
    [TestCase("debug disable", "SetDebug", false)]
    [TestCase("debug 0", "SetDebug", false)]
    [TestCase("help", "ShowUsage", false)]
    [TestCase("debug nope", "ShowUsage", false)]
    [TestCase("settings", "ShowUsage", false)]
    public void Parse_maps_args_to_action(string? args, string expectedName, bool expectedDebug)
    {
        var action = TidyChatCommandParser.Parse(args, out var debugEnabled);
        Assert.That(action.ToString(), Is.EqualTo(expectedName));
        Assert.That(debugEnabled, Is.EqualTo(expectedDebug));
    }
}
