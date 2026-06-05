namespace TidyChat.Settings.Tabs;

internal static class DeepDungeonsTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.DeepDungeonsTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.PartyDutyTab_DeepDungeonsDropdownHeader, () => DrawDeepDungeonOptions(configuration)));
    }

    private static void DrawDeepDungeonOptions(Configuration configuration)
    {
        var showCairnGlows = configuration.ShowCairnGlows;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCairnOfPassageGlowsMessages, ref showCairnGlows))
        {
            configuration.ShowCairnGlows = showCairnGlows;
            configuration.OnSettingChanged();
        }

        var showRestoresLifeToFallen = configuration.ShowRestoresLifeToFallen;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCairnOfReturnUsedMessages, ref showRestoresLifeToFallen))
        {
            configuration.ShowRestoresLifeToFallen = showRestoresLifeToFallen;
            configuration.OnSettingChanged();
        }

        var showCairnActivates = configuration.ShowCairnActivates;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCairnOfPassageActivatedMessages, ref showCairnActivates))
        {
            configuration.ShowCairnActivates = showCairnActivates;
            configuration.OnSettingChanged();
        }

        var showTransference = configuration.ShowTransference;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowTransferenceMessages, ref showTransference))
        {
            configuration.ShowTransference = showTransference;
            configuration.OnSettingChanged();
        }

        var showAetherpoolIncrease = configuration.ShowAetherpoolIncrease;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAetherpoolIncreasesMessages, ref showAetherpoolIncrease))
        {
            configuration.ShowAetherpoolIncrease = showAetherpoolIncrease;
            configuration.OnSettingChanged();
        }

        var showAetherpoolUnchanged = configuration.ShowAetherpoolUnchanged;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAetherpoolRemainsUnchangedMessages,
                ref showAetherpoolUnchanged))
        {
            configuration.ShowAetherpoolUnchanged = showAetherpoolUnchanged;
            configuration.OnSettingChanged();
        }

        var showObtainedPomander = configuration.ShowObtainedPomander;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowObtainedPomanderMessages, ref showObtainedPomander))
        {
            configuration.ShowObtainedPomander = showObtainedPomander;
            configuration.OnSettingChanged();
        }

        var showTrapTriggered = configuration.ShowTrapTriggered;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowTrapTriggeredMessages, ref showTrapTriggered))
        {
            configuration.ShowTrapTriggered = showTrapTriggered;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowTrapTriggeredMessagesHelpMarker);

        var showPomanderEffects = configuration.ShowPomanderEffects;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowPomanderEffectsMessages, ref showPomanderEffects))
        {
            configuration.ShowPomanderEffects = showPomanderEffects;
            configuration.OnSettingChanged();
        }

        var showFloorNumber = configuration.ShowFloorNumber;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowFloorNumberMessages, ref showFloorNumber))
        {
            configuration.ShowFloorNumber = showFloorNumber;
            configuration.OnSettingChanged();
        }

        var showSenseAccursedHoard = configuration.ShowSenseAccursedHoard;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAccursedHoardSensedMessages, ref showSenseAccursedHoard))
        {
            configuration.ShowSenseAccursedHoard = showSenseAccursedHoard;
            configuration.OnSettingChanged();
        }

        var showDoNotSenseAccursedHoard = configuration.ShowDoNotSenseAccursedHoard;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAccursedHoardNotSensedMessages,
                ref showDoNotSenseAccursedHoard))
        {
            configuration.ShowDoNotSenseAccursedHoard = showDoNotSenseAccursedHoard;
            configuration.OnSettingChanged();
        }

        var showDiscoverAccursedHoard = configuration.ShowDiscoverAccursedHoard;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAccursedHoardDiscoveredMessages,
                ref showDiscoverAccursedHoard))
        {
            configuration.ShowDiscoverAccursedHoard = showDiscoverAccursedHoard;
            configuration.OnSettingChanged();
        }
    }
}
