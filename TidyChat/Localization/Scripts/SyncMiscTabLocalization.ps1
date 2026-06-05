# Emotes, Tools, Progress tab key migration + clearer labels.
$root = Split-Path $PSScriptRoot -Parent
$ResxPath = Join-Path $root "Resources\Languages.resx"
$DesignerPath = Join-Path $root "Resources\Languages.Designer.cs"

$migrations = @(
    @{ Old = 'GeneralTab_FilterEmotes'; New = 'EmotesTab_FilterStandardEmotes'; Value = 'Filter standard emote channel' },
    @{ Old = 'GeneralTab_FilterEmotesHelpMarker'; New = 'EmotesTab_FilterStandardEmotesHelpMarker'; Value = $null },
    @{ Old = 'GeneralTab_FilterCustomEmotes'; New = 'EmotesTab_ShowOtherCustomEmotes'; Value = 'Other players'' custom emotes' },
    @{ Old = 'GeneralTab_FilterCustomEmotesHelpMarker'; New = 'EmotesTab_ShowOtherCustomEmotesHelpMarker'; Value = $null },
    @{ Old = 'GeneralTab_FilterSelfEmotes'; New = 'EmotesTab_ShowSelfCustomEmotes'; Value = 'Your own custom emotes' },
    @{ Old = 'GeneralTab_FilterSelfEmotesHelpMarker'; New = 'EmotesTab_ShowSelfCustomEmotesHelpMarker'; Value = $null },
    @{ Old = 'IncludeChannelTagInDryRunMode'; New = 'ToolsTab_DebugIncludeChannel'; Value = 'Show channel in debug lines' },
    @{ Old = 'SystemTab_ShowFirstClearAward'; New = 'ProgressTab_ShowFirstClearAward'; Value = 'First-time duty clear reward' },
    @{ Old = 'SystemTab_ShowSecondChanceAward'; New = 'ProgressTab_ShowSecondChanceAward'; Value = 'Second Chance reward' }
)

$tabFiles = @{
    'EmotesTab_FilterStandardEmotes' = Join-Path $root '..\Settings\Tabs\EmotesTab.cs'
    'ToolsTab_EnableDebugMode' = Join-Path $root '..\Settings\Tabs\ToolsTab.cs'
    'ProgressTab_ShowFirstClearAward' = Join-Path $root '..\Settings\Tabs\ProgressTab.cs'
}

$content = Get-Content $ResxPath -Raw
$designer = Get-Content $DesignerPath -Raw
$designerAdd = @()
$newEntries = @()

foreach ($m in $migrations) {
    if ($content -match "<data name=`"$([regex]::Escape($m.New))`"") { continue }
    $match = [regex]::Match($content, "<data name=`"$([regex]::Escape($m.Old))`"[^>]*>\s*<value>(.*?)</value>", 'Singleline')
    if (-not $match.Success) { Write-Warning "Skip $($m.Old)"; continue }
    $val = if ($m.Value) { $m.Value } else { $match.Groups[1].Value }
    $val = $val -replace '&(?!amp;)', '&amp;'
    $newEntries += "  <data name=`"$($m.New)`" xml:space=`"preserve`">`r`n    <value>$val</value>`r`n  </data>"
    $designerAdd += "        internal static string $($m.New) {`r`n            get { return ResourceManager.GetString(`"$($m.New)`", resourceCulture); }`r`n        }"
}

if ($newEntries.Count -gt 0) {
    $block = ($newEntries -join "`r`n") + "`r`n"
    $content = $content -replace '(  <data name="ConfigWindow_EmotesTabHeader")', "$block`$1"
}

if ($designerAdd.Count -gt 0 -and $designer -notmatch 'EmotesTab_FilterStandardEmotes') {
    $block = "`r`n" + ($designerAdd -join "`r`n`r`n") + "`r`n`r`n        "
    $designer = $designer -replace '(internal static string ConfigWindow_EmotesTabHeader)', "$block`$1"
    Set-Content $DesignerPath $designer -Encoding UTF8
}

Set-Content $ResxPath $content -Encoding UTF8

$replacements = @{
    'GeneralTab_FilterEmotes' = 'EmotesTab_FilterStandardEmotes'
    'GeneralTab_FilterEmotesHelpMarker' = 'EmotesTab_FilterStandardEmotesHelpMarker'
    'GeneralTab_FilterCustomEmotes' = 'EmotesTab_ShowOtherCustomEmotes'
    'GeneralTab_FilterCustomEmotesHelpMarker' = 'EmotesTab_ShowOtherCustomEmotesHelpMarker'
    'GeneralTab_FilterSelfEmotes' = 'EmotesTab_ShowSelfCustomEmotes'
    'GeneralTab_FilterSelfEmotesHelpMarker' = 'EmotesTab_ShowSelfCustomEmotesHelpMarker'
    'IncludeChannelTagInDryRunMode' = 'ToolsTab_DebugIncludeChannel'
    'SystemTab_ShowFirstClearAward' = 'ProgressTab_ShowFirstClearAward'
    'SystemTab_ShowSecondChanceAward' = 'ProgressTab_ShowSecondChanceAward'
}

foreach ($file in @(
    (Join-Path $root '..\Settings\Tabs\EmotesTab.cs'),
    (Join-Path $root '..\Settings\Tabs\ToolsTab.cs'),
    (Join-Path $root '..\Settings\Tabs\ProgressTab.cs')
)) {
    if (-not (Test-Path $file)) { continue }
    $t = Get-Content $file -Raw
    foreach ($kv in $replacements.GetEnumerator()) {
        $t = $t.Replace("Languages.$($kv.Key)", "Languages.$($kv.Value)")
    }
    Set-Content $file $t -Encoding UTF8
}

Write-Host "Misc tab localization synced."
