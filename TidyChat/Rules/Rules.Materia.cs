namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] MateriaCraftChannelRules =
    [
        new()
        {
            Name = "ShowAttachedMateria",
            SettingsTab = "Materia",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1201],
            StringChecks = [ChatStrings.MateriaAttach],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowOvermeldFailure",
            SettingsTab = "Materia",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1202],
            StringChecks = [ChatStrings.MateriaOvermeldFailure],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMateriaExtract",
            SettingsTab = "Materia",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1200],
            StringChecks = [ChatStrings.MateriaExtract],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] MateriaSystemChannelRules =
    [
        new()
        {
            Name = "ShowMateriaRetrieved",
            SettingsTab = "Materia",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1953, 1954]
        },
        new()
        {
            Name = "ShowMateriaRetrieved",
            SettingsTab = "Materia",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1953],
            StringChecks = [ChatStrings.MateriaAttemptRemove],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMateriaRetrieved",
            SettingsTab = "Materia",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1954],
            RegexChecks = [ChatStrings.MateriaRetrievedRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMateriaShatters",
            SettingsTab = "Materia",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1955]
        },
        new()
        {
            Name = "ShowMateriaShatters",
            SettingsTab = "Materia",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1955],
            StringChecks = [ChatStrings.MateriaShatters],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];
}
