using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public class Transfer
    {
        private bool transferIn;

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj datę i godzinę")]
        [Display(Name = "Data i godzina")]
        public DateTime DateTime { get; set; }

#nullable enable
        [Display(Name = "Odbiorca")]
        public string? Recipient { get; set; }

        [Display(Name = "Nadawca")]
        public string? Sender { get; set; }
#nullable disable

        [Required(ErrorMessage = "Podaj kwotę przelewu")]
        [Display(Name = "Kwota przelewu (zł)")]
        [Range(0.01, 100000000, ErrorMessage = "Podana kwota musi mieścić się w przedziale od 0,01 do 100 000 000 zł")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Podaj tytuł przelewu")]
        [Display(Name = "Tytuł przelewu")]
        public string Title { get; set; }

        public bool TransferIn
        {
            get => transferIn;
            set => transferIn = value;
        }
        public bool TransferOut
        {
            get => !transferIn;
        }
    }
}
