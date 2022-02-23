using System.Linq;
using System.Numerics;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class WhitelistTab
    {
        private static PlayerName m_placeholder = new();
        public static void Draw(Configuration configuration)
        {


            var sentByWhitelistPlayer = configuration.SentByWhitelistPlayer;
            if (ImGui.Checkbox("Show all messages sent by whitelisted player", ref sentByWhitelistPlayer))
            {
                configuration.SentByWhitelistPlayer = sentByWhitelistPlayer;
                configuration.Save();
            }


            var targetingWhitelistPlayer = configuration.TargetingWhitelistPlayer;
            if (ImGui.Checkbox("Show all messages targeting a whitelisted player", ref targetingWhitelistPlayer))
            {
                configuration.TargetingWhitelistPlayer = targetingWhitelistPlayer;
                configuration.Save();
            }

            ImGui.TextUnformatted("Users added to the whitelist will be treated as if they were you for all filter settings.\nEnter a player's first and last name and then press <Enter> to add them to the whitelist.");
            ImGui.Spacing();

            ImGui.NewLine();
            Vector2 outer_height = new Vector2(520f, 400f);
            if (!ImGui.BeginTable("##whitelistTable", 3, ImGuiTableFlags.NoHostExtendX | ImGuiTableFlags.ScrollY | ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg, outer_height)) return;
            ImGui.TableSetupScrollFreeze(0, 1);
            ImGui.TableSetupColumn("First Name", ImGuiTableColumnFlags.WidthFixed);
            ImGui.TableSetupColumn("Last Name", ImGuiTableColumnFlags.WidthFixed);
            ImGui.TableSetupColumn("Server (Optional)", ImGuiTableColumnFlags.WidthFixed);
            ImGui.TableHeadersRow();

            var list = configuration.Whitelist.ToList();
            for (var i = -1; i < list.Count; i++)
            {
                var alias = i < 0 ? m_placeholder : list[i];
                ImGui.TableNextColumn();
                ImGui.SetNextItemWidth(120);
                if (ImGui.InputText($"##whitelist{i}FirstNameInput", ref alias.FirstName, 512, ImGuiInputTextFlags.EnterReturnsTrue))
                {
                    if (i == -1)
                    {
                        configuration.Whitelist.Insert(0, alias);
                        m_placeholder = new PlayerName();
                    }
                    configuration.Save();
                }
                ImGui.TableNextColumn();
                ImGui.SetNextItemWidth(160);
                if (ImGui.InputText($"##whitelist{i}LastNameInput", ref alias.LastName, 512, ImGuiInputTextFlags.EnterReturnsTrue))
                {
                    if (i == -1)
                    {
                        configuration.Whitelist.Insert(0, alias);
                        m_placeholder = new PlayerName();
                    }
                    configuration.Save();
                }
                ImGui.TableNextColumn();
                ImGui.SetNextItemWidth(160);
                if (ImGui.InputText($"##whitelist{i}ServerNameInput", ref alias.ServerName, 512, ImGuiInputTextFlags.EnterReturnsTrue))
                {
                    if (i == -1)
                    {
                        configuration.Whitelist.Insert(0, alias);
                        m_placeholder = new PlayerName();
                    }
                    configuration.Save();
                }

                ImGui.SameLine();
                if (i != -1 && ImGui.Button($" X ##player{i}delete"))
                {
                    configuration.Whitelist.Remove(alias);
                    configuration.Save();
                }
            }
            ImGui.EndTable();
            ImGui.NewLine();
            ImGui.Spacing();
            ImGui.TextUnformatted("You must enter the player's name as it would be seen in chat - including any periods.\n\neg.\nSurname Abbreviated: Example N.\nForename Abbreviated: E. Name\nInitials: E. N.");
            ImGui.EndTabItem();
        }
    }
}
