using FileManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.BL
{
    public class FileService
    {
        private readonly FileRepository _fileRepository;

        public FileService() 
        {
            _fileRepository = new FileRepository();
        }

        public List<Model.Files> GetAllFiles()
        {
            return _fileRepository.GetAllFiles();
        }

        public void InsertFile(string FileName, int size, string Author, string Owner, string CreatedDate, string ModifiedDate, int FileFormatID)
        {
            _fileRepository.InsertFile(FileName, size, Author, Owner, CreatedDate, ModifiedDate, FileFormatID);
        }
    }
}
