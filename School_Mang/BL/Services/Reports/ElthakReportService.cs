using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.Reports
{
    public class ElthakReportService
    {
        private readonly StudentService _studentService = new StudentService();
        private readonly RPT.REPORT_CONNECTION _rpt = new RPT.REPORT_CONNECTION();

        public void OpenElthakReport(int grade,
                                     string grade_desc,
                                     string std_code,
                                     string std_name,
                                     string std_nat,
                                     int stdYear,
                                     int newYear,
                                     bool nextYearElthak)
        {
            string new_grade_desc ="";
            int sana = stdYear;
            string year_desc = "";

            if (nextYearElthak == true)
            {
               
                switch (grade)
                {
                    case 11:
                        sana = newYear;
                        year_desc = _studentService.GetYearName(sana + 1);
                        new_grade_desc = "الصف الأول الإبتدائي";
                        break;

                    case 6:
                        sana = newYear;
                        year_desc = _studentService.GetYearName(sana + 1);
                        new_grade_desc = "الصف الأول الإعدادي";
                        break;
                }
            }


            // Get Old Std Data
            switch (grade)
            {
                case 1:
                case 7:
                    sana = newYear -1;
                    year_desc = _studentService.GetYearName(sana + 1);
                    new_grade_desc = grade_desc;
                    break;
            }

       
            _rpt.OpenElthakReport(std_code, std_name, std_nat, sana, year_desc, new_grade_desc);
        }
    }
}
