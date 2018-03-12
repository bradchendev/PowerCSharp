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
