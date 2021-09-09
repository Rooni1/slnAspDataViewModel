using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Repo
{
    public interface ICountryRepo
    {
        Country CreateCountry(CreateCountryVM createCountryVM);
        List<Country> Read();
        Country Read(int id);
    }
}
