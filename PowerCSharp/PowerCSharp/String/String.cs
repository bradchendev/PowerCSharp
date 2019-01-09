using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PowerCSharp.String
{
    class String
    {
        public void removeSpace()
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.string.trim?redirectedfrom=MSDN&view=netframework-4.7.2#System_String_Trim
            //String.Trim() returns a string which equals the input string with all white-spaces trimmed from start and end:
            string a = "   A String   ".Trim();
                 //-> "A String"

            //String.TrimStart() returns a string with white-spaces trimmed from the start:
            string b = "   A String   ".TrimStart();
                //-> "A String   "

            //String.TrimEnd() returns a string with white-spaces trimmed from the end:
            string c = "   A String   ".TrimEnd();
                //-> "   A String"
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }

        // 使用substring (參數是 zero-base)
        // substring只用一個參數，就是讀取到字尾
        public void Left_right()
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?redirectedfrom=MSDN&view=netframework-4.7.2#System_String_Substring_System_Int32_System_Int32_

            string value = "This is a string.";
            int startIndex = 5;
            int length = 2;
            string substring = value.Substring(startIndex, length);
            Console.WriteLine(substring);
            // The example displays the following output:
            //       is


            // 讀取到字尾
            string substring2 = value.Substring(startIndex);
            Console.WriteLine(substring2);
            //       is a string.
        }

        /// <summary>
        /// 透過fname與lname組成userid，只保留英文字
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <returns></returns>
        private string ComposeUserId(string fname, string lname)
        {
            string uid = "";
            string uidTmp = string.Format("{0}{1}", fname.Trim().ToLower(), lname.Trim().ToLower());
            uidTmp = uidTmp.Substring(0, 40);
            foreach (char c in uidTmp)
            {
                bool isAlphaBet = Regex.IsMatch(c.ToString(), "[a-z]", RegexOptions.IgnoreCase);
                if (isAlphaBet)
                {
                    uid += c;
                }
            }
            return uid;
        }

        public void replaceDoubleQuotes()
        {
            string str = "it is a \"text\"";
            string str_without_quotes = str.Replace("\"", "");
        }

        public void stringBuilder()
        {
            //Using the StringBuilder Class in .NET
            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/stringbuilder
            StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
            MyStringBuilder.Append(" What a beautiful day.");
            Console.WriteLine(MyStringBuilder);
        }

        public void stringJoinReplace()
        {

            List<string> lists = new List<string>() { "aaaa", "bbbb" };
            Console.WriteLine(string.Join(",", lists));
            // output is aaaa, bbbb

            Console.WriteLine(string.Format("'{0}'", string.Join("','", lists.Select(i => i.Replace("'", "''")).ToArray())));
            // output is 'aaaa','bbbb'
        }

        public void splitString()
        {
            string userDomainName = @"CONTOSO\bradchen";

            string[] user = userDomainName.Split(new string[] { @"\" }, StringSplitOptions.None);

            Console.WriteLine(user[0]);
            Console.WriteLine(user[1]);

            string str = "abc(contoso\\bradchen)";
            int start = str.IndexOf('(');
            int end = str.IndexOf(')');
            string s2 = str.Substring(start + 1, end - start - 1);
            Console.WriteLine(s2);

            Console.WriteLine(s2.Substring(s2.IndexOf('\\') + 1));
            Console.WriteLine(s2.Substring(0, s2.IndexOf('\\')));


            string LuaFileFullPath = "E:\\Web\\API\\Solutions\\Solution01\\App_Data\\scripts\\CtrlDbTime.lua";

            // 取得本機Lua檔
            string text = File.ReadAllText(LuaFileFullPath, Encoding.GetEncoding(950));
            // 檢查目前設定是否為分流DB
            var isReplCurrent = text.Contains("dbname = \"TPEREPL2\"");

            // 用參數傳入
            //string input = "TPEREPL2";
            //string find = "dbname = \"" + input + "\"";
            ////string find = "dbname = \"TPEREPL2\"";
            //// 檢查目前設定是否為分流DB
            //var isReplCurrent = text.Contains(find);




            LuaFileFullPath = "E:\\Web\\API\\Solutions\\Solution01\\App_Data\\scripts\\CtrlDbTime.lua";

            LuaFileFullPath = LuaFileFullPath.Replace("E:\\Web\\API\\Solutions\\", "").Replace("\\App_Data\\scripts\\CtrlDbTime.lua", "");
            Console.WriteLine(LuaFileFullPath);




        }

        /// <summary>
        /// Guid
        /// </summary>
        public void getSpecialString()
        {
            //byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            //byte[] key = Guid.NewGuid().ToByteArray();
            //string token = Convert.ToBase64String(time.Concat(key).ToArray());

            //for (int i = 0; i < 10; i++)
            //{
            //    //time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            //    //key = Guid.NewGuid().ToByteArray();
            //    //token = Convert.ToBase64String(time.Concat(key).ToArray());

            //    // f64e986412554cdb8542981b974bc260
            //    //Console.WriteLine(Guid.NewGuid().ToString("N"));

            //    // 91e3446d-4f7c-444e-ae2b-36121b9deea6
            //    Console.WriteLine(Guid.NewGuid().ToString());
            //    System.Threading.Thread.Sleep(2000);
            //}
        }

        public void getComputerName()
        {
            Console.WriteLine(System.Environment.MachineName);

            // using System.Net;
            string hostName = Dns.GetHostName();
            Console.WriteLine("Computer name :" + hostName);
        }
    }
}
