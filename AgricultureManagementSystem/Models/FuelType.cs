using System.ComponentModel.DataAnnotations;

namespace AgricultureManagementSystem.Models
{
    public enum FuelType
    {
        [Display(Name = "Diesel")]
        Diesel,

        [Display(Name = "Benzyna")]
        Gasoline,

        [Display(Name = "LPG")]
        LPG,

        [Display(Name = "Napęd elektryczny")]
        Electric,

        [Display(Name = "Napęd hybrydowy")]
        Hybrid
    }
}
