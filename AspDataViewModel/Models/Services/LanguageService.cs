using AspDataViewModel.Models.Repo;
using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Services
{
    public class LanguageService : ILanguageService
    {
        ILanguageRepo _iLanguageRepo;
        public LanguageService(ILanguageRepo ilanguageRepo)
        {
            _iLanguageRepo = ilanguageRepo;
                
        }
        public Language Add(CreateLanguageViewModel createLanguageVM)
        {
            return _iLanguageRepo.CreateLanguage(createLanguageVM);
        }

        public LanguageViewModel All()
        {
            throw new NotImplementedException();
        }

        public LanguageViewModel FindBy(LanguageViewModel search)
        {
            throw new NotImplementedException();
        }

        public Language FindBy(int id)
        {
            return _iLanguageRepo.Read(id);
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
