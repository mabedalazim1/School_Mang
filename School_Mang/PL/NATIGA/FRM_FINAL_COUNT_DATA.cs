using School_Mang.BL;
using School_Mang.BL.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_FINAL_COUNT_DATA : Form
    {
       private readonly BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        

        // Form Closed
        private static FRM_FINAL_COUNT_DATA Frm_Final_Count_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            Frm_Final_Count_Data = null;
        }
        public static FRM_FINAL_COUNT_DATA Get_Frm_Final_Count_Data
        {
            get
            {
                if (Frm_Final_Count_Data == null)
                {
                    Frm_Final_Count_Data = new FRM_FINAL_COUNT_DATA();
                    Frm_Final_Count_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return Frm_Final_Count_Data;
            }
        }
        public FRM_FINAL_COUNT_DATA()
        { 
            InitializeComponent();

            if (Frm_Final_Count_Data == null)
            {
                Frm_Final_Count_Data = this;
            }

            try
            {
                DataTable Dt = NATEG.Get_Count_Final_Degree();

                if (Dt == null)
                    throw new InvalidOperationException("تعذر الحصول على بيانات أعداد النتائج.");

                dt_std_data.DataSource = Dt;
                dt_std_data.Columns["Grade_Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Close();
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
        }

        private void btn_show_data_Click(object sender, EventArgs e)
        {
            if (dt_std_data.Rows.Count == 0)
            {
                MSG.ErrorMesg("لا توجد بيانات مسجلة");
                return;
            }
           

            if (dt_std_data.CurrentRow == null ||
                dt_std_data.CurrentRow.Cells["Grade_Id"].Value == null ||
                dt_std_data.CurrentRow.Cells["Grade_Id"].Value == DBNull.Value)
            {
                MSG.ErrorMesg("يرجى تحديد الصف المطلوب");
                return;
            }

            int test_grade_id = Convert.ToInt32(
                dt_std_data.CurrentRow.Cells["Grade_Id"].Value);

            this.Visible = false;

            // BL.Globals.test_grade_id = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
            var frm = FRM_FINAL_DATA.Get_Frm_Final_Data;
            AppNavigation.Instance
                .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                .SetContext(c => c.Natiga.TestGradeId = test_grade_id)
                .Show(frm);

            // FRM_FINAL_DATA.Get_Frm_Final_Data.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);

        }

        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            btn_show_data_Click(sender, e);
        }
    }
}
