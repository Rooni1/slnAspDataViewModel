using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Repo
{
    public class CityRepo : ICityRepo
    {
        //private static int cityId;
        //public int CityId { get { return cityId; } }
        private static List<City> cityList = new List<City>();
        DatabasePeopleRepo _cityContext;
        ICountryRepo _countryRepo;
        //constructor
        public CityRepo(DatabasePeopleRepo cityContext,ICountryRepo countryRepo )
        {
            _countryRepo = countryRepo;
            _cityContext = cityContext;
        }
        public City CreateCity(CreateCityVM createCityVM)
        {
            Country myCountry = _countryRepo.Read(Convert.ToInt32(createCityVM.Country));
            City createCity = new City { CityName = createCityVM.CityName, country = myCountry };
            cityList.Add(createCity);
            return createCity;
        }

        public List<City> Read()
        {
            cityList = _cityContext.cities.ToList();
            return cityList;
        }

        public City Read(int id)
        {
            City selectedCity = (from city in _cityContext.cities
                               select city)
                      .FirstOrDefault(city => city.CityId == id);

            return selectedCity;
        }

        public bool Delete(City city)
        {
            _cityContext.Remove(city);
            _cityContext.SaveChanges();
            return true;
        }
    }
}
