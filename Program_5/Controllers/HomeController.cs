using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Program_5.Models;
using Program_5.ViewModels;

namespace Program_5.Controllers
{
    public class HomeController : Controller
    {
        CarContext DataBase;
        public HomeController(CarContext context)
        {
            DataBase = context;
        }

        public IActionResult Index(int? brandId)
        {
            // формируем список компаний для передачи в представление
            List<Brand> _brand_models = DataBase.Brands.ToList();
            
            // добавляем на первое место
            _brand_models.Insert(0, new Brand { Id = 0, Name = "All", Country = "no" });

            List<Car> _cars= DataBase.Cars.ToList();
            ViewBag.Brands = _brand_models;
            IndexViewModel ivm = new IndexViewModel { Brands = _brand_models, Cars = _cars};

            // если передан id компании, фильтруем список
            if (brandId != null && brandId > 0)
                ivm.Cars = DataBase.Cars.Where(p => p.Brand.Id == brandId);

            return View(ivm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewBrand(string submit, string cancel, Brand brand)
        {
            var button = submit ?? cancel;
            if (button == "Cancel")
            {
                return RedirectToAction("AddNewBrand");
            }

            if (DataBase.Brands.Any(x => ((x.Name == brand.Name)||(x.Name == "Enter"))))
            {
                return BadRequest();
            }

            DataBase.Brands.Add(brand);
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}