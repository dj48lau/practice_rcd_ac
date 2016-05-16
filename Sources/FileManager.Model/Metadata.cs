using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Model
{
    public class Metadata
    {
        public int MetadataID { get; set; }
        public string  MetadataName { get; set; }
        public int FileFormatID { get; set; }
    }
}
