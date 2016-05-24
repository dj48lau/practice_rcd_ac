using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Model;

namespace FileManager.DAL
{
   public  class MetadataRepository
    {
        public static FileManagerContext _dbContext;

        public MetadataRepository()
        {
          _dbContext = new FileManagerContext();

        }

        public List<Model.Metadata> GetAllMetadata()
        {
            return _dbContext.Metadate.ToList();
        }


        public void InsertMetadata(String MetadataName, int FileFormatID) 
        {
            Metadata metadata = new Metadata();
            metadata.MetadataName = MetadataName;
            metadata.FileFormatID = FileFormatID;
            _dbContext.Metadate.Add(metadata);
            _dbContext.SaveChanges();

        }

       // public void SearchMetadata() 
        //{ 
        //   String str = (from Metadata in _dbContext.Metadate where Metadata.MetadataName.Contains)
        
        //}
    }
}
