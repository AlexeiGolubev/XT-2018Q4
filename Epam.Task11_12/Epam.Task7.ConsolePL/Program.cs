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
        private static IUserLogic userLogic = DependencyResolver.UserLogic;
        private static IAwardLogic awardLogic = DependencyResolver.AwardLogic;
        private static IAwardedUsersLogic awardedUsersLogic = DependencyResolver.AwardedUsersLogic;
        private static int state = -1;

        public static void Main(string[] args)
        {
            Console.WriteLine("The menu of three layer architecture.");
            MenuItemChoose();
        }

        private static int GetNumberValueFromKeyboard(int min, int max = int.MaxValue)
        {
            if (int.TryParse(Console.ReadLine(), out int n) && n >= min && n <= max)
            {
                return n;
            }
            else
            {
                throw new ArgumentException("Invalid integer input value");
            }
        }

        private static void TrySetState(int min, int max)
        {
            try
            {
                state = GetNumberValueFromKeyboard(min: min, max: max);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void MenuItemChoose()
        {
            state = -1;
            while (state != 0)
            {
                Console.Clear();
                Console.WriteLine($"Choose menu item:{Environment.NewLine} 1. Work with users{Environment.NewLine}" +
                            $" 2. Work with awards{Environment.NewLine} 0. Exit");
                TrySetState(0, 2);
                switch (state)
                {
                    case 1:
                        MenuUser();
                        break;
                    case 2:
                        MenuAwards();
                        break;
                }
            }
        }

        private static void MenuUser()
        {
            state = -1;
            while (state != 0)
            {
                Console.Clear();
                Console.WriteLine($"Choose action:{Environment.NewLine} 1. Create user{Environment.NewLine}" +
                           $" 2. Delete user{Environment.NewLine} 3. Show all users{Environment.NewLine}" +
                           $" 4. Add award to user {Environment.NewLine} 0. Back to preview menu");
                TrySetState(0, 4);
                switch (state)
                {
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        DeleteUser();
                        break;
                    case 3:
                        ShowAllUsers();
                        Pause();
                        break;
                    case 4:
                        AddAward();
                        break;
                }
            }

            state = -1;
            Console.Clear();
        }

        private static void CreateUser()
        {
            string name = string.Empty;
            while (name == string.Empty)
            {
                Console.Write("Input user name: ");
                name = Console.ReadLine();
            }

            DateTime dateOfBirth = DateTime.Now;
            bool success = false;
            while (!success)
            {
                Console.Write("Input user date of birth: ");

                success = DateTime.TryParse(Console.ReadLine(), out dateOfBirth)
                    && dateOfBirth.Year <= DateTime.Now.Year
                    && DateTime.Now.Year - dateOfBirth.Year <= 150;
            }

            var user = new User
            {
                Name = name,
                DateOfBirth = dateOfBirth,
            };

            userLogic.Add(user);
            Console.WriteLine($"Added: {user}");
            Pause();
        }

        private static void DeleteUser()
        {
            ShowAllUsers();
            Console.WriteLine("Choose user by id to delete:");
            try
            {
                userLogic.Delete(GetNumberValueFromKeyboard(1, userLogic.GetAll().Count()));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("User not deleted because: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ShowAllUsers()
        {
            foreach (var user in userLogic.GetAll())
            {
                Console.WriteLine(user);
                Console.WriteLine("Awards:");
                foreach (var award in awardedUsersLogic.GetAwardsByUserId(user.Id, awardLogic.GetAll()))
                {
                    Console.WriteLine($"\t{award}");
                }
            }
        }

        private static void AddAward()
        {
            int idUser;
            int idAward;
            Console.WriteLine("Choose user:");
            ShowAllUsers();
            try
            {
                idUser = GetNumberValueFromKeyboard(1);
                Console.WriteLine("Choose award:");
                ShowAllAwards();
                try
                {
                    idAward = GetNumberValueFromKeyboard(1);
                    awardedUsersLogic.Add(idUser, idAward);
                    Console.WriteLine("User awarded!");
                    Pause();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("User already awarded!");
                    Pause();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("User is not chosen: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void MenuAwards()
        {
            state = -1;
            while (state != 0)
            {
                Console.Clear();
                Console.WriteLine($"Choose action:{Environment.NewLine} 1. Create award{Environment.NewLine}" +
                           $" 2. Delete award{Environment.NewLine} 3. Show all awards{Environment.NewLine}" +
                           $" 4. Add award to user {Environment.NewLine} 0. Back to preview menu");
                TrySetState(0, 4);
                switch (state)
                {
                    case 1:
                        CreateAward();
                        break;
                    case 2:
                        DeleteAward();
                        break;
                    case 3:
                        ShowAllAwards();
                        Pause();
                        break;
                    case 4:
                        AddAward();
                        break;
                }
            }

            state = -1;
            Console.Clear();
        }

        private static void CreateAward()
        {
            string title = string.Empty;
            while (title == string.Empty)
            {
                Console.Write("Input title: ");
                title = Console.ReadLine();
            }

            var award = new Award
            {
                Title = title,
            };

            awardLogic.Add(award);
            Console.WriteLine($"Added: {award}");
            Pause();
        }

        private static void DeleteAward()
        {
            ShowAllAwards();
            Console.WriteLine("Choose award by id to delete:");
            try
            {
                awardLogic.Delete(GetNumberValueFromKeyboard(1, awardLogic.GetAll().Count()));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Award not deleted because: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ShowAllAwards()
        {
            foreach (var item in awardLogic.GetAll())
            {
                Console.WriteLine(item);
            }
        }

        private static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
