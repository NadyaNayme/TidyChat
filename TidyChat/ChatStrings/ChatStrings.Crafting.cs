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
        Jpn = ["の製作を開始した"],
        Eng = ["begin", "synthesiz"],
        Deu = ["begonnen", "synthese", "herzustellen"],
        Fra = ["commencez", "fabriquer"]
    };

    /// <see href="https://xivapi.com/LogMessage/1154?pretty=true">You use … Success!</see>
    /// <seealso href="https://xivapi.com/LogMessage/5912?pretty=true">You use … Success!</seealso>
    public static readonly LocalizedStrings CraftingAbilitySuccess = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "use", "success"],
        Deu = ["setzt", "erfolg"],
        Fra = ["utilisez", "succès"]
    };

    /// <see href="https://xivapi.com/LogMessage/1155?pretty=true">You use … Failure!</see>
    /// <seealso href="https://xivapi.com/LogMessage/5913?pretty=true">You use … Failure!</seealso>
    public static readonly LocalizedStrings CraftingAbilityFailure = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "use", "failure"],
        Deu = ["setzt", "fehlschlag"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1162?pretty=true">Progress increases …</see>
    public static readonly LocalizedStrings CraftingProgressIncrease = new()
    {
        Jpn = ["作業が", "進んだ"],
        Eng = ["progress", "increas"],
        Deu = ["fortschritt", "gestiegen"],
        Fra = ["progression", "augmente"]
    };

    /// <see href="https://xivapi.com/LogMessage/1164?pretty=true">Quality increases …</see>
    public static readonly LocalizedStrings CraftingQualityIncrease = new()
    {
        Jpn = ["品質が", "上昇した"],
        Eng = ["quality", "increas"],
        Deu = ["qualität", "gestiegen"],
        Fra = ["qualité", "augmente"]
    };

    /// <see href="https://xivapi.com/LogMessage/1167?pretty=true">Durability decreases …</see>
    public static readonly LocalizedStrings CraftingDurabilityDecrease = new()
    {
        Jpn = ["耐久が", "減少した"],
        Eng = ["durability", "decreas"],
        Deu = ["belastbarkeit", "gesunken"],
        Fra = ["solidité", "diminue"]
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
        Jpn = ["は所持品から材料を取り出した"],
        Eng = ["remove", "following", "bag"],
        Deu = ["folgendes", "material", "inventar"],
        Fra = ["matériaux", "suivants", "inventaire"]
    };

    /// <see href="https://xivapi.com/LogMessage/5918?pretty=true">All durability restored.</see>
    public static readonly LocalizedStrings CraftingDurabilityRestored = new()
    {
        Jpn = ["耐久が全回復した"],
        Eng = ["all", "durability", "restored"],
        Deu = ["belastbarkeit", "vollständig", "wiederhergestellt"],
        Fra = ["solidité", "entièrement", "restaurée"]
    };

    /// <see href="https://xivapi.com/LogMessage/1178?pretty=true">Proof of completion recorded in crafting log!</see>
    public static readonly LocalizedStrings CraftingLogProof = new()
    {
        Jpn = ["は製作手帳に", "を作った記録を残した"],
        Eng = ["proof", "completion", "crafting", "log"],
        Deu = ["hergestellt", "handwerker", "notizbuch"],
        Fra = ["fabrication", "carnet", "artisanat"]
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

    public static readonly LocalizedStrings DesynthedItem = new()
    {
        Jpn = ["分解"],
        Eng = ["you", "desynthesize"],
        Deu = ["verwertet"],
        Fra = ["recyclez"]
    };

    public static readonly LocalizedStrings DesynthesisObtain = new()
    {
        Jpn = ["手に入れ"],
        Eng = ["you", "obtain"],
        Deu = ["erhalten"],
        Fra = ["obtenez"]
    };
}
