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
            if (!BL.Globals.Test_Internet_Con)
                return true;

            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("192.168.1.1", 3000);

                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool IsServerConnected()
        {
            return CheckServerConnection(
                server,
                database_name,
                database_user,
                database_pass);
        }

        public bool IsServerConnected(
            string server,
            string database_name,
            string database_user,
            string database_pass)
        {
            return CheckServerConnection(
                server,
                database_name,
                database_user,
                database_pass);
        }
       
        private bool CheckServerConnection(
            string server,
            string database_name,
            string database_user,
            string database_pass)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(
                    @"Server=" + server +
                    ";Database=" + database_name +
                    ";User Id=" + database_user +
                    ";Password=" + database_pass + ";"))
                {
                    connection.Open();

                    return connection.State == ConnectionState.Open;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }

    }
}
