﻿using System.Text.RegularExpressions;

namespace TidyChat
{
    public class ChatRegexStrings
    {
        public static Regex BetterPlayerCommendation { get; } = new Regex(@"You received \d{1} (commendation|commendations)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedGil { get; } = new Regex(@"You obtain (\d{1,3},)?\d{1,3} gil\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static Regex ObtainedMGP { get; } = new Regex(@"You obtain (\d{1,3},)?\d{1,3} MGP\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedVenture { get; } = new Regex(@"You obtain (a venture|2 ventures)\.",
         RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedAlliedSeals { get; } = new Regex(@"You obtain (\d{1,3},)?\d{1,3} Allied Seals\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedCenturioSeals { get; } = new Regex(@"You obtain (\d{1,3},)?\d{1,3} Centurio Seals\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedNuts { get; } = new Regex(@"You obtain (\d{1,3},)?\d{1,3} sacks of Nuts\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedSeals { get; } = new Regex(@"You obtain (\d{1,3},)?\d{1,3} (Flame|Storm|Serpent) Seals\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedClusters { get; } = new Regex(@"You obtain a (.*)cluster\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedMaterials { get; } = new Regex(@"You obtain (.*) materials\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedShards { get; } = new Regex(@"You obtain \d{1,3} (fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedTribalCurrency { get; } = new Regex(@"You obtain a (Steel Amalj'ok|Sylphic Goldleaf|Titan Cobaltpiece|Rainbowtide Psashp|Ixali Oaknot|Vanu Whitebone|Black Copper Gil|Carved Kupo Nut|Kojin Sango|Ananta Dreamstaff|namazu Koban|Fae Fancy|Qitari Compliment|Hammered Frogment)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex PlayerTargetedEmote { get; } = new Regex(@"you|your",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex PlayerUsedEmote { get; } = new Regex(@"^(You|Your)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex CastLot { get; } = new Regex(@"You cast your lot for the (.*)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex RollsNeedOrGreed { get; } = new Regex(@"You roll (Need|Greed) on the (.*)\. \d{1,2}\!",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ItemSearchCommand { get; } = new Regex(@"(\s{1,3}>>|(No|\d{1,4}) (match|matches) found containing)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedTomestones { get; } = new Regex(@"You obtain \d{1,3} Allagan tomestones of",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }
}