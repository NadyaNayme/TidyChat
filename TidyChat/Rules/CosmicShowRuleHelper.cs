using TidyChat.Translation.Data;
namespace TidyChat;

/// <summary>
/// Cosmic lines have dedicated show toggles; broad Obtain and other rules must not override them.
/// </summary>
internal static class CosmicShowRuleHelper
{
    public static bool IsCosmicRuleName(string ruleName) =>
        ruleName is "ShowCosmicExplorationMessages" or "ShowCosmicRewards" or "ShowCosmicContainers" or
        "ShowCosmicDailyProgress";

    /// <summary>
    /// True when the message is cosmic-related and the matching Crafting/Gathering toggle is enabled.
    /// </summary>
    public static bool IsCosmicMessageAllowed(Configuration config, string normalizedText) =>
        GetActiveCosmicRuleName(config, normalizedText) is not null;

    public static string? GetActiveCosmicRuleName(Configuration config, string normalizedText)
    {
        if (config.ShowCosmicContainers && MatchesCosmicContainerText(normalizedText))
            return "ShowCosmicContainers";
        if (config.ShowCosmicRewards && MatchesCosmicCurrencyRewardText(normalizedText))
            return "ShowCosmicRewards";
        if (config.ShowCosmicExplorationMessages && MatchesCosmicExplorationText(normalizedText))
            return "ShowCosmicExplorationMessages";
        if (config.ShowCosmicDailyProgress && MatchesCosmicDailyProgressText(normalizedText))
            return "ShowCosmicDailyProgress";
        return null;
    }

    /// <summary>
    /// Non-cosmic rules must not claim cosmic lines while a cosmic show toggle is on for that text.
    /// </summary>
    public static bool ShouldDeferNonCosmicRule(Configuration config, string normalizedText) =>
        IsCosmicMessageAllowed(config, normalizedText);

    public static bool ShouldDeferGeneralObtainRule(Configuration config, string normalizedText) =>
        ShouldDeferNonCosmicRule(config, normalizedText);

    public static bool MatchesCosmicContainerText(string normalizedText) =>
        MatchesAnyMarker(normalizedText, ChatStrings.CosmicContainerObtain);

    public static bool MatchesCosmicCurrencyRewardText(string normalizedText) =>
        MatchesAnyMarker(normalizedText,
            ChatStrings.CosmocreditObtain,
            ChatStrings.CosmocreditReceived,
            ChatStrings.OizysCreditObtain,
            ChatStrings.AuxesiaCreditObtain,
            ChatStrings.OizysDronebitsObtain,
            ChatStrings.CosmicFortuneObtain);

    public static bool MatchesCosmicRewardText(string normalizedText) =>
        MatchesCosmicContainerText(normalizedText) || MatchesCosmicCurrencyRewardText(normalizedText);

    public static bool MatchesCosmicExplorationText(string normalizedText) =>
        MatchesAnyMarker(normalizedText, ChatStrings.MechOpDirective, ChatStrings.CosmicRedAlert);

    public static bool MatchesCosmicDailyProgressText(string normalizedText) =>
        MatchesAnyMarker(normalizedText,
            ChatStrings.CosmicDatasetSubmitted,
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
