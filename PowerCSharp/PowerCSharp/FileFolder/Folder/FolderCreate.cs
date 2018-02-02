using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.FileFolder.Folder
{
    class FolderCreate
    {
        //How to: Create a File or Folder (C# Programming Guide)
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-create-a-file-or-folder

        public void test()
        {
            // 如果有不存在的目錄(包含子目路)則自動建立
            // Create the subfolder. You can verify in File Explorer that you have this
            // structure in the C: drive.
            //    Local Disk (C:)
            //        Top-Level Folder
            //            SubFolder
            var path = "C:\\Temp\\abc\\efg\\ftp\\2017\\dx.abc";
            Directory.CreateDirectory(path);
        }
    }
}
