### Summary
    Checks whether VM is running or not.
#### AZ

#### Powershell

```powershell
Function Test-VMRunning{
    param(
        [parameter(Mandatory = $true)]
        $ResourceGroupName,
        [parameter(Mandatory = $true)]
        $Name
    )
    
    $vmStatus = Get-AzureRMVM -ResourceGroupName $ResourceGroupName -Name $Name -Status
    $runningStatus = $vmStatus.Statuses | Where-Object code -eq 'PowerState/running' `
                        | Select-Object DisplayStatus
    
    return ($runningStatus.DisplayStatus -eq 'VM running')
}

```  

#### CSharp

# Resources
[Overview of Windows virtual machines in Azure](https://docs.microsoft.com/en-us/azure/virtual-machines/windows/overview)
