using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/10830?pretty=true">A new mech op directive has been issued.</see>
    public static readonly LocalizedStrings MechOpDirective = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["mech", "directive", "pilots", "application"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/10884?pretty=true">A red alert has been issued.</see>
    /// <seealso href="https://xivapi.com/LogMessage/10881?pretty=true">The red alert has been resolved.</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/10807?pretty=true">Moongate Hub red alert (critical missions).</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/11334?pretty=true">Red alert — critical missions available.</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/11335?pretty=true">Red alert in effect.</seealso>
    public static readonly LocalizedStrings CosmicRedAlert = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["red", "alert"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10787?pretty=true">A modest contribution to the exploration initiative has been recorded.</see>
    /// <seealso href="https://xivapi.com/LogMessage/10788?pretty=true">A respectable contribution…</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/10789?pretty=true">A generous contribution…</seealso>
    public static readonly LocalizedStrings CosmicExplorationContribution = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["contribution", "exploration", "initiative", "recorded"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
}