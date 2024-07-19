using System;

namespace TidyChat;

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
                return true;
            return false;
        }
        catch (Exception e)
        {
            TidyChatPlugin.Log.Debug("Encountered error: " + e);
            return false;
        }
    }
}