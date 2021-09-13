using AspDataViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.ViewModels
{
    public class LanguageViewModel
    {
        public CreateLanguageViewModel createLanguageVM { get; set; }
        public List<Language> LanguagesList = new List<Language>();
        //public List<PersonLanguage> personLanguagesList = new List<PersonLanguage>();
    }
}
