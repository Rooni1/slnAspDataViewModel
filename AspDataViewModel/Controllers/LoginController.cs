using AspDataViewModel.Models;
using AspDataViewModel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AspDataViewModel.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatabasePeopleRepo _loginContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
       
        public LoginController(DatabasePeopleRepo loginContext, UserManager<IdentityUser> userManager, 
                               SignInManager<IdentityUser> signInManager)
        {
            _loginContext = loginContext;
            _userManager = userManager;
            _signInManager = signInManager;
           

        }
        public IActionResult RegisterView()
        {
            return View();
        }
        public IActionResult LoginView()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginView(LoginViewModel loginVM,string returnUrl=null)
        {
            if(ModelState.IsValid)
            {
                var resul = await _signInManager
                            .PasswordSignInAsync(
                            loginVM.createLoginVM.Email,
                             loginVM.createLoginVM.Password, loginVM.createLoginVM.RememberMe,
                              false);
                if(resul.Succeeded)
                {
                    if(returnUrl == null || returnUrl == "/")
                    {
                        return Redirect("https://localhost:44352/");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                ModelState.AddModelError("", "UserName or Passwod Incorrect");
            }
            return View("LoginView");
        }
        [HttpPost]
        public async Task<IActionResult> RegisterView(RegisterViewModel _regViewModel)
        {
            
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = _regViewModel.createRegVM.Email,
                    Email = _regViewModel.createRegVM.Email,
                                           
                };
                var result = await _userManager.CreateAsync(user, _regViewModel.createRegVM.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    return Redirect("https://localhost:44352/");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View("RegisterView");
        }
        
        public IActionResult LogoutView()
        {
           
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> LogoutView(string button)
        {
            string test = string.Format(button);
            if(test == "Yes")
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("LoginView");
            }
            else
            {
                return Redirect("https://localhost:44352/");
               
            }
            

        }
        public IActionResult NotLogoutView()
        {
            
            return View("/");

        }

    }
}
