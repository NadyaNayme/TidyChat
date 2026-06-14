namespace TidyChat;

internal static class CosmicExplorationFilterHelper
{
    public static readonly uint[] GpRecoveryLogMessageIds = [11174, 11175];

    public static bool IsCosmicRuleName(string ruleName) =>
        ruleName is "ShowCosmicExplorationMessages" or
            "ShowCosmicRewards" or
            "ShowCosmicContainers" or
            "ShowCosmicClassPointsAndDataset" or
            "ShowCosmicDailyProgress";

    public static bool IsStellarGpRuleName(string ruleName) => ruleName is "ShowStellarGpRecovery";

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

    public static bool IsGpRecoveryLogMessage(uint logMessageId) =>
        logMessageId is 11174 or 11175;

    public static bool IsGpRecoveryLogMessageAllowed(Configuration config, uint logMessageId, string normalizedText) =>
        FilterMasterAccessors.StellarGpRecovery(config) &&
        IsGpRecoveryLogMessage(logMessageId) &&
        MatchesGpRecoveryText(normalizedText);

    public static bool IsGpRecoveryAllowed(Configuration config, string normalizedText) =>
        FilterMasterAccessors.StellarGpRecovery(config) && MatchesGpRecoveryText(normalizedText);

    public static bool ShouldDeferToStellarGpRecovery(Configuration config, string normalizedText) =>
        IsGpRecoveryAllowed(config, normalizedText);

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

    public static bool MatchesGpRecoveryText(string normalizedText) =>
        TextMatchHelper.MatchesAny(normalizedText,
            ChatStrings.StellarGpRecoverySelf,
            ChatStrings.StellarGpRecoveryOther,
            ChatStrings.StellarGpRecovered);
}
