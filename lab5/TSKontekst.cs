using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class TSKontekst :DbContext
    {
        public DbSet<TSComputer> Computers { get; set; }
        public DbSet<Serwer> Serwers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TSComputer>()
                .HasRequired(tsc => tsc.ServerNavigator)
                .WithRequiredDependent(s => s.TSComputerNavigator);
            modelBuilder.Entity<TSComputer>().ToTable("Komputery");
            modelBuilder.Entity<Serwer>().ToTable("Serwery")
                
            ;
        }
    }
}
