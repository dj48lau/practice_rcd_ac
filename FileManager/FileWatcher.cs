using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FileManager
{
    class FileWatcher
    {
        private static String targetDirectoryPath = ConfigurationManager.AppSettings["DropFolderPath"];
        private static String destinationFolderPath = "C:\\Users\\chiva\\Desktop\\destinationfolder";
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

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            FMHelper.WriteErrorLog("final functie fs");

        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {  
            String extension;
            // Specify what is done when a file is changed, created, or deleted.
            string[] fileEntries = Directory.GetFiles(targetDirectoryPath);
            String str = e.FullPath;
            FMHelper.WriteErrorLog("QQq ---- " + str);
            if (e.ChangeType.ToString().Equals("Created"))
            {

                FMHelper.WriteErrorLog("a intrat in if");
                extension = Path.GetExtension(str);
                extension = extension.Substring(1, (extension.Length - 1));
                destinationSubFolderPath = destinationFolderPath + "\\" + extension;
                destinationFilePath = destinationSubFolderPath + "\\" + e.Name;
                if (Directory.Exists(destinationSubFolderPath))
                {
                    MoveAsync(str, destinationFilePath);
                    FMHelper.WriteErrorLog("Mutat: -  " + str + "\n in   -" + destinationSubFolderPath);

                }
                else
                {
                    Directory.CreateDirectory(destinationSubFolderPath);
                    MoveAsync(str, destinationFilePath);
                    FMHelper.WriteErrorLog("Mutat: -  " + str + "\n in   -" + destinationSubFolderPath);
                }
                destinationFilePath = "";
                destinationSubFolderPath = "";
                extension = "";
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
