using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspDataViewModel.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspDataViewModel.ViewModels
{
    public class CreatePersonViewModel
    {
        public MemoryPeopleRepo memoryPeopleRepo { get; set; }
       
        public int PersonId{get;}
        
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter City Name"), MaxLength(30)]
        [Display(Name = "City Name")]
        public string City { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter Phone Number"), MaxLength(30)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        //public SelectList selectList { get; set; }




    }
}
