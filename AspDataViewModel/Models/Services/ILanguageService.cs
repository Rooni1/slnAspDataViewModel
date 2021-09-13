using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Services
{
    public interface ILanguageService
    {
        public Language Add(CreateLanguageViewModel createLanguageVM);
        LanguageViewModel All();
        LanguageViewModel FindBy(LanguageViewModel search);
        Language FindBy(int id);
        bool Remove(int id);
    }
}
