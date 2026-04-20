using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.BL.Services;


namespace School_Mang.PL.MAIN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 👇 إنشاء الـ Main Form (Singleton عندك)
            var mainForm = FRM_MAIN.Get_Frm_Main;

            AppNavigation.Instance
                .WithOwner(mainForm);

            Application.Run(mainForm);
        }
    }
}
