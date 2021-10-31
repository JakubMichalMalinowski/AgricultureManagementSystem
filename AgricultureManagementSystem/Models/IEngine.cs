using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    interface IEngine
    {
        public FuelType FuelType { get; set; }
        public ushort FuelCapacity { get; set; }
        public ushort Power { get; set; }
    }
}
