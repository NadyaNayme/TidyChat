namespace TidyChat;

/// <summary>
///     Controls how the login / world-travel server announcement block is handled —
///     the "Welcome to &lt;world&gt;", event-promo, congestion and phishing-warning messages.
/// </summary>
public enum ServerAnnouncementMode
{
    /// <summary>Show every announcement line unchanged (default — preserves prior behaviour).</summary>
    ShowAll = 0,

    /// <summary>Suppress the entire announcement block.</summary>
    HideAll = 1,

    /// <summary>Suppress everything except the "Welcome to &lt;world&gt;!" line.</summary>
    Condensed = 2,

    /// <summary>Show the full block on login, but suppress it on world-hops.</summary>
    LoginOnly = 3,

    /// <summary>Show the full block on login, but only "Welcome to &lt;world&gt;!" on world-hops.</summary>
    LoginThenCondensed = 4,

    /// <summary>Show greeting and event text, but suppress the phishing/congestion warning lines.</summary>
    HidePhishing = 5
}
