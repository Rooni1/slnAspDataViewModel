using AspDataViewModel.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models 
{
    public class DatabasePeopleRepo: DbContext
    {
        public DatabasePeopleRepo(DbContextOptions<DatabasePeopleRepo> options):base(options)
        {

        }
        public DbSet<Person> People { get; set; }
    }

}
