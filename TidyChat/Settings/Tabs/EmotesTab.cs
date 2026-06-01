using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class EmotesTab
{
    public static void Draw(Configuration configuration)
    {
        bool filterEmoteSpam = configuration.FilterEmoteChannel;
        if (ImGui.Checkbox(Languages.EmotesTab_FilterStandardEmotes, ref filterEmoteSpam))
        {
            configuration.FilterEmoteChannel = filterEmoteSpam;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.EmotesTab_FilterStandardEmotesHelpMarker);

        bool filterCustomEmoteSpam = configuration.FilterCustomEmoteChannel;
        if (ImGui.Checkbox(Languages.EmotesTab_FilterCustomEmoteChannel, ref filterCustomEmoteSpam))
        {
            configuration.FilterCustomEmoteChannel = filterCustomEmoteSpam;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.EmotesTab_FilterCustomEmoteChannelHelpMarker);

        bool showOtherCustomEmotes = configuration.ShowOtherCustomEmotes;
        if (ImGui.Checkbox(Languages.EmotesTab_ShowOtherCustomEmotes, ref showOtherCustomEmotes))
        {
            configuration.ShowOtherCustomEmotes = showOtherCustomEmotes;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.EmotesTab_ShowOtherCustomEmotesHelpMarker);

        bool showSelfUsedEmotes = configuration.ShowSelfUsedEmotes;
        if (ImGui.Checkbox(Languages.EmotesTab_ShowSelfCustomEmotes, ref showSelfUsedEmotes))
        {
            configuration.ShowSelfUsedEmotes = showSelfUsedEmotes;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.EmotesTab_ShowSelfCustomEmotesHelpMarker);
    }
}
