trigger:
- master

pool:
  vmImage: 'VS2017-Win2016'

variables:
  BuildConfiguration: 'Release'
  AzureSubscriptionEndpoint: 'azure-service-connection'
  WebAppName: appname
  EnvironmentName: some-devop-env

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
        projects: csprojpath\foo.csproj
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
                Package: $(System.WorkFolder)/**/foo.zip