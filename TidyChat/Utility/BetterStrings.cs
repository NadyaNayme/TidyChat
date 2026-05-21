using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Timers;
using ChatTwo.Code;
using Dalamud.Game;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using TextCopy;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat.Utility;

internal static class BetterStrings
{
    public static SeString SayReminder(SeString message, Configuration configuration)
    {
        // With the chat mode in Say, enter a phrase containing "Capture this"

        int containingPhraseStart = message.TextValue.LastIndexOf(L10N.GetTidy(TidyStrings.StartQuotation), StringComparison.Ordinal);
        int containingPhraseEnd = message.TextValue.LastIndexOf(L10N.GetTidy(TidyStrings.EndQuotation), StringComparison.Ordinal);
        int lengthOfPhrase = containingPhraseEnd - containingPhraseStart;
        string containingPhrase = message.TextValue.Substring(containingPhraseStart + 1, lengthOfPhrase - 1);
        if (configuration.CopyBetterSayReminder)
        {
            var stringBuilder = new SeStringBuilder();
            if (configuration.IncludeChatTag) AddTidyChatTag(stringBuilder);
            stringBuilder.AddText($"\"/say {containingPhrase}\" {L10N.GetTidy(TidyStrings.CopiedToClipboard)}");
            ClipboardService.SetText($"/say {containingPhrase}");
            return stringBuilder.BuiltString;
        }

        return $"/say {containingPhrase}";
    }

    public unsafe static SeString Instances(SeString message, Configuration configuration)
    {
        try
        {
            UIState* uiState = UIState.Instance();
            if (uiState == null) return "";

            // This will return the instance value: 0,1,2,3,4,5,6
            int InstanceNumberFromSignature = (int)uiState->PublicInstance.InstanceId;
            string instanceCharacter = ((char)(SeIconChar.Instance1 + (byte)(InstanceNumberFromSignature - 1))).ToString();
            var stringBuilder = new SeStringBuilder();
            if (configuration.IncludeChatTag) AddTidyChatTag(stringBuilder);
            stringBuilder.AddText($"{L10N.GetTidy(TidyStrings.InstanceText)} {instanceCharacter}");
            return stringBuilder.BuiltString;
        }
        catch
        {
            // Nah
        }
        return "";
    }

    /// <summary>
    ///     Builds the compact "You've joined the Novice Network." replacement message.
    ///     Used by <c>OnLogMessage</c> after suppressing the original multi-line join LogMessage (ID 7027).
    /// </summary>
    public static SeString NoviceNetworkJoinMessage(Configuration configuration)
    {
        SeString newMessage = L10N.Language switch
        {
            ClientLanguage.Japanese => "ビギナーチャンネルに参加しました。",
            ClientLanguage.English => "You've joined the Novice Network.",
            ClientLanguage.German => "Du bist dem Neulings-Chat beigetreten.",
            ClientLanguage.French => "Vous avez rejoint le réseau des novices.",
            _ => "You've joined the Novice Network."
        };
        var stringBuilder = new SeStringBuilder();
        if (configuration.IncludeChatTag) AddTidyChatTag(stringBuilder);
        stringBuilder.AddText($"{newMessage}");
        return stringBuilder.BuiltString;
    }

    /// <summary>
    ///     Builds the compact "You've left the Novice Network." replacement message.
    ///     Used by <c>OnLogMessage</c> after suppressing the original leave LogMessage (ID 7030).
    /// </summary>
    public static SeString NoviceNetworkLeaveMessage(Configuration configuration)
    {
        SeString newMessage = L10N.Language switch
        {
            ClientLanguage.Japanese => "ビギナーチャンネルから退出しました。",
            ClientLanguage.English => "You've left the Novice Network.",
            ClientLanguage.German => "Du hast den Neulings-Chat verlassen.",
            ClientLanguage.French => "Vous avez quitté le réseau des novices.",
            _ => "You've left the Novice Network."
        };
        var stringBuilder = new SeStringBuilder();
        if (configuration.IncludeChatTag) AddTidyChatTag(stringBuilder);
        stringBuilder.AddText($"{newMessage}");
        return stringBuilder.BuiltString;
    }

    public static SeString TreasureDungeon(Configuration configuration)
    {
        string chamber = TidyStrings.LastTreasureDungeonChamber;
        var stringBuilder = new SeStringBuilder();
        if (configuration.IncludeChatTag) AddTidyChatTag(stringBuilder);
        stringBuilder.AddText(string.Format(CultureInfo.CurrentCulture, L10N.GetTidy(TidyStrings.KickedOutMessage), chamber));
        return stringBuilder.BuiltString;
    }

    public static void TemporarilyDisableSystemFilter(Configuration configuration)
    {
        configuration.FilterSystemMessages = false;
        var t = new Timer
        {
            Interval = 1000,
            AutoReset = false
        };
        t.Elapsed += delegate
        {
            t.Enabled = false;
            t.Dispose();
            configuration.FilterSystemMessages = true;
        };
        t.Enabled = true;
    }

    /// <summary>
    ///     This method takes <paramref name="sestring" /> and adds a red "[TidyChat] " tag text to it
    /// </summary>
    /// <param name="sestring">An empty SeStringBuilder()</param>
    /// <returns>SeString with text: "[TidyChat] "</returns>
    public static SeStringBuilder AddTidyChatTag(SeStringBuilder sestring)
    {
        sestring.AddUiForeground(14);
        sestring.AddText(TidyStrings.Tag);
        sestring.AddUiForegroundOff();
        return sestring;
    }

    /// <summary>
    ///     This method takes <paramref name="sestring" /> and adds a yellow "[Channel] " tag text to it
    /// </summary>
    /// <param name="sestring">An empty SeStringBuilder()</param>
    /// <returns>SeString with text: "[Channel] "</returns>
    public static SeStringBuilder AddChannelTag(SeStringBuilder sestring, ChatType channel)
    {
        sestring.AddUiForeground(8);
        sestring.AddText($"[{channel}] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }

    /// <summary>
    ///     This method takes <paramref name="sestring" /> and adds a purple "[Rule] " tag text to it
    /// </summary>
    /// <param name="sestring">An empty SeStringBuilder()</param>
    /// <returns>SeString with text: "[Rule] "</returns>
    public static SeStringBuilder AddRuleTag(SeStringBuilder sestring, List<string> rulesMatched)
    {
        sestring.AddUiForeground(9);
        sestring.AddText($"[{string.Join(", ", rulesMatched)}] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }

    /// <summary>
    ///     This method takes <paramref name="sestring" /> and adds a red "[BLOCKED] " tag text to it
    /// </summary>
    /// <param name="sestring">An empty SeStringBuilder()</param>
    /// <returns>SeString with text: "[Rule] "</returns>
    public static SeStringBuilder AddBlockedTag(SeStringBuilder sestring)
    {
        sestring.AddUiForeground(8);
        sestring.AddText("[Blocked] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }

    /// <summary>
    ///     This method takes <paramref name="sestring" /> and adds a purple "[ALLOWED] " tag text to it
    /// </summary>
    /// <param name="sestring">An empty SeStringBuilder()</param>
    /// <returns>SeString with text: "[Rule] "</returns>
    public static SeStringBuilder AddAllowedTag(SeStringBuilder sestring)
    {
        sestring.AddUiForeground(9);
        sestring.AddText("[Allowed] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }
}
