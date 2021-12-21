using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj tytuł")]
        [Display(Name = "Tytuł notatki")]
        public string Title { get; set; }

        [Display(Name = "Zawartość")]
        [DataType(DataType.MultilineText)]
#nullable enable
        public string? Content { get; set; }
#nullable disable

        public int Index { get; set; }
    }
}
