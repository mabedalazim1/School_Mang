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

        HTTP.HTTPCLINT HTTP = new HTTP.HTTPCLINT();

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

        BL.MSG msg = new BL.MSG();
        BL.NATEG.ExcelUtlity Excel = new BL.NATEG.ExcelUtlity();


        // Change Pages
        private void changePages(Panel pn, string lbl)
        {
            FRM_MAIN.Get_Frm_Main.pn_home.Visible = false;
            FRM_MAIN.Get_Frm_Main.pn_main.Controls.Clear();
            FRM_MAIN.Get_Frm_Main.pn_main.Visible = false;
            FRM_MAIN.Get_Frm_Main.lbl_main.Text = lbl;
            FRM_MAIN.Get_Frm_Main.lbl_main.Visible = false;
            FRM_MAIN.Get_Frm_Main.pn_main.BringToFront();
            FRM_MAIN.Get_Frm_Main.pn_main.Controls.Add(pn);
            FRM_MAIN.Get_Frm_Main.trans_a.ShowSync(FRM_MAIN.Get_Frm_Main.pn_main);
            FRM_MAIN.Get_Frm_Main.lbl_main.Visible = true;
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
            BL.Globals.Kashof_Rasd = false;
            NATIGA.FRM_KSHOF_RASD frm = new NATIGA.FRM_KSHOF_RASD();
            frm.ShowDialog();
        }

        private void pic_rasd_Click(object sender, EventArgs e)
        {
            lbl_rasd_Click(sender, e);
        }

        private void lbl_import_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel 2010(*.xlsx)|*.xlsx|Excel 2003(*.xls)|*.xls";
            openFileDialog1.InitialDirectory = @"D:\Rasd";
            openFileDialog1.Title = "اختر ملف الاكسيل المراد رفعه ..!";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Excel.ReadRasdDataFromExcel(openFileDialog1.FileName);
            }
        }

        private void pic_import_Click(object sender, EventArgs e)
        {
            lbl_import_Click(sender, e);
        }

        private void lbl_rasd_report_Click(object sender, EventArgs e)
        {
            BL.Globals.Kashof_Rasd = true;
            NATIGA.FRM_KSHOF_RASD frm = new NATIGA.FRM_KSHOF_RASD();
            frm.ShowDialog();
        }

        private void pic_rasd_report_Click(object sender, EventArgs e)
        {
            lbl_rasd_report_Click(sender, e);
        }

        private void lbl_site_Click(object sender, EventArgs e)
        {
            // Get Std Data Form
            changePages(NATIGA.HOME.FRM_MANG_SITE.Get_Frm_Mang_Site.pn_home, "إدارة الموقع");
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pic_site_Click(object sender, EventArgs e)
        {
            lbl_site_Click(sender, e);
        }
    }

}
