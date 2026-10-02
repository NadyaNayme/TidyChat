using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Localization.Data;
namespace TidyChat.Tests;

// sample lines follow the game's own JA/DE/FR LogMessage templates, lowercased like normalized chat
[TestFixture]
public class LocalizedRegexTests
{
    [TearDown]
    public void TearDown() => L10N.Language = ClientLanguage.English;

    private static readonly object[] Matches =
    [
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.PvpCombatMessageRegex), "raven reaverは、ゴブリンを倒した。" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.PvpCombatMessageRegex), "du wurdest von raven reaver besiegt." },
        new object[] { ClientLanguage.German, nameof(ChatStrings.PvpCombatMessageRegex), "raven reaver bricht zusammen." },
        new object[] { ClientLanguage.French, nameof(ChatStrings.PvpCombatMessageRegex), "raven reaver reprend conscience." },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.JobChangeRegex), "youは「ナイト」にチェンジした。" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.JobChangeRegex), "du bist nun paladin." },
        new object[] { ClientLanguage.French, nameof(ChatStrings.JobChangeRegex), "vous êtes maintenant paladin." },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.JobRegisteredRegex), "ギアセット3「ナイト」を登録しました。" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.JobRegisteredRegex), "du hast das ausrüstungsset „paladin“ gespeichert." },
        new object[] { ClientLanguage.French, nameof(ChatStrings.JobRegisteredRegex), "vous enregistrez la tenue “paladin”." },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.JobSpecialistChangeRegex), "youは「マイスター鍛冶師」にチェンジした。" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.JobSpecialistChangeRegex), "du bist nun grobschmied (spezialist)." },
        new object[] { ClientLanguage.French, nameof(ChatStrings.JobSpecialistChangeRegex), "vous êtes maintenant forgeron (spécialiste)." },
        new object[] { ClientLanguage.German, nameof(ChatStrings.TradeReceiveItemsRegex), "du erhältst 3 eisenerz." },
        new object[] { ClientLanguage.French, nameof(ChatStrings.TradeReceiveItemsRegex), "vous recevez 3 minerai de fer." },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.SpideySensesRegex), "微かに不穏な気配を感じた……。" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.SpideySensesRegex), "du spürst deutlich eine bedrohliche aura ..." },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.DungeonMechanicDropsRegex), "雷管が爆薬を落とした！" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.DungeonMechanicDropsRegex), "die sprengkapsel hat eine prise sprengpulver fallen lassen!" },
        new object[] { ClientLanguage.French, nameof(ChatStrings.DungeonMechanicDropsRegex), "le détonateur fait tomber une pincée de poudre." },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.GatheringObtainNothingRegex), "何も入手できなかった。" },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.GatheringObtainNothingRegex), "raven reaverは何も入手できなかった。" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.GatheringObtainNothingRegex), "du hast nichts erhalten." },
        new object[] { ClientLanguage.French, nameof(ChatStrings.GatheringObtainNothingRegex), "vous n'obtenez rien." },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.GatheringUsesCollectabilityActionRegex), "youの「慎重純化」 収集価値が 10上昇した。" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.GatheringUsesCollectabilityActionRegex), "du setzt „fachkundige lese“ ein. sammlerwert um 10 gestiegen." },
        new object[] { ClientLanguage.French, nameof(ChatStrings.GatheringUsesCollectabilityActionRegex), "vous utilisez sélection méthodique. la valeur de collection augmente de 10 !" },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.TreasureCofferSenseRegex), "このエリアから、銀の宝箱1個、銅の宝箱2個の気配を感じる……！" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.TreasureCofferSenseRegex), "du spürst in dieser gegend 1 silberne truhe und 2 bronzene truhen!" },
        new object[] { ClientLanguage.French, nameof(ChatStrings.TreasureCofferSenseRegex), "vous ressentez la présence de 1 coffre en argent et 2 coffres en bronze dans cette zone." },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.NoTreasureCofferSenseRegex), "このエリアには、今は宝箱はなさそうだ……" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.NoTreasureCofferSenseRegex), "in dieser gegend scheint es keine schatztruhen zu geben ..." },
        new object[] { ClientLanguage.French, nameof(ChatStrings.NoTreasureCofferSenseRegex), "vous ne ressentez la présence d'aucun coffre dans cette zone..." },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.TreasurePotSenseRegex), "財宝の気配を、北方向のとても遠くから感じているようだ" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.TreasurePotSenseRegex), "du spürst eine schatztruhe sehr weit nördlich von dir!" },
        new object[] { ClientLanguage.French, nameof(ChatStrings.TreasurePotSenseRegex), "le trésor est très loin d'ici, au nord !" },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.HappyBunnyAbsentRegex), "近くにしあわせうさぎの気配は感じられない……" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.HappyBunnyOfferRegex), "der glückshase will dir als dank für das wonnemöhrchen seinen schatz überlassen!" },
        new object[] { ClientLanguage.French, nameof(ChatStrings.HappyBunnyOfferRegex), "le lapin du bonheur veut vous offrir un trésor pour vous remercier !" },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.MoochTipRegex), "泳がせ釣りのチャンス！" },
        new object[] { ClientLanguage.French, nameof(ChatStrings.MoochTipRegex), "ce poisson est parfait pour la pêche au vif !" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.MoochIILandRegex), "du hast einen fisch gefangen, der als naturköder ii geeignet ist." },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.MoochMissRegex), "泳がせ釣りのチャンスを失った。" },
        new object[] { ClientLanguage.Japanese, nameof(ChatStrings.SwimbaitKeepRegex), "スカルピンを泳がせ餌としてキープした。" },
        new object[] { ClientLanguage.German, nameof(ChatStrings.SwimbaitReleaseKeepRegex), "du lässt die groppe frei und behältst den barsch als köderfisch am haken." },
        new object[] { ClientLanguage.French, nameof(ChatStrings.SwimbaitReleaseRegex), "vous relâchez les prises conservées comme appâts pour la pêche au vif." }
    ];

    [TestCaseSource(nameof(Matches))]
    public void Localized_pattern_matches_game_line(ClientLanguage language, string field, string line)
    {
        L10N.Language = language;
        var regex = (LocalizedRegex)typeof(ChatStrings).GetField(field)!.GetValue(null)!;

        Assert.That(L10N.Get(regex).IsMatch(line), Is.True, L10N.Get(regex).ToString());
    }

    [TestCase(ClientLanguage.Japanese, "ゴブリンは「突進」の構え。", "ゴブリン", "突進")]
    [TestCase(ClientLanguage.German, "der goblin bereitet sich vor, ansturm einzusetzen.", "der goblin", "ansturm")]
    public void Enemy_readies_captures_actor_and_ability(ClientLanguage language, string line, string actor, string ability)
    {
        L10N.Language = language;
        var match = L10N.Get(ChatStrings.CombatEnemyReadiesRegex).Match(line);

        Assert.That(match.Success, Is.True);
        Assert.That(match.Groups["actor"].Value, Is.EqualTo(actor));
        Assert.That(match.Groups["ability"].Value, Is.EqualTo(ability));
    }

    [TestCase(ClientLanguage.Japanese, "ゴブリンの「突進」", "ゴブリン", "突進")]
    [TestCase(ClientLanguage.German, "der goblin setzt ansturm ein.", "der goblin", "ansturm")]
    public void Enemy_uses_captures_actor_and_ability(ClientLanguage language, string line, string actor, string ability)
    {
        L10N.Language = language;
        var match = L10N.Get(ChatStrings.CombatEnemyUsesRegex).Match(line);

        Assert.That(match.Success, Is.True);
        Assert.That(match.Groups["actor"].Value, Is.EqualTo(actor));
        Assert.That(match.Groups["ability"].Value, Is.EqualTo(ability));
    }

    [TestCase(ClientLanguage.Japanese, "youの「ファストブレード」")]
    [TestCase(ClientLanguage.German, "du setzt schneller schnitt ein.")]
    public void Own_actions_are_not_enemy_casts(ClientLanguage language, string line)
    {
        L10N.Language = language;

        Assert.That(L10N.Get(ChatStrings.CombatEnemyUsesRegex).IsMatch(line), Is.False);
    }
}
