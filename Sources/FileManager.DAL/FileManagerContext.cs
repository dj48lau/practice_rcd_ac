using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FileManager.DAL
{
    public class FileManagerContext : DbContext
    {
        public FileManagerContext()
            : base("FileManagerContext")
        { 
        }

        public DbSet<Files> Files { get; set; }
        public DbSet<FileFormat> FilesFormats { get; set; }
        public DbSet<Metadata> Metadate { get; set; }
        public DbSet<MetadataValue> MetadataValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }


    }
}
