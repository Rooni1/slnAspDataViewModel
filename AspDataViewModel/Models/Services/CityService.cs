using AspDataViewModel.Models.Repo;
using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Services
{
    public class CityService : ICityService
    {
        ICityRepo _cityRepo;
        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
                
        }
        public City Add(CreateCityVM createCityVM)
        {
            return _cityRepo.CreateCity(createCityVM);
        }

        public CityViewModel All()
        {
            CityViewModel cityViewModel = new CityViewModel{ cityList = _cityRepo.Read() };
            return cityViewModel;
        }

        public CityViewModel FindBy(CityViewModel search)
        {
            throw new NotImplementedException();
        }

        public City FindBy(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            City cityToRemove = _cityRepo.Read(id);
            return _cityRepo.Delete(cityToRemove);
        }
    }
}
