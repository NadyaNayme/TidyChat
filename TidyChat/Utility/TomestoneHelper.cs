using System.Collections.Generic;
namespace TidyChat.Utility;

internal static class TomestoneHelper
{
    public static bool ShouldHide(
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        IDictionary<uint, bool> hideTomestoneById)
    {
        if (!TryGetMatchedTomestone(normalizedText, tomestones, out var tomestone))
        {
            return false;
        }

        return hideTomestoneById.TryGetValue(tomestone.RowId, out var hide) && hide;
    }

    /// <summary>
    /// Tomestone obtain lines should show when the per-tomestone hide toggle is off,
    /// even if Show general item obtains is off.
    /// </summary>
    public static bool ShouldAllowObtain(
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        IDictionary<uint, bool> hideTomestoneById)
    {
        if (!TryGetMatchedTomestone(normalizedText, tomestones, out var tomestone))
        {
            return false;
        }

        return !hideTomestoneById.TryGetValue(tomestone.RowId, out var hide) || !hide;
    }

    private static bool TryGetMatchedTomestone(
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        out TomestoneInfo tomestone)
    {
        tomestone = default!;
        if (tomestones.Count == 0)
        {
            return false;
        }
        if (!L10N.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(normalizedText))
        {
            return false;
        }

        foreach (var candidate in tomestones)
        {
            var itemNameLower = candidate.Name.ToLower(CultureInfo.InvariantCulture);
            var lastWordStart = itemNameLower.LastIndexOf(' ') + 1;
            var typeName = itemNameLower[lastWordStart..];
            if (!normalizedText.Contains(typeName, StringComparison.Ordinal))
            {
                continue;
            }

            tomestone = candidate;
            return true;
        }

        return false;
    }
}
