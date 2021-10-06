using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Repo
{
    public class CountryRepo : ICountryRepo
    {
        //private static int countryId;
        //public int CountryId { get { return countryId; } }
        private static List<Country> countryList = new List<Country>();
        DatabasePeopleRepo _databasePeopleRepo;
        public CountryRepo(DatabasePeopleRepo databasePeopleRepo)
        {
            _databasePeopleRepo = databasePeopleRepo;
        }

        public Country CreateCountry(CreateCountryVM createCountryVM)
        {

            Country createCountry = new Country { CountryName = createCountryVM.CountryName };
            countryList.Add(createCountry);
            return createCountry;
             
        }

        public List<Country> Read()
        {
            countryList = _databasePeopleRepo.Country.ToList();
            return countryList;
        }

        public Country Read(int id)
        {
            Country selectedCountry = (from Country in _databasePeopleRepo.Country
                                 select Country)
                      .FirstOrDefault(Country => Country.CountryId == id);

            return selectedCountry;
        }
    }
}
