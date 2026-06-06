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
}