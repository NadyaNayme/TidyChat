namespace TidyChat.Settings;

internal static class ConfigurationMigration
{
    public static void ApplyVersion11(Configuration config)
    {
        if (config.ShowCosmicDailyProgress)
            config.ShowCosmicClassPointsAndDataset = true;
    }

    public static void ApplyVersion12(Configuration config) =>
        config.ShowGatheringCollectableObtains = config.ShowObtainedItems;
}
