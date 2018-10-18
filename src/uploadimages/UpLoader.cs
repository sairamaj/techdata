using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace uploadimages
{
    class Uploader
    {
        CloudStorageAccount _storageAccount;
        CloudBlobContainer _container;

        public Uploader(string connectionString, string containerName){
            if (!CloudStorageAccount.TryParse(connectionString, out _storageAccount)){
                throw new ArgumentException("Could not parse connection string.");
            }

            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            _container = blobClient.GetContainerReference(containerName);
        }

        public async Task UploadAsync(string sourceFileName, string destnationName ){
            await _container.CreateIfNotExistsAsync();

            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(destnationName);
            await blockBlob.UploadFromFileAsync(sourceFileName);
        }
    }
}