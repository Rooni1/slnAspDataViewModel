using AspDataViewModel.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models 
{
    public class DatabasePeopleRepo: IdentityDbContext<ApplicationUser>
    {
        public DatabasePeopleRepo(DbContextOptions<DatabasePeopleRepo> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonLanguage>().HasOne(L => L.Language)
                                                 .WithMany(La => La.personLanguagesList)
                                                 .HasForeignKey(Li => Li.LanguageId);

            modelBuilder.Entity<PersonLanguage>().HasOne(L => L.Person)
                                                .WithMany(La => La.personLanguagesList);
          
        }
        
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> cities { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }


    }

}
