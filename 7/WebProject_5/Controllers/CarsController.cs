using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebProject_5.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProject_5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        CarsContext db;
        public CarsController(CarsContext context)
        {
            db = context;
            if (!db.Cars.Any())
            {
                db.Cars.Add( new Car { Name = "Hyundai Kona Electric Comfort",  Price = 2500100, Power = 100, Count = 5, Brand = "Hyundai"});
                db.Cars.Add( new Car { Name = "Hyundai Kona Electric Style",    Price = 3100100, Power = 150, Count = 3, Brand = "Hyundai"});
                db.Cars.Add( new Car { Name = "Nissan Leaf E-Plus",     Price = 2800100,    Power = 160, Count = 15, Brand = "Nissan"});
                db.Cars.Add( new Car { Name = "Bright Crystal",         Price = 3840100,    Power = 90,  Count = 10, Brand = "BMW"});
                db.Cars.Add( new Car { Name = "Kia Soul EV",            Price = 1545000,    Power = 90,  Count = 25, Brand = "Kia"});
                db.Cars.Add( new Car { Name = "Volkswagen e-Up",        Price = 1800100,    Power = 62,  Count = 8,  Brand = "Volkswagen"});
                db.Cars.Add( new Car { Name = "Mazda MX-30",            Price = 2400100,    Power = 105, Count = 3,  Brand = "Mazda", });
                db.Cars.Add( new Car { Name = "Porsche Taycan Turbo",   Price = 10643000,   Power = 460, Count = 2,  Brand = "Porche"});
                db.Cars.Add( new Car { Name = "Porsche Taycan Turbo S", Price = 12900100,   Power = 560, Count = 1,  Brand = "Porche"});
                db.Cars.Add( new Car { Name = "Tesla Model S",          Price = 18000000,   Power = 450, Count = 10, Brand = "Tesla"});
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            return await db.Cars.ToListAsync();
        }

        // GET api/cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            Car car = await db.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
                return NotFound();
            return new ObjectResult(car);
        }

        // POST api/cars
        [HttpPost]
        public async Task<ActionResult<Car>> Post(Car car)
        {
            // обработка частных случаев валидации
            if (car.Power == 666)
                ModelState.AddModelError("Power", "Мощность не должен быть равной 666");

            /*if (car == null || db.Cars.Any(x => x.Name == car.Name))
            {
                ModelState.AddModelError("Name", "Недопустимое название автомобиля, автомобиль уже существет!");
            }*/
            // если есть oшибки - возвращаем ошибку 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // если ошибок нет, сохраняем в базу данных
            db.Cars.Add(car);
            await db.SaveChangesAsync();
            return Ok(car);
        }

        [HttpPut]
        public async Task<ActionResult<Car>> Put(Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            if (!db.Cars.Any(x => x.Id == car.Id))
            {
                return NotFound();
            }

            db.Update(car);
            await db.SaveChangesAsync();
            return Ok(car);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            Car car = db.Cars.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            db.Cars.Remove(car);
            await db.SaveChangesAsync();
            return Ok(car);
        }
    }
}
