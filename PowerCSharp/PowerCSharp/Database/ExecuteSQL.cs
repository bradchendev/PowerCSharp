using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.Database
{
    class ExecuteSQL
    {

        // using System.Data.SqlClient;
        private static void TruncateTable()
        {
            string queryString = "TRUNCATE TABLE dbo.Table1";
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static string GetConnectionString()
        // To avoid storing the sourceConnection string in your code, 
        // you can retrieve it from a configuration file. 
        {
            return "Data Source=DEV1; " +
                " Integrated Security=true;" +
                "Initial Catalog=TWDALSYS;";
        }
    }
}
