using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.STD.HOME
{
    public partial class FRM_STD_DATA : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.MSG msg = new BL.MSG();


        // Form Closed
        private static FRM_STD_DATA frm_Std_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Std_Data = null;
        }
        public static FRM_STD_DATA Get_Frm_Std_Data
        {
            get
            {
                if (frm_Std_Data == null)
                {
                    frm_Std_Data = new FRM_STD_DATA();
                    frm_Std_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Std_Data;
            }
        }

        public FRM_STD_DATA()
        {
            InitializeComponent();

            if (frm_Std_Data == null)
            {
                frm_Std_Data = this;
            }

        }

        // Change Pages
        private void changePages(Panel pn)
        {
            MAIN.FRM_MAIN.Get_Frm_Main.pn_home.Visible = false;
            MAIN.FRM_MAIN.Get_Frm_Main.pn_main.Controls.Clear();
            MAIN.FRM_MAIN.Get_Frm_Main.pn_main.Visible = false;
            MAIN.FRM_MAIN.Get_Frm_Main.pn_main.BringToFront();
            MAIN.FRM_MAIN.Get_Frm_Main.lbl_main.Text = "شئون الطلاب";
            MAIN.FRM_MAIN.Get_Frm_Main.lbl_main.Visible= false;
            MAIN.FRM_MAIN.Get_Frm_Main.pn_main.Controls.Add(pn);
            MAIN.FRM_MAIN.Get_Frm_Main.trans_a.ShowSync(MAIN.FRM_MAIN.Get_Frm_Main.pn_main);
            MAIN.FRM_MAIN.Get_Frm_Main.lbl_main.Visible = true;
        }

        private void lbl_current_stds_Click(object sender, EventArgs e)
        {
            BL.Globals.Current_Year_Data = true;
            STD.FRM_CHOOSE_GRADE frm = new FRM_CHOOSE_GRADE();
            frm.ShowDialog();
        }

        private void lbl_back_Click(object sender, EventArgs e)
        {
            changePages(MAIN.FRM_TALABA.Get_Frm_Talaba.pn_home);
        }

        private void lbl_show_stds_Click(object sender, EventArgs e)
        {
            DataTable Dt =  std.Get_All_Std_Data(0);
            if (Dt.Rows.Count == 0 )
            {
                msg.ErrorMesg("لم يتم تسجيل طلاب جدد لهذا العام .. !");
                return;
            }
            
            FRM_GET_STD frm = new FRM_GET_STD();
            frm.ShowDialog();
        }

        private void lbl_get_osra_data_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Form_Get_osra = true;
            FRM_GET_OSRAA.Get_Osra_data.ShowDialog();
        }

        private void lbl_add_std_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Form_Get_osra = false;
            FRM_ADD_STD frm_add_std = new FRM_ADD_STD();
            frm_add_std.ShowDialog();
        }

        private void pic_current_stds_Click(object sender, EventArgs e)
        {
            lbl_current_stds_Click(sender, e);
        }

        private void pic_add_std_Click(object sender, EventArgs e)
        {
            lbl_add_std_Click(sender, e);
        }

        private void pic_get_osra_data_Click(object sender, EventArgs e)
        {
            lbl_get_osra_data_Click(sender, e);
        }

        private void pic_show_stds_Click(object sender, EventArgs e)
        {
            lbl_show_stds_Click(sender, e);
        }

        private void lbl_next_year_Click(object sender, EventArgs e)
        {
            BL.Globals.Current_Year_Data = false;
            FRM_CHOOSE_GRADE frm = new FRM_CHOOSE_GRADE();
            frm.ShowDialog();
        }

        private void pic_next_year_Click(object sender, EventArgs e)
        {
            lbl_next_year_Click(sender, e);
        }

        private void pic_back_Click(object sender, EventArgs e)
        {
            lbl_back_Click(sender, e);
        }

        private void lbl_tahwelat_Click(object sender, EventArgs e)
        {
            DataTable Dt_1 = std.GET_Trans_Data(0, 3);
            DataTable Dt_2 = std.GET_Trans_Data(0, 4);

            if(Dt_1.Rows.Count ==0 || Dt_2.Rows.Count == 00)
            {
                msg.ErrorMesg("لا يوجد طلبات تحويل مسجلة هذا العام .. !");
                return;
            }
            FRM_TAHWELAT.Get_Frm_Tahwelat.ShowDialog();
        }

        private void pic_tahwelat_Click(object sender, EventArgs e)
        {
            lbl_tahwelat_Click(sender, e);
        }

        private void lbl_std_details_Click(object sender, EventArgs e)
        {
            BL.Globals.Details_Std = true;
            FRM_CURRENT_STD.Get_Current_Std.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lbl_std_details_Click(sender, e);
        }
    }
}
