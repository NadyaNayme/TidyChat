using TidyChat.Translation.Data;
namespace TidyChat;

/// <summary>
/// Cosmic lines have dedicated show toggles; broad Obtain "you obtain" rules must not override them.
/// </summary>
internal static class CosmicShowRuleHelper
{
    public static bool ShouldDeferGeneralObtainRule(Configuration config, string normalizedText)
    {
        if (config.ShowCosmicRewards && MatchesCosmicRewardText(normalizedText))
            return true;
        if (config.ShowCosmicExplorationMessages && MatchesCosmicExplorationText(normalizedText))
            return true;
        if (config.ShowCosmicDailyProgress && MatchesCosmicDailyProgressText(normalizedText))
            return true;
        return false;
    }

    public static bool MatchesCosmicRewardText(string normalizedText) =>
        MatchesAnyMarker(normalizedText,
            ChatStrings.CosmocreditObtain,
            ChatStrings.OizysCreditObtain,
            ChatStrings.OizysDronebitsObtain,
            ChatStrings.CosmicFortuneObtain,
            ChatStrings.CosmicContainerObtain);

    public static bool MatchesCosmicExplorationText(string normalizedText) =>
        MatchesAnyMarker(normalizedText, ChatStrings.MechOpDirective, ChatStrings.CosmicRedAlert);

    public static bool MatchesCosmicDailyProgressText(string normalizedText) =>
        MatchesAnyMarker(normalizedText,
            ChatStrings.CosmicClassPoints,
            ChatStrings.DailyPointsEarned,
            ChatStrings.DailySuccessAchieved,
            ChatStrings.DailySuccessGoalAchieved);

    private static bool MatchesAnyMarker(string normalizedText, params LocalizedStrings[] markers)
    {
        foreach (LocalizedStrings marker in markers)
        {
            if (L10N.Get(marker).All(normalizedText.Contains))
                return true;
        }

        return false;
    }
}
