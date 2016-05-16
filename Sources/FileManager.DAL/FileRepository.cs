using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Model;
namespace FileManager.DAL
{
    public class FileRepository
    {
        private readonly FileManagerContext _dbContext;

        public FileRepository() 
        {
            _dbContext = new FileManagerContext();
        }

        
        public List<Model.Files> GetAllFiles()
        {
            return _dbContext.Files.ToList();
        }

        public void InsertFile(string FileName, int size, string Author, string Owner, string CreatedDate, string ModifiedDate, int FileFormatID)
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

        public void SearchByFileName(String fileName) 
        { 
            
        
        }

    }
}
