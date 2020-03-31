using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Laptop: Computer
    {
        public Laptop(string description,int price,int weight,string manufactorer):base(description, price)
        {
            Weight = weight;
            Manufactorer = manufactorer;
        }
        public int Weight { get; set; }
        public string Manufactorer { get; set; }
    }
}
