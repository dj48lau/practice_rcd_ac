using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.DAL;

namespace FileManager.BL
{
    public class MetadataService
    {
        MetadataRepository _metadataRepository;
        public MetadataService() 
        {

            _metadataRepository = new MetadataRepository();
        }

        public void InsertMatadata(String MetadataName, int fileFormatID)
        {

            _metadataRepository.InsertMetadata(MetadataName,fileFormatID);
        
        }

        public List<Model.Metadata> GetAllMetadata() 
        {
           return _metadataRepository.GetAllMetadata();
        }

    }
}
