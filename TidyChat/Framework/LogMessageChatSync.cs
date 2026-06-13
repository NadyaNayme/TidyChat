namespace TidyChat.Utility;

internal static class LogMessageChatSync
{
    internal const uint InventoryItemAddedLogMessageId = 789;

    /// <summary>
    ///     Only LogMessage-sheet channels may inherit OnLogMessage allow/block decisions on OnChat.
    ///     Default is false so player chat and unknown channels never pick up blocks by text collision.
    /// </summary>
    internal static bool ParticipatesInLogMessageChatSync(ChatType chatType) => chatType switch
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

    internal static bool StrictCatalogMatch(uint logMessageId, string normalizedText) =>
        LogMessageCatalog.IsLoaded &&
        LogMessageCatalog.HasTemplate(logMessageId) &&
        LogMessageCatalog.Matches(logMessageId, normalizedText);

    internal static bool MatchesInventoryAddedLine(string normalizedText) =>
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.InventoryItemAdded);
}
