using FileManager.Model;
namespace FileManager.DAL.FileManager.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FileManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; 
            MigrationsDirectory = @"FileManager.DAL";
        }

        protected override void Seed(FileManagerContext context)
        {



            //var FileFormats = new List<FileFormat>
            // {
            //     new FileFormat{FormatName = "txt", WhereToCopyFilePath = "D:\\New folder (2)",MinutesIntervalToSyncronize = "5" }

            // };
            // FileFormats.ForEach(s => context.FilesFormats.AddOrUpdate(s));

             //var files = new List<File>
             //{
             //    new File{ FileName ="Test", Size =2, Author = "EU",Owner = "EU",CreatedDate ="20160404",ModifiedDate ="20160505", FileFormatID = FileFormats[0].FileFormatID }
             //};

             //files.ForEach(s => context.Files.AddOrUpdate(s));

             //FileFormats.ForEach(s => context.FilesFormats.AddOrUpdate(s));

        
             //var metadata = new List<Metadata>
             //{
             //    new Metadata{ MetadataName = "NrOfPages", FileFormatID = FileFormats[0].FileFormatID }
             //};

             //metadata.ForEach(s => context.Metadate.AddOrUpdate(s));


             //var metadataValues = new List<MetadataValue>
             //{
             //    new MetadataValue{Value = "5", MetadataID = metadata[0].MetadataID, FileID =files[0].FileID}
            
             //};
             //metadataValues.ForEach(s => context.MetadataValues.AddOrUpdate(s));

            //context.SaveChanges();


      
        }
    }
}
