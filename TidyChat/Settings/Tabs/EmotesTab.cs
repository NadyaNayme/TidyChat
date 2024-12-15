using Dalamud.Interface.Components;
using ImGuiNET;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings.Tabs;

internal static class EmotesTab
{
    public static void Draw(Configuration configuration)
    {
        var filterEmoteSpam = configuration.FilterEmoteChannel;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterEmotes, ref filterEmoteSpam))
        {
            configuration.FilterEmoteChannel = filterEmoteSpam;
            configuration.Save();
        }
        
        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterEmotesHelpMarker);
        
        var filterCustomEmoteSpam = configuration.FilterCustomEmoteChannel;
        if (ImGui.Checkbox("Filter Custom Emote Channel", ref filterCustomEmoteSpam))
        {
            configuration.FilterCustomEmoteChannel = filterCustomEmoteSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker("This will hide all Custom Emotes unless it is an emote targeting you or an emote you used.");

        var showSelfUsedEmotes = configuration.ShowSelfUsedEmotes;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterSelfEmotes, ref showSelfUsedEmotes))
        {
            configuration.ShowSelfUsedEmotes = showSelfUsedEmotes;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterSelfEmotesHelpMarker);
    }
}