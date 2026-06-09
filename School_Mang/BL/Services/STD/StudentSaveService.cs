
using School_Mang.BL.Services.STD;
using School_Mang.BL.STD;
using System;
using School_Mang.DAL;
using School_Mang.BL.Models;
using School_Mang.BL.DTO;
using School_Mang.BL.Common;

namespace School_Mang.BL.Services
{
    public class StudentSaveService
    {
        private readonly CLS_STD _std;
        private readonly DataAcceseLayer _dal;
        private readonly StudentCodeService _codeService;
        private readonly StudentService  _studentService;
        private readonly VerifyService _verify;

        public StudentSaveService()
        {
            _std = new CLS_STD();
            _codeService = new StudentCodeService();
            _studentService = new StudentService();
            _verify = new VerifyService();
            _dal = new DataAcceseLayer();
        }
        public string SaveStudent(StudentSaveRequest req)
                                    {
            int studentCode = _codeService.GetStudentCode(
                req.YearId, req.GradeId);
                

            if (!_verify.Verify_Std_Code(studentCode.ToString()).Rows.Count.Equals(0))
            {
                throw new Exception("كود الطالب غير صالح");
            }
            int year = SchoolYearService.GetCalculationYear(req.YearId);

            var sen = AgeService.NatAgeHesabSen(req.NationalId, year);


            DateTime tarikh = Convert.ToDateTime(sen.BirthDate);

            _std.Add_Std_Data(
                studentCode.ToString(),
                req.StudentName,
                req.NationalId,
                tarikh,
                req.GenderId,
                req.NationalityId,
                req.ReligionId,
                req.StatusId,
                req.GradeId,
                req.YearId,
                req.OsraId
            );

            return studentCode.ToString();
        }

        public void AddToSchool(StudentSaveRequest req)
        {
            _studentService.Add_School_Std_Data(
                req.StdCode,
                req.YearId,
                req.GradeId,
                req.StatusId,
                req.ClassId
            );
        }

        public ServiceResult UpdateStudent(StudentDTO dto)
        {
            try
            {
                UpdateSchoolStdData(dto);
                return ServiceResult.Ok("تم تحديث بيانات الطالب بنجاح");
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("حدث خطأ أثناء التحديث: " + ex.Message);
            }
            
        }
        private void UpdateSchoolStdData(StudentDTO dto)
        {
            _dal.ExecNonQuery("SP_Update_School_Std_Data",
                SqlParam.NVar("@std_code", dto.StdCode, 20),
                SqlParam.NVar("@std_name", dto.StdName, 12),
                SqlParam.NVar("@std_nat", dto.Nat, 14),
                SqlParam.Date("@std_date", dto.BirthDate),
                SqlParam.Int("@Grade_Id", dto.GradeId),
                SqlParam.Int("@Std_Status_Id", dto.StudentStatus),
                SqlParam.Int("@Class_Id", dto.ClassId),
                SqlParam.Int("@Gender_Id", dto.GenderId),
                SqlParam.Int("@Religion_Id", dto.ReligionId),
                SqlParam.Int("@Year_Id", dto.YearId),
                SqlParam.NVar("@Updated_by", dto.UserName, 15)
            );
        }
    }
}