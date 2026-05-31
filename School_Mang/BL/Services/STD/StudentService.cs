using System;
using System.Data;
using School_Mang.BL.Services.STD;
using School_Mang.DAL;

namespace School_Mang.BL.Services
{
    public class StudentService
    {
        private readonly GetDataService _getData;
        private readonly StudentDataService _studentData;
        private readonly LookupService _stdData;
        private readonly DataAcceseLayer _dal;

        public StudentService()
        {
            _getData = new GetDataService();
            _dal = new DataAcceseLayer();
            _studentData = new StudentDataService();
            _stdData = new LookupService();
        }

        public string GetYearName(int year)
        {
            var dt = Get_years(year);
            return dt.Rows[0][1].ToString();
        }

        public bool HasStudentsInYear(int yearCode)
        {
            var dt = Get_School_year_Data(yearCode, 0, 0);
            return dt.Rows.Count > 0;
        }
        public DataTable GetSchoolYearData(int yearCode, int p1, int p2)
        {
            return Get_School_year_Data(yearCode, p1, p2);
        }
        public DataTable GetStudentsByYear(int year, int gradeId, int classId)
        {
            return Get_School_year_Data(year, gradeId, classId);
        }
        public DataTable GetGradeData(int gradeId)
        {
            return _stdData.Get_Grad_Data(gradeId);
        }
        public DataTable SearchSchoolyearData(int year,
                                              int grade,
                                              int classId,
                                              string name)
        {
            return _getData.Search_School_year_Data(year, grade, classId, name);
        }

        public void DeleteSchoolStdData(string stdCode, int year)
        {
            Delete_School_Std_Data(stdCode, year);
        }
        public void ViVerifyIsThereSudents()
        {
            var dt = _studentData.Get_All_Std_Data(0);

            if (dt.Rows.Count == 0)
                throw new Exception("لم يتم تسجيل طلاب جدد لهذا العام .. !");
        }
        public DataTable Get_years(int year = 0)
        {
            return _dal.ExecQuery("SP_GETYEARS",
                SqlParam.Int("@year", year == 0 ? Properties.Settings.Default.MyYear : year));
        }
        public DataTable Get_School_year_Data(int Year_Id, int Grade_Id, int Class_Id)
           => _dal.ExecQuery("SP_Get_School_year_Data",
               SqlParam.Int("@Year_Id", Year_Id),
               SqlParam.Int("@Grade_Id", Grade_Id),
               SqlParam.Int("@Class_Id", Class_Id));

        public DataTable Verify_Std_School_Code(string std_code, int Year_Id)
           => _dal.ExecQuery("SP_Verify_Std_School_Code",
               SqlParam.NVar("@std_code", std_code, 20),
               SqlParam.Int("@Year_Id", Year_Id));

        public void Delete_School_Std_Data(string std_code, int Year_Id)
            => _dal.ExecNonQuery("SP_Delete_School_Std_Data",
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.Int("@Year_Id", Year_Id));

        public void Add_School_Std_Data(string std_code,
                                int Year_Id,
                                int Grade_Id,
                                int Std_Status_Id,
                                int Class_Id)
        {
            _dal.ExecNonQuery("SP_Add_School_Std_Data",
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Std_Status_Id", Std_Status_Id),
                SqlParam.Int("@Class_Id", Class_Id),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15)
            );
        }
    }
}