using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Common.Helper
{
    public static class InternetHelper
    {
        private static readonly Waiting Waiting = new Waiting();

        /// <summary>
        /// تحقق من الاتصال بالإنترنت بشكل عام
        /// </summary>
        public static async Task<bool> CheckInternetAsync()
        {
            Waiting.Wait();
            try
            {
                var testInternet = new CLS_TEST_INTRNET_CON();

                for (int i = 0; i < 3; i++)
                {
                    await testInternet.ChecK_Internt_Con();

                    if (Globals.Test_Internet_Con)
                        return true;

                    await Task.Delay(500);
                }

                return false;
            }
            finally
            {
                Waiting.End_WAit();
            }
        }
    }
}
