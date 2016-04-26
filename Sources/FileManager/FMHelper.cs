using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FileManager
{
    public static class FMHelper
    {
        public static void WriteErrorLog(String message)
        {
            StreamWriter sw = null;

            try
            {
                sw =new StreamWriter("C:\\Users\\chiva\\Desktop\\Log.txt",true);
                sw.WriteLine(DateTime.Now.ToString()+"   "+message);
                sw.Flush();
                sw.Close();
            }
            catch
            {

            }

        }

    }
}
