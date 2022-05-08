using SEDC.Oop.Class05.Models.Enums;
using SEDC.Oop.Class05.Models.Interfaces;

namespace SEDC.Oop.Class05.Models.Models
{
    public class Driver : IExpiryDate
    {
        public static int IdCounter { get; set; } = 0;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Shifts Shift { get; set; }
        public Car Car { get; set; }
        public string License { get; set; }
        public DateTime LicenseExpiryDate { get; set; }

        public Driver(string fName, string lName, Shifts shift, string license, DateTime expireyDate)
        {
            Id = IdCounter += 1;
            FirstName = fName;
            LastName = lName;
            Shift = shift;
            License = license;
            Car = new Car();
            LicenseExpiryDate = expireyDate;
        }
    }
}
