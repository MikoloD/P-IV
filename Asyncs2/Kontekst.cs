using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asyncs2
{
    public class Kontekst : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<CoachTB> CoachTBs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=MIKO-LAPTOP;Initial Catalog=TestDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.HasOne(a => a.CoachNavigation)
                      .WithOne(b => b.TeamNavigation)
                      .HasForeignKey<Team>(a=>a.school)
                      .HasPrincipalKey<CoachTB>(b => b.School);
            });
            modelBuilder.Entity<CoachTB>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.HasOne(a => a.TeamNavigation)
                      .WithOne(b => b.CoachNavigation)
                      .HasForeignKey<CoachTB>(a => a.School)
                      .HasPrincipalKey<Team>(b => b.school);
            });
        }
    }
}
