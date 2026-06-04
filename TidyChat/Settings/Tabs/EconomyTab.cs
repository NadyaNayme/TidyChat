namespace TidyChat.Settings.Tabs;

internal static class EconomyTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.EconomyTab_TradingSectionHeader, ImGuiTreeNodeFlags.DefaultOpen))
        {
            bool showTradeSent = configuration.ShowTradeSent;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeRequestSent, ref showTradeSent))
            {
                configuration.ShowTradeSent = showTradeSent;
                configuration.OnSettingChanged();
            }

            bool showTradeCanceled = configuration.ShowTradeCanceled;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeCanceled, ref showTradeCanceled))
            {
                configuration.ShowTradeCanceled = showTradeCanceled;
                configuration.OnSettingChanged();
            }

            bool showAwaitingTradeConfirmation = configuration.ShowAwaitingTradeConfirmation;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeAwaitingConfirmation, ref showAwaitingTradeConfirmation))
            {
                configuration.ShowAwaitingTradeConfirmation = showAwaitingTradeConfirmation;
                configuration.OnSettingChanged();
            }

            bool showTradeComplete = configuration.ShowTradeComplete;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowTradeComplete, ref showTradeComplete))
            {
                configuration.ShowTradeComplete = showTradeComplete;
                configuration.OnSettingChanged();
            }
        }

        if (ImGui.CollapsingHeader(Languages.EconomyTab_VendorSectionHeader))
        {
            bool showVendorSellMessages = configuration.ShowVendorSellMessages;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowVendorSellMessages, ref showVendorSellMessages))
            {
                configuration.ShowVendorSellMessages = showVendorSellMessages;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowVendorSellMessagesHelpMarker);

            bool showVendorPurchaseMessages = configuration.ShowVendorPurchaseMessages;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowVendorPurchaseMessages, ref showVendorPurchaseMessages))
            {
                configuration.ShowVendorPurchaseMessages = showVendorPurchaseMessages;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowVendorPurchaseMessagesHelpMarker);

            bool showGilWithdrawnMessage = configuration.ShowGilWithdrawnMessage;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowGilWithdrawnMessage, ref showGilWithdrawnMessage))
            {
                configuration.ShowGilWithdrawnMessage = showGilWithdrawnMessage;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowGilWithdrawnMessageHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.EconomyTab_MarketBoardSectionHeader))
        {
            bool showMarketBoardMessages = configuration.ShowMarketBoardMessages;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowMarketBoardMessages, ref showMarketBoardMessages))
            {
                configuration.ShowMarketBoardMessages = showMarketBoardMessages;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowMarketBoardMessagesHelpMarker);

            SettingsTabLayout.DrawNestedOptions(configuration.ShowMarketBoardMessages, () =>
            {
                bool showMarketItemSold = configuration.ShowMarketItemSold;
                if (ImGui.Checkbox(Languages.EconomyTab_ShowMarketItemSold, ref showMarketItemSold))
                {
                    configuration.ShowMarketItemSold = showMarketItemSold;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowMarketItemSoldHelpMarker);

                bool showMarketAllItemsSold = configuration.ShowMarketAllItemsSold;
                if (ImGui.Checkbox(Languages.EconomyTab_ShowMarketAllItemsSold, ref showMarketAllItemsSold))
                {
                    configuration.ShowMarketAllItemsSold = showMarketAllItemsSold;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowMarketAllItemsSoldHelpMarker);

                bool showMarketBoardSellingStatus = configuration.ShowMarketBoardSellingStatus;
                if (ImGui.Checkbox(Languages.EconomyTab_ShowMarketBoardSellingStatus, ref showMarketBoardSellingStatus))
                {
                    configuration.ShowMarketBoardSellingStatus = showMarketBoardSellingStatus;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowMarketBoardSellingStatusHelpMarker);
            });

            SettingsTabLayout.DrawIndependentOptions(() =>
            {
                bool showMarketGilEntrusted = configuration.ShowMarketGilEntrustedToRetainer;
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
            bool showGilSpentMessage = configuration.ShowGilSpentMessage;
            if (ImGui.Checkbox(Languages.EconomyTab_ShowGilSpentMessage, ref showGilSpentMessage))
            {
                configuration.ShowGilSpentMessage = showGilSpentMessage;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.EconomyTab_ShowGilSpentMessageHelpMarker);
        }
    }
}
