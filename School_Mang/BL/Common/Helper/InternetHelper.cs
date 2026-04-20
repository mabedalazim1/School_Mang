using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Mang.BL;

namespace School_Mang.BL.Common.Helper
{
    public static class InternetHelper
    {


        /// <summary>
        /// تحقق من الاتصال بالإنترنت بشكل عام
        /// </summary>
        public static async Task<bool> CheckInternetAsync(int retries = 3, int delayMs = 500)
        {
            try
            {
                using (var ping = new System.Net.NetworkInformation.Ping())
                {
                    string host = Properties.Settings.Default.Site_Server_Name;

                    for (int i = 0; i < retries; i++)
                    {
                        var reply = await ping.SendPingAsync(host);

                        if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                            return true;

                        await Task.Delay(delayMs);
                    }

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}