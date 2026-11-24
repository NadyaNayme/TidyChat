using FFXIVClientStructs.FFXIV.Client.Game.UI;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private static void DelayedInstanceDtrBarUpdate(Configuration configuration) =>
        _ = Framework.RunOnTick(() => InstanceDtrBarUpdate(configuration), TimeSpan.FromSeconds(1));

    public static unsafe void InstanceDtrBarUpdate(Configuration configuration)
    {
        DtrEntry ??= DtrBar.Get(TidyStrings.PluginName);
        DtrEntry.Tooltip = "TidyChat";

        if (!configuration.InstanceInDtrBar)
        {
            DtrEntry.Shown = false;
            DtrEntry.Text = string.Empty;
            return;
        }
        try
        {
            var uiState = UIState.Instance();
            if (uiState == null)
            {
                DtrEntry.Shown = false;
                DtrEntry.Text = string.Empty;
                return;
            }

            var instanceNumberFromSignature = (int)uiState->PublicInstance.InstanceId;
            var instanceCharacter = ((char)(SeIconChar.Instance1 + (byte)(instanceNumberFromSignature - 1))).ToString();

            DtrEntry.Text = instanceNumberFromSignature switch
            {
                >= 1 => $"{L10N.GetTidy(TidyStrings.InstanceWord)} {instanceCharacter}",
                _ => string.Empty
            };
            DtrEntry.Shown = instanceNumberFromSignature >= 1;
        }
        catch (Exception ex)
        {
            Log.Error("Error: Failed to update Instance for DtrBarEntry - " + ex);
        }
    }
}
