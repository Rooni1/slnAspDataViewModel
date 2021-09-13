using AspDataViewModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.ViewModels
{
    public class CreateLanguageViewModel
    {
        public int LanguageId { get; }

        [DataType(DataType.Text)]
        //[Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "Name")]
        public string LanguageName { get; set; }
        public List<PersonLanguage> personLanguagesList = new List<PersonLanguage>();
    }
}
