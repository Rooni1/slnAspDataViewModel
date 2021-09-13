using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        //public string City { get; set; }

        //navigation peropertiies

        //public int CityId { get; set; }
        public City city { get; set; }
        //public int CountryId { get; set; }

        public List<PersonLanguage> personLanguagesList { get; set; }



    }
}
