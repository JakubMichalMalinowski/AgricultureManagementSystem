using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public abstract class Equipment
    {
        public string Name { get; set; }
        public ushort ProductionYear { get; set; }
        public string PhotoPath { get; set; }

        protected Equipment(string name,
            ushort productionYear,
            string photoPath = null)
        {
            Name = name;
            ProductionYear = productionYear;
            PhotoPath = photoPath;
        }
    }
}
