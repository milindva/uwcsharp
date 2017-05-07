using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cstructor.Database;


namespace cstructor.Repository
{
    public interface IUserRepository
    {
        UserModel User (int userId);
        UserModel[] Users { get; }

        UserModel Register(string email, string password, bool isAdmin);
    }
    
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

       
    }

  public class UserRepository : IUserRepository
    {
        public UserModel User (int userId)
        {
            var user = DatabaseAccessor.Instance.Users
                        .Where(t => t.UserId == userId)
                        .Select(t => new UserModel { Id = t.UserId, Email = t.UserEmail, Password = t.UserPassword, IsAdmin = t.UserIsAdmin })
                        .First();
            return user;
        }

        public UserModel[] Users
        {
            get
            {
                return DatabaseAccessor.Instance.Users
                    .Select(t => new UserModel { Id = t.UserId, Email = t.UserEmail, IsAdmin = t.UserIsAdmin, Password = t.UserPassword })
                    .ToArray();
            }
        }

        public UserModel Register (string email, string password, bool isAdmin=false)
        {
            var user = DatabaseAccessor.Instance.Users
                        .Add(new Database.User { UserEmail = email, UserPassword = password, UserIsAdmin = isAdmin });

            DatabaseAccessor.Instance.SaveChanges();
            return new UserModel { Id = user.UserId, Email = user.UserEmail, Password = user.UserPassword, IsAdmin = user.UserIsAdmin};
        }

    }
}
