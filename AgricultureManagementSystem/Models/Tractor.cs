using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public class Tractor : Vehicle, IEngine
    {
        [Display(Name = "Prędkość maksymalna (km/h)")]
        [Range(1, 100, ErrorMessage = "Prędkość musi mieścić się w przedziale od 1 do 100")]
        public ushort? MaxSpeed { get; set; }

        [Required(ErrorMessage = "Podaj rodzaj paliwa")]
        [Display(Name = "Rodzaj paliwa")]
        public FuelType FuelType { get; set; }

        [Display(Name = "Pojemność zbiornika paliwa (l)")]
        [Range(1, 10000, ErrorMessage = "Pojemność zbiornika paliwa musi mieścić się w przedziale od 1 do 10 000")]
        public ushort? FuelCapacity { get; set; }

        [Required(ErrorMessage = "Podaj moc silnika")]
        [Display(Name = "Moc silnika (KM)")]
        [Range(1, 2000, ErrorMessage = "Moc silnika musi mieścić się w przedziale od 1 do 2000")]
        public ushort Power { get; set; }
    }
}
