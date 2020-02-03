using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject_5.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название автомобиля")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите бренд автомобиля")]
        public string Brand { get; set; }

        [Range(1, 1500, ErrorMessage = "Мощность должна быть в пределах от 1 до 1500")]
        [Required(ErrorMessage = "Укажите мощность автомобиля")]
        public int Power { get; set; }

        [Range(0, 1000000000, ErrorMessage = "Цена должна быть в пределах от 1 до 1 000 000 000")]
        [Required(ErrorMessage = "Укажите цену автомобиля")]
        public int Price { get; set; }

        [Range(0, 100, ErrorMessage = "Кол-во должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите кол-во автомобилей")]
        public int Count { get; set; }

    }
}
