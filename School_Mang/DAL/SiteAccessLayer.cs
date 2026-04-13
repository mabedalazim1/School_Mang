using System;
using System.Data;
using System.Data.SqlClient;

namespace School_Mang.DAL
{
    public class SiteAccessLayer
    {
        private readonly string _connectionString;
        private SqlConnection _con;
        private SqlTransaction _trans;
        private readonly BL.MSG msg = new BL.MSG();

        public SiteAccessLayer()
        {
            string server = Properties.Settings.Default.Site_Server_Name;
            string db = Properties.Settings.Default.Site_DataBasee_name;
            string user = Properties.Settings.Default.Site_DataBasee_User;
            string pass = Properties.Settings.Default.Site_DataBasee_Pass;

            _connectionString =
                $"Server={server};Database={db};User Id={user};Password={pass};";
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
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

                    if (prms != null && prms.Length > 0)
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
        // EXEC NON QUERY
        // =========================
        public int ExecNonQuery(string sp, params SqlParameter[] prms)
        {
            return Exec(sp, CommandType.StoredProcedure, prms,
                cmd => cmd.ExecuteNonQuery());
        }

        // =========================
        // EXEC QUERY (Stored Procedure)
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
        // TEXT QUERY
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
    }
}