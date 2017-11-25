using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aimu
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PropertyHandler.getEnvProperties();
            Main main = new aimu.Main();
            main.Visible = false;
            //User user = new User();
            //user.tenantId = 1;
            //user.storeId = 0;
            //user.roleId = 1;
            //user.cellPhone = 13681395366;
            //user.name = "admin";
            //user.mail = "";
            //user.memo = "";
            //user.passwordSalt = PasswordEncryption.generateSalt();
            //user.password = PasswordEncryption.generatePassword("aimupassw0rd", user.passwordSalt);
            //GlobalDb.createUser(user);
            Application.Run(main);
            Logger.getLogger().close();
        }
    }
}
