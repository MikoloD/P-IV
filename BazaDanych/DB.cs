using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BazaDanych
{
    public class DB
    {
        public void Select(SqlConnection connection)
        {
            string querry = "SELECT * FROM Klienci";
            var command = new SqlCommand(querry, connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["IDklienta"]);
            }
            reader.Close();
        }

        public void Insert(SqlConnection connection, string IDklienta, string NazwaFirmy)
        {
            var querry = "INSERT INTO Klienci(IDklienta,NazwaFirmy)" + "VALUES (@IDklienta,@NazwaFirmy)";

            var command = new SqlCommand(querry, connection);
            command.Parameters.AddWithValue("IDklienta", IDklienta);
            command.Parameters.AddWithValue("NazwaFirmy", NazwaFirmy);

            var affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows affected");
        }

        public void Delete(SqlConnection connection, string IDklienta)
        {
            var querry = "DELETE FROM Klienci WHERE IDklienta=@IDklienta";

            var command = new SqlCommand(querry, connection);
            command.Parameters.AddWithValue("IDklienta", IDklienta);

            var affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows affected");
        }
        public void Update(SqlConnection connection, string IDklienta, string NazwaFirmy)
        {
            var querry = "UPDATE Klienci SET NazwaFirmy = @NazwaFirmy WHERE IDklienta=@IDklienta";
            var command = new SqlCommand(querry, connection);
            command.Parameters.AddWithValue("IDklienta", IDklienta);
            command.Parameters.AddWithValue("NazwaFirmy", NazwaFirmy);

            var affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows affected");
        }

    }
}
