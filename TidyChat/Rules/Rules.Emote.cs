namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] EmoteRules =
    [
        new()
        {
            Name = "FilterEmoteChannel",
            SettingsTab = "Emotes",
            Channel = ChatType.StandardEmote,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.ContainsPlayerName],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowOtherCustomEmotes",
            SettingsTab = "Emotes",
            Channel = ChatType.CustomEmote,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.PlayerTargetedEmote],
            Pattern = PatternKind.RegexMatch
        }
    ];
}
