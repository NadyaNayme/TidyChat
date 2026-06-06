using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/88?pretty=true">Location discovered.</see>
    public static readonly LocalizedStrings LocationDiscovered = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["discovered"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/2600?pretty=true">You sense something foul …</see>
    public static readonly LocalizedStrings SpideySenses = new()
    {
        Jpn = ["感じ"],
        Eng = ["sense"],
        Deu = ["spürst"],
        Fra = ["percevez"]
    };
    /// <see href="https://xivapi.com/LogMessage/3240?pretty=true">You sense a hostile presence!</see>
    public static readonly LocalizedStrings HostilePresence = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["hostile", "presence"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/3712?pretty=true">The compass detects a current …</see>
    public static readonly LocalizedStrings AetherCompass = new()
    {
        Jpn = ["コンパス"],
        Eng = ["compass"],
        Deu = ["kompass"],
        Fra = ["boussole"]
    };


    /// <see href="https://xivapi.com/LogMessage">Matched via formatted chat text (not a LogMessage row)</see>
    public static readonly LocalizedStrings SayQuestReminder = new()
    {
        Jpn = ["チャットの会話モードを"],
        Eng = ["with", "the", "chat", "mode", "in", "enter", "phrase", "containing"],
        Deu = ["gib", "im", "virtuelle", "tastatur"],
        Fra = ["en", "mode", "de", "discussion"]
    };
}