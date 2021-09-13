using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        //Navigation Properties
        public List<PersonLanguage> personLanguagesList { get; set; }
    }
}
