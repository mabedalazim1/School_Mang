using System.Data;
using System.Data.SqlClient;
using System;

namespace School_Mang.DAL
{
    class SchoolDataAtSite
    {
        readonly SqlConnection sqlConnection;
        BL.MSG msg = new BL.MSG();
        BL.Waiting waiting = new BL.Waiting();
        readonly TestConcation Test_Con = new TestConcation();


        // Connection Object
        string server = Properties.Settings.Default.School_Site_Server_Name;
        string database_name = Properties.Settings.Default.School_Site_Database_Name;
        string database_user = Properties.Settings.Default.School_Site_DataBase_User;
        string database_pass = Properties.Settings.Default.School_Site_DataBase_Pass;

        public SchoolDataAtSite()
        {
            try
            {
                sqlConnection = new SqlConnection(@"Server=" + server + ";Database= " +
                                database_name + "; User Id = " + database_user +
                                "; Password = " + database_pass + ";");
            }
            catch (SqlException e)
            {
                msg.ErrorMesg(e.Message);
                return;
            }
        }
        // Mothed To Open Connection
        public void Open()
        {

            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }

        }
        public void Close()
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }

        }
 
        // Mothed To Exeucute Query By string 
        public DataTable SchoolSiteExeucuteQuery(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void SchoolSiteExecuteNonQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.ExecuteNonQuery();
        }

    }
}
