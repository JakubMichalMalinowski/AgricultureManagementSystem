using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public class Tractor : Vehicle, IEngine
    {
        [Required(ErrorMessage = "Podaj prędkość maksymalną")]
        [Display(Name = "Prędkość maksymalna")]
        public uint MaxSpeed { get; set; }

        [Required(ErrorMessage = "Podaj rodzaj paliwa")]
        [Display(Name = "Rodzaj paliwa")]
        public FuelType FuelType { get; set; }

        [Required(ErrorMessage = "Podaj pojemność zbiornika paliwa")]
        [Display(Name = "Pojemność zbiornika paliwa")]
        public ushort FuelCapacity { get; set; }

        [Required(ErrorMessage = "Podaj moc silnika")]
        [Display(Name = "Moc silnika")]
        public ushort Power { get; set; }

        public Tractor(string brand,
            string model,
            ushort productionYear,
            ushort course,
            uint maxSpeed,
            FuelType fuelType,
            ushort fuelCapacity,
            ushort power)
            : base(brand,
                  model,
                  productionYear,
                  course)
        {
            MaxSpeed = maxSpeed;
            FuelType = fuelType;
            FuelCapacity = fuelCapacity;
            Power = power;
        }
    }
}
