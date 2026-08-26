namespace TidyChat;

internal static class ChannelFilterPolicy
{
    public static bool IsCombatLogChannel(ChatType chatType) => chatType switch
    {
        ChatType.Damage or
            ChatType.Miss or
            ChatType.Action or
            ChatType.Healing or
            ChatType.Item or
            ChatType.GainBuff or
            ChatType.GainDebuff or
            ChatType.LoseBuff or
            ChatType.LoseDebuff => true,
        _ => false
    };
}
