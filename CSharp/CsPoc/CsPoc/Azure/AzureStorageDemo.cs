﻿using System;
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
using System.Diagnostics;

namespace CsPoc.Azure
{
    public class AzureStorageDemo
    {
        private CloudStorageAccount saFrom = CloudStorageAccount.Parse("TBD");
        private CloudStorageAccount saTo = CloudStorageAccount.Parse("TBD");
        private const int limit = 10;
        public void Execute()
        {
            //downlaod();
            //readAsStream();
            //copy();
            //readAsStream();
            SetAttribute();
        }

        private void SetAttribute()
        {
           
            CloudFileClient fileClient = saFrom.CreateCloudFileClient();
            CloudFileShare share = fileClient.GetShareReference("jun");
            CloudFileDirectory rootDir = share.GetRootDirectoryReference();
            CloudFile sourceFile = rootDir.GetFileReference("employee_projects_tasks.csv");

            CloudFileClient dfileClient = saTo.CreateCloudFileClient();
            CloudFileShare dshare = dfileClient.GetShareReference("jun");
            CloudFileDirectory drootDir = dshare.GetRootDirectoryReference();
            CloudFile dsourceFile = drootDir.GetFileReference("employee_projects_tasks.csv");

            dsourceFile.FetchAttributes();
            sourceFile.FetchAttributes();
            //dsourceFile.Metadata.Add("IndexVersion", sourceFile.Properties.LastModified.Value.DateTime.Ticks.ToString());
            //dsourceFile.SetMetadata();

            dsourceFile.FetchAttributes();
            string version;
            //if(dsourceFile.Metadata.TryGetValue("", out version))
            Console.WriteLine(dsourceFile.Metadata.TryGetValue("IndexVersion", out version) ? version : "null");
        }


        private void copy()
        {
           

            CloudFileClient fileClient = saFrom.CreateCloudFileClient();
            CloudFileShare share = fileClient.GetShareReference("jun");

            CloudFileDirectory rootDir = share.GetRootDirectoryReference();
            CloudFile sourceFile = rootDir.GetFileReference("employee_projects_tasks.csv");


            CloudFileClient dfileClient = saTo.CreateCloudFileClient();
            CloudFileShare dshare = dfileClient.GetShareReference("jun");

            CloudFileDirectory drootDir = dshare.GetRootDirectoryReference();
            CloudFile dsourceFile = drootDir.GetFileReference("employee_projects_tasks.csv");

            sourceFile.FetchAttributes();
            dsourceFile.FetchAttributes();


            if (!dsourceFile.Exists())
            {
                dsourceFile.Create(0);
            }



            Stopwatch timer = new Stopwatch();
            timer.Start();
            try
            {
                dsourceFile.UploadFromStream(sourceFile.OpenRead());
                //dsourceFile.UploadText(sourceFile.DownloadText());
                //dsourceFile.StartCopy(sourceFile);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            timer.Stop();

            Console.WriteLine("Elapsed" + ": " + timer.ElapsedMilliseconds.ToString());

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
            CloudFileShare share = fileClient.GetShareReference("jun");

            var ios = new SteramIODemo();

            // Ensure that the share exists.
            if (share.Exists())
            {
                // Get a reference to the root directory for the share.
                CloudFileDirectory rootDir = share.GetRootDirectoryReference();

                // Get a reference to the directory we created previously.
                //CloudFileDirectory sampleDir = rootDir.GetDirectoryReference("one");

                // Ensure that the directory exists.
                if (rootDir.Exists())
                {
                    // Get a reference to the file we created previously.
                    CloudFile file = rootDir.GetFileReference("employee_projects_tasks.csv");

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
