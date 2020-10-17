param([String]$cfg='Release')
$target = 'Industrial.IO.Serial'
$outdir = 'Bin'
$path = "../$target/bin/$cfg"

Set-Location $PSScriptRoot

New-Item -ItemType Directory -Force -Path $outdir 

[array]$files = Get-ChildItem "$path/*.nupkg"
$file = $files[$files.Length - 1]

Compress-Archive -Path "$path/lib" -DestinationPath $file -Update
Copy-Item -Path $file -Destination "../Bin" -Recurse -Force

dotnet nuget push $file -k $env:nk -s https://api.nuget.org/v3/index.json --skip-duplicate

Remove-Item "$path/lib" -Recurse -Force
Remove-Item $file -Force