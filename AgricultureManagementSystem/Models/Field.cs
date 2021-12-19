using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgricultureManagementSystem.Models
{
    public class Field
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj lokalizację")]
        [Display(Name = "Lokalizacja")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Podaj powierzchnię")]
        [Display(Name = "Powierzchnia (ha)")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "Podaj poprawną powierzchnię")]
        public double Area { get; set; }

        public IList<Activity> Activities { get; } = new List<Activity>();

#nullable enable
        [Display(Name = "Klasa gruntu")]
        public string? GroundClass { get; set; }

        [Display(Name = "Uprawa polowa")]
        public string? FieldCrop { get; set; }
#nullable disable
    }
}
