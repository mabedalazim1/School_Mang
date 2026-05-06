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
        public DataTable GetStudentsByYear(int year, int gradeId, int classId)
        {
            return _std.Get_School_year_Data(year, gradeId, classId);
        }
        public DataTable GetGradeData(int gradeId)
        {
            return _std.Get_Grad_Data(gradeId);
        }
        public DataTable SearchSchoolyearData(int year,
                                              int grade,
                                              int classId,
                                              string name)
        {
            return _std.Search_School_year_Data(year, grade, classId, name);
        }

        public void DeleteSchoolStdData(string stdCode, int year)
        {
            _std.Delete_School_Std_Data(stdCode, year);
        }
    }
}