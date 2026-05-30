using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace School_Mang.PL.STD.Mappers
{
    internal static class FRM_GET_STD_Mapper
    {
        public static StudentDTO MapToStudent(DataRow row)
        {
            return new StudentDTO
            {
                StdCode = row["std_code"].ToString(),
                Nat = row["الرقم القومى"].ToString(),
                StdName = row["std_name"].ToString(),

                GradeId = SafeConverter.GetInt(row["Grade_Id"]),
                YearId = SafeConverter.GetInt(row["Year_Id"]),
                GenderId = SafeConverter.GetInt(row["Gender_Id"]),
                ReligionId = SafeConverter.GetInt(row["Religion_Id"]),
                NationalityId = SafeConverter.GetInt(row["Nationality_Id"]),
                OsraId = SafeConverter.GetInt(row["id"]),

                FatherName = row["اسم الأب"].ToString(),
                MotherName = row["اسم الأم"].ToString(),
                Address = row["العنوان"].ToString(),
                Wazifa = row["الوظيفة"].ToString(),
                FatherTel = row["هاتف الأب"].ToString(),
                MotherTel = row["هاتف الأم"].ToString()
            };
        }
        public static StudentDTO MapToTransfer(DataRow row)
        {
            return new StudentDTO
            {
                StdCode = row["std_code"].ToString(),
                StudentFullName = row["اسم الطالب"].ToString(),
                FatherName = row["اسم الأب"].ToString(),
                Address = row["العنوان"].ToString(),
                GradeId = SafeConverter.GetInt(row["Grade_Id"]),
                TransferStatus = 4,
                TransferReason = "رغبة ولى الأمر"
            };
        }
        public static StudentDTO MapToAddStd(DataRow row)
        {
            
            return new StudentDTO
            {
                StdCode = row["std_code"].ToString(),
                StdName = row["اسم الطالب"].ToString(),
                Nat = row["الرقم القومى"].ToString(),

                StudentStatus = SafeConverter.GetInt(row["Std_Status_Id"]),
                GradeId = SafeConverter.GetInt(row["Grade_Id"]),
                YearId = SafeConverter.GetInt(row["Year_Id"])
            };
        }
    }
}