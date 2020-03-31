using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class KontekstTHP:DbContext
    {
        public DbSet<Computer> Computers { get; set; }
    }
}
