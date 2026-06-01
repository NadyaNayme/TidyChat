# Clones SystemTab_* strings used by PartyDutyTab into PartyDutyTab_* with clearer labels.
$root = Split-Path $PSScriptRoot -Parent
$ResxPath = Join-Path $root "Resources\Languages.resx"
$DesignerPath = Join-Path $root "Resources\Languages.Designer.cs"
$PartyDutyTabPath = Join-Path $root "..\Settings\Tabs\PartyDutyTab.cs"

$headerValueMap = @{
    'PartyAndInviteDropdownHeader' = 'Party & invites'
    'PartyToolsDropdownHeader' = 'Party tools'
    'PartyLeadershipDropdownHeader' = 'Leadership & lockouts'
    'DutyFinderDropdownHeader' = 'Duty Finder'
    'DutyCompletionDropdownHeader' = 'Duty completion'
    'RetainerAndVentureDropdownHeader' = 'Retainer ventures'
    'FreeCompanyDropdownHeader' = 'Free Company'
    'DeepDungeonsDropdownHeader' = 'Deep dungeons'
}

$labelOverrides = @{
    'ShowPartyObjectiveOnJoin' = 'Party objective & comment on join'
    'HideCompletedVenture' = 'Venture complete'
    'ShowRetainerVentureMessages' = 'Venture assignment & payment'
    'HideCountdownMessages' = '/countdown'
    'HideReadycheckMessages' = '/readycheck'
    'ShowNowALeader' = 'Leader promoted or demoted'
    'ShowSentPartyInviteMessages' = 'Sent party invites'
    'ShowJoiningPartyMessages' = 'Players joining'
    'ShowLeftPartyMessages' = 'Players leaving'
    'ShowDisbandAndDissolveMessages' = 'Disband & dissolve'
    'ShowReceivedPartyInvitationMessages' = 'Received invitations'
    'ShowJoinedCrossworldPartyMessages' = 'Joined party (incl. cross-world)'
    'ShowTeleportOfferFromPartyMessages' = 'Teleport offers from party'
    'ShowDutyFinderMessages' = 'Duty Finder notifications'
    'ShowCompletionTimeForUnrestrictedParty' = 'Unrestricted clear time'
    'HideLoginMessages' = 'FC member login'
    'HideLogoutMessages' = 'FC member logout'
    'HideFreeCompanyMessageBookMessages' = 'Message book entries'
    'HideAirshipVoyageMessages' = 'Airship expedition'
    'HideSubmarineVoyageMessages' = 'Submarine voyage'
}

$partyCs = Get-Content $PartyDutyTabPath -Raw
$oldNames = [regex]::Matches($partyCs, 'Languages\.([A-Za-z0-9_]+)') |
    ForEach-Object { $_.Groups[1].Value } |
    Where-Object { $_ -like 'SystemTab_*' -or $_ -eq 'ShowPartyObjectiveAndPartyCommentWhenJoiningAParty' } |
    Sort-Object -Unique

$content = Get-Content $ResxPath -Raw
$newEntries = @()
$designerProps = @()
$csReplacements = @{}

foreach ($oldName in $oldNames) {
    $suffix = if ($oldName -eq 'ShowPartyObjectiveAndPartyCommentWhenJoiningAParty') {
        'ShowPartyObjectiveOnJoin'
    } else {
        $oldName.Substring('SystemTab_'.Length)
    }
    $newName = "PartyDutyTab_$suffix"
    if ($content -match "<data name=`"$([regex]::Escape($newName))`"") { continue }

    $m = [regex]::Match($content, "<data name=`"$([regex]::Escape($oldName))`"[^>]*>\s*<value>(.*?)</value>", 'Singleline')
    if (-not $m.Success) { Write-Warning "Missing: $oldName"; continue }

    $newValue = $m.Groups[1].Value
    if ($labelOverrides.ContainsKey($suffix)) { $newValue = $labelOverrides[$suffix] }
    elseif ($headerValueMap.ContainsKey($suffix)) { $newValue = $headerValueMap[$suffix] }
    elseif ($newValue.StartsWith('Show ')) { $newValue = $newValue.Substring(5) }
    elseif ($newValue.StartsWith('Hide ')) { $newValue = $newValue.Substring(5) }

    $newValue = $newValue -replace '&(?!amp;)', '&amp;'
    $newEntries += "  <data name=`"$newName`" xml:space=`"preserve`">`r`n    <value>$newValue</value>`r`n  </data>"
    $designerProps += "        internal static string $newName {`r`n            get { return ResourceManager.GetString(`"$newName`", resourceCulture); }`r`n        }"
    $csReplacements[$oldName] = $newName
}

if ($newEntries.Count -eq 0) { Write-Host 'PartyDutyTab resx up to date.'; exit 0 }

$block = ($newEntries -join "`r`n") + "`r`n"
$content = $content -replace '(  <data name="ConfigWindow_EmotesTabHeader")', "$block`$1"
Set-Content $ResxPath $content -Encoding UTF8

$partyCs = Get-Content $PartyDutyTabPath -Raw
foreach ($kv in $csReplacements.GetEnumerator()) {
    $partyCs = $partyCs.Replace("Languages.$($kv.Key)", "Languages.$($kv.Value)")
}
Set-Content $PartyDutyTabPath $partyCs -Encoding UTF8

$designer = Get-Content $DesignerPath -Raw
if ($designer -notmatch 'PartyDutyTab_PartyAndInviteDropdownHeader') {
    $dBlock = "`r`n" + ($designerProps -join "`r`n`r`n") + "`r`n`r`n        "
    $designer = $designer -replace '(internal static string ConfigWindow_EmotesTabHeader)', "$dBlock`$1"
    Set-Content $DesignerPath $designer -Encoding UTF8
}

Write-Host "Added $($newEntries.Count) PartyDutyTab strings."
