using System;
using System.Linq;

namespace task_62
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (CarStoreContext db = new CarStoreContext())
            {
                // получаем объекты из бд и выводим на консоль
                var brands = db.Brands.ToList();
                Console.WriteLine("Бренды:");
                foreach (var u in brands)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Country}");
                }
            }
            Console.ReadKey();
        }
    }
}
