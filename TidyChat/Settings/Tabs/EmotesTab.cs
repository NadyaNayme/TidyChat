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

        var hideOtherCustomEmotes = configuration.HideOtherCustomEmotes;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterCustomEmotes, ref hideOtherCustomEmotes))
        {
            configuration.HideOtherCustomEmotes = hideOtherCustomEmotes;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterCustomEmotesHelpMarker);

        var hideUsedEmotes = configuration.HideUsedEmotes;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterSelfEmotes, ref hideUsedEmotes))
        {
            configuration.HideUsedEmotes = hideUsedEmotes;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterSelfEmotesHelpMarker);
    }
}