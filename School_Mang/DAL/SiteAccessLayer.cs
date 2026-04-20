using System;
using System.Data;
using System.Data.SqlClient;
using School_Mang.BL;

namespace School_Mang.DAL
{
    public class SiteAccessLayer
    {
        private readonly string _connectionString;
        private SqlConnection _con;
        private SqlTransaction _trans;

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
            _trans = null;

            _con?.Close();
            _con = null;
        }

        public void Rollback()
        {
            _trans?.Rollback();
            _trans = null;

            _con?.Close();
            _con = null;
        }

        // =========================
        // CORE EXECUTOR
        // =========================
        private T Execute<T>(
            string commandText,
            CommandType commandType,
            SqlParameter[] parameters,
            Func<SqlCommand, T> executor)
        {
            try
            {
                using (SqlConnection con = CreateConnection())
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.CommandType = commandType;

                    if (_trans != null)
                        cmd.Transaction = _trans;

                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    con.Open();
                    return executor(cmd);
                }
            }
            catch (Exception ex)
            {
                // مهم: لا UI داخل DAL
                throw new Exception("Site DB Error: " + ex.Message, ex);
            }
        }
        // =========================
        // EXEC NON QUERY
        // =========================
        public int ExecNonQuery(string sp, params SqlParameter[] prms)
        {
            return Execute(sp, CommandType.StoredProcedure, prms,
                cmd => cmd.ExecuteNonQuery());
        }

        // =========================
        // EXEC QUERY (Stored Procedure)
        // =========================
        public DataTable ExecQuery(string sp, params SqlParameter[] prms)
        {
            return Execute(sp, CommandType.StoredProcedure, prms,
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
            return Execute(sql, CommandType.Text, prms,
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


        public DataTable SchoolSiteExeucuteQuery(string query)
        {
            using (var con = CreateConnection())
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // =========================
        // RAW NON QUERY (SITE DB)
        // =========================
        public void SchoolSiteExecuteNonQuery(string query)
        {
            using (var con = CreateConnection())
            using (var cmd = new SqlCommand(query, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RunInTransaction(Action action)
        {
            BeginTransaction();

            try
            {
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