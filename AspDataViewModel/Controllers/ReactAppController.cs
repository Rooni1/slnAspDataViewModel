using AspDataViewModel.Models;
using AspDataViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ReactAppController : Controller
    {
        private readonly PeopleService _peopleService;
        public ReactAppController(PeopleService peopleService)
        {
            _peopleService = peopleService;
                
        }
        [HttpGet]
        //[Route("GetPerson")]
        public ActionResult<List<PeopleViewModel>> GetPerson()
        {

            PeopleViewModel people = _peopleService.All();
            return Ok(people);
        }

        [HttpGet]
        //[Route("Hello")]
        public IActionResult Hello()
        {
            return Ok("people");
        }
    }
}
