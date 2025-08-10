using System.Linq;
using System.Numerics;
using Dalamud.Interface;
using Dalamud.Interface.Components;
using Dalamud.Interface.Utility;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings.Tabs;

internal static class WhitelistTab
{
    private static PlayerName m_placeholder = new();

    public static void Draw(Configuration configuration)
    {
        var sentByWhitelistPlayer = configuration.SentByWhitelistPlayer;
        if (ImGui.Checkbox(Languages.WhitelistTab_ShowAllMessagesByWhitelistedPlayer, ref sentByWhitelistPlayer))
        {
            configuration.SentByWhitelistPlayer = sentByWhitelistPlayer;
            configuration.Save();
        }

        var targetingWhitelistPlayer = configuration.TargetingWhitelistPlayer;
        if (ImGui.Checkbox(Languages.WhitelistTab_ShowAllMessagesTargetingWhitelistedPlayer,
                ref targetingWhitelistPlayer))
        {
            configuration.TargetingWhitelistPlayer = targetingWhitelistPlayer;
            configuration.Save();
        }

        ImGui.TextUnformatted(Languages.WhitelistTab_ExplanationMessage);
        ImGui.Spacing();

        ImGui.NewLine();
        var outer_height = new Vector2(640f, 400f);
        if (!ImGui.BeginTable("##whitelistTable", 4,
                ImGuiTableFlags.NoHostExtendX | ImGuiTableFlags.ScrollY | ImGuiTableFlags.Borders |
                ImGuiTableFlags.RowBg, outer_height)) return;
        ImGui.TableSetupScrollFreeze(0, 1);
        ImGui.TableSetupColumn(Languages.WhitelistTab_SelectChannelsHeader, ImGuiTableColumnFlags.WidthFixed);
        ImGui.TableSetupColumn(Languages.WhitelistTab_FiltersHeader,
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
            if (ImGui.CollapsingHeader($"{Languages.WhitelistTab_ChannelsHeader}##whitelist{i}ChannelsHeader"))
            {
                if (ImGui.CheckboxFlags(
                        $"{Languages.ChatHistoryTab_SystemChannel}##whitelist{i}OverrideSystemFilters",
                        ref alias.whitelistedChannels,
                        1 << 3)) configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{Languages.ChatHistoryTab_TalkingChannel}##whitelist{i}OverrideTalkingFilters",
                        ref alias.whitelistedChannels,
                        1 << 2)) configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{Languages.ChatHistoryTab_EmotesChannel}##whitelist{i}OverrideEmoteFilters",
                        ref alias.whitelistedChannels, 1 << 1))
                    configuration.Save();
                if (ImGui.CheckboxFlags($"{Languages.ChatHistoryTab_LootChannel}##whitelist{i}OverrideLootFilters",
                        ref alias.whitelistedChannels, 1 << 5))
                    configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{Languages.ChatHistoryTab_CraftingChannel}##whitelist{i}OverrideCraftingFilters",
                        ref alias.whitelistedChannels,
                        1 << 8)) configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{Languages.ChatHistoryTab_GatheringChannel}##whitelist{i}OverrideGatheringFilters",
                        ref alias.whitelistedChannels,
                        1 << 9)) configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{Languages.ChatHistoryTab_LoginLogoutChannel}##whitelist{i}OverrideFreeCompanyFilters",
                        ref alias.whitelistedChannels, 1 << 7)) configuration.Save();
                if (ImGui.CheckboxFlags(
                        $"{Languages.ChatHistoryTab_ProgressChannel}##whitelist{i}OverrideProgressFilters",
                        ref alias.whitelistedChannels,
                        1 << 4)) configuration.Save();
            }

            ImGui.Spacing();

            #endregion Channels Column

            #region Player Column

            ImGui.TableNextColumn();
            ImGui.Spacing();
            if (i == -1) ImGui.TextUnformatted(Languages.WhitelistTab_MessageContains);

            ImGui.SetNextItemWidth(-1);
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
                    previewValue = Languages.WhitelistTab_Allow;
                else
                    previewValue = Languages.WhitelistTab_Block;
                ImGui.SetNextItemWidth(-1);
                if (ImGui.BeginCombo($"##whitelist{i}AllowSetting", previewValue))
                {
                    if (ImGui.Selectable($"{Languages.WhitelistTab_Allow}##{i}", alias.AllowMessage))
                    {
                        alias.AllowMessage = true;
                        configuration.Save();
                    }

                    if (ImGui.Selectable($"{Languages.WhitelistTab_Block}##{i}", !alias.AllowMessage))
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
        ImGui.TextUnformatted(Languages.WhitelistTab_ExactNameMatchWhitelistExplanation);
        ImGui.EndTabItem();
    }
}