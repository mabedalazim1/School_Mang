using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.MAIN
{
    public partial class FRM_YEAR : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.MSG msg = new BL.MSG();
        BL.LOGIN.CLS_LOGIN login = new BL.LOGIN.CLS_LOGIN();
        BL.USERS users = new BL.USERS();
        public FRM_YEAR()
        {
            InitializeComponent();
            // Fill Combos
            cmb_year.DataSource = std.Get_years(2022);
            cmb_year.DisplayMember = "YearDesc";
            cmb_year.ValueMember = "Year";
            lbl_year.Text = Properties.Settings.Default.MyYear.ToString();

            // Change Lang

            InputLanguage.CurrentInputLanguage =
            InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(txt_pass.Text == "")
            {
                
                msg.ErrorMesg("ادخل كلمة المرور.. !");
                txt_pass.Focus();
                return;
            }
            DataTable Dt = login.Login(Properties.Settings.Default.user_name, txt_pass.Text);
            if (Dt.Rows.Count > 0)
            {
                Properties.Settings.Default.MyYear = Convert.ToInt32(cmb_year.SelectedValue);
                Properties.Settings.Default.year_cod = Convert.ToInt32(cmb_year.SelectedIndex)+1;
                Properties.Settings.Default.Year_Desc = cmb_year.Text;
                Properties.Settings.Default.Save();

                DataTable dt_user = new DataTable();
                dt_user = users.Get_User_Permission(Properties.Settings.Default.user_code);

                foreach (DataRow row in dt_user.Rows)
                {
                    if (Convert.ToInt32(row["permission_id"]) == 1
                        && Convert.ToInt32(row["role_id"]) == 1)
                    {
                        if(msg.DialogeErrMsg("هل تريد تغيير العام الدراسى للبرنامج")== DialogResult.Yes)
                        {
                            users.Update_Year_Data(
                            Properties.Settings.Default.year_cod,
                            Properties.Settings.Default.MyYear,
                            Properties.Settings.Default.Year_Desc
                            );
                            msg.MyMesg("تم تغيير العام الدراسى فى قاعدة البيانات !! ");
                        }
                        else
                        {
                            msg.ErrorMesg("تم الغاء الإجراء .. لم يتم التعديل");
                            return;
                        }
                       
                    }
                    else
                    {
                        msg.MyMesg("تم تعديل العام الدراسى");
                    }
                }
                    
                string year_desc = "العام الدراسى :   " + (Properties.Settings.Default.MyYear - 1).ToString() + " - " + Properties.Settings.Default.MyYear.ToString();
                FRM_MAIN.Get_Frm_Main.lbl_Year.Text = year_desc;
                lbl_year.Text = Properties.Settings.Default.MyYear.ToString();
                FRM_MAIN.Get_Frm_Main.lbl_year_main.Text = year_desc;


                this.Close();
            }
            else
            {
                  msg.ErrorMesg(" .. ! عفوا لا يمكنك تغيير العام الدراسى تأكد من كلمة المرور");
                txt_pass.Focus();
            }
        }

        private void FRM_YEAR_Load(object sender, EventArgs e)
        {
            cmb_year.SelectedItem = Properties.Settings.Default.MyYear;
        }

        private void FRM_YEAR_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Change Lang

            InputLanguage.CurrentInputLanguage =
            InputLanguage.FromCulture(new System.Globalization.CultureInfo("ar-Eg"));
        }

        private void txt_pass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                if (txt_pass.Text == "")
                {
                    msg.ErrorMesg("ادخل كلمة المرور");
                    txt_pass.Focus();
                    return;
                }
                else
                {
                    btn_login_Click(sender, e);
                }
            } 
        }
    }
}
