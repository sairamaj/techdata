## using variables to control to the tasks with condition
```yaml
jobs:
  - job: Testing_Variables
    timeoutInMinutes: 240
    pool:
      vmImage: 'VS2017-Win2016'
    steps:
    - task: AzurePowerShell@2
      inputs:
        azureSubscription: 'subscriptionhere'
        ScriptType: 'InlineScript'
        Inline:  Write-Host "##vso[task.setvariable variable=isdeploy;]false"
        azurePowerShellVersion: 'LatestVersion'
    
    - task: AzurePowerShell@2
      condition: and(succeeded(), eq(variables['isdeploy'], 'true'))
      inputs:
        azureSubscription: 'subscriptionhere'
        ScriptType: 'InlineScript'
        Inline: Write-Host "Task-2 variable:"
        azurePowerShellVersion: 'LatestVersion'

```
[source](https://github.com/microsoft/azure-pipelines-tasks/blob/master/docs/authoring/commands.md)