using AspDataViewModel.Models;
using AspDataViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;


namespace AspDataViewModel.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DatabasePeopleRepo _dbContext;
       
        public AdministrationController(RoleManager<IdentityRole> roleManager, 
                                        UserManager<ApplicationUser> userManager,
                                        DatabasePeopleRepo dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(UserRoleViewModel userRoleVM)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = userRoleVM.createUserRoleVM.RoleName
                };
               
               var result =  await _roleManager.CreateAsync(identityRole);
               if(result.Succeeded)
                {
                    return Redirect("https://localhost:44352/");
                }
               foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
           
            return View(userRoleVM);
        }
        public IActionResult ManageUserRole()
        {
         
            CreateManageRoleViewModel manageRoleVM = new CreateManageRoleViewModel();

            manageRoleVM.userRoleList = _dbContext.Roles.ToList();

            manageRoleVM.applicationUserList = _dbContext.Users.ToList();
          
            return View(manageRoleVM);
        }
        [HttpPost]
        public async Task<IActionResult> ManageUserRole(CreateManageRoleViewModel createManageRV)
        {

            var user = await _userManager.FindByIdAsync(createManageRV.Register.UserId);
            var role = await _roleManager.FindByIdAsync(createManageRV.RoleId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {createManageRV.Register.UserId} cannot be found";
                return View("ManageUserRole");
            }
            
            await _userManager.AddToRoleAsync(user,role.Name);

            return Redirect("https://localhost:44352/Login/LoginView");
        }
    }
}
