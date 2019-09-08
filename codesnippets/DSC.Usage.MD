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