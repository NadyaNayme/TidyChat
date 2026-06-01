$rulesPath = Join-Path (Split-Path $PSScriptRoot -Parent) "..\Rules\Rules.System.cs"
$partyRules = @(
    'ShowInviteSent','ShowInviteeJoins','ShowLeftParty','ShowPartyDisband','ShowPartyDissolved',
    'ShowInvitedBy','ShowJoinParty','ShowPartyInformation','ShowOfferedTeleport','ShowCountdownTime',
    'ShowReadyChecks','ShowNowLeaderOf','ShowSealedOff','ShowDutyFinder','ShowCompletionTime',
    'ShowCompletedVenture','ShowRetainerVentureMessages','ShowUserLogins','ShowUserLogouts',
    'ShowFreeCompanyMessageBook','ShowExploratoryVoyage','ShowSubaquaticVoyage','ShowCairnGlows',
    'ShowRestoresLifeToFallen','ShowCairnActivates','ShowTransference','ShowAetherpoolIncrease',
    'ShowAetherpoolUnchanged','ShowObtainedPomander','ShowTrapTriggered','ShowPomanderEffects',
    'ShowFloorNumber','ShowSenseAccursedHoard','ShowDoNotSenseAccursedHoard','ShowDiscoverAccursedHoard'
)
$content = Get-Content $rulesPath -Raw
foreach ($name in $partyRules) {
    $content = [regex]::Replace($content,
        "(Name = `"$name`"[\s\S]*?SettingsTab = `")System(`")",
        '${1}Party${2}')
}
Set-Content $rulesPath $content -Encoding UTF8
Write-Host 'Party duty rules point to Party tab in search.'
