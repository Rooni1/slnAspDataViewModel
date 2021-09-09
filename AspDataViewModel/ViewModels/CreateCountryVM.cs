using AspDataViewModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.ViewModels
{
    public class CreateCountryVM
    {
        public int CountryId { get; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "Name")]
        public string CountryName { get; set; }
        public List<City> cities { get; set; }
    }
}
