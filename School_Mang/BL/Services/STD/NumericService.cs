using System;
using System.Text.RegularExpressions;


namespace School_Mang.BL.Services.STD
{
    public static class NumericService
    {
        public class ValidationResult
        {
            public bool IsValid { get; set; }
            public string Message { get; set; }
        }

        public static ValidationResult CheckNumeric(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new ValidationResult
                {
                    IsValid = false,
                    Message = "القيمة فارغة"
                };
            }

            if (Regex.IsMatch(text, @"\D"))
            {
                return new ValidationResult
                {
                    IsValid = false,
                    Message = "تأكد من القيمة المدخلة .. يسمح بالأرقام فقط ..!"
                };
            }

            return new ValidationResult
            {
                IsValid = true,
                Message = ""
            };
        }
    }
}