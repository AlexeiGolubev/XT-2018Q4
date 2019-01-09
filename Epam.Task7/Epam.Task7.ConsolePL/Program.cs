using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.BLL.Interface;
using Epam.Task7.Common;
using Epam.Task7.Entities;

namespace Epam.Task7.ConsolePL
{
    public class Program
    {
        private static readonly IUserLogic userLogic = DependencyResolver.UserLogic;

        public static void Main(string[] args)
        {
            DateTime.TryParse("12.12.12", out DateTime date);
            User user1 = new User()
            {
                Name = "Alex",
                DateOfBirth = date,
            };
            User user2 = new User()
            {
                Name = "Bob",
                DateOfBirth = DateTime.Now,
            };
            userLogic.Add(user1);
            userLogic.Add(user2);
            
            foreach (var user in userLogic.GetAll())
            {
                Console.WriteLine(user);
            }
        }
    }
}
