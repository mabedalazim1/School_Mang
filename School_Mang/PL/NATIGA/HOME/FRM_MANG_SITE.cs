using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.PL.MAIN;

namespace School_Mang.PL.NATIGA.HOME
{
    public partial class FRM_MANG_SITE : Form
    {
        HTTP.HTTPCLINT HTTP = new HTTP.HTTPCLINT();
        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();

        // Form Closed
        private static FRM_MANG_SITE frm_Mang_Site;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Mang_Site = null;
        }
        public static FRM_MANG_SITE Get_Frm_Mang_Site
        {
            get
            {
                if (frm_Mang_Site == null)
                {
                    frm_Mang_Site = new FRM_MANG_SITE();
                    frm_Mang_Site.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Mang_Site;
            }
        }

        public FRM_MANG_SITE()
        {
            InitializeComponent();

            if (frm_Mang_Site == null)
            {
                frm_Mang_Site = this;
            }
        }

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

        // Upload File
        private async Task UploadFile(string path )
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    await HTTP.UplodFile(openFileDialog1.FileName, path);
                }
                else
                {
                    msg.ErrorMesg("تم إلغاء الإجراء ..!");
                }

            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
           
        }
        private void label1_Click(object sender, EventArgs e)
        {
            changePages(FRM_NATEG.Get_Frm_Nateg.pn_home, "التقييمات");
        }

        private void lbl_back_Click(object sender, EventArgs e)
        {
            changePages(FRM_NATEG.Get_Frm_Nateg.pn_home, "التقييمات");

        }

        private void pic_back_Click(object sender, EventArgs e)
        {
            lbl_back_Click(sender,e);
        }

        private async void lbl_upload_a_Click(object sender, EventArgs e)
        {
            await UploadFile("upload/degree");

        }

        private void pic_upload_a_Click(object sender, EventArgs e)
        {
            lbl_upload_a_Click(sender, e);
        }

        private async void lbl_upload_test_Click(object sender, EventArgs e)
        {
                await UploadFile("upload/mark");
        }

        private void pic_upload_test_Click(object sender, EventArgs e)
        {
            lbl_upload_test_Click(sender, e);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
            FRM_DELETE_SITE_DATA.Get_Frm_Delete_Data.ShowDialog();
            
        }
    }
}
