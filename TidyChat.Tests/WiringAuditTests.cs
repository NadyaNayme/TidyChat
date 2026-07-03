using NUnit.Framework;
using System.Reflection;
using System.Text.RegularExpressions;
using TidyChat.Localization.Data;
using TidyChat.Localization.Resources;
using TidyChat.Settings;
using TidyChat.Settings.Search;
namespace TidyChat.Tests;

/// <summary>
///     Static wiring audit: every rule must resolve to a real config property, every pattern must be
///     able to match normalized (lowercased) text, and the settings search must cover every toggle.
/// </summary>
[TestFixture]
public class WiringAuditTests
{
    /// <summary>Rule accessors that are always active and do not read their config property.</summary>
    private static readonly HashSet<string> AlwaysOnAccessorRules = new(StringComparer.Ordinal)
    {
        "ShowDungeonMechanicMessages",
    };

    /// <summary>Rule names that intentionally have no same-named Configuration property.</summary>
    private static readonly HashSet<string> RulesWithoutConfigProperty = new(StringComparer.Ordinal)
    {
        "ShowDungeonMechanicMessages",
    };

    private static readonly Dictionary<string, string> RuleNameAliases = new(StringComparer.Ordinal)
    {
        ["ShowDutyCommenceMessage"] = nameof(Configuration.BetterDutyCommenceMessage),
        ["HideDutyCommenceBriefing"] = nameof(Configuration.BetterDutyCommenceMessage),
        ["ShowInventoryItemAdded"] = nameof(Configuration.HideInventoryItemAdded),
    };

    /// <summary>Master toggles that gate child rules; enabled so child accessors can respond.</summary>
    private static readonly string[] MasterToggleProperties =
    [
        nameof(Configuration.ShowInstanceMessage),
        nameof(Configuration.ShowGlamourDresserMessages),
        nameof(Configuration.ShowTryOnGlamour),
        nameof(Configuration.ShowSearchForItemResults),
        nameof(Configuration.ShowMarketBoardMessages),
        nameof(Configuration.ShowSubaquaticVoyage),
        nameof(Configuration.ShowEverythingElse),
        nameof(Configuration.ShowAllOtherCrafting),
        nameof(Configuration.ShowAllOtherGathering),
        nameof(Configuration.ShowStellarMissionMessages),
        nameof(Configuration.ShowOthersLootRoll)
    ];

    private static readonly string[] KnownSettingsTabs =
    [
        "System", "Currencies", "Allied Societies", "Gold Saucer", "Progress", "Crafting",
        "Cosmic Exploration", "Desynthesis", "Fishing", "Gathering", "Materia", "Exploration", "Housing",
        "Glamour", "Deep Dungeons", "General", "Emotes", "Party", "Duty", "Free Company", "Economy"
    ];

    private static Dictionary<string, Func<Configuration, bool>> GetConfigAccessors()
    {
        var field = typeof(Rules).GetField("ConfigAccessors", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.That(field, Is.Not.Null, "Rules.ConfigAccessors field not found (renamed?)");
        return (Dictionary<string, Func<Configuration, bool>>)field!.GetValue(null)!;
    }

    private static bool HasObtainMarkerConstraint(LocalizedFilterRule rule) =>
        rule.ObtainMarkerItemId is not null ||
        rule.ObtainMarkerAnySeal ||
        rule.ObtainMarkerAnyElemental ||
        rule.ObtainMarkerAnyTribal ||
        rule.ObtainMarkerMaterials ||
        rule.ObtainMarkerOtherPlayer ||
        rule.ObtainMarkerGil ||
        rule.ObtainMarkerMgp;

    private static IEnumerable<(string FieldName, LocalizedStrings Strings)> AllChatStringFields() =>
        typeof(ChatStrings)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == typeof(LocalizedStrings))
            .Select(f => (f.Name, (LocalizedStrings)f.GetValue(null)!));

    private static IEnumerable<(string FieldName, LocalizedRegex Regex)> AllChatRegexFields() =>
        typeof(ChatStrings)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == typeof(LocalizedRegex))
            .Select(f => (f.Name, (LocalizedRegex)f.GetValue(null)!));

    [Test]
    public void Every_rule_name_has_a_config_accessor()
    {
        var accessors = GetConfigAccessors();
        var missing = Rules.AllRules
            .Select(r => r.Name)
            .Distinct(StringComparer.Ordinal)
            .Where(name => !accessors.ContainsKey(name))
            .ToList();
        Assert.That(missing, Is.Empty,
            $"Rules without a ConfigAccessors entry (their setting checkbox does nothing): {string.Join(", ", missing)}");
    }

    [Test]
    public void Every_config_accessor_maps_to_at_least_one_rule()
    {
        var ruleNames = Rules.AllRules.Select(r => r.Name).ToHashSet(StringComparer.Ordinal);
        var orphans = GetConfigAccessors().Keys.Where(key => !ruleNames.Contains(key)).ToList();
        Assert.That(orphans, Is.Empty,
            $"ConfigAccessors entries with no rule (dead wiring): {string.Join(", ", orphans)}");
    }

    [Test]
    public void Rule_names_match_config_properties_or_known_aliases()
    {
        var unknown = Rules.AllRules
            .Select(r => r.Name)
            .Distinct(StringComparer.Ordinal)
            .Where(name => typeof(Configuration).GetProperty(name) is null &&
                           !RuleNameAliases.ContainsKey(name) &&
                           !RulesWithoutConfigProperty.Contains(name))
            .ToList();
        Assert.That(unknown, Is.Empty,
            "Rule names with neither a same-named Configuration property nor a documented alias " +
            $"(checkbox probably toggles nothing): {string.Join(", ", unknown)}");
    }

    [Test]
    public void Accessors_track_their_same_named_config_property()
    {
        var accessors = GetConfigAccessors();
        var failures = new List<string>();

        foreach (var name in Rules.AllRules.Select(r => r.Name).Distinct(StringComparer.Ordinal))
        {
            var property = typeof(Configuration).GetProperty(name);
            if (property is null || property.PropertyType != typeof(bool))
            {
                continue; // covered by Rule_names_match_config_properties_or_known_aliases
            }

            if (AlwaysOnAccessorRules.Contains(name))
            {
                continue;
            }

            var config = new Configuration();
            foreach (var master in MasterToggleProperties)
            {
                typeof(Configuration).GetProperty(master)!.SetValue(config, true);
            }

            var accessor = accessors[name];
            property.SetValue(config, true);
            var whenTrue = accessor(config);
            property.SetValue(config, false);
            var whenFalse = accessor(config);

            if (whenTrue == whenFalse)
            {
                failures.Add(name);
            }

            if (property.PropertyType == typeof(bool) && !whenTrue && whenFalse)
            {
                failures.Add($"{name} (inverted)");
            }
        }

        Assert.That(failures, Is.Empty,
            "Accessors that do not respond to (or invert) their own config property even with all master " +
            $"toggles enabled: {string.Join(", ", failures)}");
    }

    [Test]
    public void Every_rule_declares_a_valid_channel()
    {
        var invalid = Rules.AllRules
            .Where(r => !Enum.IsDefined(r.Channel))
            .Select(r => $"{r.Name} ({(int)r.Channel})")
            .Distinct()
            .ToList();
        Assert.That(invalid, Is.Empty,
            $"Rules with an unset/unknown Channel (never match their channel): {string.Join(", ", invalid)}");
    }

    [Test]
    public void Pattern_kind_is_consistent_with_declared_checks()
    {
        var failures = new List<string>();
        var index = 0;
        foreach (var rule in Rules.AllRules)
        {
            index++;
            var id = $"{rule.Name}[#{index} {rule.SettingsTab}/{rule.Channel}]";
            var hasMarker = HasObtainMarkerConstraint(rule);

            switch (rule.Pattern)
            {
                case PatternKind.RegexMatch when rule.RegexChecks is not { Count: > 0 }:
                    failures.Add($"{id}: RegexMatch without RegexChecks");
                    break;
                case PatternKind.StringMatch when rule.StringChecks is not { Count: > 0 } && !hasMarker:
                    failures.Add($"{id}: StringMatch without StringChecks or marker constraint");
                    break;
                case PatternKind.None when rule.LogMessageIds is not { Length: > 0 } && !hasMarker:
                    failures.Add($"{id}: no pattern, no LogMessageIds, no marker constraint (cannot match)");
                    break;
            }

            if (rule.RegexChecks is { Count: > 0 } && rule.Pattern != PatternKind.RegexMatch)
            {
                failures.Add($"{id}: RegexChecks declared but Pattern is {rule.Pattern} (checks are dead)");
            }

            if (rule.StringChecks is { Count: > 0 } && rule.Pattern != PatternKind.StringMatch && !hasMarker)
            {
                failures.Add($"{id}: StringChecks declared but Pattern is {rule.Pattern} (checks are dead)");
            }

            if (hasMarker && !rule.PreferLogMessageCatalog)
            {
                failures.Add($"{id}: obtain-marker constraint without PreferLogMessageCatalog (marker is ignored)");
            }
        }

        Assert.That(failures, Is.Empty, string.Join("\n", failures));
    }

    [Test]
    public void Every_settings_tab_name_is_known_to_search_location_mapping()
    {
        var unknown = Rules.AllRules
            .Select(r => r.SettingsTab)
            .Distinct(StringComparer.Ordinal)
            .Where(tab => !KnownSettingsTabs.Contains(tab, StringComparer.Ordinal))
            .ToList();
        Assert.That(unknown, Is.Empty,
            $"SettingsTab values missing from SettingsSearchIndex.FormatRuleLocation: {string.Join(", ", unknown)}");
    }

    [Test]
    public void String_check_tokens_are_lowercase_in_all_languages()
    {
        var failures = new List<string>();
        foreach ((var fieldName, var strings) in AllChatStringFields())
        {
            foreach ((var lang, var tokens) in new[]
                     {
                         ("Jpn", strings.Jpn), ("Eng", strings.Eng), ("Deu", strings.Deu), ("Fra", strings.Fra)
                     })
            {
                if (tokens is null)
                {
                    continue;
                }

                foreach (var token in tokens)
                {
                    if (string.Equals(token, "NeedsLocalization", StringComparison.Ordinal))
                    {
                        continue;
                    }

                    if (!string.Equals(token, token.ToLowerInvariant(), StringComparison.Ordinal))
                    {
                        failures.Add($"ChatStrings.{fieldName}.{lang}: \"{token}\"");
                    }
                }
            }
        }

        Assert.That(failures, Is.Empty,
            "String checks run ordinal Contains against lowercased text; these tokens can never match:\n" +
            string.Join("\n", failures));
    }

    [Test]
    public void English_string_checks_are_never_placeholders()
    {
        var failures = AllChatStringFields()
            .Where(f => f.Strings.Eng is null ||
                        f.Strings.Eng.Length == 0 ||
                        f.Strings.Eng.Any(t => t.Contains("needslocalization", StringComparison.OrdinalIgnoreCase) ||
                                               t.Contains("needstranslation", StringComparison.OrdinalIgnoreCase)))
            .Select(f => f.FieldName)
            .ToList();
        Assert.That(failures, Is.Empty,
            $"English is the fallback language; it must never be empty or a placeholder: {string.Join(", ", failures)}");
    }

    [Test]
    public void Regex_checks_are_case_insensitive_and_use_recognized_placeholders()
    {
        var failures = new List<string>();
        foreach ((var fieldName, var localized) in AllChatRegexFields())
        {
            foreach ((var lang, var regex) in new[]
                     {
                         ("Jpn", localized.Jpn), ("Eng", localized.Eng), ("Deu", localized.Deu), ("Fra", localized.Fra)
                     })
            {
                if (regex is null)
                {
                    failures.Add($"ChatStrings.{fieldName}.{lang}: regex is null");
                    continue;
                }

                var pattern = regex.ToString();
                var isPlaceholder = string.Equals(pattern, "NeedsLocalization", StringComparison.Ordinal);

                if (!isPlaceholder &&
                    pattern.Contains("needs", StringComparison.OrdinalIgnoreCase) &&
                    (pattern.Contains("localization", StringComparison.OrdinalIgnoreCase) ||
                     pattern.Contains("translation", StringComparison.OrdinalIgnoreCase)))
                {
                    failures.Add($"ChatStrings.{fieldName}.{lang}: placeholder \"{pattern}\" is not exactly " +
                                 "\"NeedsLocalization\" so the English fallback never kicks in");
                }

                if (lang is "Eng" && isPlaceholder)
                {
                    failures.Add($"ChatStrings.{fieldName}.Eng: English pattern must not be a placeholder");
                }

                if (!isPlaceholder && !regex.Options.HasFlag(RegexOptions.IgnoreCase))
                {
                    failures.Add($"ChatStrings.{fieldName}.{lang}: missing IgnoreCase (input text is lowercased)");
                }
            }
        }

        Assert.That(failures, Is.Empty, string.Join("\n", failures));
    }

    [Test]
    public void ShowObtainedQuestItems_uses_soft_hide_to_preserve_loot_flytext()
    {
        var rule = Rules.AllRules.First(r => r.Name == "ShowObtainedQuestItems");
        Assert.That(rule.SoftHideLogMessage, Is.True,
            "LootNotice obtain lines share flytext with LogMessage; soft hide keeps flytext while hiding chat.");
    }

    [Test]
    public void Search_label_keys_reference_real_config_properties_and_language_strings()
    {
        var map = GetSettingsPropertyLabelKeys();
        var failures = new List<string>();
        foreach ((var propertyName, var labelKey) in map)
        {
            if (typeof(Configuration).GetProperty(propertyName) is null)
            {
                failures.Add($"SettingsPropertyLabelKeys[\"{propertyName}\"]: no such Configuration property");
            }

            var label = typeof(Languages).GetProperty(labelKey,
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (label is null || label.PropertyType != typeof(string))
            {
                failures.Add($"SettingsPropertyLabelKeys[\"{propertyName}\"]: Languages.{labelKey} does not exist");
            }
        }

        Assert.That(failures, Is.Empty, string.Join("\n", failures));
    }

    [Test]
    public void Every_config_bool_is_searchable_with_an_explicit_label()
    {
        var map = GetSettingsPropertyLabelKeys();
        var skipped = GetSearchSkippedProperties();

        var unlabeled = typeof(Configuration)
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.PropertyType == typeof(bool) && p.CanRead && p.CanWrite)
            .Where(p => p.GetCustomAttribute<ObsoleteAttribute>() is null)
            .Where(p => !skipped.Contains(p.Name))
            .Where(p => !map.ContainsKey(p.Name))
            .Select(p => p.Name)
            .ToList();

        Assert.That(unlabeled, Is.Empty,
            "Config bools without an explicit search label fall back to fuzzy matching, which can pair the " +
            $"wrong checkbox text: {string.Join(", ", unlabeled)}");
    }

    private static Dictionary<string, string> GetSettingsPropertyLabelKeys()
    {
        var field = typeof(SettingsPropertyLabelKeys)
            .GetField("ByPropertyName", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.That(field, Is.Not.Null, "SettingsPropertyLabelKeys.ByPropertyName field not found (renamed?)");
        return (Dictionary<string, string>)field!.GetValue(null)!;
    }

    private static HashSet<string> GetSearchSkippedProperties()
    {
        var field = typeof(SettingsSearchIndex)
            .GetField("SkippedProperties", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.That(field, Is.Not.Null, "SettingsSearchIndex.SkippedProperties field not found (renamed?)");
        return (HashSet<string>)field!.GetValue(null)!;
    }
}
