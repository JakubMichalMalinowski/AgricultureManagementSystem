using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public abstract class Vehicle : Equipment
    {
        public ushort Course { get; set; }

        protected Vehicle(string name,
            ushort productionYear,
            ushort course,
            string photoPath = null)
            : base(name,
                  productionYear,
                  photoPath)
        {
            Course = course;
        }
    }
}
