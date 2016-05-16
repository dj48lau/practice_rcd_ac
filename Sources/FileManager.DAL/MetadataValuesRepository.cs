using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Model;


namespace FileManager.DAL.FileManager.DAL
{
    class MetadataValuesRepository
    {
        FileManagerContext _dbContext;

        public MetadataValuesRepository() 
        {
            _dbContext = new FileManagerContext();
        
        }

        public void InsertMetadataValues(String value,int metadataID,int FileID)
        {
           MetadataValue metadataValue = new MetadataValue();
            metadataValue.Value = value;
            metadataValue.MetadataID = metadataID;
            metadataValue.FileID = FileID;
            _dbContext.MetadataValues.Add(metadataValue);
            _dbContext.SaveChanges();
        
        
        }

    }
}
