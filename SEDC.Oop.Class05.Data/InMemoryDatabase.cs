using SEDC.Oop.Class05.Models.Enums;
using SEDC.Oop.Class05.Models.Models;

namespace SEDC.Oop.Class05.Data
{
    public static class InMemoryDatabase
    {
        private static List<Car> Cars { get; set; }
        private static List<Driver> Drivers { get; set; }
        private static List<User> Users { get; set; }

        static InMemoryDatabase()
        {
            InitDatabase();
        }

        private static void InitDatabase()
        {
            Cars = new List<Car>
            {
                new Car("ford fiesta", "SK5631AZ", new DateTime(2021,11,15)),
                new Car("Citroen c3", "SK2222PP", new DateTime(2023, 3, 3)),
                new Car("Chevrolet Spark", "SK7777KL", new DateTime(2022, 5, 20)),
                new Car("Mercedes Benz", "SK6969KO", new DateTime(2025, 5, 20)),
                new Car("Renault Scenic", "SK7667OL", new DateTime(2022, 5, 20)),
                new Car("Volkswagen Golf", "SK9999SH", new DateTime(2025, 5, 20))
            };

            Users = new List<User>
            {
                new User("admin1", "admin1", Roles.Administrator),
                new User("stanko", "stanko1", Roles.Manager),
                new User("petko", "petko1", Roles.Maintenance)
            };

            Drivers = new List<Driver>
            {
                new Driver("kristijan", "karanfilovski", Shifts.NoShift, "ASD123", new DateTime(2021, 11, 15)),
                new Driver("ilija", "mitev", Shifts.NoShift, "QWE123", new DateTime(2025, 5, 10)),
                new Driver("Radmila", "Petrushevska", Shifts.NoShift, "ZXC123", new DateTime(2022, 5, 20)),
                new Driver("Stefan", "Ivanovski", Shifts.NoShift, "ASD123", new DateTime(2025, 11, 15)),
                new Driver("Aleksandar", "Zivkovic", Shifts.NoShift, "QWE123", new DateTime(2025, 5, 10)),
                new Driver("Vlatko", "Tasevski", Shifts.NoShift, "ZXC123", new DateTime(2022, 5, 20))
            };
        }

        public static User GetUserByUserName(string userName)
        {
            return Users.FirstOrDefault(user => user.UserName == userName);
        }

        public static void AddNewUser(User user)
        {
            Users.Add(user);
        }

        public static void RemoveUser(User user)
        {
            Users.Remove(user);
        }

        public static List<User> GetUsersForRemoval()
        {
            List<User> usersForRemoval = new List<User>();
            foreach (var user in Users)
            {
                if (!user.isLoggedIn)
                {
                    usersForRemoval.Add(user);
                }
            }
            return usersForRemoval;
        }

        public static List<Car> GetAllCars()
        {
            return Cars;
        }

        public static List<Driver> GetAllDrivers()
        {
            return Drivers;
        }

        public static List<Driver> GetAllFreeDrivers()
        {
            return Drivers.Where(x => x.LicenseExpiryDate > DateTime.Now && x.Shift == Shifts.NoShift).ToList();
        }

        public static List<Driver> GetAllAssignedDrivers()
        {
            return Drivers.Where(x => x.Shift != Shifts.NoShift).ToList();
        }
    }
}
