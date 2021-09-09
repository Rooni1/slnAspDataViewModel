using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace AspDataViewModel.Models
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
                
        }

        public Person Add(CreatePersonViewModel CPview)
        {

            //MemoryPeopleRepo MPRepo = new MemoryPeopleRepo();

            //Person newperson = MPRepo.Create(CPview);

            //CreatePersonViewModel newperson = new CreatePersonViewModel
            //{
            //    Name = CPview.Name,
            //    City = CPview.City,
            //    PhoneNumber = CPview.PhoneNumber
            //};
            //return MPRepo.Create(newperson);
            return _peopleRepo.Create(CPview);
            //return MPRepo.Create(CPview);
            //return newperson;

        }

        public PeopleViewModel All()
        {
            
            //PeopleViewModel peopleVM = new PeopleViewModel();
            
            //peopleVM.peopleList = _peopleRepo.Read();
            
            PeopleViewModel peopleViewModel = new PeopleViewModel { peopleList = _peopleRepo.Read() };
            return peopleViewModel;
        }

        public Person Edit(int id, Person person)
        {
            Person personToEdit = _peopleRepo.Update(person);
            return personToEdit;
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            List<Person> perList = new List<Person>();
          

            foreach (Person item in  _peopleRepo.Read())
            {
                if (item.Name.Contains(search.FilterText, StringComparison.OrdinalIgnoreCase))
                {
                    search.peopleList.Add(item);
                    break;
                }
            }

            return search;
        }

        public Person FindBy(int id)
        {
            Person perToFind = _peopleRepo.Read(id);
            return perToFind;
        }

        public bool Remove(int id)
        {
            Person perToRemove = _peopleRepo.Read(id);
            return _peopleRepo.Delete(perToRemove);
         
        }
        
    }
}
