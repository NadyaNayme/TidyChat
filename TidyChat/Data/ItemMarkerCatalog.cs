using System;
using System.Collections.Generic;
using System.Linq;
using Dalamud.Plugin.Services;
using Lumina.Excel.Sheets;
using TidyChat.Translation.Data;
namespace TidyChat.Data;

public static class ItemMarkerCatalog
{
    private static readonly Dictionary<uint, string[]> MarkersByItemId = new();

    public static bool IsLoaded { get; private set; }

    public static void Load(IDataManager dataManager, IPluginLog log)
    {
        MarkersByItemId.Clear();
        IsLoaded = false;

        try
        {
            var tracked = new HashSet<uint>(Items.AllTracked);
            foreach(Item row in dataManager.GetExcelSheet<Item>())
            {
                if (!tracked.Contains(row.RowId)) continue;

                string name = $"{row.Name}".Trim();
                if (string.IsNullOrWhiteSpace(name)) continue;

                string[] tokens = LogMessageTokenExtractor.Extract(name);
                if (tokens.Length > 0) MarkersByItemId[row.RowId] = tokens;
            }

            IsLoaded = true;
            log.Information($"ItemMarkerCatalog: loaded markers for {MarkersByItemId.Count} obtain items.");
        }
        catch(Exception ex)
        {
            log.Error("ItemMarkerCatalog: failed to load Item sheet: " + ex);
        }
    }

    public static bool Matches(uint itemId, string normalizedText, LocalizedStrings? fallback = null)
    {
        if (MarkersByItemId.TryGetValue(itemId, out string[]? tokens) && tokens.All(normalizedText.Contains))
            return true;

        if (fallback is { } fb) return L10N.Get(fb).All(normalizedText.Contains);
        return false;
    }

    public static bool MatchesAny(IEnumerable<uint> itemIds, string normalizedText, LocalizedStrings? fallback = null)
    {
        foreach(uint itemId in itemIds)
        {
            if (Matches(itemId, normalizedText)) return true;
        }

        if (fallback is { } fb) return L10N.Get(fb).All(normalizedText.Contains);
        return false;
    }

    public static bool MatchesAnySeal(string normalizedText, LocalizedStrings? fallback = null)
    {
        if (Matches(Items.StormSeal, normalizedText) ||
            Matches(Items.SerpentSeal, normalizedText) ||
            Matches(Items.FlameSeal, normalizedText))
            return true;

        if (fallback is { } fb) return L10N.Get(fb).All(normalizedText.Contains);
        return false;
    }

    public static class Items
    {
        public const uint WolfMarks = 25;
        public const uint StormSeal = 20;
        public const uint SerpentSeal = 21;
        public const uint FlameSeal = 22;
        public const uint AlliedSeals = 27;
        public const uint CenturioSeals = 10307;
        public const uint Venture = 21072;
        public const uint Nuts = 41784;

        public static readonly uint[] ElementalAll =
        [
            2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19
        ];

        public static readonly uint[] ElementalClusters = [14, 15, 16, 17, 18, 19];

        public static readonly uint[] TribalCurrency =
        [
            6567, // Steel Amalj'ok
            6582, // Sylphic Goldleaf
            8134, // Titan Cobaltpiece
            8864, // Rainbowtide Psashp
            12876, // Ixali Oaknot
            15994, // Vanu Whitebone
            20027, // Black Copper Gil
            27907, // Carved Kupo Nut
            28725, // Kojin Sango
            33155, // Ananta Dreamstaff
            36305, // Namazu Koban
            41778, // Fae Fancy
            44642, // Qitari Compliment
            46970, // Hammered Frogment
            50622 // Arkasodara Pana
        ];

        public static readonly uint[] AllTracked =
        [
            WolfMarks, StormSeal, SerpentSeal, FlameSeal, AlliedSeals, CenturioSeals, Venture, Nuts,
            ..ElementalAll,
            ..TribalCurrency
        ];
    }
}
