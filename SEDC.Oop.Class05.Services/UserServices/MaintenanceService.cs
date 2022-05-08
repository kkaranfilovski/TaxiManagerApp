using SEDC.Oop.Class05.Data;
using SEDC.Oop.Class05.Models.Models;
using SEDC.Oop.Class05.Services.Helpers;
using SEDC.Oop.Class05.Services.Interfaces;
using SEDC.Oop.Class05.Services.Menus;

namespace SEDC.Oop.Class05.Services.UserServices
{
    public class MaintenanceService : UserService ,IMaintenance
    {
        public void MaintenanceMenu(User user)
        {
            while (true)
            {
                Screens.MaintenanceMenu();
                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    ListAllVehicles();
                    continue;
                }
                else if(selection == "2")
                {
                    ListLicensePlateNumber();
                }
                else if(selection == "3")
                {
                    ChangePassword(user);
                }
                else if (selection == "4")
                {
                    user.isLoggedIn = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection");
                    Thread.Sleep(1000);
                    continue;
                }
            }
        }

        public void ListAllVehicles()
        {
            List<Car> cars = InMemoryDatabase.GetAllCars();

            foreach(Car car in cars)
            {
                Console.WriteLine($"{car.Id}) {car.Model} with license plate {car.LicensePlate} and utilized {Decimal.Round(Decimal.Divide(car.AssignedDrivers.Count, 3)*100)}%");
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to go back");
            Console.ReadLine();
        }

        public void ListLicensePlateNumber()
        {
            List<Car> cars = InMemoryDatabase.GetAllCars();

            foreach(Car car in cars)
            {
                Helper.ExpiryColor(car);
                Console.WriteLine($" ID: {car.Id} Model: {car.Model} Plate: {car.LicensePlate} with expiry date {car.LicenseExpiryDate}");
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to go back");
            Console.ReadLine();
        }
    }
}
