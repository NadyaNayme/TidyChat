using NUnit.Framework;
using TidyChat.Settings;
using TidyChat.Utility;
namespace TidyChat.Tests;

[TestFixture]
public class NormalizeInputReplaceNameTests
{
    [Test]
    public void Replaces_proper_cased_player_name_in_lowercased_text()
    {
        var configuration = new Configuration { PlayerName = "First Last" };
        var normalized = NormalizeInput.ReplaceName("first last waves at someone.", configuration);
        Assert.That(normalized, Is.EqualTo("you waves at someone."));
    }

    [Test]
    public void Replaces_player_name_in_possessive_mount_style_line()
    {
        var configuration = new Configuration { PlayerName = "First Last" };
        var normalized = NormalizeInput.ReplaceName("first last's mount: construct vi-s core", configuration);
        Assert.That(normalized, Is.EqualTo("you's mount: construct vi-s core"));
    }

    [Test]
    public void Replaces_initialed_forms()
    {
        var configuration = new Configuration { PlayerName = "First Last" };
        Assert.That(NormalizeInput.ReplaceName("first l. waves.", configuration), Is.EqualTo("youwaves."));
        Assert.That(NormalizeInput.ReplaceName("f. last waves.", configuration), Is.EqualTo("youwaves."));
        Assert.That(NormalizeInput.ReplaceName("f. l. waves.", configuration), Is.EqualTo("youwaves."));
    }
}
