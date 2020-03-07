using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace Dapper2
{
    class DB
    {
        public void Select(SqlConnection connection)
        {
            var klienci = connection.Query<Klienci>("SELECT * FROM Klienci");
            foreach (var item in klienci)
            {
                Console.WriteLine($"{item.IDklienta}: {item.NazwaFirmy}");
            }
        }
        public void Insert(SqlConnection connection, Klienci klient)
        {
            var klienci = connection.Execute("INSERT INTO Klienci(IDklienta,NazwaFirmy)"
                + "VALUES (@IDklienta,@NazwaFirmy)",
                new { IDklienta = klient.IDklienta, NazwaFirmy = klient.NazwaFirmy });
        }
        public void Insert(SqlConnection connection, string IDklienta, string NazwaFirmy)
        {
            var klienci = connection.Execute("INSERT INTO Klienci(IDklienta,NazwaFirmy)"
                + "VALUES (@IDklienta,@NazwaFirmy)",
                new { IDklienta = IDklienta, NazwaFirmy = NazwaFirmy });
        }

        public void Delete(SqlConnection connection, string IDklienta)
        {
            var klienci = connection.Execute("DELETE FROM Klienci WHERE IDklienta=@IDklienta",
                new { IDklienta = IDklienta });
        }
        public void Delete(SqlConnection connection, Klienci klient)
        {
            var klienci = connection.Execute("DELETE FROM Klienci WHERE IDklienta=@IDklienta",
                new { IDklienta = klient.IDklienta });
        }
        public void Update(SqlConnection connection, string IDklienta, string NazwaFirmy)
        {
            var klienci = connection.Execute("UPDATE Klienci SET NazwaFirmy = @NazwaFirmy WHERE IDklienta=@IDklienta",
                new { IDklienta = IDklienta, NazwaFirmy = NazwaFirmy });
        }
         public void Update(SqlConnection connection, Klienci klient)
        {
            var klienci = connection.Execute("UPDATE Klienci SET NazwaFirmy = @NazwaFirmy WHERE IDklienta=@IDklienta",
                new { IDklienta = klient.IDklienta, NazwaFirmy = klient.NazwaFirmy });
        }
    }
}
