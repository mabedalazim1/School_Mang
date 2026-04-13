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
        #region ===== Basic Data =====

        public DataTable Get_years(int year = 0)
        {
            return DAL.ExecQuery("SP_GETYEARS",
                SqlParam.Int("@year", year == 0 ? Properties.Settings.Default.MyYear : year));
        }

        public DataTable Get_genders()
            => DAL.ExecQuery("SP_GETGENDERS", null);

        public DataTable Get_grades(string frist_classes = "no")
            => DAL.ExecQuery("SP_GETGRADES",
                SqlParam.NVar("@frist_classes", frist_classes, 3));

        public DataTable Get_nationalities()
            => DAL.ExecQuery("SP_NATIONLITIES", null);

        public DataTable Get_stdStat()
            => DAL.ExecQuery("SP_STDSTAT", null);

        public DataTable Get_religion()
            => DAL.ExecQuery("SP_RELIGIONS", null);

        public DataTable Get_OSRA_STAT_FEMALE()
            => DAL.ExecQuery("SP_OSRA_STAT_FEMALE", null);

        public DataTable Get_OSRA_STAT_MALE()
            => DAL.ExecQuery("SP_OSRA_STAT_MALE", null);

        public DataTable Get_Class_Id(int Grade_Id)
            => DAL.ExecQuery("SP_Get_Class_Id",
                SqlParam.Int("@Grade_Id", Grade_Id));

        #endregion

        #region ===== Verify =====

        public DataTable Verify_Std_Nat(string std_nat, string std_code = "0")
            => DAL.ExecQuery("SP_Verify_Std_Nat",
                SqlParam.NVar("@std_nat", std_nat, 14),
                SqlParam.NVar("@std_code", std_code, 20));

        public DataTable Verify_Osra_Nat(string nat, int id)
            => DAL.ExecQuery("SP_Verify_Osra_Nat",
                SqlParam.NVar("@nat", nat, 14),
                SqlParam.Int("@osra_Id", id));

        public DataTable Verify_Std_Code(string std_code)
            => DAL.ExecQuery("SP_Verify_Std_Code",
                SqlParam.NVar("@std_code", std_code, 20));

        public DataTable Verify_Osra_Code(string Year)
            => DAL.ExecQuery("SP_Verify_Osra_Code",
                SqlParam.NVar("@Year", Year, 2));

        public DataTable Verify_Osra_Data(int Osraa_Id)
            => DAL.ExecQuery("SP_Verify_Osra_Data",
                SqlParam.Int("@Osraa_Id", Osraa_Id));

        public DataTable Verify_Std_School_Code(string std_code, int Year_Id)
            => DAL.ExecQuery("SP_Verify_Std_School_Code",
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.Int("@Year_Id", Year_Id));

        #endregion

        #region ===== Osra =====

        public DataTable Get_All_Osra_Data()
            => DAL.ExecQuery("SP_Get_All_Osra_Data", null);

        public DataTable Search_Osra_Data(string osra_data)
            => DAL.ExecQuery("SP_Search_Osra_Data",
                SqlParam.NVar("@osra_data", osra_data, 100));

        public DataTable Get_osra_Data_ById(int Osraa_Id)
            => DAL.ExecQuery("SP_Get_osra_Data_ById",
                SqlParam.Int("@Osraa_Id", Osraa_Id));

        public void Delele_Osra_Data(int Osra_Id)
            => DAL.ExecNonQuery("SP_Delele_Osra_Data",
                SqlParam.Int("@Osra_Id", Osra_Id));

        #endregion

        #region ===== Student =====

        public DataTable Get_All_Std_Data(int Year_Id)
            => DAL.ExecQuery("SP_Get_All_Std_Data",
                SqlParam.Int("@Year_Id", Year_Id));

        public DataTable Search_Std_Data(string std_data, int Year_Id)
            => DAL.ExecQuery("SP_Search_Std_Data",
                SqlParam.NVar("@std_data", std_data, 100),
                SqlParam.Int("@Year_Id", Year_Id));

        public void Delele_Std_Data(string std_code)
            => DAL.ExecNonQuery("SP_Delele_Std_Data",
                SqlParam.NVar("@std_code", std_code, 20));

        #endregion

        #region ===== School Data =====

        public DataTable Get_School_year_Data(int Year_Id, int Grade_Id, int Class_Id)
            => DAL.ExecQuery("SP_Get_School_year_Data",
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Class_Id", Class_Id));

        public DataTable Search_School_year_Data(int Year_Id, int Grade_Id, int Class_Id, string std_name)
            => DAL.ExecQuery("SP_Search_School_year_Data",
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Class_Id", Class_Id),
                SqlParam.NVar("@std_name", std_name, 200));

        public void Delete_School_Std_Data(string std_code, int Year_Id)
            => DAL.ExecNonQuery("SP_Delete_School_Std_Data",
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.Int("@Year_Id", Year_Id));

        #endregion

        #region ===== Transfers =====

        public DataTable Get_Trans_Code(string year)
            => DAL.ExecQuery("SP_Get_Trans_Code",
                SqlParam.NVar("@year", year, 2));

        public DataTable GET_Trans_Data(int Grade_Id, int Status_Id)
        {
            int year = (Status_Id == 3)
                ? Convert.ToInt32(Globals.My_Year - 1)
                : Convert.ToInt32(Globals.My_Year);

            return DAL.ExecQuery("SP_GET_Trans_Data",
                SqlParam.Int("@Year_Id", year),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Status_Id", Status_Id));
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

        public DataTable Get_Year_Desc(int year)
            => DAL.ExecQuery("SP_Get_Year_Desc",
                SqlParam.Int("@year", year));

        public DataTable Get_Grade_Desc(int grade_id)
            => DAL.ExecQuery("SP_Get_Grade_Desc",
                SqlParam.Int("@grade_id", grade_id));

        public DataTable Get_Kaema_Data(int year_id, int grade_id)
            => DAL.ExecQuery("SP_Get_Kaema_Data",
                SqlParam.Int("@year_id", year_id),
                SqlParam.Int("@grade_id", grade_id));

        public DataTable Get_Segel_Data(int year_id, int grade_id = 0)
            => DAL.ExecQuery("SP_Get_Segel_Data",
                SqlParam.Int("@year_id", year_id),
                SqlParam.Int("@Grade_Id", grade_id),
                SqlParam.Int("@October_Sana", year_id + 20));

        public DataTable Get_Tadrg_Sen(int year_id, int grade_id = 0)
            => DAL.ExecQuery("SP_Get_Tadrg_Sen",
                SqlParam.Int("@year_id", year_id),
                SqlParam.Int("@Grade_Id", grade_id),
                SqlParam.Int("@October_Sana", year_id + 20));

        public DataTable Get_Trans_Reports(int Year_Id, int Status_Id, int Grade_Id = 0)
            => DAL.ExecQuery("SP_GET_Trans_Data",
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Status_Id", Status_Id));

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
        public void Add_Osra_Data(string father_nat,
                         string address, string father_name, string father_last_name,
                         string father_moahel, string father_wazifa, string tel,
                         string father_mobil_1, string father_mobil_2, int father_hala,
                         string mother_nat, string mother_name,
                         string mother_moahel, string mother_wazifa,
                         string mother_mobil_1, string mother_mobil_2,
                         int mother_hala, string comments, int Osraa_Id)
        {
            DAL.ExecNonQuery("SP_Add_Osra_Data",
                SqlParam.NVar("@father_nat", father_nat, 14),
                SqlParam.NVar("@address", address, 100),
                SqlParam.NVar("@father_name", father_name, 40),
                SqlParam.NVar("@father_last_name", father_last_name, 12),
                SqlParam.NVar("@father_moahel", father_moahel, 50),
                SqlParam.NVar("@father_wazifa", father_wazifa, 50),
                SqlParam.NVar("@tel", tel, 7),
                SqlParam.NVar("@father_mobil_1", father_mobil_1, 11),
                SqlParam.NVar("@father_mobil_2", father_mobil_2, 11),
                SqlParam.Int("@father_hala", father_hala),
                SqlParam.NVar("@mother_nat", mother_nat, 14),
                SqlParam.NVar("@mother_name", mother_name, 50),
                SqlParam.NVar("@mother_moahel", mother_moahel, 50),
                SqlParam.NVar("@mother_wazifa", mother_wazifa, 50),
                SqlParam.NVar("@mother_mobil_1", mother_mobil_1, 11),
                SqlParam.NVar("@mother_mobil_2", mother_mobil_2, 11),
                SqlParam.Int("@mother_hala", mother_hala),
                SqlParam.NVar("@comments", comments, 250),
                SqlParam.Int("@Osraa_Id", Osraa_Id),
                SqlParam.NVar("@Created_by", Properties.Settings.Default.user_name, 15),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15)
            );
        }
        public void Update_Osra_Data(string father_nat,
                             string address, string father_name, string father_last_name,
                             string father_moahel, string father_wazifa, string tel,
                             string father_mobil_1, string father_mobil_2, int father_hala,
                             string mother_nat, string mother_name,
                             string mother_moahel, string mother_wazifa,
                             string mother_mobil_1, string mother_mobil_2,
                             int mother_hala, string comments, int Osraa_Id)
        {
            DAL.ExecNonQuery("SP_Update_Osra_Data",
                SqlParam.NVar("@father_nat", father_nat, 14),
                SqlParam.NVar("@address", address, 100),
                SqlParam.NVar("@father_name", father_name, 40),
                SqlParam.NVar("@father_last_name", father_last_name, 12),
                SqlParam.NVar("@father_moahel", father_moahel, 50),
                SqlParam.NVar("@father_wazifa", father_wazifa, 50),
                SqlParam.NVar("@tel", tel, 7),
                SqlParam.NVar("@father_mobil_1", father_mobil_1, 11),
                SqlParam.NVar("@father_mobil_2", father_mobil_2, 11),
                SqlParam.Int("@father_hala", father_hala),
                SqlParam.NVar("@mother_nat", mother_nat, 14),
                SqlParam.NVar("@mother_name", mother_name, 50),
                SqlParam.NVar("@mother_moahel", mother_moahel, 50),
                SqlParam.NVar("@mother_wazifa", mother_wazifa, 50),
                SqlParam.NVar("@mother_mobil_1", mother_mobil_1, 11),
                SqlParam.NVar("@mother_mobil_2", mother_mobil_2, 11),
                SqlParam.Int("@mother_hala", mother_hala),
                SqlParam.NVar("@comments", comments, 250),
                SqlParam.Int("@Osraa_Id", Osraa_Id),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15)
            );
        }
        public void Add_School_Std_Data(string std_code,
                                int Year_Id,
                                int Grade_Id,
                                int Std_Status_Id,
                                int Class_Id)
        {
            DAL.ExecNonQuery("SP_Add_School_Std_Data",
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Std_Status_Id", Std_Status_Id),
                SqlParam.Int("@Class_Id", Class_Id),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15)
            );
        }
        public void Update_School_Std_Data(string std_code,
                                   string std_name,
                                   string std_nat,
                                   DateTime std_date,
                                   int Grade_Id,
                                   int Std_Status_Id,
                                   int Class_Id,
                                   int Gender_Id,
                                   int Religion_Id,
                                   int Year_Id)
        {
            DAL.ExecNonQuery("SP_Update_School_Std_Data",
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.NVar("@std_name", std_name, 12),
                SqlParam.NVar("@std_nat", std_nat, 14),
                SqlParam.Date("@std_date", std_date),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Std_Status_Id", Std_Status_Id),
                SqlParam.Int("@Class_Id", Class_Id),
                SqlParam.Int("@Gender_Id", Gender_Id),
                SqlParam.Int("@Religion_Id", Religion_Id),
                SqlParam.Int("@Year_Id", Year_Id),
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
                               bool Trans_After_Year)
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
                SqlParam.Bit("@Trans_After_Year", Trans_After_Year)
            );
        }
        public DataTable GET_Code_Std_Grade(int Grade_Id, int Year_Id, string Is_Valied)
        {
            return DAL.ExecQuery("SP_GET_Code_Std_Grade",
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.NVar("@Is_Valied", Is_Valied, 5)
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
        public void Update_New_School_Std(string std_code,
                                   int Grade_Id,
                                   int Std_Status_Id,
                                   int Class_Id,
                                   int Year_Id)
        {
            DAL.ExecNonQuery("SP_Update_New_School_Std",
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Std_Status_Id", Std_Status_Id),
                SqlParam.Int("@Class_Id", Class_Id),
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15)
            );
        }
    }
}