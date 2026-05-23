using System;
using ChatTwo.Code;
namespace TidyChat.Utility;

public static class ChatFlags
{
    [Flags]
    public enum Channels
    {
        None = 0,
        Debug = 1 << 0, // Debug
        Emotes = 1 << 1, // StandardEmote & CustomEmote

        PlayerChannels =
            1 << 2, // Say, Shout, Yell, Linkshells, Tells, Echo, Crossworld Linkshells, Party, CrossParty, PvpTeam, NoviceNetwork
        System = 1 << 3, // System
        Progress = 1 << 4, // Progress
        Loot = 1 << 5, // LootNotice
        Obtain = 1 << 6, // LootRoll
        FreeCompany = 1 << 7, // FreeCompanyLoginLogout
        Crafting = 1 << 8, // Crafting
        Gathering = 1 << 9 // Gathering
    }

    public static bool CheckFlags(PlayerName player, ChatType chatType)
        => CheckChannelFlags((Channels)player.WhitelistedChannels, chatType, includeFreeCompanyChat: true);

    public static bool CheckFlags(Configuration configuration, ChatType chatType)
        => CheckChannelFlags((Channels)configuration.ChatHistoryChannels, chatType, includeFreeCompanyChat: true);

    private static bool CheckChannelFlags(Channels channels, ChatType chatType, bool includeFreeCompanyChat)
    {
        if (channels.HasFlag(Channels.Debug) && chatType is ChatType.Debug) return true;
        if (channels.HasFlag(Channels.Emotes) &&
            chatType is ChatType.StandardEmote or ChatType.CustomEmote) return true;
        if (channels.HasFlag(Channels.PlayerChannels) &&
            chatType is ChatType.Say or ChatType.Shout or ChatType.Yell or
                        ChatType.Echo or ChatType.TellIncoming or ChatType.TellOutgoing or
                        ChatType.Linkshell1 or ChatType.Linkshell2 or ChatType.Linkshell3 or
                        ChatType.Linkshell4 or ChatType.Linkshell5 or ChatType.Linkshell6 or
                        ChatType.Linkshell7 or ChatType.Linkshell8 or
                        ChatType.CrossLinkshell1 or ChatType.CrossLinkshell2 or ChatType.CrossLinkshell3 or
                        ChatType.CrossLinkshell4 or ChatType.CrossLinkshell5 or ChatType.CrossLinkshell6 or
                        ChatType.CrossLinkshell7 or ChatType.CrossLinkshell8 or
                        ChatType.Party or ChatType.CrossParty or ChatType.FreeCompany)
            return true;
        if (channels.HasFlag(Channels.System) && chatType is ChatType.System) return true;
        if (channels.HasFlag(Channels.Progress) && chatType is ChatType.Progress) return true;
        if (channels.HasFlag(Channels.Loot) && chatType is ChatType.LootNotice) return true;
        if (channels.HasFlag(Channels.Obtain) && chatType is ChatType.LootRoll) return true;
        if (channels.HasFlag(Channels.FreeCompany) &&
            chatType is ChatType.FreeCompany or ChatType.FreeCompanyLoginLogout) return true;
        if (channels.HasFlag(Channels.Crafting) && chatType is ChatType.Crafting) return true;
        if (channels.HasFlag(Channels.Gathering) &&
            chatType is ChatType.GatheringSystem or ChatType.Gathering) return true;
        return false;
    }
}
