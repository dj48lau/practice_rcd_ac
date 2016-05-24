using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Model;
using FileManager.DAL.FileManager.DAL;

namespace FileManager.DAL
{
    public class FileRepository
    {
        public FileFormatRepository _fileFormatRepository = new FileFormatRepository();
        private readonly FileManagerContext _dbContext;

        public FileRepository() 
        {
            _dbContext = new FileManagerContext();
        }

        
        public List<Model.Files> GetAllFiles()
        {
            return _dbContext.Files.ToList();
        }

        public void InsertFile(string FileName, int size, string Author, string Owner, DateTime CreatedDate, DateTime ModifiedDate, int FileFormatID)
        {
            Files file = new Files();
            file.FileName = FileName;
            file.Size = size;
            file.Author = Author;
            file.Owner = Owner;
            file.CreatedDate = CreatedDate;
            file.ModifiedDate = ModifiedDate;
            file.FileFormatID = FileFormatID;
            _dbContext.Files.Add(file);
            _dbContext.SaveChanges();
       }



        public Boolean FileExists(String fileName, String fileFormatName)
        {
            Boolean fileExists=false;
            List<Model.Files> files = _dbContext.Files.ToList();
            foreach (Model.Files file in files)
            {
                if (file.FileName.Equals(fileName) && _fileFormatRepository.GetFileFormatName(file.FileFormatID).Equals(fileFormatName))
                {
                    fileExists = true;
                }
            }
            return fileExists;

        }

        public List<FileViewModel> GetViewModelList()
        {
            List<FileViewModel> fileViewModel =new List<FileViewModel>();
            List<Model.Files> files = GetAllFiles();

            foreach (Files f in files)
            {
                fileViewModel.Add( new FileViewModel(f.ID, f.FileName, f.CreatedDate, _fileFormatRepository.GetFileFormatName(f.FileFormatID)));

            }
            return fileViewModel;
        } 

    }
}
