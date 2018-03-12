using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.FileFolder
{
    class FileFolder
    {

        private void WriteDebugLog(string type, QueryDog model = null)
        {
            // debug log
            // AppDomain.CurrentDomain.BaseDirectory = Website root folder
            // 如果目錄不存在，則自動建立
            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log"));
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log", "debug.log");
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.AppendLine("Type:" + type);

            sb.AppendLine("MemCached Data:");

            var itemsCheck = dog.Get();
            foreach (var item in itemsCheck)
            {
                sb.AppendLine(string.Format("Name:{0}, Age:{1}", item.name, item.age));
            }

            if (model != null)
            {
                sb.AppendLine("");
                sb.AppendLine("model: ");
                // 把mode資料 轉成一行string
                //sb.AppendLine(DxdJilSerializer.Serialize(model));
            }

            File.AppendAllText(filePath, sb.ToString());
            sb.Clear();
            // debug
        }

    }

    public class dog
    {
        public string name { get; set; }
        public int age { get; set; }

        public static List<dog> Get()
        {
            return new List<dog>(){
                new dog(){ name="dog1", age=1},
                new dog(){ name="dog2", age=2}
            };
        }
    }

    public class QueryDog
    {
        public string name { get; set; }
        public int age { get; set; }
    }
}
