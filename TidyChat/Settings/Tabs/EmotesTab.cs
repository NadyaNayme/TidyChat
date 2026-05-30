using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class EmotesTab
{
    public static void Draw(Configuration configuration)
    {
        bool filterEmoteSpam = configuration.FilterEmoteChannel;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterEmotes, ref filterEmoteSpam))
        {
            configuration.FilterEmoteChannel = filterEmoteSpam;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterEmotesHelpMarker);

        bool filterCustomEmoteSpam = configuration.FilterCustomEmoteChannel;
        if (ImGui.Checkbox(Languages.EmotesTab_FilterCustomEmoteChannel, ref filterCustomEmoteSpam))
        {
            configuration.FilterCustomEmoteChannel = filterCustomEmoteSpam;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.EmotesTab_FilterCustomEmoteChannelHelpMarker);

        bool showOtherCustomEmotes = configuration.ShowOtherCustomEmotes;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterCustomEmotes, ref showOtherCustomEmotes))
        {
            configuration.ShowOtherCustomEmotes = showOtherCustomEmotes;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterCustomEmotesHelpMarker);

        bool showSelfUsedEmotes = configuration.ShowSelfUsedEmotes;
        if (ImGui.Checkbox(Languages.GeneralTab_FilterSelfEmotes, ref showSelfUsedEmotes))
        {
            configuration.ShowSelfUsedEmotes = showSelfUsedEmotes;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterSelfEmotesHelpMarker);
    }
}
