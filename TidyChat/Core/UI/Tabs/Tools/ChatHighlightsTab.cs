using Dalamud.Interface;
using Dalamud.Interface.Components;
using Dalamud.Interface.Utility;
using System.Numerics;
namespace TidyChat.Settings.Tabs;

internal static class ChatHighlightsTab
{
    private static ChatHighlight _placeholder = new();

    public static void DrawContent(Configuration configuration)
    {
        var enableChatHighlights = configuration.EnableChatHighlights;
        if (ImGui.Checkbox(Languages.ChatHighlightsTab_EnableChatHighlights, ref enableChatHighlights))
        {
            configuration.EnableChatHighlights = enableChatHighlights;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ChatHighlightsTab_EnableChatHighlightsHelpMarker);
        ImGui.Spacing();
        ImGui.TextWrapped(Languages.ChatHighlightsTab_ExplanationMessage);
        ImGui.Spacing();

        ImGui.TextUnformatted(Languages.ChatHighlightsTab_SelectChannelsHeader);
        ImGui.SameLine();
        ImGuiComponents.HelpMarker(Languages.ChatHighlightsTab_ChannelsHelpMarker);
        ImGui.SameLine();
        ImGui.TextUnformatted(Languages.ChatHighlightsTab_PatternHeader);
        ImGui.SameLine();
        ImGuiComponents.HelpMarker(Languages.ChatHighlightsTab_PatternHelpMarker);
        ImGui.SameLine();
        ImGui.TextUnformatted(Languages.ChatHighlightsTab_ColorHeader);
        ImGui.Spacing();

        var outerHeight = new Vector2(640f, 400f);
        using (var highlightsTable = ImRaii.Table("##chatHighlightsTable", 4,
                   ImGuiTableFlags.NoHostExtendX | ImGuiTableFlags.ScrollY | ImGuiTableFlags.Borders |
                   ImGuiTableFlags.RowBg, outerHeight))
        {
            if (!highlightsTable)
            {
                return;
            }

            ImGui.TableSetupScrollFreeze(0, 1);
            ImGui.TableSetupColumn(Languages.ChatHighlightsTab_SelectChannelsHeader, ImGuiTableColumnFlags.WidthFixed, 148f);
            ImGui.TableSetupColumn(Languages.ChatHighlightsTab_PatternHeader, ImGuiTableColumnFlags.WidthStretch);
            ImGui.TableSetupColumn(Languages.ChatHighlightsTab_ColorHeader, ImGuiTableColumnFlags.WidthFixed, 48f);
            ImGui.TableSetupColumn("##DeleteColumn", ImGuiTableColumnFlags.WidthFixed, 36f);
            ImGui.TableHeadersRow();

            var list = configuration.ChatHighlights.ToList();
            for (var i = -1; i < list.Count; i++)
            {
                ImGui.TableNextRow();
                var entry = i < 0 ? _placeholder : list[i];

                ImGui.TableNextColumn();
                ImGui.Spacing();
                if (ImGui.CollapsingHeader($"{(entry.Channels == 0 ? Languages.ChatHighlightsTab_SelectChannelsHeader + " (none)" : UiHelp.ChannelSummary(entry.Channels))}###chatHighlight{i}ChannelsHeader"))
                {
                    UiHelp.DrawChannelCheckboxes(configuration, ref entry.Channels, $"chatHighlight{i}");
                }

                ImGui.Spacing();
                ImGui.TableNextColumn();
                ImGui.Spacing();
                if (i == -1)
                {
                    ImGui.TextUnformatted(Languages.ChatHighlightsTab_MessageContains);
                }

                ImGui.SetNextItemWidth(-1);
                if (ImGui.InputText($"##chatHighlight{i}PatternInput", ref entry.Pattern, 120,
                        ImGuiInputTextFlags.EnterReturnsTrue))
                {
                    if (i == -1)
                    {
                        configuration.ChatHighlights.Insert(0, entry);
                        _placeholder = new();
                    }

                    configuration.OnSettingChanged();
                }

                ImGuiHelpers.ScaledDummy(10f);
                ImGui.TableNextColumn();
                ImGui.Spacing();
                if (i != -1)
                {
                    DrawColorPicker(configuration, entry, i);
                }

                ImGui.TableNextColumn();
                ImGui.Spacing();
                using (ImRaii.PushId($"DeleteHighlight{i}"))
                {
                    if (i != -1 && ImGuiComponents.IconButton(FontAwesomeIcon.Trash))
                    {
                        configuration.ChatHighlights.Remove(list[i]);
                        configuration.OnSettingChanged();
                    }
                }
            }
        }

        ImGui.Spacing();
        ImGui.TextWrapped(Languages.ChatHighlightsTab_RegexExplanation);
    }

    private static void DrawColorPicker(Configuration configuration, ChatHighlight entry, int rowIndex)
    {
        var color = ColourUtil.RgbaToVector3(entry.RgbaColor);
        ImGui.SetNextItemWidth(-1);
        if (ImGui.ColorEdit3($"##chatHighlight{rowIndex}Color", ref color,
                ImGuiColorEditFlags.NoInputs | ImGuiColorEditFlags.NoLabel | ImGuiColorEditFlags.NoAlpha))
        {
            entry.RgbaColor = ColourUtil.Vector3ToRgba(color);
            configuration.OnSettingChanged();
        }
    }
}
