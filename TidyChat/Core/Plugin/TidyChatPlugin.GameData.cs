using Lumina.Excel.Sheets;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private static void LoadFishingFlavorMessages()
    {
        var messages = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        try
        {
            foreach (var row in DataManager.GetExcelSheet<FishingSpot>())
            {
                var reach = $"{row.BigFishOnReach}".Trim();
                var end = $"{row.BigFishOnEnd}".Trim();
                var refresh = $"{row.BigFishOnRefresh}".Trim();

                if (!string.IsNullOrWhiteSpace(reach))
                {
                    messages.Add(reach);
                }
                if (!string.IsNullOrWhiteSpace(end))
                {
                    messages.Add(end);
                }
                if (!string.IsNullOrWhiteSpace(refresh))
                {
                    messages.Add(refresh);
                }
            }
        }
        catch (Exception ex)
        {
            Log.Error("Failed to load fishing flavor messages from FishingSpot: " + ex);
        }

        try
        {
            foreach (var row in DataManager.GetExcelSheet<FishParameter>())
            {
                var lure1 = $"{row.Unknown_70_1}".Trim();
                var lure2 = $"{row.Unknown_70_2}".Trim();
                var lure3 = $"{row.Unknown_70_3}".Trim();

                if (!string.IsNullOrWhiteSpace(lure1))
                {
                    messages.Add(lure1);
                }
                if (!string.IsNullOrWhiteSpace(lure2))
                {
                    messages.Add(lure2);
                }
                if (!string.IsNullOrWhiteSpace(lure3))
                {
                    messages.Add(lure3);
                }
            }
        }
        catch (Exception ex)
        {
            Log.Error("Failed to load lure flavor messages from FishParameter: " + ex);
        }

        FishingFlavorMessages = messages;
        Log.Information($"Loaded {FishingFlavorMessages.Count} fishing flavor messages.");
    }

    private void ReloadGameDataCaches(bool validateRuleIds)
    {
        LoadTomestones();
        LoadTribalCurrencies();
        LoadFishingFlavorMessages();
        LogMessageCatalog.Load(DataManager, Log);
        ItemMarkerCatalog.Load(DataManager, Log);
        ServerAnnouncementCatalog.Load(DataManager, Log);
        Rules.RebuildLogMessageIdLookup();
        if (validateRuleIds)
        {
            LogMessageCatalog.ValidateRuleIds(Rules.EnumerateReferencedLogMessageIds(), Log);
            LogMessageCatalog.ValidateRuleChannels(Rules.AllRules, Log);
        }
    }

    private static void LoadTomestones()
    {
        List<TomestoneInfo> tomestones = [];
        try
        {
            Dictionary<uint, (uint RowId, string Name)> bestPerSlot = [];
            foreach (var row in DataManager.GetExcelSheet<TomestonesItem>())
            {
                var slotId = row.Tomestones.RowId;
                if (slotId == 0)
                {
                    continue;
                }
                var name = $"{row.Item.Value.Name}";
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }
                if (!bestPerSlot.TryGetValue(slotId, out var existing) || row.RowId > existing.RowId)
                {
                    bestPerSlot[slotId] = (row.RowId, name);
                }
            }
            foreach ((var rowId, var name) in bestPerSlot.Values)
            {
                tomestones.Add(new(rowId, name));
            }
        }
        catch (Exception ex)
        {
            Log.Error("Failed to load tomestone data from Lumina: " + ex);
        }
        Tomestones = tomestones.AsReadOnly();
        Log.Information($"Loaded {Tomestones.Count} tomestones: {string.Join(", ", Tomestones.Select(t => t.Name))}");
    }

    private static void LoadTribalCurrencies()
    {
        List<TomestoneInfo> currencies = [];
        try
        {
            var sheet = DataManager.GetExcelSheet<Item>();
            foreach (var itemId in ItemMarkerCatalog.Items.TribalCurrency)
            {
                var row = sheet.GetRow(itemId);
                var name = $"{row.Name}".Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                currencies.Add(new(itemId, name));
            }

            currencies.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.CurrentCultureIgnoreCase));
        }
        catch (Exception ex)
        {
            Log.Error("Failed to load allied society currency data from Lumina: " + ex);
        }

        TribalCurrencies = currencies.AsReadOnly();
        Log.Information(
            $"Loaded {TribalCurrencies.Count} allied society currencies: {string.Join(", ", TribalCurrencies.Select(c => c.Name))}");
    }
}
