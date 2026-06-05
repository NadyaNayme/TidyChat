using System.Collections.Generic;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private static SeString BuildDebugString(ChatType chatType, SeString message, List<string> rulesMatched, bool debugIncludeChannel, bool isBlocked)
    {
        SeStringBuilder stringBuilder = new();
        Better.AddTidyChatTag(stringBuilder);
        if (debugIncludeChannel)
        {
            Better.AddChannelTag(stringBuilder, chatType);
        }
        if (isBlocked)
        {
            Better.AddBlockedTag(stringBuilder);
        }
        else
        {
            Better.AddAllowedTag(stringBuilder);
        }

        if (rulesMatched.Count > 0)
        {
            Better.AddRuleTag(stringBuilder, rulesMatched);
        }
        stringBuilder.AddText(message.TextValue);
        return stringBuilder.BuiltString;
    }
}
