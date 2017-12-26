using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
namespace NetCore20Auth
{
    //no singleton,transistEE
    public class UserService : IUserService
    {
        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IUserService
    {
        User GetById(int id);
    }
}