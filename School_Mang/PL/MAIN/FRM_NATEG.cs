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
    public partial class FRM_NATEG : Form
    {

        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();
        BL.Waiting Waiting = new BL.Waiting();
        BL.MSG msg = new BL.MSG();

        // Form Closed
        private static FRM_NATEG frm_Nateg;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Nateg = null;
        }
        public static FRM_NATEG Get_Frm_Nateg
        {
            get
            {
                if (frm_Nateg == null)
                {
                    frm_Nateg = new FRM_NATEG();
                    frm_Nateg.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Nateg;
            }
        }

        public FRM_NATEG()
        {
            InitializeComponent();

            if (frm_Nateg == null)
            {
                frm_Nateg = this;
            }
        }


        private async Task Test_Intrent()
        {
            Waiting.Wait();
            //Test Intrent Connection
            BL.CLS_TEST_INTRNET_CON test_intrent = new BL.CLS_TEST_INTRNET_CON();
            await test_intrent.ChecK_Internt_Con();
            Waiting.End_WAit();
        }

        private void lbl_current_stds_Click(object sender, EventArgs e)
        {
            lbl_golos_id_Click(sender, e);
        }

        private void lbl_golos_id_Click(object sender, EventArgs e)
        {
            NATIGA.FRM_ADD_GOLOS frm = new NATIGA.FRM_ADD_GOLOS();
            frm.ShowDialog();
        }

        private void pic__golos_id_Click(object sender, EventArgs e)
        {
            lbl_golos_id_Click(sender, e);
        }

        private void lbl_rasd_Click(object sender, EventArgs e)
        {
            BL.Globals.Koshof_Rasd = false;
            NATIGA.FRM_KSHOF_RASD frm = new NATIGA.FRM_KSHOF_RASD();
            frm.ShowDialog();
        }

        private void pic_rasd_Click(object sender, EventArgs e)
        {
            lbl_rasd_Click(sender, e);
        }

        private void pic_import_Click(object sender, EventArgs e)
        {
            lbl_final_exams_Click(sender, e);
        }

        private void lbl_rasd_report_Click(object sender, EventArgs e)
        {
            BL.Globals.Koshof_Rasd = true;
            NATIGA.FRM_KSHOF_RASD frm = new NATIGA.FRM_KSHOF_RASD();
            frm.ShowDialog();
        }

        private void pic_rasd_report_Click(object sender, EventArgs e)
        {
            lbl_rasd_report_Click(sender, e);
        }

        private async void lbl_site_Click(object sender, EventArgs e)
        {
            await Test_Intrent();
            if (!BL.Globals.Test_Internet_Con)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت ..!");
                return;
            }
            else
            {
                // Get Std Data Form
                natag_func.changePages(NATIGA.HOME.FRM_MANG_SITE.Get_Frm_Mang_Site.pn_home, "بيانات الموقع");
            }
          
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pic_site_Click(object sender, EventArgs e)
        {
            lbl_site_Click(sender, e);
        }

        private void lbl_final_exams_Click(object sender, EventArgs e)
        {
            // Get Std Data Form
            natag_func.changePages(NATIGA.HOME.FRM_FINAL_DATA_HOME.Get_Frm_Final_Data_Home.pn_home, "الإختبارات النهائية");
        }

        private void lbl_setting_Click(object sender, EventArgs e)
        {
            // Get Std Data Form
            natag_func.changePages(NATIGA.HOME.FRM_FINAL_EXAMS.Get_Frm_Final_Exams.pn_home, "التجهيزات");
        }

        private void pic_setting_Click(object sender, EventArgs e)
        {
            lbl_setting_Click(sender, e);
        }

        private void lbl_edit_golos_Click(object sender, EventArgs e)
        {
            try
            {
                BL.Globals.Edit_Golos = true;
                NATIGA.FRM_FINAL_DATA.Get_Frm_Final_Data.ShowDialog();
            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void pic_edit_golos_Click(object sender, EventArgs e)
        {
            lbl_edit_golos_Click(sender, e);
        }
    }

}
