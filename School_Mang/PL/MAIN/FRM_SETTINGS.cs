using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;

namespace School_Mang.PL.MAIN
{
    public partial class FRM_SETTINGS : Form
    {


        // Msg
        BL.MSG msg = new BL.MSG();
        BL.Waiting Waiting = new BL.Waiting();

        // Get BL DATA
        BL.LOGIN.CLS_LOGIN login = new BL.LOGIN.CLS_LOGIN();
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();

        DAL.TestConcation testConcation = new DAL.TestConcation();
        BL.USERS users = new BL.USERS();
        // Wating
        BL.Waiting waiting = new BL.Waiting();

        // Test servers
        byte server_kind = 0;
        string site_name = "";

        // Form Closed
        private static FRM_SETTINGS frm_settings;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_settings = null;
        }
        public static FRM_SETTINGS Get_Frm_Settings
        {
            get
            {
                if (frm_settings == null)
                {
                    frm_settings = new FRM_SETTINGS();
                    frm_settings.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_settings;
            }
        }


        public FRM_SETTINGS()
        {
            InitializeComponent();
            if (frm_settings == null)
            {
                frm_settings = this;
            }
            group_box_server.Size = new Size(450, 365);
            group_box_users.Size = new Size(713, 382);
            group_box_login.Size = new Size(450, 240);
            group_box_pass.Size = new Size(450, 240);

            group_box_login.Location = new Point(580, 210);
            group_box_pass.Location = new Point(580, 210);
            group_box_server.Location = new Point(580, 210);
            group_box_users.Location = new Point(400, 180);
            group_box_pic.Location = new Point(580, 210);
        }

        private void Add_Img_To_PictureBox(PictureBox pic)
        {
            waiting.Wait();
            int id = Properties.Settings.Default.user_code;
            try
            {
                DataTable Dt = users.Get_User_img(id);
                if (Dt.Rows[0][0].ToString() == "")
                {
                    pic.Image = Properties.Resources.img_200;
                }
                else
                {
                    byte[] image = (byte[])users.Get_User_img(id).Rows[0][0];
                    MemoryStream ms = new MemoryStream(image);
                    pic.Image = Image.FromStream(ms);
                }

            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);

            }
            finally
            {
                waiting.End_WAit();
            }
            waiting.End_WAit();

        }

        private void Check_Server(byte kind)
        {
            server_kind = kind;
            group_box_login.Visible = false;
            group_box_server.Visible = true;
            group_box_users.Visible = false;
            group_box_pic.Visible = false;
            group_box_pass.Visible = false;

            switch (server_kind)
            {
                case 0:
                    txt_server.Text = Properties.Settings.Default.Server_Name;
                    txt_databasee_name.Text = Properties.Settings.Default.DataBasee_name;
                    txt_databasee_user.Text = Properties.Settings.Default.DataBasee_User;
                    txt_databasee_pass.Text = Properties.Settings.Default.DataBasee_Pass;
                    txt_url.Text = Properties.Settings.Default.site_uri;
                    lbl_url.Text = "School Site Url";
                    break;

                case 1:
                    txt_server.Text = Properties.Settings.Default.Site_Server_Name;
                    txt_databasee_name.Text = Properties.Settings.Default.Site_DataBasee_name;
                    txt_databasee_user.Text = Properties.Settings.Default.Site_DataBasee_User;
                    txt_databasee_pass.Text = Properties.Settings.Default.Site_DataBasee_Pass;
                    txt_url.Text = Properties.Settings.Default.Site_Host_Test;
                    lbl_url.Text = "Test Server Url";
                    break;
            }

            // Change Lang

            InputLanguage.CurrentInputLanguage =
            InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
        }
        private void btn_close_b_Click(object sender, EventArgs e)
        {
            txt_server.Text = Properties.Settings.Default.Server_Name;
            txt_databasee_name.Text = Properties.Settings.Default.DataBasee_name;
            txt_databasee_user.Text = Properties.Settings.Default.DataBasee_User;
            txt_databasee_pass.Text = Properties.Settings.Default.DataBasee_Pass;
            txt_url.Text = Properties.Settings.Default.site_uri;
            group_box_server.Visible = false;
            group_box_pic.Visible = false;
            group_box_users.Visible = false;
            group_box_pass.Visible = false;

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Waiting.Wait();
            if (txt_server.Text == "")
            {
                msg.ErrorMesg("تأكد من اسم السيرفر");
                txt_server.Focus();
                Waiting.End_WAit();
                return;
            }
            if (txt_databasee_name.Text == "")
            {
                msg.ErrorMesg("تأكد من اسم قاعدة البانات");
                txt_databasee_name.Focus();
                Waiting.End_WAit();
                return;
            }
            if (txt_databasee_user.Text == "")
            {
                msg.ErrorMesg("تأكد من اسم المستخدم");
                txt_databasee_user.Focus();
                Waiting.End_WAit();
                return;
            }
            if (txt_databasee_name.Text == "")
            {
                msg.ErrorMesg("تأكد من كلمة المرور");
                txt_databasee_name.Focus();
                Waiting.End_WAit();
                return;
            }
            if(server_kind == 0)
            {
                if (txt_url.Text == "")
                {
                    msg.ErrorMesg("تأكد من عنوان الموقع");
                    txt_url.Focus();
                    Waiting.End_WAit();
                    return;
                }
            }
            
            DialogResult dialogResult = MessageBox.Show("هل تريد تغيير البيانات الخاصة بالسيرفر!!", " مدرسة الكوثر الخاصة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                Waiting.End_WAit();
                return ;
                
            }
            else
            {
                // Get Server data From  Properties.Settings
                switch (server_kind)
                {
                    case 0:
                        Properties.Settings.Default.Server_Name = txt_server.Text;
                        Properties.Settings.Default.DataBasee_name = txt_databasee_name.Text;
                        Properties.Settings.Default.DataBasee_User = txt_databasee_user.Text;
                        Properties.Settings.Default.DataBasee_Pass = txt_databasee_pass.Text;
                        Properties.Settings.Default.site_uri = txt_url.Text;
                       
                        break;

                    case 1:
                        Properties.Settings.Default.Site_Server_Name = txt_server.Text;
                        Properties.Settings.Default.Site_DataBasee_name = txt_databasee_name.Text;
                        Properties.Settings.Default.Site_DataBasee_User = txt_databasee_user.Text;
                        Properties.Settings.Default.Site_DataBasee_Pass = txt_databasee_pass.Text;
                        Properties.Settings.Default.Site_Server_Name = txt_url.Text;

                        break;
                }
                Properties.Settings.Default.Save();
                Waiting.End_WAit();
            }
            Waiting.End_WAit();
        }

       

        public void link_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Waiting.Wait();
            if (FRM_MAIN.Get_Frm_Main.log == false)
            {
                group_box_login.Visible = true;
                group_box_server.Visible = false;
                group_box_users.Visible = false;
                group_box_pic.Visible = false;
                group_box_pass.Visible = false;

                txt_user.Focus();
                Waiting.End_WAit();
            }
            else
            {
                Waiting.End_WAit();
                string user = Properties.Settings.Default.user_name;
                DialogResult dialogResult = MessageBox.Show(user + "هل تريد تسجيل الخروج!!" , " مدرسة الكوثر الخاصة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    Waiting.End_WAit();
                    return;
                }
                else
                {
                    Waiting.End_WAit();

                    // Empty Year data
                    Properties.Settings.Default.year_cod = 0;
                    Properties.Settings.Default.MyYear = 0;
                    Properties.Settings.Default.Year_Desc = "";
                    Properties.Settings.Default.Save();

                    FRM_MAIN.Get_Frm_Main.lbl_Year.Visible = false;
                    FRM_MAIN.Get_Frm_Main.lbl_year_main.Visible = false;
                  
                    // Disable Buttons
                    FRM_MAIN.Get_Frm_Main.pic_user_main.Visible = false;
                    FRM_MAIN.Get_Frm_Main.pic_main_con.Visible = false;
                    FRM_MAIN.Get_Frm_Main.lbl_user.Visible = false;
                    FRM_MAIN.Get_Frm_Main.lbl_welcome.Visible = false;
                    FRM_MAIN.Get_Frm_Main.btn_talaba.Visible = false;
                    FRM_MAIN.Get_Frm_Main.btn_nataeg.Visible = false;
                    FRM_MAIN.Get_Frm_Main.btn_maliat.Visible = false;
                    FRM_MAIN.Get_Frm_Main.btn_amelin.Visible = false;
                    FRM_MAIN.Get_Frm_Main.btn_home_Click(sender, e);

                    // Change Main Form
                    FRM_MAIN.Get_Frm_Main.link_login.Text = "تسجيل الدخول";
                    FRM_MAIN.Get_Frm_Main.link_login_main.Text = "تسجيل الدخول";
                    FRM_MAIN.Get_Frm_Main.toolTip1.ToolTipTitle = "تسجيل الدخول";

                    // Change Settings Form
                    lbl_user.Text = "";
                    link_login.Text = "تسجيل الدخول";
                    FRM_MAIN.Get_Frm_Main.log = false;
                    link_change_img.Visible = false;
                    link_chang_pass.Visible = false;
                    pn_change_Pass.Visible = false;
                    pn_change_img.Visible = false;
                    pn_users.Visible = false;
                    pn_change_year.Visible = false;
                    group_box_users.Visible = false;
                    group_box_pic.Visible = false;
                    group_box_pass.Visible = false;
                }
            }
        }

        private void link_chang_pass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            group_box_login.Visible = false;
            group_box_server.Visible = false;
            group_box_users.Visible = false;
            group_box_pic.Visible = false;
            group_box_pass.Visible = true;
            txt_old_pass.Focus();

            // Change Lang

            InputLanguage.CurrentInputLanguage =
            InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));

        }

        private void link_change_img_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            group_box_login.Visible = false;
            group_box_server.Visible = false;
            group_box_users.Visible = false;
            group_box_pic.Visible = true;
            group_box_pass.Visible = false;
            waiting.Wait();
            //int id = Properties.Settings.Default.user_code;
             
            Add_Img_To_PictureBox(pic_user);

            waiting.End_WAit();
        }

        private void link_server_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Check_Server(0);

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Waiting.Wait();
            txt_user.Text = "";
            txt_pass.Text = "";
            group_box_login.Visible = false;
            if (FRM_MAIN.Get_Frm_Main.show_home == true) 
            {
                FRM_MAIN.Get_Frm_Main.pictureBox2_Click(sender, e);
                
            }
            FRM_MAIN.Get_Frm_Main.fromMain = false;
            FRM_MAIN.Get_Frm_Main.show_home = false;

            Waiting.End_WAit();

        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            // Store Dir OpenFile Path

            BL.Globals.Dir_Path = "D:\\Rasd";

            Waiting.Wait();
            // Enable Test Con
            BL.Globals.Test_Internet_Con = true;
            
            if (testConcation.IsConnectedToInternet() == false) {
                if (msg.DialogeErrMsg("لا يوجد اتصال بالشبكة  .. هل تريد المتابعة؟") != DialogResult.Yes)
                {
                    msg.ErrorMesg("تأكد من الاتصال بالشبكة");
                    Waiting.End_WAit();
                    BL.Globals.Test_Internet_Con = true;
                    return;
                }
                else
                {
                   BL.Globals.Test_Internet_Con = false;
                   Waiting.End_WAit();
                }
            }
            try
            {
                if(login.Login(txt_user.Text, txt_pass.Text)!= null)
                {
                    DataTable Dt = login.Login(txt_user.Text, txt_pass.Text);
                    if (Dt.Rows.Count > 0)
                    {
                        MessageBox.Show("تم تسجيل الدخول بنجاح");
                        Waiting.End_WAit();
                        FRM_MAIN.Get_Frm_Main.btn_home_Click(sender, e);
                        if (FRM_MAIN.Get_Frm_Main.show_home == true)
                        {

                            FRM_MAIN.Get_Frm_Main.show_home = false;
                        }
                        FRM_MAIN.Get_Frm_Main.fromMain = false;
                        FRM_MAIN.Get_Frm_Main.log = true;

                        txt_user.Text = "";
                        txt_pass.Text = "";
                        group_box_login.Visible = false;
                        lbl_user.Visible = true;
                        lbl_user.Text = "المستخدم الحالى  : " +
                        Dt.Rows[0][1].ToString();
                        link_login.Text = "تسجيل الخروج";
                        link_change_img.Visible = true;
                        link_chang_pass.Visible = true;
                       
                        pn_change_img.Visible = true;
                        pn_settings_con.Visible = true;
                        pn_change_year.Visible = true; 
                        pn_change_Pass.Visible = true;


                        // Read Year Data From Databasse

                        DataTable dt_year = new DataTable();
                        dt_year = users.Get_Year_data();
                        Properties.Settings.Default.year_cod =Convert.ToInt32(dt_year.Rows[0][0]);
                        Properties.Settings.Default.MyYear =Convert.ToInt32(dt_year.Rows[0][1]);
                        Properties.Settings.Default.Year_Desc = dt_year.Rows[0][2].ToString();

                        FRM_MAIN.Get_Frm_Main.lbl_year_main.Visible = true;
                        FRM_MAIN.Get_Frm_Main.lbl_Year.Visible = true;

                        FRM_MAIN.Get_Frm_Main.lbl_Year.Text += (Properties.Settings.Default.MyYear-1).ToString() + " - " + Properties.Settings.Default.MyYear.ToString();
                        FRM_MAIN.Get_Frm_Main.lbl_year_main.Text  = "العام الدراسى /  " + (Properties.Settings.Default.MyYear-1).ToString() + " - " + Properties.Settings.Default.MyYear.ToString();

                        

                        // Store User Data

                        Properties.Settings.Default.user_code = Convert.ToInt32(Dt.Rows[0][0]);
                        Properties.Settings.Default.user_name = Dt.Rows[0][1].ToString();
                        Properties.Settings.Default.user_pass = txt_pass.Text;
                        Properties.Settings.Default.Save();


                        // Enable Buttons
                        FRM_MAIN.Get_Frm_Main.lbl_user.Visible = true;
                        FRM_MAIN.Get_Frm_Main.lbl_user.Text = Dt.Rows[0][1].ToString();
                        FRM_MAIN.Get_Frm_Main.lbl_welcome.Visible = true;
                       
                        
                        Add_Img_To_PictureBox(FRM_MAIN.Get_Frm_Main.pic_user_main);
                        FRM_MAIN.Get_Frm_Main.pic_main_con.Visible = true;
                        FRM_MAIN.Get_Frm_Main.pic_user_main.Visible = true;
                       
                        // Change Lable On Main
                        FRM_MAIN.Get_Frm_Main.link_login.Text = "تسجيل الخروج";
                        FRM_MAIN.Get_Frm_Main.link_login_main.Text = "تسجيل الخروج";
                        FRM_MAIN.Get_Frm_Main.toolTip1.ToolTipTitle = "تسجيل الخروج";

                        // Change Lang

                        InputLanguage.CurrentInputLanguage =
                        InputLanguage.FromCulture(new System.Globalization.CultureInfo("ar-EG"));

                        // Admin Permission
                        DataTable user_Dt = users.Get_User_Permission(Convert.ToInt32(Dt.Rows[0][0]));
                        foreach (DataRow row in user_Dt.Rows)
                        {
                            if(Convert.ToInt32(row["permission_id"]) == 1 
                                && Convert.ToInt32(row["role_id"])==1)
                            {
                                pn_users.Visible = true;
                                pn_back_up.Visible = true;
                                pn_restore_data.Visible = true;
                                pn_mange_site.Visible = true;
                                pn_site_server.Visible = true;

                            }
                            else
                            {
                                pn_users.Visible = false;
                                pn_back_up.Visible = false;
                                pn_restore_data.Visible = false;
                                pn_mange_site.Visible = false;
                                pn_site_server.Visible = false;

                            }

                            switch (Convert.ToInt32(row["role_id"]))
                            {
                                case 1:
                                    FRM_MAIN.Get_Frm_Main.btn_talaba.Visible = true;
                                    FRM_MAIN.Get_Frm_Main.btn_nataeg.Visible = true;
                                    FRM_MAIN.Get_Frm_Main.btn_maliat.Visible = true;
                                    FRM_MAIN.Get_Frm_Main.btn_amelin.Visible = true;
                                    FRM_MAIN.Get_Frm_Main.btn_site.Visible = true;

                                    break;
                                case 2:
                                    FRM_MAIN.Get_Frm_Main.btn_talaba.Visible = true;
                                    break;
                                case 3:
                                    FRM_MAIN.Get_Frm_Main.btn_nataeg.Visible = true;
                                    break;
                                case 4:
                                    FRM_MAIN.Get_Frm_Main.btn_amelin.Visible = true;
                                    break;
                                case 5:
                                    FRM_MAIN.Get_Frm_Main.btn_maliat.Visible = true;
                                    break;

                                default:
                                    FRM_MAIN.Get_Frm_Main.btn_home.Visible = true;

                                    break;
                            }

                        }
                        // Clear Vars 

                        BL.Globals.Add_From_Get_Std = false;
                        BL.Globals.Add_Osra_Data_To_Student = false;
                        BL.Globals.Elthak_Std = false;
                        BL.Globals.Open_Form_Get_osra = false;
                        BL.Globals.Update_Std_Data = false;

                        Waiting.End_WAit();
                    }
                    else
                    {
                        msg.ErrorMesg("تأكد من بيانات الدخول");
                        Waiting.End_WAit();
                    }
                }
                else
                {
                    Waiting.End_WAit();
                    return;
                }
               
                
            }catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.End_WAit();
            }
           
            Waiting.End_WAit();
        }

        private void txt_user_KeyUp(object sender, KeyEventArgs e){

            if (e.KeyCode == Keys.Enter)
            {
                if (txt_user.Text != "")
                {
                    txt_pass.Focus();
                }
                else
                {
                    msg.ErrorMesg("ادخل اسم المستخدم");
                    txt_user.Focus();
                    return;
                }
            }
        }

        private void txt_pass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_pass.Text == "")
                {
                    msg.ErrorMesg("ادخل كلمة المرور");
                    txt_pass.Focus();
                    return;
                }
                else
                {
                    btn_login_Click(sender, e);
                }
            }
        }

        private void link_users_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            group_box_login.Visible = false;
            group_box_server.Visible = false;
            group_box_users.Visible = true;
            group_box_pic.Visible = false;
            txt_user_data.Focus();
            waiting.Wait();
            if (testConcation.IsServerConnected())
            {
                dt_users_data.DataSource = users.Get_Users();
                dt_users_data.Columns["user_id"].Visible = false;
                dt_users_data.Columns["user_img"].Visible = false;
                dt_users_data.Columns["permission_id"].Visible = false;
                dt_users_data.Columns["role_id"].Visible = false;
                dt_users_data.Columns["Role_Permissions_id"].Visible = false;
                dt_users_data.Columns["User_Role_id"].Visible = false;
            }
            waiting.End_WAit();
        }

        private void btn_test_con_Click(object sender, EventArgs e)
        {
            try
            {
                waiting.Wait();
                if (testConcation.IsServerConnected(
                    txt_server.Text,
                    txt_databasee_name.Text,
                    txt_databasee_user.Text,
                    txt_databasee_pass.Text
                    ))
                {
                    msg.MyMesg("تم الإتصال بالسيرفر بنجاح .. !");
                }
                else
                {
                    msg.ErrorMesg("فشل الإتصال بقاعدة البيانات .. تحقق من السيرفر ..!");
                }

                }catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            finally
            {
                waiting.End_WAit();
            }
        }

        private void btn_close_users_Click(object sender, EventArgs e)
        {
            group_box_users.Visible = false;
            txt_user_data.Text = "";
        }

        private void btn_close_img_Click(object sender, EventArgs e)
        {
            group_box_pic.Visible = false;

        }

        private void btn_img_ok_Click(object sender, EventArgs e)
        { 
            waiting.Wait(); 
            try
            {
                if (pic_user.Image != Properties.Resources.img_200)
                {
                    MemoryStream ms = new MemoryStream();
                    pic_user.Image.Save(ms, pic_user.Image.RawFormat);
                    byte[] byteImg = ms.ToArray();
                    int id = Properties.Settings.Default.user_code;
                    users.Update_User_Img(id, byteImg);
                    Add_Img_To_PictureBox(FRM_MAIN.Get_Frm_Main.pic_user_main);
                }
               
            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.End_WAit();
            }
            
        }

        private void pic_user_Click(object sender, EventArgs e)
        {
            // Open FileDialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ملفات الصور|*.JPG;*.JPEG;*.JPE;*.JFIF;*.PNG;*.GIF;*.BMP;*.TIF;*.TIFF;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pic_user.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            pic_user_Click(sender, e);
        }

        private void txt_user_data_OnValueChanged(object sender, EventArgs e)
        {
            waiting.Wait();
            if (!testConcation.IsServerConnected())
            {
                msg.ErrorMesg("تأكد من الاتصال بالسيرفر.. !");
                return;
            }
            try
            {
                DataTable Dt = new DataTable();
                Dt = users.Search_User_Data(txt_user_data.Text);
                if (Dt != null)
                {
                    dt_users_data.DataSource = Dt;
                }

            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            finally
            {
                waiting.End_WAit();
            }
            waiting.End_WAit();
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            PL.USERS.FRM_ADD_USER frm = new USERS.FRM_ADD_USER();
            frm.ShowDialog();
        }

        private void btn_del_user_Click(object sender, EventArgs e)
        {
            string user_name = "";
            string user_id = "";

            try
            {
                if (dt_users_data.SelectedRows.Count > 0 )
                {
                    user_name = dt_users_data.CurrentRow.Cells[4].Value.ToString();
                    user_id = Convert.ToString(dt_users_data.CurrentRow.Cells[0].Value);
                }
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            
            try
            {
                if (user_name == "admin")
                {
                    msg.ErrorMesg("لا يمكن حذف مدير النظام ... !!");
                    waiting.End_WAit();
                    return;
                }

                waiting.Wait();
                if (msg.DialogeMsg("هل تريد حذف صلاحيات المستخدم .. " + user_name) == DialogResult.Yes)
                {
                    // Delete Permissions And Roles
                    if (dt_users_data.CurrentRow!= null)
                    {
                        try
                        {
                            if (msg.DialogeMsg("سوف يتم حذف المستخدم .. " + user_name) == DialogResult.Yes)
                            {
                                users.Delete_User_Permissions(
                            Convert.ToInt32(dt_users_data.CurrentRow.Cells["Role_Permissions_id"].Value),
                            Convert.ToInt32(dt_users_data.CurrentRow.Cells["User_Role_id"].Value));
                            }
                            else
                            {
                                msg.ErrorMesg("لفد قمت بإلغاء عملية الحذف .. !");
                                waiting.End_WAit();
                                return;
                            }
                               
                        }
                        catch (Exception ex) 
                        {
                            msg.ErrorMesg(ex.Message);
                            waiting.End_WAit();
                            return;
                        }                        
                    }
                    else
                    {
                        msg.ErrorMesg("يرجى تحديد المستخدم المراد حذفه ... ! ");
                        waiting.End_WAit();
                        return;
                    }
                       

                    // Count User
                   
                    int xCount = dt_users_data.Rows
                        .Cast<DataGridViewRow>()
                        .Select(row => row.Cells["user_id"].Value.ToString())
                        .Count(s => s == user_id);

                    // Delete The User If There is only one user Permission 

                    if(xCount == 1)
                    {
                       // msg.MyMesg("سوف يتم حذف المستخدم  " + user_name +"  ..!");
                        users.Delete_User(Convert.ToInt32(user_id));
                    }
                    
                    msg.MyMesg("تم حذف المستخدم   " + user_name + "  ..!");
                    dt_users_data.DataSource = users.Get_Users();
                }
                else
                {
                    msg.ErrorMesg("لفد قمت بإلغاء عملية الحذف .. !");
                }

            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            finally
            {
                waiting.End_WAit();
            }
            dt_users_data.DataSource = users.Get_Users();
        }

        private void pn_settings_con_Paint(object sender, PaintEventArgs e)
        {

        }

        private void link_chenge_year_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            group_box_login.Visible = false;
            group_box_pic.Visible = false;
            group_box_server.Visible = false;
            group_box_users.Visible = false;
            group_box_pass.Visible = false;
           
            FRM_YEAR frm = new FRM_YEAR();
            frm.ShowDialog();
        }

        private void btn_close_pass_Click(object sender, EventArgs e)
        {
            group_box_pass.Visible = false;
        }

        private void btn_change_pass_Click(object sender, EventArgs e)
        {
            if (txt_old_pass.Text == "")
            {
                msg.ErrorMesg("يجب ادخال كلمة المرور القديمة");
                txt_old_pass.Focus();
                return;
            }
            if (txt_new_pass1.Text == "")
            {
                msg.ErrorMesg("يجب ادخال كلمة المرور الجديدة");
                txt_new_pass1.Focus();
                return;
            }
            if (txt_new_pass2.Text == "")
            {
                msg.ErrorMesg("يجب تأكيد كلمة المرور الجديدة");
                txt_new_pass2.Focus();
                return;
            }
            if (txt_new_pass1.Text != txt_new_pass2.Text)
            {
                msg.ErrorMesg("كلمة المرور الجديدة غير مطابقة");
                txt_new_pass2.Focus();
                return;
            }
            string user_name = Properties.Settings.Default.user_name;
            waiting.Wait();
           try
            {
                if (login.Login(user_name, txt_old_pass.Text) != null)
                {
                    DataTable Dt = login.Login(user_name , txt_old_pass.Text);
                    if (Dt.Rows.Count > 0)
                    {
                        login.Change_PassWord(user_name, txt_new_pass2.Text);
                        msg.MyMesg("تم تغيير كلمة المرور بنجاح ... !");
                        group_box_pass.Visible = false;
                        txt_old_pass.Text = "";
                        txt_new_pass1.Text = "";
                        txt_new_pass2.Text = "";
                    }
                    else
                    {
                        msg.ErrorMesg("لم يتم تغيير كلمة المرور .. !");
                    }
                }
            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            finally
            {
                waiting.End_WAit();
            }

            waiting.End_WAit();
        }

        private void dt_users_data_Leave(object sender, EventArgs e)
        {
            btn_del_user.Enabled = false;
            btn_edit_user.Enabled = false;
            btn_add_perm.Enabled = false;
        }

        private void dt_users_data_MouseClick(object sender, MouseEventArgs e)
        {
            btn_del_user.Enabled = true;
            btn_edit_user.Enabled = true;
            btn_add_perm.Enabled = true;
        }

        private void Edit_User()
        {
            if (dt_users_data.CurrentRow.Cells["اسم المستخدم"].Value.ToString() == "admin")
            {
                msg.ErrorMesg("لا يمكن تعديل صلاحيات مدير النظام ... !!");
                waiting.End_WAit();
                return;
            }

            USERS.FRM_ADD_USER frm = new USERS.FRM_ADD_USER();
            frm.txt_user.Text = dt_users_data.CurrentRow.Cells["اسم المستخدم"].Value.ToString();
            frm.txt_user_role_id.Text = dt_users_data.CurrentRow.Cells["User_Role_id"].Value.ToString();
            frm.txt_role_permissions_id.Text = dt_users_data.CurrentRow.Cells["Role_Permissions_id"].Value.ToString();
            frm.txt_user_id.Text = dt_users_data.CurrentRow.Cells["user_id"].Value.ToString();

            // Old Role And Permissions

            frm.old_role_id = Convert.ToInt32(dt_users_data.CurrentRow.Cells["role_id"].Value);
            frm.old_permission_id = Convert.ToInt32(dt_users_data.CurrentRow.Cells["permission_id"].Value);
           
            frm.txt_pass.Enabled = false;
            frm.txt_user.Enabled = false;


            switch (dt_users_data.CurrentRow.Cells["role_id"].Value)
            {
                case 1:
                    frm.chk_admin.Checked = true;
                    break;
                case 2:
                    frm.chk_talba.Checked = true;
                    break;
                case 3:
                    frm.chk_takimat.Checked = true;
                    break;
                case 4:
                    frm.chk_amlin.Checked = true;
                    break;
                case 5:
                    frm.chk_maliat.Checked = true;
                    break;

            }
            switch (dt_users_data.CurrentRow.Cells["permission_id"].Value)
            {
                case 1:
                    frm.chk_all_prem.Checked = true;
                    break;
                case 2:
                    frm.chk_some_perm.Checked = true;
                    break;
                case 3:
                    frm.chk_read.Checked = true;
                    break;
            }
            frm.ShowDialog();
        }
        private void btn_edit_user_Click(object sender, EventArgs e)
        {

            BL.Globals.EditUser = true;
            BL.Globals.Add_User_Permission = false;
            Edit_User();

        }

        private void btn_add_perm_Click(object sender, EventArgs e)
        {
          
            BL.Globals.Add_User_Permission = true;
            BL.Globals.EditUser = false;

            Edit_User();


        }

        private void link_bake_up_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BL.Globals.Restore_DataBase = false;
            FRM_BACK_UP frm = new FRM_BACK_UP();
            frm.ShowDialog();
        }

        private void lbl_restore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BL.Globals.Restore_DataBase = true;
            FRM_BACK_UP frm = new FRM_BACK_UP();
            frm.ShowDialog();
        }

        private void link_mange_site_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();
            // Get Mange Site Form
            natag_func.changePages(FRM_MANGE_SITE.Get_Frm_Mange_Site.pn_home, "إدارة الموقع");
        }

        private void link_site_server_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Check_Server(1);
        }
    }
}
