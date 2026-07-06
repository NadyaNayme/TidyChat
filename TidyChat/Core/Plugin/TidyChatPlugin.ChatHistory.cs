using Flags = TidyChat.Utility.ChatFlags;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private bool CheckChatHistory(IHandleableChatMessage message, ChatType chatType, ref bool isHandled,
        List<string> rulesMatched)
    {
        if (!Configuration.ChatHistoryFilter || isHandled || chatType is ChatType.Echo)
        {
            return false;
        }
        try
        {
            if (Configuration.DisableSelfChatHistory &&
                string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
            {
                return true;
            }

            var historyChannels = (ChatFlags.Channels)Configuration.ChatHistoryChannels;
            if (historyChannels.Equals(ChatFlags.Channels.None))
            {
                return false;
            }
            if (!Flags.CheckFlags(Configuration, chatType))
            {
                return false;
            }

            var currentMessage = $"{message.Sender.TextValue}: {message.Message.TextValue}";
            lock (_chatHistoryLock)
            {
                if (Configuration.ChatHistoryTimer > 0)
                {
                    var now = Environment.TickCount64;
                    while (_chatHistory.Count > 0 && _chatHistory.Peek().ExpiresAtTicks <= now)
                    {
                        _chatHistory.Dequeue();
                    }
                }

                var isDuplicate = false;
                foreach (var entry in _chatHistory)
                {
                    if (string.Equals(entry.Message, currentMessage, StringComparison.Ordinal))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (isDuplicate)
                {
                    if (Configuration.EnableDebugMode)
                    {
                        Log.Verbose($"Found message in chat history and blocked: {currentMessage}");
                    }
                    TrackMatchedRule(rulesMatched, "ChatHistory");
                    isHandled = true;
                }
                else
                {
                    if (_chatHistory.Count >= Configuration.ChatHistoryLength)
                    {
                        Log.Verbose("Chat history at limit; evicting oldest entry");
                        _chatHistory.Dequeue();
                    }
                    var expiresAt = Configuration.ChatHistoryTimer > 0
                        ? Environment.TickCount64 + (Configuration.ChatHistoryTimer * 1000L)
                        : long.MaxValue;
                    _chatHistory.Enqueue((currentMessage, expiresAt));
                    Log.Verbose("Added to chat history: " + currentMessage);
                }
            }
            return true; // chat history always returns after processing
        }
        catch (Exception ex)
        {
            Log.Error("Error: Failed to handle Chat History - " + ex);
            return false;
        }
    }
}
