namespace TidyChat;

/// <summary>
///     Tomestone data loaded from the game's TomestoneItem sheet via Lumina at plugin startup.
/// </summary>
public sealed record TomestoneInfo(uint RowId, string Name);
