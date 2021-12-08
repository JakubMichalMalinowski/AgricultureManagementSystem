using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public class Combine : Vehicle, IEngine
    {
        [Required(ErrorMessage = "Podaj ilość wytrząsaczy")]
        [Display(Name = "Liczba wytrząsaczy")]
        [Range(1, 20, ErrorMessage = "Liczba wytrząsaczy musi mieścić się w przedziale od 1 do 20")]
        public ushort NumberOfStrawWalkers { get; set; }

        public IList<Header> Headers { get; set; }

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
