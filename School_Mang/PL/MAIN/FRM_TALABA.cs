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
    public partial class FRM_TALABA : Form
    {
        // Get Std
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.USERS users = new BL.USERS();
        BL.MSG msg = new BL.MSG();

        // Form Closed
        private static FRM_TALABA frm_Talaba;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Talaba = null;
        }
        public static FRM_TALABA Get_Frm_Talaba
        {
            get
            {
                if (frm_Talaba == null)
                {
                    frm_Talaba = new FRM_TALABA();
                    frm_Talaba.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Talaba;
            }
        }

        public FRM_TALABA()
        {
            InitializeComponent();

            if (frm_Talaba == null)
            {
                frm_Talaba = this;
            }
            
        }

        // Change Pages
        private void changePages(Panel pn, string lbl)
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

        private void pic_age_Click(object sender, EventArgs e)
        {
            STD.FRM_HESAB_SEN frm_sen = new  STD.FRM_HESAB_SEN();
            frm_sen.ShowDialog();
        }

        private void lbl_age_Click(object sender, EventArgs e)
        {
            pic_age_Click(sender,e);
        }

        private void pic_add_std_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Form_Get_osra = false;
            STD.FRM_ADD_STD frm_add_std = new STD.FRM_ADD_STD();
            frm_add_std.ShowDialog();
        }

        private void pic_elthak_Click(object sender, EventArgs e)
        {
            BL.Globals.Elthak_Std = true;

            STD.FRM_GET_STD frm = new STD.FRM_GET_STD();
            frm.ShowDialog();
        }

        private void lbl_add_std_Click(object sender, EventArgs e)
        {
            pic_add_std_Click(sender, e);
        }
 

        private void lbl_elthak_Click(object sender, EventArgs e)
        {
            pic_elthak_Click(sender, e);
        }

        private void pic_current_stds_Click(object sender, EventArgs e)
        {
            lbl_current_stds_Click(sender, e);
        }


        private void lbl_current_stds_Click(object sender, EventArgs e)
        {
            try
            {

                // Get Year

                STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.lbl_year.Text = Properties.Settings.Default.Year_Desc;
                int new_year = Properties.Settings.Default.MyYear + 1;
                STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.lbl_new_year.Text = std.Get_years(new_year).Rows[0][1].ToString();

                // Hide New Year Card If There Is no Student On New Year
                int year_code = Properties.Settings.Default.year_cod+1;
                DataTable dt_count;
                dt_count = std.Get_School_year_Data(year_code, 0, 0);
                if (dt_count.Rows.Count == 0)
                {
                    STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.card_new_year.Visible = false;
                }
                else
                {
                    STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.card_new_year.Visible = true;
                }

                // Test Permissions
                int user = Properties.Settings.Default.user_code;
                DataTable dt_user = users.Get_User_Permission(user);
                if(dt_user.Rows[0]["role_id"].ToString() == "1" &&
                    dt_user.Rows[0]["permission_id"].ToString() == "1")
                {
                    STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.card_update_data.Visible = true;
                }
                else
                {
                    STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.card_update_data.Visible = false;
                }
                // Get Std Data Form
                changePages(STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.pn_std_home, "بيانات الطلاب");
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void lbl_tahwelat_Click(object sender, EventArgs e)
        {
            PL.STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.lbl_tahwelat_Click(sender, e);
        }

        private void pic_tahwelat_Click(object sender, EventArgs e)
        {
            lbl_tahwelat_Click(sender, e);
        }

        private void lbl_ehsaa_Click(object sender, EventArgs e)
        {
            // Get Std Data Form
            changePages(STD.HOME.FRM_STD_REPORTS.Get_Frm_Std_Reports.pn_std_home, "تقارير - احصائيات");
        }
    }
}
