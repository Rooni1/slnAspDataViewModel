using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDataViewModel.Models;
using AspDataViewModel.ViewModels;

namespace AspDataViewModel.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _ipeopleService;
      

              
        public PeopleController(IPeopleService ipeopleService)
        {
            
            _ipeopleService = ipeopleService;
           
        }

       public IActionResult PeopleView()
        {
            PeopleViewModel peopleVM = new PeopleViewModel();
            peopleVM = _ipeopleService.All();
            return View(peopleVM);
        }
        [HttpPost]
        public IActionResult PeopleView(CreatePersonViewModel createPersonVM)
        {
            _ipeopleService.Add(createPersonVM);
            return View(_ipeopleService.All());
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
        public IActionResult Delete(int id)
        {

            _ipeopleService.Remove(id);
            return View("PeopleView",_ipeopleService.All());
           

        }



    }
}
