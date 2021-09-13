using AspDataViewModel.Models;
using AspDataViewModel.Models.Services;
using AspDataViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageSevice;
        private readonly DatabasePeopleRepo _languageContext;
        public LanguageController(DatabasePeopleRepo languageContext,ILanguageService languageService)
        {
            _languageSevice = languageService;
            _languageContext = languageContext;
        }
        public IActionResult LanguageView()
        {
            LanguageViewModel languageVM = new LanguageViewModel();
            languageVM.LanguagesList = _languageContext.Languages.ToList();
            return View(languageVM);

        }
        [HttpPost]
        public IActionResult LanguageView(CreateLanguageViewModel createLanguageVM)
        {
            Language addLanguage = new Language();
            addLanguage = _languageSevice.Add(createLanguageVM);
            _languageContext.Add(addLanguage);
            _languageContext.SaveChanges();
            LanguageViewModel languageVM = new LanguageViewModel();
            languageVM.LanguagesList = _languageContext.Languages.ToList();

            return View(languageVM);
        }
    }
}
