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
        private readonly IPeopleRepo _ipeopleRepo;
              
        public PeopleController(IPeopleService ipeopleService,IPeopleRepo ipeopleRepo)
        {
            
            _ipeopleService = ipeopleService;
            _ipeopleRepo = ipeopleRepo;
        }


        
        public IActionResult PeopleView()
        {

            return View();
        }
        [HttpPost]
        public IActionResult PeopleView(CreatePersonViewModel createPersonViewModel)
        {

            _ipeopleService.Add(createPersonViewModel);
            return View();
        }
       

        [HttpGet]
        public IActionResult ShowPeople()
        {
            PeopleViewModel peopleVM = new PeopleViewModel();
            peopleVM = _ipeopleService.All();
            return View(peopleVM);

        }


    }
}
