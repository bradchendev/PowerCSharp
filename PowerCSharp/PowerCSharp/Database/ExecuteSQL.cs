using System;
using System.Collections.Generic;
using System.Data;
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

        public static string ExecuteSP()
        {

            string returnString = "";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "uspInsUpdTable1";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@sn", SqlDbType.Int);
                cmd.Parameters["@sn"].Value = 9999998;

                cmd.Parameters.Add("@eventId", SqlDbType.BigInt);
                cmd.Parameters["@eventId"].Value = 2;

                try
                {
                    conn.Open();
                    returnString = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }

            return returnString;

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
