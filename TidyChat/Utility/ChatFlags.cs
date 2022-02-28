using Dalamud.Game.Text;
using System;

using ChatTwo.Code;

namespace TidyChat.Utility
{
    public static class ChatFlags
    {
        [Flags]
        public enum Channels
        {
            None = 0,
            Debug = 1 << 0, // Debug
            Emotes = 1 << 1, // StandardEmote & CustomEmote
            PlayerChannels = 1 << 2, // Say, Shout, Yell, Linkshells, Tells, Echo, Crossworld Linkshells, Party, CrossParty, PvpTeam, NoviceNetwork
            System = 1 << 3, // System
            Progress = 1 << 4, // Progress
            Loot = 1 << 5, // LootNotice
            Obtain = 1 << 6, // LootRoll
            FreeCompany = 1 << 7, // FreeCompanyLoginLogout
            Crafting = 1 << 8, // Crafting
            Gathering = 1 << 9  // Gathering

        }

        public static bool CheckFlags(PlayerName player, ChatType chatType)
        {
                Channels whitelistedPlayerChannels = (Channels)player.whitelistedChannels;
                if (whitelistedPlayerChannels.HasFlag(Channels.Debug) && chatType is ChatType.Debug)
                {
                    return false;
                }
                if (whitelistedPlayerChannels.HasFlag(Channels.Emotes) && (chatType is ChatType.StandardEmote || chatType is ChatType.CustomEmote))
                {
                    return false;
                }
                if (whitelistedPlayerChannels.HasFlag(Channels.PlayerChannels) &&
                                    (chatType is ChatType.Say ||
                                    chatType is ChatType.Shout ||
                                    chatType is ChatType.Yell ||
                                    chatType is ChatType.TellIncoming ||
                                    chatType is ChatType.TellOutgoing ||
                                    chatType is ChatType.Linkshell1 ||
                                    chatType is ChatType.Linkshell2 ||
                                    chatType is ChatType.Linkshell3 ||
                                    chatType is ChatType.Linkshell4 ||
                                    chatType is ChatType.Linkshell5 ||
                                    chatType is ChatType.Linkshell6 ||
                                    chatType is ChatType.Linkshell7 ||
                                    chatType is ChatType.Linkshell8 ||
                                    chatType is ChatType.CrossLinkshell1 ||
                                    chatType is ChatType.CrossLinkshell2 ||
                                    chatType is ChatType.CrossLinkshell3 ||
                                    chatType is ChatType.CrossLinkshell4 ||
                                    chatType is ChatType.CrossLinkshell5 ||
                                    chatType is ChatType.CrossLinkshell6 ||
                                    chatType is ChatType.CrossLinkshell7 ||
                                    chatType is ChatType.CrossLinkshell8 ||
                                    chatType is ChatType.Party ||
                                    chatType is ChatType.CrossParty
                                    )
                   )
                {
                    return false;
                }
                if (whitelistedPlayerChannels.HasFlag(Channels.System) && chatType is ChatType.System)
                {
                    return false;
                }
                if (whitelistedPlayerChannels.HasFlag(Channels.Progress) && chatType is ChatType.Progress)
                {
                    return false;
                }
                if (whitelistedPlayerChannels.HasFlag(Channels.Loot) && chatType is ChatType.LootNotice)
                {
                    return false;
                }
                if (whitelistedPlayerChannels.HasFlag(Channels.Obtain) && chatType is ChatType.LootRoll)
                {
                    return false;
                }
                if (whitelistedPlayerChannels.HasFlag(Channels.FreeCompany) && (chatType is ChatType.FreeCompany || chatType is ChatType.FreeCompanyLoginLogout))
                {
                    return false;
                }
                if (whitelistedPlayerChannels.HasFlag(Channels.Crafting) && chatType is ChatType.Crafting)
                {
                    return false;
                }
                if (whitelistedPlayerChannels.HasFlag(Channels.Gathering) && chatType is ChatType.GatheringSystem)
                {
                    return false;
                }
            return true;
            }

        public static bool CheckFlags(Configuration configuration, ChatType chatType)
        {
            Channels whitelistedHistoryChannels = (Channels)configuration.ChatHistoryChannels;
            if (whitelistedHistoryChannels.HasFlag(Channels.Debug) && chatType is ChatType.Debug)
            {
                return true;
            }
            if (whitelistedHistoryChannels.HasFlag(Channels.Emotes) && (chatType is ChatType.StandardEmote || chatType is ChatType.CustomEmote))
            {
                return true;
            }
            if (whitelistedHistoryChannels.HasFlag(Channels.PlayerChannels) &&
                                (chatType is ChatType.Say ||
                                chatType is ChatType.Shout ||
                                chatType is ChatType.Yell ||
                                chatType is ChatType.TellIncoming ||
                                chatType is ChatType.TellOutgoing ||
                                chatType is ChatType.Linkshell1 ||
                                chatType is ChatType.Linkshell2 ||
                                chatType is ChatType.Linkshell3 ||
                                chatType is ChatType.Linkshell4 ||
                                chatType is ChatType.Linkshell5 ||
                                chatType is ChatType.Linkshell6 ||
                                chatType is ChatType.Linkshell7 ||
                                chatType is ChatType.Linkshell8 ||
                                chatType is ChatType.CrossLinkshell1 ||
                                chatType is ChatType.CrossLinkshell2 ||
                                chatType is ChatType.CrossLinkshell3 ||
                                chatType is ChatType.CrossLinkshell4 ||
                                chatType is ChatType.CrossLinkshell5 ||
                                chatType is ChatType.CrossLinkshell6 ||
                                chatType is ChatType.CrossLinkshell7 ||
                                chatType is ChatType.CrossLinkshell8 ||
                                chatType is ChatType.Party ||
                                chatType is ChatType.CrossParty
                                )
               )
            {
                return true;
            }
            if (whitelistedHistoryChannels.HasFlag(Channels.System) && chatType is ChatType.System)
            {
                return true;
            }
            if (whitelistedHistoryChannels.HasFlag(Channels.Progress) && chatType is ChatType.Progress)
            {
                return true;
            }
            if (whitelistedHistoryChannels.HasFlag(Channels.Loot) && chatType is ChatType.LootNotice)
            {
                return true;
            }
            if (whitelistedHistoryChannels.HasFlag(Channels.Obtain) && chatType is ChatType.LootRoll)
            {
                return true;
            }
            if (whitelistedHistoryChannels.HasFlag(Channels.FreeCompany) && (chatType is ChatType.FreeCompany || chatType is ChatType.FreeCompanyLoginLogout))
            {
                return true;
            }
            if (whitelistedHistoryChannels.HasFlag(Channels.Crafting) && chatType is ChatType.Crafting)
            {
                return true;
            }
            if (whitelistedHistoryChannels.HasFlag(Channels.Gathering) && chatType is ChatType.GatheringSystem)
            {
                return true;
            }
            return false;
        }

    }
}
