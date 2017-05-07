using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cstructor.Database;

namespace cstructor.Repository
{
    public interface IClassRepository
    {
        ClassModel[] Classes { get; }
        ClassModel[] ForUser(int userId);
        ClassModel Class(int classId);

        void AddClassToUser(int userId, int classId);

        
    }

    public class ClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class ClassRepository : IClassRepository
    {
        private readonly IUserRepository userRepository;
        private readonly IClassRepository classRepository;

        public ClassModel[] Classes
        {
            get
            {
                return DatabaseAccessor.Instance.Classes
                    .Select(t => new ClassModel { Id = t.ClassId, Name = t.ClassName, Description = t.ClassDescription, Price = t.ClassPrice })
                    .ToArray();
            }
        }

        public ClassModel[] ForUser (int userId)
        {
            return DatabaseAccessor.Instance.Users.First(t => t.UserId == userId)
                                  .Classes.Select(t =>
                                                   new ClassModel
                                                   {
                                                       Id = t.ClassId,
                                                       Name = t.ClassName,
                                                       Description = t.ClassDescription,
                                                       Price = t.ClassPrice

                                                   })
                                 .ToArray();
        }

        public ClassModel Class (int classId)
        {
            var cls = DatabaseAccessor.Instance.Classes
                                .Where(t => t.ClassId == classId)
                                .Select(t => new ClassModel { Id = t.ClassId, Name = t.ClassName, Description = t.ClassDescription, Price = t.ClassPrice })
                                .First();
            return cls;
        }

        public void AddClassToUser(int userId, int classId)
        {
            // Get the User object from the database

      

            var user = DatabaseAccessor.Instance.Users
                        .Where(t => t.UserId == userId)
                        .Select(t => new UserModel { Id = t.UserId, Email = t.UserEmail, Password = t.UserPassword, IsAdmin = t.UserIsAdmin })
                        .First();

            // Get the Class object from the database

            //var classToAdd = classRepository.Class(classId);

            var classToAdd = DatabaseAccessor.Instance.Classes
                                .Where(t => t.ClassId == classId)
                                .Select(t => new ClassModel { Id = t.ClassId, Name = t.ClassName, Description = t.ClassDescription, Price = t.ClassPrice })
                                .First();

            //    var context = new cstructorEntities();

            //context.Users.First (t => t.UserId == user.Id)
            //                                       .Classes.Add(new Database.Class
            //                                       {
            //                                           ClassId = classToAdd.Id,
            //                                           ClassName = classToAdd.Name,
            //                                           ClassDescription = classToAdd.Description,
            //                                           ClassPrice = classToAdd.Price
            //                                       });

            DatabaseAccessor.Instance.Users.First(t => t.UserId == user.Id)
                                              .Classes.Add(new Database.Class
                                              {
                                                  ClassId = classToAdd.Id,
                                                  ClassName = classToAdd.Name,
                                                  ClassDescription = classToAdd.Description,
                                                  ClassPrice = classToAdd.Price
                                              });


            // Save the changes to database

            DatabaseAccessor.Instance.SaveChanges();
           // context.SaveChanges();
                


        }


    }
}
