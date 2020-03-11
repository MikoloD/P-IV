using System;
using System.Collections.Generic;

namespace EntityFramework
{
    public partial class PozycjeZamówienia
    {
        public int Idzamówienia { get; set; }
        public int Idproduktu { get; set; }
        public decimal CenaJednostkowa { get; set; }
        public short Ilość { get; set; }
        public float Rabat { get; set; }

        public virtual Produkty IdproduktuNavigation { get; set; }
        public virtual Zamówienia IdzamówieniaNavigation { get; set; }
    }
}
