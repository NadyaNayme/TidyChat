namespace TidyChat;

public static partial class Rules
{
    private static void AddObtainRules(List<LocalizedFilterRule> rules)
    {
        rules.AddRange(ObtainCurrenciesItemRules);
        rules.AddRange(ObtainProgressHideRules);
        rules.AddRange(ObtainCurrenciesGilHideRules);
        rules.AddRange(AlliedSocietiesTribalHideRules);
        rules.AddRange(ObtainSystemClusterHideRules);
        rules.AddRange(ObtainCurrenciesMarkerHideRules);
        rules.AddRange(AlliedSocietiesMaterialsHideRules);
        rules.AddRange(ObtainCurrenciesTomestoneHideRules);
    }
}