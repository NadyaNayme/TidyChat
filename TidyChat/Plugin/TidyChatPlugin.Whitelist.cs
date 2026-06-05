using System.Text.RegularExpressions;
using Flags = TidyChat.Utility.ChatFlags;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private void ApplyWhitelist(IHandleableChatMessage message, ChatType chatType, string rawTextValue,
        string extractedTextValue, string normalizedText, ref bool isHandled)
    {
        if (Configuration.Whitelist.Count == 0)
        {
            return;
        }
        try
        {
            foreach (var p in Configuration.Whitelist)
            {
                if (!p.AllowMessage)
                {
                    CustomFilterCheck(message.Sender, message.Message, rawTextValue, extractedTextValue,
                        normalizedText, ref isHandled, p, chatType);
                }
            }
            foreach (var p in Configuration.Whitelist)
            {
                if (p.AllowMessage)
                {
                    CustomFilterCheck(message.Sender, message.Message, rawTextValue, extractedTextValue,
                        normalizedText, ref isHandled, p, chatType);
                }
            }

            ApplyGlobalWhitelistOverrides(message, ref isHandled);
        }
        catch (Exception ex)
        {
            Log.Error("Error: Failed to evaluate Whitelist - " + ex);
        }
    }

    private void ApplyGlobalWhitelistOverrides(IHandleableChatMessage message, ref bool isHandled)
    {
        if (!Configuration.SentByWhitelistPlayer && !Configuration.TargetingWhitelistPlayer)
        {
            return;
        }

        var senderText = message.Sender.TextValue;
        var messageText = message.Message.TextValue;

        foreach (var entry in Configuration.Whitelist)
        {
            if (string.IsNullOrWhiteSpace(entry.FirstName) || entry.IsLogMessageId)
            {
                continue;
            }

            if (Configuration.SentByWhitelistPlayer && IsSentByWhitelistEntry(senderText, entry))
            {
                isHandled = false;
                return;
            }

            if (Configuration.TargetingWhitelistPlayer && TargetsWhitelistEntry(messageText, entry))
            {
                isHandled = false;
                return;
            }
        }
    }

    private static bool IsSentByWhitelistEntry(string senderText, PlayerName entry)
    {
        if (entry.IsRegex)
        {
            var regex = entry.GetCompiledRegex();
            return regex != null && regex.IsMatch(senderText);
        }

        return string.Equals(senderText, entry.FirstName, StringComparison.Ordinal);
    }

    private static bool TargetsWhitelistEntry(string messageText, PlayerName entry)
    {
        if (entry.IsRegex)
        {
            var regex = entry.GetCompiledRegex();
            return regex != null && regex.IsMatch(messageText);
        }

        return messageText.Contains(entry.FirstName, StringComparison.Ordinal);
    }
    private bool CustomFilterMatches(SeString sender, SeString message, PlayerName entry, ChatType chatType,
        string rawTextValue, string extractedTextValue, string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(entry.FirstName))
        {
            return false; // empty name would Contains-match everything
        }

        if (entry.IsLogMessageId)
        {
            return false;
        }

        var channels = (ChatFlags.Channels)entry.WhitelistedChannels;
        if (channels == ChatFlags.Channels.None)
        {
            return false;
        }
        if (!Flags.CheckFlags(entry, chatType))
        {
            return false;
        }

        if (entry.IsRegex)
        {
            var regex = entry.GetCompiledRegex((src, ex) =>
                Log.Warning($"[Whitelist] Invalid regex \"{src}\": {ex.Message}"));
            try
            {
                return regex != null &&
                       (regex.IsMatch(rawTextValue) || regex.IsMatch(extractedTextValue) ||
                        regex.IsMatch(normalizedText));
            }
            catch (RegexMatchTimeoutException)
            {
                Log.Warning($"[Whitelist] Regex match timeout for \"{entry.FirstName}\"");
                return false;
            }
        }

        if (entry.MatchMode == PlayerNameMatchMode.ExactSender)
        {
            return string.Equals(sender.TextValue, entry.FirstName, StringComparison.Ordinal);
        }

        return string.Equals(sender.TextValue, entry.FirstName, StringComparison.OrdinalIgnoreCase) ||
               ContainsIgnoreCase(rawTextValue, entry.FirstName) ||
               ContainsIgnoreCase(extractedTextValue, entry.FirstName) ||
               ContainsIgnoreCase(normalizedText, entry.FirstName);
    }

    private static bool ContainsIgnoreCase(string haystack, string needle) =>
        !string.IsNullOrEmpty(needle) &&
        haystack.Contains(needle, StringComparison.OrdinalIgnoreCase);

    private bool IsWhitelistedAllowed(SeString sender, SeString message, ChatType chatType, string rawTextValue,
        string extractedTextValue, string normalizedText)
    {
        if (Configuration.Whitelist.Count == 0)
        {
            return false;
        }
        foreach (var p in Configuration.Whitelist)
        {
            if (!p.AllowMessage)
            {
                continue;
            }
            if (CustomFilterMatches(sender, message, p, chatType, rawTextValue, extractedTextValue, normalizedText))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsWhitelistedBlocked(SeString sender, SeString message, ChatType chatType, string rawTextValue,
        string extractedTextValue, string normalizedText)
    {
        if (Configuration.Whitelist.Count == 0)
        {
            return false;
        }
        foreach (var p in Configuration.Whitelist)
        {
            if (p.AllowMessage)
            {
                continue;
            }
            if (CustomFilterMatches(sender, message, p, chatType, rawTextValue, extractedTextValue, normalizedText))
            {
                return true;
            }
        }
        return false;
    }

    private void CustomFilterCheck(SeString sender, SeString message, string rawTextValue, string extractedTextValue,
        string normalizedText, ref bool isHandled, PlayerName playerOrMessage, ChatType chatType)
    {
        if (string.IsNullOrWhiteSpace(playerOrMessage.FirstName))
        {
            return;
        }
        if (!CustomFilterMatches(sender, message, playerOrMessage, chatType, rawTextValue, extractedTextValue,
                normalizedText))
        {
            return;
        }

        isHandled = !playerOrMessage.AllowMessage;
        if (Configuration.EnableDebugMode)
        {
            Log.Verbose(playerOrMessage.AllowMessage
                ? $"A message matching \"{playerOrMessage.FirstName}\" has been allowed."
                : $"A message matching \"{playerOrMessage.FirstName}\" has been blocked.");
        }
    }
}
