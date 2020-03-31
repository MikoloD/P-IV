using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var THPdb = new KontekstTHP();
            THPdb.Computers.Add(new PC("abc", 1000, "water"));
            THPdb.Computers.Add(new Laptop("abc", 1000,2,"MSI"));
            THPdb.SaveChanges();

            var TPTdb = new KontekstTPT();
            TPTdb.Computers.Add(new PC("abc", 1000, "water"));
            THPdb.Computers.Add(new Laptop("abc", 1000, 2, "MSI"));
            TPTdb.SaveChanges();

            var TPCdb = new KontekstTPT();
            TPCdb.Computers.Add(new PC("abc", 1000, "water"));
            THPdb.Computers.Add(new Laptop("abc", 1000, 2, "MSI"));
            TPCdb.SaveChanges();

            var es = new KontekstES();
            es.Computers.Add(new ESComputer() { Description = "KomputerES", Cooling = "Fluid", Price = 1500 });
            es.SaveChanges();
            
            var ts = new TSKontekst();
            ts.Computers.Add(new TSComputer()
            {
                Description = "MSI",
                Cooling = "Fluid",
                Price = 1999,
                ServerNavigator = new Serwer() { Bandwidth = 1500 }
            });
            ts.SaveChanges();
        }
    }
}
