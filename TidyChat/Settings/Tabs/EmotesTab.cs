using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class EmotesTab
    {
        public static void Draw(Configuration configuration)
        {
            var filterEmoteSpam = configuration.FilterEmoteSpam;
            if (ImGui.Checkbox("Filter emote spam", ref filterEmoteSpam))
            {
                configuration.FilterEmoteSpam = filterEmoteSpam;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will hide all emote text unless it is an emote targeting you or an emote you used.");

            var hideOtherCustomEmotes = configuration.HideOtherCustomEmotes;
            if (ImGui.Checkbox("Filter custom emote spam", ref hideOtherCustomEmotes))
            {
                configuration.HideOtherCustomEmotes = hideOtherCustomEmotes;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will hide all \"/em\" messages unless it mentions you or is a custom emote you used.\neg. Another Player leans over and gives you a big bear hug.");

            var hideUsedEmotes = configuration.HideUsedEmotes;
            if (ImGui.Checkbox("Filter emotes used by yourself", ref hideUsedEmotes))
            {
                configuration.HideUsedEmotes = hideUsedEmotes;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will hide the message that occurs when you use an emote or custom emote.\neg. You gently pat <user>");
        }
    }
}
