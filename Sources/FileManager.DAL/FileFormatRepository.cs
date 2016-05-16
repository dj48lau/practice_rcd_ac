using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Model;

namespace FileManager.DAL.FileManager.DAL
{
    public class FileFormatRepository
    {
        private FileManagerContext _dbContext;

        public FileFormatRepository() 
        {

            _dbContext = new FileManagerContext();

        }
        public List<Model.FileFormat> GetAllFileFormat() {


            return _dbContext.FilesFormats.ToList();
        
        }

        public void InsertFileFormat(string FormatName, string WhereToCopyFilePath, string MinutesIntervalToSyncronize)
        {
            FileFormat fileFormat = new FileFormat();
            fileFormat.FormatName = FormatName;
            fileFormat.WhereToCopyFilePath = WhereToCopyFilePath;
            fileFormat.MinutesIntervalToSyncronize = MinutesIntervalToSyncronize;
            _dbContext.FilesFormats.Add(fileFormat);
            _dbContext.SaveChanges();

        }

        public Boolean FormatExists(String formatName)
        {
            Boolean formatExists = false;
            List<Model.FileFormat> formats = _dbContext.FilesFormats.ToList();
            foreach (Model.FileFormat format in formats)
            {
                if (format.FormatName.Equals(formatName))
                {
                    formatExists = true;
                }
            }
            return formatExists;
        }

        public int GetFileFormatID(String formatName)
        {
            int formatID = 0;
            List<Model.FileFormat> formats = _dbContext.FilesFormats.ToList();
            foreach (Model.FileFormat format in formats)
            {
                if (format.FormatName.Equals(formatName))
                {
                    formatID = format.ID;
                }
            }
            return formatID;

        }


    }
}
