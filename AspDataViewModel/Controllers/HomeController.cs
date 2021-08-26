using AspDataViewModel.Models;
using AspDataViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
