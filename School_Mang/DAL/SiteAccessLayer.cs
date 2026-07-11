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
        private bool HasTransaction => _con != null && _trans != null;

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
            if (HasTransaction)
                throw new InvalidOperationException("Transaction already started.");

            _con = CreateConnection();
            _con.Open();
            _trans = _con.BeginTransaction();
        }

        public void Commit()
        {
            if (!HasTransaction)
                return;

            _trans.Commit();
            _trans.Dispose();
            _trans = null;

            _con.Close();
            _con.Dispose();
            _con = null;
        }

        public void Rollback()
        {
            if (!HasTransaction)
                return;

            _trans.Rollback();
            _trans.Dispose();
            _trans = null;

            _con.Close();
            _con.Dispose();
            _con = null;
        }

        private static void AddParameters(SqlCommand cmd, SqlParameter[] parameters)
        {
            if (parameters?.Length > 0)
                cmd.Parameters.AddRange(parameters);
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
                if (HasTransaction)
                {
                    // أثناء الـ Transaction استخدم نفس الـ Connection
                    using (SqlCommand cmd = new SqlCommand(commandText, _con, _trans))
                    {
                        cmd.CommandType = commandType;

                        AddParameters(cmd, parameters);

                        return executor(cmd);
                    }
                }

                // تنفيذ عادي بدون Transaction
                using (SqlConnection con = CreateConnection())
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.CommandType = commandType;

                    AddParameters(cmd, parameters);

                    con.Open();
                    return executor(cmd);
                }
            }
            catch (Exception ex)
            {
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


        public DataTable SchoolSiteExecuteQuery(string query)
        {
            return Execute(
                query,
                CommandType.Text,
                null,
                cmd =>
                {
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    return dt;
                }
            );
        }

        // =========================
        // RAW NON QUERY (SITE DB)
        // =========================

        // لتنفيذ أوامر SQL النصية (Raw SQL) مثل DELETE وUPDATE الديناميكية.
        // لا تستخدم Stored Procedures.
        public void SchoolSiteExecuteNonQuery(string query)
        {
            Execute(
                query,
                CommandType.Text,
                null,
                cmd =>
                {
                    cmd.ExecuteNonQuery();
                    return 0;
                }
            );
        }

        public int ExecuteNonQuery(string sql, params SqlParameter[] prms)
        {
            return Execute(
                sql,
                CommandType.Text,
                prms,
                cmd => cmd.ExecuteNonQuery());
        }
        // =========================
        // EXEC SCALAR (Stored Procedure)
        // =========================
        public T ExecuteScalar<T>(string sp, params SqlParameter[] prms)
        {
            return Execute(sp, CommandType.StoredProcedure, prms,
                cmd =>
                {
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return default(T);

                    return (T)Convert.ChangeType(result, typeof(T));
                });
        }

        // =========================
        // EXEC SCALAR (Text Query)
        // =========================
        public T ExecuteScalarQuery<T>(string sql, params SqlParameter[] prms)
        {
            return Execute(sql, CommandType.Text, prms,
                cmd =>
                {
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return default(T);

                    return (T)Convert.ChangeType(result, typeof(T));
                });
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