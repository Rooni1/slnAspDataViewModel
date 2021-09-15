using AspDataViewModel.Models.Repo;
using AspDataViewModel.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models
{
    public class MemoryPeopleRepo 
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
   
       
       
    }
}
