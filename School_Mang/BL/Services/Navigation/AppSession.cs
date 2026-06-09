using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services
{
    public class AppSession
    {
        public bool Test_Internet_Con { get; set; }

        public bool EditUser { get; set; }
        public bool Add_User_Permission { get; set; }

        public bool Restore_DataBase { get; set; }

        public byte My_Year { get; set; }

        public bool Koshof_Rasd { get; set; }

        public string accessToken { get; set; }

        public HttpContent Http_Content { get; set; }

        public int test_kind { get; set; }
        public int test_month { get; set; }
        public string test_month_name { get; set; }
        public int test_grade_id { get; set; }

        public bool Amal_Sana { get; set; }
        public bool Final_Test { get; set; }

        public int Std_Golos { get; set; }

        public string Final_Test_Name { get; set; }
        public byte Final_Test_Kind { get; set; }

        public bool Final_Nataga { get; set; }
        public bool Final_Koshof { get; set; }

        public string Dir_Path { get; set; } = "";

        public bool Edit_Golos { get; set; }

        public bool Get_Site_Data { get; set; }
        public bool From_Un_Matched { get; set; }
        public bool Get_User_Data { get; set; }
        public bool Del_Assessment_Data { get; set; }
        public bool AhsaaEdara { get; set; }
    }
}
