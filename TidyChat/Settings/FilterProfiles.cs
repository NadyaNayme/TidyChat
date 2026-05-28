using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
namespace TidyChat;

internal static class FilterProfiles
{
    private static readonly Configuration Factory = new();

    private static int s_pendingProfile = (int)FilterProfile.Balanced;

    public static void SyncProfileSelector(int profileIndex) => s_pendingProfile = profileIndex;

    public static void DrawProfileSelector(Configuration configuration)
    {
        if (ImGui.IsWindowAppearing())
            s_pendingProfile = (int)configuration.FilterProfile;

        ImGui.TextUnformatted(Languages.GeneralTab_FilterProfileLabel);
        ImGuiComponents.HelpMarker(Languages.GeneralTab_FilterProfileHelpMarker);

        string[] profileLabels =
        [
            Languages.GeneralTab_FilterProfile_Custom,
            Languages.GeneralTab_FilterProfile_Balanced,
            Languages.GeneralTab_FilterProfile_Minimal,
            Languages.GeneralTab_FilterProfile_VanillaPlus
        ];

        int selectedProfile = s_pendingProfile;
        ImGui.SetNextItemWidth(280f);
        if (ImGui.BeginCombo("##filterProfile", profileLabels[selectedProfile]))
        {
            for (int i = 0; i < profileLabels.Length; i++)
            {
                if (ImGui.Selectable(profileLabels[i], selectedProfile == i))
                    s_pendingProfile = i;
            }

            ImGui.EndCombo();
        }

        ImGui.SameLine();
        bool canApply = s_pendingProfile != (int)FilterProfile.Custom;
        if (!canApply)
            ImGui.BeginDisabled();

        if (ImGui.Button(Languages.GeneralTab_FilterProfileApply))
        {
            Apply((FilterProfile)s_pendingProfile, configuration);
        }

        if (!canApply)
            ImGui.EndDisabled();
    }

    public static void Apply(FilterProfile profile, Configuration configuration)
    {
        if (profile is FilterProfile.Custom)
            return;

        ResetFilterSettings(configuration);

        switch (profile)
        {
            case FilterProfile.VanillaPlus:
                ApplyVanillaPlus(configuration);
                break;
            case FilterProfile.Minimal:
                ApplyMinimal(configuration);
                break;
        }

        configuration.FilterProfile = profile;
        SyncProfileSelector((int)profile);
        configuration.Save();
    }

    private static void ApplyVanillaPlus(Configuration configuration)
    {
        // Light touch: only hide gil, XP, and FC voyages; re-enable everything else Balanced hides.
        configuration.HideObtainedGil = true;
        configuration.ShowGainExperience = false;
        configuration.ShowExploratoryVoyage = false;
        configuration.ShowSubaquaticVoyage = false;

        configuration.HideObtainedShards = false;
        configuration.HideRouletteBonus = false;
        configuration.HideAdventurerInNeedBonus = false;
        configuration.HideFateLevelSync = false;
        configuration.HideOrchestrionPlaying = false;
        configuration.ShowUserLogins = true;
        configuration.ShowUserLogouts = true;
        configuration.ShowCompletedVenture = true;
        configuration.ShowGatheringYield = true;
        configuration.ShowGatheringAttempts = true;
        configuration.ShowGatherersBoon = true;
        configuration.ShowGatheringStartEnd = true;
        configuration.ShowAetherialReductionSands = true;
        configuration.ShowCurrentFishingHole = true;
        configuration.ShowLureMessages = true;
        configuration.ShowMooching = true;
        configuration.ShowMeasuringIlms = true;
        configuration.ShowCosmicRewards = true;
        configuration.ShowCosmicDailyProgress = true;
        configuration.ShowCombatDamage = true;
        configuration.ShowCombatAbilities = true;
        configuration.ShowCombatEffects = true;
        configuration.ShowCombatMisses = true;
        configuration.ShowCombatHealing = true;
        configuration.ShowCombatEnmity = true;
        configuration.ShowActiveHelpEntry = true;
        configuration.ShowSpiritboundGear = true;
        configuration.ShowEligibleForCoffers = true;
    }

    private static void ApplyMinimal(Configuration configuration)
    {
        configuration.ShowLevelUps = false;
        configuration.ShowMountMessages = false;
        configuration.HideOthersObtain = true;
    }

    private static void ResetFilterSettings(Configuration configuration)
    {
        configuration.FilterSystemMessages = Factory.FilterSystemMessages;
        configuration.FilterEmoteChannel = Factory.FilterEmoteChannel;
        configuration.FilterCustomEmoteChannel = Factory.FilterCustomEmoteChannel;
        configuration.FilterObtainedSpam = Factory.FilterObtainedSpam;
        configuration.FilterLootSpam = Factory.FilterLootSpam;
        configuration.FilterProgressSpam = Factory.FilterProgressSpam;
        configuration.FilterCraftingSpam = Factory.FilterCraftingSpam;
        configuration.FilterGatheringSpam = Factory.FilterGatheringSpam;

        configuration.ShowCommendations = Factory.ShowCommendations;
        configuration.ShowCompletedVenture = Factory.ShowCompletedVenture;
        configuration.ShowHousingWardMessage = Factory.ShowHousingWardMessage;
        configuration.ShowQuestReminder = Factory.ShowQuestReminder;
        configuration.ShowMountMessages = Factory.ShowMountMessages;
        configuration.ShowSelfUsedEmotes = Factory.ShowSelfUsedEmotes;
        configuration.ShowOtherCustomEmotes = Factory.ShowOtherCustomEmotes;
        configuration.ShowSpiritboundGear = Factory.ShowSpiritboundGear;
        configuration.ShowAetherCompass = Factory.ShowAetherCompass;
        configuration.ShowSearchForItemResults = Factory.ShowSearchForItemResults;
        configuration.ShowExploratoryVoyage = Factory.ShowExploratoryVoyage;
        configuration.ShowSubaquaticVoyage = Factory.ShowSubaquaticVoyage;
        configuration.ShowFreeCompanyMessageBook = Factory.ShowFreeCompanyMessageBook;
        configuration.ShowPersonalMessageBook = Factory.ShowPersonalMessageBook;
        configuration.ShowVistaMessages = Factory.ShowVistaMessages;
        configuration.ShowTryOnGlamour = Factory.ShowTryOnGlamour;
        configuration.ShowEligibleForCoffers = Factory.ShowEligibleForCoffers;
        configuration.ShowGearsetEquipped = Factory.ShowGearsetEquipped;
        configuration.ShowMateriaRetrieved = Factory.ShowMateriaRetrieved;
        configuration.ShowTradeSent = Factory.ShowTradeSent;
        configuration.ShowTradeCanceled = Factory.ShowTradeCanceled;
        configuration.ShowAwaitingTradeConfirmation = Factory.ShowAwaitingTradeConfirmation;
        configuration.ShowTradeComplete = Factory.ShowTradeComplete;
        configuration.ShowInviteSent = Factory.ShowInviteSent;
        configuration.ShowInviteeJoins = Factory.ShowInviteeJoins;
        configuration.ShowLeftParty = Factory.ShowLeftParty;
        configuration.ShowPartyDisband = Factory.ShowPartyDisband;
        configuration.ShowPartyDissolved = Factory.ShowPartyDissolved;
        configuration.ShowJoinParty = Factory.ShowJoinParty;
        configuration.ShowDutyFinder = Factory.ShowDutyFinder;
        configuration.ShowOfferedTeleport = Factory.ShowOfferedTeleport;
        configuration.ShowHuntSlain = Factory.ShowHuntSlain;
        configuration.ShowCompletionTime = Factory.ShowCompletionTime;
        configuration.ShowRelicBookStep = Factory.ShowRelicBookStep;
        configuration.ShowRelicBookComplete = Factory.ShowRelicBookComplete;
        configuration.ShowOnlineStatus = Factory.ShowOnlineStatus;
        configuration.ShowAttachToMail = Factory.ShowAttachToMail;
        configuration.ShowNowLeaderOf = Factory.ShowNowLeaderOf;
        configuration.ShowFirstClearAward = Factory.ShowFirstClearAward;
        configuration.ShowSecondChanceAward = Factory.ShowSecondChanceAward;
        configuration.ShowAetheryteTicket = Factory.ShowAetheryteTicket;
        configuration.ShowActiveHelpEntry = Factory.ShowActiveHelpEntry;
        configuration.ShowEverythingElse = Factory.ShowEverythingElse;
        configuration.ShowUserLogins = Factory.ShowUserLogins;
        configuration.ShowUserLogouts = Factory.ShowUserLogouts;

        configuration.HideFateLevelSync = Factory.HideFateLevelSync;
        configuration.HideOrchestrionPlaying = Factory.HideOrchestrionPlaying;

        configuration.ShowObtainedPomander = Factory.ShowObtainedPomander;
        configuration.ShowCairnGlows = Factory.ShowCairnGlows;
        configuration.ShowRestoresLifeToFallen = Factory.ShowRestoresLifeToFallen;
        configuration.ShowCairnActivates = Factory.ShowCairnActivates;
        configuration.ShowTransference = Factory.ShowTransference;
        configuration.ShowAetherpoolIncrease = Factory.ShowAetherpoolIncrease;
        configuration.ShowAetherpoolUnchanged = Factory.ShowAetherpoolUnchanged;
        configuration.ShowPomanderEffects = Factory.ShowPomanderEffects;
        configuration.ShowFloorNumber = Factory.ShowFloorNumber;
        configuration.ShowSenseAccursedHoard = Factory.ShowSenseAccursedHoard;
        configuration.ShowDoNotSenseAccursedHoard = Factory.ShowDoNotSenseAccursedHoard;
        configuration.ShowDiscoverAccursedHoard = Factory.ShowDiscoverAccursedHoard;

        configuration.ShowObtainedItems = Factory.ShowObtainedItems;
        configuration.HideObtainedGil = Factory.HideObtainedGil;
        configuration.HideObtainedMGP = Factory.HideObtainedMGP;
        configuration.HideObtainedClusters = Factory.HideObtainedClusters;
        configuration.HideObtainedWolfMarks = Factory.HideObtainedWolfMarks;
        configuration.HideObtainedSeals = Factory.HideObtainedSeals;
        configuration.HideObtainedAlliedSeals = Factory.HideObtainedAlliedSeals;
        configuration.HideObtainedCenturioSeals = Factory.HideObtainedCenturioSeals;
        configuration.HideObtainedNuts = Factory.HideObtainedNuts;
        configuration.HideObtainedVenture = Factory.HideObtainedVenture;
        configuration.HideObtainedMaterials = Factory.HideObtainedMaterials;
        configuration.HideObtainedTribalCurrency = Factory.HideObtainedTribalCurrency;
        configuration.HideObtainedShards = Factory.HideObtainedShards;
        configuration.ShowGainExperience = Factory.ShowGainExperience;
        configuration.HideRouletteBonus = Factory.HideRouletteBonus;
        configuration.HideAdventurerInNeedBonus = Factory.HideAdventurerInNeedBonus;
        configuration.ShowGainPvpExp = Factory.ShowGainPvpExp;
        configuration.ShowEarnAchievement = Factory.ShowEarnAchievement;
        configuration.ShowOtherEarnedAchievement = Factory.ShowOtherEarnedAchievement;

        configuration.ShowLootRoll = Factory.ShowLootRoll;
        configuration.ShowCastLot = Factory.ShowCastLot;
        configuration.ShowOthersLootRoll = Factory.ShowOthersLootRoll;
        configuration.ShowOnlyPartyMemberRolls = Factory.ShowOnlyPartyMemberRolls;
        configuration.ShowOthersCastLot = Factory.ShowOthersCastLot;
        configuration.HideOthersObtain = Factory.HideOthersObtain;

        configuration.ShowLevelUps = Factory.ShowLevelUps;
        configuration.ShowOtherLevelUps = Factory.ShowOtherLevelUps;

        configuration.ShowAttachedMateria = Factory.ShowAttachedMateria;
        configuration.ShowMateriaExtract = Factory.ShowMateriaExtract;
        configuration.ShowDesynthesisLevel = Factory.ShowDesynthesisLevel;
        configuration.ShowDesynthedItem = Factory.ShowDesynthedItem;
        configuration.ShowDesynthesisObtains = Factory.ShowDesynthesisObtains;
        configuration.ShowTrialMessages = Factory.ShowTrialMessages;
        configuration.ShowOtherSynthesis = Factory.ShowOtherSynthesis;
        configuration.ShowCraftingSynthesisComplete = Factory.ShowCraftingSynthesisComplete;
        configuration.ShowAllOtherCrafting = Factory.ShowAllOtherCrafting;

        configuration.ShowGatheringSenses = Factory.ShowGatheringSenses;
        configuration.ShowAetherialReductionSands = Factory.ShowAetherialReductionSands;
        configuration.ShowLocationAffects = Factory.ShowLocationAffects;
        configuration.ShowGatheringStartEnd = Factory.ShowGatheringStartEnd;
        configuration.ShowGatheringYield = Factory.ShowGatheringYield;
        configuration.ShowGatherersBoon = Factory.ShowGatherersBoon;
        configuration.ShowGatheringAttempts = Factory.ShowGatheringAttempts;
        configuration.ShowCaughtFish = Factory.ShowCaughtFish;
        configuration.ShowMooching = Factory.ShowMooching;
        configuration.ShowCurrentFishingHole = Factory.ShowCurrentFishingHole;
        configuration.ShowDiscoveredFishingHole = Factory.ShowDiscoveredFishingHole;
        configuration.ShowMeasuringIlms = Factory.ShowMeasuringIlms;
        configuration.ShowLureMessages = Factory.ShowLureMessages;
        configuration.ShowFishingFlavorText = Factory.ShowFishingFlavorText;
        configuration.ShowAllOtherGathering = Factory.ShowAllOtherGathering;
        configuration.ShowStellarMissionMessages = Factory.ShowStellarMissionMessages;
        configuration.ShowCosmicRewards = Factory.ShowCosmicRewards;
        configuration.ShowCosmicDailyProgress = Factory.ShowCosmicDailyProgress;

        configuration.ShowCombatCasting = Factory.ShowCombatCasting;
        configuration.ShowCombatAbilities = Factory.ShowCombatAbilities;
        configuration.ShowCombatDamage = Factory.ShowCombatDamage;
        configuration.ShowCombatMisses = Factory.ShowCombatMisses;
        configuration.ShowCombatHealing = Factory.ShowCombatHealing;
        configuration.ShowCombatEffects = Factory.ShowCombatEffects;
        configuration.ShowCombatDefeat = Factory.ShowCombatDefeat;
        configuration.ShowCombatEnemyReady = Factory.ShowCombatEnemyReady;
        configuration.ShowCombatEnmity = Factory.ShowCombatEnmity;
    }
}
