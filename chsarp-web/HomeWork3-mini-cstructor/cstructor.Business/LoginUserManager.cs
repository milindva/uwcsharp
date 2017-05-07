using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cstructor.Repository;

namespace cstructor.Business
{
    public interface ILoginUserManager
    {
        LoginUserModel LogIn(string email, string password);

    }

    public class LoginUserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }

    }

    public class LoginUserManager : ILoginUserManager
    {
        private readonly ILoginUserRepository loginuserRepository;

        public LoginUserManager (ILoginUserRepository loginuserRepository)
        {
            this.loginuserRepository = loginuserRepository;
        }

        public LoginUserModel LogIn (string email, string password)
        {
            var user = loginuserRepository.LogIn(email, password);

            if (user == null)
            {
                return null;
            }

            return new LoginUserModel { Id = user.Id, Email = user.Email };
        }
    }
}
