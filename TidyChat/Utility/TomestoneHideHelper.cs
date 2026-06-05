using System.Collections.Generic;
namespace TidyChat.Utility;

internal static class TomestoneHideHelper
{
    public static bool ShouldHide(
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        IDictionary<uint, bool> hideTomestoneById)
    {
        if (tomestones.Count == 0 || hideTomestoneById.Count == 0)
        {
            return false;
        }
        if (!L10N.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(normalizedText))
        {
            return false;
        }

        foreach (var tomestone in tomestones)
        {
            var itemNameLower = tomestone.Name.ToLower(CultureInfo.InvariantCulture);
            var lastWordStart = itemNameLower.LastIndexOf(' ') + 1;
            var typeName = itemNameLower[lastWordStart..];
            if (!normalizedText.Contains(typeName, StringComparison.Ordinal))
            {
                continue;
            }
            return hideTomestoneById.TryGetValue(tomestone.RowId, out var hide) && hide;
        }

        return false;
    }
}
