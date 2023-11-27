using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.MAIN
{
    public partial class FRM_MAIN : Form
    {
        // Form Closed
        private static FRM_MAIN frm_main;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_main = null;
        }
        public static FRM_MAIN Get_Frm_Main
        {
            get
            {
                if (frm_main == null)
                {
                    frm_main = new FRM_MAIN();
                    frm_main.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_main;
            }
        }

        // Color
        public Color color = Color.FromArgb(0, 224, 224, 224);

        // Log In Var
        public Boolean log = false;
        public Boolean fromMain = false;
        public Boolean show_home = false;

        // init Forms
        FRM_HOME frm_home = new FRM_HOME();
        FRM_TALABA frm_talba = FRM_TALABA.Get_Frm_Talaba;
        FRM_NATEG frm_nateg = new FRM_NATEG();
        FRM_AMELIN frm_amlin = new FRM_AMELIN();
        FRM_MALIAT frm_maliat = new FRM_MALIAT();
        FRM_SETTINGS frm_settings = new FRM_SETTINGS();
        BL.USERS users = new BL.USERS();
        BL.MSG msg = new BL.MSG();

        // Move Form
        int move;
        int move_x;
        int move_y;

        public FRM_MAIN()
        {
            InitializeComponent();
            if (frm_main == null)
            {
                frm_main = this;
            }

            // Empty User Data
           
            Properties.Settings.Default.user_code = 0;
            Properties.Settings.Default.user_name = "";

            // Empty Year Data

            Properties.Settings.Default.year_cod = 0;
            Properties.Settings.Default.Year_Desc = "";
            Properties.Settings.Default.MyYear = 0;
            lbl_Year.Visible = false;
            lbl_year_main.Visible = false;
        }

        // Change Pages
        private void changePages(string lbl, Panel pn)
        {
            pic_logo.BringToFront();
            pic_logo.Visible = true;
            lbl_caption.Text = lbl;
            lbl_main.Visible = true;
            lbl_main.Text = lbl;

            if (Properties.Settings.Default.year_cod != 0)
            {
                lbl_year_main.Visible = true;
            }
            else
            {
                lbl_year_main.Visible = false;
            }

            pn_home.Visible = false;
            pn_main.Controls.Clear();
            pn_main.Visible = false;
            pn_main.BringToFront();
            pn_main.Controls.Add(pn);
            trans_a.ShowSync(pn_main);

            // Change Lang

            InputLanguage.CurrentInputLanguage =
            InputLanguage.FromCulture(new System.Globalization.CultureInfo("ar-EG"));

        }
        // Change Btn Color

        private void clearColor()
        {
            btn_home.ForeColor = color;
            btn_amelin.ForeColor = color;
            btn_nataeg.ForeColor = color;
            btn_talaba.ForeColor = color;
            btn_maliat.ForeColor = color;
            btn_sittings.ForeColor = color;
        }
        // Selected Btn
        SimpleButton sel_btn;
        private void selected_btn()
        {
            sel_btn.Focus();
        }
        private void whiteColor(SimpleButton btn)
        {
            clearColor();
            sel_btn = btn;
            btn.ForeColor = Color.Chocolate;
            btn.BackColor = color;
        }
            // Get User Permission
        private void Get_Permissions(int role)
        {
            int user_id = Properties.Settings.Default.user_code;
            DataTable user_Dt = users.Get_User_Permission(user_id);
            foreach (DataRow row in user_Dt.Rows)
            {
                if (Convert.ToInt32(row["role_id"]) == role)
                {
                    Properties.Settings.Default.permission_id = Convert.ToInt32(row["permission_id"]);
                    Properties.Settings.Default.Save();
                }
            }
        }
        private void pn_topbar_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            move_x = e.X;
            move_y = e.Y;

        }
        private void pn_topbar_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void pn_topbar_MouseMove(object sender, MouseEventArgs e)
        {
            if(move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
          DialogResult  dialogResult = MessageBox.Show("هل تريد الخروج من البرنامج", " مدرسة الكوثر الخاصة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                return;
            }

        }

        private void btn_hide_nav_Click(object sender, EventArgs e)
        {
            if(pn_navbar.Width == 50)
            {
                pn_navbar.Width = 200;
            }
            else
            {
                pn_navbar.Width = 50;
            }
            if(sel_btn != null)
            {
                selected_btn();
            }
            
        }

        private void btn_max_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Maximized)
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

        private void pn_topbar_MouseDoubleClick(object sender, MouseEventArgs e)
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

        public void btn_home_Click(object sender, EventArgs e)
        {
            whiteColor(btn_home);
            changePages("الرئيسية", frm_home.pn_home);
        }


        public void pictureBox2_Click(object sender, EventArgs e)
        {
            clearColor();
            pic_logo.Visible = false;
            lbl_main.Visible = false;
            lbl_year_main.Visible = false;
            pn_home.Visible = false;
            pn_main.Visible = false;
            pn_home.BringToFront();
            trans_a.ShowSync(pn_home);
            lbl_caption.Text = "مدرسة الكوثر الخاصة";
        }
     
        private void btn_talaba_Click(object sender, EventArgs e)
        {
            whiteColor(btn_talaba);
            changePages("شئون الطلاب", frm_talba.pn_home);
            Get_Permissions(2);
        }

        private void btn_nataeg_Click(object sender, EventArgs e)
        {
            whiteColor(btn_nataeg);
            changePages("التقييمات", frm_nateg.pn_home);
            Get_Permissions(3);
        }

        private void btn_amelin_Click(object sender, EventArgs e)
        {
            whiteColor(btn_amelin);
            changePages("شئون العاملين", frm_amlin.pn_home);
            Get_Permissions(4);

        }

        private void btn_maliat_Click(object sender, EventArgs e)
        {
            whiteColor(btn_maliat);
            changePages("الشئون المالية", frm_maliat.pn_home);
            Get_Permissions(5);
        }

        private void btn_sittings_Click(object sender, EventArgs e)
        {
            if (fromMain == false)
            {
                FRM_SETTINGS.Get_Frm_Settings.group_box_login.Visible = false;
                FRM_SETTINGS.Get_Frm_Settings.pn_settings_con.Visible = true;
            }
            whiteColor(btn_sittings);
            changePages("الإعدادات", frm_settings.pn_home);
           
            fromMain = false;
            show_home = false;
        }
        private void FRM_MAIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد الخروج من البرنامج", " مدرسة الكوثر الخاصة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void link_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fromMain = true;
            Boolean isloged = log;
            FRM_SETTINGS.Get_Frm_Settings.link_login_LinkClicked(sender, e);
            FRM_SETTINGS.Get_Frm_Settings.lbl_settings.Visible = false;
            FRM_SETTINGS.Get_Frm_Settings.pn_settings_con.Visible = false;
            if (!isloged)
            {
                btn_sittings_Click(sender, e);
                FRM_SETTINGS.Get_Frm_Settings.txt_user.Focus();
                FRM_SETTINGS.Get_Frm_Settings.lbl_user.Visible = false;
            }

               InputLanguage.CurrentInputLanguage =
               InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            show_home = true;
           
           
        }

        private void pic_user_main_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            link_login.Focus();
            ActiveControl = link_login;
        }
    }
}
