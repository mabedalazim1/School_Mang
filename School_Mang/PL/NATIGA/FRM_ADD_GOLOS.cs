using School_Mang.BL;
using School_Mang.BL.Services;
using School_Mang.BL.Services.Nateg;
using System;
using System.Data;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_ADD_GOLOS : Form
    {
        private readonly GolosService _golosService =
                        new GolosService();

        BL.STD.CLS_STD std = new BL.STD.CLS_STD();

        private readonly LookupService _stdData = new LookupService();

        int year = Properties.Settings.Default.year_cod;


        public FRM_ADD_GOLOS()
        {
            InitializeComponent();

            // Fill Combo
            cmb_grade.DataSource = _stdData.Get_grades();
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            lbl_year.Text = Properties.Settings.Default.Year_Desc;

            lbl_coun_std.Text = std.Get_Kaema_Data(year, 10).Rows.Count.ToString();

            Get_Count_Grade(10);
        }

       
        int move;
        int move_x;
        int move_y;

        private void Get_Count_Grade(int grade)
        {
            DataTable dt = _golosService.GetGolosSum(grade);

            bool hasGolos =
                dt != null &&
                dt.Rows.Count > 0 &&
                dt.Rows[0]["Golos"] != DBNull.Value &&
                Convert.ToInt32(dt.Rows[0]["Golos"]) > 0;

            if (hasGolos)
            {
                txt_golos.Text = _golosService.GetGolosSum(grade, "min")
                                              .Rows[0]["Golos"]
                                              .ToString();

                btn_save_data.ButtonText = "تعديل الترقيم";
                lbl_edit.Visible = true;
            }
            else
            {
                txt_golos.Text = "";
                btn_save_data.ButtonText = "بدء الترقيم";
                lbl_edit.Visible = false;
            }
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void txt_nat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void btn_save_data_Click(object sender, EventArgs e)
        {
            if (txt_golos.Text == "")
            {
                MSG.ErrorMesg("يرجى ادخال رقم البداية");
                txt_golos.Focus();
                return;
            }

            if (MSG.DialogeMsg("هل تريد إضافة أرقام جلوس للصف المحدد ... ؟") != DialogResult.Yes)
                return;

            try
            {
                int grade = Convert.ToInt32(cmb_grade.SelectedValue);

                if (_golosService.GetGolosSum(grade).Rows[0]["Golos"].ToString() != "")
                {
                    if (MSG.DialogeErrMsg("تم إدخال أرقام الجلوس للصف المحدد من قبل .. سوف يتم حذف الأرقام القديمة.. هل تريد المتابعة ؟") == DialogResult.No)
                        return;
                }

                int golos = Convert.ToInt32(txt_golos.Text);

                Waiting.Start();

                _golosService.UpdateGolosNumbers(grade, golos);

                MSG.MyMesg("تم تعديل أرقام الجلوس بنجاح ..!");
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
            }
        }

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            int grade = Convert.ToInt32(cmb_grade.SelectedValue);

            lbl_coun_std.Text = _golosService
                .GetGolosSum(grade, "count")
                .Rows[0][0]
                .ToString();

            Get_Count_Grade(grade);
        }
    }
}
