using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Repo
{
    public class LanguageRapo : ILanguageRepo
    {
        DatabasePeopleRepo _databaselanguageRapo;
        public static List<Language> languageList = new List<Language>();
        public LanguageRapo(DatabasePeopleRepo datababelanguageRepo)
        {
            _databaselanguageRapo = datababelanguageRepo;
        }
        public Language CreateLanguage(CreateLanguageViewModel createLanguageVM)
        {
            Language createLanguage = new Language { LanguageName = createLanguageVM.LanguageName};
            languageList.Add(createLanguage);
           
            return createLanguage;
        }

        public bool Delete(Language language)
        {
            throw new NotImplementedException();
        }

        public List<Language> Read()
        {
            languageList = _databaselanguageRapo.Languages.ToList();
            return languageList;
        }

        public Language Read(int id)
        {
            languageList = _databaselanguageRapo.Languages.ToList();
            foreach (Language lang in languageList)
            {
                if (lang.LanguageId == id)
                {
                    return lang;
                }
            }
            return null;
        }
    }
}
