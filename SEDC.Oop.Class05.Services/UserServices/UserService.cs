using SEDC.Oop.Class05.Data;
using SEDC.Oop.Class05.Models.Models;
using SEDC.Oop.Class05.Services.Helpers;
using SEDC.Oop.Class05.Services.Interfaces;

namespace SEDC.Oop.Class05.Services.UserServices
{
    public class UserService : IUser
    {

        public User LogIn()
        {
            while (true)
            {
                try
                {
                    string userName = Validations.GetUserName();
                    var user = InMemoryDatabase.GetUserByUserName(userName);

                    if (user != null)
                    {
                        if (Validations.ValidatePassword(user))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Successful Login! Welcome {user.Role}!");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            user.isLoggedIn = true;
                            return user;
                        }
                    }
                    else
                    {
                        throw new Exception("invalid username. Try again!");
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowError(ex);
                }
            }
        }

        public void ChangePassword(User user)
        {
            while (true)
            {
                try
                {
                    if (Validations.ValidatePassword(user))
                    {
                        string newPassword = Validations.GetNewPassword();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Succesfully changed password");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        user.Password = newPassword;
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