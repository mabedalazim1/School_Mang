using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.BL;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_ADD_GOLOS : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.NATEG.CLS_NATEG nateg = new BL.NATEG.CLS_NATEG();

        int year = Properties.Settings.Default.year_cod;


        public FRM_ADD_GOLOS()
        {
            InitializeComponent();

            // Fill Combo
            cmb_grade.DataSource = std.Get_grades();
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
            DataTable dt = nateg.Get_Golos_Sum(grade);

            if ( dt != null  && dt.Rows.Count > 0)
            {
                txt_golos.Text = nateg.Get_Golos_Sum(grade,"min").Rows[0]["Golos"].ToString();
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
            try
            {
                if (MSG.DialogeMsg("هل تريد إضافة أرقام جلوس للصف المحدد ... ؟") == DialogResult.Yes)
                {
                    int grade = Convert.ToInt32(cmb_grade.SelectedValue);

                    if (nateg.Get_Golos_Sum(grade).Rows[0]["Golos"].ToString() != "")
                    {
                        if (MSG.DialogeErrMsg("تم إدخال أرقام الجلوس للصف المحدد من قبل .. سوف يتم حذف الأرقام القديمة.. هل تريد المتابعة ؟") == DialogResult.No)
                        {
                            return;
                        }

                    }
                    // Add Golos Data
                    int golos = Convert.ToInt32(txt_golos.Text);
                    int std_code;
                    DataTable std_data = nateg.Get_Golos_Data(grade);
                   
                    Waiting.Start();
                    foreach(DataRow row in std_data.Rows)
                    {
                       std_code = Convert.ToInt32(row["std_code"]);
                        nateg.Update_Golos_Data(std_code, golos);
                        golos += 1;
                    }
                    Waiting.Stop();
                    MSG.MyMesg("تم تعديل أرقام الجلوس بنجاح ..!");
                }
                else
                {
                    return;
                }

            }
            catch(Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Waiting.Stop();
            }
            Waiting.Stop();

        }

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            int grade = Convert.ToInt32(cmb_grade.SelectedValue);
            lbl_coun_std.Text= nateg.Get_Golos_Sum(grade, "count").Rows[0][0].ToString();
            Get_Count_Grade(Convert.ToInt32(cmb_grade.SelectedValue));
        }
    }
}
