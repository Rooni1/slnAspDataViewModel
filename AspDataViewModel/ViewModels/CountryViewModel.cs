using AspDataViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.ViewModels
{
    public class CountryViewModel
    {
        public CreateCountryVM CreateCountryVM { get; set; }
        public List<Country> countryList = new List<Country>();
        public List<City> cityList = new List<City>();
    }
}
