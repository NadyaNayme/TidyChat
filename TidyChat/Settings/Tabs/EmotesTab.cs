using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class EmotesTab
{
    public static void Draw(Configuration configuration)
    {
        var filterEmoteSpam = configuration.FilterEmoteChannel;
        if (ImGui.Checkbox(Languages.EmotesTab_FilterStandardEmotes, ref filterEmoteSpam))
        {
            configuration.FilterEmoteChannel = filterEmoteSpam;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.EmotesTab_FilterStandardEmotesHelpMarker);

        var filterCustomEmoteSpam = configuration.FilterCustomEmoteChannel;
        if (ImGui.Checkbox(Languages.EmotesTab_FilterCustomEmoteChannel, ref filterCustomEmoteSpam))
        {
            configuration.FilterCustomEmoteChannel = filterCustomEmoteSpam;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.EmotesTab_FilterCustomEmoteChannelHelpMarker);

        var showOtherCustomEmotes = configuration.ShowOtherCustomEmotes;
        if (ImGui.Checkbox(Languages.EmotesTab_ShowOtherCustomEmotes, ref showOtherCustomEmotes))
        {
            configuration.ShowOtherCustomEmotes = showOtherCustomEmotes;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.EmotesTab_ShowOtherCustomEmotesHelpMarker);

        var showSelfUsedEmotes = configuration.ShowSelfUsedEmotes;
        if (ImGui.Checkbox(Languages.EmotesTab_ShowSelfCustomEmotes, ref showSelfUsedEmotes))
        {
            configuration.ShowSelfUsedEmotes = showSelfUsedEmotes;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.EmotesTab_ShowSelfCustomEmotesHelpMarker);
    }
}
