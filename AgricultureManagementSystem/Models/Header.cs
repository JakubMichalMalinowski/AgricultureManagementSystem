﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AgricultureManagementSystem.Models
{
    public class Header : Equipment
    {
        [Required(ErrorMessage = "Podaj rodzaj przystawki")]
        [Display(Name = "Rodzaj przystawki")]
        public HeaderType HeaderType { get; set; }

        [Required(ErrorMessage = "Podaj szerokość roboczą przystawki")]
        [Display(Name = "Szerokość robocza przystawki (m)")]
        [Range(0.1, 30, ErrorMessage = "Szerokość przystawki musi mieścić się w zakresie od 0.1 do 30")]
        public float Width { get; set; }

        public void Update(Header header)
        {
            Brand = header.Brand;
            Model = header.Model;
            ProductionYear = header.ProductionYear;
            HeaderType = header.HeaderType;
            Width = header.Width;
        }
    }
}
