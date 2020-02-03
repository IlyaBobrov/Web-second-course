using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_task_4.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace Web_task_4
{
    public class DataModels
    {
        public static void FitrstInit(CarContext context)
        {
            if (!context.Brands.Any())
            {
                context.Brands.AddRange(
                    new Brand
                    {
                        Name = "Subaru",
                        Country = "Japan"
                    },
                    new Brand
                    {
                        Name = "Mitsubishi",
                        Country = "Japan"
                    },
                    new Brand
                    {
                        Name = "Nissan",
                        Country = "Japan"
                    },
                    new Brand
                    {
                        Name = "BMW",
                        Country = "Germany"
                    },
                    new Brand
                    {
                        Name = "Mercedes",
                        Country = "Germany"
                    },
                    new Brand
                    {
                        Name = "Volvo",
                        Country = "USA"
                    },
                    new Brand
                    {
                        Name = "Toyota",
                        Country = "Japan"
                    },
                    new Brand
                    {
                        Name = "Honda",
                        Country = "Japan"
                    }
                );
                context.SaveChanges();
            }

            if (!context.Cars.Any())
            {
                context.Cars.AddRange(
                    new Car
                    {
                        Name = "Subaru Impreza",
                        Price = 3500,
                        EnginePower = 290,
                        Number = 5,
                        Brand = "Subaru"
                    },
                    new Car
                    {
                        Name = "Mitsubishi Evo",
                        Price = 4200,
                        EnginePower = 320,
                        Number = 3,
                        Brand = "Mitsubishi"
                    },
                    new Car
                    {
                        Name = "Nissan Silvia",
                        Price = 2200,
                        EnginePower = 180,
                        Number = 10,
                        Brand = "Nissan"
                    },
                    new Car
                    {
                        Name = "BMW X5",
                        Price = 4100,
                        EnginePower = 350,
                        Number = 15,
                        Brand = "BMW"
                    },
                    new Car
                    {
                        Name = "Mercedes CLA",
                        Price = 8600,
                        EnginePower = 340,
                        Number = 3,
                        Brand = "Mercedes"
                    },
                    new Car
                    {
                        Name = "Volvo V60",
                        Price = 7600,
                        EnginePower = 390,
                        Number = 12,
                        Brand = "Volvo"
                    },
                    new Car
                    {
                        Name = "Toyota Supra 2019",
                        Price = 5500,
                        EnginePower = 400,
                        Number = 1,
                        Brand = "Toyota"
                    },
                    new Car
                    {
                        Name = "Honda Civic",
                        Price = 1200,
                        EnginePower = 180,
                        Number = 30,
                        Brand = "Honda"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
