using Microsoft.Office.Interop.Excel;
using School_Mang.BL.STD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace School_Mang.BL.Services.STD
{
    public class StudentUpdateService
    {
        private readonly CLS_STD _std;
        private readonly StudentCodeService _codeService;

        public StudentUpdateService()
        {
            _std = new CLS_STD();
            _codeService = new StudentCodeService();
        }
  
        public void UpdateStudentData(
                                string code,
                                string name,
                                string nat,
                                int type,
                                int nationality,
                                int religion,
                                int status,
                                int grade,
                                int yearId,
                                int osraId)
        {
            int year = SchoolYearService.GetCalculationYear(yearId);

            var sen = AgeService.NatAgeHesabSen(nat, year);
            DateTime tarikh = Convert.ToDateTime(sen.BirthDate);
            // Update Std Data 
            _std.Update_Std_Data(
                code,
                name,
                nat,
                tarikh,
                type,
                nationality,
                religion,
                status,
                grade,
                yearId,
                osraId
            );
        }
    }
}
