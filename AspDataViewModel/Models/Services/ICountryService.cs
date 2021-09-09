using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Services
{
    public interface ICountryService
    {
        Country Add(CreateCountryVM createCountryVM);
        CountryViewModel All();
        CountryViewModel FindBy(CountryViewModel search);
        Country FindBy(int id);
    }
}
