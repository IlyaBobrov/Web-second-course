using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Web_task_4.Models;

namespace Web_task_4.Controllers
{
    public class HomeController : Controller
    {
        CarContext db;
        public HomeController(CarContext context)
        {
            db = context;
        }

        public IActionResult Index(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                return View(db.Cars.ToList());
            }
            var c = from i in db.Cars select i;
            c = c.Where(t => t.Name.Contains(searchString));
            return View(c.ToList());
        }

        public IActionResult IndexBrand(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                return View(db.Brands.ToList());
            }
            var c = from i in db.Brands select i;
            c = c.Where(t => t.Name.Contains(searchString));
            return View(c.ToList());
        }

        //add car
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(string add, string cancel, Car car)
        {
            var button = add ?? cancel;
            if (button == "Cancel")
            {
                return RedirectToAction("Index");
            }

            if (db.Cars.Contains(car))
            {
                return BadRequest();
            }

            db.Cars.Add(car);
            db.SaveChanges();
            return View(db.Cars.ToList());
        }
        
        //add model car
        
        [HttpGet]
        public IActionResult createBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createBrand(string submit, string cancel, Brand brand_)
        {
            var button = submit ?? cancel;
            if (button == "Cancel")
            {
                return RedirectToAction("IndexBrand");
            }

            if (db.Brands.Contains(brand_))
            {
                return BadRequest();
            }
            db.Brands.Add(brand_);
            db.SaveChanges();
            return RedirectToAction("IndexBrand");
        }

        //show car
        
        [HttpGet]
        public IActionResult show(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var obj = db.Cars.Find(id);
            ViewBag.Name = obj.Name;
            ViewBag.Id = obj.Id;
            ViewBag.EnginePower = obj.EnginePower;
            ViewBag.Number = obj.Number;
            ViewBag.Price = obj.Price;
            ViewBag.Brand = obj.Brand;
            return View();
        }

        [HttpGet]
        public IActionResult showBrand(int? id)
        {
            if (id == null) return RedirectToAction("IndexBrand");
            var obj = db.Brands.Find(id);
            ViewBag.Name = obj.Name;
            ViewBag.Country = obj.Country;
            ViewBag.Id = id;
            return View();
        }

        //edit car

        [HttpGet]
        public IActionResult edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var car = db.Cars.Find(id);
            ViewBag.Name = car.Name;
            ViewBag.EnginePower = car.EnginePower;
            ViewBag.Number = car.Number;
            ViewBag.Id = id;
            ViewBag.Price = car.Price;
            ViewBag.Brand = car.Brand;
            return View();
        }

        [HttpPost]
        public IActionResult edit(string submit, string cancel, Car car)
        {
            var button = submit ?? cancel;
            if (button == "Cancel")
            {
                return RedirectToAction("Index");
            }
            if (car == null)
            {
                return BadRequest();
            }
            if (!db.Cars.Any(x => x.Name == car.Name))
            {
                return NotFound();
            }

            db.Cars.Update(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //edit model car

        [HttpGet]
        public IActionResult editBrand(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var br = db.Brands.Find(id);
            ViewBag.Name = br.Name;
            ViewBag.Id = br.Id;
            ViewBag.Country = br.Country;
            return View();
        }

        [HttpPost]
        public IActionResult editBrand(string submit, string cancel, Brand brand_)
        {
            var button = submit ?? cancel;
            if (button == "Cancel")
            {
                return RedirectToAction("IndexBrand");
            }
            if (brand_ == null)
            {
                return BadRequest();
            }
            if (!db.Brands.Any(x => x.Id == brand_.Id))
            {
                return NotFound();
            }

            db.Brands.Update(brand_);
            db.SaveChanges();
            return RedirectToAction("IndexBrand");
        }

        //delete car

        [HttpGet]
        public IActionResult delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var car = db.Cars.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            var obj = db.Cars.Find(id);
            ViewBag.Name = obj.Name;
            ViewBag.Id = obj.Id;
            ViewBag.EnginePower = obj.EnginePower;
            ViewBag.Number = obj.Number;
            ViewBag.Price = obj.Price;
            ViewBag.Brand = obj.Brand;
            return View();
        }
        [HttpPost]
        public IActionResult delete(string add, string cancel, Car car)
        {
            var button = add ?? cancel;
            if (button == "Cancel")
            {
                return RedirectToAction("Index");
            }
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //delete model

        [HttpGet]
        public IActionResult deleteBrand(int? id)
        {
            if (id == null) return RedirectToAction("IndexBrand");
            var brand_ = db.Brands.FirstOrDefault(x => x.Id == id);
            if (brand_ == null)
            {
                return NotFound();
            }
            var obj = db.Brands.Find(id);
            ViewBag.Name = obj.Name;
            ViewBag.Id = obj.Id;
            ViewBag.Country = obj.Country;
            return View();
        }
        [HttpPost]
        public IActionResult deleteBrand(string submit, string cancel, Brand brand_)
        {
            var button = submit ?? cancel;
            if (button == "Cancel")
            {
                return RedirectToAction("IndexBrand");
            }

            db.Brands.Remove(brand_);
            db.SaveChanges();
            return RedirectToAction("IndexBrand");

        }
    }
}