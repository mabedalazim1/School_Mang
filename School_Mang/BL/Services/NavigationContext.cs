using DevExpress.XtraReports.Wizards;
using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services
{
    
    public class NavigationContext
    {

        public  ReportDataType CurrentReport { get; set; }
        public GetOsraMode OsraMode { get; set; }
        public GetStudentMode StudentMode { get; set; }
        public GetStudentCase StudentCase { get; set; }

        public StudentDTO StudentData { get; set; }
        public Action PostAction { get; set; }

        public int Year { get; set; }
        public bool CurrentYearData { get; set; }

    }
}
