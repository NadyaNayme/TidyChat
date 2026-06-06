namespace TidyChat;

public static partial class Rules
{
    private static void AddLootRules(List<LocalizedFilterRule> rules)
    {
        rules.AddRange(LootPartyEarlyRules);
        rules.AddRange(LootGatheringShardRules);
        rules.AddRange(LootPartyLateRules);
    }
}