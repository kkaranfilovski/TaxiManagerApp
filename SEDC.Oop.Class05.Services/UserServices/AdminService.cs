using SEDC.Oop.Class05.Models.Enums;
using SEDC.Oop.Class05.Models.Models;
using SEDC.Oop.Class05.Services.Helpers;
using SEDC.Oop.Class05.Services.Menus;
using SEDC.Oop.Class05.Data;
using SEDC.Oop.Class05.Services.Interfaces;

namespace SEDC.Oop.Class05.Services.UserServices
{
    public class AdminService : UserService, IAdmin
    {
        public void AdminMenu(User user)
        {
            while (true)
            {
                Screens.AdminMenu();
                string selection = Console.ReadLine();

                if (selection == "1")
                {
                    AddNewUser();
                    continue;
                }
                else if (selection == "2")
                {
                    RemoveUser();
                    continue;
                }
                else if (selection == "3")
                {
                    ChangePassword(user);
                    continue;
                }
                else if (selection == "4")
                {
                    user.isLoggedIn = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection");
                    continue;
                }
            }
        }

        public void AddNewUser()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("===== ADD NEW USER =====");

                    string userName = Validations.GetUserName();
                    if (InMemoryDatabase.GetUserByUserName(userName) != null)
                    {
                        throw new Exception("There is already user with that username. Try another one");
                    }

                    string password = Validations.GetNewPassword();
                    Roles role = Validations.GetRole();

                    var newUser = new User(userName, password, role);
                    InMemoryDatabase.AddNewUser(newUser);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Succesfully created new {newUser.Role} user");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    break;
                }
                catch (Exception ex)
                {
                    Helper.ShowError(ex);
                    continue;
                }
            }
        }

        public void RemoveUser()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("===== REMOVE EXISTING USER =====");

                    List<User> users = InMemoryDatabase.GetUsersForRemoval();

                    if (users.Count == 0)
                    {
                        Console.WriteLine("No users available.");
                        Thread.Sleep(1500);
                        break;
                    }

                    int counter = 1;
                    foreach (User user in users)
                    {
                        Console.WriteLine($"{counter}) {user.UserName} with the role of {user.Role}");
                        counter++;
                    }

                    Console.WriteLine("Enter the number of the user you want to remove");
                    string selection = Console.ReadLine();
                    int parsedSelection = Validations.ParseInput(selection);

                    if (parsedSelection > users.Count || parsedSelection < 0)
                    {
                        throw new Exception("Invalid selection. Select valid choice");
                    }
                    else
                    {
                        var userToRemove = users[parsedSelection - 1];

                        InMemoryDatabase.RemoveUser(userToRemove);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Succesfully removed user");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowError(ex);
                    continue;
                }
            }
        }
    }
}
