using System.Linq;
using System.Timers;
using Dalamud;
using Dalamud.Game.Gui;
using Dalamud.Game.Text.SeStringHandling;
using TextCopy;
using TidyChat.Localization.Resources;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat.Utility;

internal static class BetterStrings
{
    public static void Commendations(Configuration configuration, ChatGui chatGui)
    {
        TidyStrings.NumberOfCommendations++;

        // Give it a few seconds before sending the /debug message with the total number of commendations in case there is any lag between commendation messages
        // There shouldn't be any lag since I think they all get sent at once - but having this small wait guarantees that there won't be any problems
        if (TidyStrings.NumberOfCommendations == 1)
        {
            var t = new Timer
            {
                Interval = 2500,
                AutoReset = false
            };
            t.Elapsed += delegate
            {
                var stringBuilder = new SeStringBuilder();
                if (configuration.IncludeChatTag) AddTidyChatTag(stringBuilder);

                var commendations = "";
                if (TidyStrings.NumberOfCommendations == 1)
                    commendations = string.Format(localization.BetterStrings_CommendationSingular);
                else if (TidyStrings.NumberOfCommendations > 1)
                    commendations = localization.BetterStrings_CommendationsPlural;

                var dutyName =
                    $"{(configuration.IncludeDutyNameInComms && TidyStrings.LastDuty.Length > 0 ? " " + localization.BetterStrings_CommendationsFromCompletingDuty + " " + L10N.GetTidy(TidyStrings.LastDuty) + "." : ".")}";

                // TODO: Localize this
                // FR: Vous avez reçu <#> honneurs en ayant participé à (...)
                stringBuilder.AddText(string.Format(localization.BetterStrings_ReceivedCommendationsMessages,
                    TidyStrings.NumberOfCommendations.ToString(), commendations, dutyName));

                chatGui.Print(stringBuilder.BuiltString);

                t.Enabled = false;
                t.Dispose();
                TidyStrings.NumberOfCommendations = 0;
                TidyStrings.LastDuty = "";
            };
            t.Enabled = true;
        }
    }

    public static SeString SayReminder(SeString message, Configuration configuration)
    {
        // With the chat mode in Say, enter a phrase containing "Capture this"

        var containingPhraseStart = message.TextValue.LastIndexOf(L10N.GetTidy(TidyStrings.StartQuotation));
        var containingPhraseEnd = message.TextValue.LastIndexOf(L10N.GetTidy(TidyStrings.EndQuotation));
        var lengthOfPhrase = containingPhraseEnd - containingPhraseStart;
        var containingPhrase = message.TextValue.Substring(containingPhraseStart + 1, lengthOfPhrase - 1);
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

    public static SeString Instances(SeString message, Configuration configuration)
    {
        var instanceNumber = L10N.Get(ChatRegexStrings.GetInstanceNumber).Matches(message.TextValue).First()
            .Groups["instance"].Value;
        var stringBuilder = new SeStringBuilder();
        if (configuration.IncludeChatTag) AddTidyChatTag(stringBuilder);
        stringBuilder.AddText($"{L10N.GetTidy(TidyStrings.InstanceText)} {instanceNumber}");
        return stringBuilder.BuiltString;
    }

    /// <see href="https://xivapi.com/LogMessage/7027?pretty=true">You've joined the Novice Network</see>
    /// <see href="https://xivapi.com/LogMessage/7030?pretty=true">You have left the Novice Network</see>
    public static SeString NoviceNetwork(SeString originalMessage, string normalizedInput, Configuration configuration)
    {
        if (L10N.Get(ChatStrings.NoviceNetworkJoin).All(normalizedInput.Contains))
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

        if (L10N.Get(ChatStrings.NoviceNetworkLeft).All(normalizedInput.Contains))
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

        return originalMessage;
    }

    public static void TemporarilyDisableSystemFilter(Configuration configuration, ChatGui chatGui)
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
    ///     This method takes <paramref name="sestring" /> and adds a yellow "[Debug] " tag text to it
    /// </summary>
    /// <param name="sestring">An empty SeStringBuilder()</param>
    /// <returns>SeString with text: "[Debug] "</returns>
    public static SeStringBuilder AddDebugTag(SeStringBuilder sestring)
    {
        sestring.AddUiForeground(8);
        sestring.AddText(TidyStrings.DebugTag);
        sestring.AddUiForegroundOff();
        return sestring;
    }
}