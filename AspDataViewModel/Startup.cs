using AspDataViewModel.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using AspDataViewModel.Models.Repo;
using AspDataViewModel.Models.Services;

namespace AspDataViewModel
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
                
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPeopleRepo,MemoryPeopleRepo>();
            services.AddScoped<IPeopleService,PeopleService>();
            services.AddScoped<ICountryRepo, CountryRepo>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityRepo, CityRepo>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ILanguageRepo, LanguageRapo>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddControllersWithViews();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(15);

            });
            services.AddDbContext<DatabasePeopleRepo>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DbCString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=People}/{action=PeopleView}/{id?}");
                endpoints.MapControllerRoute(
                    name: "custom",
                    pattern: "{controller=Ajax}/{action=Index}/{id?}");
            });
        }
    }
}
