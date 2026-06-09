using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL
{
    public static class AppEnvironment
    {
        public static bool IsServer =>
           System.Net.IPAddress.TryParse(GetServerHost(), out _);

        private static string GetServerHost()
        {
            string server = Properties.Settings.Default.Server_Name;
            return server.Split('\\')[0];
        }
    }
}
