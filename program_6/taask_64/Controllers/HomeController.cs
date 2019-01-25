using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using taask_64.Models;

namespace taask_64.Controllers
{
    public class HomeController : Controller
    {
        CarStoreContext db;
        public HomeController(CarStoreContext context)
        {
            db = context;
            // добавляем начальные данные
            if (db.Brands.Count() == 0)
            {
                Brand Hyundai = new Brand { Name = "Hyundai", Country = "South Korea" };
                Brand Nissan = new Brand { Name = "Nissan", Country = "Japan" };
                Brand BMW = new Brand { Name = "BMW", Country = "Germany" };
                Brand Kia = new Brand { Name = "Kia", Country = "South Korea" };
                Brand Volkswagen = new Brand { Name = "Volkswagen", Country = "Germany" };
                Brand Mazda = new Brand { Name = "Mazda", Country = "Japan" };
                Brand Porche = new Brand { Name = "Porche", Country = "Germany" };
                Brand Tesla = new Brand { Name = "Tesla", Country = "USA" };

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

        //Eager loading позволяет загружать связанные данные с помощью метода Include()
        public IActionResult EagerLoadingIndex()
        {
            var cars = db.Cars.Include(x => x.Brand).ToList();
            return View(cars.ToList());
        }

        //Explicit loading предполагает явную загрузку данных с помощью метода Load
        public IActionResult ExplicitLoadingIndex()
        {
            db.Cars.Load();
            db.Brands.Load();
            return View(db.Cars.ToList());
        }

        //Lazy loading предполагает неявную автоматическую загрузку связанных данных
        public IActionResult LazyLoadingIndex()
        {
            //var cars = db.Cars.ToList();
            return View(db.Cars.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
