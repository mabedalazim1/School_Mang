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
        public FRM_HOME()
        {
            InitializeComponent();
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
