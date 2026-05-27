namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] CombatRules =
    [

        new()
        {
            Name = "ShowCombatCasting",
            SettingsTab = "System",
            Channel = ChatType.Action,
            IsActive = true,
            LogMessageIds = [502],
            StringChecks = [ChatStrings.CombatCastBegin],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatCasting",
            SettingsTab = "System",
            Channel = ChatType.Action,
            IsActive = true,
            LogMessageIds = [534],
            StringChecks = [ChatStrings.CombatCastComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatCasting",
            SettingsTab = "System",
            Channel = ChatType.Action,
            IsActive = true,
            LogMessageIds = [537, 538],
            StringChecks = [ChatStrings.CombatCastCancel],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatCasting",
            SettingsTab = "System",
            Channel = ChatType.Action,
            IsActive = true,
            LogMessageIds = [540, 541, 542],
            StringChecks = [ChatStrings.CombatCastInterrupted],
            Pattern = PatternKind.StringMatch,
        },
        new()
        {
            Name = "ShowCombatCasting",
            SettingsTab = "System",
            Channel = ChatType.Damage,
            IsActive = true,
            LogMessageIds = [1472],
            StringChecks = [ChatStrings.CombatInterruptPrevent],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowCombatCasting",
            SettingsTab = "System",
            Channel = ChatType.Damage,
            IsActive = true,
            StringChecks = [ChatStrings.CombatInterruptPrevent],
            Pattern = PatternKind.StringMatch,
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowCombatCasting",
            SettingsTab = "System",
            Channel = ChatType.Action,
            IsActive = true,
            StringChecks = [ChatStrings.CombatCastInterrupted],
            Pattern = PatternKind.StringMatch,
        },
        new()
        {
            Name = "ShowCombatAbilities",
            SettingsTab = "System",
            Channel = ChatType.Action,
            IsActive = true,
            LogMessageIds = [533],
            StringChecks = [ChatStrings.AbilityUseMessage],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatDamage",
            SettingsTab = "System",
            Channel = ChatType.Damage,
            IsActive = true,
            LogMessageIds = [523],
            StringChecks = [ChatStrings.CombatAbsorption],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatDamage",
            SettingsTab = "System",
            Channel = ChatType.Damage,
            IsActive = true,
            LogMessageIds = [504, 505, 508, 509, 510, 511, 517],
            StringChecks = [ChatStrings.CombatHitDamage],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatDamage",
            SettingsTab = "System",
            Channel = ChatType.Damage,
            IsActive = true,
            LogMessageIds = [447, 448],
            StringChecks = [ChatStrings.CombatDirectHit],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatDamage",
            SettingsTab = "System",
            Channel = ChatType.Damage,
            IsActive = true,
            LogMessageIds = [450, 451],
            StringChecks = [ChatStrings.CombatCriticalDirectHit],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatDamage",
            SettingsTab = "System",
            Channel = ChatType.Damage,
            IsActive = true,
            LogMessageIds = [518],
            StringChecks = [ChatStrings.CombatParried],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatMisses",
            SettingsTab = "System",
            Channel = ChatType.Miss,
            IsActive = true,
            LogMessageIds = [506, 600, 515, 612]
        },
        new()
        {
            Name = "ShowCombatMisses",
            SettingsTab = "System",
            Channel = ChatType.Miss,
            IsActive = true,
            LogMessageIds = [506],
            StringChecks = [ChatStrings.CombatMiss],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatMisses",
            SettingsTab = "System",
            Channel = ChatType.Miss,
            IsActive = true,
            LogMessageIds = [600],
            StringChecks = [ChatStrings.CombatAttackMisses],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatMisses",
            SettingsTab = "System",
            Channel = ChatType.Miss,
            IsActive = true,
            LogMessageIds = [612],
            StringChecks = [ChatStrings.CombatUnaffected],
            Pattern = PatternKind.StringMatch,
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowCombatMisses",
            SettingsTab = "System",
            Channel = ChatType.Miss,
            IsActive = true,
            StringChecks = [ChatStrings.CombatUnaffected],
            Pattern = PatternKind.StringMatch,
        },
        new()
        {
            Name = "ShowCombatHealing",
            SettingsTab = "System",
            Channel = ChatType.Healing,
            IsActive = true,
            LogMessageIds = [519, 520],
            StringChecks = [ChatStrings.CombatHpRecover],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatHealing",
            SettingsTab = "System",
            Channel = ChatType.Healing,
            IsActive = true,
            LogMessageIds = [560],
            StringChecks = [ChatStrings.CombatRevived],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatEffects",
            SettingsTab = "System",
            Channel = ChatType.GainDebuff,
            IsActive = true,
            LogMessageIds = [527, 604],
            StringChecks = [ChatStrings.CombatDebuffApplied],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatEffects",
            SettingsTab = "System",
            Channel = ChatType.LoseDebuff,
            IsActive = true,
            LogMessageIds = [532, 551],
            StringChecks = [ChatStrings.CombatDebuffCured],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatEffects",
            SettingsTab = "System",
            Channel = ChatType.GainBuff,
            IsActive = true,
            LogMessageIds = [526],
            StringChecks = [ChatStrings.BuffGainEffect],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatEffects",
            SettingsTab = "System",
            Channel = ChatType.LoseBuff,
            IsActive = true,
            LogMessageIds = [531, 550],
            StringChecks = [ChatStrings.BuffLossEffect],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatEffects",
            SettingsTab = "System",
            Channel = ChatType.GainBuff,
            IsActive = true,
            LogMessageIds = [528],
            StringChecks = [ChatStrings.CombatFormChange],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatEffects",
            SettingsTab = "System",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            LogMessageIds = [640],
            StringChecks = [ChatStrings.PetWithdraws],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatEffects",
            SettingsTab = "System",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            LogMessageIds = [617],
            StringChecks = [ChatStrings.CombatDestroyed],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatDefeat",
            SettingsTab = "System",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            LogMessageIds = [557],
            StringChecks = [ChatStrings.CombatDefeat],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatDefeat",
            SettingsTab = "System",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            LogMessageIds = [558],
            StringChecks = [ChatStrings.CombatDefeatedBy],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatEnemyReady",
            SettingsTab = "System",
            Channel = ChatType.Action,
            IsActive = true,
            LogMessageIds = [501],
            StringChecks = [ChatStrings.CombatReady],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatAdds",
            SettingsTab = "System",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            LogMessageIds = [555],
            StringChecks = [ChatStrings.CombatCallsForHelp],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCombatEnmity",
            SettingsTab = "System",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            LogMessageIds = [536],
            StringChecks = [ChatStrings.CombatEnmity],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },

    ];
}
