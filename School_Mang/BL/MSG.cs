using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.BL
{
    class MSG
    {
        public void ErrorMesg(string str = "تأكد من الرقم القومى")
        {
            MessageBox.Show(str, "برنامج إدارة المدرسة - خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MyMesg(string str)
        {
            MessageBox.Show(str, "برنامج إدارة المدرسة ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult DialogeMsg(string str)
        {
            DialogResult dialogResult = MessageBox.Show(str +"  ..!", " برنامج إدارة المدرسة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dialogResult;
        }

        public DialogResult DialogeErrMsg(string str)
        {
            DialogResult dialogResult = MessageBox.Show(str + "  ..!", " برنامج إدارة المدرسة", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return dialogResult;
        }
    }
}
