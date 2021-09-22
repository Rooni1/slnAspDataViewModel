using AspDataViewModel.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.ViewModels
{
    public class CreateManageRoleViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<IdentityRole> userRoleList { get; set; } = new List<IdentityRole>();
        public List<ApplicationUser> applicationUserList { get; set; } = new List<ApplicationUser>();
        public Register Register{ get; set; }
    }
}
