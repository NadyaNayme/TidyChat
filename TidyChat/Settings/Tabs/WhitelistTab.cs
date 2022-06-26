using System.Linq;
using System.Numerics;
using Dalamud.Interface;
using Dalamud.Interface.Components;
using ImGuiNET;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings.Tabs;

internal static class WhitelistTab
{
    private static PlayerName m_placeholder = new();

    public static void Draw(Configuration configuration)
    {
        var sentByWhitelistPlayer = configuration.SentByWhitelistPlayer;
        if (ImGui.Checkbox(localization.WhitelistTab_ShowAllMessagesByWhitelistedPlayer, ref sentByWhitelistPlayer))
        {
            configuration.SentByWhitelistPlayer = sentByWhitelistPlayer;
            configuration.Save();
        }

        var targetingWhitelistPlayer = configuration.TargetingWhitelistPlayer;
        if (ImGui.Checkbox(localization.WhitelistTab_ShowAllMessagesTargetingWhitelistedPlayer,
                ref targetingWhitelistPlayer))
        {
            configuration.TargetingWhitelistPlayer = targetingWhitelistPlayer;
            configuration.Save();
        }

        ImGui.TextUnformatted(localization.WhitelistTab_ExplanationMessage);
        ImGui.Spacing();

        ImGui.NewLine();
        var outer_height = new Vector2(640f, 400f);
        if (!ImGui.BeginTable("##whitelistTable", 4,
                ImGuiTableFlags.NoHostExtendX | ImGuiTableFlags.ScrollY | ImGuiTableFlags.Borders |
                ImGuiTableFlags.RowBg, outer_height)) return;
        ImGui.TableSetupScrollFreeze(0, 1);
        ImGui.TableSetupColumn(localization.WhitelistTab_SelectChannelsHeader, ImGuiTableColumnFlags.WidthFixed);
        ImGui.TableSetupColumn(localization.WhitelistTab_PlayerInformationTableHeader,
            ImGuiTableColumnFlags.WidthStretch);
        ImGui.TableSetupColumn("##AllowColumn", ImGuiTableColumnFlags.WidthFixed, 120f);
        ImGui.TableSetupColumn("##DeleteColumn", ImGuiTableColumnFlags.WidthFixed);
        ImGui.TableHeadersRow();
        var list = configuration.Whitelist.ToList();
        for (var i = -1; i < list.Count; i++)
        {
            var alias = i < 0 ? m_placeholder : list[i];

            #region Channels Column

            ImGui.TableNextColumn();
            ImGui.Spacing();
            if (ImGui.CollapsingHeader($"{localization.WhitelistTab_ChannelsHeader}##whitelist{i}ChannelsHeader"))
            {
                if (ImGui.CheckboxFlags(
                        $"{localization.ChatHistoryTab_EmotesChannel}##whitelist{i}OverrideEmoteFilters",
                        ref alias.whitelistedChannels, 1 << 1))
                    configuration.Save();
                if (ImGui.CheckboxFlags($"{localization.ChatHistoryTab_LootChannel}##whitelist{i}OverrideLootFilters",
                        ref alias.whitelistedChannels, 1 << 5))
                    configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{localization.ChatHistoryTab_CraftingChannel}##whitelist{i}OverrideCraftingFilters",
                        ref alias.whitelistedChannels,
                        1 << 8)) configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{localization.ChatHistoryTab_GatheringChannel}##whitelist{i}OverrideGatheringFilters",
                        ref alias.whitelistedChannels,
                        1 << 9)) configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{localization.ChatHistoryTab_TalkingChannel}##whitelist{i}OverrideTalkingFilters",
                        ref alias.whitelistedChannels,
                        1 << 2)) configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{localization.ChatHistoryTab_LoginLogoutChannel}##whitelist{i}OverrideFreeCompanyFilters",
                        ref alias.whitelistedChannels, 1 << 7)) configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{localization.ChatHistoryTab_ProgressChannel}##whitelist{i}OverrideProgressFilters",
                        ref alias.whitelistedChannels,
                        1 << 4)) configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{localization.ChatHistoryTab_SystemChannel}##whitelist{i}OverrideSystemFilters",
                        ref alias.whitelistedChannels,
                        1 << 3)) configuration.Save();
            }

            ImGui.Spacing();

            #endregion Channels Column

            #region Player Column

            ImGui.SetNextItemWidth(-1);
            ImGui.TableNextColumn();
            ImGui.Spacing();
            ImGui.TextUnformatted(localization.WhitelistTab_WhitelistedPlayerFirstName);
            ImGuiHelpers.ScaledRelativeSameLine(0f);
            if (ImGui.InputText($"##whitelist{i}FirstNameInput", ref alias.FirstName, 120,
                    ImGuiInputTextFlags.EnterReturnsTrue))
            {
                if (i == -1)
                {
                    configuration.Whitelist.Insert(0, alias);
                    m_placeholder = new PlayerName();
                }

                configuration.Save();
            }

            ImGui.TextUnformatted(localization.WhitelistTab_WhitelistedPlayerLastName);
            ImGuiHelpers.ScaledRelativeSameLine(0f);

            if (ImGui.InputText($"##whitelist{i}LastNameInput", ref alias.LastName, 120,
                    ImGuiInputTextFlags.EnterReturnsTrue))
            {
                if (i == -1)
                {
                    configuration.Whitelist.Insert(0, alias);
                    m_placeholder = new PlayerName();
                }

                configuration.Save();
            }

            ImGui.TextUnformatted(localization.WhitelistTab_WhitelistedPlayerServerName);
            ImGuiHelpers.ScaledRelativeSameLine(0f);

            if (ImGui.InputText($"##whitelist{i}ServerNameInput", ref alias.ServerName, 132,
                    ImGuiInputTextFlags.EnterReturnsTrue))
            {
                if (i == -1)
                {
                    configuration.Whitelist.Insert(0, alias);
                    m_placeholder = new PlayerName();
                }

                configuration.Save();
            }

            ImGuiHelpers.ScaledDummy(10f);

            #endregion Player Column

            #region Allow Column

            ImGui.TableNextColumn();
            ImGui.Spacing();
            if (i == -1)
            {
                // Don't render the Allow/Block for initial addition
            }
            else
            {
                var previewValue = "";
                if (alias.AllowMessage)
                    previewValue = localization.WhitelistTab_Allow;
                else
                    previewValue = localization.WhitelistTab_Block;
                if (ImGui.BeginCombo($"##whitelist{i}AllowSetting", previewValue))
                {
                    if (ImGui.Selectable($"{localization.WhitelistTab_Allow}##{i}", alias.AllowMessage))
                    {
                        alias.AllowMessage = true;
                        configuration.Save();
                    }

                    if (ImGui.Selectable($"{localization.WhitelistTab_Block}##{i}", !alias.AllowMessage))
                    {
                        alias.AllowMessage = false;
                        configuration.Save();
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
                configuration.Save();
            }

            ImGui.PopID();

            #endregion Delete Column
        }

        ImGui.EndTable();
        ImGui.NewLine();
        ImGui.Spacing();
        ImGui.TextUnformatted(localization.WhitelistTab_ExactNameMatchWhitelistExplanation);
        ImGui.EndTabItem();
    }
}