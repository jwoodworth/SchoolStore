using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SchoolStore.Models;
using SendGrid;
using Microsoft.AspNetCore.Http.Extensions;

namespace SchoolStore.Controllers
{
    public class AccountController : Controller
    {

        

        //Using Microsoft.AspNetCore.Identity
        private SignInManager<ApplicationUser> _signInManager;
        private SendGridClient _sendGridClient;

        public AccountController(SignInManager<ApplicationUser> signInManager, SendGrid.SendGridClient sendGridClient)
        {
            this._signInManager = signInManager;
            this._sendGridClient = sendGridClient;
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
        public async Task<IActionResult> Register(string username, string password)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser newUser = new ApplicationUser { UserName = username, Email=username };
                var userResult = _signInManager.UserManager.CreateAsync(newUser).Result;
                if (userResult.Succeeded)  
                {
                    var passwordResult = _signInManager.UserManager.AddPasswordAsync(newUser, password).Result;
                    if (passwordResult.Succeeded)
                    {
                        _signInManager.SignInAsync(newUser, false).Wait();
                        
                        SendGrid.Helpers.Mail.SendGridMessage message = new SendGrid.Helpers.Mail.SendGridMessage();
                        message.AddTo(username);
                        message.Subject = "Welcome to School Store";
                        message.SetFrom("schoolstoreadmin@codingtemple.com");
                        message.AddContent("text/plain", "Thanks for registering as " + username + " on SchoolStore!");
                        await _sendGridClient.SendEmailAsync(message);



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
                ApplicationUser currentUser = await _signInManager.UserManager.FindByNameAsync(username);
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
                ApplicationUser currentUser = await _signInManager.UserManager.FindByNameAsync(username);
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


        [HttpGet]
            public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                string token = await _signInManager.UserManager.GeneratePasswordResetTokenAsync(user);
                token = System.Net.WebUtility.UrlEncode(token);


                //using Microsoft.AspNetCore.Http.Extensions;

                string currentUrl = Request.GetDisplayUrl();
                System.Uri uri = new Uri(currentUrl);

                string resetUrl = uri.GetLeftPart(UriPartial.Authority);

                resetUrl += "/account/resetpassword?id=" + token + "&email=" + email;



                SendGrid.Helpers.Mail.SendGridMessage message = new SendGrid.Helpers.Mail.SendGridMessage();
                message.AddTo(email);
                message.Subject = "Your password reset token";
                message.SetFrom("schooladmin@schoolstore.com");
                message.AddContent("text/plain", resetUrl);
                message.AddContent("text/html", string.Format("<a href=\"{0}\">{0}</a>", resetUrl));
                await _sendGridClient.SendEmailAsync(message);
            }

            return RedirectToAction("ResetSent");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string id, string email, string password)
        {
            string originalToken = id;
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _signInManager.UserManager.ResetPasswordAsync(user, originalToken, password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", new { resetSuccessful = true });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }

            }
            return View();
        }

    }
}