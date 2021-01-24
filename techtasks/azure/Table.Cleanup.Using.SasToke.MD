# Summary
* Using SAS token insteadof storage key
* Retrieve Table for given filter


```powershell
Function Get-SasToken{
    param(
        $ResourceGroupName,
        $StorageAccountName
    )
    $StartTime = Get-Date
    $EndTime = $startTime.AddHours(1.0)
    $StgAccount = Get-AzStorageAccount -Name $StorageAccountName -ResourceGroupName $ResourceGroupName
    New-AzStorageAccountSASToken -Service Table -ResourceType Container,Object -Permission "racwdlup" -startTime $StartTime -ExpiryTime $EndTime -Context $StgAccount.Context
}
#Import-Module AzTable

$OctopusDeploymentTable = 'tablename'
$StorageAccout = 'storageaccount'
$ResourceGroup = 'resourcegroup'
$SASToken = Get-SasToken -ResourceGroupName $ResourceGroup -StorageAccountName $StorageAccout
$Context = New-AzStorageContext -StorageAccountName $StorageAccout -SasToken $SASToken
# Note. u get error : ExecuteQuerySegmentedAsync witout passing CloudTable property.
$Table = (Get-AzStorageTable -Name $OctopusDeploymentTable -Context $Context).CloudTable

$CleanUpDate = [datetime]::now.AddDays(-$NumberOfDaysToKeep)

# for date use filtercoditionfordata
# properties are case senitive
$Filter = [Microsoft.Azure.Cosmos.Table.TableQuery]::GenerateFilterConditionForDate("Timestamp",[Microsoft.Azure.Cosmos.Table.QueryComparisons]::LessThan,$CleanUpDate)

$RowsToClean = Get-AzTableRow -Table $Table -CustomFilter $Filter 
$RowsToClean
$RowsToClean | ForEach-Object { Remove-AzTableRow -Table $CloudTable -entity $_ ` }
```