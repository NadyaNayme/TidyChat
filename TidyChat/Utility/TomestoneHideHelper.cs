using System.Collections.Generic;
using System.Globalization;
using TidyChat.Data;
using TidyChat.Translation;

namespace TidyChat.Utility;

internal static class TomestoneHideHelper
{
    public static bool ShouldHide(
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        IDictionary<uint, bool> hideTomestoneById)
    {
        if (tomestones.Count == 0 || hideTomestoneById.Count == 0) return false;
        if (!L10N.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(normalizedText)) return false;

        foreach(TomestoneInfo tomestone in tomestones)
        {
            string itemNameLower = tomestone.Name.ToLower(CultureInfo.InvariantCulture);
            int lastWordStart = itemNameLower.LastIndexOf(' ') + 1;
            string typeName = itemNameLower[lastWordStart..];
            if (!normalizedText.Contains(typeName, StringComparison.Ordinal)) continue;
            return hideTomestoneById.TryGetValue(tomestone.RowId, out bool hide) && hide;
        }

        return false;
    }
}
