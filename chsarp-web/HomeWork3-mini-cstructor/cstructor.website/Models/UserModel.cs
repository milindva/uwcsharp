using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace cstructor.website.Models
{
    public class UserModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter valid email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

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
}