using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.FileFolder
{
    class MyFile
    {
        //How to: Copy, Delete, and Move Files and Folders (C# Programming Guide)
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-copy-delete-and-move-files-and-folders

        //File.Exists Method (String)
        //https://msdn.microsoft.com/en-us/library/system.io.file.exists(v=vs.110).aspx

        public void test()
        {
            string curFile = @"c:\temp\test.txt";
            Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");

            // Delete a file by using File class static method...
            if (System.IO.File.Exists(@"C:\Users\Public\DeleteTest\test.txt"))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(@"C:\Users\Public\DeleteTest\test.txt");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            // ...or by using FileInfo instance method.
            System.IO.FileInfo fi = new System.IO.FileInfo(@"C:\Users\Public\DeleteTest\test2.txt");
            try
            {
                fi.Delete();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
