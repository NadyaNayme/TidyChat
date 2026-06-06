using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/4321?pretty=true">You desynthesize …</see>
    public static readonly LocalizedStrings DesynthedItem = new()
    {
        Jpn = ["分解"],
        Eng = ["you", "desynthesize"],
        Deu = ["verwertet"],
        Fra = ["recyclez"]
    };
    /// <see href="https://xivapi.com/LogMessage/4322?pretty=true">You obtain … (desynthesis).</see>
    public static readonly LocalizedStrings DesynthesisObtain = new()
    {
        Jpn = ["手に入れ"],
        Eng = ["you", "obtain"],
        Deu = ["erhalten"],
        Fra = ["obtenez"]
    };
}