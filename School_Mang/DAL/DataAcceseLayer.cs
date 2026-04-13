using System;
using System.Data;
using System.Data.SqlClient;

namespace School_Mang.DAL
{
    public class DataAcceseLayer
    {
        readonly SqlConnection sqlConnection;
        private readonly string _connectionString;
        private SqlConnection _con;
        private SqlTransaction _trans;
        private readonly BL.MSG msg = new BL.MSG();

        public DataAcceseLayer()
        {
            string server = Properties.Settings.Default.Server_Name;
            string db = Properties.Settings.Default.DataBasee_name;
            string user = Properties.Settings.Default.DataBasee_User;
            string pass = Properties.Settings.Default.DataBasee_Pass;

            _connectionString =
                $"Server={server};Database={db};User Id={user};Password={pass};";
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // =========================
        // TRANSACTION SUPPORT
        // =========================
        public void BeginTransaction()
        {
            _con = CreateConnection();
            _con.Open();
            _trans = _con.BeginTransaction();
        }

        public void Commit()
        {
            _trans?.Commit();
            _con?.Close();
        }

        public void Rollback()
        {
            _trans?.Rollback();
            _con?.Close();
        }

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
        // =========================
        // CORE EXECUTOR
        // =========================
        private T Exec<T>(string text, CommandType type, SqlParameter[] prms, Func<SqlCommand, T> action)
        {
            try
            {
                using (SqlConnection con = CreateConnection())
                using (SqlCommand cmd = new SqlCommand(text, con))
                {
                    cmd.CommandType = type;

                    if (prms != null)
                        cmd.Parameters.AddRange(prms);

                    con.Open();
                    return action(cmd);
                }
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                return default(T);
            }
        }

        // =========================
        // EXEC NON QUERY (SP)
        // =========================
        public int ExecNonQuery(string sp, params SqlParameter[] prms)
        {
            return Exec(sp, CommandType.StoredProcedure, prms,
                cmd => cmd.ExecuteNonQuery());
        }

        // =========================
        // EXEC QUERY (SP)
        // =========================
        public DataTable ExecQuery(string sp, params SqlParameter[] prms)
        {
            return Exec(sp, CommandType.StoredProcedure, prms,
                cmd =>
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    return dt;
                });
        }

        // =========================
        // TEXT QUERY SELECT
        // =========================
        public DataTable Query(string sql, params SqlParameter[] prms)
        {
            return Exec(sql, CommandType.Text, prms,
                cmd =>
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    return dt;
                });
        }

        // =========================
        // EXEC NON QUERY (TEXT)
        // =========================
        public int ExecuteQuery(string sql, params SqlParameter[] prms)
        {
            return Exec(sql, CommandType.Text, prms,
                cmd => cmd.ExecuteNonQuery());
        }

        // =========================
        // TRANSACTION WRAPPER
        // =========================
        public void RunInTransaction(Action action)
        {
            try
            {
                BeginTransaction();
                action();
                Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
        }
        public DataTable SchoolSiteExeucuteQuery(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}