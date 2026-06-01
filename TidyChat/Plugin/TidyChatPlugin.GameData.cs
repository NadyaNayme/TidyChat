using System.Collections.Generic;
using Lumina.Excel.Sheets;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private static void LoadFishingFlavorMessages()
    {
        var messages = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        try
        {
            foreach(FishingSpot row in DataManager.GetExcelSheet<FishingSpot>())
            {
                string reach = $"{row.BigFishOnReach}".Trim();
                string end = $"{row.BigFishOnEnd}".Trim();
                string refresh = $"{row.BigFishOnRefresh}".Trim();

                if (!string.IsNullOrWhiteSpace(reach)) messages.Add(reach);
                if (!string.IsNullOrWhiteSpace(end)) messages.Add(end);
                if (!string.IsNullOrWhiteSpace(refresh)) messages.Add(refresh);
            }
        }
        catch(Exception ex)
        {
            Log.Error("Failed to load fishing flavor messages from FishingSpot: " + ex);
        }

        try
        {
            foreach(FishParameter row in DataManager.GetExcelSheet<FishParameter>())
            {
                string lure1 = $"{row.Unknown_70_1}".Trim();
                string lure2 = $"{row.Unknown_70_2}".Trim();
                string lure3 = $"{row.Unknown_70_3}".Trim();

                if (!string.IsNullOrWhiteSpace(lure1)) messages.Add(lure1);
                if (!string.IsNullOrWhiteSpace(lure2)) messages.Add(lure2);
                if (!string.IsNullOrWhiteSpace(lure3)) messages.Add(lure3);
            }
        }
        catch(Exception ex)
        {
            Log.Error("Failed to load lure flavor messages from FishParameter: " + ex);
        }

        FishingFlavorMessages = messages;
        Log.Information($"Loaded {FishingFlavorMessages.Count} fishing flavor messages.");
    }

    private void ReloadGameDataCaches(bool validateRuleIds)
    {
        LoadTomestones();
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
        List<TomestoneInfo> tomestones = new();
        try
        {
            Dictionary<uint, (uint RowId, string Name)> bestPerSlot = new();
            foreach(TomestonesItem row in DataManager.GetExcelSheet<TomestonesItem>())
            {
                uint slotId = row.Tomestones.RowId;
                if (slotId == 0) continue;
                string name = $"{row.Item.Value.Name}";
                if (string.IsNullOrWhiteSpace(name)) continue;
                if (!bestPerSlot.TryGetValue(slotId, out (uint RowId, string Name) existing) || row.RowId > existing.RowId)
                    bestPerSlot[slotId] = (row.RowId, name);
            }
            foreach((uint rowId, string name) in bestPerSlot.Values)
                tomestones.Add(new(rowId, name));
        }
        catch(Exception ex)
        {
            Log.Error("Failed to load tomestone data from Lumina: " + ex);
        }
        Tomestones = tomestones.AsReadOnly();
        Log.Information($"Loaded {Tomestones.Count} tomestones: {string.Join(", ", Tomestones.Select(t => t.Name))}");
    }
}
