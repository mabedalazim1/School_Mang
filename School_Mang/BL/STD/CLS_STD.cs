using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace School_Mang.BL.STD
{
    class CLS_STD
    {
        public DataTable Get_years()
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@year", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.MyYear;

            DataTable Dt;
            Dt = DAL.Selectdata("SP_GETYEARS", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_years(int year)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@year", SqlDbType.Int);
            param[0].Value = year;

            DataTable Dt;
            Dt = DAL.Selectdata("SP_GETYEARS", param);
            DAL.Close();
            return Dt;
        }
        public DataTable Get_genders()
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_GETGENDERS", null);
            DAL.Close();
            return Dt;
        }
        
         public DataTable Get_grades(string frist_classes = "no")
         {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@frist_classes", SqlDbType.VarChar,3);
            param[0].Value = frist_classes;
            Dt = DAL.Selectdata("SP_GETGRADES", param);
            DAL.Close();
            return Dt;
         }

        public DataTable Get_nationalities()
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_NATIONLITIES", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_stdStat()
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_STDSTAT", null);
            DAL.Close();
            return Dt;
        }
        
        public DataTable Get_religion()
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_RELIGIONS", null);
            DAL.Close();
            return Dt;
        }
        public DataTable Get_OSRA_STAT_FEMALE()
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_OSRA_STAT_FEMALE", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_OSRA_STAT_MALE()
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_OSRA_STAT_MALE", null);
            DAL.Close();
            return Dt;
        }


        public DataTable Get_Class_Id(int Grade_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[0].Value = Grade_Id;

            Dt = DAL.Selectdata("SP_Get_Class_Id", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Verify_Std_Nat( string std_nat,string std_code="0")
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@std_nat", SqlDbType.NVarChar, 14);
            param[0].Value = std_nat;

            param[1] = new SqlParameter("@std_code", SqlDbType.NVarChar, 20);
            param[1].Value = std_code;

            Dt = DAL.Selectdata("SP_Verify_Std_Nat", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Verify_Osra_Nat(string nat,int id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@nat", SqlDbType.NVarChar, 14);
            param[0].Value = nat;

            param[1] = new SqlParameter("@osra_Id", SqlDbType.Int);
            param[1].Value = id;

            Dt = DAL.Selectdata("SP_Verify_Osra_Nat", param);
            DAL.Close();
            return Dt;
        }
        public DataTable Get_All_Osra_Data()
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_Get_All_Osra_Data", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Search_Osra_Data(string osra_data)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@osra_data", SqlDbType.NVarChar, 100);
            param[0].Value = osra_data;

            Dt = DAL.Selectdata("SP_Search_Osra_Data", param);
            DAL.Close();
            return Dt;
        }

        public void Add_Std_Data(string std_code,
                                 string std_name, string std_nat, DateTime std_date,
                                 int Gender_Id,int Nationality_Id, int Religion_Id,
                                 int Std_Status_Id,int Grade_Id, int Year_Id,
                                 int Osraa_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[13];

            param[0] = new SqlParameter("@std_code", SqlDbType.NVarChar,20);
            param[0].Value = std_code;

            param[1] = new SqlParameter("@std_name", SqlDbType.NVarChar, 12);
            param[1].Value = std_name;

            param[2] = new SqlParameter("@std_nat", SqlDbType.NVarChar, 14);
            param[2].Value = std_nat;

            param[3] = new SqlParameter("@std_date", SqlDbType.Date);
            param[3].Value = std_date;

            param[4] = new SqlParameter("@Gender_Id", SqlDbType.Int);
            param[4].Value = Gender_Id;

            param[5] = new SqlParameter("@Nationality_Id", SqlDbType.Int);
            param[5].Value = Nationality_Id;

            param[6] = new SqlParameter("@Religion_Id", SqlDbType.Int);
            param[6].Value = Religion_Id;

            param[7] = new SqlParameter("@Std_Status_Id", SqlDbType.Int);
            param[7].Value = Std_Status_Id;

            param[8] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[8].Value = Grade_Id;

            param[9] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[9].Value = Year_Id;

            param[10] = new SqlParameter("@Osraa_Id", SqlDbType.Int);
            param[10].Value = Osraa_Id;

            param[11] = new SqlParameter("@Created_by", SqlDbType.NVarChar, 15);
            param[11].Value = Properties.Settings.Default.user_name;

            param[12] = new SqlParameter("@Updated_by", SqlDbType.NVarChar, 15);
            param[12].Value = Properties.Settings.Default.user_name;

            DAL.ExeucuteCommand("SP_Add_Std_Data", param);
        }

        public DataTable GET_Code_Std_Grade(int Grade_Id, int Year_Id, string Is_Valied)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[0].Value = Grade_Id;

            param[1] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[1].Value = Year_Id;

            param[2] = new SqlParameter("@Is_Valied", SqlDbType.NVarChar,5);
            param[2].Value = Is_Valied;

            Dt = DAL.Selectdata("SP_GET_Code_Std_Grade", param);
            DAL.Close();
            return Dt;
        }


        public DataTable Verify_Std_Code(string std_code)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@std_code", SqlDbType.NVarChar,20);
            param[0].Value = std_code;
            
            Dt = DAL.Selectdata("SP_Verify_Std_Code", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Verify_Osra_Code(string Year)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Year", SqlDbType.NVarChar, 2);
            param[0].Value = Year;

            Dt = DAL.Selectdata("SP_Verify_Osra_Code", param);
            DAL.Close();
            return Dt;
        }

        public void Add_Osra_Data(string father_nat,
                                 string address, string father_name, string father_last_name,
                                 string father_moahel, string father_wazifa, string tel,
                                 string father_mobil_1, string father_mobil_2, int father_hala,
                                 string @mother_nat, string mother_name,
                                 string mother_moahel, string mother_wazifa,
                                 string mother_mobil_1, string mother_mobil_2,
                                 int mother_hala, string comments, int Osraa_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[21];

            param[0] = new SqlParameter("@father_nat", SqlDbType.NVarChar, 14);
            param[0].Value = father_nat;

            param[1] = new SqlParameter("@address", SqlDbType.NVarChar, 100);
            param[1].Value = address;

            param[2] = new SqlParameter("@father_name", SqlDbType.NVarChar, 40);
            param[2].Value = father_name;

            param[3] = new SqlParameter("@father_last_name", SqlDbType.NVarChar, 12);
            param[3].Value = father_last_name;

            param[4] = new SqlParameter("@father_moahel", SqlDbType.NVarChar, 50);
            param[4].Value = father_moahel;

            param[5] = new SqlParameter("@father_wazifa", SqlDbType.NVarChar, 50);
            param[5].Value = father_wazifa;

            param[6] = new SqlParameter("@tel", SqlDbType.NVarChar, 7);
            param[6].Value = @tel;

            param[7] = new SqlParameter("@father_mobil_1", SqlDbType.NVarChar, 11);
            param[7].Value = father_mobil_1;

            param[8] = new SqlParameter("@father_mobil_2", SqlDbType.NVarChar, 11);
            param[8].Value = father_mobil_2;

            param[9] = new SqlParameter("@father_hala", SqlDbType.Int);
            param[9].Value = father_hala;

            param[10] = new SqlParameter("@mother_nat", SqlDbType.NVarChar, 14);
            param[10].Value = mother_nat;

            param[11] = new SqlParameter("@mother_name", SqlDbType.NVarChar, 50);
            param[11].Value = mother_name;

            param[12] = new SqlParameter("@mother_moahel", SqlDbType.NVarChar, 50);
            param[12].Value = mother_moahel;

            param[13] = new SqlParameter("@mother_wazifa", SqlDbType.NVarChar, 50);
            param[13].Value = mother_wazifa;

            param[14] = new SqlParameter("@mother_mobil_1", SqlDbType.NVarChar, 11);
            param[14].Value = mother_mobil_1;

            param[15] = new SqlParameter("@mother_mobil_2", SqlDbType.NVarChar, 11);
            param[15].Value = mother_mobil_2;

            param[16] = new SqlParameter("@mother_hala", SqlDbType.Int);
            param[16].Value = mother_hala;

            param[17] = new SqlParameter("@comments", SqlDbType.NVarChar, 250);
            param[17].Value = comments;

            param[18] = new SqlParameter("@Osraa_Id", SqlDbType.Int);
            param[18].Value = Osraa_Id;

            param[19] = new SqlParameter("@Created_by", SqlDbType.NVarChar, 15);
            param[19].Value = Properties.Settings.Default.user_name.ToString();

            param[20] = new SqlParameter("@Updated_by", SqlDbType.NVarChar, 15);
            param[20].Value = Properties.Settings.Default.user_name.ToString();

            DAL.ExeucuteCommand("SP_Add_Osra_Data", param);
        }

        public DataTable Get_osra_Data_ById(int Osraa_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Osraa_Id", SqlDbType.Int );
            param[0].Value = Osraa_Id;

            Dt = DAL.Selectdata("SP_Get_osra_Data_ById", param);
            DAL.Close();
            return Dt;
        }

        public void Update_Osra_Data(string father_nat,
                                 string address, string father_name, string father_last_name,
                                 string father_moahel, string father_wazifa, string tel,
                                 string father_mobil_1, string father_mobil_2, int father_hala,
                                 string @mother_nat, string mother_name,
                                 string mother_moahel, string mother_wazifa,
                                 string mother_mobil_1, string mother_mobil_2,
                                 int mother_hala, string comments, int Osraa_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@father_nat", SqlDbType.NVarChar, 14);
            param[0].Value = father_nat;

            param[1] = new SqlParameter("@address", SqlDbType.NVarChar, 100);
            param[1].Value = address;

            param[2] = new SqlParameter("@father_name", SqlDbType.NVarChar, 40);
            param[2].Value = father_name;

            param[3] = new SqlParameter("@father_last_name", SqlDbType.NVarChar, 12);
            param[3].Value = father_last_name;

            param[4] = new SqlParameter("@father_moahel", SqlDbType.NVarChar, 50);
            param[4].Value = father_moahel;

            param[5] = new SqlParameter("@father_wazifa", SqlDbType.NVarChar, 50);
            param[5].Value = father_wazifa;

            param[6] = new SqlParameter("@tel", SqlDbType.NVarChar, 7);
            param[6].Value = @tel;

            param[7] = new SqlParameter("@father_mobil_1", SqlDbType.NVarChar, 11);
            param[7].Value = father_mobil_1;

            param[8] = new SqlParameter("@father_mobil_2", SqlDbType.NVarChar, 11);
            param[8].Value = father_mobil_2;

            param[9] = new SqlParameter("@father_hala", SqlDbType.Int);
            param[9].Value = father_hala;

            param[10] = new SqlParameter("@mother_nat", SqlDbType.NVarChar, 14);
            param[10].Value = mother_nat;

            param[11] = new SqlParameter("@mother_name", SqlDbType.NVarChar, 50);
            param[11].Value = mother_name;

            param[12] = new SqlParameter("@mother_moahel", SqlDbType.NVarChar, 50);
            param[12].Value = mother_moahel;

            param[13] = new SqlParameter("@mother_wazifa", SqlDbType.NVarChar, 50);
            param[13].Value = mother_wazifa;

            param[14] = new SqlParameter("@mother_mobil_1", SqlDbType.NVarChar, 11);
            param[14].Value = mother_mobil_1;

            param[15] = new SqlParameter("@mother_mobil_2", SqlDbType.NVarChar, 11);
            param[15].Value = mother_mobil_2;

            param[16] = new SqlParameter("@mother_hala", SqlDbType.Int);
            param[16].Value = mother_hala;

            param[17] = new SqlParameter("@comments", SqlDbType.NVarChar, 250);
            param[17].Value = comments;

            param[18] = new SqlParameter("@Osraa_Id", SqlDbType.Int);
            param[18].Value = Osraa_Id;


            param[19] = new SqlParameter("@Updated_by", SqlDbType.NVarChar, 15);
            param[19].Value = Properties.Settings.Default.user_name;

            DAL.ExeucuteCommand("SP_Update_Osra_Data", param);
        }

        public DataTable Verify_Osra_Data(int Osraa_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@Osraa_Id", SqlDbType.Int);
            param[0].Value = Osraa_Id;


            Dt = DAL.Selectdata("SP_Verify_Osra_Data", param);
            DAL.Close();
            return Dt;
        }

        public void Delele_Osra_Data( int Osra_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@Osra_Id", SqlDbType.Int);
            param[0].Value = Osra_Id;

           
            DAL.Open();
            DAL.ExeucuteCommand("SP_Delele_Osra_Data", param);
            DAL.Close();
        }

        public DataTable Get_All_Std_Data(int Year_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[0].Value = Year_Id;

            Dt = DAL.Selectdata("SP_Get_All_Std_Data", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Search_Std_Data(string std_data, int Year_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@std_data", SqlDbType.NVarChar, 100);
            param[0].Value = std_data;

            param[1] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[1].Value = Year_Id;

            Dt = DAL.Selectdata("SP_Search_Std_Data", param);
            DAL.Close();
            return Dt;
        }

        public void Update_Std_Data(string std_code,
                                string std_name, string std_nat, DateTime std_date,
                                int Gender_Id, int Nationality_Id, int Religion_Id,
                                int Std_Status_Id, int Grade_Id, int Year_Id,
                                int Osraa_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[12];

            param[0] = new SqlParameter("@std_code", SqlDbType.NVarChar, 20);
            param[0].Value = std_code;

            param[1] = new SqlParameter("@std_name", SqlDbType.NVarChar, 12);
            param[1].Value = std_name;

            param[2] = new SqlParameter("@std_nat", SqlDbType.NVarChar, 14);
            param[2].Value = std_nat;

            param[3] = new SqlParameter("@std_date", SqlDbType.Date);
            param[3].Value = std_date;

            param[4] = new SqlParameter("@Gender_Id", SqlDbType.Int);
            param[4].Value = Gender_Id;

            param[5] = new SqlParameter("@Nationality_Id", SqlDbType.Int);
            param[5].Value = Nationality_Id;

            param[6] = new SqlParameter("@Religion_Id", SqlDbType.Int);
            param[6].Value = Religion_Id;

            param[7] = new SqlParameter("@Std_Status_Id", SqlDbType.Int);
            param[7].Value = Std_Status_Id;

            param[8] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[8].Value = Grade_Id;

            param[9] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[9].Value = Year_Id;

            param[10] = new SqlParameter("@Osraa_Id", SqlDbType.Int);
            param[10].Value = Osraa_Id;

            param[11] = new SqlParameter("@Updated_by", SqlDbType.NVarChar, 15);
            param[11].Value = Properties.Settings.Default.user_name;

            DAL.ExeucuteCommand("SP_Update_Std_Data", param);
        }

        public void Delele_Std_Data(string std_code)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@std_code", SqlDbType.NVarChar,20);
            param[0].Value = std_code;


            DAL.Open();
            DAL.ExeucuteCommand("SP_Delele_Std_Data", param);
            DAL.Close();
        }

        public void Add_School_Std_Data(string std_code,
                                        int Year_Id,
                                        int Grade_Id, 
                                        int Std_Status_Id,
                                        int Class_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@std_code", SqlDbType.NVarChar, 20);
            param[0].Value = std_code;

            param[1] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[1].Value = Year_Id;

            param[2] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[2].Value = Grade_Id;

            param[3] = new SqlParameter("@Std_Status_Id", SqlDbType.Int);
            param[3].Value = Std_Status_Id;

            param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
            param[4].Value = Class_Id;

            param[5] = new SqlParameter("@Updated_by", SqlDbType.NVarChar, 15);
            param[5].Value = Properties.Settings.Default.user_name;

            DAL.ExeucuteCommand("SP_Add_School_Std_Data", param);
        }

        public DataTable Get_School_year_Data(int Year_Id, int Grade_Id, int Class_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[0].Value = Year_Id;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
            param[2].Value = Class_Id;

            Dt = DAL.Selectdata("SP_Get_School_year_Data", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Search_School_year_Data(int Year_Id, int Grade_Id,
                                                 int Class_Id , string std_name)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[0].Value = Year_Id;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
            param[2].Value = Class_Id;

            param[3] = new SqlParameter("@std_name", SqlDbType.NVarChar,200);
            param[3].Value = std_name;

            Dt = DAL.Selectdata("SP_Search_School_year_Data", param);
            DAL.Close();
            return Dt;
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
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[11];

            param[0] = new SqlParameter("@std_code", SqlDbType.NVarChar, 20);
            param[0].Value = std_code;

            param[1] = new SqlParameter("@std_name", SqlDbType.NVarChar, 12);
            param[1].Value = std_name;

            param[2] = new SqlParameter("@std_nat", SqlDbType.NVarChar, 14);
            param[2].Value = std_nat;

            param[3] = new SqlParameter("@std_date", SqlDbType.Date);
            param[3].Value = std_date;


            param[4] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[4].Value = Grade_Id;

            param[5] = new SqlParameter("@Std_Status_Id", SqlDbType.Int);
            param[5].Value = Std_Status_Id;

            param[6] = new SqlParameter("@Class_Id", SqlDbType.Int);
            param[6].Value = Class_Id;

            param[7] = new SqlParameter("@Gender_Id", SqlDbType.Int);
            param[7].Value = Gender_Id;

            param[8] = new SqlParameter("@Religion_Id", SqlDbType.Int);
            param[8].Value = Religion_Id;

            param[9] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[9].Value = Year_Id;

            param[10] = new SqlParameter("@Updated_by", SqlDbType.NVarChar, 15);
            param[10].Value = Properties.Settings.Default.user_name;


            DAL.Open();
            DAL.ExeucuteCommand("SP_Update_School_Std_Data", param);
            DAL.Close();
        }

        public void Delete_School_Std_Data(string std_code,
                                          int Year_Id)
                                          
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@std_code", SqlDbType.NVarChar, 20);
            param[0].Value = std_code;

            param[1] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[1].Value = Year_Id;


            DAL.Open();
            DAL.ExeucuteCommand("SP_Delete_School_Std_Data", param);
            DAL.Close();
        }

        public void Add_Transfers_Data(string Transfer_code,
                                          string std_code,
                                          string Transfer_School,
                                          int Transfer_status,
                                          int Year_Id,
                                          string Guardian_name,
                                          string Transfer_reason,
                                          byte Resom , byte Kotob,
                                          string adrs , int New_Grade,
                                          bool Trans_After_Year)

        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[14];

            param[0] = new SqlParameter("@Transfer_code", SqlDbType.NVarChar, 20);
            param[0].Value = Transfer_code;

            param[1] = new SqlParameter("@std_code", SqlDbType.NVarChar, 20);
            param[1].Value = std_code;

            param[2] = new SqlParameter("@Transfer_School", SqlDbType.NVarChar, 100);
            param[2].Value = Transfer_School;

            param[3] = new SqlParameter("@Transfer_status", SqlDbType.Int);
            param[3].Value = Transfer_status;

            param[4] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[4].Value = Year_Id;

            param[5] = new SqlParameter("@Guardian_name", SqlDbType.NVarChar, 50);
            param[5].Value = Guardian_name;

            param[6] = new SqlParameter("@Transfer_reason", SqlDbType.NVarChar, 50);
            param[6].Value = Transfer_reason;

            param[7] = new SqlParameter("@Resom", SqlDbType.Bit);
            param[7].Value = Resom;

            param[8] = new SqlParameter("@Kotob", SqlDbType.Bit);
            param[8].Value = Kotob;

            param[9] = new SqlParameter("@adrs", SqlDbType.NVarChar, 1000);
            param[9].Value = adrs;

            param[10] = new SqlParameter("@Created_by", SqlDbType.NVarChar, 15);
            param[10].Value = Properties.Settings.Default.user_name;

            param[11] = new SqlParameter("@Updated_by", SqlDbType.NVarChar, 15);
            param[11].Value = Properties.Settings.Default.user_name;

            param[12] = new SqlParameter("@New_Grade", SqlDbType.Int);
            param[12].Value = New_Grade;

            param[13] = new SqlParameter("@Trans_After_Year", SqlDbType.Bit);
            param[13].Value = Trans_After_Year;

            DAL.Open();
            DAL.ExeucuteCommand("SP_Add_Transfers_Data", param);
            DAL.Close();
        }

        // Read Trans_Code From databasse

        public DataTable Get_Trans_Code(string year)
        {
            SqlParameter[] param = new SqlParameter[1];
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            DataTable Dt;

            param[0] = new SqlParameter("@year", SqlDbType.NVarChar, 2);
            param[0].Value = year;

            Dt = DAL.Selectdata("SP_Get_Trans_Code", param);
            DAL.Close();
            return Dt;

        }

        public DataTable GET_Trans_Data(int Grade_Id,int Status_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            
            SqlParameter[] param = new SqlParameter[3];

            if(Status_Id == 3)
            {
                param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
                param[0].Value = Convert.ToInt32(Globals.My_Year -1);
                
            }
            else
            {
                param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
                param[0].Value = Convert.ToInt32(Globals.My_Year);
            }

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
            param[2].Value = Status_Id;

            Dt = DAL.Selectdata("SP_GET_Trans_Data", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Search_Trans_Data(int Grade_Id,
                                           int Status_Id, 
                                           string std_name)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[4];
            if (Status_Id == 3)
            {
                param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
                param[0].Value = Convert.ToInt32(Globals.My_Year)-1;
            }
            else
            {
                param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
                param[0].Value = Convert.ToInt32(Globals.My_Year) ;
            }

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
            param[2].Value = Status_Id;

            param[3] = new SqlParameter("@std_name", SqlDbType.NVarChar, 200);
            param[3].Value = std_name;

            Dt = DAL.Selectdata("SP_Search_Trans_Data", param);
            DAL.Close();
            return Dt;
        }

        public void Update_Trans_Data(   int Transfer_code,
                                         string Transfer_School,
                                         string Guardian_name,
                                         string Transfer_reason,
                                         byte Resom, byte Kotob,
                                         string adrs)

        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@Transfer_code", SqlDbType.Int);
            param[0].Value = Transfer_code;

            param[1] = new SqlParameter("@Transfer_School", SqlDbType.NVarChar, 100);
            param[1].Value = Transfer_School;

            param[2] = new SqlParameter("@Guardian_name", SqlDbType.NVarChar, 50);
            param[2].Value = Guardian_name;

            param[3] = new SqlParameter("@Transfer_reason", SqlDbType.NVarChar, 50);
            param[3].Value = Transfer_reason;

            param[4] = new SqlParameter("@Resom", SqlDbType.Bit);
            param[4].Value = Resom;

            param[5] = new SqlParameter("@Kotob", SqlDbType.Bit);
            param[5].Value = Kotob;

            param[6] = new SqlParameter("@adrs", SqlDbType.NVarChar, 1000);
            param[6].Value = adrs;

            param[7] = new SqlParameter("@Updated_by", SqlDbType.NVarChar, 15);
            param[7].Value = Properties.Settings.Default.user_name;


            DAL.Open();
            DAL.ExeucuteCommand("SP_Update_Trans_Data", param);
            DAL.Close();
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
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Transfer_code", SqlDbType.Int);
            param[0].Value = Transfer_code;

            param[1] = new SqlParameter("@std_code", SqlDbType.NVarChar, 20);
            param[1].Value = std_code;

            param[2] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[2].Value = Year_Id;

            param[3] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[3].Value = Grade_Id;

            param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
            param[4].Value = Class_Id;

            param[5] = new SqlParameter("@Updated_by", SqlDbType.NVarChar, 15);
            param[5].Value = Properties.Settings.Default.user_name;

            param[6] = new SqlParameter("@new_year", SqlDbType.Int);
            param[6].Value = new_year;

            param[7] = new SqlParameter("@std_found", SqlDbType.Int);
            param[7].Value = std_found;

            param[8] = new SqlParameter("@To_School", SqlDbType.Int);
            param[8].Value = To_School;

            param[9] = new SqlParameter("@Trans_After_Year", SqlDbType.Bit);
            param[9].Value = Trans_After_Year;

            DAL.Open();
            DAL.ExeucuteCommand("SP_Delete_Transfers_Data", param);
            DAL.Close();
        }

        public DataTable Get_Count_New_Year(int new_year)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
          
            string query = @"select COUNT(std_code) as std_code from School_Std_Data
                             where Year_Id = " + new_year +" ;";
            Dt = DAL.ReadData_Query(query, null);
            DAL.Close();
            return Dt;

        }

        public DataTable Get_Count_Trans_Std(int new_year, string std_code)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            string query = @"select COUNT(std_code) as std_code
                            from School_Std_Data where Year_Id = " +
                            new_year + "and std_code =" + std_code + " ;";
                           

            Dt = DAL.ReadData_Query(query, null);
            DAL.Close();
            return Dt;

        }

        public DataTable Verify_Std_School_Code(string std_code,int Year_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[2];
           

            param[0] = new SqlParameter("@std_code", SqlDbType.NVarChar, 20);
            param[0].Value = std_code;

            param[1] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[1].Value = Year_Id;


            Dt = DAL.Selectdata("SP_Verify_Std_School_Code", param);
            DAL.Close();
            return Dt;
        }

        public void Update_New_School_Std(string std_code,
                                         int Grade_Id,
                                         int Std_Status_Id,
                                         int Class_Id,
                                         int Year_Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@std_code", SqlDbType.NVarChar,20);
            param[0].Value = std_code;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            param[2] = new SqlParameter("@Std_Status_Id", SqlDbType.Int);
            param[2].Value = Std_Status_Id;

            param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
            param[3].Value = Class_Id;

            param[4] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[4].Value = Year_Id;

            param[5] = new SqlParameter("@Updated_by", SqlDbType.NVarChar, 15);
            param[5].Value = Properties.Settings.Default.user_name;

           
            DAL.Open();
            DAL.ExeucuteCommand("SP_Update_New_School_Std", param);
            DAL.Close();
        }
        public DataTable Get_Year_Desc(int year)
        {

            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@year", SqlDbType.Int);
            param[0].Value = year;

            Dt = DAL.Selectdata("SP_Get_Year_Desc", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Grade_Desc(int grade_id)
        {

            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@grade_id", SqlDbType.Int);
            param[0].Value = grade_id;

            Dt = DAL.Selectdata("SP_Get_Grade_Desc", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Kaema_Data(int year_id, int grade_id)
        {

            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@year_id", SqlDbType.Int);
            param[0].Value = year_id;

            param[1] = new SqlParameter("@grade_id", SqlDbType.Int);
            param[1].Value = grade_id;

            Dt = DAL.Selectdata("SP_Get_Kaema_Data", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Segel_Data(int year_id,int grade_id = 0)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            int October_Sana = year_id + 20;

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@year_id", SqlDbType.Int);
            param[0].Value = year_id;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = grade_id;

            param[2] = new SqlParameter("@October_Sana", SqlDbType.Int);
            param[2].Value = October_Sana;

            Dt = DAL.Selectdata("SP_Get_Segel_Data", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Tadrg_Sen(int year_id, int grade_id =0)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            int October_Sana = year_id + 20;

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@year_id", SqlDbType.Int);
            param[0].Value = year_id;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = grade_id;

            param[2] = new SqlParameter("@October_Sana", SqlDbType.Int);
            param[2].Value = October_Sana;

            Dt = DAL.Selectdata("SP_Get_Tadrg_Sen", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Trans_Reports(int Year_Id, int Status_Id ,int Grade_Id = 0)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[0].Value = Year_Id;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
            param[2].Value = Status_Id;

            Dt = DAL.Selectdata("SP_GET_Trans_Data", param);
            DAL.Close();
            return Dt;
        }

        public DataTable GET_Trans_By_Code(string std_code)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@std_code", SqlDbType.NVarChar,20);
            param[0].Value = std_code;

            Dt = DAL.Selectdata("SP_GET_Trans_By_Code", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Tahewl_Data(string Transfer_code)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Transfer_code", SqlDbType.NVarChar, 20);
            param[0].Value = Transfer_code;

            Dt = DAL.Selectdata("SP_Get_Tahewl", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Data_For_Site(int Grade_Id = 0, int Golos = 0)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@Golos", SqlDbType.Int);
            param[1].Value = Golos;
            
            param[2] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[2].Value = Grade_Id;

            param[3] = new SqlParameter("@stdunet_full_name", SqlDbType.NVarChar,255);
            param[3].Value = "";

            param[4] = new SqlParameter("@search", SqlDbType.Bit);
            param[4].Value = false;

            DataTable Dt;
            Dt = DAL.Selectdata("SP_Get_Data_For_Site", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Data_For_Site(int Grade_Id, string stdunet_full_name)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@Golos", SqlDbType.Int);
            param[1].Value = 0;

            param[2] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[2].Value = Grade_Id;

            param[3] = new SqlParameter("@stdunet_full_name", SqlDbType.NVarChar, 255);
            param[3].Value = stdunet_full_name;

            param[4] = new SqlParameter("@search", SqlDbType.Bit);
            param[4].Value = true;

            DataTable Dt;
            Dt = DAL.Selectdata("SP_Get_Data_For_Site", param);
            DAL.Close();
            return Dt;
        }
    }
}
