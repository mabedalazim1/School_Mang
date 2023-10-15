using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.RPT
{
    public partial class FRM_REPORTS : Form
    {

      
        // Form Closed
        private static FRM_REPORTS frm_Report;

        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Report = null;
        }
        public static FRM_REPORTS Get_Frm_report
        {
            get
            {
                if (frm_Report == null)
                {
                    frm_Report = new FRM_REPORTS();
                    frm_Report.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Report;
            }
        }


        public FRM_REPORTS()
        {
            InitializeComponent();

            if (frm_Report == null)
            {
                frm_Report = this;
            }
           
        }


        int move;
        int move_x;
        int move_y;

        private void pn_top_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            move_x = e.X;
            move_y = e.Y;
        }

        private void pn_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }

        private void btn_max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pn_top_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.Zoom(1);
        }
    }
}
