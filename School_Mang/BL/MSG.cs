using System.Windows.Forms;

namespace School_Mang.BL
{
    public static class MSG
    {
        private const string Title = "برنامج إدارة المدرسة";

        public static void ErrorMesg(string str = "تأكد من الرقم القومى")
        {
            MessageBox.Show(str, Title + " - خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void MyMesg(string str)
        {
            MessageBox.Show(str, Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static DialogResult DialogeMsg(string str)
        {
            return MessageBox.Show(str + " ..!", Title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }

        public static DialogResult DialogeErrMsg(string str)
        {
            return MessageBox.Show(str + " ..!", Title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
        }

        public static void MyExclamationMsg(string str)
        {
            MessageBox.Show(str, Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        public static void NoInternet()
        {
            MessageBox.Show("تأكد من الإتصال بالإنترنت..!",
                Title + " - خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static DialogResult DialogeMsgRtl(string str)
        {
            return MessageBox.Show(
                str,
                Title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        public static DialogResult DialogeErrMsgRtl(string str)
        {
            return MessageBox.Show(
                str,
                Title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }
    }
}