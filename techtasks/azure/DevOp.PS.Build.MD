## Using powershell which as Az commands also (azureSubscription is the one added in dev op projects.)
```yaml
jobs:
  - job: Testing
    timeoutInMinutes: 180
    pool:
      vmImage: 'VS2017-Win2016'
    steps:
    - task: AzurePowerShell@4
      inputs:
        azureSubscription: 'subscriptionnamewhichwasaddedinprojectsettingshere'
        ScriptType: 'FilePath'
        ScriptPath: 'src\scripts\Start-Test.ps1'
        azurePowerShellVersion: 'LatestVersion'
      env:
        Name: $(Name)
```