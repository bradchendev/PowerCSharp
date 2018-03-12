using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
// C:\Windows\System32\inetsrv\Microsoft.Web.Administration.dll

namespace PowerCSharp
{
    public static class ListWebSite2
    {

        public static void ListWebSites()
        {
            ServerManager IIS = new ServerManager();

            foreach (Site site in IIS.Sites)
            {
                Console.WriteLine(string.Concat
                (
                    site.Name, " , ",
                    site.Id, " , ",
                    site.State, " , ",
                    site.Applications["/"].VirtualDirectories[0].PhysicalPath
                ));
            }
        }
    }
}
