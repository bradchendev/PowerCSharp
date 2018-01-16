using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.FileFolder
{

    public class Log
    {

        public static void Write(string msg)
        {
            // debug log
            // AppDomain.CurrentDomain.BaseDirectory = Website root folder
            // 如果目錄不存在，則自動建立
            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log"));

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log", "debug.log");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.AppendLine("DateTime:" + DateTime.Now.ToString());
            sb.AppendLine(msg);

            File.AppendAllText(filePath, sb.ToString());
            sb.Clear();
            // debug
        }

    }
}
