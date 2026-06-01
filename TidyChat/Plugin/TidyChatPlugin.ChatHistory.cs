using Flags = TidyChat.Utility.ChatFlags;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private bool CheckChatHistory(IHandleableChatMessage message, ChatType chatType, ref bool isHandled)
    {
        if (!Configuration.ChatHistoryFilter || isHandled) return false;
        try
        {
            if (Configuration.DisableSelfChatHistory &&
                string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
                return true;

            var historyChannels = (ChatFlags.Channels)Configuration.ChatHistoryChannels;
            if (historyChannels.Equals(ChatFlags.Channels.None)) return false;
            if (!Flags.CheckFlags(Configuration, chatType)) return false;

            string currentMessage = $"{message.Sender.TextValue}: {message.Message.TextValue}";
            lock(_chatHistoryLock)
            {
                if (Configuration.ChatHistoryTimer > 0)
                {
                    long now = Environment.TickCount64;
                    while(_chatHistory.Count > 0 && _chatHistory.Peek().ExpiresAtTicks <= now)
                        _chatHistory.Dequeue();
                }

                bool isDuplicate = false;
                foreach((string Message, long ExpiresAtTicks) entry in _chatHistory)
                {
                    if (string.Equals(entry.Message, currentMessage, StringComparison.Ordinal))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (isDuplicate)
                {
                    Log.Verbose($"Found message in chat history and blocked: {currentMessage}");
                    isHandled = true;
                }
                else
                {
                    if (_chatHistory.Count >= Configuration.ChatHistoryLength)
                    {
                        Log.Verbose("Chat history reached limit. Removed oldest message and added:" + currentMessage);
                        _chatHistory.Dequeue();
                    }
                    else
                    {
                        Log.Verbose("Added:" + currentMessage);
                    }
                    long expiresAt = Configuration.ChatHistoryTimer > 0
                        ? Environment.TickCount64 + (Configuration.ChatHistoryTimer * 1000L)
                        : long.MaxValue;
                    _chatHistory.Enqueue((currentMessage, expiresAt));
                }
            }
            return true; // chat history always returns after processing
        }
        catch(Exception ex)
        {
            Log.Error("Error: Failed to handle Chat History - " + ex);
            return false;
        }
    }
}
