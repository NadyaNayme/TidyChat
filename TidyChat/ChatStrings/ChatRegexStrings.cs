using System.Text.RegularExpressions;

namespace TidyChat
{
    public class ChatRegexStrings
    {
        public static Regex ObtainedGil { get; } = new Regex(@"You obtain (\d{1,3},)?\d{1,3} gil\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
      
        public static Regex ObtainedVenture { get; } = new Regex(@"You obtain a venture\.",
         RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static Regex ObtainedNuts { get; } = new Regex(@"You obtain (\d{1,3},)?\d{1,3} sacks of Nuts\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static Regex ObtainedSeals { get; } = new Regex(@"You obtain (\d{1,3},)?\d{1,3} (Flame|Maelstrom|Adder) Seals\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static Regex ObtainedClusters { get; } = new Regex(@"You obtain a cracked (.*)cluster\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ObtainedMaterials { get; } = new Regex(@"You obtain (.*) materials\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static Regex ObtainedShards { get; } = new Regex(@"You obtain \d{1,3} (fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }
}