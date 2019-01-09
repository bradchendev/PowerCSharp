using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.Database
{
    class BulkInsert
    {
        public void test1()
        {
            //DataTable workTable = new DataTable("DalServiceStatus");
            //DataColumn workCol = workTable.Columns.Add("Sn", typeof(Int32));
            //workCol.AllowDBNull = false;
            //workCol.Unique = true;

            //DataColumn workCol = workTable.Columns.Add("DalServerSn", typeof(Int32));
            //workTable.Columns.Add("WebSiteId", typeof(Int64));
            //workTable.Columns.Add("WebSiteName", typeof(String));
            //workTable.Columns.Add("WebSiteState", typeof(Int32));
            //workTable.Columns.Add("AppFolder", typeof(String));
            //workTable.Columns.Add("AppFolderLastM", typeof(DateTime));

            //DataRow workRow;
            //for (int i = 0; i < param.InsDataItems.Count; i++)
            //{
            //    workRow = workTable.NewRow();
            //    workRow["DalServerSn"] = param.InsDataItems[i].DalServerSn;
            //    workRow["WebSiteId"] = param.InsDataItems[i].WebSiteId;
            //    workRow["WebSiteName"] = param.InsDataItems[i].WebSiteName;
            //    workRow["WebSiteState"] = param.InsDataItems[i].WebSiteState;
            //    workRow["AppFolder"] = param.InsDataItems[i].AppFolder;
            //    workRow["AppFolderLastM"] = param.InsDataItems[i].AppFolderLastM;
            //    workTable.Rows.Add(workRow);
            //}  

        }

        // 自動將list轉成DataTable
        public void test2() 
        {

            var MyList = new List<ServiceStatusModelItem>()
            {
                new ServiceStatusModelItem(){ DalServerSn = 1, WebSiteId = 1, WebSiteName ="test", WebSiteState = 1, AppFolder = "D:\\test1", AppFolderLastM = DateTime.Now },
                new ServiceStatusModelItem(){ DalServerSn = 2, WebSiteId = 1, WebSiteName ="test2", WebSiteState = 1, AppFolder = "D:\\test2", AppFolderLastM = DateTime.Now},
            };

            //using System.Data.SqlClient;
            //using (SqlConnection destinationConnection = new SqlConnection(GetConnectionString()))
            //{
            //    destinationConnection.Open();

            //    using (SqlBulkCopy bulkCopy =
            //               new SqlBulkCopy(destinationConnection))
            //    {
            //        bulkCopy.DestinationTableName = "dbo.DalServiceStatus";

            //        bulkCopy.ColumnMappings.Add("DalServerSn", "DalServerSn");
            //        bulkCopy.ColumnMappings.Add("WebSiteId", "WebSiteId");
            //        bulkCopy.ColumnMappings.Add("WebSiteName", "WebSiteName");
            //        bulkCopy.ColumnMappings.Add("WebSiteState", "WebSiteState");
            //        bulkCopy.ColumnMappings.Add("AppFolder", "AppFolder");
            //        bulkCopy.ColumnMappings.Add("AppFolderLastM", "AppFolderLastM");

            //        try
            //        {
            //            var dataTable = ToDataTable<ServiceStatusModelItem>(MyList);

            //            // Write from the source to the destination.
            //            bulkCopy.WriteToServer(dataTable);
            //        }
            //        catch (Exception ex)
            //        {
            //            //Console.WriteLine(ex.Message);
            //            throw;
            //        }
            //    }
            //}

        }

        private static string GetConnectionString()
        // To avoid storing the sourceConnection string in your code, 
        // you can retrieve it from a configuration file. 
        {
            return "Data Source=DEV1; " +
                " Integrated Security=true;" +
                "Initial Catalog=TWDALSYS;";
        }

        // 將List資料自動轉成DataTable
        //  https://stackoverflow.com/questions/18100783/how-to-convert-a-list-into-data-table
        // using System.Data;, using System.Reflection;
        //public static DataTable ToDataTable<T>(List<T> items)
        //{
        //    DataTable dataTable = new DataTable(typeof(T).Name);

        //    //Get all the properties
        //    PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (PropertyInfo prop in Props)
        //    {
        //        //Defining type of data column gives proper data table 
        //        var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
        //        //Setting column names as Property names
        //        dataTable.Columns.Add(prop.Name, type);
        //    }
        //    foreach (T item in items)
        //    {
        //        var values = new object[Props.Length];
        //        for (int i = 0; i < Props.Length; i++)
        //        {
        //            //inserting property values to datatable rows
        //            values[i] = Props[i].GetValue(item, null);
        //        }
        //        dataTable.Rows.Add(values);
        //    }
        //    //put a breakpoint here and check datatable
        //    return dataTable;
        //}

        public class ServiceStatusModelItem
        {
            public int DalServerSn { get; set; }

            public long WebSiteId { get; set; }

            public string WebSiteName { get; set; }

            public int WebSiteState { get; set; }

            public string AppFolder { get; set; }

            public DateTime AppFolderLastM { get; set; }
        }
    }
}
