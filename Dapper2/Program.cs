using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Dapper2
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDbConnection connection = new SqlConnection();
            SqlConnection connection;
            using (connection = new SqlConnection(@"Data Source=MIKO-LAPTOP;Initial Catalog=ZNorthwind;Integrated Security=True"))
            {
                DB db = new DB(); 
                db.Insert(connection, "ABCDE", "ABCDE");
                db.Update(connection,"ABCDE","WitchKing");
                db.Select(connection);
                Console.WriteLine();
                db.Delete(connection, "ABCDE");
                db.Select(connection);
            }
        }
    }

}
