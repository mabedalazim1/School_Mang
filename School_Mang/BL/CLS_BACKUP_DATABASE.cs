using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL
{
    class CLS_BACKUP_DATABASE
    {
        DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
        MSG msg = new MSG();
        Waiting waiting = new Waiting();

        public string temp_data_name = "";

        // Mothed To BackUp DataBase 
        public void BackUP_DataBase(string file_name)
        {
            try
            {
                waiting.Wait();
                string Query = "Backup Database KPS_DATA_2023 to Disk ='" + file_name + "';";
                DAL.ExeucuteQuery(Query);
                temp_data_name = file_name;
                waiting.End_WAit();
                msg.MyExclamationMsg("تم إنشاء النسخة الاحتياطية  ..!" + file_name);
            }
            catch(Exception e)
            {
                msg.ErrorMesg(e.Message);
                waiting.End_WAit();
            }
            

        }

        // Mothed To Restore DataBase 
        public void Restore_DataBase(string file_name)
        {
            try
            {
                waiting.Wait();
                string Query = "USE master;" +
                           "ALTER DATABASE KPS_DATA_2023 SET OFFLINE WITH ROLLBACK IMMEDIATE;" +
                           "Restore Database KPS_DATA_2023 From Disk ='" + file_name +
                           "' WITH REPLACE; ALTER DATABASE KPS_DATA_2023 SET ONLINE WITH ROLLBACK IMMEDIATE;";

                DAL.ExeucuteQuery(Query);
                waiting.End_WAit();
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
                waiting.End_WAit();
            }

            
        }
    }
}
