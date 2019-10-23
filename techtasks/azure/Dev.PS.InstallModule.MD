## Installing a module in powershell script in devops 

Install-PackageProvider -Name NuGet -Force -Scope CurrentUser

Install-Module -Name AzTable -Force -Verbose -Scope CurrentUser

[source](https://mohitgoyal.co/2017/08/18/install-powershell-modules-on-hosted-agent-in-vsts-visual-studio-team-services/)