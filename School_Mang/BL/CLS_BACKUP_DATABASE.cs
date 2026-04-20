using System;
using School_Mang.DAL;
using School_Mang.BL;

namespace School_Mang.BL
{
    class CLS_BACKUP_DATABASE
    {
        private readonly DataAcceseLayer DAL = new DataAcceseLayer();

        public string temp_data_name = "";

        // =========================
        // BACKUP DATABASE
        // =========================
        public void BackUP_DataBase(string file_name)
        {
            try
            {
                Waiting.Start();

                string safeFile = SanitizePath(file_name);

                string query = $@"
                                BACKUP DATABASE KPS_DATA_2023
                                TO DISK = '{safeFile}'
                                WITH INIT, STATS = 10;
                                ";

                DAL.ExecuteQuery(query);

                temp_data_name = file_name;

                MSG.MyExclamationMsg("تم إنشاء النسخة الاحتياطية بنجاح");
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
            }
        }

        // =========================
        // RESTORE DATABASE
        // =========================
        public void Restore_DataBase(string file_name)
        {
            try
            {
                Waiting.Start();

                string safeFile = SanitizePath(file_name);

                // 1 - offline
                DAL.ExecuteQuery(@"
                                USE master;
                                ALTER DATABASE KPS_DATA_2023 SET OFFLINE WITH ROLLBACK IMMEDIATE;
                                ");

                // 2 - restore
                string restoreQuery = $@"
                                        RESTORE DATABASE KPS_DATA_2023
                                        FROM DISK = '{safeFile}'
                                        WITH REPLACE;
                                        ";

                DAL.ExecuteQuery(restoreQuery);

                // 3 - online
                DAL.ExecuteQuery(@"
                                ALTER DATABASE KPS_DATA_2023 SET ONLINE WITH ROLLBACK IMMEDIATE;
                                ");

                MSG.MyExclamationMsg("تم استرجاع النسخة الاحتياطية بنجاح");
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
            }
        }

        // =========================
        // SECURITY HELPERS
        // =========================
        private string SanitizePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new Exception("مسار الملف غير صحيح");

            return path
                .Trim()
                .Replace("'", "''"); // مهم جدًا لـ SQL string safety
        }
    }
}