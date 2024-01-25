using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL
{
    class CLS_TEST_INTRNET_CON
    {
        Waiting Waiting = new Waiting();
        MSG msg = new MSG();

        public async Task ChecK_Internt_Con()
        {
            try
            {
                Waiting.Wait();

                Ping ping = new Ping();
                string hostName = Properties.Settings.Default.Site_Server_Name;
                PingReply reply = await ping.SendPingAsync(hostName);
                if (reply.Status == IPStatus.Success)
                {
                    Globals.Test_Internet_Con = true;
                }
                else
                {
                    Globals.Test_Internet_Con = false;
                }

                Waiting.End_WAit();
            }catch(Exception e)
            {
                Globals.Test_Internet_Con = false;
                Waiting.End_WAit();
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.End_WAit();
            }
            
        }
    }
}
