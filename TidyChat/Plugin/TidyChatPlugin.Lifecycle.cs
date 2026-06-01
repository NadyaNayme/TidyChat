using System.Collections.Generic;
using System.Threading;
using Dalamud.Game.ClientState.Objects.SubKinds;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using Lumina.Excel.Sheets;
using Timer = System.Timers.Timer;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private void OnLogin()
    {
        L10N.Language = ClientState.ClientLanguage;
        ReloadGameDataCaches(validateRuleIds: false);
        if (Configuration.BetterCommendationMessage) BetterCommendationsUpdate(printMessage: false);
        if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(Configuration);
        _setPlayerNameRetries = 0; // each login gets a fresh retry budget
        // #122: open the grace window so "Login only" mode shows the post-login announcement burst.
        _serverAnnouncementLoginGraceEnd = DateTime.UtcNow.AddSeconds(ServerAnnouncementLoginGraceSeconds);
        SetPlayerName();
    }

    private void OnLogout(int add, int remove)
    {
        FlushBlockedMessageCount(persist: true);
    }

    private void OnTerritoryChanged(uint e)
    {
        FlushBlockedMessageCount(persist: false);
        byte newExclusiveType = 0;
        try
        {
            newExclusiveType = DataManager.GetExcelSheet<TerritoryType>().GetRow(e).ExclusiveType;
        }
        catch
        {
            /* non-critical — default 0 means "not a duty" */
        }

        if (Configuration.BetterCommendationMessage) BetterCommendationsUpdate(printMessage: newExclusiveType != 2);
        if (Configuration.InstanceInDtrBar) DelayedInstanceDtrBarUpdate(Configuration);
        if (Configuration.IncludeDutyNameInComms)
            try
            {
                TerritoryType territory =
                    DataManager.GetExcelSheet<TerritoryType>().GetRow(e); // built in sheets will never be null
                byte exclusiveType = territory.ExclusiveType;
                bool isPvp = territory.IsPvpZone;

                string placeName = $"{territory.PlaceName.Value.Name}";
                string dutyName = $"{territory.ContentFinderCondition.Value.Name}";

                TidyStrings.LastDuty = exclusiveType switch
                {
                    2 when dutyName.Length >= 1 => dutyName,
                    2 when dutyName.Length == 0 && placeName.Length > 0 => placeName,
                    2 when dutyName.Length == 0 && isPvp => L10N.GetTidy(TidyStrings.PvPDuty),
                    _ => TidyStrings.LastDuty // Keep previous value if we don't care about the new value
                };
            }
            catch(KeyNotFoundException)
            {
                Log.Warning(
                    "Something somehow somewhere went wrong but we don't want to crash on territory change");
            }
    }
    private void SetPlayerName()
    {
        if (_setPlayerNamePending) return;
        try
        {
            IPlayerCharacter? player = ObjectTable.LocalPlayer;
            if (player is null) return;

            Configuration.PlayerName = $"{player.Name}";
            Log.Information($"Player name saved as {player.Name}");
            Configuration.Save();
            _setPlayerNameRetries = 0; // success — reset the retry budget for the next login cycle
        }
        catch(Exception ex)
        {
            if (_setPlayerNameRetries >= MaxSetPlayerNameRetries)
            {
                Log.Error($"Error: Failed to capture player's name after {MaxSetPlayerNameRetries} retries. Giving up until next login. " + ex);
                return;
            }

            _setPlayerNameRetries++;
            Log.Error($"Error: Failed to capture player's name - retry {_setPlayerNameRetries}/{MaxSetPlayerNameRetries} in 30 seconds. " + ex);
            _setPlayerNamePending = true;
            Timer t = new()
            {
                Interval = 30000,
                AutoReset = false
            };
            t.Elapsed += delegate
            {
                _setPlayerNamePending = false;
                t.Enabled = false;
                t.Dispose();
                SetPlayerName();
            };
            t.Enabled = true;
        }
    }

    private void FlushBlockedMessageCount(bool persist)
    {
        Configuration.TtlMessagesBlocked += (ulong)Interlocked.Exchange(ref _sessionBlockedMessages, 0);
        if (persist)
            Configuration.FlushToDisk();
    }

    private unsafe void BetterCommendationsUpdate(bool printMessage = true)
    {
        try
        {
            PlayerState* player = PlayerState.Instance();
            if (player == null)
            {
                Log.Error("PlayerState was null, something went wrong");
                return;
            }

            TidyStrings.CommendationsEarned = player->PlayerCommendations;
        }
        catch(Exception ex)
        {
            Log.Error(ex, "Failed to improve Commendations message");
        }

        int commendationChange = TidyStrings.CommendationsEarned - TidyStrings.LastCommendations;
        TidyStrings.LastCommendations = TidyStrings.CommendationsEarned;

        if (printMessage && commendationChange is >= 1 and <= 7)
        {
            string? commendations = commendationChange == 1
                ? Languages.BetterStrings_CommendationSingular
                : Languages.BetterStrings_CommendationsPlural;

            string dutyName =
                $"{(Configuration.IncludeDutyNameInComms && TidyStrings.LastDuty.Length > 0 ? " " + Languages.BetterStrings_CommendationsFromCompletingDuty + " " + TidyStrings.LastDuty + "." : ".")}";

            string summaryText = string.Format(
                CultureInfo.CurrentCulture,
                Languages.BetterStrings_ReceivedCommendationsMessages,
                commendationChange.ToString(CultureInfo.CurrentCulture),
                commendations,
                dutyName);

            SeString output;
            if (Configuration.EnableDebugMode)
            {
                SeStringBuilder debugBuilder = new();
                Better.AddTidyChatTag(debugBuilder);
                if (Configuration.DebugIncludeChannel)
                    Better.AddChannelTag(debugBuilder, ChatType.System);
                Better.AddAllowedTag(debugBuilder);
                Better.AddRuleTag(debugBuilder, ["BetterCommendationMessage"]);
                debugBuilder.AddText(summaryText);
                output = debugBuilder.BuiltString;
            }
            else
            {
                SeStringBuilder stringBuilder = new();
                if (Configuration.IncludeChatTag) Better.AddTidyChatTag(stringBuilder);
                stringBuilder.AddText(summaryText);
                output = stringBuilder.BuiltString;
            }

            ChatGui.Print(output);
        }
    }
}
