using System;

namespace Program_5.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public DateTime CreationDate { get; set; }

        public TimeSpan LifeTime
        {
            get
            {
                return DateTime.Now.Subtract(CreationDate);
            }
        }
    }
}
