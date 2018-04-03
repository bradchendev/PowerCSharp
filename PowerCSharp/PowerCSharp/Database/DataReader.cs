using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.Database
{
    /// <summary>
    /// Improving .NET Application Performance and Scalability
    /// J.D. Meier, Srinath Vasireddy, Ashish Babbar, and Alex Mackman
    /// Microsoft Corporation May 2004
    /// https://msdn.microsoft.com/en-us/library/ff647768.aspx#scalenetchapt12_topic10
    /// 
    /// </summary>

    class MyDataReader
    {
        public class ClientBasic
        {
            public int Sn { get; set; }
            public string Fname { get; set; }
            public string Lname { get; set; }
            public DateTime birthday { get; set; }
            public int Age { get; set; }
        }

        public ClientBasic getClientInfo(int Sn)
        {
            var client = new ClientBasic();

            //var connString = ConfigurationManager.ConnectionStrings["MyDb1"].ConnectionString;
            var connString = "server=SQL1;Integrated Security=SSPI;database=MyDb1";
            SqlConnection connection = new SqlConnection(connString);
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "select Fname, Lname, birthday, age from dbo.clients where sn = " + Sn,
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                        //    reader.GetString(1));
                        client.Fname = reader.GetString(0);
                        client.Lname = reader.GetString(1);
                        client.Age = reader.GetInt32(3);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
            return client;
        }



        public SqlDataReader RetrieveRowsWithDataReader()
        {
            // using System.Data;
            // using System.Data.SqlClient;
            SqlConnection conn = new SqlConnection(
                   "server=(local);Integrated Security=SSPI;database=northwind");
            SqlCommand cmd = new SqlCommand("RetrieveProducts", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                // Generate the reader. CommandBehavior.CloseConnection causes
                // the connection to be closed when the reader object is closed.
                return (cmd.ExecuteReader(CommandBehavior.CloseConnection));
            }
            finally
            {
                if (null != conn)
                    conn.Close();
            }
        }

        // Display the product list using the console.
        private void DisplayProducts()
        {
            SqlDataReader reader = RetrieveRowsWithDataReader();
            try
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1}",
                                      reader.GetInt32(0).ToString(),
                                      reader.GetString(1));
                }
            }
            finally
            {
                if (null != reader)
                    reader.Close(); // Also closes the connection due to the CommandBehavior
                // enumerator used when generating the reader.
            }
        }
    }
}
