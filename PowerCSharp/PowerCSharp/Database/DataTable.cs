using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.Database
{
    class DataTable
    {
        private static void test()
        {
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(GetConnectionString());
            var query = "select [Id], [ProductName] from [dbo].[Orders] where [Id] between 4500000 and 5000000";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();

            foreach (DataRow od in dataTable.Rows)
            {

                Console.WriteLine(od["ProductName"].ToString());
            }

        }

        private static string GetConnectionString()
        // To avoid storing the sourceConnection string in your code, 
        // you can retrieve it from a configuration file. 
        {
            return "Data Source=DEV1; " +
                " Integrated Security=true;" +
                "Initial Catalog=AdventureWorks2008R2;";

            //return "Data Source=DEV1; " +
            //    "Initial Catalog=AdventureWorks2008R2;" +
            //    "User ID=App1User;" +
            //    "Password=NaJfHonijAT1;" +
            //    "Connection Timeout=60; " +
            //    "Application Name=App1;";

        }
    }

}
