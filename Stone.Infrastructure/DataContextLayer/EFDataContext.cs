using Microsoft.EntityFrameworkCore;
using Stone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Infrastructure.DataContextLayer
{
    public class EFDataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inss> Inss { get; set; }
        public DbSet<Irpf> Irpf { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:stone-pay-db.database.windows.net,1433;Initial Catalog=stonepay-db;Persist Security Info=False;User ID=carlos;Password=segredo.3#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();

            ConfigureEmployee(modelBuilder);
            ConfigureInss(modelBuilder);
        }

        private void ConfigureEmployee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasKey(b => b.Id)
            .HasName("Id");
        }

        private void ConfigureInss(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inss>(i =>
            {
                i.ToTable("Inss");
            });
        }

        private void ConfigureIrrf(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inss>(i =>
            {
                i.ToTable("Irpf");
            });
        }
    }
}
