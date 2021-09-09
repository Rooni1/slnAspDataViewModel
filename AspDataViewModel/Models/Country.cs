using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        // Navigation Property to create relationship
        public List<City> Cities { get; set; }
        //public List<Person> Persons { get; set; }
    }
}
