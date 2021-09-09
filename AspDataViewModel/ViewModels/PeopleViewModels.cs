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
        public string FilterText { get; set; }



    }
}
