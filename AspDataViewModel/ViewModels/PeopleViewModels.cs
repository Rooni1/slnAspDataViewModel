using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDataViewModel.Models;

namespace AspDataViewModel.ViewModels
{
    public class PeopleViewModel
    {
        public CreatePersonViewModel CreatePersonVM { get; set; }
        public List<Person> peopleList = new List<Person>();
        public List<City> cityList = new List<City>();
        public List<PersonLanguage> personLanguagesList { get; set; } = new List<PersonLanguage>();
        public List<Language> languageList { get; set; } = new List<Language>();
        public List<Country> countryList { get; set; } = new List<Country>();

        public string FilterText { get; set; }

    }
}
