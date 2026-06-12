namespace TidyChat;

internal static class StellarGpShowRuleHelper
{
    public static readonly uint[] GpRecoveryLogMessageIds = [11174, 11175];

    public static bool IsStellarGpRuleName(string ruleName) => ruleName is "ShowStellarGpRecovery";

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

    public static bool MatchesGpRecoveryText(string normalizedText) =>
        TextMatchHelper.MatchesAny(normalizedText,
            ChatStrings.StellarGpRecoverySelf,
            ChatStrings.StellarGpRecoveryOther,
            ChatStrings.StellarGpRecovered);
}
