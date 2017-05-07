using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cstructor.Repository;

namespace cstructor.Business
{
    public interface IUserManager
    {

        UserModel User(int userId);
        UserModel Register(string email, string password, bool isAdmin);
        

    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
       // public IUserRepository UserRepository { get => userRepository; set => userRepository = value; }

        public UserModel(int id, string email, string password, bool isadmin)
        {
            Id = id;
            Email = email;
            Password = password;
            IsAdmin = isadmin;
        }

        public UserModel()
        {

        }

       

    }

        public class UserManager : IUserManager
        {
            private readonly IUserRepository userRepository;

            public UserManager(IUserRepository userRepository)
            {
                this.userRepository = userRepository;
            }

            public UserModel User (int userId)
            {
                var userModel = userRepository.User(userId);

                return new UserModel(userModel.Id, userModel.Email, userModel.Password, userModel.IsAdmin);
            }

            public UserModel Register (string email, string password, bool isAdmin=false)
            {
                var user = userRepository.Register(email, password, isAdmin);

                if (user == null)
                {
                    return null;
                }

                return new UserModel ( user.Id, user.Email, user.Password, user.IsAdmin );
            }


        }


    }

