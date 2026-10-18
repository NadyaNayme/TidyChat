using NUnit.Framework;
using TidyChat.Data;
using TidyChat.Utility;
namespace TidyChat.Tests;

[TestFixture]
public class SoundMacroLogMessageTests
{
    private const string ReadyCheckComplete =
        "Ready check complete.<br>Ready: <num(lnum1)>/<num(lnum3)><br>Not Ready: <num(lnum2)>/<num(lnum3)><if([lnum2==0],<sound(0,46)>,<sound(0,47)>)>";
    private const string Countdown =
        "Battle commencing in <num(lnum1)> <if([lnum1==1],second,seconds)>!<br>(<if([lnum2==0],,<switch(lnum2,,,,,,)>)><if(gnum8,<sheet(ObjStr,gnum8,0)>,gstr3)>)<sound(1,95)>";
    private const string InviteeJoins =
        "<sound(0,65)><head(<if([gstr1==gstr2],you,<if(gnum7,<ennoun(ObjStr,2,gnum7,1,1)>,gstr2)>)>)> <if([gstr1==gstr2],join,joins)> the party.";
    private const string ReadyCheckInitiated =
        "<head(<if([gstr1==gstr3],<if(gnum8,<ennoun(ObjStr,2,gnum8,1,1)>,you)>,<if(gnum8,<ennoun(ObjStr,2,gnum8,1,1)>,gstr3)>)>)> <if([gstr1==gstr3],have,has)> initiated a ready check.";

    [SetUp]
    public void SetUp() =>
        LogMessageCatalog.LoadForTests(
            new Dictionary<uint, string>
            {
                [3794] = "Ready check complete.",
                [5255] = "Battle commencing in !",
                [60] = "the party.",
                [3791] = "initiated a ready check."
            },
            macroTemplates: new Dictionary<uint, string>
            {
                [3794] = ReadyCheckComplete,
                [5255] = Countdown,
                [60] = InviteeJoins,
                [3791] = ReadyCheckInitiated
            });

    [TestCase(ReadyCheckComplete)]
    [TestCase(Countdown)]
    [TestCase(InviteeJoins)]
    public void Sound_macro_is_detected_leading_trailing_and_nested(string macroString) =>
        Assert.That(LogMessageCatalog.ContainsSoundMacro(macroString), Is.True);

    [Test]
    public void Template_without_sound_is_not_flagged() =>
        Assert.That(LogMessageCatalog.ContainsSoundMacro(ReadyCheckInitiated), Is.False);

    [TestCase(3794u)]
    [TestCase(5255u)]
    [TestCase(60u)]
    public void Sound_templates_never_reach_the_game_formatter(uint logMessageId)
    {
        Assert.That(LogMessageCatalog.PlaysSound(logMessageId), Is.True);
        Assert.That(LogMessageHelper.CanUseGameFormatter(logMessageId), Is.False);
    }

    [Test]
    public void Templates_without_sound_still_use_the_game_formatter()
    {
        Assert.That(LogMessageCatalog.PlaysSound(3791), Is.False);
        Assert.That(LogMessageHelper.CanUseGameFormatter(3791), Is.True);
    }

    [Test]
    public void Ready_check_complete_and_countdown_keep_an_id_only_rule()
    {
        foreach (var id in new uint[] { 3794, 5255 })
        {
            Assert.That(
                Rules.AllRules.Any(r => r.LogMessageIds?.Contains(id) == true && r.Pattern == PatternKind.None),
                Is.True, $"LogMessage {id} has no id-only rule");
        }
    }
}
