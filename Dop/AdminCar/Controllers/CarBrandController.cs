using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AdminCar.Models;
using Microsoft.AspNetCore.Authorization;
using AdminCar.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminCar.Controllres
{
    public class CarBrandController : Controller
    {
        Context db;
        public CarBrandController(Context context)
        {
            db = context;
        }

        //Lazy loading предполагает неявную автоматическую загрузку связанных данных
        [Authorize]
        public IActionResult TableTest()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Cars.ToList());
            }
            return Content("Информация недоступна анонимным пользователям");
        }

        //-----------------car----------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult AddNewCar()
        {
            List<Brand> _brand_model = db.Brands.ToList(); //.Select(c => new BrandModel { Id = c.Id, Name = c.Name })

            // добавляем на первое место
            List<Car> _cars = db.Cars.ToList();
            IndexViewModel ivm = new IndexViewModel { Brands = _brand_model, Cars = _cars };

            return View(ivm);
        }
        [HttpPost]
        public IActionResult AddNewCar(string submit, string cancel, Car car)
        {
            var button = submit ?? cancel;
            if (button == "Cancel")
            {
                return RedirectToAction("AddNewCar");
            }

            if (db.Cars.Any(x => x.Name == car.Name))
            {
                return BadRequest();
            }

            db.Cars.Add(car);
            db.SaveChanges();
            return Redirect("~/Home/Index");
        }

        public async Task<IActionResult> Index(int? brand, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 6;

            //фильтрация
            IQueryable<Car> cars = db.Cars.Include(x => x.Brand);

            if (brand != null && brand != 0)
            {
                cars = cars.Where(p => p.Brand.Id == brand);
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
