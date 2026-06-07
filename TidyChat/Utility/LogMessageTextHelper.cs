namespace TidyChat.Utility;

internal static class LogMessageTextHelper
{
    internal static bool TryExtractText(ILogMessage message, out string text)
    {
        text = string.Empty;
        if (message is null || message.LogMessageId == 0)
        {
            return false;
        }

        if (message.Address == nint.Zero)
        {
            return false;
        }

        if (message.ParameterCount == 0 &&
            LogMessageCatalog.TryGetTemplateText(message.LogMessageId, out var staticTemplate))
        {
            text = staticTemplate;
            return text.Length > 0;
        }

        if (LogMessageCatalog.IsRuntimeOnly(message.LogMessageId) ||
            !AreLogMessageParametersReadable(message))
        {
            return false;
        }

        return TryFormatLogMessageUnsafe(message, out text);
    }

    internal static bool TryExtractNormalizedText(ILogMessage message, out string normalizedText)
    {
        normalizedText = string.Empty;
        if (!TryExtractText(message, out var text))
        {
            return false;
        }

        normalizedText = text.ToLower(CultureInfo.CurrentCulture);
        return normalizedText.Length > 0;
    }

    private static bool AreLogMessageParametersReadable(ILogMessage message)
    {
        var count = message.ParameterCount;
        if (count <= 0)
        {
            return true;
        }

        for (var i = 0; i < count; i++)
        {
            if (message.TryGetIntParameter(i, out _))
            {
                continue;
            }

            if (!message.TryGetStringParameter(i, out var stringParameter))
            {
                return false;
            }

            try
            {
                _ = stringParameter.ExtractText();
            }
            catch
            {
                return false;
            }
        }

        return true;
    }

    private static bool TryFormatLogMessageUnsafe(ILogMessage message, out string text)
    {
        text = string.Empty;
        try
        {
            var formatted = message.FormatLogMessageForDebugging();
            text = formatted.ExtractText();
            return text.Length > 0;
        }
        catch
        {
            return false;
        }
    }
}
