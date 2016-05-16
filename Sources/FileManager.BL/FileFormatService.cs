using FileManager.DAL.FileManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.BL
{
   public class FileFormatService
    {
        private FileFormatRepository _fileFormatRepository;

        public FileFormatService() { 
        _fileFormatRepository = new FileFormatRepository();
        
        }
        public List<Model.FileFormat> GetAllFileFormat() {
            return _fileFormatRepository.GetAllFileFormat();
        
        }

        public void InsertFileFormat(string FormatName, string WhereToCopyFilePath, string MinutesIntervalToSyncronize)
        {

            _fileFormatRepository.InsertFileFormat(FormatName, WhereToCopyFilePath, MinutesIntervalToSyncronize);

        }
        public Boolean FormatExists(String formatName)
        {
            return _fileFormatRepository.FormatExists(formatName);
        }

        public int GetFileFormatID(String formatName)
        {

            return _fileFormatRepository.GetFileFormatID(formatName);

        }

    }
}
