using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDataViewModel.Models;

namespace AspDataViewModel.ViewModels
{
    public class PeopleViewModel
    {
        public CreatePersonViewModel CreatePersonViewModel { get; set; }
        public List<Person> peopleList { get; set; }



    }
}
