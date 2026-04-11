using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.BL.Common.Helper;

namespace School_Mang.PL.SITE
{
    public partial class FRM_COUNT_USERS : Form
    {
        BL.SITE.CLS_MANGE_SITE site = new BL.SITE.CLS_MANGE_SITE();
        BL.Waiting Waiting = new BL.Waiting();
        BL.MSG msg = new BL.MSG();

        // Form Closed
        private static FRM_COUNT_USERS Frm_Count_Users;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            Frm_Count_Users = null;
        }
        public static FRM_COUNT_USERS Get_Frm_Count_Users
        {
            get
            {
                if (Frm_Count_Users == null)
                {
                    Frm_Count_Users = new FRM_COUNT_USERS();
                    Frm_Count_Users.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return Frm_Count_Users;
            }
        }

        public FRM_COUNT_USERS()
        {
            InitializeComponent();

            if (Frm_Count_Users == null)
            {
                Frm_Count_Users = this;
            }

            Load_Data();
        }

        int move;
        int move_x;
        int move_y;

       
        private async void Load_Data()
        {

            bool isConncted = await InternetHelper.CheckInternetAsync();

            if (!isConncted)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                this.Close();
                return;
            }
            else
            {
                try
                {
                    Waiting.Wait();
                    DataTable Dt;
                    Dt = site.Get_Count_Users_Data();
                    if (Dt != null)
                    {
                        dt_std_data.DataSource = Dt;
                        dt_std_data.Columns["id"].Visible = false;
                        dt_std_data.CurrentCell = dt_std_data.Rows[0].Cells[1];
                    }
                    else
                    {
                        Waiting.End_WAit();
                        msg.ErrorMesg("حدث خطأ فى الإتصال..!");
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    Waiting.End_WAit();
                    msg.ErrorMesg(ex.Message);
                }
            }
            Waiting.End_WAit();
        }

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

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_show_data_Click(object sender, EventArgs e)
        {
            bool isConncted = await InternetHelper.CheckInternetAsync();

            if (!isConncted)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }
            try
            {
                Waiting.Wait();
                int grde =Convert.ToInt32(dt_std_data.CurrentRow.Cells["id"].Value);
                BL.Globals.test_grade_id = grde;
                FRM_SITE_USER_DATA.Get_Frm_Site_User_Data.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
                Waiting.End_WAit();
            }
            catch(Exception ex)
            {
                Waiting.End_WAit();
                msg.ErrorMesg(ex.Message);
            }
        }

        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            btn_show_data_Click(sender, e);
        }

        private void FRM_COUNT_USERS_Load(object sender, EventArgs e)
        {
                        
        }

    }
}
