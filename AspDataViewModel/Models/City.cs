using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }

        // navigation properties to create relation
        //public int CountryId { get; set; }
        public Country country { get; set; }
        public List<Person> person { get; set; }
    }
}
