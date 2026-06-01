using System;
using System.Text.RegularExpressions;
using Dalamud.Game.Text;
using TidyChat.Utility;
using Flags = TidyChat.Utility.ChatFlags;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private void ApplyWhitelist(IHandleableChatMessage message, ChatType chatType, ref bool isHandled)
    {
        if (Configuration.Whitelist.Count == 0) return;
        try
        {
            foreach(PlayerName p in Configuration.Whitelist)
            {
                if (!p.AllowMessage)
                    CustomFilterCheck(message.Sender, message.Message, ref isHandled, p, chatType);
            }
            foreach(PlayerName p in Configuration.Whitelist)
            {
                if (p.AllowMessage)
                    CustomFilterCheck(message.Sender, message.Message, ref isHandled, p, chatType);
            }

            ApplyGlobalWhitelistOverrides(message, ref isHandled);
        }
        catch(Exception ex)
        {
            Log.Error("Error: Failed to evaluate Whitelist - " + ex);
        }
    }

    private void ApplyGlobalWhitelistOverrides(IHandleableChatMessage message, ref bool isHandled)
    {
        if (!Configuration.SentByWhitelistPlayer && !Configuration.TargetingWhitelistPlayer)
            return;

        string senderText = message.Sender.TextValue;
        string messageText = message.Message.TextValue;

        foreach(PlayerName entry in Configuration.Whitelist)
        {
            if (string.IsNullOrWhiteSpace(entry.FirstName) || entry.IsLogMessageId)
                continue;

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
            Regex? regex = entry.GetCompiledRegex();
            return regex != null && regex.IsMatch(senderText);
        }

        return string.Equals(senderText, entry.FirstName, StringComparison.Ordinal);
    }

    private static bool TargetsWhitelistEntry(string messageText, PlayerName entry)
    {
        if (entry.IsRegex)
        {
            Regex? regex = entry.GetCompiledRegex();
            return regex != null && regex.IsMatch(messageText);
        }

        return messageText.Contains(entry.FirstName, StringComparison.Ordinal);
    }
    private bool CustomFilterMatches(SeString sender, SeString message, PlayerName entry, ChatType chatType)
    {
        if (string.IsNullOrWhiteSpace(entry.FirstName)) return false; // empty name would Contains-match everything

        if (entry.IsLogMessageId) return false;

        var channels = (ChatFlags.Channels)entry.WhitelistedChannels;
        if (channels == ChatFlags.Channels.None) return false;
        if (!Flags.CheckFlags(entry, chatType)) return false;

        if (entry.IsRegex)
        {
            Regex? regex = entry.GetCompiledRegex((src, ex) =>
                Log.Warning($"[Whitelist] Invalid regex \"{src}\": {ex.Message}"));
            try
            {
                return regex != null && regex.IsMatch(message.TextValue);
            }
            catch(RegexMatchTimeoutException)
            {
                Log.Warning($"[Whitelist] Regex match timeout for \"{entry.FirstName}\"");
                return false;
            }
        }

        if (entry.MatchMode == PlayerNameMatchMode.ExactSender)
            return string.Equals(sender.TextValue, entry.FirstName, StringComparison.Ordinal);

        return string.Equals(sender.TextValue, entry.FirstName, StringComparison.Ordinal)
               || message.TextValue.Contains(entry.FirstName, StringComparison.Ordinal);
    }

    private bool IsWhitelistedAllowed(SeString sender, SeString message, ChatType chatType)
    {
        if (Configuration.Whitelist.Count == 0) return false;
        foreach(PlayerName p in Configuration.Whitelist)
        {
            if (!p.AllowMessage) continue;
            if (CustomFilterMatches(sender, message, p, chatType)) return true;
        }
        return false;
    }

    private bool IsWhitelistedBlocked(SeString sender, SeString message, ChatType chatType)
    {
        if (Configuration.Whitelist.Count == 0) return false;
        foreach(PlayerName p in Configuration.Whitelist)
        {
            if (p.AllowMessage) continue;
            if (CustomFilterMatches(sender, message, p, chatType)) return true;
        }
        return false;
    }

    private void CustomFilterCheck(SeString sender, SeString message, ref bool isHandled,
        PlayerName playerOrMessage,
        ChatType chatType)
    {
        if (string.IsNullOrWhiteSpace(playerOrMessage.FirstName)) return;
        if (!CustomFilterMatches(sender, message, playerOrMessage, chatType)) return;

        if (!isHandled && !playerOrMessage.AllowMessage)
        {
            isHandled = true;
            if (Configuration.EnableDebugMode)
                Log.Verbose($"A message matching \"{playerOrMessage.FirstName}\" has been blocked.");
        }
        else if (isHandled && playerOrMessage.AllowMessage)
        {
            isHandled = false;
            if (Configuration.EnableDebugMode)
                Log.Verbose($"A message matching \"{playerOrMessage.FirstName}\" has been allowed.");
        }
    }
}
