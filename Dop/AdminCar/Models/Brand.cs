using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCar.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string Site { get; set; }

        //public virtual List<Car> Cars { get; set; }
        public List<Car> Cars { get; set; }
        public Brand()
        {
            Cars = new List<Car>();
        }
    }
}
