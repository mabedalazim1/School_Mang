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
    public partial class FRM_EDIT_ABSENT_STD : Form
    {
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        

        // Form Closed
        private static FRM_EDIT_ABSENT_STD frm_Edit_absent_std;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Edit_absent_std = null;
        }
        public static FRM_EDIT_ABSENT_STD Get_Frm_Edit_absent_std
        {
            get
            {
                if (frm_Edit_absent_std == null)
                {
                    frm_Edit_absent_std = new FRM_EDIT_ABSENT_STD();
                    frm_Edit_absent_std.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Edit_absent_std;
            }
        }
        public FRM_EDIT_ABSENT_STD()
        {
            InitializeComponent();

            if (frm_Edit_absent_std == null)
            {
                frm_Edit_absent_std = this;
            }
        }
        private void Chang_Chk(CheckBox checkBox)
        {
            if (checkBox.Checked)
            {
                checkBox.ForeColor = Color.Red;
            }
            else
            {
                checkBox.ForeColor = Color.RoyalBlue;
            }
            AbsentTerm();
        }

        private void Disable_Chk(CheckBox sub_chk)
        {
            sub_chk.Checked = true;
            sub_chk.Enabled = false;
            sub_chk.ForeColor = Color.Red;
        }
        private void Enable_Chk(CheckBox sub_chk)
        {
            sub_chk.Checked = false;
            sub_chk.Enabled = true;
            sub_chk.ForeColor = Color.RoyalBlue;
        }
        private void Chang_Term_Chk(CheckBox main_chk)
        {
           
            if (main_chk.Checked )
            {
                switch (main_chk.Name)
                {
                    case "chk_term_1":
                        Disable_Chk(chk_ar_1);
                        Disable_Chk(chk_dain_1);
                        Disable_Chk(chk_english_1);
                        Disable_Chk(chk_maharat_1);
                        Disable_Chk(chk_math_1);
                        Disable_Chk(chk_scince_1);
                        Disable_Chk(chk_social_1);
                        Disable_Chk(chk_tocnolegy_1);
                        break;
                    case "chk_term_2":

                        Disable_Chk(chk_ar_2);
                        Disable_Chk(chk_dain_2);
                        Disable_Chk(chk_english_2);
                        Disable_Chk(chk_maharat_2);
                        Disable_Chk(chk_math_2);
                        Disable_Chk(chk_scince_2);
                        Disable_Chk(chk_social_2);
                        Disable_Chk(chk_tocnolegy_2);
                        break;
                }
                
            }
            else
            {
                switch (main_chk.Name)
                {
                    case "chk_term_1":
                        Enable_Chk(chk_ar_1);
                        Enable_Chk(chk_dain_1);
                        Enable_Chk(chk_english_1);
                        Enable_Chk(chk_maharat_1);
                        Enable_Chk(chk_math_1);
                        Enable_Chk(chk_scince_1);
                        Enable_Chk(chk_social_1);
                        Enable_Chk(chk_tocnolegy_1);
                        break;
                    case "chk_term_2":

                        Enable_Chk(chk_ar_2);
                        Enable_Chk(chk_dain_2);
                        Enable_Chk(chk_english_2);
                        Enable_Chk(chk_maharat_2);
                        Enable_Chk(chk_math_2);
                        Enable_Chk(chk_scince_2);
                        Enable_Chk(chk_social_2);
                        Enable_Chk(chk_tocnolegy_2);
                        break;
                }
            }
        }

        private void AbsentTerm()
        {
            if(chk_ar_1.Checked && chk_dain_1.Checked
                && chk_english_1.Checked && chk_maharat_1.Checked
                && chk_math_1.Checked && chk_scince_1.Checked 
                && chk_social_1.Checked && chk_tocnolegy_1.Checked)
            {
                chk_term_1.Checked = true;
            }
            if (chk_ar_2.Checked && chk_dain_2.Checked
                && chk_english_2.Checked && chk_maharat_2.Checked
                && chk_math_2.Checked && chk_scince_2.Checked
                && chk_social_2.Checked && chk_tocnolegy_2.Checked)
            {
                chk_term_2.Checked = true;
            }
        }
        int move;
        int move_x;
        int move_y;

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
            Close();
            BL.Globals.Std_Golos = 0;
            FRM_FINAL_DATA.Get_Frm_Final_Data.cmb_grade_DropDownClosed(sender, e);
            FRM_FINAL_DATA.Get_Frm_Final_Data.Show();
        }

        private void chk_term_1_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Term_Chk(chk_term_1);
        }

        private void chk_term_2_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Term_Chk(chk_term_2);
        }

        private void chk_ar_1_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_ar_1);
        }

        private void chk_math_1_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_math_1);
        }

        private void chk_english_1_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_english_1);
        }

        private void chk_social_1_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_social_1);
        }

        private void chk_dain_1_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_dain_1);
        }

        private void chk_scince_1_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_scince_1);
        }

        private void chk_tocnolegy_1_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_tocnolegy_1);
        }

        private void chk_maharat_1_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_maharat_1);
        }

        private void chk_ar_2_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_ar_2);
        }

        private void chk_math_2_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_math_2);
        }

        private void chk_english_2_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_english_2);
        }

        private void chk_social_2_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_social_2);
        }

        private void chk_dain_2_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_dain_2);
        }

        private void chk_scince_2_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_scince_2);
        }

        private void chk_tocnolegy_2_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_tocnolegy_2);
        }

        private void chk_maharat_2_CheckedChanged(object sender, EventArgs e)
        {
            Chang_Chk(chk_maharat_2);
        }

        private void FRM_EDIT_ABSENT_STD_Load(object sender, EventArgs e)
        {
            try
            {
                int grade = BL.Globals.test_grade_id;

                int Std_Golos = BL.Globals.Std_Golos;
                DataTable Dt = NATEG.Get_Final_All_Data(Std_Golos);
                if (Dt.Rows.Count == 0)
                {
                    MSG.ErrorMesg("لا توجد بيانات مسجلة لهذا الطالب ..!");
                    this.Close();
                    BL.Globals.Std_Golos = 0;
                    FRM_FINAL_DATA.Get_Frm_Final_Data.Show();
                    return;
                }

                txt_name.Text = Dt.Rows[0]["stdunet_name"].ToString();
                txt_grade.Text = Dt.Rows[0]["GradeDesc"].ToString();
                txt_grade.TextAlign = HorizontalAlignment.Center;

                // Test Std Grade
                if (grade == 4 || grade == 5 || grade == 6)
                {
                    chk_tocnolegy_1.Location = new Point( 131, 259);
                    chk_tocnolegy_1.Text = "تكنولوجي";
                    chk_maharat_1.Location = new Point(15, 259);
                    chk_maharat_1.Text = "مهارات";

                    chk_tocnolegy_2.Location = new Point(130, 259);
                    chk_tocnolegy_2.Text = "تكنولوجي";
                    chk_maharat_2.Location = new Point(12, 259);
                    chk_maharat_2.Text = "مهارات";
                }
                else
                {
                    chk_tocnolegy_1.Location = new Point(163, 259);
                    chk_tocnolegy_1.Text = "حاسب";
                    chk_maharat_1.Location = new Point(32, 259);
                    chk_maharat_1.Text = "فنية";
                    
                    chk_tocnolegy_2.Location = new Point(160, 259);
                    chk_tocnolegy_2.Text = "حاسب";
                    chk_maharat_2.Location = new Point(29, 259);
                    chk_maharat_2.Text = "فنية";
                }
                // Get Absent Student
                bool absent_ar_A = Convert.ToBoolean(Dt.Rows[0]["absent_ar_A"]);
                bool absent_ar_B = Convert.ToBoolean(Dt.Rows[0]["absent_ar_B"]);
                bool absent_math_A = Convert.ToBoolean(Dt.Rows[0]["absent_math_A"]);
                bool absent_math_B = Convert.ToBoolean(Dt.Rows[0]["absent_math_B"]);
                bool absent_scince_A = Convert.ToBoolean(Dt.Rows[0]["absent_scince_A"]);
                bool absent_scince_B = Convert.ToBoolean(Dt.Rows[0]["absent_scince_B"]);
                bool absent_social_A = Convert.ToBoolean(Dt.Rows[0]["absent_social_A"]);
                bool absent_social_B = Convert.ToBoolean(Dt.Rows[0]["absent_social_B"]);
                bool absent_english_A = Convert.ToBoolean(Dt.Rows[0]["absent_english_A"]);
                bool absent_english_B = Convert.ToBoolean(Dt.Rows[0]["absent_english_B"]);
                bool absent_din_A = Convert.ToBoolean(Dt.Rows[0]["absent_din_A"]);
                bool absent_din_B = Convert.ToBoolean(Dt.Rows[0]["absent_din_B"]);
                bool absent_maharat_A = Convert.ToBoolean(Dt.Rows[0]["absent_maharat_A"]);
                bool absent_maharat_B = Convert.ToBoolean(Dt.Rows[0]["absent_maharat_B"]);
                bool absent_tocnolegy_A = Convert.ToBoolean(Dt.Rows[0]["absent_tocnolegy_A"]);
                bool absent_tocnolegy_B = Convert.ToBoolean(Dt.Rows[0]["absent_tocnolegy_B"]);
                bool absent_term_A = Convert.ToBoolean(Dt.Rows[0]["absent_term_A"]);
                bool absent_term_B = Convert.ToBoolean(Dt.Rows[0]["absent_term_B"]);

                chk_ar_1.Checked = absent_ar_A;
                chk_ar_2.Checked = absent_ar_B;
                chk_math_1.Checked = absent_math_A;
                chk_math_2.Checked = absent_math_B;
                chk_scince_1.Checked = absent_scince_A;
                chk_scince_2.Checked = absent_scince_B;
                chk_social_1.Checked = absent_social_A;
                chk_social_2.Checked = absent_social_B;
                chk_english_1.Checked = absent_english_A;
                chk_english_2.Checked = absent_english_B;
                chk_dain_1.Checked = absent_din_A;
                chk_dain_2.Checked = absent_din_B;
                chk_maharat_1.Checked = absent_maharat_A;
                chk_maharat_2.Checked = absent_maharat_B;
                chk_tocnolegy_1.Checked = absent_tocnolegy_A;
                chk_tocnolegy_2.Checked = absent_tocnolegy_B;

                chk_term_1.Checked = absent_term_A;
                chk_term_2.Checked = absent_term_B;
            }
            catch(Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void btn_save_data_Click(object sender, EventArgs e)
        {
            bool absent_ar_A = chk_ar_1.Checked;
            bool absent_ar_B = chk_ar_2.Checked;
            bool absent_math_A = chk_math_1.Checked;
            bool absent_math_B = chk_math_2.Checked;
            bool absent_scince_A = chk_scince_1.Checked;
            bool absent_scince_B = chk_scince_2.Checked;
            bool absent_social_A = chk_social_1.Checked;
            bool absent_social_B = chk_social_2.Checked;
            bool absent_english_A = chk_english_1.Checked;
            bool absent_english_B = chk_english_2.Checked;
            bool absent_din_A = chk_dain_1.Checked;
            bool absent_din_B = chk_dain_2.Checked;
            bool absent_maharat_A = chk_maharat_1.Checked;
            bool absent_maharat_B = chk_maharat_2.Checked;
            bool absent_tocnolegy_A = chk_tocnolegy_1.Checked;
            bool absent_tocnolegy_B = chk_tocnolegy_2.Checked;
            bool absent_term_A = chk_term_1.Checked;
            bool absent_term_B = chk_term_2.Checked;
            try
            {
                Waiting.Start();
                NATEG.Update_Final_Absent(
                                        absent_ar_A, absent_ar_B,
                                        absent_math_A, absent_math_B,
                                        absent_scince_A, absent_scince_B,
                                        absent_social_A, absent_social_B,
                                        absent_english_A, absent_english_B,
                                        absent_din_A, absent_din_B,
                                        absent_maharat_A, absent_maharat_B,
                                        absent_tocnolegy_A, absent_tocnolegy_B,
                                        absent_term_A, absent_term_B);
                MSG.MyMesg("تم تسجيل غياب الطالب .. !");
                Waiting.Stop();
            }
            catch(Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
            }   
        }
    }
}
