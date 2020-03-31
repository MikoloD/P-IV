using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Serwer
    {
        public int ServerId { get; set; }
        public int Bandwidth { get; set; }
        public int Price { get; set; }
        public string Colling { get; set; }
        public virtual TSComputer TSComputerNavigator{get;set;}

    }
}
