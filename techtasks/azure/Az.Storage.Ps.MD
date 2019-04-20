# Get Stoage blob
$context = New-AzStorageContext -StorageAccountName storageacct21ff5dff -StorageAccountKey <storagkey>
Get-AzStorageBlob -Container <containerName> -Context $context