using System.Diagnostics;
using ImGuiNET;
using TidyChat.Localization.Resources;

namespace TidyChat;

public static class TabFooter
{
    public static bool Display(Configuration configuration)
    {
        ImGui.Spacing();
        ImGui.Separator();
        ImGui.Spacing();
        if (ImGui.Button(Languages.SettingsTabFooter_SaveButtonText)) configuration.Save();
        ImGui.SameLine();
        if (ImGui.Button(Languages.SettingsTabFooter_SaveAndCloseButtonText))
        {
            configuration.Save();
            return true;
        }

        if (!configuration.NoCoffee)
        {
            ImGui.SameLine();
            ImGui.PushStyleColor(ImGuiCol.Button, 0xFF000000 | 0x005E5BFF);
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, 0xDD000000 | 0x005E5BFF);
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, 0xAA000000 | 0x005E5BFF);

            if (ImGui.Button(Languages.SettingsTabFooter_SupportOnKofiButtonText))
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://ko-fi.com/nadyanayme",
                    UseShellExecute = true,
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
                UseShellExecute = true,
            });
        ImGui.PopStyleColor(3);

        return false;
    }
}
