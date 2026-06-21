namespace TidyChat;

/// <summary>
///     Channel invariants: combat log lines are never filtered; error lines are only
///     hidden by explicit hide rules that expose a settings toggle.
/// </summary>
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

    public static bool IsErrorChannel(ChatType chatType) => chatType is ChatType.Error;

    /// <summary>Combat log channels skip <see cref="TidyChatPlugin.EvaluateChannelRules" /> entirely.</summary>
    public static bool ShouldBypassChannelRules(ChatType chatType) => IsCombatLogChannel(chatType);
}
