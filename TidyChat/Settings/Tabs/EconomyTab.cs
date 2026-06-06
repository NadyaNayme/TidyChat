namespace TidyChat.Settings.Tabs;

internal static class EconomyTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.EconomyTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.EconomyTab_TradingSectionHeader, () => DrawTrading(configuration)),
            (Languages.EconomyTab_VendorSectionHeader, () => DrawVendor(configuration)),
            (Languages.EconomyTab_MarketBoardSectionHeader, () => DrawMarketBoard(configuration)),
            (Languages.EconomyTab_RetainerSectionHeader, () => DrawRetainer(configuration)),
            (Languages.EconomyTab_GilSectionHeader, () => DrawGil(configuration)));
    }

    private static void DrawTrading(Configuration configuration)
    {
        var showTradeSent = configuration.ShowTradeSent;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeRequestSent, ref showTradeSent))
        {
            configuration.ShowTradeSent = showTradeSent;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowTradeRequestSentHelpMarker);

        var showTradeCanceled = configuration.ShowTradeCanceled;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeCanceled, ref showTradeCanceled))
        {
            configuration.ShowTradeCanceled = showTradeCanceled;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowTradeCanceledHelpMarker);

        var showAwaitingTradeConfirmation = configuration.ShowAwaitingTradeConfirmation;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeAwaitingConfirmation, ref showAwaitingTradeConfirmation))
        {
            configuration.ShowAwaitingTradeConfirmation = showAwaitingTradeConfirmation;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowTradeAwaitingConfirmationHelpMarker);

        var showTradeComplete = configuration.ShowTradeComplete;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeComplete, ref showTradeComplete))
        {
            configuration.ShowTradeComplete = showTradeComplete;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowTradeCompleteHelpMarker);
    }

    private static void DrawVendor(Configuration configuration)
    {
        var showVendorSellMessages = configuration.ShowVendorSellMessages;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowVendorSellMessages, ref showVendorSellMessages))
        {
            configuration.ShowVendorSellMessages = showVendorSellMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowVendorSellMessagesHelpMarker);

        var showVendorPurchaseMessages = configuration.ShowVendorPurchaseMessages;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowVendorPurchaseMessages, ref showVendorPurchaseMessages))
        {
            configuration.ShowVendorPurchaseMessages = showVendorPurchaseMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowVendorPurchaseMessagesHelpMarker);

        var showGilWithdrawnMessage = configuration.ShowGilWithdrawnMessage;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowGilWithdrawnMessage, ref showGilWithdrawnMessage))
        {
            configuration.ShowGilWithdrawnMessage = showGilWithdrawnMessage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowGilWithdrawnMessageHelpMarker);
    }

    private static void DrawMarketBoard(Configuration configuration)
    {
        var showMarketBoardMessages = configuration.ShowMarketBoardMessages;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowMarketBoardMessages, ref showMarketBoardMessages))
        {
            configuration.ShowMarketBoardMessages = showMarketBoardMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowMarketBoardMessagesHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowMarketBoardMessages, () =>
        {
            var showMarketItemSold = configuration.ShowMarketItemSold;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowMarketItemSold, ref showMarketItemSold))
            {
                configuration.ShowMarketItemSold = showMarketItemSold;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowMarketItemSoldHelpMarker);

            var showMarketAllItemsSold = configuration.ShowMarketAllItemsSold;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowMarketAllItemsSold, ref showMarketAllItemsSold))
            {
                configuration.ShowMarketAllItemsSold = showMarketAllItemsSold;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowMarketAllItemsSoldHelpMarker);

            var showMarketBoardSellingStatus = configuration.ShowMarketBoardSellingStatus;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowMarketBoardSellingStatus, ref showMarketBoardSellingStatus))
            {
                configuration.ShowMarketBoardSellingStatus = showMarketBoardSellingStatus;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowMarketBoardSellingStatusHelpMarker);
        });
    }

    private static void DrawRetainer(Configuration configuration)
    {
        var completedVenture = configuration.ShowCompletedVenture;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowCompletedVenture, ref completedVenture))
        {
            configuration.ShowCompletedVenture = completedVenture;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowCompletedVentureHelpMarker);

        var retainerVentureMessages = configuration.ShowRetainerVentureMessages;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowRetainerVentureMessages, ref retainerVentureMessages))
        {
            configuration.ShowRetainerVentureMessages = retainerVentureMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowRetainerVentureMessagesHelpMarker);

        var showMarketGilEntrusted = configuration.ShowMarketGilEntrustedToRetainer;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowMarketGilEntrustedToRetainer, ref showMarketGilEntrusted))
        {
            configuration.ShowMarketGilEntrustedToRetainer = showMarketGilEntrusted;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowMarketGilEntrustedToRetainerHelpMarker);
    }

    private static void DrawGil(Configuration configuration)
    {
        var showGilSpentMessage = configuration.ShowGilSpentMessage;
        if (ImGui.Checkbox(Languages.EconomyTab_ShowGilSpentMessage, ref showGilSpentMessage))
        {
            configuration.ShowGilSpentMessage = showGilSpentMessage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowGilSpentMessageHelpMarker);
    }
}
