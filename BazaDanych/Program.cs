using System;
using System.Data.SqlClient;

namespace BazaDanych
{
    class Program
    {
        static void Main(string[] args)
        {

            var conectionString = @"Data Source=MIKO-LAPTOP;Initial Catalog=ZNorthwind;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conectionString);
            using (var c1 = new SqlConnection())
            {
                // var.wynki
            }
            connection.Open();
            var db = new DB();
            db.Insert(connection, "ABCDE", "Firma1");
            db.Update(connection, "ABCDE", "Firma2");
            db.Delete(connection, "ABCDE");
            db.Select(connection);
            connection.Close();

        }
    }
}