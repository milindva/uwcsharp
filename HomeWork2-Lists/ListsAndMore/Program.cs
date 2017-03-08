using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsAndMore
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });
            users.Add(new Models.User { Name = "Test", Password = "test" }); // adding one more entry to test Remove use case

            //Display original contents of the list

            Console.WriteLine("Printing all users in the list before any modifications");
            foreach (var user in users)
                Console.WriteLine("Name={0}\t Password={1}", user.Name, user.Password);



            //Display to the console, all the passwords that are "hello"

            var helloPasswords = from user in users
                                 where user.Password == "hello"
                                 select user;

            Console.WriteLine();
            Console.WriteLine(@"User with password as ""hello""");


            foreach (var user in helloPasswords)
                Console.WriteLine("Name= {0}\t Password= {1}", user.Name, user.Password);

            //Delete any passwords that are the lower - cased version of their Name.
            //This should remove users "Test" and "Steve"

            users.RemoveAll(u => u.Password == u.Name.ToLower());

            // printing remaining users list (Steve and Test removed now)

            Console.WriteLine();
            Console.WriteLine("Users after removing weak passwords (same as their username in lowercase");

            foreach (var user in users)
                Console.WriteLine("Name={0}\t Password= {1}", user.Name, user.Password);

            // Delete the first User that has the password "hello".

            Models.User userToDelete = new Models.User();

            userToDelete = users.FirstOrDefault(u => u.Password == "hello");
            users.Remove(userToDelete);

            // Display remaining users in the list
            // Only one entry for user "Lisa"  should be displayed in the final line of output 

            Console.WriteLine();
            Console.WriteLine(@"Contents of the list after deleting first user with password as ""hello"":");

            foreach ( var user in users)
                Console.WriteLine("Name={0}\t Password={1}", user.Name, user.Password);

        }
    }
}
