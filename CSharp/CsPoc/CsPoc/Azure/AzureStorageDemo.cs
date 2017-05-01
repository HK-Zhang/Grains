using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure; // Namespace for Azure Configuration Manager
using Microsoft.WindowsAzure.Storage; // Namespace for Storage Client Library
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage
using Microsoft.WindowsAzure.Storage.File; // Namespace for File storage
using System.IO;
using CsPoc.Basic;

namespace CsPoc.Azure
{
    public class AzureStorageDemo
    {
        private const int limit = 10;
        public void Execute()
        {
            //downlaod();
            readAsStream();
        }

        private void downlaod()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create a CloudFileClient object for credentialed access to File storage.
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            // Get a reference to the file share we created previously.
            CloudFileShare share = fileClient.GetShareReference("one");

            // Ensure that the share exists.
            if (share.Exists())
            {
                // Get a reference to the root directory for the share.
                CloudFileDirectory rootDir = share.GetRootDirectoryReference();

                // Get a reference to the directory we created previously.
                CloudFileDirectory sampleDir = rootDir.GetDirectoryReference("one");

                // Ensure that the directory exists.
                if (sampleDir.Exists())
                {
                    // Get a reference to the file we created previously.
                    CloudFile file = sampleDir.GetFileReference("azurefile.txt");

                    // Ensure that the file exists.
                    if (file.Exists())
                    {
                        // Write the contents of the file to the console window.
                        Console.WriteLine(file.DownloadTextAsync().Result);
                    }
                }
            }
        }

        private async void readAsStream()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create a CloudFileClient object for credentialed access to File storage.
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            // Get a reference to the file share we created previously.
            CloudFileShare share = fileClient.GetShareReference("one");

            var ios = new SteramIODemo();

            // Ensure that the share exists.
            if (share.Exists())
            {
                // Get a reference to the root directory for the share.
                CloudFileDirectory rootDir = share.GetRootDirectoryReference();

                // Get a reference to the directory we created previously.
                CloudFileDirectory sampleDir = rootDir.GetDirectoryReference("one");

                // Ensure that the directory exists.
                if (sampleDir.Exists())
                {
                    // Get a reference to the file we created previously.
                    CloudFile file = sampleDir.GetFileReference("employee_po_number.csv");

                    // Ensure that the file exists.
                    if (file.Exists())
                    {
                        using (var stream = await file.OpenReadAsync())
                        {
                            using (var sr = new StreamReader(stream))
                            {
                                int lineIndex = 0;
                                string firstLine = sr.ReadLine();

                                while (!sr.EndOfStream)
                                {
                                    lineIndex = 0;
                                    //Console.WriteLine(sr.ReadLine());
                                    using (var outputstream = new MemoryStream())
                                    {
                                        using (var csvWriter = new StreamWriter(outputstream, Encoding.UTF8))
                                        {
                                            csvWriter.WriteLine(firstLine);

                                            while (lineIndex<limit && !sr.EndOfStream)
                                            {
                                                csvWriter.WriteLine(sr.ReadLine());
                                                lineIndex++;
                                            }

                                            csvWriter.Flush();
                                        }

                                        ios.ReadFromStream(new MemoryStream(outputstream.ToArray()));
                                    }

                                }
                                
                            }
                        }
                    }
                }
            }
        }

    }
}
