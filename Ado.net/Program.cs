using Microsoft.Data.SqlClient;

namespace ADODotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bank;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            var connection = new SqlConnection(conStr);
            //var command = connection.CreateCommand();
            var cmd1 = new SqlCommand("select * from Customers", connection);
            connection.Open();

            var result = cmd1.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    Console.WriteLine(result[1]);
                }
            }

            connection.Close();
        }
    }
}
