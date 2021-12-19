using System;
using System.ComponentModel.DataAnnotations;

namespace AgricultureManagementSystem.Models
{
    public class Trailer : Equipment
    {
        [Display(Name = "Masa własna (kg)")]
        [Range(1, 10000, ErrorMessage = "Masa własna musi mieścić się w przedziale od 1 do 10000")]
        public ushort? CurbWeight { get; set; }

        [Display(Name = "Ładowność - masa załadunkowa (kg)")]
        [Range(1, 30000, ErrorMessage = "Masa załadunkowa musi mieścić się w przedziale od 1 do 30000")]
        public ushort? CapacityKg { get; set; }

        [Display(Name = "Pojemność (m3)")]
        [Range(0.01, 100, ErrorMessage = "Pojemność musi mieścić się w przedziale od 0.01 do 100")]
        public float? CapacityM3 { get; set; }
    }
}
