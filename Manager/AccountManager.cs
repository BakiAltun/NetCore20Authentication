using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Collections.Generic;

namespace NetCore20Auth
{
    //no singleton,transistEE
    public class SignManager : ISignManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IUserService _userService;

        public  SignManager(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public User CurrentUser()
        {
            return _userService.GetById(0);
        }

        public void ForgetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public void ScreenUnLock(string password)
        {
            throw new NotImplementedException();
        }

        public void SignIn(User userEntity)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Baki"),
                new Claim(ClaimTypes.Surname, "Altun"),
                new Claim("IsPublic", Boolean.FalseString )
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        public void SignOut()
        {
            _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }

    public interface ISignManager
    {
        void SignIn(User entity);
        void SignOut();
        User CurrentUser();
        void ForgetPassword(string email);
        void ScreenUnLock(string password);
    }
}