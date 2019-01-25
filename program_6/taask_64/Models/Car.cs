using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taask_64
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Power { get; set; }
        public int Count { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
