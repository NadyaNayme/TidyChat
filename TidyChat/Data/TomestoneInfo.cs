namespace TidyChat.Data;

/// <summary>
///     Tomestone names and row IDs from the TomestoneItem sheet, loaded at plugin startup.
/// </summary>
public sealed record TomestoneInfo(uint RowId, string Name);
