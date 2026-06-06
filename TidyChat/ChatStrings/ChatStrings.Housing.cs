using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/3379?pretty=true">Housing ward entry.</see>
    public static readonly LocalizedStrings HousingWardMessage = new()
    {
        Jpn = ["区"],
        Eng = ["ward"],
        Deu = ["bezirk"],
        Fra = ["secteur"]
    };


    /// <see href="https://xivapi.com/LogMessage/732?pretty=true">You have entered a sanctuary.</see>
    /// <seealso href="https://xivapi.com/LogMessage/733?pretty=true">You have left the sanctuary.</seealso>
    public static readonly LocalizedStrings SanctuaryMessage = new()
    {
        Jpn = ["レストエリア"],
        Eng = ["sanctuary"],
        Deu = ["ruhebereich"],
        Fra = ["repos"]
    };
}
