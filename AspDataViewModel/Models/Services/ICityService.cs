using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Services
{
    public interface ICityService
    {
        public City Add(CreateCityVM createCityVM);
        CityViewModel All();
        CityViewModel FindBy(CityViewModel search);
        City FindBy(int id);
        bool Remove(int id);
    }
}
