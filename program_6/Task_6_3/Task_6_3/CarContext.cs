using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Task_6_3
{
    class CarContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public CarContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Database=CarStoreNew63_3;Username=postgres;Password=89376650756;");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Task63_migration;Trusted_Connection=True;");
        }
    }
}
