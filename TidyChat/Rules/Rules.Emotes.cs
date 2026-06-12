namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] EmotesRules =
    [
        new()
        {
            Name = "FilterEmoteChannel",
            SettingsTab = "Emotes",
            Channel = ChatType.StandardEmote,
            IsActive = true,
            RegexChecks = [ChatStrings.ContainsPlayerName],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowOtherCustomEmotes",
            SettingsTab = "Emotes",
            Channel = ChatType.CustomEmote,
            IsActive = true,
            RegexChecks = [ChatStrings.PlayerTargetedEmote],
            Pattern = PatternKind.RegexMatch
        }
    ];
}
