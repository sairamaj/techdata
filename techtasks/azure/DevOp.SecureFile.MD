# Secure file access in devops 
From devop library create data.var

```powershell
jobs:
 - job: Testing_Secure
   pool:
     vmImage: 'VS2017-Win2016'
   steps:
    - task: DownloadSecureFile@1
      name: testname
      inputs:
        secureFile: data.var

    - task: PowerShell@2
      inputs:
        targetType: inline
        script: |
          Write-Host "________________"
          Get-Content $(testname.secureFilePath)
          Write-Host "________________"


```