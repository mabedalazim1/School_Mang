
using School_Mang.BL.Services.STD;
using School_Mang.BL.STD;
using System;
using System.Data;
using School_Mang.BL.Models;

namespace School_Mang.BL.Services
{
    public class StudentSaveService
    {
        private readonly CLS_STD _std;
        private readonly StudentCodeService _codeService;
        private readonly StudentService  _studentService;
        private readonly VerifyService _verify;

        public StudentSaveService()
        {
            _std = new CLS_STD();
            _codeService = new StudentCodeService();
            _studentService = new StudentService();
            _verify = new VerifyService();
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
    }
}