using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public class Machine : Equipment
    {
        [Required(ErrorMessage = "Podaj szerokość roboczą")]
        [Display(Name = "Szerokość robocza (m)")]
        [Range(0.1, 30, ErrorMessage = "Szerokość robocza musi mieścić się w przzedziale od 0.1 do 30")]
        public ushort WorkingWidth { get; set; }

        [Required(ErrorMessage = "Podaj sposób pracy maszyną")]
        [Display(Name = "Wykonywana praca maszyny")]
        public string TypeOfWork { get; set; }

        [Display(Name = "Wymagana moc pociągowa (KM)")]
        [Range(1, 2000, ErrorMessage = "Moc potrzebna do pracy z maszyną musi mieścić się w przedziale od 1 do 2000")]
        public ushort? RequiredPower { get; set; }

        public Machine(string model,
            ushort productionYear,
            ushort workingWidth,
            string typeOfWork)
            : base(model, productionYear)
        {
            WorkingWidth = workingWidth;
            TypeOfWork = typeOfWork;
        }
    }
}
