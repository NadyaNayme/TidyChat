using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{

    /// <see href="https://xivapi.com/LogMessage/84?pretty=true">You have gone offline.</see>
    public static readonly LocalizedStrings UserLogout = new()
    {
        Jpn = ["がオフラインになりました"],
        Eng = ["gone", "offline"],
        Deu = ["ausgeloggt"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/3086?pretty=true">You have logged out.</see>
    public static readonly LocalizedStrings UserLoggedOut = new()
    {
        Jpn = ["freecompany", "がログアウトしました"],
        Eng = ["logged", "out"],
        Deu = ["ausgeloggt"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1885?pretty=true">You have received a free company invite from …</see>
    public static readonly LocalizedStrings FreeCompanyInviteReceived = new()
    {
        Jpn = ["からフリーカンパニーに招待されました"],
        Eng = ["free", "company", "invite", "received"],
        Deu = ["wurdest", "gesellschaft", "eingeladen"],
        Fra = ["invité", "rejoindre", "compagnie"]
    };

    /// <see href="https://xivapi.com/LogMessage/1895?pretty=true">Free company invite from … canceled.</see>
    public static readonly LocalizedStrings FreeCompanyInviteCanceled = new()
    {
        Jpn = ["からのフリーカンパニー招待がキャンセルされました"],
        Eng = ["free", "company", "invite", "canceled"],
        Deu = ["einladung", "gesellschaft", "abgebrochen"],
        Fra = ["invitation", "rejoindre", "compagnie"]
    };

    /// <see href="https://xivapi.com/LogMessage/3127?pretty=true">Company action "…" is no longer active.</see>
    public static readonly LocalizedStrings CompanyActionExpired = new()
    {
        Jpn = ["カンパニーアクション", "終了"],
        Eng = ["company", "action", "no", "longer", "active"],
        Deu = ["gesellschaftskommandos", "geendet"],
        Fra = ["bienfait", "dissipés"]
    };
    /// <see href="https://xivapi.com/LogMessage/6057?pretty=true">Submersible has embarked on a subaquatic voyage.</see>
    public static readonly LocalizedStrings SubaquaticVoyageEmbarked = new()
    {
        Jpn = ["潜水艦", "が出港しました"],
        Eng = ["embarked", "subaquatic", "voyage"],
        Deu = ["tauchboot", "aufgebrochen"],
        Fra = ["marin", "expédition", "exploration"]
    };
    /// <see href="https://xivapi.com/LogMessage/6059?pretty=true">Submersible subaquatic voyage finalized.</see>
    /// <seealso href="https://xivapi.com/LogMessage/6060?pretty=true">Other player finalizes subaquatic voyage.</seealso>
    public static readonly LocalizedStrings SubaquaticVoyageFinalized = new()
    {
        Jpn = ["潜水艦", "の探索完了を確認しました"],
        Eng = ["subaquatic", "voyage", "finaliz"],
        Deu = ["abschluss", "erkundungsreise", "tauchboot"],
        Fra = ["finalisé", "expédition", "exploration"]
    };
    /// <see href="https://xivapi.com/LogMessage/4168?pretty=true">Submarine part has been repaired.</see>
    public static readonly LocalizedStrings SubmarinePartRepaired = new()
    {
        Jpn = ["潜水艦", "修理"],
        Eng = ["submarine", "part", "repaired"],
        Deu = ["tauchboot", "repariert"],
        Fra = ["sous-marin", "réparé"]
    };
    /// <see href="https://xivapi.com/LogMessage/6062?pretty=true">Submersible attains rank N!</see>
    public static readonly LocalizedStrings SubmarineAttainsRank = new()
    {
        Jpn = ["ランク", "潜水艦"],
        Eng = ["attains", "rank"],
        Deu = ["rang", "tauchboot"],
        Fra = ["sous-marin", "rang"]
    };
    /// <see href="https://xivapi.com/LogMessage/6092?pretty=true">Submersible's retrieval levels increased by N.</see>
    public static readonly LocalizedStrings SubmarineRetrievalLevelsIncreased = new()
    {
        Jpn = ["潜水艦", "上昇"],
        Eng = ["retrieval", "levels"],
        Deu = ["tauchboot", "gestiegen"],
        Fra = ["sous-marin", "augmenté"]
    };
}
