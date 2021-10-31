using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public abstract class Equipment
    {
        [Required(ErrorMessage = "Podaj markę")]
        [Display(Name = "Marka")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Podaj model")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Podaj rok produkcji")]
        [Display(Name = "Rok produkcji")]
        public ushort ProductionYear { get; set; }

        protected Equipment(string brand,
            string model,
            ushort productionYear)
        {
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
        }
    }
}
