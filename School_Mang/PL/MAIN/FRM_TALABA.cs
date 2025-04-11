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
        BL.Waiting waiting = new BL.Waiting();

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

            // Set User permission
            switch (Properties.Settings.Default.permission_id)
            {
                case 3:
                    card_new.Visible = false;
                    break;
                case 1:
                case 2:
                    card_new.Visible = true;
                    break;
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

        // Hide New Year
        private void cheack_New_Year()
        {
            // Get Year

            STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.lbl_year.Text = Properties.Settings.Default.Year_Desc;
            STD.HOME.FRM_STD_REPORTS.Get_Frm_Std_Reports.lbl_cruunt_year.Text = Properties.Settings.Default.Year_Desc;
            int new_year = Properties.Settings.Default.MyYear + 1;
            STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.lbl_new_year.Text = std.Get_years(new_year).Rows[0][1].ToString();
            STD.HOME.FRM_STD_REPORTS.Get_Frm_Std_Reports.lbl_new_year.Text = std.Get_years(new_year).Rows[0][1].ToString();

            // Hide New Year Card If There Is no Student On New Year
            int year_code = Properties.Settings.Default.year_cod + 1;
            DataTable dt_count;
            dt_count = std.Get_School_year_Data(year_code, 0, 0);
            if (dt_count.Rows.Count == 0)
            {
                STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.card_new_year.Visible = false;
                STD.HOME.FRM_STD_REPORTS.Get_Frm_Std_Reports.card_new_year.Visible = false;
            }
            else
            {
                STD.HOME.FRM_STD_DATA.Get_Frm_Std_Data.card_new_year.Visible = true;
                STD.HOME.FRM_STD_REPORTS.Get_Frm_Std_Reports.card_new_year.Visible = true;

            }
        }
        private void pic_age_Click(object sender, EventArgs e)
        {
            STD.FRM_HESAB_SEN frm_sen = new STD.FRM_HESAB_SEN();
            frm_sen.ShowDialog();
        }

        private void lbl_age_Click(object sender, EventArgs e)
        {
            pic_age_Click(sender, e);
        }

        private void pic_add_std_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Form_Get_osra = false;
            STD.FRM_ADD_STD.getAdd_Std_Frm.ShowDialog();
        }

        private void pic_elthak_Click(object sender, EventArgs e)
        {
            BL.Globals.Elthak_Std = true;
            BL.Globals.Elthak_Std_Next_Year = false;

            STD.FRM_GET_STD.Get_Student.ShowDialog();
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
                // Get Data From dataBase
                cheack_New_Year();

                // Test Permissions
                int user = Properties.Settings.Default.user_code;
                DataTable dt_user = users.Get_User_Permission(user);
                if (dt_user.Rows[0]["role_id"].ToString() == "1" &&
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
            // Hide New Year Data
            cheack_New_Year();
            // Get Std Data Form
            changePages(STD.HOME.FRM_STD_REPORTS.Get_Frm_Std_Reports.pn_std_home, "تقارير - احصائيات");
        }

        private void pic_ehsaa_Click(object sender, EventArgs e)
        {
            lbl_ehsaa_Click(sender, e);
        }

        private void lbl_eltehak_old_Click(object sender, EventArgs e)
        {
            BL.Globals.Elthak_Std = true;
            STD.FRM_CURRENT_STD.Get_Current_Std.ShowDialog();
        }

        private void pic_eltehak_old_Click(object sender, EventArgs e)
        {
            lbl_eltehak_old_Click(sender, e);
        }

        private void lbl_bian_dragat_Click(object sender, EventArgs e)
        {

            waiting.Wait();
            BL.Globals.Current_Year_Data = true;
            BL.Globals.Degree_Statement = true;
            STD. FRM_CHOOSE_GRADE frm = new STD.FRM_CHOOSE_GRADE();
            frm.ShowDialog();
        }

        private void pic_bian_dragat_Click(object sender, EventArgs e)
        {
            lbl_bian_dragat_Click(sender, e);
        }

        private void pic_elthak_next_year_Click(object sender, EventArgs e)
        {
            BL.Globals.Elthak_Std_Next_Year = true;
            BL.Globals.Elthak_Std = false;

            STD.FRM_CURRENT_STD.Get_Current_Std.grade = 11;
            STD.FRM_CURRENT_STD.Get_Current_Std.ShowDialog();
        }

        private void lbl_elthak_next_year_Click(object sender, EventArgs e)
        {
            pic_elthak_next_year_Click(sender, e);
        }

        private void FRM_TALABA_Load(object sender, EventArgs e)
        {
            BL.Globals.Elthak_Std = false;
            BL.Globals.Elthak_Std_Next_Year = false;
        }
    }
}
