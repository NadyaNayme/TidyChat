using TidyChat.Translation.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/533?pretty=true">You use … / … uses …</see>
    public static readonly LocalizedStrings AbilityUseMessage = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "use"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <seealso href="https://xivapi.com/LogMessage/533?pretty=true">The enemy uses … / … uses …</seealso>
    public static readonly LocalizedStrings AbilityUseMessageOther = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["uses"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/526?pretty=true">You gain the effect of …</see>
    public static readonly LocalizedStrings BuffGainEffect = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["gain", "effect"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/550?pretty=true">You lose the effect of …</see>
    public static readonly LocalizedStrings BuffLossEffect = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["lose", "effect"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/607?pretty=true">… nullifies the effect of …</see>
    public static readonly LocalizedStrings BuffEffectNullify = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["nullifies", "effect"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/502?pretty=true">… begins casting …</see>
    public static readonly LocalizedStrings CombatCastBegin = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["begins", "casting"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/534?pretty=true">… casts …</see>
    public static readonly LocalizedStrings CombatCastComplete = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["casts"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/538?pretty=true">… cancels …</see>
    /// <seealso href="https://xivapi.com/LogMessage/537?pretty=true">… cancels …</seealso>
    public static readonly LocalizedStrings CombatCastCancel = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["cancels"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/541?pretty=true">… is interrupted.</see>
    /// <seealso href="https://xivapi.com/LogMessage/542?pretty=true">Your use of … is interrupted.</seealso>
    public static readonly LocalizedStrings CombatCastInterrupted = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["interrupted"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1472?pretty=true">Interrupted! You prevent … from performing …</see>
    public static readonly LocalizedStrings CombatInterruptPrevent = new()
    {
        Jpn = ["中断"],
        Eng = ["interrupted", "prevent"],
        Deu = ["unterbrochen"],
        Fra = ["interrompue"]
    };

    /// <see href="https://xivapi.com/LogMessage/612?pretty=true">… is unaffected.</see>
    public static readonly LocalizedStrings CombatUnaffected = new()
    {
        Jpn = ["効果なし"],
        Eng = ["unaffected"],
        Deu = ["unbeeinflusst"],
        Fra = ["affect"]
    };

    /// <see href="https://xivapi.com/LogMessage/515?pretty=true">The attack misses you.</see>
    public static readonly LocalizedStrings CombatAttackMissesYou = new()
    {
        Jpn = ["ミス"],
        Eng = ["misses", "you"],
        Deu = ["verfehlt"],
        Fra = ["manque"]
    };

    /// <see href="https://xivapi.com/LogMessage/504?pretty=true">You hit … for N damage.</see>
    public static readonly LocalizedStrings CombatHitDamage = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["damage"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/518?pretty=true">Parried! You take N damage.</see>
    public static readonly LocalizedStrings CombatParried = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["parried", "damage"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/617?pretty=true">The … is destroyed.</see>
    public static readonly LocalizedStrings CombatDestroyed = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["destroyed"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/523?pretty=true">The palace bat absorbs N HP.</see>
    public static readonly LocalizedStrings CombatAbsorption = new()
    {
        Jpn = ["吸収"],
        Eng = ["absorbs", "hp"],
        Deu = ["absorbiert", "hp"],
        Fra = ["absorbe", "pv"]
    };

    /// <see href="https://xivapi.com/LogMessage/447?pretty=true">Direct hit! …</see>
    public static readonly LocalizedStrings CombatDirectHit = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["direct", "hit"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/450?pretty=true">Critical direct hit! …</see>
    /// <seealso href="https://xivapi.com/LogMessage/451?pretty=true">Critical direct hit! …</seealso>
    public static readonly LocalizedStrings CombatCriticalDirectHit = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["critical", "direct", "hit"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/528?pretty=true">… moves into … Form.</see>
    public static readonly LocalizedStrings CombatFormChange = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["moves", "into", "form"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/640?pretty=true">The … withdraws from the battlefield.</see>
    public static readonly LocalizedStrings PetWithdraws = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["withdraws", "battlefield"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/506?pretty=true">… misses you.</see>
    public static readonly LocalizedStrings CombatMiss = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["misses"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/600?pretty=true">The attack misses.</see>
    public static readonly LocalizedStrings CombatAttackMisses = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["attack", "misses"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/519?pretty=true">You recover N HP.</see>
    public static readonly LocalizedStrings CombatHpRecover = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["recover", "hp"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/560?pretty=true">You are revived.</see>
    public static readonly LocalizedStrings CombatRevived = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["revived"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/596?pretty=true">… fully resists …</see>
    public static readonly LocalizedStrings CombatStatusResist = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["fully", "resist"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/527?pretty=true">… suffers the effect of …</see>
    public static readonly LocalizedStrings CombatDebuffApplied = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["suffers", "effect"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/532?pretty=true">You recover from the effect of …</see>
    public static readonly LocalizedStrings CombatDebuffCured = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["recover", "effect"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/557?pretty=true">You defeat …</see>
    public static readonly LocalizedStrings CombatDefeat = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["defeat"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/558?pretty=true">… is defeated by …</see>
    public static readonly LocalizedStrings CombatDefeatedBy = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["defeated"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/501?pretty=true">You ready …</see>
    public static readonly LocalizedStrings CombatReady = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "ready"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <seealso href="https://xivapi.com/LogMessage/501?pretty=true">… readies …</seealso>
    public static readonly LocalizedStrings CombatReadies = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["readies"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/555?pretty=true">… calls for help!</see>
    public static readonly LocalizedStrings CombatCallsForHelp = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["calls", "help"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/536?pretty=true">Your enmity increases.</see>
    public static readonly LocalizedStrings CombatEnmity = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["enmity", "increases"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
}
