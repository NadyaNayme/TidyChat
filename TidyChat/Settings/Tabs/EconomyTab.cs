namespace TidyChat.Settings.Tabs;

internal static class EconomyTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.EconomyTab_TradingSectionHeader, ImGuiTreeNodeFlags.DefaultOpen))
        {
            var showTradeSent = configuration.ShowTradeSent;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeRequestSent, ref showTradeSent))
            {
                configuration.ShowTradeSent = showTradeSent;
                configuration.OnSettingChanged();
            }

            var showTradeCanceled = configuration.ShowTradeCanceled;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeCanceled, ref showTradeCanceled))
            {
                configuration.ShowTradeCanceled = showTradeCanceled;
                configuration.OnSettingChanged();
            }

            var showAwaitingTradeConfirmation = configuration.ShowAwaitingTradeConfirmation;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeAwaitingConfirmation, ref showAwaitingTradeConfirmation))
            {
                configuration.ShowAwaitingTradeConfirmation = showAwaitingTradeConfirmation;
                configuration.OnSettingChanged();
            }

            var showTradeComplete = configuration.ShowTradeComplete;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeComplete, ref showTradeComplete))
            {
                configuration.ShowTradeComplete = showTradeComplete;
                configuration.OnSettingChanged();
            }
        }

        if (ImGui.CollapsingHeader(Languages.EconomyTab_VendorSectionHeader))
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

        if (ImGui.CollapsingHeader(Languages.EconomyTab_MarketBoardSectionHeader))
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

            SettingsTabLayout.DrawIndependentOptions(() =>
            {
                var showMarketGilEntrusted = configuration.ShowMarketGilEntrustedToRetainer;
                if (ImGui.Checkbox(Languages.EconomyTab_ShowMarketGilEntrustedToRetainer, ref showMarketGilEntrusted))
                {
                    configuration.ShowMarketGilEntrustedToRetainer = showMarketGilEntrusted;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowMarketGilEntrustedToRetainerHelpMarker);
            });
        }

        if (ImGui.CollapsingHeader(Languages.EconomyTab_GilSectionHeader))
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
}
