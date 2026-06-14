namespace TidyChat.Utility;

internal static class LogMessageHelper
{
    internal const uint InventoryItemAddedLogMessageId = 789;

    internal static bool TryExtractText(ILogMessage message, out string text)
    {
        text = string.Empty;
        if (message is null || message.LogMessageId == 0)
        {
            return false;
        }

        if (message.Address == nint.Zero)
        {
            return false;
        }

        if (message.ParameterCount == 0 &&
            LogMessageCatalog.TryGetTemplateText(message.LogMessageId, out var staticTemplate))
        {
            text = staticTemplate;
            return text.Length > 0;
        }

        if (LogMessageCatalog.IsRuntimeOnly(message.LogMessageId) ||
            !AreLogMessageParametersReadable(message))
        {
            return false;
        }

        return TryFormatLogMessageUnsafe(message, out text);
    }

    internal static bool TryExtractNormalizedText(ILogMessage message, out string normalizedText)
    {
        normalizedText = string.Empty;
        if (!TryExtractText(message, out var text))
        {
            return false;
        }

        normalizedText = text.ToLower(CultureInfo.CurrentCulture);
        return normalizedText.Length > 0;
    }

    internal static bool IsPlayerAuthoredChannel(ChatType chatType) => chatType switch
    {
        ChatType.Say or
            ChatType.Shout or
            ChatType.Yell or
            ChatType.TellIncoming or
            ChatType.TellOutgoing or
            ChatType.Party or
            ChatType.CrossParty or
            ChatType.Alliance or
            ChatType.FreeCompany or
            ChatType.NoviceNetwork or
            ChatType.PvpTeam or
            ChatType.CustomEmote or
            ChatType.Linkshell1 or
            ChatType.Linkshell2 or
            ChatType.Linkshell3 or
            ChatType.Linkshell4 or
            ChatType.Linkshell5 or
            ChatType.Linkshell6 or
            ChatType.Linkshell7 or
            ChatType.Linkshell8 or
            ChatType.CrossLinkshell1 or
            ChatType.CrossLinkshell2 or
            ChatType.CrossLinkshell3 or
            ChatType.CrossLinkshell4 or
            ChatType.CrossLinkshell5 or
            ChatType.CrossLinkshell6 or
            ChatType.CrossLinkshell7 or
            ChatType.CrossLinkshell8 or
            ChatType.GmTell or
            ChatType.GmSay or
            ChatType.GmShout or
            ChatType.GmYell or
            ChatType.GmParty or
            ChatType.GmFreeCompany or
            ChatType.GmNoviceNetwork or
            ChatType.GmLinkshell1 or
            ChatType.GmLinkshell2 or
            ChatType.GmLinkshell3 or
            ChatType.GmLinkshell4 or
            ChatType.GmLinkshell5 or
            ChatType.GmLinkshell6 or
            ChatType.GmLinkshell7 or
            ChatType.GmLinkshell8 => true,
        _ => false
    };

    /// <summary>
    ///     Only LogMessage-sheet channels may inherit OnLogMessage allow/block decisions on OnChat.
    ///     Player-authored channels are always excluded so token collisions cannot hide say/party/tell.
    /// </summary>
    internal static bool ParticipatesInLogMessageChatSync(ChatType chatType)
    {
        if (IsPlayerAuthoredChannel(chatType))
        {
            return false;
        }

        return chatType switch
        {
            ChatType.System or
                ChatType.RetainerSale or
                ChatType.StandardEmote or
                ChatType.Crafting or
                ChatType.Gathering or
                ChatType.GatheringSystem or
                ChatType.LootNotice or
                ChatType.LootRoll or
                ChatType.Progress or
                ChatType.FreeCompanyLoginLogout or
                ChatType.GlamourNotifications or
                ChatType.BattleSystem or
                ChatType.Echo or
                ChatType.Item or
                ChatType.Action or
                ChatType.Damage or
                ChatType.Miss or
                ChatType.Healing or
                ChatType.GainBuff or
                ChatType.GainDebuff or
                ChatType.LoseBuff or
                ChatType.LoseDebuff or
                ChatType.Error or
                ChatType.NpcDialogue or
                ChatType.NpcAnnouncement or
                ChatType.FreeCompanyAnnouncement or
                ChatType.MessageBook or
                ChatType.NoviceNetworkSystem or
                ChatType.PeriodicRecruitmentNotification or
                ChatType.Orchestrion or
                ChatType.PvpTeamAnnouncement or
                ChatType.PvpTeamLoginLogout or
                ChatType.Urgent or
                ChatType.Notice or
                ChatType.Alarm or
                ChatType.Sign or
                ChatType.RandomNumber or
                ChatType.Debug => true,
            _ => false
        };
    }

    internal static bool StrictCatalogMatch(uint logMessageId, string normalizedText) =>
        LogMessageCatalog.IsLoaded &&
        LogMessageCatalog.HasTemplate(logMessageId) &&
        LogMessageCatalog.Matches(logMessageId, normalizedText);

    internal static bool PendingTextMatchesOnChannel(uint logMessageId, ChatType chatType, string normalizedText)
    {
        if (IsPlayerAuthoredChannel(chatType))
        {
            return false;
        }

        if (LogMessageCatalog.GetChatTypeForId(logMessageId) is ChatType sheetChannel &&
            sheetChannel != chatType &&
            chatType is not ChatType.Echo)
        {
            return false;
        }

        return StrictCatalogMatch(logMessageId, normalizedText);
    }

    internal static bool MatchesInventoryAddedLine(string normalizedText) =>
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.InventoryItemAdded);

    private static bool AreLogMessageParametersReadable(ILogMessage message)
    {
        var count = message.ParameterCount;
        if (count <= 0)
        {
            return true;
        }

        for (var i = 0; i < count; i++)
        {
            if (message.TryGetIntParameter(i, out _))
            {
                continue;
            }

            if (!message.TryGetStringParameter(i, out var stringParameter))
            {
                return false;
            }

            try
            {
                _ = stringParameter.ExtractText();
            }
            catch
            {
                return false;
            }
        }

        return true;
    }

    private static bool TryFormatLogMessageUnsafe(ILogMessage message, out string text)
    {
        text = string.Empty;
        try
        {
            var formatted = message.FormatLogMessageForDebugging();
            text = formatted.ExtractText();
            return text.Length > 0;
        }
        catch
        {
            return false;
        }
    }
}
