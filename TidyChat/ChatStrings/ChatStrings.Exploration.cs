using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/88?pretty=true">Location discovered.</see>
    public static readonly LocalizedStrings LocationDiscovered = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["been", "discovered"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/2600?pretty=true">You sense something foul …</see>
    public static readonly LocalizedStrings SpideySenses = new()
    {
        Jpn = ["感じ"],
        Eng = ["you", "sense", "foul"],
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

    /// <see href="https://xivapi.com/LogMessage/4415?pretty=true">Mark details can viewed at any time… (second line).</see>
    public static readonly LocalizedStrings MarkBillDetails = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["mark", "details", "key items"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/4415?pretty=true">You obtain a stack of mark bills.</see>
    public static readonly LocalizedStrings MarkBillObtain = new()
    {
        Jpn = ["受注"],
        Eng = ["obtain", "mark bills"],
        Deu = ["angenommen", "jagdlizenz"],
        Fra = ["obtenu"]
    };

    /// <see href="https://xivapi.com/LogMessage/4412?pretty=true">Stack of … mark bills objectives complete!</see>
    public static readonly LocalizedStrings MarkBillComplete = new()
    {
        Jpn = ["コンプリート", "モブハント"],
        Eng = ["objectives", "complete"],
        Deu = ["abgeschlossen"],
        Fra = ["objectifs", "réussis"]
    };

    /// <see href="https://xivapi.com/LogMessage/4416?pretty=true">You destroy the stack of mark bills and abandon the hunt.</see>
    public static readonly LocalizedStrings MarkBillAbandon = new()
    {
        Jpn = ["破棄"],
        Eng = ["destroy", "abandon", "hunt"],
        Deu = ["entfernt"],
        Fra = ["jeté"]
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
