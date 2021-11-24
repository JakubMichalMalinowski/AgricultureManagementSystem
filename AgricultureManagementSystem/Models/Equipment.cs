using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public abstract class Equipment
    {
        [Key]
        public int Id { get; set; }

#nullable enable
        [Display(Name = "Marka")]
        public string? Brand { get; set; }
#nullable disable

        [Required(ErrorMessage = "Podaj model")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Podaj rok produkcji")]
        [Display(Name = "Rok produkcji")]
        [Range(1900, 2100, ErrorMessage = "Rok produkcji musi mieścić się w przedziale od 1900 do 2100")]
        public ushort ProductionYear { get; set; }

        protected Equipment(string model,
            ushort productionYear)
        {
            Model = model;
            ProductionYear = productionYear;
        }
    }
}
