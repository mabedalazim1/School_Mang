using School_Mang.BL;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.BL.Services.FamilySyncService;
using School_Mang.BL.Services.FamilySyncService.Models;
using School_Mang.BL.Services.SyncService;
using System;
using System.Windows.Forms;



namespace School_Mang.PL.SITE
{
    public partial class FRM_PROGRESS : Form
    {
        

        public FRM_PROGRESS()
        {
            InitializeComponent();
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

        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }

        private void pn_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }


        public void Start(int maximum, string title)
        {
            lblTitle.Text = title;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = maximum;
            progressBar1.Value = 0;

            lblStatus.Text = $"0 / {maximum}";

            RefreshUI();
        }

        public void Step(string message)
        {
            if (progressBar1.Value < progressBar1.Maximum)
                progressBar1.Value++;

            lblStatus.Text =
                $"{message} ({progressBar1.Value} / {progressBar1.Maximum})";

            RefreshUI();
        }

        public void Finish()
        {
            progressBar1.Value = progressBar1.Maximum;

            lblStatus.Text = "تم الانتهاء";

            RefreshUI();
        }

        private void RefreshUI()
        {
            lblTitle.Refresh();
            lblStatus.Refresh();
            progressBar1.Refresh();

            Application.DoEvents();
        }

        public void UpdateProgress(int current, int total, string message)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() =>
                {
                    UpdateProgress(current, total, message);
                }));
                return;
            }

            progressBar1.Maximum = total;
            progressBar1.Value = current;

            lblStatus.Text = message;


            Refresh();
        }
    }
}
