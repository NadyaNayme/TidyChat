namespace TidyChat
{
    public class ChatStrings
    {
        // You are now in the instanced area <zone> <instance>. Current instance can be confirmed at any time using the /instance text command.
        public static string[] InstancedArea { get; } = { "you", "are", "now", "in", "the", "instanced", "area" };

        // You received a player commendation!
        public static string[] PlayerCommendation { get; } = { "you", "received", "a", "player", "commendation" };

        // <duty> has ended
        public static string[] DutyEnded { get; } = { "has", "ended" };

        // The guildhest will end soon
        public static string[] GuildhestEnded { get; } = { "the", "guildhest", "will", "end", "soon" };
        // With the chat mode in Say, enter a phrase containing "Some Words"
        public static string[] SayQuestReminder { get; } = { "with", "the", "chat", "mode", "in" };

        // You sense the presence of a powerful mark...
        public static string[] PowerfulMark { get; } = { "you", "sense", "the", "presence", "of", "a", "powerful", "mark" };

        // You minions of an extraordinarily powerful mark...
        public static string[] ExtraordinarilyPowerfulMark { get; } = { "the", "minions", "of", "an", "extraordinarily", "powerful", "mark", };

        // Retainer completed a venture.
        public static string[] CompletedVenture { get; } = { "completed", "a", "venture" };

        //You gain \d <class> experience points
        public static string[] GainExperiencePoints { get; } = { "you", "gain", "experience", "points" };

        // A bonus of 1,200,000 experience points and 12,000 gil has been awards for using the duty roulette.
        public static string[] RouletteBonusExperiencePoints { get; } = { "a", "bonus", "of", "experience", "points", "and", "gil", "has", "been", "awarded", "for", "using", "the", "duty", "roulette" };

        //You acquire \d Pvp EXP.
        public static string[] GainPvpExp { get; } = { "you", "acquire", "pvp", "exp" };

        //You earn the achievement <achievement>
        public static string[] EarnAchievement { get; } = { "you", "earn", "the", "achievement" };

        // You synthesize a/an <item>
        public static string[] YouSynthesize { get; } = { "you", "synthesize" };

        // <Player> has logged out.
        public static string[] HasLoggedOut { get; } = { "has", "logged", "out" };

        // Tomestones
        public static string[] ObtainedTomesetones { get; } = { "You", "obtain", "Allagan", "tomestones", "of" };

        // Ready Check
        public static string[] ReadyCheckComplete { get; } = { "ready", "check", "complete" };

        // Level Ups
        public static string[] YouAttainLevel { get; } = { "you", "attain", "level" };

        // Ability Unlocks
        public static string[] YouLearnAbility { get; } = { "you", "learn" };

        // Countdown
        public static string[] CountdownTime { get; } = { "battle", "commencing", "in", "seconds" };

        // Teleporting to <Location>...
        public static string[] DebugTeleport { get; } = { "teleporting", "to" };

        // You sense something...
        public static string[] SpideySenses { get; } = { "you", "sense", "something" };

        // The compass detects a current approximately <##> yalms to the <direction>...
        public static string[] AetherCompass { get; } = { "the", "compass", "detects", "a", "current", "approximately" };

        // Glamours projected from plate <##>
        public static string[] GlamoursProjected { get; } = { "glamours", "projected", "from", "plate" };
        // Overmelding fail
        // You are unable to attach the materia to the <item>. The <materia> was lost.
        public static string[] OvermeldFailure { get; } = { "you", "are", "unable", "to", "attach", "the", "materia", "to" };
    }
}
