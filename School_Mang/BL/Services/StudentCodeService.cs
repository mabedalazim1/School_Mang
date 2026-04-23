using School_Mang.BL.STD;
using System;
using System.Data;
using System.Linq;


namespace School_Mang.BL.Services
{
    public class StudentCodeService
    {

        private readonly CLS_STD _std;

        public StudentCodeService()
        {
            _std = new CLS_STD();
        }

        public int GetStudentCode(int yearId, int gradeId)
        {
            string yearPart = GetYearCode(yearId);
            string gradePart = GetGradeCode(gradeId);

            int baseCode = int.Parse(yearPart + gradePart);

            var dt = _std.GET_Code_Std_Grade(gradeId, yearId, "yes");

            int count = 0;
            if (dt?.Rows.Count > 0)
                int.TryParse(dt.Rows[0]["count_std"].ToString(), out count);

            int code = baseCode + (count + 1);

            return VerifyStudentCode(code);
        }
        private string GetGradeCode(int gradeId)
        {
            if (gradeId >= 1 && gradeId <= 9)
                return gradeId.ToString("D1") + "000";

            if (gradeId == 10)
                return "0100";

            if (gradeId == 11)
                return "0200";

            throw new Exception("Invalid grade");
        }

        private bool IsCodeValid(int code)
        {
            try
            {
                return _std.Verify_Std_Code(code.ToString()).Rows.Count == 0;
            }
            catch
            {
                return false;
            }
        }
        private int VerifyStudentCode(int code)
        {
            try
            {
                // طول ما الكود مش متاح (يعني موجود)
                while (!IsCodeValid(code))
                {
                    code++;
                }
            }
            catch {
                throw new Exception("Invalid Code");
            }

            return code;
        }
        private string GetYearCode(int yearId)
        {
            var dt = _std.Get_Year_By_Id(yearId);

            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("Invalid Year Id");

            return dt.Rows[0]["Year"].ToString().Substring(2, 2);
        }
    }
}