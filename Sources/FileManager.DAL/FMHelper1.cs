using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FileManager
{
    public static class FMHelper1
    {
        public static void WriteErrorLog(String message)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("C:\\Users\\Mihai\\Desktop\\Log1.txt", true);
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
