using FileManager.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FileService fileService = new FileService();
            var listOfFiles = fileService.GetAllFiles();
            Console.WriteLine("The number of File is:" + listOfFiles.Count);
            //Console.ReadLine();

            FileFormatService fileFormatService = new FileFormatService();
            var listOfFileFormat = fileFormatService.GetAllFileFormat();
            Console.WriteLine("The number of fileFormats is " + listOfFileFormat.Count);

           // DBOperationsServices op = new DBOperationsServices();
           // op.InsertFile("test",500,"eu","eu","10","22",1);

            MetadataService ms = new MetadataService();
            ms.InsertMatadata("nrofpages",1);

            Console.ReadLine();
        }
    }
}
