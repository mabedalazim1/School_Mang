using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_SITE_STD_DATA : Form
    {
        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();

        // Form Closed
        private static FRM_SITE_STD_DATA frm_Site_Std_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Site_Std_Data = null;
        }
        public static FRM_SITE_STD_DATA Get_Frm_Site_Std_Data
        {
            get
            {
                if (frm_Site_Std_Data == null)
                {
                    frm_Site_Std_Data = new FRM_SITE_STD_DATA();
                    frm_Site_Std_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Site_Std_Data;
            }
        }
        public FRM_SITE_STD_DATA()
        {
            InitializeComponent();

            if (frm_Site_Std_Data == null)
            {
                frm_Site_Std_Data = this;
            }
            
            LoadStdData();

           
        }


        int move;
        int move_x;
        int move_y;

        private void LoadStdData()
        {
            try
            {
                int test_kind = BL.Globals.test_kind;
                int test_month = BL.Globals.test_month;
                int grade_id = BL.Globals.test_grade_id;
                DataTable Dt;

                Waiting.Wait();
                if(test_kind == 1)
                {
                    Dt = NATEG.Get_Degree_Data(test_month, grade_id);
                    dt_std_data.DataSource = Dt;

                    switch (grade_id)
                    {
                        case 10:
                        case 11:
                        case 1:
                        case 2:
                        case 3:
                            dt_std_data.Columns["دراسات"].Visible = false;
                            dt_std_data.Columns["مهارات"].Visible = false;
                            dt_std_data.Columns["تكنولوجيا"].Visible = false;
                            dt_std_data.Columns["علوم"].HeaderText = "متعدد";
                            break;
                        
                        case 4:
                        case 5:
                        case 6:
                            dt_std_data.Columns["بدنية"].Visible = false;

                            break;

                        case 7:
                        case 8:
                        case 9:
                            dt_std_data.Columns["بدنية"].Visible = false;
                            dt_std_data.Columns["مهارات"].HeaderText = "فنية";
                            dt_std_data.Columns["تكنولوجيا"].HeaderText = "حاسب";
                            break;

                    }
                }
                else
                {
                    Dt = NATEG.Get_Mark_Data(test_month, grade_id);
                    dt_std_data.DataSource = Dt;
                    switch (grade_id)
                    {
                        case 10:
                        case 11:
                            dt_std_data.Columns["دراسات"].Visible = false;
                            dt_std_data.Columns["فرنسى"].Visible = false;
                            dt_std_data.Columns["مهارات"].Visible = false;
                            dt_std_data.Columns["تكنولوجيا"].Visible = false;
                            dt_std_data.Columns["علوم"].HeaderText = "متعدد";
                            break;
                        case 1:
                        case 2:
                        case 3:
                            dt_std_data.Columns["دراسات"].Visible = false;
                            dt_std_data.Columns["مهارات"].Visible = false;
                            dt_std_data.Columns["تكنولوجيا"].Visible = false;
                            dt_std_data.Columns["علوم"].HeaderText = "متعدد";
                            break;

                        case 4:
                        case 5:
                        case 6:
                            dt_std_data.Columns["مهارات"].Visible = false;
                            dt_std_data.Columns["تكنولوجيا"].Visible = false;

                            break;

                        case 7:
                        case 8:
                        case 9:

                            dt_std_data.Columns["مهارات"].HeaderText = "فنية";
                            dt_std_data.Columns["تكنولوجيا"].HeaderText = "حاسب";
                            break;

                    }
                    
                }

                dt_std_data.Columns["test_kind_Id"].Visible = false;
                dt_std_data.Columns["grade_Id"].Visible = false;
                dt_std_data.Columns["الصف"].Visible = false;
                dt_std_data.Columns["نوع الإختبار"].Visible = false;

                DataTable grade_dt = std.Get_grades();
                cmb_grade.DataSource = grade_dt;
                cmb_grade.DisplayMember = "GradeDesc";
                cmb_grade.ValueMember = "Grade_Id";
            }
            catch(Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.End_WAit();
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

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void FRM_SITE_STD_DATA_Load(object sender, EventArgs e)
        {
            dt_std_data.Columns["اسم الطالب"].Width = 200;
            cmb_grade.SelectedValue = BL.Globals.test_grade_id;
        }
    }
}
