using Dalamud.Interface.Components;
using ImGuiNET;
using TidyChat.Resources.Languages;

namespace TidyChat.Settings.Tabs;

internal static class EmotesTab
{
    public static void Draw(Configuration configuration)
    {
        var filterEmoteSpam = configuration.FilterEmoteSpam;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterEmotes, ref filterEmoteSpam))
        {
            configuration.FilterEmoteSpam = filterEmoteSpam;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterEmotesHelpMarker);

        var hideOtherCustomEmotes = configuration.ShowOtherCustomEmotes;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterCustomEmotes, ref hideOtherCustomEmotes))
        {
            configuration.ShowOtherCustomEmotes = hideOtherCustomEmotes;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterCustomEmotesHelpMarker);

        var hideUsedEmotes = configuration.ShowUsedEmotes;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterSelfEmotes, ref hideUsedEmotes))
        {
            configuration.ShowUsedEmotes = hideUsedEmotes;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterSelfEmotesHelpMarker);
    }
}