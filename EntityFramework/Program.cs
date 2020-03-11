using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var db = new Kontekst();
            db.Database.EnsureCreated();
            db.Zajecias.Add(new Zajecia()
            {
                Nazwa = "P4",
                GodzinaRozpoczecia = new DateTime(2020, 1, 1, 13, 30, 0)
            });
            db.SaveChanges();

            var zajecia = db.Zajecias.Where(x=>x.Id < 2);
            foreach(var elem in zajecia)
            {
                Console.WriteLine($"{elem.Id} {elem.Nazwa} {elem.GodzinaRozpoczecia}");
            }
            var zajeciaDoZmiany = db.Zajecias.First(x => x.Nazwa.StartsWith("P"));
            zajeciaDoZmiany.Nazwa = "AM2";
            db.Update(zajeciaDoZmiany);
            db.SaveChanges();
            foreach (var elem in zajecia)
            {
                Console.WriteLine($"{elem.Id} {elem.Nazwa} {elem.GodzinaRozpoczecia}");
            }
            db.Remove(zajeciaDoZmiany);
            */
            var NorthwindContext = new ZNorthwindContext();
            foreach(var elem in NorthwindContext.PozycjeZamówienia.Include(x=>x.IdproduktuNavigation))
            {
                Console.WriteLine($"{elem.Idzamówienia} {elem.Idproduktu}" +
                    $" {elem.IdproduktuNavigation.NazwaProduktu} {elem.IdproduktuNavigation.CenaJednostkowa}" +
                    $" {elem.Ilość}");
            }
        }
    }
}
