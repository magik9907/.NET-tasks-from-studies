using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Display(Name = "Twoja ulubiona ulica")]
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "pole obowiazkowe")]
        public string Street { get; set; }
        [Display(Name = "Kod pocztow")]
        [StringLength(6)]
        [Required(ErrorMessage = "pole obowiazkowe")]
        public string ZipCode { get; set; }
        [Display(Name = "Miasto")]
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "pole obowiazkowe")]
        public string City { get; set; }
        [Display(Name = "numer")]
        [Required(ErrorMessage = "pole obowiazkowe")]
        public int Number { get; set; }
    }
}
