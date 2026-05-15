param(
    [string]$Configuration = "Release",
    [switch]$OpenOutput
)

$ErrorActionPreference = "Stop"

$scriptDirectory = Split-Path -Parent $MyInvocation.MyCommand.Path
$repoRoot = [System.IO.Path]::GetFullPath((Join-Path $scriptDirectory ".."))
$projectPath = Join-Path $repoRoot "Trung-tam-quan-ly-ngoai-ngu\Trung-tam-quan-ly-ngoai-ngu.csproj"
$publishDir = Join-Path $repoRoot "artifacts\publish\win-x64"

if (-not (Test-Path -LiteralPath $projectPath)) {
    throw "Khong tim thay project UI tai: $projectPath"
}

if (Test-Path -LiteralPath $publishDir) {
    $resolvedPublishDir = (Resolve-Path -LiteralPath $publishDir).Path
    if (-not $resolvedPublishDir.StartsWith($repoRoot, [System.StringComparison]::OrdinalIgnoreCase)) {
        throw "Refuse to clean publish dir ngoai repo: $resolvedPublishDir"
    }

    Remove-Item -LiteralPath $resolvedPublishDir -Recurse -Force
}

New-Item -ItemType Directory -Path $publishDir -Force | Out-Null

Push-Location $repoRoot
try {
    Write-Host "Publishing EXE..." -ForegroundColor Cyan
    & dotnet publish $projectPath -c $Configuration /p:PublishProfile=FolderProfile
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}
finally {
    Pop-Location
}

$exePath = Join-Path $publishDir "Trung-tam-quan-ly-ngoai-ngu.exe"
$settingsPath = Join-Path $publishDir "appsettings.json"

Write-Host ""
Write-Host "Publish xong." -ForegroundColor Green
Write-Host "EXE: $exePath"
Write-Host "Config: $settingsPath"
Write-Host "Folder: $publishDir"

if ($OpenOutput) {
    Start-Process explorer.exe $publishDir
}
