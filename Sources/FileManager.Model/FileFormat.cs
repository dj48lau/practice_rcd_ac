using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Model
{
    public class FileFormat
    {
        public int ID { get; set; }
        public string FormatName { get; set; }
        public string WhereToCopyFilePath { get; set; }
        public string MinutesIntervalToSyncronize { get; set; }
        //public virtual ICollection <File> File{ get; set; }


    }
}
