using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDataViewModel.Models;
using AspDataViewModel.ViewModels;
using Microsoft.EntityFrameworkCore;
using AspDataViewModel.Models.Services;

namespace AspDataViewModel.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _ipeopleService;
        private readonly DatabasePeopleRepo _peopleContext;
        private readonly ILanguageService _languageService;
      

              
        public PeopleController(IPeopleService ipeopleService,DatabasePeopleRepo peopleContext, ILanguageService languageService)
        {
            
            _ipeopleService = ipeopleService;
            _peopleContext = peopleContext;
            _languageService = languageService;
        }

       public IActionResult PeopleView()
        {
            PeopleViewModel peopleVM = new PeopleViewModel();
           
            peopleVM.cityList = _peopleContext.cities.ToList();
            peopleVM.languageList = _peopleContext.Languages.ToList();
            peopleVM.peopleList = _peopleContext.People.Include(p => p.city).ToList();
            peopleVM.personLanguagesList = _peopleContext.PersonLanguages.Include(l => l.Language).ToList();
            peopleVM.personLanguagesList = _peopleContext.PersonLanguages.Include(l => l.Person).ToList();
            peopleVM.countryList = _peopleContext.Country.ToList();

            return View(peopleVM);
        }
        [HttpPost]
        public IActionResult PeopleView(CreatePersonViewModel createPersonVM)
        {
            //Creating Person and adding to database
            Person addPerson = new Person();
            addPerson = _ipeopleService.Add(createPersonVM);
            //_peopleContext.Add(addPerson);
            //_peopleContext.SaveChanges();

            // Ading values to personlanguage table
            for (int i = 0; i< createPersonVM.languageArray.Length;i++)
            {
                PersonLanguage perLanguage = new PersonLanguage
                {
                    PersonId = addPerson.Id,
                    LanguageId = createPersonVM.languageArray[i]
                };
                _peopleContext.PersonLanguages.Add(perLanguage);
                _peopleContext.SaveChanges();
            }
         
            PeopleViewModel peopleVM = new PeopleViewModel();
            peopleVM.peopleList = _peopleContext.People.Include(p => p.city).ToList();
            peopleVM.personLanguagesList = _peopleContext.PersonLanguages.Include(l => l.Language).ToList();
            peopleVM.personLanguagesList = _peopleContext.PersonLanguages.Include(l => l.Person).ToList();
            peopleVM.countryList = _peopleContext.Country.ToList();
            

            //return RedirectToAction(nameof(PeopleView));
            return View(peopleVM);
        }
                
        public IActionResult UpDate(int id,Person perToedit)
        {
            Person newPerUpdated =  _ipeopleService.Edit(id, perToedit);
            PeopleViewModel peopleVM = new PeopleViewModel();
            peopleVM = _ipeopleService.All();
            peopleVM.peopleList.Insert(id, newPerUpdated);

            return RedirectToAction(nameof(PeopleView));

        }
        public IActionResult FindByViewModel(PeopleViewModel peopleVM)
        {
           
            peopleVM = _ipeopleService.FindBy(peopleVM);

            return View("PeopleView",peopleVM);
           
           
            
        }
        public IActionResult FindById(int id)
        {

             return View("_peoplePartialView", _ipeopleService.FindBy(id));

        }
        public IActionResult Delete(int id)
        {

            _ipeopleService.Remove(id);
            return View("PeopleView",_ipeopleService.All());
           

        }
        
    }
}
