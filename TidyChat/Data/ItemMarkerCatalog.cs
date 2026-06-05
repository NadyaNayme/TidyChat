using Dalamud.Plugin.Services;
using Lumina.Excel.Sheets;
using System.Collections.Generic;
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
            foreach (var row in dataManager.GetExcelSheet<Item>())
            {
                if (!tracked.Contains(row.RowId))
                {
                    continue;
                }

                var name = $"{row.Name}".Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                var tokens = LogMessageTokenExtractor.Extract(name);
                if (tokens.Length > 0)
                {
                    MarkersByItemId[row.RowId] = tokens;
                }
            }

            IsLoaded = true;
            log.Information($"ItemMarkerCatalog: loaded markers for {MarkersByItemId.Count} obtain items.");
        }
        catch (Exception ex)
        {
            log.Error("ItemMarkerCatalog: failed to load Item sheet: " + ex);
        }
    }

    public static bool Matches(uint itemId, string normalizedText, LocalizedStrings? fallback = null)
    {
        if (MarkersByItemId.TryGetValue(itemId, out var tokens) && tokens.All(normalizedText.Contains))
        {
            return true;
        }

        if (fallback is { } fb)
        {
            return L10N.Get(fb).All(normalizedText.Contains);
        }
        return false;
    }

    public static bool MatchesAny(IEnumerable<uint> itemIds, string normalizedText, LocalizedStrings? fallback = null)
    {
        foreach (var itemId in itemIds)
        {
            if (Matches(itemId, normalizedText))
            {
                return true;
            }
        }

        if (fallback is { } fb)
        {
            return L10N.Get(fb).All(normalizedText.Contains);
        }
        return false;
    }

    public static bool MatchesAnyGrandCompanySeal(string normalizedText)
    {
        if (Matches(Items.AlliedSeals, normalizedText) ||
            Matches(Items.CenturioSeals, normalizedText) ||
            Matches(Items.WolfMarks, normalizedText))
        {
            return false;
        }

        if (Matches(Items.StormSeal, normalizedText) ||
            Matches(Items.SerpentSeal, normalizedText) ||
            Matches(Items.FlameSeal, normalizedText))
        {
            return true;
        }

        return L10N.Get(ChatRegexStrings.ObtainedSeals).IsMatch(normalizedText);
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
            21076, // Steel Amalj'ok (Amalj'aa)
            21075, // Sylphic Goldleaf (Sylphs)
            21078, // Titan Cobaltpiece (Kobolds)
            21077, // Rainbowtide Psashp (Sahagin)
            21073, // Ixali Oaknot (Ixal)
            21074, // Vanu Whitebone (Vanu Vanu)
            21079, // Black Copper Gil (Vath)
            21080, // Carved Kupo Nut (Moogles)
            21081, // Kojin Sango (Kojin)
            21935, // Ananta Dreamstaff (Ananta)
            22525, // Namazu Koban (Namazu)
            28186, // Fae Fancy (Pixies)
            28187, // Qitari Compliment (Qitari)
            28188, // Hammered Frogment (Dwarves)
            36657, // Arkasodara Pana (Arkasodara)
            44472, // Pelu Pelplume (Pelupelu)
            48084, // Mamool Ja Nanook (Mamool Ja)
            46178 // Yok Huy Ward (Yok Huy)
        ];

        public static readonly uint[] AllTracked =
        [
            WolfMarks, StormSeal, SerpentSeal, FlameSeal, AlliedSeals, CenturioSeals, Venture, Nuts,
            ..ElementalAll,
            ..TribalCurrency
        ];
    }
}
