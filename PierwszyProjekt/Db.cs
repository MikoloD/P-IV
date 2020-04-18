using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;

namespace PierwszyProjekt
{
    class DB
    {
        public BindingList<string> SelectStacje(SqlConnection connection)
        {
            BindingList<string> listaStacji = new BindingList<string>();
            var stacje = connection.Query<string>(
                "SELECT NazwaStacji FROM Stacja;");
            foreach (var item in stacje)
            {
                listaStacji.Add(item);
            }
            return listaStacji;
        }
    }
}
