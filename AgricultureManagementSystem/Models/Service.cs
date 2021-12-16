using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj prawidłową datę")]
        [Display(Name = "Data i godzina")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Podaj rodzaj czynności")]
        [Display(Name = "Rodzaj czynności")]
        public string ServiceType { get; set; }

#nullable enable
        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string? ServiceDescription { get; set; }
#nullable disable

        public void Update(Service service)
        {
            DateTime = service.DateTime;
            ServiceType = service.ServiceType;
            ServiceDescription = service.ServiceDescription;
        }
    }
}
