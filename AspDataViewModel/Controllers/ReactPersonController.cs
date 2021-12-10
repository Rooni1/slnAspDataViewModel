using AspDataViewModel.Models;
using AspDataViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Controllers
{
    public class ReactPersonController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly IPeopleRepo _peopleRepo;
        public ReactPersonController(IPeopleService peopleService, IPeopleRepo peopleRepo)
        {
            _peopleService = peopleService;
            _peopleRepo = peopleRepo;
        }
        public IActionResult Index()
        {

            PeopleViewModel people = _peopleService.All();
            return Json(people.peopleList);

        }
    }
}
