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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonLanguage>().HasOne(L => L.Language)
                                                 .WithMany(La => La.personLanguagesList)
                                                 .HasForeignKey(Li => Li.LanguageId);

            modelBuilder.Entity<PersonLanguage>().HasOne(L => L.Person)
                                                .WithMany(La => La.personLanguagesList)
                                                .HasForeignKey(Li => Li.PersonId);
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> cities { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }


    }

}
