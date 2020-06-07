# Sending a message to queue

```powershell
#Connect-AzAccount

$queueName = 'queuename'
$storagename = 'stroageaccountname'
$storagekey = 'storageaccount'
$Message = 'test message'

# context
$ctx = New-AzStorageContext -StorageAccountName $storagename -StorageAccountKey $storagekey
# Retrieve a specific queue
$queue = Get-AzStorageQueue –Name $queueName –Context $ctx
$QueueMessage = New-Object `
                -TypeName "Microsoft.WindowsAzure.Storage.Queue.CloudQueueMessage,$($queue.CloudQueue.GetType().Assembly.FullName)" `
                -ArgumentList $Message

# Add a new message to the queue
$queue.CloudQueue.AddMessageAsync($QueueMessage)
```