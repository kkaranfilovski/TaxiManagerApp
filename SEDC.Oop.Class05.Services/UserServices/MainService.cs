using SEDC.Oop.Class05.Models.Enums;
using SEDC.Oop.Class05.Services.Menus;

namespace SEDC.Oop.Class05.Services.UserServices
{
    public class MainService
    {
        private UserService userService = new UserService();
        private AdminService adminService = new AdminService();
        private MaintenanceService maintenanceService = new MaintenanceService();
        private ManagerService managerService = new ManagerService();

        public void Main()
        {
            while (true)
            {
                Screens.WelcomeMenu();
                var user = userService.LogIn();

                if (user.Role == Roles.Administrator)
                {
                    adminService.AdminMenu(user);
                }
                else if (user.Role == Roles.Maintenance)
                {
                    maintenanceService.MaintenanceMenu(user);
                }
                else if (user.Role == Roles.Manager)
                {
                    managerService.ManagerMenu(user);
                }
            }
        }
    }
}
