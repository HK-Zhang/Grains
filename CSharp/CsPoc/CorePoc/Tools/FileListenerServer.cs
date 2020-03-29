using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CorePoc.Tools
{
    public class FileListenerServer
    {
        private FileSystemWatcher _watcher;
        public FileListenerServer()
        {
        }
        public FileListenerServer(string path)
        {

            try
            {

                this._watcher = new FileSystemWatcher();
                _watcher.Path = path;
                _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.DirectoryName;
                _watcher.IncludeSubdirectories = true;
                _watcher.Created += new FileSystemEventHandler(FileWatcher_Created);
                _watcher.Changed += new FileSystemEventHandler(FileWatcher_Changed);
                _watcher.Deleted += new FileSystemEventHandler(FileWatcher_Deleted);
                _watcher.Renamed += new RenamedEventHandler(FileWatcher_Renamed);

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }


        public void Start()
        {

            this._watcher.EnableRaisingEvents = true;
            Console.WriteLine("File monitor started...");

        }

        public void Stop()
        {

            this._watcher.EnableRaisingEvents = false;
            this._watcher.Dispose();
            this._watcher = null;

        }

        protected void FileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("add:" + e.ChangeType + ";" + e.FullPath + ";" + e.Name);

        }
        protected void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("change:" + e.ChangeType + ";" + e.FullPath + ";" + e.Name);
        }
        protected void FileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("delete:" + e.ChangeType + ";" + e.FullPath + ";" + e.Name);
        }
        protected void FileWatcher_Renamed(object sender, RenamedEventArgs e)
        {

            Console.WriteLine("rename: OldPath:{0} NewPath:{1} OldFileName{2} NewFileName:{3}", e.OldFullPath, e.FullPath, e.OldName, e.Name);

        }

    }
}
