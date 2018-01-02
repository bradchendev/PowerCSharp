﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.String
{
    class String
    {
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

            LuaFileFullPath = "E:\\Web\\API\\Solutions\\Solution01\\App_Data\\scripts\\CtrlDbTime.lua";

            LuaFileFullPath = LuaFileFullPath.Replace("E:\\Web\\API\\Solutions\\", "").Replace("\\App_Data\\scripts\\CtrlDbTime.lua", "");
            Console.WriteLine(LuaFileFullPath);




        }

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
