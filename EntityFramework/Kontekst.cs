using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class Kontekst: DbContext
    {
        public DbSet<Zajecia> Zajecias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=MIKO-LAPTOP;Initial Catalog=ZNorthwind;Integrated Security=True");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder
                .Entity<Zajecia>()
                .Property(x => x.Nazwa)
                .HasMaxLength(255)
                .HasColumnName("NazwaFluent");   
                */

        }
        }
    }
