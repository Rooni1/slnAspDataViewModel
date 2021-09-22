using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.ViewModels
{
    public class CreateUserRoleViewModelcs
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "Name")]
        public string RoleName { get; set; }


    }
}
