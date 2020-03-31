using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class KontekstES : DbContext
    {
        public DbSet<ESComputer> Computers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ESComputer>()
                .Map(map =>
            {
                map.Properties(prop => new
                {
                    prop.Description,
                    prop.Cooling
                });
                map.ToTable("pola Tekstowe");
            }
            )
                .Map(map =>
            {
                map.Properties(prop => new
                {
                    prop.Price
                });
                map.ToTable("pola Liczbowe");
            }
            );
        }
    }
}
