using SEDC.Oop.Class05.Models.Enums;
using SEDC.Oop.Class05.Models.Models;

namespace SEDC.Oop.Class05.Services.Helpers
{
    public static class Validations
    {
        public static string GetUserName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter username: ");
                    string userName = Console.ReadLine();
                    if (userName.Length > 4)
                    {
                        return userName;
                    }
                    else
                    {
                        throw new Exception("Username must containt at least 5 characters");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }

        public static bool ValidatePassword(User user)
        {
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (user.Password == password)
            {
                return true;
            }
            else
            {
                throw new Exception("Invalid password. Try again");
            }
        }

        public static string GetNewPassword()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter new password: ");
                    string newPassword = Console.ReadLine();

                    if (newPassword.Length > 4 && DoesItContainNum(newPassword))
                    {
                        return newPassword;
                    }
                    else
                    {
                        throw new Exception("Password must be at least 5 characters long and contain 1 number");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

        }

        private static bool DoesItContainNum(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str, i))
                {
                    return true;
                }
            }
            return false;
        }

        public static Roles GetRole()
        {
            Console.WriteLine("Choose one of the following roles for the new user");
            Console.WriteLine("1. Administrator");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Maintainance");

            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    return Roles.Administrator;
                case "2":
                    return Roles.Manager;
                case "3":
                    return Roles.Maintenance;
                default:
                    throw new Exception("Invalid selection.\nCreation unsuccessful. Please try again");
            }
        }

        public static int ParseInput(string input)
        {
            while (true)
            {
                try
                {
                    bool isValid = int.TryParse(input, out int number);
                    if (!isValid)
                    {
                        throw new Exception("Invalid choice. Please enter a valid number");
                    }
                    else
                    {
                        return number;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

            }
        }
    }
}
