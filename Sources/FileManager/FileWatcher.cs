using FileManager.Model;
using FileManager.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace FileManager
{
    class FileWatcher
    {
        private static String targetDirectoryPath = ConfigurationManager.AppSettings["DropFolderPath"];
        private static String destinationFolderPath = "C:\\Users\\a.chiva\\Desktop\\destinationFolder";
        private static String destinationSubFolderPath;
        private static String destinationFilePath;

        public static void FileWatcherInitialisation()
        {
            FMHelper.WriteErrorLog(" inceput functie fs");
            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = targetDirectoryPath;

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Filter = "*.*";

            watcher.Created += new FileSystemEventHandler(OnChanged);

            watcher.EnableRaisingEvents = true;

            FMHelper.WriteErrorLog("final functie fs");

        }

       

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
           // FMHelper.WriteErrorLog("intra in onchanged");
            String extension;

            FileService _fileServices = new FileService();
            FileFormatService _fileFormatServices = new FileFormatService();
            MetadataService _metadataServices = new MetadataService();

            String str = e.FullPath;
            Thread.Sleep(5000);
            if (e.ChangeType.ToString().Equals("Created"))
            {
                //FMHelper.WriteErrorLog("intra in on created");

                String fileName = Path.GetFileNameWithoutExtension(str);
                Boolean formatExists = false;
                extension = Path.GetExtension(str);
                DateTime creationDate = File.GetCreationTime(str);
                DateTime modifiedDate = File.GetLastWriteTime(str);
                String owner = File.GetAccessControl(str).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                int fileSize = (int)new System.IO.FileInfo(str).Length;
                extension = extension.Substring(1, (extension.Length - 1));

                destinationSubFolderPath = destinationFolderPath + "\\" + extension;
                destinationFilePath = destinationSubFolderPath + "\\" + fileName + "." + extension;



                if (Directory.Exists(destinationSubFolderPath))
                {
                    formatExists = _fileFormatServices.FormatExists(extension);


                    if (_fileServices.FileExists(fileName, extension))
                    {
                        fileName = fileName + "_" + DateTime.Now.ToString(" dd MM yyyy hh-mm");
                        destinationFilePath = destinationSubFolderPath + "\\" + fileName + "." + extension;
                        _fileServices.InsertFile(fileName, fileSize, "", owner, creationDate, modifiedDate, _fileFormatServices.GetFileFormatID(extension));
                        _metadataServices.InsertMatadata("nrofpages", 1);

                    }
                    else
                    {
                        _fileServices.InsertFile(fileName, fileSize, "", owner, creationDate, modifiedDate, _fileFormatServices.GetFileFormatID(extension));
                        _metadataServices.InsertMatadata("nrofpages", 1);
                    }

                    MoveAsync(str, destinationFilePath);

                }
                else
                {
                    Directory.CreateDirectory(destinationSubFolderPath);

                    if (!_fileFormatServices.FormatExists(extension))
                    {

                        _fileFormatServices.InsertFileFormat(extension, destinationSubFolderPath, "10");
                    }

                    _fileServices.InsertFile(fileName, fileSize, "", owner, creationDate, modifiedDate, _fileFormatServices.GetFileFormatID(extension));
                    _metadataServices.InsertMatadata("nrofpages", 1);

                    MoveAsync(str, destinationFilePath);
                }

            }
            FMHelper.WriteErrorLog("File: " + e.FullPath + " " + e.ChangeType);
        }


        public static Task MoveAsync(string sourceFileName, string destFileName)
        {


            return Task.Run(() => { File.Move(sourceFileName, destFileName); });
        }


        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            FMHelper.WriteErrorLog("File: " + e.OldFullPath + "renamed to {1}" + e.FullPath);
        }

       

    }
}
