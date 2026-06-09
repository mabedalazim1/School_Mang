using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using School_Mang.BL.Common.Helper;

namespace School_Mang.BL.STD
{
    public class CLS_STD
    {
        private readonly DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
        

        #region ===== Transfers =====

        public DataTable Get_Trans_Code(string year)
            => DAL.ExecQuery("SP_Get_Trans_Code",
                SqlParam.NVar("@year", year, 2));

        public DataTable GET_Trans_Data(int Grade_Id, params int[] statusIds)
        {
            bool hasTransferStatus = statusIds.Contains(3) || statusIds.Contains(7);

            int year = hasTransferStatus
               ? Convert.ToInt32(Globals.My_Year - 1)
                : Convert.ToInt32(Globals.My_Year);
            string statusList = string.Join(",", statusIds);

            return DAL.ExecQuery("SP_GET_Trans_Data",
                SqlParam.Int("@Year_Id", year),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.NVar("@Status_Ids", statusList)
            );
        }

        public DataTable GET_Trans_Data_By_Year(int year, int Grade_Id, params int[] statusIds)
        {
            
            string statusList = string.Join(",", statusIds);

            return DAL.ExecQuery("SP_GET_Trans_Data",
                SqlParam.Int("@Year_Id", year),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.NVar("@Status_Ids", statusList)
            );
        }

        public DataTable Search_Trans_Data(int Grade_Id, int Status_Id, string std_name)
        {
            int year = (Status_Id == 3)
                ? Convert.ToInt32(Globals.My_Year - 1)
                : Convert.ToInt32(Globals.My_Year);

            return DAL.ExecQuery("SP_Search_Trans_Data",
                SqlParam.Int("@Year_Id", year),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Status_Id", Status_Id),
                SqlParam.NVar("@std_name", std_name, 200));
        }

        public DataTable GET_Trans_By_Code(string std_code)
            => DAL.ExecQuery("SP_GET_Trans_By_Code",
                SqlParam.NVar("@std_code", std_code, 20));

        public DataTable Get_Tahewl_Data(string Transfer_code)
            => DAL.ExecQuery("SP_Get_Tahewl",
                SqlParam.NVar("@Transfer_code", Transfer_code, 20));

        #endregion

        #region ===== Reports =====

       

        

        public DataTable Get_Kaema_Data(int year_id, int grade_id)
            => DAL.ExecQuery("SP_Get_Kaema_Data",
                SqlParam.Int("@year_id", year_id),
                SqlParam.Int("@grade_id", grade_id));

        public DataTable Get_Segel_Data(int year_id, int grade_id = 0)
            => DAL.ExecQuery("SP_Get_Segel_Data",
                SqlParam.Int("@year_id", year_id),
                SqlParam.Int("@Grade_Id", grade_id),
                SqlParam.Int("@October_Sana", year_id + 20));

        public DataTable Get_Tadrg_Sen(int year_id, int grade_id = 0,bool isDesc = false)
            => DAL.ExecQuery("SP_Get_Tadrg_Sen",
                SqlParam.Int("@year_id", year_id),
                SqlParam.Int("@Grade_Id", grade_id),
                SqlParam.Int("@October_Sana", year_id + 20),
                SqlParam.Bit("@isDesc", isDesc));


        #endregion

        #region ===== Site =====

        public DataTable Get_Data_For_Site(int Grade_Id = 0, int Golos = 0)
            => DAL.ExecQuery("SP_Get_Data_For_Site",
                SqlParam.Int("@Year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@Golos", Golos),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.NVar("@stdunet_full_name", "", 255),
                SqlParam.Bit("@search", false));

        public DataTable Get_Data_For_Site(int Grade_Id, string stdunet_full_name)
            => DAL.ExecQuery("SP_Get_Data_For_Site",
                SqlParam.Int("@Year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@Golos", 0),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.NVar("@stdunet_full_name", stdunet_full_name, 255),
                SqlParam.Bit("@search", true));

        #endregion

        public void Add_Std_Data(string std_code,
                         string std_name, string std_nat, DateTime std_date,
                         int Gender_Id, int Nationality_Id, int Religion_Id,
                         int Std_Status_Id, int Grade_Id, int Year_Id,
                         int Osraa_Id)
        {
            DAL.ExecNonQuery("SP_Add_Std_Data",
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.NVar("@std_name", std_name, 12),
                SqlParam.NVar("@std_nat", std_nat, 14),
                SqlParam.Date("@std_date", std_date),
                SqlParam.Int("@Gender_Id", Gender_Id),
                SqlParam.Int("@Nationality_Id", Nationality_Id),
                SqlParam.Int("@Religion_Id", Religion_Id),
                SqlParam.Int("@Std_Status_Id", Std_Status_Id),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.Int("@Osraa_Id", Osraa_Id),
                SqlParam.NVar("@Created_by", Properties.Settings.Default.user_name, 15),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15)
            );
        }
        public void Update_Std_Data(string std_code,
                            string std_name, string std_nat, DateTime std_date,
                            int Gender_Id, int Nationality_Id, int Religion_Id,
                            int Std_Status_Id, int Grade_Id, int Year_Id,
                            int Osraa_Id)
        {
            DAL.ExecNonQuery("SP_Update_Std_Data",
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.NVar("@std_name", std_name, 12),
                SqlParam.NVar("@std_nat", std_nat, 14),
                SqlParam.Date("@std_date", std_date),
                SqlParam.Int("@Gender_Id", Gender_Id),
                SqlParam.Int("@Nationality_Id", Nationality_Id),
                SqlParam.Int("@Religion_Id", Religion_Id),
                SqlParam.Int("@Std_Status_Id", Std_Status_Id),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.Int("@Osraa_Id", Osraa_Id),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15)
            );
        }
        
        
        public void Add_Transfers_Data(string Transfer_code,
                               string std_code,
                               string Transfer_School,
                               int Transfer_status,
                               int Year_Id,
                               string Guardian_name,
                               string Transfer_reason,
                               byte Resom, byte Kotob,
                               string adrs, int New_Grade,
                               bool Trans_After_Year,
                               bool NewStudentInThisYear)
        {
            DAL.ExecNonQuery("SP_Add_Transfers_Data",
                SqlParam.NVar("@Transfer_code", Transfer_code, 20),
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.NVar("@Transfer_School", Transfer_School, 100),
                SqlParam.Int("@Transfer_status", Transfer_status),
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.NVar("@Guardian_name", Guardian_name, 50),
                SqlParam.NVar("@Transfer_reason", Transfer_reason, 50),
                SqlParam.Byte("@Resom", Resom),
                SqlParam.Byte("@Kotob", Kotob),
                SqlParam.NVar("@adrs", adrs, 1000),
                SqlParam.NVar("@Created_by", Properties.Settings.Default.user_name, 15),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15),
                SqlParam.Int("@New_Grade", New_Grade),
                SqlParam.Bit("@Trans_After_Year", Trans_After_Year),
                SqlParam.Bit("@NewStudentInThisYear", NewStudentInThisYear)
            );
        }
       
        public void Update_Trans_Data(int Transfer_code,
                                      string Transfer_School,
                                      string Guardian_name,
                                      string Transfer_reason,
                                      byte Resom, byte Kotob,
                                      string adrs)
        {
            DAL.ExecNonQuery("SP_Update_Trans_Data",
                SqlParam.Int("@Transfer_code", Transfer_code),
                SqlParam.NVar("@Transfer_School", Transfer_School, 100),
                SqlParam.NVar("@Guardian_name", Guardian_name, 50),
                SqlParam.NVar("@Transfer_reason", Transfer_reason, 50),
                SqlParam.Byte("@Resom", Resom),
                SqlParam.Byte("@Kotob", Kotob),
                SqlParam.NVar("@adrs", adrs, 1000),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15)
            );
        }
        public DataTable Get_Count_New_Year(int new_year)
        {
            string query = @"SELECT COUNT(std_code) AS std_code 
                     FROM School_Std_Data
                     WHERE Year_Id = @Year_Id";

            return DAL.Query(query,
                SqlParam.Int("@Year_Id", new_year)
            );
        }
        public DataTable Get_Count_Trans_Std(int new_year, string std_code)
        {
            string query = @"SELECT COUNT(std_code) AS std_code
                     FROM School_Std_Data
                     WHERE Year_Id = @Year_Id
                     AND std_code = @std_code";

            return DAL.Query(query,
                SqlParam.Int("@Year_Id", new_year),
                SqlParam.NVar("@std_code", std_code, 20)
            );
        }
        public void Delete_Transfers_Data(int Transfer_code,
                                  string std_code,
                                  int Year_Id,
                                  int Grade_Id,
                                  int Class_Id,
                                  int new_year,
                                  int std_found,
                                  int To_School,
                                  bool Trans_After_Year)
        {
            DAL.ExecNonQuery("SP_Delete_Transfers_Data",
                SqlParam.Int("@Transfer_code", Transfer_code),
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Class_Id", Class_Id),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15),
                SqlParam.Int("@new_year", new_year),
                SqlParam.Int("@std_found", std_found),
                SqlParam.Int("@To_School", To_School),
                SqlParam.Bit("@Trans_After_Year", Trans_After_Year)
            );
        }
        
    }
}