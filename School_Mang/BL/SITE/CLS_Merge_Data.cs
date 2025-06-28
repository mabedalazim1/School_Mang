using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace School_Mang.BL.SITE
{
    class CLS_Merge_Data
    {
        readonly MSG msg = new MSG();
        readonly Waiting waiting = new Waiting();
        readonly DAL.DataAcceseLayer localDb = new DAL.DataAcceseLayer();
        readonly DAL.SchoolDataAtSite remoteDb = new DAL.SchoolDataAtSite();

        public void SyncTable(string tableName, string[] primaryKeys)
        {
            waiting.Wait();
            try
            {
                localDb.Open();
                remoteDb.Open();

                DataTable localTable = localDb.SchoolSiteExeucuteQuery($"SELECT * FROM {tableName}");
                DataTable remoteTable = remoteDb.SchoolSiteExeucuteQuery($"SELECT * FROM {tableName}");

                // حذف من البعيد
                foreach (DataRow remoteRow in remoteTable.Rows)
                {
                    bool exists = localTable.AsEnumerable().Any(localRow =>
                        primaryKeys.All(key => localRow[key].ToString() == remoteRow[key].ToString()));

                    if (!exists)
                    {
                        string whereClause = string.Join(" AND ", primaryKeys.Select(k =>
                            $"{k} = '{remoteRow[k].ToString().Replace("'", "''")}'"));
                        remoteDb.SchoolSiteExecuteNonQuery($"DELETE FROM {tableName} WHERE {whereClause}");
                    }
                }

                // إدراج أو تحديث
                foreach (DataRow localRow in localTable.Rows)
                {
                    DataRow remoteMatch = remoteTable.AsEnumerable().FirstOrDefault(remoteRow =>
                        primaryKeys.All(key => localRow[key].ToString() == remoteRow[key].ToString()));

                    if (remoteMatch == null)
                    {
                        // INSERT
                        var columns = localRow.Table.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
                        var values = columns.Select(c => {
                            var value = localRow[c].ToString().Replace("'", "''");
                            var type = localRow.Table.Columns[c].DataType;

                            // لو نصي → أضف حرف N
                            return type == typeof(string) ? $"N'{value}'" : $"'{value}'";
                        }).ToArray();

                        remoteDb.SchoolSiteExecuteNonQuery(
                            $"INSERT INTO {tableName} ({string.Join(",", columns)}) VALUES ({string.Join(",", values)})"
                        );
                    }
                    else
                    {
                        // UPDATE
                        List<string> updates = new List<string>();
                        foreach (DataColumn col in localTable.Columns)
                        {
                            var colName = col.ColumnName;
                            var localVal = localRow[colName].ToString();
                            var remoteVal = remoteMatch[colName].ToString();

                            if (localVal != remoteVal)
                            {
                                var formattedValue = col.DataType == typeof(string)
                                    ? $"N'{localVal.Replace("'", "''")}'"
                                    : $"'{localVal.Replace("'", "''")}'";

                                updates.Add($"{colName} = {formattedValue}");
                            }
                        }

                        if (updates.Any())
                        {
                            string setClause = string.Join(", ", updates);
                            string whereClause = string.Join(" AND ", primaryKeys.Select(k =>
                                $"{k} = '{localRow[k].ToString().Replace("'", "''")}'"));

                            remoteDb.SchoolSiteExecuteNonQuery($"UPDATE {tableName} SET {setClause} WHERE {whereClause}");
                        }
                    }
                }

                localDb.Close();
                remoteDb.Close();

                waiting.End_WAit();
                msg.MyMesg($"✅ تمت مزامنة جدول {tableName}");
            }
            catch (Exception ex)
            {
                waiting.End_WAit();
                msg.ErrorMesg(ex.Message);
            }
           
        }
    }
}
