## Define DSC
```powershell
Configuration SmtpFeatureTest
{
    Import-DscResource -ModuleName PSDesiredStateConfiguration
    Node localhost
    {

        WindowsFeatureSet WindowsFeatureSetExample
        {
            Name                    = @("SMTP-Server")
            Ensure                  = 'Present'
            IncludeAllSubFeature    = $true
        }
    }
}
```

## Compile
* . .\SmtpFeatureTest.ps1  (dot soruce)
* SmtpFeatureTest (run )
* Generates localhost.mof


[source](https://docs.microsoft.com/en-us/powershell/dsc/configurations/write-compile-apply-configuration)

## Apply
* Start-DscConfiguration -Path C:\tools\dsctest\SmtpFeatureTest -Verbose -Wait

### Running a PS script
```powershell
Configuration SetScript
{
    Import-DscResource -ModuleName PSDesiredStateConfiguration
    Node localhost
    {

        Script TestPS
        {
			GetScript = { #Do Nothing
			}

			SetScript = {
                Push-Location "C:\temp\"
				.\HelloWorld.ps1
			}

			TestScript = {
				return $false
			}
        }
    }
}
```

### Running existing DSC scripts
```powershell
    Start-DscConfiguration –UseExisting –Verbose –Wait
```
### Invoking Resource Directly
[Invoke-DscResource](https://devblogs.microsoft.com/powershell/invoking-powershell-dsc-resources-directly/)

### Debug DSC
[Enable-DscDebug](https://docs.microsoft.com/en-us/powershell/dsc/troubleshooting/debugresource)


### Azure DSC Logs
C:\WindowsAzure\Logs\Plugins\Microsoft.Powershell.DSC\2.26.1.0

[Azure VM DSC](https://devblogs.microsoft.com/powershell/introducing-the-azure-powershell-dsc-desired-state-configuration-extension/)