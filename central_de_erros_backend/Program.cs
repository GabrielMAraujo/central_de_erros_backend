using System;
using central_de_erros_backend.Services;

namespace central_de_erros_backend
{
    class Program
    {
        static void Main(string[] args)
        {
            CentralContext context = new CentralContext();

            UserService userService = new UserService(context);

            userService.AddTestUsers();

            AlertService alertService = new AlertService(context);

            alertService.AddTestAlerts();
        }
    }
}
