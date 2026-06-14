namespace TidyChat;

internal static class CosmicShowRuleHelper
{
    public static bool IsCosmicRuleName(string ruleName) =>
        ruleName is "ShowCosmicExplorationMessages" or
            "ShowCosmicRewards" or
            "ShowCosmicContainers" or
            "ShowCosmicClassPointsAndDataset" or
            "ShowCosmicDailyProgress";

    public static bool IsCosmicMessageAllowed(Configuration config, string normalizedText) =>
        GetActiveCosmicRuleName(config, normalizedText) is not null;

    public static string? GetActiveCosmicRuleName(Configuration config, string normalizedText)
    {
        if (config.ShowCosmicContainers && MatchesCosmicContainerText(normalizedText))
        {
            return "ShowCosmicContainers";
        }
        if (config.ShowCosmicRewards && MatchesCosmicCurrencyRewardText(normalizedText))
        {
            return "ShowCosmicRewards";
        }
        if (config.ShowCosmicExplorationMessages && MatchesCosmicExplorationText(normalizedText))
        {
            return "ShowCosmicExplorationMessages";
        }
        if (config.ShowCosmicClassPointsAndDataset && MatchesCosmicClassPointsAndDatasetText(normalizedText))
        {
            return "ShowCosmicClassPointsAndDataset";
        }
        if (config.ShowCosmicDailyProgress && MatchesCosmicDailyProgressText(normalizedText))
        {
            return "ShowCosmicDailyProgress";
        }
        return null;
    }

    public static bool ShouldDeferNonCosmicRule(Configuration config, string normalizedText) =>
        IsCosmicMessageAllowed(config, normalizedText);

    public static bool MatchesCosmicContainerText(string normalizedText) =>
        TextMatchHelper.MatchesAny(normalizedText, ChatStrings.CosmicContainerObtain);

    public static bool MatchesCosmicCurrencyRewardText(string normalizedText) =>
        TextMatchHelper.MatchesAny(normalizedText,
            ChatStrings.CosmocreditObtain,
            ChatStrings.CosmocreditReceived,
            ChatStrings.OizysCreditObtain,
            ChatStrings.AuxesiaCreditObtain,
            ChatStrings.OizysDronebitsObtain,
            ChatStrings.CosmicFortuneObtain);

    public static bool MatchesCosmicExplorationText(string normalizedText) =>
        TextMatchHelper.MatchesAny(normalizedText,
            ChatStrings.MechOpDirective,
            ChatStrings.CosmicRedAlert,
            ChatStrings.CosmicExplorationContribution,
            ChatStrings.CosmicExplorationSizableContribution);

    public static bool MatchesCosmicClassPointsAndDatasetText(string normalizedText) =>
        TextMatchHelper.MatchesAny(normalizedText,
            ChatStrings.CosmicDatasetSubmitted,
            ChatStrings.CosmicClassPoints,
            ChatStrings.CosmicToolMasteryPoints);

    public static bool MatchesCosmicDailyProgressText(string normalizedText) =>
        TextMatchHelper.MatchesAny(normalizedText,
            ChatStrings.DailyPointsEarned,
            ChatStrings.DailySuccessAchieved,
            ChatStrings.DailySuccessGoalAchieved,
            ChatStrings.StellarSuccessAchieved);
}
