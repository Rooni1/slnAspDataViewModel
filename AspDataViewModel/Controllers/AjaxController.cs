using AspDataViewModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IPeopleService _ipeopleService;


        public AjaxController(IPeopleService ipeopleService)
        {
            _ipeopleService = ipeopleService;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult People()
        {
            return PartialView("_peopleAjaxPartialView", _ipeopleService.All().peopleList);
        }
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

    }
}
