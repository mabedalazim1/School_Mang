using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.BL.Services.STD
{
    public static class GetTypeService
    {
        public static int CheckType(TextBox txt ) {

                if (string.IsNullOrWhiteSpace(txt.Text) || txt.Text.Length != 14)
                    throw new Exception("الرقم القومي غير صحيح");

            // Chack Type
            int type = Convert.ToInt32(txt.Text.Substring(12, 1));

            if (type % 2 == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

    }
}
