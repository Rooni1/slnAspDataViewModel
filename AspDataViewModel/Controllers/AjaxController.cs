using AspDataViewModel.Models;
using AspDataViewModel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Controllers
{
    [Authorize]
    public class AjaxController : Controller
    {
        private readonly IPeopleService _ipeopleService;
        private readonly DatabasePeopleRepo _peopleContext;


        public AjaxController(IPeopleService ipeopleService, DatabasePeopleRepo peopleContext)
        {
            _ipeopleService = ipeopleService;
            _peopleContext = peopleContext;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult People()
        {
            PeopleViewModel peopleVM = new PeopleViewModel();
            peopleVM.peopleList = _peopleContext.People.Include(p => p.city).ToList();
            peopleVM.personLanguagesList = _peopleContext.PersonLanguages.Include(l => l.Language).ToList();
            peopleVM.personLanguagesList = _peopleContext.PersonLanguages.Include(l => l.Person).ToList();
            peopleVM.countryList = _peopleContext.Country.ToList();
            return PartialView("_peopleAjaxPartialView", _ipeopleService.All().peopleList);
            //return View(PeopleView ,peopleVM);
           

        }

        [Authorize(Roles ="Admin")]
        public IActionResult Delete(int id)
        {
           
            if (id != 0)
            {
                _ipeopleService.Remove(id);
                ViewBag.Message = $"Person with id = {id} is deleted";
                return PartialView("_deletePeopleAjaxView", ViewBag.Message);
            }
            else
            {
                ViewBag.Message = $"Please enter the person Id";
                return PartialView("_deletePeopleAjaxView", ViewBag.Message);
            }
        }
        public IActionResult PerDetail(int id)
        {
            if (id != 0)
            {

                return PartialView("_peopleAjaxDetailView", _ipeopleService.FindBy(id));
            }
            else 
            {
                ViewBag.Message = $"Please enter the person Id";
                return PartialView("_peopleAjaxDetailView", ViewBag.Message);
            }

        }
       
        public IActionResult UpDate(int id)
        {
            return PartialView("_editPeoplePartialView", _ipeopleService.FindBy(id));
        }
       
        [HttpPost]
        public IActionResult Edit(int id,Person upDatedPerson)
        {
            return PartialView("_editPeoplePartialView", _ipeopleService.Edit(id, upDatedPerson));
            
        }


    }
}
