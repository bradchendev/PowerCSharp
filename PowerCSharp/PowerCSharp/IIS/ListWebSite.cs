using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace PowerCSharp
{
    public static class ListWebSite
    {

        public static void ListLocalIISWebSites()
        {
            foreach (Website site in GetSites("IIS://localhost/W3SVC"))
            {
                Console.WriteLine(string.Concat
                (
                    site.Name, " , ",
                    site.Identity, " , ",
                    site.Status, " , ",
                    site.PhysicalPath
                ));
            }
        }

        private static IEnumerable<Website> GetSites(string Path)
        {
            DirectoryEntry IIsEntities = new DirectoryEntry(Path);

            foreach (DirectoryEntry IIsEntity in IIsEntities.Children)
            {
                if (IIsEntity.SchemaClassName == "IIsWebServer")
                {
                    yield return new Website
                    (
                        Convert.ToInt32(IIsEntity.Name),
                        IIsEntity.Properties["ServerComment"].Value.ToString(),
                        GetPath(IIsEntity),
                        (ServerState)IIsEntity.Properties["ServerState"].Value
                    );
                }
            }
        }

        private static string GetPath(DirectoryEntry IIsWebServer)
        {
            foreach (DirectoryEntry IIsEntity in IIsWebServer.Children)
            {
                if (IIsEntity.SchemaClassName == "IIsWebVirtualDir")
                    return IIsEntity.Properties["Path"].Value.ToString();
            }
            return null;
        }

    }

    public class Website
    {
        public int Identity { get; set; }
        public string Name { get; set; }
        public string PhysicalPath { get; set; }
        public ServerState Status { get; set; }

        public Website(int p1, string p2, string p3, ServerState serverState)
        {
            // TODO: Complete member initialization
            this.Identity = p1;
            this.Name = p2;
            this.PhysicalPath = p3;
            this.Status = serverState;
        }

    }

    public enum ServerState
    {
        Starting = 1,
        Started = 2,
        Stopping = 3,
        Stopped = 4,
        Pausing = 5,
        Paused = 6,
        Continuing = 7
    }

}
