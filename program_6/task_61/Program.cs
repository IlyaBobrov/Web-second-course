using System;
using System.Collections.Generic;
using System.Linq;

namespace task_61
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Brand Hyundai = new Brand { Name = "Hyundai", Country = "South Korea" };
                Brand Nissan = new Brand { Name = "Nissan", Country = "Japan" };
                Brand BMW = new Brand { Name = "BMW", Country = "Germany" };
                Brand Kia = new Brand { Name = "Kia", Country = "South Korea" };
                Brand Volkswagen = new Brand { Name = "Volkswagen", Country = "Germany" };
                Brand Mazda = new Brand { Name = "Mazda", Country = "Japan" };
                Brand Porche = new Brand { Name = "Porche", Country = "Germany" };
                Brand Tesla = new Brand { Name = "Tesla", Country = "USA" };

                List<Brand> Store = new List<Brand>() { Hyundai, Nissan, BMW, Kia, Volkswagen, Mazda, Porche, Tesla};


                // добавляем их в бд
                foreach(var v in Store)
                {
                    if (!db.Brands.Contains(v))
                    {
                        db.Brands.Add(v);
                    }
                }
                
                db.SaveChanges();
                Console.WriteLine("Бренды успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var brands = db.Brands.ToList();
                Console.WriteLine("Список брендов:");
                foreach (var u in brands)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Country}");
                }
            }
            Console.Read();
        }
    }
}
