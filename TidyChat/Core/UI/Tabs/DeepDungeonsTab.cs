namespace TidyChat.Settings.Tabs;

internal static class DeepDungeonsTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.DeepDungeonsTab_FilteringNote);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterSystemMessages, Languages.GeneralTab_FilterSystemSpam);

        SettingsTabLayout.DrawSections(true,
            (Languages.DeepDungeonsTab_DeepDungeonsDropdownHeader, () => DrawDeepDungeonOptions(configuration)));
    }

    private static void DrawDeepDungeonOptions(Configuration configuration)
    {
        var showCairnGlows = configuration.ShowCairnGlows;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowCairnOfPassageGlowsMessages, ref showCairnGlows))
        {
            configuration.ShowCairnGlows = showCairnGlows;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowCairnOfPassageGlowsMessagesHelpMarker);

        var showRestoresLifeToFallen = configuration.ShowRestoresLifeToFallen;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowCairnOfReturnUsedMessages, ref showRestoresLifeToFallen))
        {
            configuration.ShowRestoresLifeToFallen = showRestoresLifeToFallen;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowCairnOfReturnUsedMessagesHelpMarker);

        var showCairnActivates = configuration.ShowCairnActivates;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowCairnOfPassageActivatedMessages, ref showCairnActivates))
        {
            configuration.ShowCairnActivates = showCairnActivates;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowCairnOfPassageActivatedMessagesHelpMarker);

        var showTransference = configuration.ShowTransference;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowTransferenceMessages, ref showTransference))
        {
            configuration.ShowTransference = showTransference;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowTransferenceMessagesHelpMarker);

        var showAetherpoolIncrease = configuration.ShowAetherpoolIncrease;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowAetherpoolIncreasesMessages, ref showAetherpoolIncrease))
        {
            configuration.ShowAetherpoolIncrease = showAetherpoolIncrease;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowAetherpoolIncreasesMessagesHelpMarker);

        var showAetherpoolUnchanged = configuration.ShowAetherpoolUnchanged;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowAetherpoolRemainsUnchangedMessages,
                ref showAetherpoolUnchanged))
        {
            configuration.ShowAetherpoolUnchanged = showAetherpoolUnchanged;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowAetherpoolRemainsUnchangedMessagesHelpMarker);

        var showObtainedPomander = configuration.ShowObtainedPomander;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowObtainedPomanderMessages, ref showObtainedPomander))
        {
            configuration.ShowObtainedPomander = showObtainedPomander;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowObtainedPomanderMessagesHelpMarker);

        var showTrapTriggered = configuration.ShowTrapTriggered;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowTrapTriggeredMessages, ref showTrapTriggered))
        {
            configuration.ShowTrapTriggered = showTrapTriggered;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowTrapTriggeredMessagesHelpMarker);

        var showPomanderEffects = configuration.ShowPomanderEffects;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowPomanderEffectsMessages, ref showPomanderEffects))
        {
            configuration.ShowPomanderEffects = showPomanderEffects;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowPomanderEffectsMessagesHelpMarker);

        var showFloorNumber = configuration.ShowFloorNumber;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowFloorNumberMessages, ref showFloorNumber))
        {
            configuration.ShowFloorNumber = showFloorNumber;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowFloorNumberMessagesHelpMarker);

        var showSenseAccursedHoard = configuration.ShowSenseAccursedHoard;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowAccursedHoardSensedMessages, ref showSenseAccursedHoard))
        {
            configuration.ShowSenseAccursedHoard = showSenseAccursedHoard;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowAccursedHoardSensedMessagesHelpMarker);

        var showDoNotSenseAccursedHoard = configuration.ShowDoNotSenseAccursedHoard;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowAccursedHoardNotSensedMessages,
                ref showDoNotSenseAccursedHoard))
        {
            configuration.ShowDoNotSenseAccursedHoard = showDoNotSenseAccursedHoard;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowAccursedHoardNotSensedMessagesHelpMarker);

        var showDiscoverAccursedHoard = configuration.ShowDiscoverAccursedHoard;
        if (ImGui.Checkbox(Languages.DeepDungeonsTab_ShowAccursedHoardDiscoveredMessages,
                ref showDiscoverAccursedHoard))
        {
            configuration.ShowDiscoverAccursedHoard = showDiscoverAccursedHoard;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DeepDungeonsTab_ShowAccursedHoardDiscoveredMessagesHelpMarker);
    }
}
