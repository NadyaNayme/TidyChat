using Dalamud.Game.Gui.Dtr;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using TidyStrings = TidyChat.Utility.InternalStrings;
using Timer = System.Timers.Timer;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    public static IDtrBarEntry GetDtrBar() => DtrBar.Get(TidyStrings.PluginName);

    private static void DelayedInstanceDtrBarUpdate(Configuration configuration)
    {
        Timer t = new()
        {
            Interval = 1000,
            AutoReset = false
        };
        t.Elapsed += delegate
        {
            t.Enabled = false;
            t.Dispose();
            InstanceDtrBarUpdate(configuration);
        };
        t.Enabled = true;
    }

    public unsafe static void InstanceDtrBarUpdate(Configuration configuration)
    {
        DtrEntry ??= GetDtrBar();
        DtrEntry.Tooltip = "TidyChat";

        if (!configuration.InstanceInDtrBar)
        {
            DtrEntry.Shown = false;
            DtrEntry.Text = string.Empty;
            return;
        }
        try
        {
            UIState* uiState = UIState.Instance();
            if (uiState == null)
            {
                DtrEntry.Shown = false;
                DtrEntry.Text = string.Empty;
                return;
            }

            int instanceNumberFromSignature = (int)uiState->PublicInstance.InstanceId;
            string instanceCharacter = ((char)(SeIconChar.Instance1 + (byte)(instanceNumberFromSignature - 1))).ToString();

            DtrEntry.Text = instanceNumberFromSignature switch
            {
                >= 1 => $"{L10N.GetTidy(TidyStrings.InstanceWord)} {instanceCharacter}",
                _ => string.Empty
            };
            DtrEntry.Shown = instanceNumberFromSignature >= 1;
        }
        catch(Exception ex)
        {
            Log.Error("Error: Failed to update Instance for DtrBarEntry - " + ex);
        }
    }
}
