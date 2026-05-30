using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings;

internal static class SettingsSearchIndex
{
    private static readonly HashSet<string> AlwaysOnSettings = new(StringComparer.Ordinal)
    {
        "ShowSRankHunt",
        "ShowSSRankHunt",
        "ShowInvitedBy",
        "ShowReadyChecks",
        "ShowCountdownTime",
        "ShowFriendList",
        "ShowTrapTriggered",
        "ShowSpideySenses",
        "ShowMateriaShatters",
        "ShowVolumeControlMessage",
        "ShowSealedOff",
        "ShowOvermeldFailure",
        "ShowFateDiscovery",
        "ShowCosmicExplorationMessages",
        "ShowCombatAdds",
        "ShowObtainedQuestItems",
        "ShowAbilityUnlocks"
    };

    private static readonly HashSet<string> SkippedProperties = new(StringComparer.Ordinal)
    {
        "Enabled"
    };

    private static readonly PropertyInfo[] LanguageProperties =
        typeof(Languages).GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

    private static readonly PropertyInfo[] ConfigBoolProperties =
        typeof(Configuration).GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.PropertyType == typeof(bool) && p.CanRead && p.CanWrite)
            .ToArray();

    private static readonly Dictionary<string, RuleMetadata> RuleMetadataByName = BuildRuleMetadata();

    private static Entry[]? s_entries;

    public static void DrawResults(Configuration configuration)
    {
        string query = SettingsSearch.Query.Trim();
        Entry[] entries = s_entries ??= BuildEntries();

        List<Entry> matches = entries.Where(e => e.Matches(query)).ToList();
        AppendTomestoneMatches(configuration, query, matches);

        ImGui.Spacing();
        if (matches.Count == 0)
        {
            ImGui.TextUnformatted(Languages.ConfigWindow_SearchNoResults);
            return;
        }

        ImGui.TextUnformatted(string.Format(CultureInfo.CurrentCulture, Languages.ConfigWindow_SearchResultCount,
            matches.Count.ToString(CultureInfo.CurrentCulture)));
        ImGui.Spacing();

        if (!ImGui.BeginChild("##settingsSearchResults", new System.Numerics.Vector2(0, 0)))
            return;

        foreach(Entry entry in matches.OrderBy(e => e.Location, StringComparer.OrdinalIgnoreCase)
                     .ThenBy(e => e.Label, StringComparer.OrdinalIgnoreCase))
            DrawEntry(configuration, entry);

        ImGui.EndChild();
    }

    private static void DrawEntry(Configuration configuration, Entry entry)
    {
        ImGui.PushID(entry.Id);

        if (entry.CanToggle)
        {
            bool value = entry.GetBool(configuration);
            if (ImGui.Checkbox(entry.Label, ref value))
            {
                entry.SetBool(configuration, value);
                configuration.OnSettingChanged();
            }
        }
        else if (entry.AlwaysOn)
        {
            ImGui.BeginDisabled();
            bool value = true;
            ImGui.Checkbox(entry.Label, ref value);
            ImGui.EndDisabled();
            ImGuiComponents.HelpMarker(Languages.ConfigWindow_SettingAlwaysOn);
        }
        else
        {
            ImGui.TextUnformatted(entry.Label);
        }

        if (!string.IsNullOrEmpty(entry.Help))
        {
            ImGui.SameLine();
            ImGuiComponents.HelpMarker(entry.Help);
        }

        ImGui.TextColored(new System.Numerics.Vector4(0.55f, 0.55f, 0.55f, 1f), entry.Location);

        if (!string.IsNullOrEmpty(entry.RuleName))
            ImGui.TextDisabled($"{Languages.ConfigWindow_SearchRuleLabel}: {entry.RuleName}");

        if (entry.Examples.Count > 0)
        {
            string examples = string.Join(" / ", entry.Examples.Take(3));
            ImGui.TextWrapped($"{Languages.ConfigWindow_SearchExamplesLabel}: {examples}");
        }

        if (entry.LogMessageIds.Count > 0)
        {
            string ids = string.Join(", ", entry.LogMessageIds.OrderBy(id => id));
            ImGui.TextDisabled($"{Languages.ConfigWindow_SearchLogMessageIdsLabel}: {ids}");
        }

        ImGui.Spacing();
        ImGui.PopID();
    }

    private static void AppendTomestoneMatches(Configuration configuration, string query, List<Entry> matches)
    {
        if (TidyChatPlugin.Tomestones.Count == 0)
            return;

        foreach(TomestoneInfo tomestone in TidyChatPlugin.Tomestones)
        {
            if (!Contains(query, tomestone.Name) && !Contains(query, "tomestone") && !Contains(query, "tomestones"))
                continue;

            configuration.HideTomestoneById.TryGetValue(tomestone.RowId, out bool hide);
            string label = string.Format(CultureInfo.CurrentCulture, Languages.ConfigWindow_SearchHideTomestone,
                tomestone.Name);
            matches.Add(new Entry(
                Id: $"tomestone-{tomestone.RowId}",
                Label: label,
                Help: null,
                Location: $"Advanced > {Languages.AdvancedTab_LootObtainTabHeader}",
                RuleName: null,
                Examples: [],
                LogMessageIds: [],
                CanToggle: true,
                AlwaysOn: false,
                GetBool: _ => hide,
                SetBool: (_, value) => configuration.HideTomestoneById[tomestone.RowId] = value));
        }
    }

    private static Entry[] BuildEntries()
    {
        var entries = new List<Entry>(ConfigBoolProperties.Length);

        foreach(PropertyInfo property in ConfigBoolProperties)
        {
            if (SkippedProperties.Contains(property.Name))
                continue;

            (string label, string? help) = ResolveLabelAndHelp(property.Name);
            RuleMetadata? ruleMeta = RuleMetadataByName.GetValueOrDefault(property.Name);
            string location = ruleMeta is not null
                ? FormatRuleLocation(ruleMeta.SettingsTab)
                : InferLocation(property.Name);

            entries.Add(new Entry(
                Id: property.Name,
                Label: label,
                Help: help,
                Location: location,
                RuleName: ruleMeta is not null ? property.Name : null,
                Examples: ruleMeta?.Examples ?? [],
                LogMessageIds: ruleMeta?.LogMessageIds ?? [],
                CanToggle: !AlwaysOnSettings.Contains(property.Name),
                AlwaysOn: AlwaysOnSettings.Contains(property.Name),
                GetBool: config => (bool)property.GetValue(config)!,
                SetBool: (config, value) => property.SetValue(config, value)));
        }

        return entries.ToArray();
    }

    private static Dictionary<string, RuleMetadata> BuildRuleMetadata()
    {
        var metadata = new Dictionary<string, RuleMetadata>(StringComparer.Ordinal);

        foreach(IGrouping<string, LocalizedFilterRule> group in Rules.AllRules.GroupBy(r => r.Name, StringComparer.Ordinal))
        {
            var examples = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var logIds = new HashSet<uint>();

            foreach(LocalizedFilterRule rule in group)
            {
                if (rule.StringChecks is not null)
                {
                    foreach(Translation.Data.LocalizedStrings strings in rule.StringChecks)
                    {
                        foreach(string token in strings.Eng)
                        {
                            if (!string.IsNullOrWhiteSpace(token))
                                examples.Add(token);
                        }
                    }
                }

                if (rule.LogMessageIds is not null)
                {
                    foreach(uint id in rule.LogMessageIds)
                        logIds.Add(id);
                }
            }

            metadata[group.Key] = new RuleMetadata(
                group.First().SettingsTab,
                examples.ToList(),
                logIds.ToList());
        }

        return metadata;
    }

    private static (string Label, string? Help) ResolveLabelAndHelp(string propertyName)
    {
        PropertyInfo? labelProperty = FindBestLanguageProperty(propertyName, helpMarker: false);
        if (labelProperty is null)
            return (FormatPropertyName(propertyName), null);

        string label = (string)labelProperty.GetValue(null)!;
        PropertyInfo? helpProperty = FindPairedHelpProperty(labelProperty.Name);
        string? help = helpProperty is null ? null : (string)helpProperty.GetValue(null)!;
        return (label, help);
    }

    private static PropertyInfo? FindPairedHelpProperty(string labelPropertyName)
    {
        string helpName = $"{labelPropertyName}HelpMarker";
        return LanguageProperties.FirstOrDefault(p =>
            p.PropertyType == typeof(string) &&
            string.Equals(p.Name, helpName, StringComparison.Ordinal));
    }

    private static PropertyInfo? FindBestLanguageProperty(string propertyName, bool helpMarker)
    {
        string[] terms = ExtractTerms(propertyName);
        PropertyInfo? best = null;
        int bestScore = 0;

        foreach(PropertyInfo property in LanguageProperties)
        {
            if (property.PropertyType != typeof(string))
                continue;

            bool isHelp = property.Name.EndsWith("HelpMarker", StringComparison.Ordinal);
            if (isHelp != helpMarker)
                continue;

            int score = ScoreLanguageProperty(property.Name, terms);
            if (score <= bestScore)
                continue;

            bestScore = score;
            best = property;
        }

        return bestScore > 0 ? best : null;
    }

    private static int ScoreLanguageProperty(string languagePropertyName, string[] terms)
    {
        int score = 0;
        foreach(string term in terms)
        {
            if (term.Length < 3)
                continue;

            if (languagePropertyName.Contains(term, StringComparison.OrdinalIgnoreCase))
                score += term.Length;
        }

        return score;
    }

    private static string[] ExtractTerms(string propertyName)
    {
        var terms = new List<string>();
        foreach(string part in SplitCamelCase(propertyName))
        {
            if (part is "Show" or "Hide" or "Filter" or "Better" or "Enable" or "Disable")
                continue;

            if (part.EndsWith('s') && part.Length > 4)
                terms.Add(part[..^1]);

            terms.Add(part);
        }

        return terms.ToArray();
    }

    private static IEnumerable<string> SplitCamelCase(string value)
    {
        if (string.IsNullOrEmpty(value))
            yield break;

        var current = new StringBuilder();
        for (int i = 0; i < value.Length; i++)
        {
            char c = value[i];
            if (char.IsUpper(c) && current.Length > 0)
            {
                yield return current.ToString();
                current.Clear();
            }

            current.Append(c);
        }

        if (current.Length > 0)
            yield return current.ToString();
    }

    private static string FormatPropertyName(string propertyName) =>
        string.Join(' ', SplitCamelCase(propertyName));

    private static string FormatRuleLocation(string settingsTab) => settingsTab switch
    {
        "System" => $"Advanced > {Languages.AdvancedTab_SystemTabHeader}",
        "Loot/Obtain" => $"Advanced > {Languages.AdvancedTab_LootObtainTabHeader}",
        "Progress" => $"Advanced > {Languages.AdvancedTab_ProgressTabHeader}",
        "Combat" => $"Advanced > {Languages.AdvancedTab_CombatTabHeader}",
        "Crafting" or "Gathering" =>
            $"Advanced > {Languages.AdvancedTab_CraftingGatheringTabHeader}",
        "General" or "Emotes" => Languages.ConfigWindow_SettingsTabHeader,
        _ => $"Advanced > {settingsTab}"
    };

    private static string InferLocation(string propertyName)
    {
        if (propertyName.StartsWith("Filter", StringComparison.Ordinal) ||
            propertyName.StartsWith("Better", StringComparison.Ordinal) ||
            propertyName.StartsWith("Include", StringComparison.Ordinal) ||
            propertyName is "EnableSmolMode" or "NormalizeBlocks" or "AlwaysNormalizeBlocks" or "NoCoffee" or
                "ShowSelfUsedEmotes")
            return Languages.ConfigWindow_SettingsTabHeader;

        if (propertyName.StartsWith("EnableDebug", StringComparison.Ordinal) ||
            propertyName is "DebugIncludeChannel")
            return Languages.ConfigWindow_AdvancedSettingsTabHeader;

        if (propertyName.StartsWith("ChatHistory", StringComparison.Ordinal) ||
            propertyName is "DisableSelfChatHistory")
            return $"Advanced > {Languages.AdvancedTab_ChatHistoryTabHeader}";

        if (propertyName is "SentByWhitelistPlayer" or "TargetingWhitelistPlayer")
            return $"Advanced > {Languages.AdvancedTab_CustomFiltersHeader}";

        return Languages.ConfigWindow_AdvancedSettingsTabHeader;
    }

    private static bool Contains(string query, string? value) =>
        !string.IsNullOrEmpty(value) &&
        value.Contains(query, StringComparison.OrdinalIgnoreCase);

    private sealed record RuleMetadata(string SettingsTab, List<string> Examples, List<uint> LogMessageIds);

    private sealed record Entry(
        string Id,
        string Label,
        string? Help,
        string Location,
        string? RuleName,
        List<string> Examples,
        List<uint> LogMessageIds,
        bool CanToggle,
        bool AlwaysOn,
        Func<Configuration, bool> GetBool,
        Action<Configuration, bool> SetBool)
    {
        public bool Matches(string query)
        {
            if (Contains(query, Label) ||
                Contains(query, Help) ||
                Contains(query, Location) ||
                Contains(query, RuleName) ||
                Contains(query, Id))
                return true;

            foreach(string example in Examples)
            {
                if (Contains(query, example))
                    return true;
            }

            foreach(uint id in LogMessageIds)
            {
                if (id.ToString(CultureInfo.InvariantCulture).Contains(query, StringComparison.Ordinal))
                    return true;
            }

            foreach(string term in ExtractTerms(Id))
            {
                if (term.Length >= 3 && Contains(query, term))
                    return true;
            }

            return false;
        }
    }
}
