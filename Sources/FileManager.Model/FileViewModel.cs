using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Model
{
    public class FileViewModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public DateTime CreationDate { get; set; }
        public String FormatName { get; set; }

        public FileViewModel(int ID, string Name, DateTime CreationDate, String FormatName)
        {
            this.ID = ID;
            this.Name = Name;
            this.CreationDate = CreationDate;
            this.FormatName = FormatName;
        }
    }
}
