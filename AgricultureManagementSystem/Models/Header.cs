﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public ushort Width { get; set; }

        public Header(string model,
            ushort productionYear,
            HeaderType headerType,
            ushort width)
            : base(model, productionYear)
        {
            HeaderType = headerType;
            Width = width;
        }
    }
}