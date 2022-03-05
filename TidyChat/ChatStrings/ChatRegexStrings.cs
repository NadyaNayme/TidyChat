using System.Text.RegularExpressions;

namespace TidyChat
{
   public  static class ChatRegexStrings
    {
        private readonly static RegexOptions regexOptions = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

        public readonly static Regex BetterPlayerCommendation = new(@"You received \d{1} (commendation|commendations)",
          regexOptions);

        /// <see href="https://xivapi.com/LogMessage/657?pretty=true">You obtain...</see>
       public readonly static LocalizedRegex ObtainedGil = new()
        {
            Jpn = new(@"ギルを手に入れた。$", regexOptions),
            Eng = new(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} gil\.", regexOptions),
            Deu = new(@"(du|you) hast (\d{1,3},)?\d{1,3} gil erhalten\.$", regexOptions),
            Fra = new(@"(vous|you) obtenez \d{1,6} gils\.$", regexOptions),
        };

       public readonly static LocalizedRegex ObtainedMGP = new()
        {
            Jpn = new(@"(\d{1,3},)?\d{1,3} MGP", regexOptions),
            Eng = new(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} MGP\.", regexOptions),
            Deu = new(@"(\d{1,3},)?\d{1,3} MGP erhalten\.", regexOptions),
            Fra = new(@"^(vous|you) (a|avez) reçu \d{1,6} PGS\.$", regexOptions),
        };

        /// <see href="https://xivapi.com/Item/25?pretty=true">Wolf Marks</see>
       public readonly static LocalizedRegex ObtainedWolfMarks = new()
        {
            Jpn = new(@"(\d{1,3},)?\d{1,3} 対人戦績", regexOptions),
            Eng = new(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} wolf marks\.", regexOptions),
            Deu = new(@"(\d{1,3},)?\d{1,3} wolfsmarken erhalten\.", regexOptions),
            Fra = new(@"^(vous|you) (a|avez) reçu \d{1,6} marque de loup\.$", regexOptions),
        };


        /// <see href="https://xivapi.com/Item/21072?pretty=true">Venture</see>
       public readonly static Regex ObtainedVenture = new(@"You (obtain|obtains) (a venture|2 ventures|3 ventures)\.", regexOptions);

        /// <see href="https://xivapi.com/Item/27?pretty=true">Allied Seals</see>
       public readonly static LocalizedRegex ObtainedAlliedSeals = new()
        {
            Jpn = new(@"^同盟記章を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions),
            Eng = new(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} Allied Seals\.", regexOptions),
            Deu = new(@"(\d{1,3},)?\d{1,3} jagdabzeichen erhalten\.", regexOptions),
            Fra = new(@"(vous|you) obtenez \d{1,6} insignes alliés\.$", regexOptions),
        };

        /// <see href="https://xivapi.com/Item/10307?pretty=true">Centurio Seals</see>
       public readonly static LocalizedRegex ObtainedCenturioSeals = new()
        {
            Jpn = new(@"^セントリオ記章を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions),
            Eng = new(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} Centurio Seals\.", regexOptions),
            Deu = new(@"(\d{1,3},)?\d{1,3} centurio-abzeichen erhalten\.", regexOptions),
            Fra = new(@"(vous|you) obtenez \d{1,6} insignes centurio\.$", regexOptions),
        };

       public readonly static LocalizedRegex ObtainedNuts = new()
        {
            Jpn = new(@"^モブハントの戦利品を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions),
            Eng = new(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} sacks of Nuts\.", regexOptions),
            Deu = new(@"(\d{1,3},)?\d{1,3} kupo-trophaë\.", regexOptions),
            Fra = new(@"(vous|you) obtenez \d{1,6} insignes de chasse\.$", regexOptions),
        };

        /// <see href="https://xivapi.com/Item/20?pretty=true">Storm Seals</see>
        /// <seealso href="https://xivapi.com/Item/21?pretty=true">Serpent Seals</see>
        /// <seealso href="https://xivapi.com/Item/22?pretty=true">Flame Seals</see>
       public readonly static LocalizedRegex ObtainedSeals = new()
        {
            Jpn = new(@"の軍票(\d{1,3},)?\d{1,3}枚を手に入れた。$", regexOptions),
            Eng = new(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} (Flame|Storm|Serpent) Seals\.", regexOptions),
            Deu = new(@"(flottentaler|ordenstaler|legionstaler) erhalten", regexOptions),
            Fra = new(@"(vous|you) obtenez \d{1,6} sceaux (de|des) (Immortels|Deux Vipères|Maelstrom)\.$", regexOptions),
        };

        /// <see href="https://xivapi.com/Item/2?pretty=true">Fire Shard</see>
        /// ...
        /// <seealso href="https://xivapi.com/Item/19?pretty=true">Water Cluster</see>
       public readonly static LocalizedRegex ObtainedClusters = new()
        {
            Jpn = new(@"クラスター(×2)?を(手に入れた|入手した)。$", regexOptions),
            Eng = new(@"You (obtain|obtains) (a|2) (.*)cluster\.", regexOptions),
            Deu = new(@"NeedsLocalization", regexOptions),
            Fra = new(@"NeedsLocalization", regexOptions),
        };

       public readonly static Regex ObtainedMaterials = new(@"You (obtain|obtains) (.*) materials\.", regexOptions);

       public readonly static Regex ObtainedShards = new(@"You (obtain|obtains) (a|an|\d{1,3}) .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.", regexOptions);

       public readonly static LocalizedRegex ObtainedTribalCurrency = new()
        {
            Jpn = new(@"NeedsTranslation", regexOptions),
            Eng = new(@"You (obtain|obtains) (a|an|2) (Steel Amalj'ok|Steel Amalj'oks|Sylphic Goldleaf|Sylphic Goldleaves|Titan Cobaltpiece|Titan Cobaltpieces|Rainbowtide Psashp|Rainbowtide Psashps|Ixali oaknot|Ixali oaknots|Vanu Whitebone|Vanu Whitebones|Black Copper Gil|Black Copper Gils|Carved Kupo Nut|Carved Kupo Nuts|Kojin Sango|Kojin Sangos|Ananta Dreamstaves|Ananta Dreamstaffs|Namazu Koban|Namazu Kobans|Fae Fancies|Fae Fancy|Qitari Compliment|Qitari Compliments|Hammered Frogment|Hammered Frogments)\.", regexOptions),
            Deu = new(@"(du|you) hast (einen|2) (Stahl-Amalj'ok|Sylphen-goldblatt|Titan-koboldeistenstück|Regenbogenwellen-Psashp|Ixal-eichenmünze|Vanu-Weißknochen|Schwarzkupfer-Gil|Kupo-Schnitznuss|Kohin-Koralle|Ananta-Traumstab|Namazuo-Koban|Pixie-Glitter|Qitari-Kastanienkreuzer|Zwergenmünze) erhalten\.$", regexOptions),
            Fra = new(@"NeedsTranslation", regexOptions),
        };

       public readonly static LocalizedRegex PlayerTargetedEmote = new()
        {
            Jpn = new(@"You|Your", regexOptions),
            Eng = new(@"you|your", regexOptions),
            Deu = new(@"you|your|du|deiner|dir|dich", regexOptions),
            Fra = new(@"you|your|vous", regexOptions),
        };

       public readonly static LocalizedRegex StartsWithYou = new()
        {
            Jpn = new(@"^(You|Your)", regexOptions),
            Eng = new(@"^(You|Your)", regexOptions),
            Deu = new(@"^(You|Your|du|deiner|dir|dich)", regexOptions),
            Fra = new(@"^(Vous)", regexOptions),
        };

       public readonly static LocalizedRegex CastLot = new()
        {
            Jpn = new(@"^youは.*にロットした。$", regexOptions),
            Eng = new(@"You (cast|casts) (your|his|her) lot for (.*)\.", regexOptions),
            Deu = new(@"NeedsLocalization", regexOptions),
            Fra = new(@"NeedsLocalization", regexOptions),
        };

       public readonly static LocalizedRegex RollsNeedOrGreed = new()
        {
            Jpn = new(@"^youは.+に(NEED|GREED)のダイスで\d{1,2}を出した。$", regexOptions),
            Eng = new(@"You (roll|rolls) (Need|Greed) on (.*)\. \d{1,2}\!", regexOptions),
            Deu = new(@"NeedsLocalization", regexOptions),
            Fra = new(@"NeedsLocalization", regexOptions),
        };

       public readonly static LocalizedRegex OthersCastLot = new()
        {
            // relies on the fact that all player names have a space between them (or a period if initialised)
            Jpn = new(@"^\w+[ .].+は.+にロットした。$", regexOptions),
            Eng = new(@"(.*) casts (his|her) lot for (.*)\.", regexOptions),
            Deu = new(@"NeedsLocalization", regexOptions),
            Fra = new(@"(.*) lance ses dés pour (la|le|les) (.*)\.", regexOptions),
        };

       public readonly static LocalizedRegex OthersRollNeedOrGreed = new()
        {
            Jpn = new(@"^\w+[ .].+は.+に(NEED|GREED)のダイスで\d{1,2}を出した。$", regexOptions),
            Eng = new(@"(.*) rolls (Need|Greed) on (.*)\. \d{1,2}\!", regexOptions),
            Deu = new(@"NeedsLocalization", regexOptions),
            Fra = new(@"(.*) jette les dés (Cupidité) pour (la|le|les) (.*)", regexOptions),
        };

       public readonly static LocalizedRegex YouObtainSystem = new()
        {
            Jpn = new(@"^youは.+を手に入れた。$", regexOptions),
            Eng = new(@"^you obtain.+", regexOptions),
            Deu = new(@"NeedsLocalization", regexOptions),
            Fra = new(@"^vous obtient", regexOptions),
        };

       public readonly static LocalizedRegex OtherObtains = new()
        {
            Jpn = new(@"^\w+[ .].+は.+を手に入れた。$", regexOptions),
            Eng = new(@"(.*) obtains .+", regexOptions),
            Deu = new(@"NeedsLocalization", regexOptions),
            Fra = new(@"(.*) obtient (un|une|\d{1,3}) .+", regexOptions),
        };

       public readonly static LocalizedRegex ItemSearchCommand = new()
        {
            Jpn = new(@"^\s{1,3}>>|を含む所持アイテムは(\d{1,4}種類見つかりました|ありませんでした)。$", regexOptions),
            Eng = new(@"(\s{1,3}>>|(No|\d{1,4}) (match|matches) found containing)", regexOptions),
            Deu = new(@"NeedsLocalization", regexOptions),
            Fra = new(@"NeedsLocalization", regexOptions),
        };

       public readonly static LocalizedRegex SearchForItemResults = new()
        {
            // TODO: items found in the armory chest, items in second tab of saddlebag
            Jpn = new(@"^ミラージュドレッサーに\d個あります。$|^愛蔵品キャビネット「.+」に\d個あります。$|に装備中です。$|合計\d{1,9}個見つかりました。|^所持品ブロック[1234]に\d{1,9}個あります。$|^チョコボかばんのかばんタブ[12]に\d{1,9}個あります。$", regexOptions),
            Eng = new(@"(\d (item|items) found in glamour dresser\.)|(\d (item|items) found in the .* section of the armoire\.)|(Currently equipped to .* slot)|(Total: \d{1,9} (item|items) found)|(\d{1,9} (item|items) found in the (1st|2nd|3rd|4th) tab of (your|.+'s) inventory)|\d{1,9} (item|items) found in saddlebag", regexOptions),
            Deu = new(@"NeedsLocalization", regexOptions),
            Fra = new(@"NeedsLocalization", regexOptions),
        };

       public readonly static LocalizedRegex ObtainedTomestones = new()
        {
            Jpn = new(@"^アラガントームストーン:([^を]+)を(\d{1,3}個手に入れた|入手した)。$", regexOptions),
            Eng = new(@"You (obtain|obtains) \d{1,3} Allagan tomestones of (\w+)", regexOptions),
            Deu = new(@"(du|you) hast \d{1,3} (Allagischer|Allagisch|Allagische|Allagischa) (Stein|Steine) (der|des) (\w+) erhalten\.$", regexOptions),
            Fra = new(@"(vous|you) obtenez \d{1,3} Mémoquartz allagois (\w+)", regexOptions),
        };

        /// <see href="https://xivapi.com/LogMessage/700?pretty=true">Gearset equipped.</see>
        // TODO: German/French need to be tested and may not use quotes for the gearsets.
       public readonly static LocalizedRegex GearsetEquipped = new()
        {
            Jpn = new(@"」に装備変更しました。$", regexOptions),
            Eng = new(@"“(.*)” equipped\.", regexOptions),
            Deu = new(@"Du hast „(.*)“ angelegt\.", regexOptions),
            Fra = new(@"vous vous équipez (.*)\.", regexOptions),
        };

        // Future proofing the materias a bit
       public readonly static Regex MateriaRetrieved = new(@"You (receive|receives) (a|an|2) .+ materia (I|II|III|IV|V|VI|VII|VIII|IX|X|XI|XII|XIII|XIV|XV|XVI|XVII|XVII|XIV|XV|XVI|XVII|XVII|XVIII|XIX)", regexOptions);

       public readonly static Regex MateriaShatters = new(@"The .+ materia (I|II|III|IV|V|VI|VII|VIII|IX|X|XI|XII|XIII|XIV|XV|XVI|XVII|XVII|XIV|XV|XVI|XVII|XVII|XVIII|XIX) shatters", regexOptions);

       public readonly static Regex AttachedMateria = new(@"You successfully attach (a|an) .+ materia (I|II|III|IV|V|VI|VII|VIII|IX|X|XI|XII|XIII|XIV|XV|XVI|XVII|XVII|XIV|XV|XVI|XVII|XVII|XVIII|XIX) to the", regexOptions);

        /// <see href="https://xivapi.com/LogMessage/3860?pretty=true">Master volume muted/unmuted</see>
        /// ...
        /// <seealso href="https://xivapi.com/LogMessage/3866?pretty=true">Performance volume muted/unmuted</see>
       public readonly static LocalizedRegex VolumeControls = new()
        {
            Jpn = new(@"をミュートしました。$|のミュートを解除しました。$|の音量を\d{1,3}に変更しました。$", regexOptions),
            Eng = new(@"volume (muted|unmuted|set to \d{1,3}\.)", regexOptions),
            Deu = new(@"NeedsLocalization", regexOptions),
            Fra = new(@"vous avez (activé|déactivé) (la|le|les|l'ambiance) (musqiue|volume général|effets sonores|voix|sons système|sonore|haut-parleur pour les sons système)\.", regexOptions),
        };

        /// <see href="https://xivapi.com/LogMessage/1063?pretty=true">You begin mining.</see>
        /// ...
        /// <seealso href="https://xivapi.com/LogMessage/1070?pretty=true">You finish harvesting.</see>
       public readonly static LocalizedRegex GatheringStartEnd = new()
        {
            Jpn = new(@"は(採掘|砕岩|伐採|草刈)を(開始した|終えた)", regexOptions),
            Eng = new(@"you (begin|finish) (mining|quarrying|logging|harvesting)\.", regexOptions),
            Deu = new(@"(du|deiner|dir|dich) (beginnst|beginnt|bist fertig mit dem|ist fertig mit dem) (abzubauen|herauszubrechen|abzuholzen|abzuernten|Abbauen|Herausbrechen|Abholzen|Abernten)", regexOptions),
            Fra = new(@"vous (commencez|arrêtez) (á extraire|d'extraire) (du minerai|des pierres|couper du bois|faucher de la végétation)\.", regexOptions),
        };

       public readonly static Regex AetherialReductionSands = new(@".+handfuls of .+ .+sand are obtained\.", regexOptions);

        /// <see href="https://xivapi.com/LogMessage/2012?pretty=true">Area will be sealed off in 15 seconds</see>
        /// <seealso href="https://xivapi.com/LogMessage/2013?pretty=true">Area is sealed off!</see>
        /// <seealso href="https://xivapi.com/LogMessage/2014?pretty=true">Area is no longer sealed!</see>
       public readonly static LocalizedRegex SealedOff = new()
        {
            Jpn = new(@"(の封鎖まであと|が封鎖された！|の封鎖が解かれた)", regexOptions),
            Eng = new(@"(will be sealed off in 15 seconds|is sealed off|is no longer sealed)", regexOptions),
            Deu = new(@"((sekunde|sekunden)\, bis sich .+ schließt\.|hat sich geschlossen\.|öffnet sich wieder\.)", regexOptions),
            Fra = new(@"(dans \d{1,2} secondes\.|Fermeture|Ouverture)", regexOptions),
        };

        // Name S. gains \d{1,4} (+\d{1,2}%) experience points.
       public readonly static LocalizedRegex GainExperiencePoints = new()
        {
            Jpn = new(@"ポイントの経験値を得た。$", regexOptions),
            Eng = new(@"(.* gains .* experience points\.)", regexOptions),
            Deu = new(@"NeedsLocalization", regexOptions),
            Fra = new(@".* gagnez .* points d'expérience\.", regexOptions),
        };

        /// <see href="https://xivapi.com/LogMessage/3085?pretty=true">Player has logged out</see>
       public readonly static LocalizedRegex HasLoggedIn = new()
        {
            Jpn = new(@"ポイント上昇した！$", regexOptions),
            Eng = new(@"(has|have) logged in\.$", regexOptions),
            Deu = new(@"hat sich eingeloggt\.$", regexOptions),
            Fra = new(@"s'est (connecté|connectée)\.$", regexOptions),
        };

        /// <see href="https://xivapi.com/LogMessage/3086?pretty=true">Player has logged out</see>
       public readonly static LocalizedRegex HasLoggedOut = new()
        {
            Jpn = new(@"がログアウトしました。$", regexOptions),
            Eng = new(@"has logged out\.$", regexOptions),
            Deu = new(@"hat sich ausgeloggt\.$", regexOptions),
            Fra = new(@"s'est (déconnecté|déconnectée)\.$", regexOptions),
        };

       public readonly static LocalizedRegex GetInstanceNumber = new()
        {
            Jpn = new(@"(?<instance>||)", regexOptions),
            Eng = new(@"(?<instance>||)", regexOptions),
            Deu = new(@"(?<instance>||)", regexOptions),
            Fra = new(@"(?<instance>||)", regexOptions),
        };

        /// <see href="https://xivapi.com/LogMessage/732?pretty=true">You have entered a sanctuary.</see>
       public readonly static LocalizedRegex EnteredSanctuary = new()
        {
            Jpn = new(@"レストエリアに入った", regexOptions),
            Eng = new(@"you have entered a sanctuary", regexOptions),
            Deu = new(@"du hast einen ruhebereich betreten", regexOptions),
            Fra = new(@"vous êtes (entré|entrée) dans un lieu de repos", regexOptions),
        };

        /// <see href="https://xivapi.com/LogMessage/733?pretty=true">You have left the sanctuary.</see>
       public readonly static LocalizedRegex LeftSanctuary = new()
        {
            Jpn = new(@"レストエリアから離れた", regexOptions),
            Eng = new(@"you have left the sanctuary", regexOptions),
            Deu = new(@"du hast den ruhebereich verlassen", regexOptions),
            Fra = new(@"vous aves quitté le lieu de repos", regexOptions),
        };

        /// <see href="https://xivapi.com/LogMessage/1351?pretty=true">You are currently not in an instanced area.</see>
       public readonly static LocalizedRegex NotInstancedArea = new()
        {
            Jpn = new(@"インスタンスエリアは存在しません", regexOptions),
            Eng = new(@"you are currently not in an instanced area", regexOptions),
            Deu = new(@"momentan ist das areal nicht instanziiert", regexOptions),
            Fra = new(@"il n'y a actuellement aucune zone instanciée", regexOptions),
        };

    }
}
