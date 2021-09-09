using AspDataViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.ViewModels
{
    public class CityViewModel
    {
        public CreateCityVM createCityVM { get; set; }
        public List<City> cityList = new List<City>();
        public List<Country> countriesList = new List<Country>();
    }
}
