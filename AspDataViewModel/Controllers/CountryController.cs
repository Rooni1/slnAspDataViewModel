using AspDataViewModel.Models;
using AspDataViewModel.Models.Services;
using AspDataViewModel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
       
        private readonly ICountryService _iCountryService;
        private readonly DatabasePeopleRepo _countryContext;

        public CountryController(ICountryService countryService, DatabasePeopleRepo countryContext)
        {
            _iCountryService = countryService;
            _countryContext = countryContext;
        }
        public IActionResult CountryView()
        {
            CountryViewModel countryVM = new CountryViewModel();
            countryVM.countryList = _countryContext.Country.ToList();

            return View(countryVM);

        }
        [HttpPost]
        public IActionResult CountryView(CreateCountryVM createCountryVM)
        {
           
            Country addCountry = new Country();
            addCountry = _iCountryService.Add(createCountryVM);
            _countryContext.Add(addCountry);
            _countryContext.SaveChanges();
            CountryViewModel countryVM = new CountryViewModel();
            countryVM.countryList = _countryContext.Country.ToList();
            return View(countryVM);
            //return RedirectToAction(nameof(CountryView));

        }

    }
}
