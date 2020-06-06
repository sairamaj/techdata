```powershell
param(
    [parameter(Mandatory = $True)]    
    $EnvironmentName
)
#Connect-AzAccount
$Context = Set-AzContext -Subscription "subscriptionidhere"
$Time = "20:00"
$TimeZone = "Pacific Standard Time"

$Servers = @('Server1','Server2','Server3')

foreach ($Server in $Servers) {
    Write-Host "Getting VM: $Server"
    $vm = Get-AzVM -ResourceGroupName $EnvironmentName -Name $Server
    $properties = @{
        "status"           = "Enabled";
        "taskType"         = "ComputeVmShutdownTask";
        "dailyRecurrence"  = @{"time" = ("{0:HHmm}" -f $Time) };
        "timeZoneId"       = $TimeZone;
        "targetResourceId" = $vm.Id
    }
    Write-Host "Setting Auto Shutdown for $($vm.Name) for time:$($Time) - $($TimeZone)"
    
    try{
        $output = New-AzResource -ResourceId ("/subscriptions/{0}/resourceGroups/{1}/providers/microsoft.devtestlab/schedules/shutdown-computevm-{2}" `
        -f $Context.Subscription.Id, $EnvironmentName, $vm.Name) `
        -Location $vm.Location -Properties $properties -ApiVersion "2017-04-26-preview" `
        -Force
    }
    catch{
    }
    
    # Check if resource deployment threw an error
    if ($? -eq $true) {
        # OK, return deployment object
        return $output
    } else {
        # Write error
        Write-Error -Message $Error[0].Exception.Message
    }
}
```