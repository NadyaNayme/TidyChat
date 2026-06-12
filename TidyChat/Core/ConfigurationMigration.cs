namespace TidyChat.Settings;

internal static class ConfigurationMigration
{
    public static void ApplyVersion12(Configuration config) =>
        config.ShowGatheringCollectableObtains = config.ShowObtainedItems;

    public static void ApplyVersion13(Configuration config)
    {
#pragma warning disable CS0618
        config.ShowGlamourDresserOutfit = config.ShowGlamourAltered;
        config.ShowGlamourDresserProjection = config.ShowGlamourAltered;
        config.ShowGlamourArmoireMessages = config.ShowGlamourAltered;
#pragma warning restore CS0618
        config.ShowTryOnGlamourPreview = config.ShowTryOnGlamourCast;
    }

    public static void ApplyVersion14(Configuration config)
    {
#pragma warning disable CS0618
        var legacyLure = config.ShowLureMessages;
#pragma warning restore CS0618
        config.ShowLureAttemptMessages = legacyLure;
        config.ShowLureBiteFeelingMessages = legacyLure;
        config.ShowReelInLine = config.ShowCaughtFish;
        config.ShowLoseBait = config.ShowCaughtFish;
    }
}
