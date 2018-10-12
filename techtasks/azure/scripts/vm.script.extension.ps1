Write-Host 'adding temp directory'
$path = 'c:\temp'
if( $false -eq (Test-Path $path) ){
    New-Item -Path $path -ItemType Directory 
}
Write-Host 'Adding Hello world file'
"Hello world" | out-file (Join-Path $path hello.txt)

Write-Host 'Doing chocolate install'
Set-ExecutionPolicy Bypass -Scope Process -Force; 
iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

Write-Host "Installing Chrome"
choco install googlechrome, git, WindowsAzurePowershell  -y