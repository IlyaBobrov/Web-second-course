using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCar.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Power { get; set; }
        //public virtual Brand Brand { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
