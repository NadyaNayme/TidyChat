using Dalamud.Game;
namespace TidyChat.Utility;

internal static class TreasureDungeonHelper
{
    private static int s_currentFloor = 1;
    private static int s_previousFloor = 1;
    private static bool s_gateJustAdvanced;

    internal static void Reset()
    {
        s_currentFloor = 1;
        s_previousFloor = 1;
        s_gateJustAdvanced = false;
    }

    internal static void ClearGateAdvance() => s_gateJustAdvanced = false;

    internal static void RecordGateOpened(int floor)
    {
        if (floor is < 1 or > 6)
        {
            return;
        }

        s_previousFloor = s_currentFloor;
        s_currentFloor = floor;
        s_gateJustAdvanced = true;
    }

    internal static bool TryGetExpulsionChamber(out string chamber)
    {
        var floor = Math.Max(1, s_gateJustAdvanced ? s_previousFloor : s_currentFloor);
        s_gateJustAdvanced = false;
        chamber = FormatChamber(floor);
        return true;
    }

    internal static bool TryParseChamber(string chamber, out int floor)
    {
        floor = 0;
        if (string.IsNullOrWhiteSpace(chamber))
        {
            return false;
        }

        var digits = new string([.. chamber.TakeWhile(char.IsDigit)]);
        return digits.Length > 0 &&
               int.TryParse(digits, NumberStyles.Integer, CultureInfo.InvariantCulture, out floor) &&
               floor is >= 1 and <= 6;
    }

    internal static string FormatChamber(int floor) =>
        L10N.Language switch
        {
            ClientLanguage.Japanese => floor.ToString(CultureInfo.InvariantCulture),
            ClientLanguage.German => floor.ToString(CultureInfo.InvariantCulture),
            ClientLanguage.French => floor == 1 ? "1re" : $"{floor.ToString(CultureInfo.InvariantCulture)}e",
            _ => floor switch
            {
                1 => "1st",
                2 => "2nd",
                3 => "3rd",
                4 => "4th",
                5 => "5th",
                6 => "6th",
                _ => floor.ToString(CultureInfo.InvariantCulture)
            }
        };
}
