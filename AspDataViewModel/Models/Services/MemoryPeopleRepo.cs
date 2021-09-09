using AspDataViewModel.Models.Repo;
using AspDataViewModel.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models
{
    public class MemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> personList = new List<Person>();
        private static int personId;
        DatabasePeopleRepo _databasePeopleRepo;
        ICityRepo _cityRepo;

        public MemoryPeopleRepo(DatabasePeopleRepo databasePeopleRepo,ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
            _databasePeopleRepo = databasePeopleRepo;
        }


        public int PersonId { get { return personId; } }

        private static int IdCounter()
        {
            return ++personId;
        }
   
        public Person Create(CreatePersonViewModel createPersonVM)
        {
            City myCity = _cityRepo.Read(Convert.ToInt32(createPersonVM.City));
            Person createPerson = new Person{Name = createPersonVM.Name, 
                PhoneNumber = createPersonVM.PhoneNumber,city = myCity};

            personList.Add(createPerson);          
            return createPerson;
        }

        public List<Person> Read()
        {

            return personList = _databasePeopleRepo.People.Include(p => p.city).ToList();

        }

        public Person Read(int id)
        {
            personList = _databasePeopleRepo.People.Include(p => p.city).ToList();
            foreach (Person per in personList )
            {
                if(per.Id == id)
                {
                    return per;
                }
            }
            return null;
        }

        public Person Update(Person person)
        {
            _databasePeopleRepo.Update(person);
            _databasePeopleRepo.SaveChanges();
            personList = _databasePeopleRepo.People.ToList();
            foreach (Person per in personList)
            {
                if (per.Id == person.Id)
                {
                    return per;
                }
            }
            return null;
            
        }

        public bool Delete(Person person)
        {
            _databasePeopleRepo.Remove(person);
            _databasePeopleRepo.SaveChanges();
            //personList.Remove(person);
            return true;
           
        }

       
    }
}
