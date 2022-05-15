using ImGuiNET;
using System.Linq;
using System.Numerics;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings.Tabs
{
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
            if (ImGui.Checkbox(localization.WhitelistTab_ShowAllMessagesTargetingWhitelistedPlayer, ref targetingWhitelistPlayer))
            {
                configuration.TargetingWhitelistPlayer = targetingWhitelistPlayer;
                configuration.Save();
            }

            ImGui.TextUnformatted(localization.WhitelistTab_ExplanationMessage);
            ImGui.Spacing();

            ImGui.NewLine();
            Vector2 outer_height = new Vector2(540f, 400f);
            if (!ImGui.BeginTable("##whitelistTable", 3, ImGuiTableFlags.NoHostExtendX | ImGuiTableFlags.ScrollY | ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg, outer_height)) return;
            ImGui.TableSetupScrollFreeze(0, 1);
            ImGui.TableSetupColumn(localization.WhitelistTab_SelectChannelsHeader, ImGuiTableColumnFlags.WidthFixed);
            ImGui.TableSetupColumn(localization.WhitelistTab_PlayerInformationTableHeader, ImGuiTableColumnFlags.WidthFixed);
            ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthStretch);
            ImGui.TableHeadersRow();

            var list = configuration.Whitelist.ToList();
            for (var i = -1; i < list.Count; i++)
            {
                var alias = i < 0 ? m_placeholder : list[i];

                #region Channels Column
                ImGui.TableNextColumn();
                ImGui.Spacing();
                if (ImGui.CheckboxFlags($"Emotes##whitelist{i}OverrideEmoteFilters", ref alias.whitelistedChannels, 1 << 1))
                {
                    configuration.Save();
                }
                ImGui.SameLine(80f);
                if (ImGui.CheckboxFlags($"Loot##whitelist{i}OverrideLootFilters", ref alias.whitelistedChannels, 1 << 5))
                {
                    configuration.Save();
                }
                if (ImGui.CheckboxFlags($"Crafting##whitelist{i}OverrideCraftingFilters", ref alias.whitelistedChannels, 1 << 8))
                {
                    configuration.Save();
                }
                ImGui.SameLine(80f);
                if (ImGui.CheckboxFlags($"Gathering##whitelist{i}OverrideGatheringFilters", ref alias.whitelistedChannels, 1 << 9))
                {
                    configuration.Save();
                }
                if (ImGui.CheckboxFlags($"Talking##whitelist{i}OverrideTalkingFilters", ref alias.whitelistedChannels, 1 << 2))
                {
                    configuration.Save();
                }
                ImGui.SameLine(80f);
                if (ImGui.CheckboxFlags($"Login/Logout##whitelist{i}OverrideFreeCompanyFilters", ref alias.whitelistedChannels, 1 << 7))
                {
                    configuration.Save();
                }
                if (ImGui.CheckboxFlags($"Progress##whitelist{i}OverrideProgressFilters", ref alias.whitelistedChannels, 1 << 4))
                {
                    configuration.Save();
                }
                ImGui.SameLine(80f);
                if (ImGui.CheckboxFlags($"System##whitelist{i}OverrideSystemFilters", ref alias.whitelistedChannels, 1 << 3))
                {
                    configuration.Save();
                }
                ImGui.Spacing();
                #endregion Channels Column

                #region Player Column
                ImGui.TableNextColumn();
                ImGui.Spacing();
                ImGui.SetNextItemWidth(120);
                ImGui.TextUnformatted(localization.WhitelistTab_WhitelistedPlayerFirstName);
                ImGui.SameLine(75f);
                if (ImGui.InputText($"##whitelist{i}FirstNameInput", ref alias.FirstName, 20, ImGuiInputTextFlags.EnterReturnsTrue))
                {
                    if (i == -1)
                    {
                        configuration.Whitelist.Insert(0, alias);
                        m_placeholder = new PlayerName();
                    }
                    configuration.Save();
                }
                ImGui.SetNextItemWidth(120);
                ImGui.TextUnformatted(localization.WhitelistTab_WhitelistedPlayerLastName);
                ImGui.SameLine(75f);
                if (ImGui.InputText($"##whitelist{i}LastNameInput", ref alias.LastName, 20, ImGuiInputTextFlags.EnterReturnsTrue))
                {
                    if (i == -1)
                    {
                        configuration.Whitelist.Insert(0, alias);
                        m_placeholder = new PlayerName();
                    }
                    configuration.Save();
                }
                ImGui.SetNextItemWidth(120);
                ImGui.TextUnformatted(localization.WhitelistTab_WhitelistedPlayerServerName);
                ImGui.SameLine(75f);
                if (ImGui.InputText($"##whitelist{i}ServerNameInput", ref alias.ServerName, 32, ImGuiInputTextFlags.EnterReturnsTrue))
                {
                    if (i == -1)
                    {
                        configuration.Whitelist.Insert(0, alias);
                        m_placeholder = new PlayerName();
                    }
                    configuration.Save();
                }
                #endregion Player Column
                #region Delete Column
                ImGui.TableNextColumn();
                ImGui.Spacing();
                if (i != -1 && ImGui.Button($"Remove##player{i}delete"))
                {
                    configuration.Whitelist.Remove(alias);
                    configuration.Save();
                }
                #endregion Delete Column
            }
            ImGui.EndTable();
            ImGui.NewLine();
            ImGui.Spacing();
            ImGui.TextUnformatted(localization.WhitelistTab_ExactNameMatchWhitelistExplanation);
            ImGui.EndTabItem();
        }
    }
}
