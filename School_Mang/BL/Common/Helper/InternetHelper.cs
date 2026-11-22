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
        public static async Task<bool> CheckInternetAsync(
            int retries = 2,
            int delayMs = 300)
        {
            string host = Properties.Settings.Default.Site_Server_Name;

            if (string.IsNullOrWhiteSpace(host))
                return false;

            try
            {
                using (var ping = new System.Net.NetworkInformation.Ping())
                {
                    for (int i = 0; i < retries; i++)
                    {
                        try
                        {
                            var reply = await ping.SendPingAsync(host, 1000);

                            if (reply.Status ==
                                System.Net.NetworkInformation.IPStatus.Success)
                            {
                                return true;
                            }
                        }
                        catch
                        {
                            // فشل المحاولة الحالية، ننتقل للمحاولة التالية
                        }

                        if (i < retries - 1)
                            await Task.Delay(delayMs);
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}