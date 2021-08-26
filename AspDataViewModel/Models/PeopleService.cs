using AspDataViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace AspDataViewModel.Models
{
    public class PeopleService : IPeopleService
    {
        readonly IPeopleRepo _peopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
                
        }
       
        public  Person Add(CreatePersonViewModel CPview)
        {

            MemoryPeopleRepo MPRepo = new MemoryPeopleRepo();
            Person newperson = MPRepo.Create(CPview.Name,
                                            CPview.PhoneNumber, CPview.CityName);
            return newperson;

        }

        public PeopleViewModel All()
        {
            MemoryPeopleRepo MPRepo = new MemoryPeopleRepo();
            PeopleViewModel peopleVM = new PeopleViewModel();
            peopleVM.peopleList = MPRepo.Read();
            
            return peopleVM;
        }

        public Person Edit(int id, Person person)
        {
            throw new NotImplementedException();
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            throw new NotImplementedException();
        }

        public Person FindBy(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
