using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopStudy.Models;
using ShopStudy.NewDomain.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopStudy.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        // Post: /<controller>/
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var loginResult = await _signInManager.PasswordSignInAsync(model.UserName,
                model.Password,
                model.RememberMe,
                false);

            if (!loginResult.Succeeded)
            {
                ModelState.AddModelError("", "Entry is not possible");
                return View(model);
            }

            if (Url.IsLocalUrl(model.ReturnUrl))
                return Redirect(model.ReturnUrl);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);
            
            var newUser = new User(){UserName = model.UserName, Email = model.Email};
            var createUser = await _userManager.CreateAsync(newUser, model.Password);

            if (!createUser.Succeeded)
            {
                foreach (var identityError in createUser.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                    return View(model);
                }
            }

            await _signInManager.SignInAsync(newUser, false);
            await _userManager.AddToRoleAsync(newUser, "User");
            return RedirectToAction("Index", "Home");
        }
    }
}
