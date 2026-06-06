using Dalamud.Interface;
using Dalamud.Interface.Components;
using Dalamud.Interface.Utility;
using System.Numerics;
using Flags = TidyChat.Utility.ChatFlags;
namespace TidyChat.Settings.Tabs;

internal static class WhitelistTab
{
    private static PlayerName m_placeholder = new();

    public static void DrawContent(Configuration configuration)
    {
        var sentByWhitelistPlayer = configuration.SentByWhitelistPlayer;
        if (ImGui.Checkbox(Languages.WhitelistTab_ShowAllMessagesByWhitelistedPlayer, ref sentByWhitelistPlayer))
        {
            configuration.SentByWhitelistPlayer = sentByWhitelistPlayer;
            configuration.OnSettingChanged();
        }
        ImGuiComponents.HelpMarker(Languages.WhitelistTab_ShowAllMessagesByWhitelistedPlayerHelpMarker);

        var targetingWhitelistPlayer = configuration.TargetingWhitelistPlayer;
        if (ImGui.Checkbox(Languages.WhitelistTab_ShowAllMessagesTargetingWhitelistedPlayer,
                ref targetingWhitelistPlayer))
        {
            configuration.TargetingWhitelistPlayer = targetingWhitelistPlayer;
            configuration.OnSettingChanged();
        }
        ImGuiComponents.HelpMarker(Languages.WhitelistTab_ShowAllMessagesTargetingWhitelistedPlayerHelpMarker);

        ImGui.TextWrapped(Languages.WhitelistTab_ExplanationMessage);
        ImGui.Spacing();
        ImGui.TextWrapped(Languages.WhitelistTab_FilteringNote);
        ImGui.Spacing();

        ImGui.TextUnformatted(Languages.WhitelistTab_SelectChannelsHeader);
        ImGui.SameLine();
        ImGuiComponents.HelpMarker(Languages.WhitelistTab_ChannelsHelpMarker);
        ImGui.SameLine();
        ImGui.TextUnformatted(Languages.WhitelistTab_FiltersHeader);
        ImGui.SameLine();
        ImGuiComponents.HelpMarker(Languages.WhitelistTab_FiltersHelpMarker);
        ImGui.SameLine();
        ImGui.TextUnformatted(Languages.WhitelistTab_Allow);
        ImGui.SameLine();
        ImGuiComponents.HelpMarker(Languages.WhitelistTab_AllowBlockHelpMarker);
        ImGui.Spacing();

        var outer_height = new Vector2(640f, 400f);
        if (!ImGui.BeginTable("##whitelistTable", 4,
                ImGuiTableFlags.NoHostExtendX | ImGuiTableFlags.ScrollY | ImGuiTableFlags.Borders |
                ImGuiTableFlags.RowBg, outer_height))
        {
            return;
        }
        ImGui.TableSetupScrollFreeze(0, 1);
        ImGui.TableSetupColumn(Languages.WhitelistTab_SelectChannelsHeader, ImGuiTableColumnFlags.WidthFixed, 148f);
        ImGui.TableSetupColumn(Languages.WhitelistTab_FiltersHeader, ImGuiTableColumnFlags.WidthStretch);
        ImGui.TableSetupColumn(Languages.WhitelistTab_Allow, ImGuiTableColumnFlags.WidthFixed, 96f);
        ImGui.TableSetupColumn("##DeleteColumn", ImGuiTableColumnFlags.WidthFixed, 36f);
        ImGui.TableHeadersRow();
        var list = configuration.Whitelist.ToList();
        for (var i = -1; i < list.Count; i++)
        {
            ImGui.TableNextRow();
            var alias = i < 0 ? m_placeholder : list[i];

            #region Channels Column

            ImGui.TableNextColumn();
            ImGui.Spacing();
            if (ImGui.CollapsingHeader($"{FormatChannelSummary(alias.WhitelistedChannels)}##whitelist{i}ChannelsHeader"))
            {
                DrawChannelCheckboxes(configuration, alias, i);
            }

            ImGui.Spacing();

            #endregion Channels Column

            #region Player Column

            ImGui.TableNextColumn();
            ImGui.Spacing();
            if (i == -1)
            {
                ImGui.TextUnformatted(Languages.WhitelistTab_MessageContains);
            }

            ImGui.SetNextItemWidth(-1);
            if (ImGui.InputText($"##whitelist{i}FirstNameInput", ref alias.FirstName, 120,
                    ImGuiInputTextFlags.EnterReturnsTrue))
            {
                if (i == -1)
                {
                    configuration.Whitelist.Insert(0, alias);
                    m_placeholder = new();
                }

                configuration.OnSettingChanged();
            }

            if (i != -1 && !alias.IsRegex)
            {
                var matchPreview = alias.MatchMode == PlayerNameMatchMode.ExactSender
                    ? Languages.WhitelistTab_MatchModeExactSender
                    : Languages.WhitelistTab_MatchModeMessageContains;
                ImGui.SetNextItemWidth(-1);
                if (ImGui.BeginCombo($"##whitelist{i}MatchMode", matchPreview))
                {
                    if (ImGui.Selectable(Languages.WhitelistTab_MatchModeMessageContains,
                            alias.MatchMode == PlayerNameMatchMode.MessageContains))
                    {
                        alias.MatchMode = PlayerNameMatchMode.MessageContains;
                        configuration.OnSettingChanged();
                    }
                    if (ImGui.Selectable(Languages.WhitelistTab_MatchModeExactSender,
                            alias.MatchMode == PlayerNameMatchMode.ExactSender))
                    {
                        alias.MatchMode = PlayerNameMatchMode.ExactSender;
                        configuration.OnSettingChanged();
                    }
                    ImGui.EndCombo();
                }
            }

            ImGuiHelpers.ScaledDummy(10f);

            #endregion Player Column

            #region Allow Column

            ImGui.TableNextColumn();
            ImGui.Spacing();
            if (i == -1)
            { }
            else
            {
                var previewValue = "";
                if (alias.AllowMessage)
                {
                    previewValue = Languages.WhitelistTab_Allow;
                }
                else
                {
                    previewValue = Languages.WhitelistTab_Block;
                }
                ImGui.SetNextItemWidth(-1);
                if (ImGui.BeginCombo($"##whitelist{i}AllowSetting", previewValue))
                {
                    if (ImGui.Selectable($"{Languages.WhitelistTab_Allow}##{i}", alias.AllowMessage))
                    {
                        alias.AllowMessage = true;
                        configuration.OnSettingChanged();
                    }

                    if (ImGui.Selectable($"{Languages.WhitelistTab_Block}##{i}", !alias.AllowMessage))
                    {
                        alias.AllowMessage = false;
                        configuration.OnSettingChanged();
                    }

                    ImGui.EndCombo();
                }
            }

            #endregion Allow Column


            #region Delete Column

            ImGui.TableNextColumn();
            ImGui.Spacing();
            ImGui.PushID($"Delete{i}");
            if (i != -1 && ImGuiComponents.IconButton(FontAwesomeIcon.Trash))
            {
                configuration.Whitelist.Remove(list[i]);
                configuration.OnSettingChanged();
            }

            ImGui.PopID();

            #endregion Delete Column
        }

        ImGui.EndTable();
        ImGui.NewLine();
        ImGui.Spacing();
        ImGui.TextWrapped(Languages.WhitelistTab_ExactNameMatchWhitelistExplanation);
    }

    private static void DrawChannelCheckboxes(Configuration configuration, PlayerName alias, int rowIndex)
    {
        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_SystemChannel}##whitelist{rowIndex}OverrideSystemFilters",
                ref alias.WhitelistedChannels,
                1 << 3))
        {
            configuration.OnSettingChanged();
        }
        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_TalkingChannel}##whitelist{rowIndex}OverrideTalkingFilters",
                ref alias.WhitelistedChannels,
                1 << 2))
        {
            configuration.OnSettingChanged();
        }
        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_EmotesChannel}##whitelist{rowIndex}OverrideEmoteFilters",
                ref alias.WhitelistedChannels, 1 << 1))
        {
            configuration.OnSettingChanged();
        }
        if (ImGui.CheckboxFlags($"{Languages.ChatHistoryTab_LootChannel}##whitelist{rowIndex}OverrideLootFilters",
                ref alias.WhitelistedChannels, 1 << 5))
        {
            configuration.OnSettingChanged();
        }
        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_LootRollsChannel}##whitelist{rowIndex}OverrideLootRollFilters",
                ref alias.WhitelistedChannels, 1 << 6))
        {
            configuration.OnSettingChanged();
        }
        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_CraftingChannel}##whitelist{rowIndex}OverrideCraftingFilters",
                ref alias.WhitelistedChannels,
                1 << 8))
        {
            configuration.OnSettingChanged();
        }
        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_GatheringChannel}##whitelist{rowIndex}OverrideGatheringFilters",
                ref alias.WhitelistedChannels,
                1 << 9))
        {
            configuration.OnSettingChanged();
        }
        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_LoginLogoutChannel}##whitelist{rowIndex}OverrideFreeCompanyFilters",
                ref alias.WhitelistedChannels, 1 << 7))
        {
            configuration.OnSettingChanged();
        }
        if (ImGui.CheckboxFlags(
                $"{Languages.ChatHistoryTab_ProgressChannel}##whitelist{rowIndex}OverrideProgressFilters",
                ref alias.WhitelistedChannels,
                1 << 4))
        {
            configuration.OnSettingChanged();
        }
    }

    private static string FormatChannelSummary(int channelFlags)
    {
        if (channelFlags == 0)
        {
            return $"{Languages.WhitelistTab_ChannelsHeader} (none)";
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

        return labels.Count == 0
            ? $"{Languages.WhitelistTab_ChannelsHeader} (none)"
            : $"{Languages.WhitelistTab_ChannelsHeader}: {string.Join(", ", labels)}";
    }
}
