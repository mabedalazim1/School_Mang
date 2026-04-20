using School_Mang.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL
{
    public static class Globals
    {

        public static AppSession Current = new AppSession();

        public static bool Test_Internet_Con
        {
            get => Current.Test_Internet_Con;
            set => Current.Test_Internet_Con = value;
        }

        public static bool Open_Form_Get_osra
        {
            get => Current.Open_Form_Get_osra;
            set => Current.Open_Form_Get_osra = value;
        }

        public static bool EditUser
        {
            get => Current.EditUser;
            set => Current.EditUser = value;
        }

        public static bool Add_User_Permission
        {
            get => Current.Add_User_Permission;
            set => Current.Add_User_Permission = value;
        }

       
        public static bool Restore_DataBase
        {
            get => Current.Restore_DataBase;
            set => Current.Restore_DataBase = value;
        }

      
        public static byte My_Year
        {
            get => Current.My_Year;
            set => Current.My_Year = value;
        }

        public static bool Koshof_Rasd
        {
            get => Current.Koshof_Rasd;
            set => Current.Koshof_Rasd = value;
        }

        public static string accessToken
        {
            get => Current.accessToken;
            set => Current.accessToken = value;
        }

        public static HttpContent Http_Content
        {
            get => Current.Http_Content;
            set => Current.Http_Content = value;
        }

        public static int test_kind
        {
            get => Current.test_kind;
            set => Current.test_kind = value;
        }

        public static int test_month
        {
            get => Current.test_month;
            set => Current.test_month = value;
        }

        public static string test_month_name
        {
            get => Current.test_month_name;
            set => Current.test_month_name = value;
        }

        public static int test_grade_id
        {
            get => Current.test_grade_id;
            set => Current.test_grade_id = value;
        }

        public static bool Amal_Sana
        {
            get => Current.Amal_Sana;
            set => Current.Amal_Sana = value;
        }

        public static bool Final_Test
        {
            get => Current.Final_Test;
            set => Current.Final_Test = value;
        }

        public static int Std_Golos
        {
            get => Current.Std_Golos;
            set => Current.Std_Golos = value;
        }

        public static string Final_Test_Name
        {
            get => Current.Final_Test_Name;
            set => Current.Final_Test_Name = value;
        }

        public static byte Final_Test_Kind
        {
            get => Current.Final_Test_Kind;
            set => Current.Final_Test_Kind = value;
        }

        public static bool Final_Nataga
        {
            get => Current.Final_Nataga;
            set => Current.Final_Nataga = value;
        }

        public static bool Final_Koshof
        {
            get => Current.Final_Koshof;
            set => Current.Final_Koshof = value;
        }

        public static string Dir_Path
        {
            get => Current.Dir_Path;
            set => Current.Dir_Path = value;
        }

        public static bool Edit_Golos
        {
            get => Current.Edit_Golos;
            set => Current.Edit_Golos = value;
        }

        public static bool Get_Site_Data
        {
            get => Current.Get_Site_Data;
            set => Current.Get_Site_Data = value;
        }

        public static bool From_Un_Matched
        {
            get => Current.From_Un_Matched;
            set => Current.From_Un_Matched = value;
        }

        public static bool Get_User_Data
        {
            get => Current.Get_User_Data;
            set => Current.Get_User_Data = value;
        }

        public static bool Del_Assessment_Data
        {
            get => Current.Del_Assessment_Data;
            set => Current.Del_Assessment_Data = value;
        }
    }
}


