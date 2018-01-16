using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.FileFolder.ConfigFile
{
    // 如果是Console Application
    //  佈署的時候，若直接複製exe與App.config檔案到特定位置，則需要指定位置
    //   不然ConfigurationManager.AppSettings會讀不到
    // AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"C:\service\ConsoleApplication1\App.config");

    // using System.Configuration;
    class App
    {

        private string GetAppConfigValue()
        {
            return ConfigurationManager.AppSettings["Debug"];
        }
    }
}
