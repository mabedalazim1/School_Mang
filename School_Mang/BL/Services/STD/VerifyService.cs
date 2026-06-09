using School_Mang.BL.Common;
using School_Mang.DAL;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace School_Mang.BL.Services.STD
{
    public class VerifyService
    {
        private readonly DataAcceseLayer _dal;
        public VerifyService() 
        {
            _dal = new DataAcceseLayer();
        }

        public ServiceResult ValidateIsNumeric(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return ServiceResult.Fail("القيمة فارغة");
            }

            if (value.Any(c => !char.IsDigit(c)))
            {
                return ServiceResult.Fail("تأكد من القيمة المدخلة .. يسمح بالأرقام فقط ..!");
            }

            return ServiceResult.Ok();

        }

        public ServiceResult VerifyStudentNationalId(string nationalId, string studentCode = "0")
        {
            try
            {
                var dt = Verify_Std_Nat(nationalId, studentCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    var name = dt.Rows[0][1].ToString();

                    return ServiceResult.Fail($"الرقم القومي مسجل من قبل باسم الطالب  / {name} ");
                }

                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.Message);
            }
        }

        public ServiceResult VerifyOsraNationalId(string nationalId, int osraId = 0)
        {
            try
            {
                var dt = Verify_Osra_Nat(nationalId, osraId);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();

                    return ServiceResult.Fail("الرقم القومي مسجل من قبل باسم ولى الأمر  :  " + name);
                }

                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.Message);
            }
        }

        public DataTable Verify_Std_Code(string std_code)
           => _dal.ExecQuery("SP_Verify_Std_Code",
               SqlParam.NVar("@std_code", std_code, 20));

        public DataTable Verify_Std_Nat(string std_nat, string std_code = "0")
           => _dal.ExecQuery("SP_Verify_Std_Nat",
               SqlParam.NVar("@std_nat", std_nat, 14),
               SqlParam.NVar("@std_code", std_code, 20));

        public DataTable Verify_Osra_Nat(string nat, int id)
            => _dal.ExecQuery("SP_Verify_Osra_Nat",
                SqlParam.NVar("@nat", nat, 14),
                SqlParam.Int("@osra_Id", id));



        public DataTable Verify_Osra_Code(string Year)
            => _dal.ExecQuery("SP_Verify_Osra_Code",
                SqlParam.NVar("@Year", Year, 2));
    }
}
