﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Web_task_4.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
