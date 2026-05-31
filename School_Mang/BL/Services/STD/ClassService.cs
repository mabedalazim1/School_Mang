using School_Mang.BL.STD;
using System;
using School_Mang.BL.Common.Helper;

namespace School_Mang.BL.Services.STD
{
    public class ClassService
    {
        private readonly LookupService _stdData = new LookupService();

        public int GetClassByGrade(int gradeId)
        {
            var dt = _stdData.Get_Grad_Data(gradeId);

            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("لا يوجد فصول لهذا الصف");

            return SafeConverter.GetInt(dt.Rows[0]["Class_Id"]);
        }
    }
}
