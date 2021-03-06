﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Web_7.Models
{
    public class CarsContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public CarsContext(DbContextOptions<CarsContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
