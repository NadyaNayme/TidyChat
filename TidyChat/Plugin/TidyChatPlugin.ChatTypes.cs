using Dalamud.Game.Text;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    #region Chat2 ChatTypes

    // Stole this region from Anna's Chat2: https://git.annaclemens.io/ascclemens/ChatTwo/src/branch/main/ChatTwo
    private const ushort Clear7 = ~(~0 << 7);

    private static ChatType FromCode(ushort code) => (ChatType)(code & Clear7);

    private static ChatType FromDalamud(XivChatType type) => FromCode((ushort)type);

    #endregion Chat2 ChatTypes
}
