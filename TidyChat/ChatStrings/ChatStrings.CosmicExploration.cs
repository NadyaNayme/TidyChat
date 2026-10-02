using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/10830?pretty=true">A new mech op directive has been issued.</see>
    public static readonly LocalizedStrings MechOpDirective = new()
    {
        Jpn = ["メカオペレーションが発令されました", "パイロットになりたい場合は", "搭乗希望エントリーをしましょう"],
        Eng = ["mech", "directive", "pilots", "application"],
        Deu = ["angefordert", "aufgerufen", "einsteigeerlaubnis"],
        Fra = ["intervention", "mécanique", "volontaire"]
    };
    /// <see href="https://xivapi.com/LogMessage/10884?pretty=true">A red alert has been issued.</see>
    /// <seealso href="https://xivapi.com/LogMessage/10881?pretty=true">The red alert has been resolved.</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/10807?pretty=true">Moongate Hub red alert (critical missions).</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/11334?pretty=true">Red alert - critical missions available.</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/11335?pretty=true">Red alert in effect.</seealso>
    public static readonly LocalizedStrings CosmicRedAlert = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["red", "alert"],
        Deu = ["NeedsLocalization"],
        Fra = ["alerte", "rouge"]
    };

    /// <see href="https://xivapi.com/LogMessage/10787?pretty=true">
    ///     A modest contribution to the exploration initiative has
    ///     been recorded.
    /// </see>
    /// <seealso href="https://xivapi.com/LogMessage/10788?pretty=true">A respectable contribution…</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/10789?pretty=true">A generous contribution…</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/10790?pretty=true">A sizable contribution…</seealso>
    public static readonly LocalizedStrings CosmicExplorationContribution = new()
    {
        Jpn = ["調査員により"],
        Eng = ["contribution", "exploration", "initiative", "recorded"],
        Deu = ["projektbeitrag", "komitee", "aufgezeichnet"],
        Fra = ["examinateur", "enregistré", "efforts"]
    };

    public static readonly LocalizedStrings CosmicExplorationSizableContribution = new()
    {
        Jpn = ["調査員により", "とても大きな活躍が記録された"],
        Eng = ["sizable", "contribution", "exploration", "initiative", "recorded"],
        Deu = ["unglaublicher", "projektbeitrag", "aufgezeichnet"],
        Fra = ["examinateur", "enregistré", "considérables"]
    };

    public static readonly LocalizedStrings CosmicContainerObtain = new()
    {
        Jpn = ["コスモコンテナ", "手に入れた"],
        Eng = ["obtain", "cosmic", "container"],
        Deu = ["kosmo-container", "erhalten"],
        Fra = ["obtenez", "conteneur", "cosmique"]
    };

    public static readonly LocalizedStrings CosmicFortuneObtain = new()
    {
        Jpn = ["コスモフォーチュンの景品として", "を入手しました"],
        Eng = ["obtain", "cosmic", "fortune"],
        Deu = ["preis", "kosmo", "erhalten"],
        Fra = ["gagné", "fortune", "cosmique"]
    };

    public static readonly LocalizedStrings CosmocreditObtain = new()
    {
        Jpn = ["コスモクレジット", "手に入れた"],
        Eng = ["obtain", "cosmocredit"],
        Deu = ["kosmo-kohle", "erhalten"],
        Fra = ["obtenez", "crédit", "cosmique"]
    };

    /// <see href="https://xivapi.com/LogMessage/10859?pretty=true">You will receive additional cosmocredits.</see>
    public static readonly LocalizedStrings CosmocreditReceived = new()
    {
        Jpn = ["メカオペレーションのサポートにより", "コスモミッションの報酬クレジットが一定回数アップするようになった"],
        Eng = ["receive", "cosmocredit"],
        Deu = ["bodenunterstützung", "limitierten", "missionsvergütungen"],
        Fra = ["intervention", "mécanique", "récompense"]
    };

    public static readonly LocalizedStrings OizysCreditObtain = new()
    {
        Jpn = ["オイジュスクレジット", "手に入れた"],
        Eng = ["obtain", "oizys", "credit"],
        Deu = ["oizys-tacken", "erhalten"],
        Fra = ["obtenez", "crédit", "oizys"]
    };

    public static readonly LocalizedStrings AuxesiaCreditObtain = new()
    {
        Jpn = ["アウクセシアクレジット", "手に入れた"],
        Eng = ["obtain", "auxesia"],
        Deu = ["auxesia-asche", "erhalten"],
        Fra = ["obtenez", "crédit", "auxesia"]
    };

    public static readonly LocalizedStrings OizysDronebitsObtain = new()
    {
        Jpn = ["オイジュス・ドローンチップ", "手に入れた"],
        Eng = ["obtain", "oizys", "dronebit"],
        Deu = ["oizys-drohnenchips", "erhalten"],
        Fra = ["obtenez", "drone", "oizys"]
    };
}
