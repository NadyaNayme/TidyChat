using ImGuiNET;
using System.Diagnostics;

namespace TidyChat
{
    public static class SettingsTabFooter
    {
		public static void Display(Configuration configuration, ref bool settingsVisible)
		{
			ImGui.Spacing();
			ImGui.Separator();
			ImGui.Spacing();
			if (ImGui.Button("Save"))
			{
				configuration.Save();
			}
			ImGui.SameLine();
			if (ImGui.Button("Save and Close Config"))
			{
				configuration.Save();
				settingsVisible = false;
			}
			if (!configuration.NoCoffee)
			{
				ImGui.SameLine();
				ImGui.PushStyleColor(ImGuiCol.Button, 0xFF000000 | 0x005E5BFF);
				ImGui.PushStyleColor(ImGuiCol.ButtonActive, 0xDD000000 | 0x005E5BFF);
				ImGui.PushStyleColor(ImGuiCol.ButtonHovered, 0xAA000000 | 0x005E5BFF);

				if (ImGui.Button("Support on Ko-Fi"))
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = "https://ko-fi.com/nadyanayme",
						UseShellExecute = true
					});
				}

				ImGui.PopStyleColor(3);
			}
		}
	}
}
