using System;
using System.ComponentModel.DataAnnotations;

namespace AgricultureManagementSystem.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj poprawną datę")]
        [Display(Name = "Data i czas")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Podaj nazwę")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

#nullable enable
        [Display(Name = "Opis")]
        public string? Description { get; set; }
#nullable disable
    }
}
