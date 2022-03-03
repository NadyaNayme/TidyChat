using System.Text.RegularExpressions;

namespace TidyChat
{
    public static class ChatRegexStrings
    {
        public static Regex BetterPlayerCommendation { get; } = new Regex(@"You received \d{1} (commendation|commendations)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

        /// <see href="https://xivapi.com/LogMessage/657?pretty=true">You obtain...</see>
        public static LocalizedRegex ObtainedGil { get; } = new()
        {
            Jpn = new Regex(@"ギルを手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} gil\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"(du|you) hast (\d{1,3},)?\d{1,3} gil erhalten\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"(vous|you) obtenez \d{1,6} gils\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex ObtainedMGP { get; } = new()
        {
            Jpn = new Regex(@"(\d{1,3},)?\d{1,3} MGP",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} MGP\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"(\d{1,3},)?\d{1,3} MGP erhalten\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"^(vous|you) (a|avez) reçu \d{1,6} PGS\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };


        /// <see href="https://xivapi.com/Item/21072?pretty=true">Venture</see>
        public static Regex ObtainedVenture { get; } = new Regex(@"You (obtain|obtains) (a venture|2 ventures|3 ventures)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

        /// <see href="https://xivapi.com/Item/27?pretty=true">Allied Seals</see>
        public static LocalizedRegex ObtainedAlliedSeals { get; } = new()
        {
            Jpn = new Regex(@"^同盟記章を(\d{1,3},)?\d{1,3}個手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} Allied Seals\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"(\d{1,3},)?\d{1,3} jagdabzeichen erhalten\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"(vous|you) obtenez \d{1,6} insignes alliés\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        /// <see href="https://xivapi.com/Item/10307?pretty=true">Centurio Seals</see>
        public static LocalizedRegex ObtainedCenturioSeals { get; } = new()
        {
            Jpn = new Regex(@"^セントリオ記章を(\d{1,3},)?\d{1,3}個手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} Centurio Seals\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"(\d{1,3},)?\d{1,3} centurio-abzeichen erhalten\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"(vous|you) obtenez \d{1,6} insignes centurio\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex ObtainedNuts { get; } = new()
        {
            Jpn = new Regex(@"^モブハントの戦利品を(\d{1,3},)?\d{1,3}個手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} sacks of Nuts\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"(\d{1,3},)?\d{1,3} kupo-trophaë\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"(vous|you) obtenez \d{1,6} insignes de chasse\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        /// <see href="https://xivapi.com/Item/20?pretty=true">Storm Seals</see>
        /// <seealso href="https://xivapi.com/Item/21?pretty=true">Serpent Seals</see>
        /// <seealso href="https://xivapi.com/Item/22?pretty=true">Flame Seals</see>
        public static LocalizedRegex ObtainedSeals { get; } = new()
        {
            Jpn = new Regex(@"の軍票(\d{1,3},)?\d{1,3}枚を手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} (Flame|Storm|Serpent) Seals\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"(flottentaler|ordenstaler|legionstaler) erhalten",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"(vous|you) obtenez \d{1,6} sceaux (de|des) (Immortels|Deux Vipères|Maelstrom)\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        /// <see href="https://xivapi.com/Item/2?pretty=true">Fire Shard</see>
        /// ...
        /// <seealso href="https://xivapi.com/Item/19?pretty=true">Water Cluster</see>
        public static LocalizedRegex ObtainedClusters { get; } = new()
        {
            Jpn = new Regex(@"クラスター(×2)?を(手に入れた|入手した)。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"You (obtain|obtains) (a|2) (.*)cluster\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static Regex ObtainedMaterials { get; } = new Regex(@"You (obtain|obtains) (.*) materials\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

        public static Regex ObtainedShards { get; } = new Regex(@"You (obtain|obtains) (a|an|\d{1,3}) .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

        public static LocalizedRegex ObtainedTribalCurrency { get; } = new()
        {
            Jpn = new Regex(@"NeedsTranslation",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"You (obtain|obtains) (a|an|2) (Steel Amalj'ok|Steel Amalj'oks|Sylphic Goldleaf|Sylphic Goldleaves|Titan Cobaltpiece|Titan Cobaltpieces|Rainbowtide Psashp|Rainbowtide Psashps|Ixali oaknot|Ixali oaknots|Vanu Whitebone|Vanu Whitebones|Black Copper Gil|Black Copper Gils|Carved Kupo Nut|Carved Kupo Nuts|Kojin Sango|Kojin Sangos|Ananta Dreamstaves|Ananta Dreamstaffs|Namazu Koban|Namazu Kobans|Fae Fancies|Fae Fancy|Qitari Compliment|Qitari Compliments|Hammered Frogment|Hammered Frogments)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"(du|you) hast (einen|2) (Stahl-Amalj'ok|Sylphen-goldblatt|Titan-koboldeistenstück|Regenbogenwellen-Psashp|Ixal-eichenmünze|Vanu-Weißknochen|Schwarzkupfer-Gil|Kupo-Schnitznuss|Kohin-Koralle|Ananta-Traumstab|Namazuo-Koban|Pixie-Glitter|Qitari-Kastanienkreuzer|Zwergenmünze) erhalten\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"NeedsTranslation",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex PlayerTargetedEmote { get; } = new()
        {
            Jpn = new Regex(@"You|Your",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"you|your",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"you|your|du|deiner|dir|dich",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"you|your|vous",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex StartsWithYou { get; } = new()
        {
            Jpn = new Regex(@"^(You|Your)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"^(You|Your)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"^(You|Your|du|deiner|dir|dich)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"^(Vous)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex CastLot { get; } = new()
        {
            Jpn = new Regex(@"^youは.*にロットした。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"You (cast|casts) (your|his|her) lot for (.*)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex RollsNeedOrGreed { get; } = new()
        {
            Jpn = new Regex(@"^youは.+に(NEED|GREED)のダイスで\d{1,2}を出した。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"You (roll|rolls) (Need|Greed) on (.*)\. \d{1,2}\!",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex OthersCastLot { get; } = new()
        {
            // relies on the fact that all player names have a space between them (or a period if initialised)
            Jpn = new Regex(@"^\w+[ .].+は.+にロットした。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"(.*) casts (his|her) lot for (.*)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"(.*) lance ses dés pour (la|le|les) (.*)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex OthersRollNeedOrGreed { get; } = new()
        {
            Jpn = new Regex(@"^\w+[ .].+は.+に(NEED|GREED)のダイスで\d{1,2}を出した。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"(.*) rolls (Need|Greed) on (.*)\. \d{1,2}\!",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"(.*) jette les dés (Cupidité) pour (la|le|les) (.*)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex YouObtainSystem { get; } = new()
        {
            Jpn = new Regex(@"^youは.+を手に入れた。$",
                  RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"^you obtain.+",
                  RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"NeedsLocalization",
                  RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"^vous obtient",
                  RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex OtherObtains { get; } = new()
        {
            Jpn = new Regex(@"^\w+[ .].+は.+を手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"(.*) obtains .+",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"(.*) obtient (un|une|\d{1,3}) .+",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex ItemSearchCommand { get; } = new()
        {
            Jpn = new Regex(@"^\s{1,3}>>|を含む所持アイテムは(\d{1,4}種類見つかりました|ありませんでした)。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"(\s{1,3}>>|(No|\d{1,4}) (match|matches) found containing)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex SearchForItemResults { get; } = new()
        {
            // TODO: items found in the armory chest, items in second tab of saddlebag
            Jpn = new Regex(@"^ミラージュドレッサーに\d個あります。$|^愛蔵品キャビネット「.+」に\d個あります。$|に装備中です。$|合計\d{1,9}個見つかりました。|^所持品ブロック[1234]に\d{1,9}個あります。$|^チョコボかばんのかばんタブ[12]に\d{1,9}個あります。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"(\d (item|items) found in glamour dresser\.)|(\d (item|items) found in the .* section of the armoire\.)|(Currently equipped to .* slot)|(Total: \d{1,9} (item|items) found)|(\d{1,9} (item|items) found in the (1st|2nd|3rd|4th) tab of (your|.+'s) inventory)|\d{1,9} (item|items) found in saddlebag",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex ObtainedTomestones { get; } = new()
        {
            Jpn = new Regex(@"^アラガントームストーン:([^を]+)を(\d{1,3}個手に入れた|入手した)。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"You (obtain|obtains) \d{1,3} Allagan tomestones of (\w+)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"(du|you) hast \d{1,3} (Allagischer|Allagisch|Allagische|Allagischa) (Stein|Steine) (der|des) (\w+) erhalten\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"(vous|you) obtenez \d{1,3} Mémoquartz allagois (\w+)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        /// <see href="https://xivapi.com/LogMessage/700?pretty=true">Gearset equipped.</see>
        // TODO: German/French need to be tested and may not use quotes for the gearsets.
        public static LocalizedRegex GearsetEquipped { get; } = new()
        {
            Jpn = new Regex(@"」に装備変更しました。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"“(.*)” equipped\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"Du hast „(.*)“ angelegt\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"vous vous équipez (.*)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        // Future proofing the materias a bit
        public static Regex MateriaRetrieved { get; } = new Regex(@"You (receive|receives) (a|an|2) .+ materia (I|II|III|IV|V|VI|VII|VIII|IX|X|XI|XII|XIII|XIV|XV|XVI|XVII|XVII|XIV|XV|XVI|XVII|XVII|XVIII|XIX)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

        public static Regex MateriaShatters { get; } = new Regex(@"The .+ materia (I|II|III|IV|V|VI|VII|VIII|IX|X|XI|XII|XIII|XIV|XV|XVI|XVII|XVII|XIV|XV|XVI|XVII|XVII|XVIII|XIX) shatters",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

        public static Regex AttachedMateria { get; } = new Regex(@"You successfully attach (a|an) .+ materia (I|II|III|IV|V|VI|VII|VIII|IX|X|XI|XII|XIII|XIV|XV|XVI|XVII|XVII|XIV|XV|XVI|XVII|XVII|XVIII|XIX) to the",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

        /// <see href="https://xivapi.com/LogMessage/3860?pretty=true">Master volume muted/unmuted</see>
        /// ...
        /// <seealso href="https://xivapi.com/LogMessage/3866?pretty=true">Performance volume muted/unmuted</see>
        public static LocalizedRegex VolumeControls { get; } = new()
        {
            Jpn = new Regex(@"をミュートしました。$|のミュートを解除しました。$|の音量を\d{1,3}に変更しました。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"volume (muted|unmuted|set to \d{1,3}\.)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"vous avez (activé|déactivé) (la|le|les|l'ambiance) (musqiue|volume général|effets sonores|voix|sons système|sonore|haut-parleur pour les sons système)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        /// <see href="https://xivapi.com/LogMessage/1063?pretty=true">You begin mining.</see>
        /// ...
        /// <seealso href="https://xivapi.com/LogMessage/1070?pretty=true">You finish harvesting.</see>
        public static LocalizedRegex GatheringStartEnd { get; } = new()
        {
            Jpn = new Regex(@"は(採掘|砕岩|伐採|草刈)を(開始した|終えた)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"you (begin|finish) (mining|quarrying|logging|harvesting)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"(du|deiner|dir|dich) (beginnst|beginnt|bist fertig mit dem|ist fertig mit dem) (abzubauen|herauszubrechen|abzuholzen|abzuernten|Abbauen|Herausbrechen|Abholzen|Abernten)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"vous (commencez|arrêtez) (á extraire|d'extraire) (du minerai|des pierres|couper du bois|faucher de la végétation)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static Regex AetherialReductionSands { get; } = new Regex(@".+handfuls of .+ .+sand are obtained\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

        /// <see href="https://xivapi.com/LogMessage/2012?pretty=true">Area will be sealed off in 15 seconds</see>
        /// <seealso href="https://xivapi.com/LogMessage/2013?pretty=true">Area is sealed off!</see>
        /// <seealso href="https://xivapi.com/LogMessage/2014?pretty=true">Area is no longer sealed!</see>
        public static LocalizedRegex SealedOff { get; } = new()
        {
            Jpn = new Regex(@"(の封鎖まであと|が封鎖された！|の封鎖が解かれた)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"(will be sealed off in 15 seconds|is sealed off|is no longer sealed)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"((sekunde|sekunden)\, bis sich .+ schließt\.|hat sich geschlossen\.|öffnet sich wieder\.)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"(dans \d{1,2} secondes\.|Fermeture|Ouverture)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        // Name S. gains \d{1,4} (+\d{1,2}%) experience points.
        public static LocalizedRegex GainExperiencePoints { get; } = new()
        {
            Jpn = new Regex(@"ポイントの経験値を得た。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"(.* gains .* experience points\.)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"NeedsLocalization",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@".* gagnez .* points d'expérience\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        /// <see href="https://xivapi.com/LogMessage/3085?pretty=true">Player has logged out</see>
        public static LocalizedRegex HasLoggedIn { get; } = new()
        {
            Jpn = new Regex(@"ポイント上昇した！$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"(has|have) logged in\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"hat sich eingeloggt\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"s'est (connecté|connectée)\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        /// <see href="https://xivapi.com/LogMessage/3086?pretty=true">Player has logged out</see>
        public static LocalizedRegex HasLoggedOut { get; } = new()
        {
            Jpn = new Regex(@"がログアウトしました。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"has logged out\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"hat sich ausgeloggt\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"s'est (déconnecté|déconnectée)\.$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        public static LocalizedRegex GetInstanceNumber { get; } = new()
        {
            Jpn = new Regex(@"(?<instance>||)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"(?<instance>||)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"(?<instance>||)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"(?<instance>||)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        /// <see href="https://xivapi.com/LogMessage/732?pretty=true">You have entered a sanctuary.</see>
        public static LocalizedRegex EnteredSanctuary { get; } = new()
        {
            Jpn = new Regex(@"レストエリアに入った",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"you have entered a sanctuary",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"du hast einen ruhebereich betreten",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"vous êtes (entré|entrée) dans un lieu de repos",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        /// <see href="https://xivapi.com/LogMessage/733?pretty=true">You have left the sanctuary.</see>
        public static LocalizedRegex LeftSanctuary { get; } = new()
        {
            Jpn = new Regex(@"レストエリアから離れた",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"you have left the sanctuary",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"du hast den ruhebereich verlassen",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"vous aves quitté le lieu de repos",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

        /// <see href="https://xivapi.com/LogMessage/1351?pretty=true">You are currently not in an instanced area.</see>
        public static LocalizedRegex NotInstancedArea { get; } = new()
        {
            Jpn = new Regex(@"インスタンスエリアは存在しません",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Eng = new Regex(@"you are currently not in an instanced area",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Deu = new Regex(@"momentan ist das areal nicht instanziiert",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
            Fra = new Regex(@"il n'y a actuellement aucune zone instanciée",
          RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
        };

    }
}
