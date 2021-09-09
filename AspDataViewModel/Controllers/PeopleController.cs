using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDataViewModel.Models;
using AspDataViewModel.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AspDataViewModel.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _ipeopleService;
        private readonly DatabasePeopleRepo _peopleContext;
      

              
        public PeopleController(IPeopleService ipeopleService,DatabasePeopleRepo peopleContext)
        {
            
            _ipeopleService = ipeopleService;
            _peopleContext = peopleContext;
        }

       public IActionResult PeopleView()
        {
            PeopleViewModel peopleVM = new PeopleViewModel();
            peopleVM.cityList = _peopleContext.cities.ToList();

            //peopleVM = _ipeopleService.All();
            return View(peopleVM);
        }
        [HttpPost]
        public IActionResult PeopleView(CreatePersonViewModel createPersonVM)
        {
            Person addPerson = new Person();
            addPerson = _ipeopleService.Add(createPersonVM);
            //addPerson.Id = createPersonVM.PersonId;
            //addPerson.Name = createPersonVM.Name;
            //addPerson.PhoneNumber = createPersonVM.PhoneNumber;
            //addPerson.City = createPersonVM.City;

            _peopleContext.Add(addPerson);
            _peopleContext.SaveChanges();
            //_ipeopleService.Add(createPersonVM);
            PeopleViewModel peopleVM = new PeopleViewModel();
            peopleVM.peopleList = _peopleContext.People.Include(p => p.city).ToList();


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

             return View("PeopleView", _ipeopleService.FindBy(id));

        }
        public IActionResult Delete(int id)
        {

            _ipeopleService.Remove(id);
            return View("PeopleView",_ipeopleService.All());
           

        }



    }
}
