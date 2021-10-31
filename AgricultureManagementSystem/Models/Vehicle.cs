using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public abstract class Vehicle : Equipment
    {
        [Required(ErrorMessage = "Podaj przebieg")]
        [Display(Name = "Przebieg")]
        public ushort Course { get; set; }

        protected Vehicle(string brand,
            string model,
            ushort productionYear,
            ushort course)
            : base(brand,
                  model,
                  productionYear)
        {
            Course = course;
        }
    }
}
