using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public class Combine : Vehicle
    {
        [Required(ErrorMessage = "Podaj ilość wytrząsaczy")]
        [Display(Name = "Liczba wytrząsaczy")]
        [Range(1, 20, ErrorMessage = "Liczba wytrząsaczy musi mieścić się w przedziale od 1 do 20")]
        public ushort NumberOfStrawWalkers { get; set; }

        public IList<Header> Headers { get; set; }
    }
}
