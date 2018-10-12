### Summary
    Create a Virtual machine
#### AZ

#### Powershell
```powershell
New-AzureRmVm `
    -ResourceGroupName "testing" `
    -Name "vmwithps" `
    -Location "WestUS2" `
    -VirtualNetworkName "testNetwork" `
    -SubnetName "testSubnet" `
    -SecurityGroupName "testNetworkSecurityGroup" `
    -PublicIpAddressName "testPublicIpAddress" `
    -OpenPorts 80,3389

# Get public ip
Get-AzureRmPublicIpAddress -ResourceGroupName "testing" | Select "IpAddress"
```
#### CSharp
```csharp
```
#### Resource Templates

###### Manual
[![Deploy to Azure](https://azuredeploy.net/deploybutton.svg)](https://azuredeploy.net/?repository=https://github.com/Azure/azure-quickstart-templates/tree/master/101-vm-simple-windows)

###### Automate
```powershell
$ResourceGroupName = 'testing'
$TemplateFile = 'https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/101-vm-simple-windows/azuredeploy.json'
$TemplateParameterFile = 'https://raw.githubusercontent.com/sairamaj/techtips/master/data/techtasks/azure/101-vm-simple.windows-parameters.json'

# Creating a deployment 
New-AzureRmResourceGroupDeployment `
    -Name TestAutomationDeployment `
    -ResourceGroupName $ResourceGroupName `
    -TemplateFile $TemplateFile `
    -TemplateParameterFile $TemplateParameterFile `
    -AsJob
```

# Resources
[Overview of Windows virtual machines in Azure](https://docs.microsoft.com/en-us/azure/virtual-machines/windows/overview)  
[Quickstart: Create a Windows virtual machine in Azure with PowerShell](https://docs.microsoft.com/en-us/azure/virtual-machines/windows/quick-create-powershell)  
[Azure Quick start templates](https://azure.microsoft.com/en-us/resources/templates/)  
[Using Azure Quick Start Templates - Video](https://www.lynda.com/Azure-tutorials/Using-Azure-Quickstart-Templates/572164/604861-4.html)  
