using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.PL.SITE;

namespace School_Mang.PL.MAIN
{
    public partial class FRM_MANGE_SITE : Form
    {
        // Form Closed
        private static FRM_MANGE_SITE frm_Mange_Site;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Mange_Site = null;
        }
        public static FRM_MANGE_SITE Get_Frm_Mange_Site
        {
            get
            {
                if (frm_Mange_Site == null)
                {
                    frm_Mange_Site = new FRM_MANGE_SITE();
                    frm_Mange_Site.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Mange_Site;
            }
        }


        public FRM_MANGE_SITE()
        {
            InitializeComponent();

            if (frm_Mange_Site == null)
            {
                frm_Mange_Site = this;
            }
        }

        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();
        BL.MSG msg = new BL.MSG();

        private void lbl_back_Click(object sender, EventArgs e)
        {
            natag_func.changePages(FRM_SETTINGS.Get_Frm_Settings.pn_home, "الإعدادات");
        }

        private void lbl_users_Click(object sender, EventArgs e)
        {
            try
            {
               FRM_COUNT_USERS.Get_Frm_Count_Users.ShowDialog();
            }catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void pic_users_Click(object sender, EventArgs e)
        {
            lbl_users_Click(sender, e);
        }
    }
}
