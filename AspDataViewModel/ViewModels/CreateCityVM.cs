using AspDataViewModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.ViewModels
{
    public class CreateCityVM
    {
        public int CityId { get; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "Name")]
         public string CityName { get; set; }

        public List<Person> People { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
    }
} 
