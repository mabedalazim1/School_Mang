using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.PL.MAIN;

namespace School_Mang.BL.NATEG
{
    public class cls_NATAG_FUNCTIONS
    {
        public string OpenDialoge(OpenFileDialog FileDialog)
        {
            FileDialog.Filter = "Excel 2010(*.xlsx)|*.xlsx|Excel 2003(*.xls)|*.xls";
            FileDialog.InitialDirectory = @"D:\Rasd";
            FileDialog.Title = "اختر ملف الاكسيل المراد رفعه ..!";
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                return FileDialog.FileName;
            }
            else
            {
                return null;
            }
        }

        // Change Pages
        public void changePages(Panel pn, string lbl)
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
    }
}
