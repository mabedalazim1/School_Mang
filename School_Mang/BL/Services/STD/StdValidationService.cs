using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace School_Mang.BL.Services.STD
{

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public static ValidationResult Ok()
        {
            return new ValidationResult
            {
                IsValid = true,
                Message = ""
            };
        }

        public static ValidationResult Fail(string message)
        {
            return new ValidationResult
            {
                IsValid = false,
                Message = message
            };
        }
    }
    public static class StdValidationService
    {
        private static readonly BL.STD.CLS_STD std = new BL.STD.CLS_STD();

        public static ValidationResult VerifyStdNat(string stdCode, string nat, bool isUpdateMode = false)
        {
            try
            {
                string code = "0";

                if (isUpdateMode)
                    code = stdCode;

                DataTable dt = std.Verify_Std_Nat(nat, code);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][1].ToString();

                    return ValidationResult.Fail(
                        $"الرقم القومي للطالب {name} مسجل من قبل"
                    );
                }

                return ValidationResult.Ok();
            }
            catch (Exception ex)
            {
                return ValidationResult.Fail(ex.Message);
            }
        }
        public static ValidationResult VerifyOsraNat(string nat)
        {
            try
            {
                DataTable dt = std.Verify_Osra_Nat(nat, 0);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][1].ToString();

                    return ValidationResult.Fail(
                         $"الرقم القومي مسجل من قبل ({name})"
                    );
                }

                return ValidationResult.Ok();
            }
            catch (Exception ex)
            {
                return ValidationResult.Fail(ex.Message);
            }
        }
        public static ValidationResult VerifyStdStatus(object statusObj)
        {
            try
            {
                if (statusObj == null || !int.TryParse(statusObj.ToString(), out int status))
                {
                     return ValidationResult.Fail("حدث خطأ في قراءة حالة الطالب");
                }

                if (status == 3 || status == 4 || status == 7)
                {
                    return ValidationResult.Fail(
                        "لا يمكن التعامل مع الطالب المحول .. يرجى حذف طلب التحويل أولاً.."
                        );
                }


                return ValidationResult.Ok();
            }
            catch (Exception ex)
            {
                return ValidationResult.Fail(ex.Message);
            }
        }
    }
}
