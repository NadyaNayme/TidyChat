using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/1156?pretty=true">You synthesize …</see>
    /// <see href="https://xivapi.com/LogMessage/1157?pretty=true">You synthesize ×N …</see>
    /// <see href="https://xivapi.com/LogMessage/1158?pretty=true">You synthesize.</see>
    public static readonly LocalizedStrings SynthesisComplete = new()
    {
        Jpn = ["完成"],
        Eng = ["you", "synthesize"],
        Deu = ["hergestellt"],
        Fra = ["fabriquez"]
    };

    /// <see href="https://xivapi.com/LogMessage/1150?pretty=true">You begin synthesizing …</see>
    public static readonly LocalizedStrings CraftingBeginSynthesizing = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["begin", "synthesiz"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1154?pretty=true">You use … Success!</see>
    /// <seealso href="https://xivapi.com/LogMessage/5912?pretty=true">You use … Success!</seealso>
    public static readonly LocalizedStrings CraftingAbilitySuccess = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "use", "success"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1155?pretty=true">You use … Failure!</see>
    /// <seealso href="https://xivapi.com/LogMessage/5913?pretty=true">You use … Failure!</seealso>
    public static readonly LocalizedStrings CraftingAbilityFailure = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "use", "failure"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1162?pretty=true">Progress increases …</see>
    public static readonly LocalizedStrings CraftingProgressIncrease = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["progress", "increas"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1164?pretty=true">Quality increases …</see>
    public static readonly LocalizedStrings CraftingQualityIncrease = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["quality", "increas"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1167?pretty=true">Durability decreases …</see>
    public static readonly LocalizedStrings CraftingDurabilityDecrease = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["durability", "decreas"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1168?pretty=true">… removed from your bag.</see>
    public static readonly LocalizedStrings CraftingMaterialRemoved = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["removed", "bag"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1169?pretty=true">You remove the following from your bag:</see>
    public static readonly LocalizedStrings CraftingRemoveFromBagHeader = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["remove", "following", "bag"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/5918?pretty=true">All durability restored.</see>
    public static readonly LocalizedStrings CraftingDurabilityRestored = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["all", "durability", "restored"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1178?pretty=true">Proof of completion recorded in crafting log!</see>
    public static readonly LocalizedStrings CraftingLogProof = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["proof", "completion", "crafting", "log"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1156?pretty=true">Name synthesizes …</see>
    public static readonly LocalizedStrings OtherSynthesis = new()
    {
        Jpn = ["完成"],
        Eng = ["synthesizes"],
        Deu = ["hat", "hergestellt"],
        Fra = ["fabrique"]
    };

    /// <see href="https://xivapi.com/LogMessage/5902?pretty=true">Trial synthesis …</see>
    public static readonly LocalizedStrings TrialSynthesis = new()
    {
        Jpn = ["製作練習"],
        Eng = ["trial", "synthesis"],
        Deu = ["testsynthese"],
        Fra = ["synthèse", "essai"]
    };

    /// <see href="https://xivapi.com/LogMessage/5533?pretty=true">You are now able to execute …</see>
    /// <seealso href="https://xivapi.com/LogMessage/11365?pretty=true">Stellar mission able-to-execute.</seealso>
    public static readonly LocalizedStrings AbleToExecute = new()
    {
        Jpn = ["実行可能"],
        Eng = ["able", "to", "execute"],
        Deu = ["kann", "nun", "ausgeführt", "werden"],
        Fra = ["pouvez", "utiliser", "l'action"]
    };

    /// <see href="https://xivapi.com/LogMessage/603?pretty=true">Buff effect gain (Inner Quiet, Multihook, etc.)</see>
    /// <seealso href="https://xivapi.com/LogMessage/11366?pretty=true">Stellar mission buff effect gain.</seealso>
    public static readonly LocalizedStrings BuffEffectGain = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["gain", "effect"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
}
