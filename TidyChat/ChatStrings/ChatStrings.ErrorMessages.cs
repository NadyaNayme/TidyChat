using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    public static readonly LocalizedStrings FateLevelTooHighToAttack = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["unable", "attack", "fate", "target", "level", "high"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings ActiveHelpEntryAdded = new()
    {
        Jpn = ["howto"],
        Eng = ["active", "help", "entry", "added"],
        Deu = ["tutorial-hilfstext"],
        Fra = ["tutoriel"]
    };
}
