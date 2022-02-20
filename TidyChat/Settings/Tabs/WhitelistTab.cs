using System.Numerics;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class WhitelistTab
    {
        public static void Draw(Configuration configuration)
        {

            ImGui.TextUnformatted("Users added to the whitelist will be treated as if they were you for all filter settings.");
            ImGui.Dummy(new Vector2(0f, 25f));

            ImGui.EndTabItem();
        }
    }
}
