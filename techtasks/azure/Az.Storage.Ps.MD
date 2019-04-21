# Get Stoage blob
$context = New-AzStorageContext -StorageAccountName storageacct21ff5dff -StorageAccountKey <storagkey>
Get-AzStorageBlob -Container <containerName> -Context $context

# Copy blob to local file.
$sourceContainer = 'source container name'
$localTargetDirectory = "c:\Temp"

$context = New-AzStorageContext -StorageAccountName storageacct21ff5dff -StorageAccountKey $storageKey
foreach($blob in (Get-AzStorageBlob -Container $sourceContainer -Context $context) ){
    Get-AzStorageBlobContent -Blob $blob.Name -Container $sourceContainer -Destination $localTargetDirectory -Context $context
}

# Upload local directory to container
param(
    $storageKey
)

$destinationContainer = "containername"
$context = New-AzStorageContext -StorageAccountName <storageaccount> -StorageAccountKey $storageKey

$container = Get-AzStorageContainer -Name $destinationContainer -Context $context
if( $null -ne $container){
    Write-Host "$($container.Name) exists..."
}else{
    New-AzStorageContainer -Name $destinationContainer -Context $context
}

foreach($file in (Get-ChildItem -Path $directory) )
{
    Set-AzStorageBlobContent -File $file.FullName -Container $destinationContainer -Blob $file.Name -Context $context
}

