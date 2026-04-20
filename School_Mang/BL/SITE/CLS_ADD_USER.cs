using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Mang.BL.Common.Helper;


namespace School_Mang.BL.SITE
{
    public class CLS_ADD_USER
    {
        STD.CLS_STD std = new STD.CLS_STD();
        CLS_MANGE_SITE site = new CLS_MANGE_SITE();

        int year = Properties.Settings.Default.year_cod;
        DataTable Dt_std_data;
        DataTable Dt_user_table_data;
        DataTable Dt_user_name = new DataTable();
        DataColumn dc = new DataColumn("user_name", typeof(String));

        public CLS_ADD_USER()
        {
            // Get Student Data From local DataBase
            Dt_std_data = std.Get_Data_For_Site();

            // Get users Data From server DataBase
            Dt_user_table_data = site.Get_User_Table_Data();

            Dt_user_name.Columns.Add(dc);
        }
        

        private string Generate_letter(int filed)
        {
            string letter = "";

            switch (filed)
            {
                case 0:
                    letter = "k";
                    break;
                case 1:
                    letter = "j";
                    break;
                case 2:
                    letter = "h";
                    break;
                case 3:
                    letter = "g";
                    break;
                case 4:
                    letter = "f";
                    break;
                case 5:
                    letter = "e";
                    break;
                case 6:
                    letter = "d";
                    break;
                case 7:
                    letter = "c";
                    break;
                case 8:
                    letter = "b";
                    break;
                case 9:
                    letter = "a";
                    break;

            }
            return letter;

        }

        // Generate Letters From No
        private string  Generate_User_name(string std_nat, int filed1,int filed2)
        {
            string pass = std_nat.Substring(std_nat.Length - 4);
            string user_name = "";


            user_name = Generate_letter(filed1)
                + Generate_letter(filed2)
                + pass;

            return user_name;
        }
        // Generate Student Code

        private void Generate_Code(string std_nat, int Golos)
        {
            string std_golos = Golos.ToString();

            string pass = std_nat.Substring(std_nat.Length - 4);

            // Get User Name From Golos And Nat_No
            string field_tow_no = std_golos.Substring(std_golos.Length - 2);
            string field1 = field_tow_no.Substring(field_tow_no.Length - 1);
            string field2 = field_tow_no.Substring(0 , 1);

           string user_name =  Generate_User_name(
               std_nat,
               Convert.ToInt32(field1), 
               Convert.ToInt32(field2));
            MSG.MyMesg("user name is : " + user_name);

        }

        private string Generate_Code_String(int Golos)
        {
            var std_nat = Dt_std_data.AsEnumerable()
                        .Where(row => row.Field<int>("Golos") == Golos)
                        .Select(row => row.Field<string>("std_nat"))
                        .FirstOrDefault();

            var std_code = Dt_std_data.AsEnumerable()
                     .Where(row => row.Field<int>("Golos") == Golos)
                     .Select(row => row.Field<string>("std_code"))
                     .FirstOrDefault();
            string std_golos = Golos.ToString();

            // Get User Name From Golos And Nat_No
            string field_tow_no = std_golos.Substring(std_golos.Length - 2);
            string field1 = field_tow_no.Substring(field_tow_no.Length - 1);
            string field2 = field_tow_no.Substring(0, 1);

            string user_name = Generate_User_name(
                std_nat,
                Convert.ToInt32(field1),
                Convert.ToInt32(field2));
           return user_name;

        }

        public async void Get_User_Data(int Golos)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

                if (Golos != 0)
            {
                var std_nat = Dt_std_data.AsEnumerable()
                         .Where(row => row.Field<int>("Golos") == Golos)
                         .Select(row => row.Field<string>("std_nat"))
                         .FirstOrDefault();

                var std_code = Dt_std_data.AsEnumerable()
                         .Where(row => row.Field<int>("Golos") == Golos)
                         .Select(row => row.Field<string>("std_code"))
                         .FirstOrDefault();

                int code = 0;
                if (std_code != null)
                {
                    code = Convert.ToInt32(std_code);
                    if (std_nat != null)
                    {
                        Generate_Code(std_nat, code);
                    }
                }
                else
                {
                    MSG.ErrorMesg("لا يوجد طالب يرجي التأكد من رقم الجلوس ..!");
                }
            }

        }

        // Test
        public void Get_Dublcate_Data(DataTable Dt, string filed_name)
        {

            var allDuplicates = Dt.AsEnumerable()
                                .GroupBy(dr => dr.Field<string>(filed_name))
                                .Where(g => g.Count() > 1)
                                .SelectMany(g => g)
                                .ToList();

            MSG.MyMesg("عدد " + filed_name + " المكرر..! : " + allDuplicates.Count.ToString());

            foreach (var item in allDuplicates)
            {
                MSG.MyMesg(item.Field<string>(filed_name).ToString());
            }
        }

       
   
        public async void Update_Site_Data()
        {
            if (!await InternetFlow.EnsureAsync())
                return;


            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(Dt_user_table_data);
            int Golos;
            string std_code;
            Waiting.Start();
            foreach (DataRow std in Dt_std_data.Rows)
            {
                std_code = std["std_code"].ToString();
                if (std["Golos"] != null)
                {
                     Golos = Convert.ToInt32(std["Golos"]);
                }
                else
                {
                    Golos = 0;
                }

                var foundRow = Dt_user_table_data.AsEnumerable().Where(r => r["stdCode"].ToString() == std_code).FirstOrDefault();
                if (foundRow != null)
                {
                   site. Update_User_stdCode(std_code,Golos);
                }
                //site.Update_User_stdCode(std_code, Golos);
                }
            Waiting.Stop();
            MSG.MyMesg("تم تحديث البيانات ..!");
        }
    }
}
