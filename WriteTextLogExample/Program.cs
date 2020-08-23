using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteTextLogExample
{
    class Program
    {
        /* 
             * there are a few options of openning and reading a file.
             * The best practice way of working with files in the .NET Framework is using
             * the SystemIO lib :https://docs.microsoft.com/en-us/dotnet/api/system.io?view=netframework-4.7.2
             * You can use Stream Reader and Writer. but in that case you must remember to close the stream (using() or finally)
             * I personaly prefere using the static functions of the class 'File'. (https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=netframework-4.7.2)
        */
        static void Main(string[] args)
        {
            //the file name. the full path is in the install folder (where the exe is)
            const string fileName = "ErorrLog";
            //when working with files you must understand that there are many problems we can't expect.
            //for example trying to read a file that the user deleted or modified

            //here is an example on trying to divied by zero, wich will trow an exaption that we will catch and write the message to a txt file
            try
            {
                int x = 5;
                int y = 0;
                int res = x / y;
            }
            catch (Exception e)
            {
                //this command will write the e.Message to the file (fileName). it will overwrite the file not add to it
                //this method will create the file if it can't find it.
                //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealltext?view=netframework-4.7.2
                File.WriteAllText(fileName, e.Message);

                //another way is to append data to a file.
                //this will not! overwrite the log file.
                //this method will create the file if it can't find it.
                //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.appendalltext?view=netframework-4.7.2
                File.AppendAllText(fileName, e.Message);
            }

        }
    }
}
