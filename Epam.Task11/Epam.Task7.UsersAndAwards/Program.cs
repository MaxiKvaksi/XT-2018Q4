using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Epam.Task7.BLL.Interface;
using Epam.Task7.Common;
using Epam.Task7.Entities;
using Epam.Task7.Entities.Exceptions;

namespace Epam.Task7.UsersAndAwards
{
    public class Program
    {
        private static int state = -1;
        private static IUserLogic userLogic = DependencyResolver.UserLogic;
        private static IAwardLogic awardLogic = DependencyResolver.AwardLogic;
        private static IAwardedUsersLogic awardedUsersLogic = DependencyResolver.AwardedUsersLogic;

        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates work three layer architecture.");
            ObjectChooseDialog();
        }

        private static int GetNumberValueFromKeyboard(int min, int max = int.MaxValue)
        {
            if (int.TryParse(Console.ReadLine(), out int n) && n >= min && n <= max)
            {
                return n;
            }
            else
            {
                throw new InvalidInputException("Invalid integer input value");
            }
        }

        private static void TrySetState(int min, int max)
        {
            try
            {
                state = GetNumberValueFromKeyboard(min: min, max: max);
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ObjectChooseDialog()
        {
            state = -1;
            while (state != 0)
            {
                Console.Clear();
                Console.WriteLine($"Choose objects type for work(0 to exit):{Environment.NewLine}" +
                            $"1.Users{Environment.NewLine}2.Awards");
                TrySetState(0, 2);
                switch (state)
                {
                    case 1:
                        UserOptionDialog();
                        break;
                    case 2:
                        AwardsOptionDialog();
                        break;
                }
            }  
        }

        private static void UserOptionDialog()
        {
            state = -1;
            while (state != 0)
            {
                Console.Clear();
                Console.WriteLine($"Choose action (0 to back to preview menu):{Environment.NewLine}" +
                           $"1.Create user{Environment.NewLine}2.Delete user{Environment.NewLine}3.Show all users{Environment.NewLine}4.Add award to user");
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
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 4:
                        AddAward();
                        break;
                }
            }

            state = -1;
            Console.Clear();
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
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                catch (CollisionException)
                {
                    Console.WriteLine("Award already awarded!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                catch (InvalidInputException e)
                {
                    Console.WriteLine("Award not chosen: " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine();
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine("User not chosen: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ShowAllUsers()
        {
            int counter = 0;
            foreach (var user in userLogic.GetAll())
            {
                Console.WriteLine(user);
                Console.WriteLine("Awards:");
                foreach (var award in awardedUsersLogic.GetAwardsByUserId(user.Id, awardLogic.GetAll()))
                {
                    Console.WriteLine($"\t{award}");
                }
                counter++;
            }
        }

        private static void DeleteUser()
        {
            ShowAllUsers();
            Console.WriteLine("Choose user by id to delete:");
            try
            {
                userLogic.Delete(GetNumberValueFromKeyboard(1, userLogic.GetAll().Count()));
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine("User not deleted because: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AwardsOptionDialog()
        {
            state = -1;
            while (state != 0)
            {
                Console.Clear();
                Console.WriteLine($"Choose action (0 to back to preview menu):{Environment.NewLine}" +
                           $"1.Create award{Environment.NewLine}2.Delete award{Environment.NewLine}3.Show all awards{Environment.NewLine}4.Add award to user");
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
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 4:
                        AddAward();
                        break;
                }
            }

            state = -1;
            Console.Clear();
        }

        private static void ShowAllAwards()
        {
            foreach (var item in awardLogic.GetAll())
            {
                Console.WriteLine(item);
            }
        }

        private static void DeleteAward()
        {
            ShowAllAwards();
            Console.WriteLine("Choose award by id to delete:");
            try
            {
                awardLogic.Delete(GetNumberValueFromKeyboard(1, awardLogic.GetAll().Count()));
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine("Award not deleted because: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CreateAward()
        {
            string title;
            while (true)
            {
                Console.WriteLine("Input title:");
                title = Console.ReadLine();
                try
                {
                    if (Regex.IsMatch(title, Constants.AWARD_TITLE_REGEX))
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidInputException("Invalid title");
                    }
                }
                catch (InvalidInputException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var award = new Award
            {
                Title = title,
            };

            awardLogic.Add(award);
            Console.WriteLine($"Added: {award}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void CreateUser()
        {
            string name;
            while (true)
            {
                Console.WriteLine("Input name:");
                name = Console.ReadLine();
                try
                {
                    if (Regex.IsMatch(name, Constants.USERNAME_REGEX))
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidInputException("Invalid name");
                    }
                }
                catch (InvalidInputException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            DateTime dateOfBirth;
            while (true)
            {
                Console.WriteLine("Input date of birth:");
                try
                {
                    if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth)
                        && dateOfBirth.Year <= DateTime.Now.Year
                        && DateTime.Now.Year - dateOfBirth.Year <= Constants.MAX_AGE)
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidInputException("Invalid date of birth");
                    }
                }
                catch (InvalidInputException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var user = new User
            {
                Name = name,
                DateOfBirth = dateOfBirth,
            };

            userLogic.Add(user);
            Console.WriteLine($"Added: {user}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
