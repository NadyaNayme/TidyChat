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
                if (ImGui.CollapsingHeader($"{FormatChannelSummary(entry.Channels)}##chatHighlight{i}ChannelsHeader"))
                {
                    DrawChannelCheckboxes(configuration, entry, i);
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

    private static void DrawChannelCheckboxes(Configuration configuration, ChatHighlight entry, int rowIndex)
    {
        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_SystemChannel}##chatHighlight{rowIndex}System",
                ref entry.Channels,
                1 << 3))
        {
            configuration.OnSettingChanged();
        }

        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_TalkingChannel}##chatHighlight{rowIndex}Talking",
                ref entry.Channels,
                1 << 2))
        {
            configuration.OnSettingChanged();
        }

        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_EmotesChannel}##chatHighlight{rowIndex}Emotes",
                ref entry.Channels,
                1 << 1))
        {
            configuration.OnSettingChanged();
        }

        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_LootChannel}##chatHighlight{rowIndex}Loot",
                ref entry.Channels,
                1 << 5))
        {
            configuration.OnSettingChanged();
        }

        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_LootRollsChannel}##chatHighlight{rowIndex}LootRolls",
                ref entry.Channels,
                1 << 6))
        {
            configuration.OnSettingChanged();
        }

        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_CraftingChannel}##chatHighlight{rowIndex}Crafting",
                ref entry.Channels,
                1 << 8))
        {
            configuration.OnSettingChanged();
        }

        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_GatheringChannel}##chatHighlight{rowIndex}Gathering",
                ref entry.Channels,
                1 << 9))
        {
            configuration.OnSettingChanged();
        }

        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_LoginLogoutChannel}##chatHighlight{rowIndex}LoginLogout",
                ref entry.Channels,
                1 << 7))
        {
            configuration.OnSettingChanged();
        }

        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_ProgressChannel}##chatHighlight{rowIndex}Progress",
                ref entry.Channels,
                1 << 4))
        {
            configuration.OnSettingChanged();
        }
    }

    private static string FormatChannelSummary(int channelFlags)
    {
        if (channelFlags == 0)
        {
            return $"{Languages.ChatHighlightsTab_SelectChannelsHeader} (none)";
        }

        var labels = new List<string>();
        if ((channelFlags & (int)ChatFlags.Channels.System) != 0)
        {
            labels.Add(Languages.ChatHistoryTab_SystemChannel);
        }

        if ((channelFlags & (int)ChatFlags.Channels.PlayerChannels) != 0)
        {
            labels.Add(Languages.ChatHistoryTab_TalkingChannel);
        }

        if ((channelFlags & (int)ChatFlags.Channels.Emotes) != 0)
        {
            labels.Add(Languages.ChatHistoryTab_EmotesChannel);
        }

        if ((channelFlags & (int)ChatFlags.Channels.Progress) != 0)
        {
            labels.Add(Languages.ChatHistoryTab_ProgressChannel);
        }

        if ((channelFlags & (int)ChatFlags.Channels.Loot) != 0)
        {
            labels.Add(Languages.ChatHistoryTab_LootChannel);
        }

        if ((channelFlags & (int)ChatFlags.Channels.Obtain) != 0)
        {
            labels.Add(Languages.ChatHistoryTab_LootRollsChannel);
        }

        if ((channelFlags & (int)ChatFlags.Channels.FreeCompany) != 0)
        {
            labels.Add(Languages.ChatHistoryTab_LoginLogoutChannel);
        }

        if ((channelFlags & (int)ChatFlags.Channels.Crafting) != 0)
        {
            labels.Add(Languages.ChatHistoryTab_CraftingChannel);
        }

        if ((channelFlags & (int)ChatFlags.Channels.Gathering) != 0)
        {
            labels.Add(Languages.ChatHistoryTab_GatheringChannel);
        }

        return string.Join(", ", labels);
    }
}
