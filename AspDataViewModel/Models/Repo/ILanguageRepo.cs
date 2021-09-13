using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Repo
{
    public interface ILanguageRepo
    {
        public Language CreateLanguage(CreateLanguageViewModel createCityVM);
        List<Language> Read();
        Language Read(int id);
        bool Delete(Language language);
    }
}
