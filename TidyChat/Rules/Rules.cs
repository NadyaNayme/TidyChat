using System;
using System.Collections.Generic;
using ChatTwo.Code;
using TidyChat.Translation.Data;

namespace TidyChat;

#pragma warning disable MA0048
public enum PatternKind
{
    None,
    StringMatch,
    RegexMatch,
}

public enum SettingTab
{
    Basic,
    System,
    LootObtain,
    Progress,
    CraftingGathering,
}

public enum SettingCategory
{
    None,
    EmoteFilters,
    ImprovedMessages,
    FreeCompany,
    DeepDungeon,
    Party,
    Trading,
    Looting,
    CommonCurrency,
    BattleCurrency,
    BeastTribe,
    OtherObtain,
    Desynthesis,
    Materia,
    Crafting,
    Gathering,
    Fishing,
}

public class LocalizedRegexRule
{
    public required string Name { get; set; }
    public required string SettingsTab { get; set; }

    public ChatType Channel { get; set; }
    public LocalizedRegex RegexMatch { get; set; }
    public LocalizedStrings StringMatch { get; set; }
    public PatternKind Pattern { get; set; } = PatternKind.None;
    public SettingTab SettingTab { get; set; } = SettingTab.Basic;
    public SettingCategory SettingCategory { get; set; } = SettingCategory.None;
    public required Boolean IsActive { get; set; } = false;
    public string? Error { get; set; } 

}
public static class Rules
{
    private static readonly List<LocalizedRegexRule> _rules =
    [
        new LocalizedRegexRule
        {
            Name = "ShowAetherpoolIncrease",
            SettingsTab = "Test",
            Channel = ChatType.Echo,
            IsActive = true,
            RegexMatch = ChatRegexStrings.AetherpoolIncrease,
            Pattern = PatternKind.RegexMatch,
        },
        new LocalizedRegexRule
        {
            Name = "HideAetherCompass",
            SettingsTab = "Test",
            Channel = ChatType.System,
            IsActive = true,
            StringMatch = ChatStrings.AetherCompass,
            Pattern = PatternKind.StringMatch,
        },
    ];

    public static LocalizedRegexRule[] AllRules => [.. _rules];
    public static void UpdateIsActiveStates(Configuration config)
    {
        foreach (var rule in _rules)
            {
                try
                {
                    rule.IsActive = config.GetPropertyValue<Boolean>(config, rule.Name);
                }
                catch (Exception ex)
                {
                    // If we don't know if a rule is True or False assume it is False
                    rule.IsActive = true;
                    rule.Error = ex.ToString();
                }
            }
    }
}
