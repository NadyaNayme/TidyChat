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

        // You sense the presence of a powerful mark...
        public static string[] PowerfulMark { get; } = { "you", "sense", "the", "presense", "of", "a", "powerful" };
        // Retainer completed a venture.
        public static string[] CompletedVenture { get; } = { "completed", "a", "venture" };

    }
}