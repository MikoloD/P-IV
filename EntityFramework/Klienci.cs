using System;
using System.Collections.Generic;

namespace EntityFramework
{
    public partial class Klienci
    {
        public Klienci()
        {
            Zamówienia = new HashSet<Zamówienia>();
        }

        public string Idklienta { get; set; }
        public string NazwaFirmy { get; set; }
        public string Przedstawiciel { get; set; }
        public string StanowiskoPrzedstawiciela { get; set; }
        public string Adres { get; set; }
        public string Miasto { get; set; }
        public string Region { get; set; }
        public string KodPocztowy { get; set; }
        public string Kraj { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }

        public virtual ICollection<Zamówienia> Zamówienia { get; set; }
    }
}
