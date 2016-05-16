using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Model
{
    public class MetadataValue
    {
        public int MetaDataValueID { get; set; }
        public string Value { get; set; }
        public int MetadataID { get; set; }
        public int FileID { get; set; }

        public virtual Metadata Metadata { get; set; }
        public virtual Files  File { get; set; }
    }
}
