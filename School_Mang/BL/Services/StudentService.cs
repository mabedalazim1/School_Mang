using System;
using System.Data;

namespace School_Mang.BL.Services
{
    public class StudentService
    {
        private readonly BL.STD.CLS_STD _std;

        public StudentService()
        {
            _std = new BL.STD.CLS_STD();
        }

        public string GetYearName(int year)
        {
            var dt = _std.Get_years(year);
            return dt.Rows[0][1].ToString();
        }

        public bool HasStudentsInYear(int yearCode)
        {
            var dt = _std.Get_School_year_Data(yearCode, 0, 0);
            return dt.Rows.Count > 0;
        }
        public DataTable GetYears(int year)
        {
            return _std.Get_years(year);
        }

        public DataTable GetSchoolYearData(int yearCode, int p1, int p2)
        {
            return _std.Get_School_year_Data(yearCode, p1, p2);
        }

    }
}