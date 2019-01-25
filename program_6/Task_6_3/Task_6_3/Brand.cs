using System;
using System.Collections.Generic;
using System.Text;

namespace Task_6_3
{
    class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
       // public string Since { get; set; }
        //public string Actor { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
