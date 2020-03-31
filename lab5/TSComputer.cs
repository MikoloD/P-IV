using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class TSComputer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Cooling { get; set; }
        public virtual Serwer ServerNavigator { get; set; }
    }
}
