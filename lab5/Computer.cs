using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public abstract class Computer
    {
        public Computer(string description,int price)
        {
            Description = description;
            Price = price;
        }
        public int ID { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}