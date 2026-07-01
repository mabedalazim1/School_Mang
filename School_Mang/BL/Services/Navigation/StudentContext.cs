using School_Mang.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.Navigation
{
    public class StudentContext
    {
        public int? StudentId { get; set; }
        public bool AddNewStudent { get; set; }
        public bool OpenFromGetStd { get; set; }
        public bool AddFromGetStd { get; set; }
        public bool OpenFromAddstudent { get; set; }
        public bool EditStudent { get; set; }
        public bool UpdateStdData { get; set; }
        public bool Get_User_Data { get; set; }
    }
}
