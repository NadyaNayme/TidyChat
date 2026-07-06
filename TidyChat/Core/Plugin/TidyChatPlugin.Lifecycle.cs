using FFXIVClientStructs.FFXIV.Client.Game.UI;
using Lumina.Excel.Sheets;
using System.Threading;
using Timer = System.Timers.Timer;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private void OnLogin()
    {
        L10N.Language = ClientState.ClientLanguage;
        ReloadGameDataCaches(validateRuleIds: false);
        _commendationBaselineSynced = false;
        if (Configuration.BetterCommendationMessage)
        {
            _commendationBaselineSynced = TrySyncCommendationBaseline();
        }
        _lastTerritoryExclusiveType = TryGetTerritoryExclusiveType(ClientState.TerritoryType);
        if (Configuration.InstanceInDtrBar)
        {
            InstanceDtrBarUpdate(Configuration);
        }
        _setPlayerNameRetries = 0; // each login gets a fresh retry budget
        // #122: open the grace window so "Login only" mode shows the post-login announcement burst.
        _serverAnnouncementLoginGraceEnd = DateTime.UtcNow.AddSeconds(ServerAnnouncementLoginGraceSeconds);
        SetPlayerName();
    }

    private void OnLogout(int add, int remove)
    {
        FlushBlockedMessageCount(persist: true);
        ResetCommendationTracking();
        _commendationBaselineSynced = false;
        _lastTerritoryExclusiveType = 0;
    }

    private void OnTerritoryChanged(uint e)
    {
        EnemyCastLogHelper.Clear();
        TreasureDungeonHelper.Reset();
        FlushBlockedMessageCount(persist: false);
        var previousExclusiveType = _lastTerritoryExclusiveType;
        var newExclusiveType = TryGetTerritoryExclusiveType(e);
        _lastTerritoryExclusiveType = newExclusiveType;

        if (Configuration.BetterCommendationMessage)
        {
            var leftDuty = previousExclusiveType == 2 && newExclusiveType != 2;
            BetterCommendationsUpdate(printMessage: leftDuty && _commendationBaselineSynced);
        }
        if (Configuration.InstanceInDtrBar)
        {
            DelayedInstanceDtrBarUpdate(Configuration);
        }
        if (Configuration.IncludeDutyNameInComms)
        {
            try
            {
                var territory =
                    DataManager.GetExcelSheet<TerritoryType>().GetRow(e); // built in sheets will never be null
                var exclusiveType = territory.ExclusiveType;
                var isPvp = territory.IsPvpZone;

                var placeName = $"{territory.PlaceName.Value.Name}";
                var dutyName = $"{territory.ContentFinderCondition.Value.Name}";

                TidyStrings.LastDuty = exclusiveType switch
                {
                    2 when dutyName.Length >= 1 => dutyName,
                    2 when dutyName.Length == 0 && placeName.Length > 0 => placeName,
                    2 when dutyName.Length == 0 && isPvp => L10N.GetTidy(TidyStrings.PvPDuty),
                    _ => TidyStrings.LastDuty // Keep previous value if we don't care about the new value
                };
            }
            catch (KeyNotFoundException)
            {
                Log.Warning(
                    "Something somehow somewhere went wrong but we don't want to crash on territory change");
            }
        }
    }
    private void SetPlayerName()
    {
        if (_setPlayerNamePending)
        {
            return;
        }
        try
        {
            var player = ObjectTable.LocalPlayer;
            if (player is null)
            {
                return;
            }

            Configuration.PlayerName = $"{player.Name}";
            Log.Information($"Player name saved as {player.Name}");
            Configuration.Save();
            _setPlayerNameRetries = 0; // success — reset the retry budget for the next login cycle
        }
        catch (Exception ex)
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
        {
            Configuration.FlushToDisk();
        }
    }

    private unsafe bool TrySyncCommendationBaseline()
    {
        try
        {
            var player = PlayerState.Instance();
            if (player is null)
            {
                Log.Error("PlayerState was null, something went wrong");
                return false;
            }

            TidyStrings.CommendationsEarned = player->PlayerCommendations;
            TidyStrings.LastCommendations = TidyStrings.CommendationsEarned;
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to sync commendation baseline");
            return false;
        }
    }

    private static void ResetCommendationTracking()
    {
        TidyStrings.LastDuty = "";
        TidyStrings.CommendationsEarned = 0;
        TidyStrings.LastCommendations = 0;
    }

    private byte TryGetTerritoryExclusiveType(uint territoryTypeId)
    {
        try
        {
            return DataManager.GetExcelSheet<TerritoryType>().GetRow(territoryTypeId).ExclusiveType;
        }
        catch
        {
            return 0;
        }
    }

    private unsafe void BetterCommendationsUpdate(bool printMessage = true)
    {
        try
        {
            var player = PlayerState.Instance();
            if (player is null)
            {
                Log.Error("PlayerState was null, something went wrong");
                return;
            }

            TidyStrings.CommendationsEarned = player->PlayerCommendations;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to improve Commendations message");
        }

        var commendationChange = TidyStrings.CommendationsEarned - TidyStrings.LastCommendations;
        TidyStrings.LastCommendations = TidyStrings.CommendationsEarned;

        if (printMessage && commendationChange is >= 1 and <= 7)
        {
            var commendations = commendationChange == 1
                ? Languages.BetterStrings_CommendationSingular
                : Languages.BetterStrings_CommendationsPlural;

            var dutyName =
                $"{(Configuration.IncludeDutyNameInComms && TidyStrings.LastDuty.Length > 0 ? " " + Languages.BetterStrings_CommendationsFromCompletingDuty + " " + TidyStrings.LastDuty + "." : ".")}";

            var summaryText = string.Format(
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
                {
                    Better.AddChannelTag(debugBuilder, ChatType.System);
                }
                Better.AddAllowedTag(debugBuilder);
                Better.AddRuleTag(debugBuilder, ["BetterCommendationMessage"]);
                debugBuilder.AddText(summaryText);
                output = debugBuilder.BuiltString;
            }
            else
            {
                SeStringBuilder stringBuilder = new();
                if (Configuration.IncludeChatTag)
                {
                    Better.AddTidyChatTag(stringBuilder);
                }
                stringBuilder.AddText(summaryText);
                output = stringBuilder.BuiltString;
            }

            ChatGui.Print(output);
        }
    }
}
