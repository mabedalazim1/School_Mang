using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_KAEMA_GRADE : Form
    {
        BL.MSG msg = new BL.MSG();
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();
        BL.Waiting waiting = new BL.Waiting();

        // Form Closed
        private static FRM_KAEMA_GRADE frm_Kaema_Grade;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Kaema_Grade = null;
        }
        public static FRM_KAEMA_GRADE Get_Frm_Kaema_Grade
        {
            get
            {
                if (frm_Kaema_Grade == null)
                {
                    frm_Kaema_Grade = new FRM_KAEMA_GRADE();
                    frm_Kaema_Grade.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Kaema_Grade;
            }
        }
        public FRM_KAEMA_GRADE()
        {
            InitializeComponent();

            if (frm_Kaema_Grade == null)
            {
                frm_Kaema_Grade = this;
            }

            if (BL.Globals.Open_41_New || BL.Globals.Open_Tadarg_Sen)
            {
                cmb_grade.DataSource = std.Get_grades("yes");
            }

            else
            {
                cmb_grade.DataSource = std.Get_grades();
            }


            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            cmb_sana.DataSource = std.Get_years();
            cmb_sana.DisplayMember = "YearDesc";
            cmb_sana.ValueMember = "Year_Id";
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

        private void pn_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }
        private void Print_Kaema(int grade = 0)
        {
            try
            {
                string grade_desc;

                int sana = Convert.ToInt32(cmb_sana.SelectedValue);

                if (grade == 0)
                {
                    grade_desc = "كل الصفوف";
                }
                else
                {
                    grade_desc = std.Get_Grade_Desc(grade).Rows[0]["GradeDesc"].ToString();
                }

                // Test If Tere Is Data Or Not

                if (std.Get_Kaema_Data(sana, 0).Rows.Count == 0)
                {
                    msg.ErrorMesg("لا توجد بيانات مسجلة .. يرجى التأكد من العام الدراسى !");

                }
                else
                {
                    RPT.Open_Kaema_Report(sana, grade, grade_desc);
                }


            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }


        private void FRM_KAEMA_GRADE_Load(object sender, EventArgs e)
        {

            cmb_grade.SelectedIndex = 0;
            if (cmb_sana.Items.Count > 1)
            {
                cmb_sana.SelectedIndex = 0;
            }
        }

        private void btn_print_kaema_Click(object sender, EventArgs e)
        {
            waiting.Wait();
            int grade = Convert.ToInt32(cmb_grade.SelectedValue);
            if (BL.Globals.Open_Kaema)
            {
                Print_Kaema(grade);
                waiting.End_WAit();
                return;
            }
            if (BL.Globals.Open_Tadarg_Sen)
            {
               
                int year_id = Convert.ToInt32(cmb_sana.SelectedValue);
                if (std.Get_Tadrg_Sen(year_id, grade).Rows.Count == 0)
                {
                    msg.ErrorMesg("لا توجد بيانات مسجلة للصف المحدد .. !");
                    waiting.End_WAit();
                    return;
                }

                RPT.OpenTadargSen(year_id, grade);
                waiting.End_WAit();
                return;
            }
            if (BL.Globals.Open_Segel)
            {
                int year_id = Convert.ToInt32(cmb_sana.SelectedValue);
                if (std.Get_Segel_Data(year_id, grade).Rows.Count == 0)
                {
                    msg.ErrorMesg("لا توجد بيانات مسجلة للصف المحدد .. !");
                    waiting.End_WAit();
                    return;
                }

                RPT.OpenSegel(year_id, grade);
                waiting.End_WAit();
                return;
            }
            if (BL.Globals.Open_41_New)
            {
                int year_id = Convert.ToInt32(cmb_sana.SelectedValue);
                if (std.Get_Segel_Data(year_id, grade).Rows.Count == 0)
                {
                    msg.ErrorMesg("لا توجد بيانات مسجلة للصف المحدد .. !");
                    waiting.End_WAit();
                    return;
                }

                RPT.OpenMostgdin_41(year_id, grade);
                waiting.End_WAit();
                return;
            }

            if (BL.Globals.Open_Transfer_From)
            {
                int year_id = Convert.ToInt32(cmb_sana.SelectedValue) ;
                if (std.Get_Trans_Reports(year_id -1 , 3, grade ).Rows.Count == 0)
                {
                    msg.ErrorMesg("لا توجد بيانات مسجلة للصف المحدد .. !");
                    waiting.End_WAit();
                    return;
                }
                RPT.OpenTahewl_Data(year_id -1 , 3, grade );

                waiting.End_WAit(); 
                return;
            }
            if (BL.Globals.Open_Transfer_To)
            {
                int year_id = Convert.ToInt32(cmb_sana.SelectedValue);
                if (std.Get_Trans_Reports(year_id, 4, grade).Rows.Count == 0)
                {
                    msg.ErrorMesg("لا توجد بيانات مسجلة للصف المحدد .. !");
                    waiting.End_WAit();
                    return;
                }
                RPT.OpenTahewl_Data(year_id, 4, grade);
                waiting.End_WAit();
                return;
            }
            waiting.End_WAit();

        }

        private void btn_print_kaema_all_Click(object sender, EventArgs e)
        {
            waiting.Wait();
            int year_id = Convert.ToInt32(cmb_sana.SelectedValue);
            if (BL.Globals.Open_Kaema)
            {
                Print_Kaema();
                waiting.End_WAit();
                return;
            }
            if (BL.Globals.Open_Tadarg_Sen)
            {
                if (std.Get_Tadrg_Sen(year_id).Rows.Count == 0)
                {
                    msg.ErrorMesg("لا توجد بيانات مسجلة لهذا العام .. !");
                    waiting.End_WAit();
                    return;
                }

                if (msg.DialogeErrMsg("سوف يتم عرض بيانات جميع الطلاب .. هل تريد المتابعة ؟ ") != DialogResult.Yes) return;

                RPT.OpenTadargSen(year_id);
                waiting.End_WAit();
                return;
            }

            if (BL.Globals.Open_Segel)
            {
                if (std.Get_Segel_Data(year_id).Rows.Count == 0)
                {
                    msg.ErrorMesg("لا توجد بيانات مسجلة لهذا العام .. !");
                    waiting.End_WAit();
                    return;
                }
                RPT.OpenSegel(year_id);
                waiting.End_WAit();
                return;
            }
            if (BL.Globals.Open_41_New)
            {
               
                if (std.Get_Segel_Data(year_id).Rows.Count == 0)
                {
                    msg.ErrorMesg("لا توجد بيانات مسجلة لهذا العام .. !");
                    waiting.End_WAit();
                    return;
                }
                if (msg.DialogeErrMsg("سوف يتم عرض بيانات جميع الطلاب .. هل تريد المتابعة ؟ ") != DialogResult.Yes) return;


                RPT.OpenMostgdin_41(year_id);
                waiting.End_WAit();
                return;
            }

            if (BL.Globals.Open_Transfer_From)
            {
                if (msg.DialogeErrMsg("سوف يتم عرض بيانات جميع الطلاب .. هل تريد المتابعة ؟ ") != DialogResult.Yes) return;
                RPT.OpenTahewl_Data(year_id - 1, 3);
                waiting.End_WAit();
                return;

            }

            if (BL.Globals.Open_Transfer_To)
            {
                if (msg.DialogeErrMsg("سوف يتم عرض بيانات جميع الطلاب .. هل تريد المتابعة ؟ ") != DialogResult.Yes) return;
                RPT.OpenTahewl_Data(year_id, 4);
                waiting.End_WAit();
                return;

            }
            waiting.End_WAit();
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();

            BL.Globals.Open_Kaema = false;
            BL.Globals.Open_Segel = false;
            BL.Globals.Open_Tadarg_Sen = false;
            BL.Globals.Open_41_New = false;
            BL.Globals.Open_Transfer_From = false;
            BL.Globals.Open_Transfer_To = false;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void FRM_KAEMA_GRADE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_close_b_Click(sender, e);
            }
        }
    }
}
