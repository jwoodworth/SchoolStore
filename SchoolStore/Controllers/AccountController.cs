using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SchoolStore.Models;

namespace SchoolStore.Controllers
{
    public class AccountController : Controller
    {
        //Using Microsoft.AspNetCore.Identity
        private SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            this._signInManager = signInManager;
        }

        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Index()
        {

            return Content("You can only see this if you're signed in!");
        }

        public IActionResult Register()
        {
            return View();
        }


        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string username, string password)
        {
            if (ModelState.IsValid)
            {
                IdentityUser newUser = new IdentityUser(username);
                var userResult = _signInManager.UserManager.CreateAsync(newUser).Result;
                if (userResult.Succeeded)  
                {
                    var passwordResult = _signInManager.UserManager.AddPasswordAsync(newUser, password).Result;
                    if (passwordResult.Succeeded)
                    {
                        _signInManager.SignInAsync(newUser, false).Wait();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in passwordResult.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                        _signInManager.UserManager.DeleteAsync(newUser).Wait();
                    }
                }
                else
                {
                    foreach (var error in userResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                IdentityUser currentUser = await _signInManager.UserManager.FindByNameAsync(username);
                if (currentUser != null)
                {
                    var lockOut = false;
                    var result = await _signInManager.CheckPasswordSignInAsync(currentUser, password, lockOut);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(currentUser, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        if (result.IsLockedOut)
                        {
                            ModelState.AddModelError("username", "This account is currently locked out");
                        }
                        else
                        {
                            ModelState.AddModelError("username", "Either username or password is invalid");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("username", "Either username or password is invalid");
                }
            }
            // If we got this far, something failed, redisplay form
            return View();
        }

        public IActionResult ChangePWD()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePWD(string username, string currentPassword, string newPassword)
        {
            if (ModelState.IsValid)
            {
                IdentityUser currentUser = await _signInManager.UserManager.FindByNameAsync(username);
                if (currentUser != null)
                {
                    var lockOut = false;
                    var result = await _signInManager.CheckPasswordSignInAsync(currentUser, currentPassword, lockOut);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(currentUser, false);
                        await _signInManager.UserManager.ChangePasswordAsync(currentUser, currentPassword, newPassword);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        if (result.IsLockedOut)
                        {
                            ModelState.AddModelError("username", "This account is currently locked out");
                        }
                        else
                        {
                            ModelState.AddModelError("username", "Either username or password is invalid");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("username", "Either username or password is invalid");
                }
            }
            // If we got this far, something failed, redisplay form
            return View();
        }




    }
}