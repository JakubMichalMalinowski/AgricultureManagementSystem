using System;
using System.ComponentModel.DataAnnotations;

namespace AgricultureManagementSystem.Models
{
    public abstract class Vehicle : Equipment
    {
        [Required(ErrorMessage = "Podaj przebieg lub motogodziny")]
        [Display(Name = "Przebieg (km / mth)")]
        [Range(1, 10000000, ErrorMessage = "Przebieg musi mieścić się w przedziale od 1 do 10 000 000")]
        public uint Course { get; set; }

        protected Vehicle() { }
    }
}
