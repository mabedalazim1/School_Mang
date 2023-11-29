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
    public partial class FRM_NATAG_DATA : Form
    {
        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();



        // Form Closed
        private static FRM_NATAG_DATA Frm_Natag_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            Frm_Natag_Data = null;
        }
        public static FRM_NATAG_DATA Get_Frm_Natag_Data
        {
            get
            {
                if (Frm_Natag_Data == null)
                {
                    Frm_Natag_Data = new FRM_NATAG_DATA();
                    Frm_Natag_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return Frm_Natag_Data;
            }
        }
        public FRM_NATAG_DATA()
        {
            InitializeComponent();

            if (Frm_Natag_Data == null)
            {
                Frm_Natag_Data = this;
            }
            Waiting.Wait();

            DataTable Dt ;
            switch (BL.Globals.test_kind)
            {
                case 1:
                    Dt = NATEG.Get_Count_Degree(BL.Globals.test_month);
                  
                        dt_std_data.DataSource = Dt;
                        lbl_title.Text = "بيانات الموقع - التقييمات";

                    break;
                case 2:
                    Dt = NATEG.Get_Count_Mark(BL.Globals.test_month);
                   
                        dt_std_data.DataSource = Dt;
                        lbl_title.Text = "بيانات الموقع - الإختبارات";
                    break;
            }

            dt_std_data.Columns["id"].Visible = false;
            dt_std_data.Columns["test_kind_Id"].Visible = false;
            dt_std_data.Columns["grade_Id"].Visible = false;

            Waiting.End_WAit();
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

        private void FRM_NATAG_DATA_Load(object sender, EventArgs e)
        {

        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            btn_close_Click(sender, e);

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btn_show_data_Click(object sender, EventArgs e)
        {

            BL.Globals.test_grade_id = Convert.ToInt32(dt_std_data.CurrentRow.Cells["grade_Id"].Value);
            BL.Globals.test_month = Convert.ToInt32(dt_std_data.CurrentRow.Cells["test_kind_Id"].Value);
            FRM_SITE_STD_DATA.Get_Frm_Site_Std_Data.ShowDialog();
        }

        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            btn_show_data_Click(sender, e);
        }
    }
}
