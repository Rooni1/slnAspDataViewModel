using AspDataViewModel.Models.Repo;
using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Services
{
    public class CountryService : ICountryService
    {
        ICountryRepo _countryRepo;
        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;


        }
        public Country Add(CreateCountryVM createCountryVM)
        {
            return _countryRepo.CreateCountry(createCountryVM);

        }

        public CountryViewModel All()
        {
            throw new NotImplementedException();
        }

        public CountryViewModel FindBy(CountryViewModel search)
        {
            throw new NotImplementedException();
        }

        public Country FindBy(int id)
        {
            throw new NotImplementedException();
        }
    }
}
