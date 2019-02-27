$scriptpath = $MyInvocation.MyCommand.Path
$dir = Split-Path $scriptpath
Write-host "My directory is $dir"
Write-host "Running: $dir\OneDriveLib.dll"
Import-Module "$dir\OneDriveLib.dll"
Get-ODStatus
PAUSE