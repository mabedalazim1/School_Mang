using School_Mang.BL.Services.STD;
using School_Mang.DAL;
using System;
using System.Data;
using System.Linq;

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
       
        public DataTable GetStudentsByYear(int year, int gradeId, int classId, bool sortByUpdatedAt = false)
        {
            DataTable dt = Get_School_year_Data(year, gradeId, classId);

            if (sortByUpdatedAt && dt.Columns.Contains("Updated_At"))
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "Updated_At DESC";
                return dv.ToTable();
            }

            return dt;
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

        public ValidationResult CanDeleteStudent(string stdCode, int year, object statusObj)
        {
            // 1. check status (نفس اللي في الفورم)
            var statusCheck = StdValidationService.VerifyStdStatus(statusObj);
            if (!statusCheck.IsValid)
                return statusCheck;

            // 2. check previous year
            var prevYear = Verify_Std_School_Code(stdCode, year - 1);
            if (prevYear.Rows.Count != 0)
            {
                return ValidationResult.Fail("لا يمكن حذف هذا الطالب لأنه مقيد فى العام السابق .. !");
            }

            // 3. check next year
            var nextYear = Verify_Std_School_Code(stdCode, year + 1);
            if (nextYear.Rows.Count != 0)
            {
                return ValidationResult.Fail("لا يمكن الحذف فى حالة ترحيل البيانات للعام القادم .. !");
            }

            return ValidationResult.Ok();
        }

        public void DeleteStudent(string stdCode, int year)
        {
            try
            { 
                Delete_School_Std_Data(stdCode, year);
            }
            catch (Exception ex)
            {
              throw new Exception("حدث خطأ أثناء الحذف: " + ex.Message);
            }
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

        public bool HasStudentsWithoutGolos(int yearId)
        {
            return _dal.ExecuteScalar<bool>(
                "SP_Has_Students_Without_Golos",
                SqlParam.Int("@Year_Id", yearId));
        }
    }
}