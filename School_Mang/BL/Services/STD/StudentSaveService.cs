
using School_Mang.BL.Services.STD;
using School_Mang.BL.STD;
using System;
using System.Data;

namespace School_Mang.BL.Services
{
    public class StudentSaveService
    {
        private readonly CLS_STD _std;
        private readonly StudentCodeService _codeService;

        public StudentSaveService()
        {
            _std = new CLS_STD();
            _codeService = new StudentCodeService();
        }
        public string SaveStudent(
                                string studentName,
                                string nationalId,
                                int yearId,
                                int gradeId,
                                int genderId,
                                int nationalityId,
                                int religionId,
                                int statusId,
                                int osraId)
                                    {
            int studentCode = _codeService.GetStudentCode(
                yearId, 
                gradeId
                );

            if (!_std.Verify_Std_Code(studentCode.ToString()).Rows.Count.Equals(0))
            {
                throw new Exception("كود الطالب غير صالح");
            }
            int year = SchoolYearService.GetCalculationYear(yearId);

            var sen = AgeService.NatAgeHesabSen(nationalId, year);


            DateTime tarikh = Convert.ToDateTime(sen.BirthDate);

            _std.Add_Std_Data(
                studentCode.ToString(),
                studentName,
                nationalId,
                tarikh,
                genderId,
                nationalityId,
                religionId,
                statusId,
                gradeId,
                yearId,
                osraId
            );

            return studentCode.ToString();
        }

       
    }
}