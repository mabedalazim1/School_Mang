using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.DAL
{
    public class SiteAccessLayer
    {
        readonly SqlConnection sqlConnection;
        BL.MSG msg = new BL.MSG();
        readonly DAL.TestConcation Test_Con = new TestConcation();


        public SiteAccessLayer()
        {
            // Connection Object
            string server = "sql5080.site4now.net";
            string database_name = "db_a786ad_kpsdata";
            string database_user = "db_a786ad_kpsdata_admin";
            string database_pass = "kps@2020";

            try
            {
                sqlConnection = new SqlConnection(@"Server=" + server + ";Database= " +
                                database_name + "; User Id = " + database_user +
                                "; Password = " + database_pass + ";");
            }
            catch (SqlException e)
            {
                msg.ErrorMesg(e.Message);
            }
        }

        // Mothed To Open Connection
        public void Open()
        {
            if (Test_Con.IsConnectedToInternet() == false) return;
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
            if (Test_Con.IsConnectedToInternet() == false) return;
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
        // Mothed To Read Data From Databasse
        public DataTable Selectdata(string stored_procedure, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = stored_procedure;
                sqlcmd.Connection = sqlConnection;

                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        sqlcmd.Parameters.Add(param[i]);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                // return dt;
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            return dt;
        }
        // Mothed To Insert Delete Update Data
        public void ExeucuteCommand(string stored_procedure, SqlParameter[] param)
        {
            if (Test_Con.IsConnectedToInternet() == false) return;
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = stored_procedure;
                sqlcmd.Connection = sqlConnection;

                if (param != null)
                {
                    sqlcmd.Parameters.AddRange(param);
                }
                Open();
                sqlcmd.ExecuteNonQuery();
                Close();
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }

        }

        // Mothed To Read Data From Databasse By Query
        public DataTable ReadData_Query(string Query, SqlParameter[] param)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = Query;
                sqlcmd.Connection = sqlConnection;

                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        sqlcmd.Parameters.Add(param[i]);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                Close();
            }
            Close();
            return dt;
        }

        // Mothed To Update Data From Databasse By Query
        public DataTable Update_Data_Query(string Query, SqlParameter[] param)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = Query;
                sqlcmd.Connection = sqlConnection;

                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        sqlcmd.Parameters.Add(param[i]);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                da.Update(dt);
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                Close();
            }
            Close();
            return dt;
        }

        // Mothed To Exeucute Query
        public void ExeucuteQuery(string query)
        {
            if (Test_Con.IsConnectedToInternet() == false) return;
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = query;
                sqlcmd.Connection = sqlConnection;

                Open();
                sqlcmd.ExecuteNonQuery();
                Close();
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }

        }

    }
}
