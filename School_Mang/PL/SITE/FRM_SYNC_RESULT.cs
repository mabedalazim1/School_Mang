using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.Services;
using School_Mang.BL.Services.FamilySyncService.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;



namespace School_Mang.PL.SITE
{
    public partial class FRM_SYNC_RESULT : Form
    {
        private readonly LookupService _lookupService;
        private readonly FamilySyncResult _result;
        private readonly int _currentYear;
        public FRM_SYNC_RESULT(FamilySyncResult result, int currentYear)
        {
            InitializeComponent();

            _result = result;
            _currentYear = currentYear;
            _lookupService = new LookupService();
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

        private void FRM_EDIT_DATA_Load(object sender, EventArgs e)
        {

            DataTable dt = _lookupService.Get_years(_currentYear);
            DataRow row = dt.Select($"Year_Id = {_currentYear}").FirstOrDefault();

            if (row != null)
            {
                lbl_year.Text = row["YearDesc"].ToString();
            }

            lbl_no.Text = SafeConverter.GetString(_result.NoChange);
            lbl_add.Text = SafeConverter.GetString(_result.Added);
            lbl_update.Text = SafeConverter.GetString(_result.Reactivated);
            lbl_disabled.Text = SafeConverter.GetString(_result.Disabled);
            lbl_count.Text = SafeConverter.GetString(_result.Total);
        }

       
    }
}
