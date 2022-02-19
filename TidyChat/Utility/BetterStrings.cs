using TidyStrings = TidyChat.Utility.InternalStrings;
using Dalamud.Game.Text.SeStringHandling;

namespace TidyChat.Utility
{
    internal static class BetterStrings
    {
        // TODO: Move Commendations stringbuilder here

        public static SeString SayReminder(SeString message, Configuration configuration)
        {
            // With the chat mode in Say, enter a phrase containing "Capture this"

            int containingPhraseStart = message.TextValue.IndexOf('“');
            int containingPhraseEnd = message.TextValue.LastIndexOf('”');
            int lengthOfPhrase = containingPhraseEnd - containingPhraseStart;
            string containingPhrase = message.TextValue.Substring(containingPhraseStart + 1, lengthOfPhrase - 1);
            if (configuration.CopyBetterSayReminder)
            {
                var stringBuilder = new SeStringBuilder();
                if (configuration.IncludeChatTag)
                {
                    stringBuilder.AddUiForeground(14);
                    stringBuilder.AddText(TidyStrings.Tag);
                    stringBuilder.AddUiForegroundOff();
                }
                stringBuilder.AddText($"\"/say {containingPhrase}\" {TidyStrings.CopiedToClipboard}");
                TextCopy.ClipboardService.SetText($"/say {containingPhrase}");
                return stringBuilder.BuiltString;
            }
            return $"/say {containingPhrase}";
        }

        public static SeString Instances(SeString message, Configuration configuration)
        {
            // The last character in the first sentence is the instanceNumber so
            // we capture it by finding the period that ends the first sentence and going back one character
            int index = message.TextValue.IndexOf('.');
            string instanceNumber = message.TextValue.Substring(index - 1, 1);
            var stringBuilder = new SeStringBuilder();
            if (configuration.IncludeChatTag)
            {
                stringBuilder.AddUiForeground(14);
                stringBuilder.AddText(TidyStrings.Tag);
                stringBuilder.AddUiForegroundOff();
            }
            stringBuilder.AddText($"{TidyStrings.InstanceText} {instanceNumber}");
            return stringBuilder.BuiltString;
        }
    }
}
