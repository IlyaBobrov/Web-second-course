﻿using System.Collections.Generic;
using AdminCar.Models;


namespace AdminCar.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Brand> Brands { get; set; }

        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}

