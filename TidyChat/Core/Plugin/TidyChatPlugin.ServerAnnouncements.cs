namespace TidyChat;

internal enum ServerAnnouncementChatAction : byte
{
    None = 0,
    Show = 1,
    Hide = 2
}

public sealed partial class TidyChatPlugin
{
    /// <summary>
    ///     Classifies login/world-travel announcement lines. Callers must still run
    ///     <see cref="FinishChatHandling" /> so custom Allow/Block filters can override.
    /// </summary>
    private ServerAnnouncementChatAction HandleServerAnnouncements(IHandleableChatMessage message, ChatType chatType,
        string normalizedText, bool protectedByShowRule)
    {
        if (protectedByShowRule)
        {
            return ServerAnnouncementChatAction.None;
        }
        if (Configuration.ServerAnnouncementMode == ServerAnnouncementMode.ShowAll)
        {
            return ServerAnnouncementChatAction.None;
        }

        var isWorldGreeting = ServerAnnouncementCatalog.IsWorldGreeting(normalizedText);
        var isGenericGameWelcome = ServerAnnouncementCatalog.IsGenericGameWelcome(normalizedText);
        var isAnnouncement = ServerAnnouncementCatalog.IsAnnouncement(normalizedText);
        if (!isWorldGreeting && !isAnnouncement)
        {
            return ServerAnnouncementChatAction.None;
        }

        var isPhishing = ServerAnnouncementCatalog.IsPhishingWarning(normalizedText);
        // Login announcements usually use System; some clients also deliver them on Notice/Urgent (#24).
        if (chatType is not (ChatType.System or ChatType.Notice or ChatType.Urgent))
        {
            return ServerAnnouncementChatAction.None;
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
            return ServerAnnouncementChatAction.Hide;
        }

        var isCondensing = Configuration.ServerAnnouncementMode switch
        {
            ServerAnnouncementMode.Condensed => true,
            ServerAnnouncementMode.LoginThenCondensed => !withinLoginWindow,
            ServerAnnouncementMode.HidePhishing => true,
            _ => false
        };
        if (isCondensing && Configuration.IncludeChatTag && !Configuration.EnableDebugMode)
        {
            SeStringBuilder tagBuilder = new();
            Better.AddTidyChatTag(tagBuilder);
            tagBuilder.AddText(message.Message.TextValue);
            message.Message = tagBuilder.BuiltString;
        }

        return ServerAnnouncementChatAction.Show;
    }
}
