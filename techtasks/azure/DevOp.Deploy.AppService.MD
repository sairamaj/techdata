[appservice](https://mohitgoyal.co/2019/07/30/create-multi-stage-pipelines-with-yaml-in-azure-devops/)

```yml
trigger:
- master

pool:
  vmImage: 'VS2017-Win2016'

variables:
  BuildConfiguration: 'Release'
  AzureSubscriptionEndpoint: 'azure-subscription-here-from-service-connection'
  WebAppName: myWebApp
  EnvironmentName: devOpEnvName

stages:
- stage: 'build'
  displayName: 'build'
  jobs:
  - job:
    displayName: 'build'
    pool:
      vmImage: 'ubuntu-latest'
    steps:
    - task: DotNetCoreCLI@2
      displayName: 'build'
      inputs:
        command: publish
        projects: src\MyWebApp\MyWebApp.csproj
        arguments: '--configuration $(BuildConfiguration) --output $(Build.ArtifactStagingDirectory)'
        publishWebProjects: true
        zipAfterPublish : true

    - task: PublishBuildArtifacts@1
      inputs:
        displayName: 'Artifacts'
        pathtoPublish: '$(Build.ArtifactStagingDirectory)' 
        artifactName: 'drop'

- stage: 'deploy'
  displayName: 'deploy'
  jobs:
  - deployment:
    pool:
      vmImage: 'ubuntu-latest'
    environment: $(EnvironmentName)
    strategy:
      runOnce:
        deploy:
          steps:
            - task: AzureRMWebAppDeployment@4
              displayName: Azure App service deploy
              inputs:
                appType: webApp
                connectedServiceName: $(azureSubscriptionEndpoint)
                WebAppName: $(WebAppName)
                Package: $(System.WorkFolder)/**/*.zip
```
