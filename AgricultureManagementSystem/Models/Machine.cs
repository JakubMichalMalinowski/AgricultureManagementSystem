using System;
using System.ComponentModel.DataAnnotations;

namespace AgricultureManagementSystem.Models
{
    public class Machine : Equipment
    {
        [Required(ErrorMessage = "Podaj szerokość roboczą")]
        [Display(Name = "Szerokość robocza (m)")]
        [Range(0.1, 30, ErrorMessage = "Szerokość robocza musi mieścić się w przzedziale od 0.1 do 30")]
        public float WorkingWidth { get; set; }

        [Required(ErrorMessage = "Podaj typ maszyny")]
        [Display(Name = "Typ maszyny")]
        public string TypeOfMachine { get; set; }

        [Display(Name = "Wymagana moc pociągowa (KM)")]
        [Range(1, 2000, ErrorMessage = "Moc potrzebna do pracy z maszyną musi mieścić się w przedziale od 1 do 2000")]
        public ushort? RequiredPower { get; set; }
    }
}
