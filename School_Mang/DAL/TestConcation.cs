using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Data;
using System.Data.SqlClient;

namespace School_Mang.DAL
{
    class TestConcation
    {

        // Connection Object
        public static string server = Properties.Settings.Default.Server_Name;
        public static string database_name = Properties.Settings.Default.DataBasee_name;
        public static string database_user = Properties.Settings.Default.DataBasee_User;
        public static string database_pass = Properties.Settings.Default.DataBasee_Pass;

        public bool IsConnectedToInternet()
        {
            string host = "192.168.1.1";  
            bool result = false;
            Ping p = new Ping();

            if (!BL.Globals.Test_Internet_Con) return true;

            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
                
            }
            catch{ }
            return result;
        }
        public bool IsServerConnected()
        {

            SqlConnection connection = new SqlConnection(@"Server=" + server + ";Database= " +
                                    database_name + "; User Id = " + database_user +
                                    "; Password = " + database_pass + ";");
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public bool IsServerConnected(
            string server,
            string database_name ,
            string database_user ,
            string database_pass)
        {
            SqlConnection connection = new SqlConnection(@"Server=" + server + ";Database= " +
                                    database_name + "; User Id = " + database_user +
                                    "; Password = " + database_pass + ";");
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

    }
}
