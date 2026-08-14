namespace TidyChat;

internal static class TidyChatCommandParser
{
    internal enum ActionKind
    {
        OpenSettings,
        ToggleDebug,
        SetDebug,
        ShowUsage
    }

    internal static ActionKind Parse(string? args, out bool debugEnabled)
    {
        debugEnabled = false;
        if (string.IsNullOrWhiteSpace(args))
        {
            return ActionKind.OpenSettings;
        }

        var parts = args.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (parts.Length == 0)
        {
            return ActionKind.OpenSettings;
        }

        var head = parts[0].ToLowerInvariant();
        if (head is "help" or "?" or "usage")
        {
            return ActionKind.ShowUsage;
        }

        if (head is not "debug")
        {
            return ActionKind.ShowUsage;
        }

        if (parts.Length == 1)
        {
            return ActionKind.ToggleDebug;
        }

        switch (parts[1].ToLowerInvariant())
        {
            case "on":
            case "enable":
            case "true":
            case "1":
                debugEnabled = true;
                return ActionKind.SetDebug;
            case "off":
            case "disable":
            case "false":
            case "0":
                debugEnabled = false;
                return ActionKind.SetDebug;
            case "toggle":
                return ActionKind.ToggleDebug;
            default:
                return ActionKind.ShowUsage;
        }
    }
}
