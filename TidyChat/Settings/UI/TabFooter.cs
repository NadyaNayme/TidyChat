using System.Diagnostics;
using System.Numerics;
using TidyStrings = TidyChat.Utility.InternalStrings;
namespace TidyChat.Settings.UI;

public static class TabFooter
{
    public static void Display(Configuration configuration)
    {
        ImGui.Spacing();
        ImGui.Separator();
        ImGui.Spacing();

        if (!configuration.NoCoffee)
        {
            ImGui.PushStyleColor(ImGuiCol.Button, 0xFF000000 | 0x005E5BFF);
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, 0xDD000000 | 0x005E5BFF);
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, 0xAA000000 | 0x005E5BFF);

            if (ImGui.Button(Languages.SettingsTabFooter_SupportOnKofiButtonText))
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://ko-fi.com/kagekazu",
                    UseShellExecute = true
                });

            ImGui.PopStyleColor(3);
        }

        ImGui.SameLine();
        ImGui.PushStyleColor(ImGuiCol.Button, 0x80FA8600);
        ImGui.PushStyleColor(ImGuiCol.ButtonActive, 0x2BBB3200);
        ImGui.PushStyleColor(ImGuiCol.ButtonHovered, 0x6ED86400);
        if (ImGui.Button(Languages.SettingsTabFooter_WikiPageButtonText))
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/NadyaNayme/TidyChat/wiki",
                UseShellExecute = true
            });
        ImGui.PopStyleColor(3);

        ImGui.SameLine();
        float versionWidth = ImGui.CalcTextSize(TidyStrings.Version).X;
        ImGui.SetCursorPosX(ImGui.GetWindowContentRegionMax().X - versionWidth);
        ImGui.TextColored(new Vector4(0.45f, 0.45f, 0.45f, 1f), TidyStrings.Version);
    }
}
