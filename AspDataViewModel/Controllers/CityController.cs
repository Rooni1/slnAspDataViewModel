using AspDataViewModel.Models;
using AspDataViewModel.Models.Services;
using AspDataViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _iCityService;
        private readonly DatabasePeopleRepo _cityContext;
        public CityController(ICityService cityService,DatabasePeopleRepo cityContext)
        {
            _iCityService = cityService;
            _cityContext = cityContext;
        }
        public IActionResult CityView()
        {
            CityViewModel cityVM = new CityViewModel();
           cityVM.cityList = _cityContext.cities.Include(c => c.country).ToList();
            cityVM.countriesList = _cityContext.Country.ToList();

            return View(cityVM);
            

        }
        [HttpPost]
        public IActionResult CityView(CreateCityVM createCityVM)
        {
            City addcity = new City();
            addcity = _iCityService.Add(createCityVM);
            _cityContext.Add(addcity);
            _cityContext.SaveChanges();
            CityViewModel cityVM = new CityViewModel();
            cityVM.cityList = _cityContext.cities.Include(c => c.country).ToList();
            return View(cityVM);
     
            //return RedirectToAction(nameof(CityView));
        }
        public IActionResult Delete(int id)
        {

            _iCityService.Remove(id);
            return View("CityView", _iCityService.All());


        }
    }
}
