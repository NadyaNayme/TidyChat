namespace TidyChat.Settings;

/// <summary>
///     How login and world-travel server announcements are filtered (welcome line, event promos, congestion, phishing).
/// </summary>
public enum ServerAnnouncementMode
{
    /// <summary>Show every line unchanged (default; same as pre-#122 behaviour).</summary>
    ShowAll = 0,

    /// <summary>Hide the entire announcement block.</summary>
    HideAll = 1,

    /// <summary>Keep only the "Welcome to &lt;world&gt;!" line.</summary>
    Condensed = 2,

    /// <summary>Full block on login; nothing on world-hops.</summary>
    LoginOnly = 3,

    /// <summary>Full block on login; welcome line only on world-hops.</summary>
    LoginThenCondensed = 4,

    /// <summary>Keep greeting and event text; hide phishing and congestion warnings.</summary>
    HidePhishing = 5
}
