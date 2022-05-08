using SEDC.Oop.Class05.Models.Interfaces;

namespace SEDC.Oop.Class05.Models.Models
{
    public class Car : IExpiryDate
    {
        public static int IdCounter { get; set; } = 0;
        public int Id { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public List<Driver> AssignedDrivers { get; set; }
        public DateTime LicenseExpiryDate { get; set ; }

        public Car()
        {

        }

        public Car(string model, string licensePlate, DateTime expireyDate)
        {
            Id = IdCounter += 1;
            Model = model;
            LicensePlate = licensePlate;
            AssignedDrivers = new List<Driver>();
            LicenseExpiryDate = expireyDate;
        }
    }
}
