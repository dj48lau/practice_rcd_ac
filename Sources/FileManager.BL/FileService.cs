using FileManager.DAL;
using FileManager.Model;
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

        public void InsertFile(string FileName, int size, string Author, string Owner, DateTime CreatedDate, DateTime ModifiedDate, int FileFormatID)
        {
            _fileRepository.InsertFile(FileName, size, Author, Owner, CreatedDate, ModifiedDate, FileFormatID);
        }

        public Boolean FileExists(String fileName, String fileFormatName)
        {
            return _fileRepository.FileExists(fileName, fileFormatName);
        }

        public List<FileViewModel> GetViewModelList()
        {
           
            return _fileRepository.GetViewModelList();
        } 
    }
}
