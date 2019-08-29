## Sample BuildFile

```yaml

pool:
  vmImage: 'VS2017-Win2016'
steps:
- task: DotNetCoreCLI@2
  displayName: 'dotnet run'
  inputs:
    command: run
    projects: '**/*.csproj'
    arguments: 'arg1 arg2'
    workingDirectory: 'src\ProjectDir'
  env:
    AzureClientId: $(AzureClientId)
    AzureClientSecret: $(AzureClientSecret)
    AzureDeploymentAccountStorageKey: $(AzureDeploymentAccountStorageKey)
    AzureWebJobsStorage: $(AzureWebJobsStorage)
```

* Above using environment variables for secrets. These environment variables can be accessed in C# as regular environment variables.