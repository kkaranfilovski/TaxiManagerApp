using SEDC.Oop.Class05.Data;
using SEDC.Oop.Class05.Models.Enums;
using SEDC.Oop.Class05.Models.Models;
using SEDC.Oop.Class05.Services.Helpers;
using SEDC.Oop.Class05.Services.Interfaces;
using SEDC.Oop.Class05.Services.Menus;

namespace SEDC.Oop.Class05.Services.UserServices
{
    public class ManagerService : UserService, IManager
    {

        public void ManagerMenu(User user)
        {
            while (true)
            {
                Screens.ManagerMenu();
                string selection = Console.ReadLine();

                if (selection == "1")
                {
                    ListAllDrivers();
                    continue;
                }
                else if (selection == "2")
                {
                    ListTaxiLicenseStatus();
                    continue;
                }
                else if (selection == "3")
                {
                    DriverManager();
                    continue;
                }
                else if (selection == "4")
                {
                    ChangePassword(user);
                }
                else if (selection == "5")
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

        public void DriverManager()
        {
            while (true)
            {
                Screens.DriverManagerMenu();
                string selection = Console.ReadLine();

                if (selection == "1")
                {
                    AssignDriver();
                    break;
                }
                else if (selection == "2")
                {
                    UnassignDriver();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again");
                    continue;
                }
            }
        }

        public void ListAllDrivers()
        {
            List<Driver> drivers = InMemoryDatabase.GetAllDrivers();

            foreach (var driver in drivers)
            {
                if(driver.LicenseExpiryDate < DateTime.Now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{driver.Id}) {driver.FirstName} {driver.LastName} driving license is expired.");
                    Console.ResetColor();
                }
                else if (driver.Shift == Shifts.NoShift)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{driver.Id}) {driver.FirstName} {driver.LastName} is free.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{driver.Id}) {driver.FirstName} {driver.LastName} driving in the {driver.Shift} shift with a {driver.Car.Model} car");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to go back");
            Console.ReadLine();
        }

        public void ListTaxiLicenseStatus()
        {
            List<Driver> drivers = InMemoryDatabase.GetAllDrivers();

            foreach (var driver in drivers)
            {
                Helper.ExpiryColor(driver);
                Console.WriteLine($" Name: {driver.FirstName} {driver.LastName} with license {driver.License} expiring on {driver.LicenseExpiryDate}");
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to go back");
            Console.ReadLine();
        }

        private void AssignDriver()
        {
            while (true)
            {
                try
                {
                    List<Driver> drivers = InMemoryDatabase.GetAllFreeDrivers();

                    if(drivers.Count == 0)
                    {
                        Console.WriteLine("No available drivers.");
                        Thread.Sleep(1500);
                        break;
                    }

                    Console.WriteLine("Enter a number to choose a driver:");
                    int counter = 1;
                    foreach (var driver in drivers)
                    {
                        Console.WriteLine($"{counter}) {driver.FirstName} {driver.LastName} is free.");
                        counter++;                       
                    }

                    string selection = Console.ReadLine();
                    int parsedSelection = Validations.ParseInput(selection);

                    if (parsedSelection > drivers.Count || parsedSelection < 0)
                    {
                        throw new Exception("Invalid choice");
                    }
                    else
                    {
                        var driver = drivers[parsedSelection - 1];
                        var shift = PickShift(driver);
                        var car = PickCar(shift);
                        driver.Car = car;
                        car.AssignedDrivers.Add(driver);
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

        private Shifts PickShift(Driver driver)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Pick shift:");
                    Console.WriteLine("1. Morning");
                    Console.WriteLine("2. Afternoon");
                    Console.WriteLine("3. Evening");

                    string selection = Console.ReadLine();

                    if (selection == "1")
                    {
                        return driver.Shift = Shifts.Morning;
                    }
                    else if (selection == "2")
                    {
                        return driver.Shift = Shifts.Afternoon;
                    }
                    else if (selection == "3")
                    {
                        return driver.Shift = Shifts.Evening;
                    }
                    else
                    {
                        throw new Exception("Invalid choice. Try again");
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowError(ex);
                    continue;
                }
            }
        }

        private Car PickCar(Shifts shift)
        {
            while (true)
            {
                try
                {
                    List<Car> cars = InMemoryDatabase.GetAllCars();
                    List<Car> availableCars = new List<Car>();

                    Console.Clear();
                    Console.WriteLine("Pick car:");
                    int counter = 1;
                    foreach (Car car in cars)
                    {
                        if (car.LicenseExpiryDate < DateTime.Now || car.AssignedDrivers.Any(x => x.Shift == shift))
                        {
                            continue;
                        }
                        else
                        {
                            availableCars.Add(car);
                            Console.WriteLine($"{counter}) {car.Model} with license plate {car.LicensePlate}");
                            counter++;
                        }
                    }

                    string selection = Console.ReadLine();
                    int parsedSelection = Validations.ParseInput(selection);

                    if (parsedSelection > availableCars.Count || parsedSelection < 0)
                    {
                        throw new Exception("Invalid choice. Try again");
                    }
                    else
                    {
                        return availableCars[parsedSelection - 1];
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowError(ex);
                    continue;
                }
            }
        }

        private void UnassignDriver()
        {
            while (true)
            {
                try
                {
                    List<Driver> drivers = InMemoryDatabase.GetAllAssignedDrivers();

                    int counter = 1;
                    foreach (var driver in drivers)
                    {
                        Console.WriteLine($"{counter}) {driver.FirstName} {driver.LastName} driving in the {driver.Shift} shift with a {driver.Car.Model} car");
                        counter++;
                    }

                    string selection = Console.ReadLine();
                    int parsedSelection = Validations.ParseInput(selection);

                    if (parsedSelection > drivers.Count || parsedSelection < 0)
                    {
                        throw new Exception("Invalid choice. Try again");
                    }
                    else
                    {
                        var driver = drivers[parsedSelection - 1];
                        driver.Shift = Shifts.NoShift;
                        driver.Car.AssignedDrivers.Remove(driver);
                        driver.Car = new Car();
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
