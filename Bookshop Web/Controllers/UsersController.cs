using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Bookshop.Web.Models;
using Bookshop.Business.Interfaces;

namespace Bookshop.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View();

            var user = userService.ValidateUser(model.UserName, model.Password);
            if(user != null)
            {
                ICollection<Claim> claims = new List <Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(claimsPrincipal);

                
                if (Url.IsLocalUrl(returnUrl))  return Redirect(returnUrl);
                // if(returnUrl == "")             return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Login", "Username or password is wrong.");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
