using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL
{
    class Globals
    {


        private static bool _Test_Internet_Con;
        public static bool Test_Internet_Con
        {
            get
            {
                return _Test_Internet_Con;
            }
            set
            {
                _Test_Internet_Con = value;
            }
        }


        private static bool _Open_Form_Get_osra;
        public static bool Open_Form_Get_osra
        {
            get
            {
                return _Open_Form_Get_osra;
            }
            set
            {
                _Open_Form_Get_osra = value;
            }
        }

        private static bool _Add_Osra_Data_To_Student;
        public static bool Add_Osra_Data_To_Student
        {
            get
            {
                return _Add_Osra_Data_To_Student;
            }
            set
            {
                _Add_Osra_Data_To_Student = value;
            }
        }

        private static bool _Add_From_Get_Std;
        public static bool Add_From_Get_Std
        {
            get
            {
                return _Add_From_Get_Std;
            }
            set
            {
                _Add_From_Get_Std = value;
            }
        }

        private static bool _Update_Std_Data;
        public static bool Update_Std_Data
        {
            get
            {
                return _Update_Std_Data;
            }
            set
            {
                _Update_Std_Data = value;
            }
        }

        private static bool _Elthak_Std;
        public static bool Elthak_Std
        {
            get
            {
                return _Elthak_Std;
            }
            set
            {
                _Elthak_Std = value;
            }
        }

        private static bool _EditUser;
        public static bool EditUser
        {
            get
            {
                return _EditUser;
            }
            set
            {
                _EditUser = value;
            }
        }

        private static bool _Add_User_Permission;
        public static bool Add_User_Permission
        {
            get
            {
                return _Add_User_Permission;
            }
            set
            {
                _Add_User_Permission = value;
            }
        }

        private static bool _Current_Year_Data;
        public static bool Current_Year_Data
        {
            get
            {
                return _Current_Year_Data;
            }
            set
            {
                _Current_Year_Data = value;
            }
        }

        private static bool _Update_Taheewl;
        public static bool Update_Taheewl
        {
            get
            {
                return _Update_Taheewl;
            }
            set
            {
                _Update_Taheewl = value;
            }
        }

        private static bool _Taheewl_To_School;
        public static bool Taheewl_To_School
        {
            get
            {
                return _Taheewl_To_School;
            }
            set
            {
                _Taheewl_To_School = value;
            }
        }

        private static bool _Details_Std;
        public static bool Details_Std
        {
            get
            {
                return _Details_Std;
            }
            set
            {
                _Details_Std = value;
            }
        }

        private static bool _Restore_DataBase;
        public static bool Restore_DataBase
        {
            get
            {
                return _Restore_DataBase;
            }
            set
            {
                _Restore_DataBase = value;
            }
        }

    }
}
