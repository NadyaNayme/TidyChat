using Dalamud.Game.Text;
namespace TidyChat;

/// <summary>
///     Dalamud <c>IChatGui.Print</c> queues messages with a bare channel id, so both relation kinds stay
///     <see cref="XivChatRelationKind.None" />. Game-originated chat packs source/target into the log info word.
/// </summary>
internal static class PluginChatPassthroughHelper
{
    internal const string PassthroughRuleName = "Plugin passthrough";

    internal static bool IsDalamudPluginPrint(XivChatRelationKind sourceKind, XivChatRelationKind targetKind) =>
        sourceKind is XivChatRelationKind.None && targetKind is XivChatRelationKind.None;

    internal static bool ShouldAllow(XivChatRelationKind sourceKind, XivChatRelationKind targetKind) =>
        IsDalamudPluginPrint(sourceKind, targetKind);
}
