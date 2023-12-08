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
    public partial class FRM_FINAL_DATA : Form
    {
        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();
        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();
        BL.NATEG.ExcelUtlity Excel = new BL.NATEG.ExcelUtlity();

        // Form Closed
        private static FRM_FINAL_DATA frm_Final_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Final_Data = null;
        }
        public static FRM_FINAL_DATA Get_Frm_Final_Data
        {
            get
            {
                if (frm_Final_Data == null)
                {
                    frm_Final_Data = new FRM_FINAL_DATA();
                    frm_Final_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Final_Data;
            }
        }


        public FRM_FINAL_DATA()
        {
            InitializeComponent();

            if (frm_Final_Data == null)
            {
                frm_Final_Data = this;
            }

        }

        private void lbl_back_Click(object sender, EventArgs e)
        {
            natag_func.changePages(FRM_NATEG.Get_Frm_Nateg.pn_home, "التقييمات");
        }

        private void lbl_get_dgree_a_Click(object sender, EventArgs e)
        {
            try
            {
                BL.Globals.Amal_Sana = true;
                BL.Globals.Final_Test = false;
                FRM_CHOSE_FINAL_DATA frm = new FRM_CHOSE_FINAL_DATA();
                frm.ShowDialog();
            }catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void pic_get_dgree_a_Click(object sender, EventArgs e)
        {
            lbl_get_dgree_a_Click(sender, e);
        }

        private void lbl_get_dgree_b_Click(object sender, EventArgs e)
        {
            try
            {
                BL.Globals.Final_Test = true;
                BL.Globals.Amal_Sana = false;
                FRM_CHOSE_FINAL_DATA frm = new FRM_CHOSE_FINAL_DATA();
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void pic_get_dgree_b_Click(object sender, EventArgs e)
        {
            lbl_get_dgree_b_Click(sender, e);
        }
    }
}
