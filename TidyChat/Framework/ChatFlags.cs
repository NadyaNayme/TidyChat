namespace TidyChat.Utility;

public static class ChatFlags
{
    [Flags]
    public enum Channels
    {
        None = 0,
        Debug = 1 << 0,
        Emotes = 1 << 1,
        PlayerChannels = 1 << 2, // Say, shout, yell, tells, linkshells, party, echo
        System = 1 << 3,
        Progress = 1 << 4,
        Loot = 1 << 5,
        Obtain = 1 << 6,
        FreeCompany = 1 << 7,
        Crafting = 1 << 8,
        Gathering = 1 << 9
    }

    public static bool CheckFlags(int channelFlags, ChatType chatType)
        => CheckChannelFlags((Channels)channelFlags, chatType);

    private static bool CheckChannelFlags(Channels channels, ChatType chatType)
    {
        if (channels.HasFlag(Channels.Debug) && chatType is ChatType.Debug)
        {
            return true;
        }
        if (channels.HasFlag(Channels.Emotes) &&
            chatType is ChatType.StandardEmote or ChatType.CustomEmote)
        {
            return true;
        }
        if (channels.HasFlag(Channels.PlayerChannels) &&
            chatType is ChatType.Say or
                ChatType.Shout or
                ChatType.Yell or
                ChatType.Echo or
                ChatType.TellIncoming or
                ChatType.TellOutgoing or
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
                ChatType.Party or
                ChatType.CrossParty or
                ChatType.FreeCompany)
        {
            return true;
        }
        if (channels.HasFlag(Channels.System) && chatType is ChatType.System or ChatType.RetainerSale)
        {
            return true;
        }
        if (channels.HasFlag(Channels.Progress) && chatType is ChatType.Progress)
        {
            return true;
        }
        if (channels.HasFlag(Channels.Loot) && chatType is ChatType.LootNotice)
        {
            return true;
        }
        if (channels.HasFlag(Channels.Obtain) && chatType is ChatType.LootRoll)
        {
            return true;
        }
        if (channels.HasFlag(Channels.FreeCompany) &&
            chatType is ChatType.FreeCompany or ChatType.FreeCompanyLoginLogout)
        {
            return true;
        }
        if (channels.HasFlag(Channels.Crafting) && chatType is ChatType.Crafting)
        {
            return true;
        }
        if (channels.HasFlag(Channels.Gathering) &&
            chatType is ChatType.GatheringSystem or ChatType.Gathering)
        {
            return true;
        }
        return false;
    }
}
