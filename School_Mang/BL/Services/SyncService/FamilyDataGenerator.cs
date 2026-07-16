using System;

namespace School_Mang.BL.Services.FamilySyncService
{
    public class FamilyDataGenerator
    {
        private const int UserNameOffset = 137;
        private string GetLetters(string familyCode)
        {
            if (string.IsNullOrWhiteSpace(familyCode) || familyCode.Length != 5)
                throw new ArgumentException("كود الأسرة يجب أن يتكون من 5 أرقام.");

            char firstLetter = GetLetter(familyCode[4]);
            char secondLetter = GetLetter(familyCode[3]);

            return $"{firstLetter}{secondLetter}";
        }

        private char GetLetter(char digit)
        {
            switch (digit)
            {
                case '0': return 'k';
                case '1': return 'j';
                case '2': return 'h';
                case '3': return 'g';
                case '4': return 'f';
                case '5': return 'e';
                case '6': return 'd';
                case '7': return 'c';
                case '8': return 'b';
                case '9': return 'a';
                default: return 'n';
            }
        }

        private int GetNumberPart(string nationalId, string familyCode)
        {
            if (string.IsNullOrWhiteSpace(nationalId) || nationalId.Length < 4)
                throw new ArgumentException("الرقم القومي غير صحيح");

            if (string.IsNullOrWhiteSpace(familyCode) || familyCode.Length < 3)
                throw new ArgumentException("كود الأسرة غير صحيح");


            // آخر 4 أرقام من الرقم القومي
            int nationalPart = int.Parse(
                nationalId.Substring(nationalId.Length - 4)
            );


            // أول 3 أرقام من كود الأسرة
            int familyPart = int.Parse(
                familyCode.Substring(0, 3)
            );


            return nationalPart + familyPart;
        }

        private string FormatNumberPart(int number)
        {
            string value = number.ToString();

            // لو أقل من اربعة ارقام
            if (value.Length < 4)
            {
                 number += 800; 
                return number.ToString("0000");
            }
            // لو 4 أرقام 
            if (value.Length == 4)
            {
                return number.ToString("0000");
            }

            // لو 5 أرقام
            if (value.Length == 5)
            {
                int firstDigit = int.Parse(value.Substring(0, 1));

                if (firstDigit == 2)
                {
                    number = (int)Math.Round(number / 10.0);
                }
                else
                {
                    number += 800;

                    // المحافظة على 4 أرقام
                    if (number > 9999)
                        number -= 10000;
                }

                return number.ToString("0000");
            }

            throw new Exception("الرقم الناتج خارج النطاق المتوقع");
        }
        public string GenerateUniqueUserName(string nationalId, int osraId, int attempt = 0)
        {
            string familyCode = osraId.ToString("00000");

            string letters = GetLetters(familyCode);

            int number = GetNumberPart(nationalId, familyCode);


            number += attempt * UserNameOffset;

            string numberPart = FormatNumberPart(number);

            return $"{letters}{numberPart}";
        }

        public string GenerateFirstName(string fatherName)
        {
            if (string.IsNullOrWhiteSpace(fatherName))
                return string.Empty;

            fatherName = fatherName.Trim();

            while (fatherName.Contains("  "))
                fatherName = fatherName.Replace("  ", " ");

            string[] parts = fatherName.Split(' ');

            if (parts.Length == 0)
                return string.Empty;

            string first = parts[0];

            // عبد الرحمن - عبد الله - عبد المنعم ...
            if (first == "عبد" && parts.Length > 1)
                return first + " " + parts[1];

            // أبو يوسف - ابو كريم ...
            if ((first == "أبو" || first == "ابو") && parts.Length > 1)
                return first + " " + parts[1];

            return first;
        }

        public string GeneratePassword(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("اسم المستخدم غير موجود");

            if (userName.Length < 4)
                throw new ArgumentException("اسم المستخدم غير صحيح");

            string password =
                userName.Substring(userName.Length - 4);

            return BCrypt.Net.BCrypt.HashPassword(
                password,
                10);
        }
    }
}
