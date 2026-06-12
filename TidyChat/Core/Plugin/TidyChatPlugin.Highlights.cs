namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private static void MigrateLegacyHighlightColors(IList<ChatHighlight> highlights)
    {
        foreach (var highlight in highlights)
        {
            if (highlight.UiForegroundColor != 0)
            {
                highlight.RgbaColor = ChatHighlightPresets.FromLegacyUiForeground(highlight.UiForegroundColor);
                highlight.UiForegroundColor = 0;
                continue;
            }

            if (highlight.RgbaColor == 0)
            {
                highlight.RgbaColor = ChatHighlightPresets.DefaultRgba;
            }
        }
    }

    private void TryApplyChatHighlight(IHandleableChatMessage message, ChatType chatType, string rawTextValue,
        string extractedTextValue, string normalizedText)
    {
        if (!Configuration.EnableChatHighlights || Configuration.ChatHighlights.Count == 0)
        {
            return;
        }

        if (!ChatHighlightHelper.TryGetMatchingHighlight(Configuration.ChatHighlights, chatType, rawTextValue,
                extractedTextValue, normalizedText, out var highlight) ||
            highlight is null)
        {
            return;
        }

        message.Message = ChatHighlightHelper.ApplyForeground(message.Message, highlight.RgbaColor);
    }
}
