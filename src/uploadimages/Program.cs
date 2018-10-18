using System;
using System.IO;

namespace uploadimages
{
    class Program
    {
        static void Main(string[] args)
        {
            if( args.Length < 1 ){
                Console.WriteLine("Directory name required.");
                System.Environment.Exit(-1);
            }

            string storageConnectionString = Environment.GetEnvironmentVariable("storageconnectionstring");
            Uploader loader = new Uploader(storageConnectionString,"saitech");
            var path = args[0];
            foreach(var fileName in Directory.GetFiles(path) ){
                var destinationName = $"images/{Path.GetFileName(fileName)}";
                Console.WriteLine($"Uploading {fileName} as {destinationName}");
                loader.UploadAsync(fileName,destinationName).GetAwaiter().GetResult();
            }

            // Create a blob client.
            Console.WriteLine("done");
            System.Environment.Exit(0);
        }
    }
}
