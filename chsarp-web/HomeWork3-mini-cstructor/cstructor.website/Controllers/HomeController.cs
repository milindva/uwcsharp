using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cstructor.Business;
using cstructor.website.Models;
using cstructor.Repository;
using cstructor.Database;


namespace cstructor.website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassManager classManager;
        private readonly IUserManager userManager;
        private readonly ILoginUserManager loginUserManager;
        
        

        public HomeController ( IClassManager classManager, IUserManager userManager, ILoginUserManager loginUserManager)
        {
            this.classManager = classManager;
            this.userManager = userManager;
            this.loginUserManager = loginUserManager;
        }

        public HomeController( IClassManager classManager)
        {
            this.classManager = classManager;
        }

        public ActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogIn(LogInModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = loginUserManager.LogIn(loginModel.Email, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new cstructor.website.Models.LogInModel { Id = user.Id, Email = user.Email };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginModel.Email, false);

                    //return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl ?? "~/");
                }
            }

            return View(loginModel);
        }


        public ActionResult LogOff()
        {
            Session["User"] = null;
            System.Web.Security.FormsAuthentication.SignOut();

            return Redirect("~/");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(cstructor.website.Models.UserModel  usermodel)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Register(usermodel.Email, usermodel.Password, usermodel.IsAdmin);

                return View("AddUser",usermodel);
            }
            else
            {
                return View();
            }

        }


        public ActionResult Classes(int id)
        {
            var user = userManager.User(id);
            var classes = classManager
                          .ForUser(id)
                          .Select(t => new cstructor.website.Models.ClassModel
                          {
                              Id = t.Id,
                              Name = t.Name,
                              Description = t.Description,
                              Price = t.Price
                          }).ToArray();

            var model = new UserViewModel
            {
                User = new cstructor.website.Models.UserModel(user.Id, user.Email, user.Password, user.IsAdmin),
                Classes = classes
            };

            return View(model);


        }

        public ActionResult ClassesForUser()
        {
            var user = (cstructor.website.Models.LogInModel)Session["User"];
            int userId = user.Id;

            var classes = classManager.ForUser(userId)
                            .Select(t => new cstructor.website.Models.ClassModel
                            {
                                Id = t.Id,
                                Name = t.Name,
                                Description = t.Description,
                                Price = t.Price
                            }).ToArray();

            var model = new UserViewModel
            {
                User = new cstructor.website.Models.UserModel(user.Id, user.Email, user.Password, false),
                Classes = classes
            };

            return View(model);
        }

        public ActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        public ActionResult ClassList()
        {
            var classes = classManager.Classes
                            .Select(t => new cstructor.website.Models.ClassModel(t.Id, t.Name, t.Description, t.Price))
                            .ToArray();

            var model = new IndexModel { Classes = classes };
            return View(model);
        }

        [HttpGet]
        public ActionResult EnrollInAClass()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var classes = classManager.Classes
                            .Select(t => new cstructor.website.Models.ClassModel(t.Id, t.Name, t.Description, t.Price))
                            .ToArray();


            var model = new IndexModel { Classes = classes };

            //return View(model);

            foreach (var cls in model.Classes)
            {
                items.Add(new SelectListItem
                {
                    Text = cls.Name,
                    Value = cls.Id.ToString()
                });

            }

            ViewData["ClassesToEnroll"] = items;
            //return View(model);
            return View();

        }

        //[HttpPost]

        //public ActionResult EnrollInAClass(website.Models.UserViewModel userViewModel, FormCollection form)
        //{

        //    var user = (cstructor.website.Models.LogInModel)Session["User"];
        //    int userId = user.Id;

        //    int classId = Convert.ToInt32(form["ClassesToEnroll"].ToString());

        //    classManager.AddClassToUser(userId, classId);

        //    return View();
        //}

        [HttpGet]
        public ActionResult RegisterUserForm()
        {
            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}