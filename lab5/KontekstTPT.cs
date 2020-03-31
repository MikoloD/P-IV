using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class KontekstTPT : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PC>().ToTable("PCs");
            modelBuilder.Entity<Laptop>().ToTable("Laptops");
        }
    }
}
