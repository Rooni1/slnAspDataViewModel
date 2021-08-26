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
        public int PersonId { get { return personId; } }

        private static int IdCounter()
        {
            return ++personId;
        }
   
        public Person Create(string name,string phoneNumber,string city)
        {
            Person createPerson = new Person{Id =IdCounter(),Name = name,PhoneNumber = phoneNumber,City=city };

            personList.Add(createPerson);          
            return createPerson;
        }

        public List<Person> Read()
        {
            return personList;
        }

        public Person Read(int id)
        {
            foreach(Person per in personList)
            {
                if(personId == id)
                {
                    return per;
                }
            }
            return null;
        }

        public Person Update(Person person)
        {
            foreach(Person perToUpdate in personList)
            {
                if(perToUpdate.Name == person.Name)
                {
                    perToUpdate.Name = person.Name;
                    perToUpdate.City = person.City;
                    perToUpdate.PhoneNumber = person.PhoneNumber;
                    return perToUpdate;
                    break;
                }
            }
            return null;
        }

        public bool Delete(Person person)
        {
            
            personList.Remove(person);
            return true;
           
        }

       
    }
}
