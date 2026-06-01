using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Timers;
using Dalamud.Game;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
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

    /// <summary>
    ///     Rewrites LogMessage 748 to "[item link] sold for [gil] gil." while preserving item payloads.
    /// </summary>
    public static SeString? MarketItemSold(SeString message, Configuration configuration, string normalizedText)
    {
        Match gilMatch = L10N.Get(ChatRegexStrings.MarketItemSold).Match(normalizedText);
        if (!gilMatch.Success || !gilMatch.Groups["gil"].Success)
            return null;

        string gilAmount = gilMatch.Groups["gil"].Value;
        var builder = new SeStringBuilder();
        if (configuration.IncludeChatTag)
            AddTidyChatTag(builder);

        bool addedItem = false;
        foreach(Payload payload in message.Payloads)
        {
            if (payload is TextPayload { Text: { Length: > 0 } text })
            {
                int putUpIndex = text.IndexOf(" you put up", StringComparison.OrdinalIgnoreCase);
                int soldForIndex = text.IndexOf("sold for", StringComparison.OrdinalIgnoreCase);
                int cutIndex = putUpIndex >= 0 ? putUpIndex : soldForIndex;
                if (cutIndex >= 0)
                {
                    if (cutIndex > 0)
                    {
                        builder.AddText(text[..cutIndex]);
                        if (!text.StartsWith("The ", StringComparison.OrdinalIgnoreCase) || cutIndex > "The ".Length)
                            addedItem = true;
                    }
                    break;
                }
            }

            builder.Add(payload);
            if (payload is ItemPayload)
                addedItem = true;
        }

        if (!addedItem)
            return null;

        builder.AddText($" sold for {gilAmount} gil.");
        return builder.BuiltString;
    }

    public static SeString DutyCommence(SeString message, Configuration configuration, string normalizedText)
    {
        string dutyName = ExtractDutyNameFromCommence(normalizedText, message.TextValue);
        if (string.IsNullOrWhiteSpace(dutyName) && TidyStrings.LastDuty.Length > 0)
            dutyName = TidyStrings.LastDuty;

        if (!string.IsNullOrWhiteSpace(dutyName))
            TidyStrings.LastDuty = dutyName;

        if (string.IsNullOrWhiteSpace(dutyName))
            dutyName = L10N.GetTidy(TidyStrings.InstanceWord);

        var stringBuilder = new SeStringBuilder();
        if (configuration.IncludeChatTag) AddTidyChatTag(stringBuilder);
        stringBuilder.AddText(string.Format(CultureInfo.CurrentCulture, L10N.GetTidy(TidyStrings.DutyHasBegunFormat), dutyName));
        return stringBuilder.BuiltString;
    }

    private static string ExtractDutyNameFromCommence(string normalizedText, string rawText)
    {
        foreach(string candidate in new[] { normalizedText, StripItemLinkNoise(rawText).ToLower(CultureInfo.InvariantCulture) })
        {
            if (string.IsNullOrWhiteSpace(candidate)) continue;
            Match match = L10N.Get(ChatRegexStrings.DutyHasBegun).Match(candidate);
            if (match.Success && match.Groups["duty"].Success)
            {
                string duty = match.Groups["duty"].Value.Trim();
                if (duty.Length > 0) return duty;
            }
        }

        return string.Empty;
    }

    private static string StripItemLinkNoise(string text)
    {
        if (string.IsNullOrEmpty(text)) return text;
        return Regex.Replace(text, @"\uE0BB|\uE0BC|\uE0BD|\uE0BE|\uE0BF|", string.Empty, RegexOptions.None, TimeSpan.FromSeconds(1))
            .Trim();
    }

    public unsafe static SeString Instances(SeString message, Configuration configuration)
    {
        try
        {
            UIState* uiState = UIState.Instance();
            if (uiState == null) return "";

            // This will return the instance value: 0,1,2,3,4,5,6
            int instanceNumberFromSignature = (int)uiState->PublicInstance.InstanceId;
            string instanceCharacter = ((char)(SeIconChar.Instance1 + (byte)(instanceNumberFromSignature - 1))).ToString();
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

    public static SeString NoviceNetworkJoinMessage(Configuration configuration)
    {
        string newMessage = ResolveNoviceNetworkCompactText(7025, 7027, 7011,
            "You've joined the Novice Network.",
            "Du bist dem Neulings-Chat beigetreten.",
            "Vous avez rejoint le réseau des novices.",
            "ビギナーチャンネルに参加しました。");
        var stringBuilder = new SeStringBuilder();
        if (configuration.IncludeChatTag) AddTidyChatTag(stringBuilder);
        stringBuilder.AddText(newMessage);
        return stringBuilder.BuiltString;
    }

    /// <summary>
    ///     Compact Novice Network leave text. Used by <see cref="TidyChatPlugin.OnLogMessage" />
    ///     after suppressing LogMessage 7030.
    /// </summary>
    public static SeString NoviceNetworkLeaveMessage(Configuration configuration)
    {
        string newMessage = ResolveNoviceNetworkCompactText(7030, 0, 0,
            "You've left the Novice Network.",
            "Du hast den Neulings-Chat verlassen.",
            "Vous avez quitté le réseau des novices.",
            "ビギナーチャンネルから退出しました。");
        var stringBuilder = new SeStringBuilder();
        if (configuration.IncludeChatTag) AddTidyChatTag(stringBuilder);
        stringBuilder.AddText(newMessage);
        return stringBuilder.BuiltString;
    }

    private static string ResolveNoviceNetworkCompactText(
        uint primaryId, uint secondaryId, uint tertiaryId,
        string engFallback, string deuFallback, string fraFallback, string jpnFallback)
    {
        if (LogMessageCatalog.TryGetCompactLine(primaryId, out string line)) return line;
        if (secondaryId != 0 && LogMessageCatalog.TryGetCompactLine(secondaryId, out line)) return line;
        if (tertiaryId != 0 && LogMessageCatalog.TryGetCompactLine(tertiaryId, out line)) return line;

        return L10N.Language switch
        {
            ClientLanguage.Japanese => jpnFallback,
            ClientLanguage.German => deuFallback,
            ClientLanguage.French => fraFallback,
            _ => engFallback
        };
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

    /// <summary>Prepends a red "[TidyChat] " tag to the builder.</summary>
    /// <param name="sestring">Target builder.</param>
    /// <returns>The same builder, for chaining.</returns>
    public static SeStringBuilder AddTidyChatTag(SeStringBuilder sestring)
    {
        sestring.AddUiForeground(14);
        sestring.AddText(TidyStrings.Tag);
        sestring.AddUiForegroundOff();
        return sestring;
    }

    /// <summary>Prepends a yellow "[Channel] " tag to the builder.</summary>
    /// <param name="sestring">Target builder.</param>
    /// <returns>The same builder, for chaining.</returns>
    public static SeStringBuilder AddChannelTag(SeStringBuilder sestring, ChatType channel)
    {
        sestring.AddUiForeground(8);
        sestring.AddText($"[{channel}] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }

    /// <summary>Prepends a purple rule-name tag to the builder.</summary>
    /// <param name="sestring">Target builder.</param>
    /// <returns>The same builder, for chaining.</returns>
    public static SeStringBuilder AddRuleTag(SeStringBuilder sestring, List<string> rulesMatched)
    {
        sestring.AddUiForeground(9);
        sestring.AddText($"[{string.Join(", ", rulesMatched)}] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }

    /// <summary>Prepends a red "[Blocked] " tag to the builder.</summary>
    /// <param name="sestring">Target builder.</param>
    /// <returns>The same builder, for chaining.</returns>
    public static SeStringBuilder AddBlockedTag(SeStringBuilder sestring)
    {
        sestring.AddUiForeground(8);
        sestring.AddText("[Blocked] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }

    /// <summary>Prepends a purple "[Allowed] " tag to the builder.</summary>
    /// <param name="sestring">Target builder.</param>
    /// <returns>The same builder, for chaining.</returns>
    public static SeStringBuilder AddAllowedTag(SeStringBuilder sestring)
    {
        sestring.AddUiForeground(9);
        sestring.AddText("[Allowed] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }
}
