using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class CombatTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.CombatTab_CastingAndAbilitiesDropdownHeader, ImGuiTreeNodeFlags.DefaultOpen))
        {
            bool showCombatCasting = configuration.ShowCombatCasting;
            if (ImGui.Checkbox(Languages.CombatTab_ShowCombatCastingMessages, ref showCombatCasting))
            {
                configuration.ShowCombatCasting = showCombatCasting;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CombatTab_ShowCombatCastingMessagesHelpMarker);

            bool showCombatAbilities = configuration.ShowCombatAbilities;
            if (ImGui.Checkbox(Languages.CombatTab_ShowCombatAbilitiesMessages, ref showCombatAbilities))
            {
                configuration.ShowCombatAbilities = showCombatAbilities;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CombatTab_ShowCombatAbilitiesMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.CombatTab_DamageHealingAndEffectsDropdownHeader))
        {
            bool showCombatDamage = configuration.ShowCombatDamage;
            if (ImGui.Checkbox(Languages.CombatTab_ShowCombatDamageMessages, ref showCombatDamage))
            {
                configuration.ShowCombatDamage = showCombatDamage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CombatTab_ShowCombatDamageMessagesHelpMarker);

            bool showCombatMisses = configuration.ShowCombatMisses;
            if (ImGui.Checkbox(Languages.CombatTab_ShowCombatMissesMessages, ref showCombatMisses))
            {
                configuration.ShowCombatMisses = showCombatMisses;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CombatTab_ShowCombatMissesMessagesHelpMarker);

            bool showCombatHealing = configuration.ShowCombatHealing;
            if (ImGui.Checkbox(Languages.CombatTab_ShowCombatHealingMessages, ref showCombatHealing))
            {
                configuration.ShowCombatHealing = showCombatHealing;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CombatTab_ShowCombatHealingMessagesHelpMarker);

            bool showCombatEffects = configuration.ShowCombatEffects;
            if (ImGui.Checkbox(Languages.CombatTab_ShowCombatEffectsMessages, ref showCombatEffects))
            {
                configuration.ShowCombatEffects = showCombatEffects;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CombatTab_ShowCombatEffectsMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.CombatTab_DefeatAndAddsDropdownHeader))
        {
            bool showCombatDefeat = configuration.ShowCombatDefeat;
            if (ImGui.Checkbox(Languages.CombatTab_ShowCombatDefeatMessages, ref showCombatDefeat))
            {
                configuration.ShowCombatDefeat = showCombatDefeat;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CombatTab_ShowCombatDefeatMessagesHelpMarker);

            bool showCombatEnemyReady = configuration.ShowCombatEnemyReady;
            if (ImGui.Checkbox(Languages.CombatTab_ShowCombatEnemyReadyMessages, ref showCombatEnemyReady))
            {
                configuration.ShowCombatEnemyReady = showCombatEnemyReady;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CombatTab_ShowCombatEnemyReadyMessagesHelpMarker);

            bool showCombatAdds = configuration.ShowCombatAdds;
            if (ImGui.Checkbox(Languages.CombatTab_ShowCombatAddsMessages, ref showCombatAdds))
            {
                configuration.ShowCombatAdds = showCombatAdds;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CombatTab_ShowCombatAddsMessagesHelpMarker);

            bool showCombatEnmity = configuration.ShowCombatEnmity;
            if (ImGui.Checkbox(Languages.CombatTab_ShowCombatEnmityMessages, ref showCombatEnmity))
            {
                configuration.ShowCombatEnmity = showCombatEnmity;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CombatTab_ShowCombatEnmityMessagesHelpMarker);
        }
    }
}
