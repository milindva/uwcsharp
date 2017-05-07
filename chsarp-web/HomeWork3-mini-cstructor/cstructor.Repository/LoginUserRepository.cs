using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cstructor.Repository
{

    public interface ILoginUserRepository
    {
        LoginUserModel LogIn(string email, string password);

    }

    public class LoginUserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        
    }

    public class LoginUserRepository : ILoginUserRepository
    {
        public LoginUserModel LogIn (string email, string password)
        {
            var user = DatabaseAccessor.Instance.Users
                       .FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower()
                       && t.UserPassword == password);

            if (user == null)
            {
                return null;
            }

            return new LoginUserModel { Id = user.UserId, Email = user.UserEmail };
        }
        
    }

   
}
