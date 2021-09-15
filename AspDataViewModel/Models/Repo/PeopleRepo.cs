using AspDataViewModel.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models.Repo
{
    public class PeopleRepo : IPeopleRepo
    {
        private static List<Person> personList = new List<Person>();
        DatabasePeopleRepo _databasePeopleRepo;
        ICityRepo _cityRepo;
        public PeopleRepo(DatabasePeopleRepo databasePeopleRepo,ICityRepo cityRepo)
        {
            _databasePeopleRepo = databasePeopleRepo;
            _cityRepo = cityRepo;
                
        }
        public Person Create(CreatePersonViewModel createPersonVM)
        {
            City myCity = _cityRepo.Read(Convert.ToInt32(createPersonVM.City));
            Person createPerson = new Person
            {
                Name = createPersonVM.Name,
                PhoneNumber = createPersonVM.PhoneNumber,
                city = myCity
            };
            _databasePeopleRepo.Add(createPerson);
            _databasePeopleRepo.SaveChanges();

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
            personList = _databasePeopleRepo.People.Include(p => p.personLanguagesList).ToList();

            foreach (Person per in personList)
            {
                if (per.Id == id)
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
