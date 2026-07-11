using System;
using System.Data;
using System.Data.SqlClient;
using School_Mang.BL;

namespace School_Mang.DAL
{
    public class DataAcceseLayer
    {
        private readonly string _connectionString;
        private SqlConnection _con;
        private SqlTransaction _trans;

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

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    con.Open();
                    return executor(cmd);
                }
            }
            catch (Exception ex)
            {
                // مهم: لا UI داخل DAL
                throw new Exception("Database Error: " + ex.Message, ex);
            }
        }

        // =========================
        // EXEC NON QUERY (SP)
        // =========================
        public int ExecNonQuery(string sp, params SqlParameter[] prms)
        {
            return Execute(sp, CommandType.StoredProcedure, prms,
                cmd => cmd.ExecuteNonQuery());
        }

        // =========================
        // EXEC QUERY (SP)
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
        // TEXT QUERY SELECT
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


        // =========================
        // EXEC NON QUERY (TEXT)
        // =========================
        public int ExecuteQuery(string sql, params SqlParameter[] prms)
        {
            return Execute(sql, CommandType.Text, prms,
                cmd => cmd.ExecuteNonQuery());
        }


        // =========================
        // TRANSACTION WRAPPER
        // =========================
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


        // =========================
        // RAW QUERY (SITE DB)
        // =========================
        public DataTable LocalDbExeucuteQuery(string query)
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
        public void LocalDbExeucuteNonQuery(string query)
        {
            using (var con = CreateConnection())
            using (var cmd = new SqlCommand(query, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        // =========================
        // BULK INSERT
        // =========================
        public void BulkInsert(DataTable table, string destinationTable)
        {
            using (SqlConnection con = CreateConnection())
            {
                con.Open();

                using (SqlBulkCopy bulk = new SqlBulkCopy(con))
                {
                    bulk.DestinationTableName = destinationTable;

                    foreach (DataColumn column in table.Columns)
                    {
                        bulk.ColumnMappings.Add(
                            column.ColumnName,
                            column.ColumnName);
                    }

                    bulk.WriteToServer(table);
                }
            }
        }

        public int ExecuteTableParameter(
                                        string sp,
                                        string parameterName,
                                        DataTable table,
                                        string typeName)
        {
            return Execute(sp,
                CommandType.StoredProcedure,
                new[]
                {
            new SqlParameter(parameterName, SqlDbType.Structured)
            {
                TypeName = typeName,
                Value = table
            }
                },
                cmd => cmd.ExecuteNonQuery());
        }
    }
}