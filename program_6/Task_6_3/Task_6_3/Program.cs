using System;
using System.Linq;


namespace Task_6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            using (CarContext db = new CarContext())
            {
                // получаем объекты из бд и выводим на консоль
                var brands = db.Brands.ToList();
                Console.WriteLine("Бренды:");
                foreach (var u in brands)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Country}");
                }
                var cars = db.Cars.ToList();
                Console.WriteLine("Авто:");
                foreach (var u in cars)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Price} - {u.Power} - {u.Count}");
                }
            }
            Console.WriteLine("--finish--");
            Console.ReadKey();
        }
    }
}
