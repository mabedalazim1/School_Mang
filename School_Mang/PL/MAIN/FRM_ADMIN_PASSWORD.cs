using School_Mang.BL;
using System;
using System.Data;
using System.Windows.Forms;

namespace School_Mang.PL.MAIN
{
    public partial class FRM_ADMIN_PASSWORD : Form
    {

        private readonly BL.LOGIN.CLS_LOGIN _login = new BL.LOGIN.CLS_LOGIN();
        private readonly BL.USERS _users = new BL.USERS();

        public FRM_ADMIN_PASSWORD(string operationName = "تأكيد كلمة المرور")
        {
            InitializeComponent();
            lbl_title.Text = operationName;
        }

        int move;
        int move_x;
        int move_y;

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pn_top_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            move_x = e.X;
            move_y = e.Y;
        }

        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }

        private void pn_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool IsAdmin()
        {
            DataTable dt = _users.Get_User_Permission(Properties.Settings.Default.user_code);

            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["permission_id"]) == 1 &&
                    Convert.ToInt32(row["role_id"]) == 1)
                {
                    return true;
                }
            }

            return false;
        }

        private bool VerifyPassword()
        {
            if (string.IsNullOrWhiteSpace(txt_pass.Text))
            {
                MSG.ErrorMesg("ادخل كلمة المرور.");
                txt_pass.Focus();
                return false;
            }

            DataTable dt = _login.Login(
                Properties.Settings.Default.user_name,
                txt_pass.Text);

            if (dt.Rows.Count == 0)
            {
                MSG.ErrorMesg("كلمة المرور غير صحيحة.");
                txt_pass.SelectAll();
                txt_pass.Focus();
                return false;
            }

            return true;
        }

        private void Login()
        {
            if (!VerifyPassword())
                return;

            if (!IsAdmin())
            {
                MSG.ErrorMesg("هذه العملية متاحة لمدير النظام فقط.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Login();
                }
            }
        }

        private void FRM_ADMIN_PASSWORD_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage =
            InputLanguage.FromCulture(
                new System.Globalization.CultureInfo("en-US"));
        }
        private void FRM_ADMIN_PASSWORD_Shown(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage =
                InputLanguage.FromCulture(
                    new System.Globalization.CultureInfo("en-US"));

            txt_pass.Focus();
        }

        private void FRM_ADMIN_PASSWORD_FormClosed(object sender, FormClosedEventArgs e)
        {
            InputLanguage.CurrentInputLanguage =
                InputLanguage.FromCulture(
                    new System.Globalization.CultureInfo("ar-EG"));
        }

    }
}
