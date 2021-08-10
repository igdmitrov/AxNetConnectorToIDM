using Microsoft.Dynamics.BusinessConnectorNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxNetConnectorToIDM
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            AxConnector ax = new AxConnector();
            ax.Connect();
            var users = ax.GetUsers();

            System.Console.WriteLine("Users:");
            foreach (AxaptaContainer user in users)
            {
                System.Console.WriteLine(user.get_Item(1));
            }

            var groups = ax.GetGroups();
            System.Console.WriteLine("Groups:");
            foreach (AxaptaContainer group in groups)
            {
                System.Console.WriteLine(group.get_Item(1));
            }

            var userId = ax.CreateUser(new NewUser() { UserAccount = "User_NA", Domain = "local.domain.com", CompanyId = "DAT" });
            System.Console.WriteLine(userId);

            var changeStatusResult = ax.ChangeUserStatus("local.domain.com", "User_NA", false);
            System.Console.WriteLine(changeStatusResult);

            var updateStatusResult = ax.UpdateUser("local.domain.com", "User_NA", "Test test", "test@test.com");
            System.Console.WriteLine(updateStatusResult);

            var addGroupToUserResult = ax.AddUserToGroup("local.domain.com", "User_NA", "U.ALL.001");
            System.Console.WriteLine(addGroupToUserResult);

            var removeGroupToUserResult = ax.RemoveUserFromGroup("local.domain.com", "User_NA", "U.ALL.001");
            System.Console.WriteLine(removeGroupToUserResult);

            ax.LogOff();

            System.Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();
        }
    }
}
