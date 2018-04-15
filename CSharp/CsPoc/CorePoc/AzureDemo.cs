using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CorePoc
{
    class AzureDemo
    {
        public static void Blob()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("TBD");

            // Create the blob client.
            var fileClient = storageAccount.CreateCloudFileClient();

            // Retrieve a reference to a container.
            var container = fileClient.GetShareReference("devmasterdata");
            var dir = container.GetRootDirectoryReference();
            var appendBlob = dir.GetFileReference("lastAbsenceUpdate.txt");

            //int numBlocks = 10;
            //Random rnd = new Random();
            //byte[] bytes = new byte[numBlocks];
            //rnd.NextBytes(bytes);

            //for (int i = 0; i < numBlocks; i++)
            //{
            //    appendBlob.AppendText(String.Format("Timestamp: {0:u} \tLog Entry: {1}{2}",
            //        DateTime.UtcNow, bytes[i], Environment.NewLine));
            //}

            Console.WriteLine(appendBlob.DownloadTextAsync().GetAwaiter().GetResult());


            //var dir = container.GetDirectoryReference("");
            //var cloudBlob = dir.GetBlockBlobReference("employee_absence_processed.csv");


            //using (MemoryStream ms = new MemoryStream())
            //{
            //    cloudBlob.DownloadToStream(ms);//Read blob data in a stream.
            //}


            //string a = cloudBlob.DownloadText();
            //StringBuilder sb = new StringBuilder(a);
            //sb.AppendLine("1|2|3|4");
            //sb.AppendLine("1|2|3|4");
            //sb.AppendLine("1|2|3|4");
            //cloudBlob.UploadText(a);

        }

    }


}
