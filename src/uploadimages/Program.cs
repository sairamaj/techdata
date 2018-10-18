using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace uploadimages
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount;
            CloudBlobContainer cloudBlobContainer;
            string sourceFile;
            string destinationFile = null;
            
            string storageConnectionString = Environment.GetEnvironmentVariable("storageconnectionstring");
            Console.WriteLine(storageConnectionString);
        }
    }
}
