using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Mang.BL.Common.Helper;
using School_Mang.BL;

namespace School_Mang.BL.Common.Helper
{
    public static class InternetFlow
    {
        public static async Task<bool> EnsureAsync(int retries = 3, 
                                                    int delayMs = 500, 
                                                    bool showMessage = true)
        {
            Waiting.Start();

            try
            {
                bool ok = await InternetHelper.CheckInternetAsync(retries, delayMs);

                if (!ok)
                {
                    if (showMessage)
                        MSG.NoInternet();

                    return false;
                }

                return true;
            }
            finally
            {
                Waiting.Stop();
            }
        }
    }
}
