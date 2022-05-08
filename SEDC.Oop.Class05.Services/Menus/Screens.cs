namespace SEDC.Oop.Class05.Services.Menus
{
    public static class Screens
    {
        public static void WelcomeMenu()
        {
            Console.Clear();
            Console.WriteLine("Taxi Manager 9000");
            Console.WriteLine("------------------");
            Console.WriteLine("Log in:");
        }

        public static void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("===== ADMIN MENU =====");
            Console.WriteLine("Enter a number to choose one of the following:");
            Console.WriteLine("1. Add new user");
            Console.WriteLine("2. Remove existing user");
            Console.WriteLine("3. Change password");
            Console.WriteLine("4. Exit");
        }

        public static void ManagerMenu()
        {
            Console.Clear();
            Console.WriteLine("===== MANAGER MENU =====");
            Console.WriteLine("Enter a number to choose one of the following:");
            Console.WriteLine("1. List all drivers");
            Console.WriteLine("2. License Status");
            Console.WriteLine("3. Driver manager");
            Console.WriteLine("4. Change password");
            Console.WriteLine("5. Exit");
        }

        public static void DriverManagerMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter a number to choose one of the following:");
            Console.WriteLine("1. Assign driver");
            Console.WriteLine("2. Unassign driver");
        }

        public static void MaintenanceMenu()
        {
            Console.Clear();
            Console.WriteLine("===== MAINTENANCE MENU =====");
            Console.WriteLine("Enter a number to choose one of the following:");
            Console.WriteLine("1. List all vehicles");
            Console.WriteLine("2. License plate status");
            Console.WriteLine("3. Change password");
            Console.WriteLine("4. Exit");
        }        
    }
}
