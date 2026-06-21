using System;
using System.Windows.Forms;

namespace School_Mang.RPT
{
    public partial class FRM_REPORTS : Form
    {
        public FRM_REPORTS()
        {
            InitializeComponent();
        }


        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                crystalReportViewer1.ReportSource = null;
            }
            catch
            {
            }

            base.OnFormClosed(e);
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
