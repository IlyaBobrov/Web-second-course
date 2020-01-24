using System;
using System.Collections.Generic;

namespace Program_5.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public List<Car> Cars{ get; set; }
        public Brand()
        {
            Cars = new List<Car>();
        }
    }
}
