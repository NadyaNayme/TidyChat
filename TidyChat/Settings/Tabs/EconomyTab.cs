using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class EconomyTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.SystemTab_TradingDropdownHeader, ImGuiTreeNodeFlags.DefaultOpen))
        {
            bool showTradeSent = configuration.ShowTradeSent;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeRequestSentMessages, ref showTradeSent))
            {
                configuration.ShowTradeSent = showTradeSent;
                configuration.OnSettingChanged();
            }

            bool showTradeCanceled = configuration.ShowTradeCanceled;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeCanceledMessages, ref showTradeCanceled))
            {
                configuration.ShowTradeCanceled = showTradeCanceled;
                configuration.OnSettingChanged();
            }

            bool showAwaitingTradeConfirmation = configuration.ShowAwaitingTradeConfirmation;
            if (ImGui.Checkbox(Languages.SystemTab_ShowAwaitingTradeConfirmationMessages,
                    ref showAwaitingTradeConfirmation))
            {
                configuration.ShowAwaitingTradeConfirmation = showAwaitingTradeConfirmation;
                configuration.OnSettingChanged();
            }

            bool showTradeComplete = configuration.ShowTradeComplete;
            if (ImGui.Checkbox(Languages.SystemTab_ShowTradeCompleteMessages, ref showTradeComplete))
            {
                configuration.ShowTradeComplete = showTradeComplete;
                configuration.OnSettingChanged();
            }
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_VendorAndRetainerDropdownHeader))
        {
            bool showVendorSellMessages = configuration.ShowVendorSellMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowVendorSellMessages, ref showVendorSellMessages))
            {
                configuration.ShowVendorSellMessages = showVendorSellMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowVendorSellMessagesHelpMarker);

            bool showVendorPurchaseMessages = configuration.ShowVendorPurchaseMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowVendorPurchaseMessages, ref showVendorPurchaseMessages))
            {
                configuration.ShowVendorPurchaseMessages = showVendorPurchaseMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowVendorPurchaseMessagesHelpMarker);

            bool showGilWithdrawnMessage = configuration.ShowGilWithdrawnMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGilWithdrawnMessage, ref showGilWithdrawnMessage))
            {
                configuration.ShowGilWithdrawnMessage = showGilWithdrawnMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowGilWithdrawnMessageHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_MarketBoardDropdownHeader))
        {
            bool showMarketBoardMessages = configuration.ShowMarketBoardMessages;
            if (ImGui.Checkbox(Languages.SystemTab_ShowMarketBoardMessages, ref showMarketBoardMessages))
            {
                configuration.ShowMarketBoardMessages = showMarketBoardMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowMarketBoardMessagesHelpMarker);

            if (configuration.ShowMarketBoardMessages)
            {
                ImGui.Indent();
                bool betterMarketBoardSaleMessage = configuration.BetterMarketBoardSaleMessage;
                if (ImGui.Checkbox(Languages.EconomyTab_BetterMarketBoardSaleMessage, ref betterMarketBoardSaleMessage))
                {
                    configuration.BetterMarketBoardSaleMessage = betterMarketBoardSaleMessage;
                    configuration.OnSettingChanged();
                }

                ImGuiComponents.HelpMarker(Languages.EconomyTab_BetterMarketBoardSaleMessageHelpMarker);
                ImGui.Unindent();
            }
        }

        if (ImGui.CollapsingHeader(Languages.SystemTab_GilMessagesDropdownHeader))
        {
            bool showGilSpentMessage = configuration.ShowGilSpentMessage;
            if (ImGui.Checkbox(Languages.SystemTab_ShowGilSpentMessage, ref showGilSpentMessage))
            {
                configuration.ShowGilSpentMessage = showGilSpentMessage;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.SystemTab_ShowGilSpentMessageHelpMarker);
        }
    }
}
