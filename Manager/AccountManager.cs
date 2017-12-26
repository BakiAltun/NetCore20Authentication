using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
namespace NetCore20Auth
{
    //no singleton,transistEE
    public class AccountManager : IAccountManager
    {
        private readonly HttpContext _httpContext;
        
        private readonly IUserService _userService;

        public AccountManager(HttpContext httpContext, IUserService userService)
        {
            _httpContext = httpContext;
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
            throw new NotImplementedException();
        }

        public void SignOut()
        {
            _httpContext.SignOutAsync();
        }
    }

    public interface IAccountManager
    {
        void SignIn(User entity);
        void SignOut();
        User CurrentUser();
        void ForgetPassword(string email);
        void ScreenUnLock(string password);
    }
}