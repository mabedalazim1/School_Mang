using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.SITE
{
    /// <summary>
    /// دالة عامة لقراءة الأكسيل
    /// </summary>
    public class ExcelColumn
    {
        public string Name { get; set; }
        public Type DataType { get; set; }
        public int Index { get; set; }

        // 🆕 خصائص جديدة
        public bool AllowNull { get; set; } = false;
        public bool AllowWhitespace { get; set; } = false;
        public object DefaultValue { get; set; } = null;

        // 🆕 تحقق مخصص
        public Func<object, bool> CustomValidator { get; set; }
        public string CustomErrorMessage { get; set; }
    }
}
