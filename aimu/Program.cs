using System;
using System.Collections.Generic;
using System.Linq;
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
            Application.Run(main);
           // Application.Run(new Login());
        }
    }
}
