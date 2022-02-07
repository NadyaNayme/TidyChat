namespace TidyChat
{
    public class ChatStrings
    {
        // You are now in the instanced area <zone> <instance>. To see this message again use /instance blah blah blah
        public static string[] InstancedArea { get; } = { "you", "are", "now", "in", "the", "instanced", "area" };

        // You received a player commendation!
        public static string[] PlayerCommendation { get; } = { "you", "received", "a", "player", "commendation" };

        // <duty> has ended
        public static string[] DutyEnded { get; } = { "has", "ended" };

    }
}