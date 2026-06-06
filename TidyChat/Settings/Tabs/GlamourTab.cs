namespace TidyChat.Settings.Tabs;



internal static class GlamourTab

{

    public static void Draw(Configuration configuration)

    {

        SettingsTabLayout.DrawTabNote(Languages.GlamourTab_FilteringNote);



        var showGlamourDresser = configuration.ShowGlamourDresserMessages;

        if (ImGui.Checkbox(Languages.GlamourTab_ShowGlamourDresserMessages, ref showGlamourDresser))

        {

            configuration.ShowGlamourDresserMessages = showGlamourDresser;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.GlamourTab_ShowGlamourDresserMessagesHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowGlamourDresserMessages,

            () => DrawGlamourDresserSubOptions(configuration));



        var showTryOnGlamour = configuration.ShowTryOnGlamour;

        if (ImGui.Checkbox(Languages.GlamourTab_ShowTryOnEquipGlamourMessages, ref showTryOnGlamour))

        {

            configuration.ShowTryOnGlamour = showTryOnGlamour;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.GlamourTab_ShowTryOnEquipGlamourMessagesHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowTryOnGlamour,

            () => DrawTryOnEquipSubOptions(configuration));



        SettingsTabLayout.DrawIndependentOptions(() =>

        {

            var showSpiritboundGear = configuration.ShowSpiritboundGear;

            if (ImGui.Checkbox(Languages.SystemTab_ShowSpiritboundMessages, ref showSpiritboundGear))

            {

                configuration.ShowSpiritboundGear = showSpiritboundGear;

                configuration.OnSettingChanged();

            }



            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSpiritboundMessagesHelpMarker);

        });



        var showGearsetEquipped = configuration.ShowGearsetEquipped;

        if (ImGui.Checkbox(Languages.SystemTab_ShowGearsetChangingMessages, ref showGearsetEquipped))

        {

            configuration.ShowGearsetEquipped = showGearsetEquipped;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGearsetChangingMessagesHelpMarker);



        var showGearItemsRepaired = configuration.ShowGearItemsRepaired;

        if (ImGui.Checkbox(Languages.SystemTab_ShowGearItemsRepaired, ref showGearItemsRepaired))

        {

            configuration.ShowGearItemsRepaired = showGearItemsRepaired;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGearItemsRepairedHelpMarker);



        var showJobChange = configuration.ShowJobChange;

        if (ImGui.Checkbox(Languages.SystemTab_ShowJobChangeMessages, ref showJobChange))

        {

            configuration.ShowJobChange = showJobChange;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowJobChangeMessagesHelpMarker);



        var showPortraitMessages = configuration.ShowPortraitMessages;

        if (ImGui.Checkbox(Languages.SystemTab_ShowPortraitMessages, ref showPortraitMessages))

        {

            configuration.ShowPortraitMessages = showPortraitMessages;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowPortraitMessagesHelpMarker);

    }



    private static void DrawGlamourDresserSubOptions(Configuration configuration)

    {

        var showDresserOutfit = configuration.ShowGlamourDresserOutfit;

        if (ImGui.Checkbox(Languages.GlamourTab_ShowGlamourDresserOutfit, ref showDresserOutfit))

        {

            configuration.ShowGlamourDresserOutfit = showDresserOutfit;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.GlamourTab_ShowGlamourDresserOutfitHelpMarker);



        var showDresserProjection = configuration.ShowGlamourDresserProjection;

        if (ImGui.Checkbox(Languages.GlamourTab_ShowGlamourDresserProjection, ref showDresserProjection))

        {

            configuration.ShowGlamourDresserProjection = showDresserProjection;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.GlamourTab_ShowGlamourDresserProjectionHelpMarker);



        var showArmoire = configuration.ShowGlamourArmoireMessages;

        if (ImGui.Checkbox(Languages.GlamourTab_ShowGlamourArmoireMessages, ref showArmoire))

        {

            configuration.ShowGlamourArmoireMessages = showArmoire;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.GlamourTab_ShowGlamourArmoireMessagesHelpMarker);

    }



    private static void DrawTryOnEquipSubOptions(Configuration configuration)

    {

        var showTryOnPreview = configuration.ShowTryOnGlamourPreview;

        if (ImGui.Checkbox(Languages.GlamourTab_ShowTryOnGlamourPreview, ref showTryOnPreview))

        {

            configuration.ShowTryOnGlamourPreview = showTryOnPreview;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.GlamourTab_ShowTryOnGlamourPreviewHelpMarker);



        var showTryOnCast = configuration.ShowTryOnGlamourCast;

        if (ImGui.Checkbox(Languages.SystemTab_ShowTryOnGlamourCast, ref showTryOnCast))

        {

            configuration.ShowTryOnGlamourCast = showTryOnCast;

            configuration.OnSettingChanged();

        }



        UiHelp.StandaloneHideFilterMarker(Languages.SystemTab_ShowTryOnGlamourCastHelpMarker);



        var showPlateProjected = configuration.ShowGlamourPlateProjected;

        if (ImGui.Checkbox(Languages.SystemTab_ShowGlamourPlateProjected, ref showPlateProjected))

        {

            configuration.ShowGlamourPlateProjected = showPlateProjected;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGlamourPlateProjectedHelpMarker);



        var showPartialApply = configuration.ShowGlamourPlatePartialApply;

        if (ImGui.Checkbox(Languages.SystemTab_ShowGlamourPlatePartialApply, ref showPartialApply))

        {

            configuration.ShowGlamourPlatePartialApply = showPartialApply;

            configuration.OnSettingChanged();

        }



        UiHelp.StandaloneHideFilterMarker(Languages.SystemTab_ShowGlamourPlatePartialApplyHelpMarker);



        var showGearDye = configuration.ShowGearDyeApplied;

        if (ImGui.Checkbox(Languages.SystemTab_ShowGearDyeApplied, ref showGearDye))

        {

            configuration.ShowGearDyeApplied = showGearDye;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGearDyeAppliedHelpMarker);



        var showRestoreFailed = configuration.ShowGearsetGlamourRestoreFailed;

        if (ImGui.Checkbox(Languages.SystemTab_ShowGearsetGlamourRestoreFailed, ref showRestoreFailed))

        {

            configuration.ShowGearsetGlamourRestoreFailed = showRestoreFailed;

            configuration.OnSettingChanged();

        }



        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGearsetGlamourRestoreFailedHelpMarker);

    }

}


