namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] OrchestrionRules =
    [

        new()
        {
            Name = "HideOrchestrionPlaying",
            SettingsTab = "System",
            Channel = ChatType.Orchestrion,
            IsActive = false,
            BlockWhenActive = true,
            LogMessageIds = [3433]
        },

    ];
}
