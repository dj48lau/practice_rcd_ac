using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FileManager.Model
{
    public class Files
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public int Size { get; set; }
        public string Author { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int FileFormatID { get; set; }
        public virtual FileFormat FileFormat { get; set; }




    }
}
