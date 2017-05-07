using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cstructor.website.Models
{
    public class UserViewModel
    {
        public UserModel User { get; set; }
        public ClassModel[] Classes { get; set; }

        public ClassModel SelectedClass { get; set; }

        public int SelectedClassId { get; set; }

    }
}