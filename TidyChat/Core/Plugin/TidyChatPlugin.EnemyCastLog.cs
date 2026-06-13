using System.Threading;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private bool TryCondenseEnemyCastLog(IHandleableChatMessage message, string normalizedText)
    {
        if (!Configuration.BetterEnemyCastLog)
        {
            return false;
        }

        switch (EnemyCastLogHelper.Handle(normalizedText))
        {
            case EnemyCastLogAction.RecordReadies:
                return false;
            case EnemyCastLogAction.SuppressUses:
                LogBlockedChat(["BetterEnemyCastLog"], message.Message.TextValue);
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
                return true;
            default:
                return false;
        }
    }
}
