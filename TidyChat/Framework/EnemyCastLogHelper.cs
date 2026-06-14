using System.Threading;

namespace TidyChat.Utility;

internal enum EnemyCastLogAction
{
    None,
    RecordReadies,
    SuppressUses
}

internal static class EnemyCastLogHelper
{
    private const int PendingCastWindowMs = 20_000;

    private static readonly Lock Sync = new();
    private static readonly Dictionary<string, PendingCast> PendingByActor = new(StringComparer.OrdinalIgnoreCase);

    internal readonly record struct PendingCast(string NormalizedAbility, long RecordedAtUtcMs);

    internal static void Clear()
    {
        lock (Sync)
        {
            PendingByActor.Clear();
        }
    }

    internal static EnemyCastLogAction Handle(string normalizedText, bool hideInstantUses = false)
    {
        if (TryMatchReadies(normalizedText, out var readiesActor, out var readiesAbility))
        {
            RememberReadies(readiesActor, readiesAbility);
            return EnemyCastLogAction.RecordReadies;
        }

        if (TryMatchUses(normalizedText, out var usesActor, out var usesAbility) &&
            (ShouldSuppressUses(usesActor, usesAbility) || hideInstantUses))
        {
            return EnemyCastLogAction.SuppressUses;
        }

        PruneExpired();
        return EnemyCastLogAction.None;
    }

    internal static bool ShouldSuppressUses(string actor, string ability)
    {
        var actorKey = NormalizeActor(actor);
        var abilityKey = NormalizeAbility(ability);
        if (actorKey.Length == 0 || abilityKey.Length == 0)
        {
            return false;
        }

        lock (Sync)
        {
            if (!PendingByActor.TryGetValue(actorKey, out var pending))
            {
                return false;
            }

            if (!string.Equals(pending.NormalizedAbility, abilityKey, StringComparison.Ordinal))
            {
                return false;
            }

            return UtcNowMs() - pending.RecordedAtUtcMs <= PendingCastWindowMs;
        }
    }

    private static void RememberReadies(string actor, string ability)
    {
        var actorKey = NormalizeActor(actor);
        var abilityKey = NormalizeAbility(ability);
        if (actorKey.Length == 0 || abilityKey.Length == 0)
        {
            return;
        }

        lock (Sync)
        {
            PendingByActor[actorKey] = new PendingCast(abilityKey, UtcNowMs());
        }
    }

    private static void PruneExpired()
    {
        var now = UtcNowMs();
        lock (Sync)
        {
            foreach (var actor in PendingByActor.Keys.ToArray())
            {
                if (now - PendingByActor[actor].RecordedAtUtcMs > PendingCastWindowMs)
                {
                    PendingByActor.Remove(actor);
                }
            }
        }
    }

    private static bool TryMatchReadies(string normalizedText, out string actor, out string ability)
    {
        actor = string.Empty;
        ability = string.Empty;
        var match = L10N.Get(ChatStrings.CombatEnemyReadiesRegex).Match(normalizedText);
        if (!match.Success)
        {
            return false;
        }

        actor = match.Groups["actor"].Value;
        ability = match.Groups["ability"].Value;
        return true;
    }

    private static bool TryMatchUses(string normalizedText, out string actor, out string ability)
    {
        actor = string.Empty;
        ability = string.Empty;
        var match = L10N.Get(ChatStrings.CombatEnemyUsesRegex).Match(normalizedText);
        if (!match.Success)
        {
            return false;
        }

        actor = match.Groups["actor"].Value;
        ability = match.Groups["ability"].Value;
        return true;
    }

    internal static string NormalizeActor(string actor) => actor.Trim().ToLower(CultureInfo.CurrentCulture);

    internal static string NormalizeAbility(string ability)
    {
        var trimmed = ability.Trim();
        var multiplierIndex = trimmed.LastIndexOf(" (", StringComparison.Ordinal);
        if (multiplierIndex > 0 && trimmed.EndsWith(')'))
        {
            trimmed = trimmed[..multiplierIndex];
        }

        return trimmed.Trim().TrimEnd('.').ToLower(CultureInfo.CurrentCulture);
    }

    private static long UtcNowMs() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
}
