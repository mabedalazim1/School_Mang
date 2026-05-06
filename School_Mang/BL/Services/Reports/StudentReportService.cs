using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.Reports
{
    public class StudentReportService
    {
        private readonly RPT.REPORT_CONNECTION _rpt = new RPT.REPORT_CONNECTION();

        public void OpenDegreeStatement(int year, int gradeId, string stdCode)
        {
            _rpt.OpenDegree_Statement(year, gradeId, stdCode);
        }
    }
}