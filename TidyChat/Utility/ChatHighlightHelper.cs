using Dalamud.Utility;
using Lumina.Text.Parse;
using Lumina.Text.ReadOnly;
using System.Text;
using System.Text.RegularExpressions;
namespace TidyChat.Utility;

internal static class ChatHighlightHelper
{
    private static readonly MacroStringParseOptions MacroParseOptions = new()
    {
        ExceptionMode = MacroStringParseExceptionMode.Throw
    };

    public static SeString ApplyForeground(
        SeString message, uint rgbaColor)
    {
        string text;
        try
        {
            text = new ReadOnlySeString(message.Encode()).ExtractText();
        }
        catch
        {
            text = message.TextValue;
        }

        if (string.IsNullOrEmpty(text))
        {
            return message;
        }

        var argbColor = ColourUtil.RgbaToArgb(rgbaColor);
        var macroText = $"<color(0x{argbColor:X8})>{EscapeMacroText(text)}<color(stackcolor)>";
        using var rented = new RentedSeStringBuilder();
        rented.Builder.AppendMacroString(Encoding.UTF8.GetBytes(macroText), MacroParseOptions);
        return rented.Builder.ToReadOnlySeString().ToDalamudString();
    }

    private static string EscapeMacroText(string text)
    {
        if (text.IndexOfAny(['\\', '<', '>', '(', ')', '[', ']', ',']) < 0)
        {
            return text;
        }

        var builder = new StringBuilder(text.Length + 8);
        foreach (var ch in text)
        {
            if (ch is '\\' or '<' or '>' or '(' or ')' or '[' or ']' or ',')
            {
                builder.Append('\\');
            }

            builder.Append(ch);
        }

        return builder.ToString();
    }

    public static bool TryGetMatchingHighlight(IList<ChatHighlight> highlights, ChatType chatType,
        string rawTextValue, string extractedTextValue, string normalizedText, out ChatHighlight? match)
    {
        foreach (var entry in highlights)
        {
            if (Matches(entry, chatType, rawTextValue, extractedTextValue, normalizedText))
            {
                match = entry;
                return true;
            }
        }

        match = null;
        return false;
    }

    private static bool Matches(ChatHighlight entry, ChatType chatType, string rawTextValue,
        string extractedTextValue, string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(entry.Pattern))
        {
            return false;
        }

        var channels = (ChatFlags.Channels)entry.Channels;
        if (channels == ChatFlags.Channels.None || !ChatFlags.CheckFlags(entry.Channels, chatType))
        {
            return false;
        }

        if (entry.IsRegex)
        {
            var regex = entry.GetCompiledRegex();
            if (regex is null)
            {
                return false;
            }

            try
            {
                return regex.IsMatch(rawTextValue) ||
                       regex.IsMatch(extractedTextValue) ||
                       regex.IsMatch(normalizedText);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        return ContainsIgnoreCase(rawTextValue, entry.Pattern) ||
               ContainsIgnoreCase(extractedTextValue, entry.Pattern) ||
               ContainsIgnoreCase(normalizedText, entry.Pattern);
    }

    private static bool ContainsIgnoreCase(string haystack, string needle) =>
        !string.IsNullOrEmpty(needle) &&
        haystack.Contains(needle, StringComparison.OrdinalIgnoreCase);
}
