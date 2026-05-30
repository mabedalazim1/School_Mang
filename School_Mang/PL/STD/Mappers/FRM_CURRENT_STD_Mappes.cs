using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.STD.Mappers
{
    internal static class FRM_CURRENT_STD_Mappes
    {
        public static StudentDTO MapToTahweelStd(DataGridViewRow row)
        {
            return new StudentDTO
            {
                StdCode = row.Cells["std_code"].Value?.ToString(),
                StudentFullName = row.Cells["اسم الطالب"].Value?.ToString(),
                FatherName = row.Cells["father_name"].Value?.ToString(),
                Address = row.Cells["العنوان"].Value?.ToString(),
                GradeId = SafeConverter.GetInt(row.Cells["Grade_Id"].Value),
                TransferStatus = 3,
                TransferReason = "رغبة ولى الأمر",
                StudentStatus = SafeConverter.GetInt(row.Cells["Std_Status_Id"].Value)
            };
        }
    }
}
