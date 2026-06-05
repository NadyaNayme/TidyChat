using Dalamud.Game;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Timers;
using TextCopy;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat.Utility;

internal static class BetterStrings
{
    public static SeString SayReminder(SeString message, Configuration configuration)
    {
        var containingPhraseStart = message.TextValue.LastIndexOf(L10N.GetTidy(TidyStrings.StartQuotation), StringComparison.Ordinal);
        var containingPhraseEnd = message.TextValue.LastIndexOf(L10N.GetTidy(TidyStrings.EndQuotation), StringComparison.Ordinal);
        var lengthOfPhrase = containingPhraseEnd - containingPhraseStart;
        var containingPhrase = message.TextValue.Substring(containingPhraseStart + 1, lengthOfPhrase - 1);
        if (configuration.CopyBetterSayReminder)
        {
            var stringBuilder = new SeStringBuilder();
            if (configuration.IncludeChatTag)
            {
                AddTidyChatTag(stringBuilder);
            }
            stringBuilder.AddText($"\"/say {containingPhrase}\" {L10N.GetTidy(TidyStrings.CopiedToClipboard)}");
            ClipboardService.SetText($"/say {containingPhrase}");
            return stringBuilder.BuiltString;
        }

        return $"/say {containingPhrase}";
    }

    public static SeString DutyCommence(SeString message, Configuration configuration, string normalizedText)
    {
        var dutyName = ExtractDutyNameFromCommence(normalizedText, message.TextValue);
        if (string.IsNullOrWhiteSpace(dutyName) && TidyStrings.LastDuty.Length > 0)
        {
            dutyName = TidyStrings.LastDuty;
        }

        if (!string.IsNullOrWhiteSpace(dutyName))
        {
            TidyStrings.LastDuty = dutyName;
        }

        if (string.IsNullOrWhiteSpace(dutyName))
        {
            dutyName = L10N.GetTidy(TidyStrings.InstanceWord);
        }

        var stringBuilder = new SeStringBuilder();
        if (configuration.IncludeChatTag)
        {
            AddTidyChatTag(stringBuilder);
        }
        stringBuilder.AddText(string.Format(CultureInfo.CurrentCulture, L10N.GetTidy(TidyStrings.DutyHasBegunFormat), dutyName));
        return stringBuilder.BuiltString;
    }

    private static string ExtractDutyNameFromCommence(string normalizedText, string rawText)
    {
        var strippedRaw = StripItemLinkNoise(rawText);
        foreach (var candidate in new[] { strippedRaw, normalizedText })
        {
            if (string.IsNullOrWhiteSpace(candidate))
            {
                continue;
            }
            var match = L10N.Get(ChatRegexStrings.DutyHasBegun).Match(candidate);
            if (match.Success && match.Groups["duty"].Success)
            {
                var duty = match.Groups["duty"].Value.Trim();
                if (duty.Length > 0)
                {
                    return duty;
                }
            }
        }

        return string.Empty;
    }

    private static string StripItemLinkNoise(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }
        return Regex.Replace(text, @"\uE0BB|\uE0BC|\uE0BD|\uE0BE|\uE0BF|", string.Empty, RegexOptions.None, TimeSpan.FromSeconds(1))
            .Trim();
    }

    public static unsafe SeString Instances(SeString message, Configuration configuration)
    {
        try
        {
            var uiState = UIState.Instance();
            if (uiState == null)
            {
                return "";
            }

            var instanceNumberFromSignature = (int)uiState->PublicInstance.InstanceId;
            var instanceCharacter = ((char)(SeIconChar.Instance1 + (byte)(instanceNumberFromSignature - 1))).ToString();
            var stringBuilder = new SeStringBuilder();
            if (configuration.IncludeChatTag)
            {
                AddTidyChatTag(stringBuilder);
            }
            stringBuilder.AddText($"{L10N.GetTidy(TidyStrings.InstanceText)} {instanceCharacter}");
            return stringBuilder.BuiltString;
        }
        catch
        { }
        return "";
    }

    public static SeString NoviceNetworkJoinMessage(Configuration configuration)
    {
        var newMessage = ResolveNoviceNetworkCompactText(7025, 7027, 7011,
            "You've joined the Novice Network.",
            "Du bist dem Neulings-Chat beigetreten.",
            "Vous avez rejoint le réseau des novices.",
            "ビギナーチャンネルに参加しました。");
        var stringBuilder = new SeStringBuilder();
        if (configuration.IncludeChatTag)
        {
            AddTidyChatTag(stringBuilder);
        }
        stringBuilder.AddText(newMessage);
        return stringBuilder.BuiltString;
    }

    public static SeString NoviceNetworkLeaveMessage(Configuration configuration)
    {
        var newMessage = ResolveNoviceNetworkCompactText(7030, 0, 0,
            "You've left the Novice Network.",
            "Du hast den Neulings-Chat verlassen.",
            "Vous avez quitté le réseau des novices.",
            "ビギナーチャンネルから退出しました。");
        var stringBuilder = new SeStringBuilder();
        if (configuration.IncludeChatTag)
        {
            AddTidyChatTag(stringBuilder);
        }
        stringBuilder.AddText(newMessage);
        return stringBuilder.BuiltString;
    }

    private static string ResolveNoviceNetworkCompactText(
        uint primaryId, uint secondaryId, uint tertiaryId,
        string engFallback, string deuFallback, string fraFallback, string jpnFallback)
    {
        if (LogMessageCatalog.TryGetCompactLine(primaryId, out var line))
        {
            return line;
        }
        if (secondaryId != 0 && LogMessageCatalog.TryGetCompactLine(secondaryId, out line))
        {
            return line;
        }
        if (tertiaryId != 0 && LogMessageCatalog.TryGetCompactLine(tertiaryId, out line))
        {
            return line;
        }

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
        var chamber = TidyStrings.LastTreasureDungeonChamber;
        var stringBuilder = new SeStringBuilder();
        if (configuration.IncludeChatTag)
        {
            AddTidyChatTag(stringBuilder);
        }
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

    public static SeStringBuilder AddTidyChatTag(SeStringBuilder sestring)
    {
        sestring.AddUiForeground(14);
        sestring.AddText(TidyStrings.Tag);
        sestring.AddUiForegroundOff();
        return sestring;
    }

    public static SeStringBuilder AddChannelTag(SeStringBuilder sestring, ChatType channel)
    {
        sestring.AddUiForeground(8);
        sestring.AddText($"[{channel}] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }

    public static SeStringBuilder AddRuleTag(SeStringBuilder sestring, List<string> rulesMatched)
    {
        sestring.AddUiForeground(9);
        sestring.AddText($"[{string.Join(", ", rulesMatched)}] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }

    public static SeStringBuilder AddBlockedTag(SeStringBuilder sestring)
    {
        sestring.AddUiForeground(8);
        sestring.AddText("[Blocked] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }

    public static SeStringBuilder AddAllowedTag(SeStringBuilder sestring)
    {
        sestring.AddUiForeground(9);
        sestring.AddText("[Allowed] ");
        sestring.AddUiForegroundOff();
        return sestring;
    }
}
