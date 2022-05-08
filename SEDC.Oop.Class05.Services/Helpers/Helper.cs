using SEDC.Oop.Class05.Models.Interfaces;

namespace SEDC.Oop.Class05.Services.Helpers
{
    public static class Helper
    {
        public static void ExpiryColor<T>(T item) where T : IExpiryDate
        {
            DateTime dateTimeNow = DateTime.Now;
            string status = String.Empty;

            if (dateTimeNow > item.LicenseExpiryDate)
            {
                status = "Expired";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(status);
                Console.ResetColor();
            }
            else if (item.LicenseExpiryDate.Year == dateTimeNow.Year && item.LicenseExpiryDate.Month - dateTimeNow.Month <= 3)
            {
                status = "Warning";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(status);
                Console.ResetColor();
            }
            else
            {
                status = "Valid";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(status);
                Console.ResetColor();
            }
        }

        public static void ShowError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            Thread.Sleep(1500);
        }
    }
}
