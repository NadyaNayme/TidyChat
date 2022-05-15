using Dalamud.Logging;
using System;

namespace TidyChat
{
    public static class FilterFreeCompanyMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (
                    (configuration.HideUserLogins && L10N.Get(ChatRegexStrings.HasLoggedIn).IsMatch(input)) ||
                    (configuration.HideUserLogouts && L10N.Get(ChatRegexStrings.HasLoggedOut).IsMatch(input))
                   )
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                PluginLog.LogDebug("Encountered error: " + e);
                return false;
            }
        }
    }
}
