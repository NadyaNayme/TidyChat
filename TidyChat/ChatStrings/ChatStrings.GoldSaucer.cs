using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/4784?pretty=true">The Finer Miner — You take up your pickaxe.</see>
    /// <seealso href="https://xivapi.com/LogMessage/4789?pretty=true">Out on a Limb — You take up your hatchet.</seealso>
    public static readonly LocalizedStrings GoldSaucerTakeUpTool = new()
    {
        Jpn = ["かまえ"],
        Eng = ["you", "take", "up"],
        Deu = ["aus"],
        Fra = ["apprêtez"]
    };


    /// <see href="https://xivapi.com/LogMessage/4785?pretty=true">The Finer Miner — You sense nothing.</see>
    /// <seealso href="https://xivapi.com/LogMessage/4790?pretty=true">Out on a Limb — You sense nothing.</seealso>
    public static readonly LocalizedStrings GoldSaucerSenseNothing = new()
    {
        Jpn = ["感じなかった"],
        Eng = ["sense", "nothing"],
        Deu = ["nichts"],
        Fra = ["raté"]
    };


    /// <see href="https://xivapi.com/LogMessage/4786?pretty=true">The Finer Miner — You sense something close.</see>
    /// <seealso href="https://xivapi.com/LogMessage/4791?pretty=true">Out on a Limb — You sense something close.</seealso>
    public static readonly LocalizedStrings GoldSaucerSenseClose = new()
    {
        Jpn = ["感じた"],
        Eng = ["sense", "something", "close"],
        Deu = ["richtigen", "spur"],
        Fra = ["bon", "coup"]
    };


    /// <see href="https://xivapi.com/LogMessage/4787?pretty=true">The Finer Miner — You sense something very close.</see>
    /// <seealso href="https://xivapi.com/LogMessage/4792?pretty=true">Out on a Limb — You sense something very close.</seealso>
    public static readonly LocalizedStrings GoldSaucerSenseVeryClose = new()
    {
        Jpn = ["かなり"],
        Eng = ["sense", "something", "very", "close"],
        Deu = ["ganz", "nah"],
        Fra = ["très", "bon"]
    };


    /// <see href="https://xivapi.com/LogMessage/4788?pretty=true">The Finer Miner — You're right on top of it!</see>
    /// <seealso href="https://xivapi.com/LogMessage/4793?pretty=true">Out on a Limb — You're right on top of it!</seealso>
    public static readonly LocalizedStrings GoldSaucerRightOnTop = new()
    {
        Jpn = ["確実"],
        Eng = ["right", "top"],
        Deu = ["richtige", "stelle"],
        Fra = ["excellent"]
    };
}
