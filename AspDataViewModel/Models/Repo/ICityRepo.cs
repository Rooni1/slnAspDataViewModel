using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Repo
{
    public interface ICityRepo
    {
        public City CreateCity(CreateCityVM createCityVM);
        List<City> Read();
        City Read(int id);
        bool Delete(City city);
    }
}
