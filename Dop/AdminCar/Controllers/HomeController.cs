using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdminCar.Models;
using Microsoft.AspNetCore.Authorization;

using Microsoft.EntityFrameworkCore;
using AdminCar.ViewModels;

namespace AdminCar.Controllers
{
    
    public class HomeController : Controller
    {

        Context db;
        public HomeController(Context context)
        {
            db = context;
            // добавляем начальные данные
            if (db.Brands.Count() == 0)
            {
                Brand Volkswagen = new Brand { Name = "Volkswagen", Country = "Germany", Year = 1920, Site = "http://Volkswagen.com" };
                Brand Hyundai = new Brand { Name = "Hyundai", Country = "South Korea", Year = 1945, Site = "http://Hyundai.com" };
                Brand Nissan = new Brand { Name = "Nissan", Country = "Japan", Year = 1912, Site = "http://Nissan.com" };
                Brand BMW = new Brand { Name = "BMW", Country = "Germany", Year = 1898, Site = "http://BMW.com" };
                Brand Kia = new Brand { Name = "Kia", Country = "South Korea", Year = 1980, Site = "http://Kia.com" };
                Brand Mazda = new Brand { Name = "Mazda", Country = "Japan", Year = 1972, Site = "http://Mazda.com" };
                Brand Porche = new Brand { Name = "Porche", Country = "Germany", Year = 1900, Site = "http://Poche.com" };
                Brand Tesla = new Brand { Name = "Tesla", Country = "USA", Year = 2010, Site = "http://Tesla.com" };

                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(Hyundai, Nissan, BMW, Kia, Volkswagen, Mazda, Porche, Tesla);
                    context.SaveChanges();
                }

                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(
                        new Car { Name = "Hyundai Kona Electric Comfort", Price = 2500100, Power = 100, Brand = Hyundai, },
                        new Car { Name = "Hyundai Kona Electric Style", Price = 3100100, Power = 150, Brand = Hyundai, },
                        new Car { Name = "Porsche Taycan Turbo S", Price = 12900100, Power = 560, Brand = Porche, },
                        new Car { Name = "Porsche Taycan Turbo", Price = 10643000, Power = 460, Brand = Porche, },
                        new Car { Name = "Nissan Leaf E-Plus", Price = 2800100, Power = 160, Brand = Nissan, },
                        new Car { Name = "Volkswagen e-Up", Price = 1800100, Power = 62, Brand = Volkswagen, },
                        new Car { Name = "Bright Crystal", Price = 3840100, Power = 90, Brand = BMW, },
                        new Car { Name = "Tesla Model S", Price = 18000000, Power = 450, Brand = Tesla, },
                        new Car { Name = "Kia Soul EV", Price = 1545000, Power = 90, Brand = Kia, },
                        new Car { Name = "Mazda MX-30", Price = 2400100, Power = 105, Brand = Mazda, }
                    );
                    context.SaveChanges();
                }
            }
        }

        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        [Authorize]
        public IActionResult TableTest()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Cars.ToList());
            }
            return Content("Информация недоступна анонимным пользователям");
        }

        [Authorize]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();// User.Identity.Name);
            }
            return View("не аутентифицирован");
        }

        /*public IActionResult Index(int? brandId)
        {
            // формируем список компаний для передачи в представление
            List<Brand> _brand_models = db.Brands.ToList();

            // добавляем на первое место
            _brand_models.Insert(0, new Brand { Id = 0, Name = "All", Country = "no" });

            List<Car> _cars = db.Cars.ToList();
            ViewBag.Brands = _brand_models;
            IndexViewModel ivm = new IndexViewModel { Brands = _brand_models, Cars = _cars };

            // если передан id компании, фильтруем список
            if (brandId != null && brandId > 0)
                ivm.Cars = db.Cars.Where(p => p.Brand.Id == brandId);

            return View(ivm);
        }*/

        //[AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }


        //-----------------BRAND----------------------------------------------------------------------------------------------
     
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult AddNewBrand()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddNewBrand(string submit, string cancel, Brand brand)
        {
            var button = submit ?? cancel;
            if (button == "Cancel")
            {
                return Redirect("~/Home/IndexCar");
                //return RedirectToAction("AddNewBrand");
            }

            if (db.Brands.Any(x => ((x.Name == brand.Name) || (x.Name == "Enter"))))
            {
                return BadRequest();
            }

            db.Brands.Add(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-------------CARS---------------------------------------------------------------------------------------------------
        
        [Authorize(Roles = "admin, moder")]
        [HttpGet]
        public IActionResult AddNewCar()
        {
            
            List<Brand> _brand_model = db.Brands.ToList(); //.Select(c => new BrandModel { Id = c.Id, Name = c.Name })

            // добавляем на первое место
            List<Car> _cars = db.Cars.ToList();
            IndexViewModel ivm = new IndexViewModel { Brands = _brand_model, Cars = _cars };

            return View(ivm);
        }

        
        [Authorize(Roles = "admin,moder")]
        [HttpPost]
        public IActionResult AddNewCar(string submit, string cancel,string delete, Car car)
        {
            var button = submit ?? cancel;
            if (button == "Cancel")
            {
                return Redirect("~/Home/IndexCar");
                //return RedirectToAction("AddNewCar");
            }

            var buttonD = submit ?? delete;
            if (buttonD == "Delete")
            {
                
                /*if (db.Cars.Any(x => x.Name == car.Name))
                {

                    Car c = db.Cars.Find(car.Name);
                    if (c != null)
                    {
                        db.Cars.Remove(c);
                        db.SaveChanges();
                        return Redirect("~/Home/IndexCar");
                    }
                }*/
                return Redirect("~/Home/AddNewCar");
            }
            if (db.Cars.Any(x => x.Name == car.Name))
            {
                return BadRequest();
            }

            db.Cars.Add(car);
            db.SaveChanges();
            return Redirect("~/Home/IndexCar");
        }

        public async Task<IActionResult> IndexCar(int? brand, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            if (User.Identity.IsAuthenticated)
            {
                int pageSize = 6;

                //фильтрация
                IQueryable<Car> cars = db.Cars.Include(x => x.Brand);

                if (brand != null && brand != 0)
                {
                    cars = cars.Where(p => p.BrandId == brand);
                }
                if (!String.IsNullOrEmpty(name))
                {
                    cars = cars.Where(p => p.Name.Contains(name));
                }

                // сортировка
                switch (sortOrder)
                {
                    case SortState.NameDesc:
                        cars = cars.OrderByDescending(s => s.Name);
                        break;
                    case SortState.PriceAsc:
                        cars = cars.OrderBy(s => s.Price);
                        break;
                    case SortState.PriceDesc:
                        cars = cars.OrderByDescending(s => s.Price);
                        break;
                    case SortState.PowerAsc:
                        cars = cars.OrderBy(s => s.Power);
                        break;
                    case SortState.PowerDesc:
                        cars = cars.OrderByDescending(s => s.Power);
                        break;
                    case SortState.BrandAsc:
                        cars = cars.OrderBy(s => s.Brand.Name);
                        break;
                    case SortState.BrandDesc:
                        cars = cars.OrderByDescending(s => s.Brand.Name);
                        break;
                    default:
                        cars = cars.OrderBy(s => s.Name);
                        break;
                }

                // пагинация
                var count = await cars.CountAsync();
                var items = await cars.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

                // формируем модель представления
                IndexViewModel viewModel = new IndexViewModel
                {
                    PageViewModel = new PageViewModel(count, page, pageSize),
                    SortViewModel = new SortViewModel(sortOrder),
                    FilterViewModel = new FilterViewModel(db.Brands.ToList(), brand, name),
                    Cars = items
                };
                return View(viewModel);
            }
            return Content("Информация недоступна анонимным пользователям");
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
