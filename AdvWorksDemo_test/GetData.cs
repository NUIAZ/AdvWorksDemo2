using System.Data;
using Microsoft.Data.SqlClient;

namespace AdvWorksDemo_test
{
    /// <summary>
    /// Class comment: This class is used to get data from the database using ADO.NET
    /// </summary>
    internal class GetData
    {
        /// <summary>
        /// Method comment: This method is used to get data from the database using ADO.NET
        /// </summary>
        /// <param name="title"></param>
        public static void GetCustomerData(int title)
        {
            try
            {
                Console.WriteLine("Reached getData method.");

                using SqlConnection conn = new ("Data Source=.;Initial Catalog=AdventureWorksLT2017;Integrated Security=true;TrustServerCertificate=true");
                conn.Open();

                using SqlCommand cmd = new("[dbo].[SELECT_customer_title]", conn);

                cmd.Parameters.AddWithValue("@title", title);
                cmd.CommandType = CommandType.StoredProcedure;

                var reader = cmd.ExecuteReader();

                int numRows = 0;
                if (reader.HasRows)
                {
                    Console.WriteLine("Reached Reader Rows Returned.");
                    Console.WriteLine("___________________________");

                    while (reader.Read())
                    {
                        numRows++;
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    }

                    Console.WriteLine("___________________________");
                    Console.WriteLine("Number of rows: " + numRows + ".");

                    reader.Close();
                    InsertAudit(title, numRows);
               
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message + ".");
            }
        }

        /// <summary>
        /// Method comment: This method is used to insert data into the audit table
        /// </summary>
        /// <param name="input"></param>
        /// <param name="rowCount"></param>
        static void InsertAudit(int input, int rowCount)
        {
            try
            {
                Console.WriteLine("Reached Insert Audit.");

                //insert into our audit table
                using SqlConnection conn = new ("Data Source=.;Initial Catalog=AdventureWorksLT2017;Integrated Security=true;TrustServerCertificate=true");
                conn.Open();

                using SqlCommand cmd = new("[dbo].[INSERT_AuditSample]", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TitleNumberInput", input);
                cmd.Parameters.AddWithValue("@OutputRowCount", rowCount);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message + ".");
            }
        }
     
    }
}
