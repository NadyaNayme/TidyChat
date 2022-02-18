using System.Text.RegularExpressions;

namespace TidyChat
{
    public static class ChatRegexStrings
    {
        public static Regex BetterPlayerCommendation { get; } = new Regex(@"You received \d{1} (commendation|commendations)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static LocalizedRegex ObtainedGil { get; } = new()
        {
            En = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} gil\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"ギルを手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
        };
        public static Regex ObtainedMGP { get; } = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} MGP\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedVenture { get; } = new Regex(@"You (obtain|obtains) (a venture|2 ventures)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static LocalizedRegex ObtainedAlliedSeals { get; } = new()
        {
            En = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} Allied Seals\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"^同盟記章を(?:\d{1,3},)?\d{1,3}個手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
        };
        public static LocalizedRegex ObtainedCenturioSeals { get; } = new()
        {
            En = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} Centurio Seals\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"^セントリオ記章を(?:\d{1,3},)?\d{1,3}個手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
        };
        public static LocalizedRegex ObtainedNuts { get; } = new()
        {
            En = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} sacks of Nuts\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"^モブハントの戦利品を(?:\d{1,3},)?\d{1,3}個手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
        };
        public static LocalizedRegex ObtainedSeals { get; } = new()
        {
            En = new Regex(@"You (obtain|obtains) (\d{1,3},)?\d{1,3} (Flame|Storm|Serpent) Seals\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"の軍票(?:\d{1,3},)?\d{1,3}枚を手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        public static LocalizedRegex ObtainedClusters { get; } = new()
        {
            En = new Regex(@"You (obtain|obtains) (a|2) (.*)cluster\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"クラスター(?:×2)?を(?:手に入れた|入手した)。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        public static Regex ObtainedMaterials { get; } = new Regex(@"You (obtain|obtains) (.*) materials\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedShards { get; } = new Regex(@"You (obtain|obtains) \d{1,3} .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedTribalCurrency { get; } = new Regex(@"You (obtain|obtains) (a|an|2) (Steel Amalj'ok|Steel Amalj'oks|Sylphic Goldleaf|Sylphic Goldleaves|Titan Cobaltpiece|Titan Cobaltpieces|Rainbowtide Psashp|Rainbowtide Psashps|Ixali oaknot|Ixali oaknots|Vanu Whitebone|Vanu Whitebones|Black Copper Gil|Black Copper Gils|Carved Kupo Nut|Carved Kupo Nuts|Kojin Sango|Kojin Sangos|Ananta Dreamstaves|Ananta Dreamstaffs|Namazu Koban|Namazu Kobans|Fae Fancies|Fae Fancy|Qitari Compliment|Qitari Compliments|Hammered Frogment|Hammered Frogments)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex PlayerTargetedEmote { get; } = new Regex(@"you|your",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex PlayerUsedEmote { get; } = new Regex(@"^(You|Your)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static LocalizedRegex CastLot { get; } = new()
        {
            En = new Regex(@"You (cast|casts) (your|his|her) lot for (.*)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"^youは.*にロットした。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        public static LocalizedRegex RollsNeedOrGreed { get; } = new()
        {
            En = new Regex(@"You (roll|rolls) (Need|Greed) on (.*)\. \d{1,2}\!",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"^youは.+に(?:NEED|GREED)のダイスで\d{1,2}を出した。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        public static LocalizedRegex OthersCastLot { get; } = new()
        {
            En = new Regex(@".* casts (his|her) lot for (.*)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            // relies on the fact that all player names have a space between them (or a period if initialised)
            Ja = new Regex(@"^\w+[ .].+は.+にロットした。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        public static LocalizedRegex OthersRollNeedOrGreed { get; } = new()
        {
            En = new Regex(@".* rolls (Need|Greed) on (.*)\. \d{1,2}\!",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"^\w+[ .].+は.+に(?:NEED|GREED)のダイスで\d{1,2}を出した。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        public static LocalizedRegex OthersObtain { get; } = new()
        {
            En = new Regex(@".* obtains .+",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"^\w+[ .].+は.+を手に入れた。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
        };
        public static LocalizedRegex ItemSearchCommand { get; } = new()
        {
            En = new Regex(@"(\s{1,3}>>|(No|\d{1,4}) (match|matches) found containing)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"^\s{1,3}>>|を含む所持アイテムは(?:\d{1,4}種類見つかりました|ありませんでした)。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        public static LocalizedRegex SearchForItemResults { get; } = new()
        {
            // TODO: items found in the armory chest, items in second tab of saddlebag
            En = new Regex(@"(\d (item|items) found in glamour dresser\.)|(\d (item|items) found in the .* section of the armoire\.)|(Currently equipped to .* slot)|(Total: \d{1,9} (item|items) found)|(\d{1,9} (item|items) found in the (1st|2nd|3rd|4th) tab of (your|.+'s) inventory)|\d{1,9} (item|items) found in saddlebag",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"^ミラージュドレッサーに\d個あります。$|^愛蔵品キャビネット「.+」に\d個あります。$|に装備中です。$|合計\d{1,9}個見つかりました。|^所持品ブロック[1234]に\d{1,9}個あります。$|^チョコボかばんのかばんタブ[12]に\d{1,9}個あります。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        public static LocalizedRegex ObtainedTomestones { get; } = new()
        {
            En = new Regex(@"You (?:obtain|obtains) \d{1,3} Allagan tomestones of (\w+)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"^アラガントームストーン:([^を]+)を(?:\d{1,3}個手に入れた|入手した)。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        public static LocalizedRegex GearsetEquipped { get; } = new()
        {
            En = new Regex(@"“(.*)” equipped\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"」に装備変更しました。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        // Future proofing the materias a bit
        public static Regex MateriaRetrieved { get; } = new Regex(@"You (receive|receives) (a|an|2) .+ materia (I|II|III|IV|V|VI|VII|VIII|IX|X|XI|XII|XIII|XIV|XV|XVI|XVII|XVII|XIV|XV|XVI|XVII|XVII|XVIII|XIX)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex MateriaShatters { get; } = new Regex(@"The .+ materia (I|II|III|IV|V|VI|VII|VIII|IX|X|XI|XII|XIII|XIV|XV|XVI|XVII|XVII|XIV|XV|XVI|XVII|XVII|XVIII|XIX) shatters",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex AttachedMateria { get; } = new Regex(@"You successfully attach (a|an) .+ materia (I|II|III|IV|V|VI|VII|VIII|IX|X|XI|XII|XIII|XIV|XV|XVI|XVII|XVII|XIV|XV|XVI|XVII|XVII|XVIII|XIX) to the",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static LocalizedRegex VolumeControls { get; } = new()
        {
            Ja = new Regex(@"volume (muted|unmuted|set to \d{1,3}\.)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            En = new Regex(@"をミュートしました。$|のミュートを解除しました。$|の音量を\d{1,3}に変更しました。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
        };
        public static Regex GatheringStartEnd { get; } = new Regex(@"You (begin|finish) (mining|quarrying|logging|harvesting)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex AetherialReductionSands { get; } = new Regex(@".+handfuls of .+ .+sand are obtained\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex SealedOff { get; } = new Regex(@"(will be sealed off in 15 seconds|is sealed off|is no longer sealed)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        // Name S. gains \d{1,4} (+\d{1,2}%) experience points.
        public static LocalizedRegex GainExperiencePoints { get; } = new()
        {
            En = new Regex(@"(.* gains .* experience points\.)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase),
            Ja = new Regex(@"ポイントの経験値を得た。$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        // <Player Name> has logged out.
        public static Regex HasLoggedOut { get; } = new Regex(@"(.* has logged out\.)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }
}
