using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace NetCore20Auth
{
    public class AccountController : Controller
    {
        private readonly IAccount _account;
        private readonly SignInManager<User> _signinManager;
        private readonly IAccountManager _accountManager;

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {

            return View((object)returnUrl);
        }

        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(string userName, string password)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,"baki"),
                new Claim(ClaimTypes.Surname,"altun"),
                new Claim(ClaimTypes.Role, string.Join(",", new[] {1,2,3})),
                new Claim(ClaimTypes.Email,"mail@mailinator.com")
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

            return new ObjectResult(value: (object)(new { result = "Success", CookieAuthenticationDefaults.AuthenticationScheme }));
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();

            return new ObjectResult(value: (object)(new { result = "Success" }));
        }

        [Authorize]
        public string GetTestOne()
        {
            return "Login Başararılı";
        }

        [AllowAnonymous]
        public string GetTestTwo()
        {
            return "Loginsiz Giriş";
        }

        [AllowAnonymous]
        public ActionResult FacebookSigning(string facebookId, string accessToken)
        {
            _account.Process(options =>
            {
                options.FacebookId = facebookId;
                options.AccessToken = accessToken;
            });

            if (_account.IsFailed)
                return Json(_account.Result); //show message

            _accountManager.SignIn(_account.GetUser);

            return RedirectToAction("Login", new { returnUrl = "email" });
        }

        [AllowAnonymous]
        public ActionResult TwitterSigning(string twitterId, string accessToken)
        {
            _account.Process(options =>
            {
                options.TwitterId = twitterId;
                options.AccessToken = accessToken;
            });

            if (_account.IsFailed)
                return Json(_account.Result); //show message

            _accountManager.SignIn(_account.GetUser);

            return RedirectToAction("Login", new { returnUrl = "email" });
        }

        [AllowAnonymous]
        public ActionResult CustomSigning(string userName, string password)
        {
            _account.Process(options =>
            {
                options.UserName = userName;
                options.Password = password;
            });

            if (_account.IsFailed)
                return Json(_account.Result); //show message
                
            _accountManager.SignIn(_account.GetUser);

            return RedirectToAction("Login", new { returnUrl = "email" });
        }
    }
}