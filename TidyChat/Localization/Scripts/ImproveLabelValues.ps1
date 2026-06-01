# Strips redundant "Show " prefix from tab-prefixed option labels (not headers).
$ResxPath = Join-Path (Split-Path $PSScriptRoot -Parent) "Resources\Languages.resx"
$prefixes = 'GeneralTab_|ObtainTab_|CombatTab_|ProgressTab_|CraftingGatheringTab_|SystemTab_|EmotesTab_|ToolsTab_|WhitelistTab_|ChatHistoryTab_'
$content = Get-Content $ResxPath -Raw

$content = [regex]::Replace($content, "(<data name=`"(?:$prefixes)[^`"]+`"[^>]*>\s*<value>)Show ", '${1}', 'IgnoreCase')

# Section header improvements
$headers = @{
    'GeneralTab_FilterSystemSpam' = 'System message filtering'
    'GeneralTab_DisplayOptionsHeader' = 'Display'
    'GeneralTab_ImprovedMessagesHeader' = 'Message rewrites'
    'ObtainTab_LootingAndRollingDropdownHeader' = 'Loot rolls'
    'ObtainTab_CommonCurrenciesDropdownHeader' = 'Common currencies'
    'ObtainTab_BattleCurrenciesDropdownHeader' = 'Battle currencies'
    'ObtainTab_BeastTribeQuestsDropdownHeader' = 'Beast Tribe'
    'ObtainTab_OtherObtainMessagesDropdownHeader' = 'Other obtain'
    'CombatTab_CastingAndAbilitiesDropdownHeader' = 'Casting &amp; abilities'
    'CombatTab_DamageHealingAndEffectsDropdownHeader' = 'Damage, healing &amp; effects'
    'CombatTab_DefeatAndAddsDropdownHeader' = 'Defeat &amp; adds'
    'ProgressTab_ExperienceAndLevelsDropdownHeader' = 'Experience &amp; levels'
    'ProgressTab_DutyRewardsDropdownHeader' = 'Duty rewards'
    'ProgressTab_QuestAndAchievementsDropdownHeader' = 'Quests &amp; achievements'
    'ProgressTab_UnlocksDropdownHeader' = 'Unlocks'
    'CraftingGatheringTab_CraftingDropdownHeader' = 'Crafting'
    'CraftingGatheringTab_GatheringLocationsDropdownHeader' = 'Gathering'
    'CraftingGatheringTab_FishingDropdownHeader' = 'Fishing'
    'SystemTab_ServerAnnouncementsDropdownHeader' = 'Server announcements'
    'SystemTab_WorldAndInstancesDropdownHeader' = 'World &amp; instances'
    'SystemTab_HuntMessagesDropdownHeader' = 'Hunt marks'
    'SystemTab_ExplorationDropdownHeader' = 'Exploration'
    'SystemTab_GlamourAndGearDropdownHeader' = 'Glamour &amp; gear'
    'SystemTab_SocialAndMiscDropdownHeader' = 'Social &amp; misc'
    'SystemTab_CharacterAndGearDropdownHeader' = 'Character &amp; gearsets'
    'SystemTab_RelicAndMailDropdownHeader' = 'Relic &amp; mail'
    'SystemTab_SocialStatusDropdownHeader' = 'Social status'
    'SystemTab_CatchAllDropdownHeader' = 'Catch-all'
    'SystemTab_OrchestrionDropdownHeader' = 'Orchestrion'
    'SystemTab_ErrorMessagesDropdownHeader' = 'Error messages'
    'EnableTinyChat' = 'Tiny chat (lowercase)'
}

foreach ($kv in $headers.GetEnumerator()) {
    $content = [regex]::Replace($content,
        "(<data name=`"$([regex]::Escape($kv.Key))`"[^>]*>\s*<value>).*?(</value>)",
        "`${1}$($kv.Value)`${2}", 'Singleline')
}

Set-Content $ResxPath $content -Encoding UTF8
Write-Host 'Label values improved.'
