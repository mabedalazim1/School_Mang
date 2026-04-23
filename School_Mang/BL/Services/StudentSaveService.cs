
using School_Mang.BL.STD;
using System;
using System.Data;

namespace School_Mang.BL.Services
{
    public class StudentSaveService
    {
        private readonly CLS_STD _std;
        private readonly StudentCodeService _codeService;
        private readonly HESAB_SEN _hesabSen;

        public StudentSaveService()
        {
            _std = new CLS_STD();
            _codeService = new StudentCodeService();
            _hesabSen = new HESAB_SEN();
        }
        public void SaveStudent(
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
            var dt = _std.Get_Year_By_Id(yearId);

            string yearStr = dt.Rows[0]["YearDesc"].ToString(); // "2026-2025"
            int year = Convert.ToInt32(dt.Rows[0]["Year"]) -1; // 2026

            var sen = _hesabSen.Nat_HesabSen(nationalId, year);
               
            

            if (sen == null)
                throw new Exception("خطأ في الرقم القومي");

            MSG.MyMesg(sen.ToString());

            //string tarikh = sen[5].ToString() + "-" + sen[4].ToString() + "-" + sen[3].ToString();
            string birthDateStr = $"{sen[5]}-{sen[4]}-{sen[3]}";
            
            MSG.MyMesg(birthDateStr);

            _std.Add_Std_Data(
                studentCode.ToString(),
                studentName,
                nationalId,
                Convert.ToDateTime(birthDateStr),
                genderId,
                nationalityId,
                religionId,
                statusId,
                gradeId,
                yearId,
                osraId
            );
        }

       
    }
}