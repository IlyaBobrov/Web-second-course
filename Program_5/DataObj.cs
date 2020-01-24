using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using Program_5.Models;

namespace Program_5
{
    public class DataObj
    {
        public static void Initialize(CarContext context)
        {
            Brand Hyundai = new Brand   {Name = "Hyundai", Country = "South Korea"};
            Brand Nissan = new Brand    {Name = "Nissan", Country = "Japan"};
            Brand BMW = new Brand       {Name = "BMW", Country = "Germany"};
            Brand Kia = new Brand       {Name = "Kia", Country = "South Korea"};
            Brand Volkswagen = new Brand{Name = "Volkswagen", Country = "Germany"};
            Brand Mazda = new Brand     {Name = "Mazda", Country = "Japan"};
            Brand Porche = new Brand    {Name = "Porche", Country = "Germany"};
            Brand Tesla = new Brand    {Name = "Tesla", Country = "USA"};

            if (!context.Brands.Any())
            {
                context.Brands.AddRange(Hyundai, Nissan, BMW, Kia, Volkswagen, Mazda, Porche, Tesla);
                context.SaveChanges();
            }

            if (!context.Cars.Any())
            {
                context.Cars.AddRange(
                    new Car
                    {
                        Name = "Hyundai Kona Electric Comfort",
                        Price = 2500100,
                        Power = 100,
                        Count = 5,
                        Brand = Hyundai,
                    },
                new Car
                {
                    Name = "Hyundai Kona Electric Style",
                    Price = 3100100,
                    Power = 150,
                    Count = 3,
                    Brand = Hyundai,
                },
                new Car
                {
                    Name = "Nissan Leaf E-Plus",
                    Price = 2800100,
                    Power = 160,
                    Count = 15,
                    Brand = Nissan,
                },
                new Car
                {
                    Name = "Bright Crystal",
                    Price = 3840100,
                    Power = 90,
                    Count = 10,
                    Brand = BMW,
                },
                new Car
                {
                    Name = "Kia Soul EV",
                    Price = 1545000,
                    Power = 90,
                    Count = 25,
                    Brand = Kia,
                },
                new Car
                {
                    Name = "Volkswagen e-Up",
                    Price = 1800100,
                    Power = 62,
                    Count = 8,
                    Brand = Volkswagen,
                },
                new Car
                {
                    Name = "Mazda MX-30",
                    Price = 2400100,
                    Power = 105,
                    Count = 3,
                    Brand = Mazda,
                },
                new Car
                {
                    Name = "Porsche Taycan Turbo",
                    Price = 10643000,
                    Power = 460,
                    Count = 2,
                    Brand = Porche,
                },
                new Car
                {
                    Name = "Porsche Taycan Turbo S",
                    Price = 12900100,
                    Power = 560,
                    Count = 1,
                    Brand = Porche,
                },
                new Car
                {
                    Name = "Tesla Model S",
                    Price = 18000000,
                    Power = 450,
                    Count = 10,
                    Brand = Tesla,
                }
                );
            context.SaveChanges();
            }
        }
    }
}
