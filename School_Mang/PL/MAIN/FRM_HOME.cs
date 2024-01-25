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
    public partial class FRM_HOME : Form
    {
        // Form Closed
        private static FRM_HOME frm_home;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_home = null;
        }
        public static FRM_HOME Get_Frm_home
        {
            get
            {
                if (frm_home == null)
                {
                    frm_home = new FRM_HOME();
                    frm_home.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_home;
            }
        }
        public FRM_HOME()
        {
            InitializeComponent();

            if (frm_home == null)
            {
                frm_home = this;
            }
        }

        private void pic_age_Click(object sender, EventArgs e)
        {
            PL.STD.FRM_HESAB_SEN frm = new STD.FRM_HESAB_SEN();
            frm.ShowDialog();
        }

        private void lbl_age_Click(object sender, EventArgs e)
        {
            pic_age_Click(sender,e);
        }

        private void pic_open_calc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void lbl_open_calc_Click(object sender, EventArgs e)
        {
            pic_open_calc_Click(sender, e);
        }
    }
}
