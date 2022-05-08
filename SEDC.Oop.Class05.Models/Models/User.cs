using SEDC.Oop.Class05.Models.Enums;

namespace SEDC.Oop.Class05.Models.Models
{
    public class User
    {
        public static int IdCounter { get; set; } = 0;
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isLoggedIn { get; set; }
        public Roles Role { get; set; }

        public User(string userName, string password, Roles role)
        {
            Id = IdCounter += 1;
            UserName = userName;
            Password = password;
            Role = role;
            isLoggedIn = false;
        }

    }
}
