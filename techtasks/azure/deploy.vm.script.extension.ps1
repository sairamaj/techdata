Select-AzureRmSubscription -SubscriptionName 'Visual Studio Enterprise'

$ResourceGroupName = 'testing'
$TemplateFile = 'templates\vm.script.extension.json'
$TemplateParameterFile = 'templates\vm.script.extension.parameters.json'
$DeploymentName = 'TestAutomationDeployment'
# Creating a deployment 

New-AzureRmResourceGroupDeployment `
    -Name $DeploymentName `
    -ResourceGroupName $ResourceGroupName `
    -TemplateFile $TemplateFile `
    -TemplateParameterFile $TemplateParameterFile `
    -AsJob

Write-Host "Deployment has been submitted."
Write-Host "Wait 30 seconds before querying the status."
Start-Sleep -Seconds 30
Write-Host "Getting Deployment status"
Get-AzureRmResourceGroupDeployment -ResourceGroupName $ResourceGroupName -Name $DeploymentName
