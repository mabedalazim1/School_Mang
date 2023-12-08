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
    public partial class FRM_FINAL_EXAMS : Form
    {

        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();
        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();
        BL.NATEG.ExcelUtlity Excel = new BL.NATEG.ExcelUtlity();

        // Form Closed
        private static FRM_FINAL_EXAMS frm_Final_Exams;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Final_Exams = null;
        }
        public static FRM_FINAL_EXAMS Get_Frm_Final_Exams
        {
            get
            {
                if (frm_Final_Exams == null)
                {
                    frm_Final_Exams = new FRM_FINAL_EXAMS();
                    frm_Final_Exams.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Final_Exams;
            }
        }

        public FRM_FINAL_EXAMS()
        {
            InitializeComponent();

            if (frm_Final_Exams == null)
            {
                frm_Final_Exams = this;
            }
        }

        

        private void lbl_back_Click(object sender, EventArgs e)
        {
           natag_func.changePages(FRM_NATEG.Get_Frm_Nateg.pn_home, "التقييمات");
        }

        private void pic_back_Click(object sender, EventArgs e)
        {
            lbl_back_Click(sender, e);
        }

        private void lbl_upload_sery_Click(object sender, EventArgs e)
        {
            try
            {
                string file_name = natag_func.OpenDialoge(openFileDialog1);
                if (file_name == null) 
                {
                    msg.ErrorMesg("تم إلغاء الإجراء..!");
                    return;
                }
                Waiting.Wait();
                DataTable dt_sery = Excel.ReadSeryData(file_name);
                foreach (DataRow row in dt_sery.Rows)
                {
                    int Golos = Convert.ToInt32(row["Golos"]);
                    int Sery = Convert.ToInt32(row["Sery"]);

                    NATEG.Update_Sery_Data(Golos, Sery);
                  
                }
                Waiting.End_WAit();
                msg.MyMesg("تم تحديث الأرقام السرية بنجاح .. !");
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            Waiting.End_WAit();
        }

        private void pic_upload_sery_Click(object sender, EventArgs e)
        {
            lbl_upload_sery_Click(sender, e);
        }

        private void lbl_get_sery_Click(object sender, EventArgs e)
        {
            try
            {
                FRM_ADD_SERY frm = new FRM_ADD_SERY();
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void lbl_final_Click(object sender, EventArgs e)
        {
            natag_func.changePages(FRM_FINAL_DATA.Get_Frm_Final_Data. pn_home, "الإختبارات النهائية");
        }

        private void pic_final_Click(object sender, EventArgs e)
        {
            lbl_final_Click(sender, e);
        }
    }
}


