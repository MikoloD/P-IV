using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class PC: Computer
    {
        public PC(string description, int price, string cooling) : base(description, price)
        {
           Cooling = cooling;
        }
        public string Cooling { get; set; }
    }
}
