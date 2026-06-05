using System.Threading;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private bool HandleServerAnnouncements(IHandleableChatMessage message, ChatType chatType, string normalizedText,
        bool protectedByShowRule)
    {
        if (protectedByShowRule)
        {
            return false;
        }
        if (Configuration.ServerAnnouncementMode == ServerAnnouncementMode.ShowAll)
        {
            return false;
        }

        var isWorldGreeting = ServerAnnouncementCatalog.IsWorldGreeting(normalizedText);
        var isGenericGameWelcome = ServerAnnouncementCatalog.IsGenericGameWelcome(normalizedText);
        var isAnnouncement = ServerAnnouncementCatalog.IsAnnouncement(normalizedText);
        if (!isWorldGreeting && !isAnnouncement)
        {
            return false;
        }

        var isPhishing = ServerAnnouncementCatalog.IsPhishingWarning(normalizedText);
        // Login announcements usually use System; some clients also deliver them on Notice/Urgent (#24).
        if (chatType is not ChatType.System && chatType is not ChatType.Notice and not ChatType.Urgent)
        {
            return false;
        }

        var withinLoginWindow = DateTime.UtcNow < _serverAnnouncementLoginGraceEnd;
        var keepGenericGameWelcome =
            Configuration.ServerAnnouncementMode is ServerAnnouncementMode.HidePhishing ||
            (withinLoginWindow && Configuration.ServerAnnouncementMode is ServerAnnouncementMode.LoginOnly or ServerAnnouncementMode.LoginThenCondensed);

        var suppress = Configuration.ServerAnnouncementMode switch
        {
            ServerAnnouncementMode.HideAll => true,
            ServerAnnouncementMode.Condensed => !isWorldGreeting,
            ServerAnnouncementMode.LoginOnly => !withinLoginWindow,
            ServerAnnouncementMode.LoginThenCondensed => !withinLoginWindow && !isWorldGreeting,
            ServerAnnouncementMode.HidePhishing => isPhishing,
            _ => false
        };
        if (isGenericGameWelcome && !keepGenericGameWelcome)
        {
            suppress = true;
        }

        if (suppress)
        {
            if (Configuration.EnableDebugMode)
            {
                Log.Debug($"BLOCKED (server announcement): {message.Message}");
                if (!message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                {
                    message.Message = BuildDebugString(chatType, message.Message, ["ServerAnnouncement"], Configuration.DebugIncludeChannel, true);
                }
                return true;
            }
            message.PreventOriginal();
            Interlocked.Increment(ref _sessionBlockedMessages);
            return true;
        }

        if (Configuration.EnableDebugMode)
        {
            if (!message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
            {
                message.Message = BuildDebugString(chatType, message.Message, ["ServerAnnouncement"], Configuration.DebugIncludeChannel, false);
            }
            return true;
        }

        var isCondensing = Configuration.ServerAnnouncementMode switch
        {
            ServerAnnouncementMode.Condensed => true,
            ServerAnnouncementMode.LoginThenCondensed => !withinLoginWindow,
            ServerAnnouncementMode.HidePhishing => true,
            _ => false
        };
        if (isCondensing && Configuration.IncludeChatTag)
        {
            SeStringBuilder tagBuilder = new();
            Better.AddTidyChatTag(tagBuilder);
            tagBuilder.AddText(message.Message.TextValue);
            message.Message = tagBuilder.BuiltString;
        }

        return true;
    }
}
