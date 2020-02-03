using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Program_5.Models;
using Program_5.ViewModels;

namespace Program_5.Controllers
{
    public class CarController : Controller
    {
        CarContext DataBase;

        public CarController(CarContext context)
        {
            DataBase = context;
        }

        [HttpGet]
        public IActionResult AddNewCar()
        {
            List<Brand> _brand_model = DataBase.Brands.ToList(); //.Select(c => new BrandModel { Id = c.Id, Name = c.Name })
            
            // добавляем на первое место
            List<Car> _cars = DataBase.Cars.ToList();
            IndexViewModel ivm = new IndexViewModel { Brands = _brand_model, Cars = _cars};

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

            if (DataBase.Cars.Any(x => x.Name == car.Name))
            {
                return BadRequest();
            }

            DataBase.Cars.Add(car);
            DataBase.SaveChanges();
            return Redirect("~/Home/Index");
        }

        public async Task<IActionResult> Index(int? brand, string name, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 6;

            //фильтрация
            IQueryable<Car> cars = DataBase.Cars.Include(x => x.Brand);

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
                FilterViewModel = new FilterViewModel(DataBase.Brands.ToList(), brand, name),
                Cars = items
            };
            return View(viewModel);
        }
    }
}
