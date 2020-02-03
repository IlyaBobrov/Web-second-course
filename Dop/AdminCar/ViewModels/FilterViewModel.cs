using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using AdminCar.Models;

namespace AdminCar.ViewModels
{
    public class FilterViewModel
    {
        //список брендов
        public SelectList Brands { get; private set; }

        //бренд
        public int? SelectedBrand { get; private set; }

        //имя
        public string SelectedName { get; private set; }
        public FilterViewModel(List<Brand> brands, int? brand, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            brands.Insert(0, new Brand { Name = "All", Id = 0, Country = "not" });
            Brands = new SelectList(brands, "Id", "Name", brand);
            SelectedBrand = brand;
            SelectedName = name;
        }
    }
}
