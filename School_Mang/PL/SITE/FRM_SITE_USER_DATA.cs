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
    public partial class FRM_SITE_USER_DATA : Form
    {
        BL.SITE.CLS_MANGE_SITE site = new BL.SITE.CLS_MANGE_SITE();
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.Waiting Waiting = new BL.Waiting();
        BL.MSG msg = new BL.MSG();

        // Form Closed
        private static FRM_SITE_USER_DATA Frm_Site_User_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            Frm_Site_User_Data = null;
        }
        public static FRM_SITE_USER_DATA Get_Frm_Site_User_Data
        {
            get
            {
                if (Frm_Site_User_Data == null)
                {
                    Frm_Site_User_Data = new FRM_SITE_USER_DATA();
                    Frm_Site_User_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return Frm_Site_User_Data;
            }
        }


        public FRM_SITE_USER_DATA()
        {
            InitializeComponent();

            if (Frm_Site_User_Data == null)
            {
                Frm_Site_User_Data = this;
            }

            dt_std_data.MouseDown += new MouseEventHandler(this.dt_std_data_MouseClick);

            Waiting.Wait();
            DataTable grade_dt = std.Get_grades();

            DataRow dr = grade_dt.NewRow();
            dr["GradeDesc"] = "الكل";
            dr["Grade_Id"] = 0;
            grade_dt.Rows.InsertAt(dr, 0);

            cmb_grade.DataSource = grade_dt;
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            cmb_grade.SelectedIndex = 0;

            is_cmb_grade_selected = true;
            txt_std_data.Text = "";

            byte grade = Convert.ToByte(BL.Globals.test_grade_id);
            Load_Data(grade);
            
            Waiting.End_WAit();
        }

        
        private async void Load_Data(byte grade)
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

                if (BL.Globals.Get_User_Data)
                {
                    // Get User Data From School DataBase
                    try
                    {
                        Waiting.Wait();
                        DataTable users;
                        users = std.Get_Data_For_Site();
                        dt_std_data.DataSource = null;
                        dt_std_data.DataSource = users;

                        if (users != null)
                        {
                            dt_std_data.Columns["std_name"].Visible = false;
                            dt_std_data.Columns["father_name"].Visible = false;
                            dt_std_data.Columns["Grade_Id"].Visible = false;
                            dt_std_data.Columns["Class_Id"].Visible = false;
                            dt_std_data.Columns["Religion_Id"].Visible = false;
                            dt_std_data.Columns["Gender_Id"].Visible = false;
                            dt_std_data.Columns["Year_Id"].Visible = false;
                            dt_std_data.Columns["std_nat"].Visible = false;

                            dt_std_data.Columns["stdunet_full_name"].Width = 250;
                            dt_std_data.Columns["stdunet_full_name"].HeaderText = "اسم الطالب";

                            dt_std_data.Columns["Golos"].HeaderText = "رقم الجلوس";
                            dt_std_data.Columns["Golos"].Width = 130;
                            dt_std_data.Columns["std_code"].HeaderText = "كود الطالب";
                            dt_std_data.Columns["GradeDesc"].HeaderText = "الصف";

                            lbl_count.Text = users.Rows.Count.ToString();
                            lbl_title.Text = "  بيانات الطلاب  ";

                        }
                        else
                        {
                            msg.ErrorMesg("حدث خطأ فى الإتصال..!");
                            this.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        msg.ErrorMesg(e.Message);
                        Waiting.End_WAit();
                    }
                    finally
                    {
                        Waiting.End_WAit();
                    }
                }
                else
                {
                    //Get Site Data
                    try
                    {
                        Waiting.Wait();
                        DataTable users;
                        users = site.Get_Users_Data(grade);
                        dt_std_data.DataSource = null;
                        dt_std_data.DataSource = users;
                        if (users != null)
                        {
                            dt_std_data.Columns["clas_id"].Visible = false;
                            dt_std_data.Columns["grade_Id"].Visible = false;
                            dt_std_data.Columns["gender_Id"].Visible = false;
                            dt_std_data.Columns["religion_Id"].Visible = false;
                            dt_std_data.Columns["firstName"].Visible = false;
                            dt_std_data.Columns["stdCode"].Visible = false;

                            dt_std_data.Columns[0].Width = 120;
                            dt_std_data.Columns[1].Width = 250;
                            lbl_count.Text = users.Rows.Count.ToString();
                            lbl_title.Text = "بيانات المستخدمين";
                        }
                        else
                        {
                            msg.ErrorMesg("حدث خطأ فى الإتصال..!");
                            this.Close();
                        }

                        Waiting.End_WAit();

                    }
                    catch (Exception e)
                    {
                        msg.ErrorMesg(e.Message);
                        Waiting.End_WAit();
                    }
                    finally
                    {
                        Waiting.End_WAit();
                    }
                }

            }
            Waiting.End_WAit();

        }
        int move;
        int move_x;
        int move_y;
        bool is_cmb_grade_selected;

        private async void Check_data()
        {
            bool isConncted = await InternetHelper.CheckInternetAsync();

            if (!isConncted)
            {
                //msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }

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
            BL.Globals.Get_User_Data = false;

        }

        private async void btn_show_data_Click(object sender, EventArgs e)
        {

            int std_code = Convert.ToInt32(dt_std_data.CurrentRow.Cells["رقم الجلوس"].Value);
            bool isConncted = await InternetHelper.CheckInternetAsync();

            if (!isConncted)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }

            if (BL.Globals.Get_User_Data)
            {
                try
                {
                    // Add User Data To Form
                    Close();
                    BL.Globals.Get_User_Data = false;
                }
                catch (Exception ex)
                {
                    msg.ErrorMesg(ex.Message);
                }
            }

            try
            {
                DataTable std_Dt;
                std_Dt = site.Get_Users_Data(std_code);

                // Open Edit Form
                this.Hide();
                string stdCode = std_Dt.Rows[0]["stdCode"].ToString();
                int Golos = Convert.ToInt32(std_Dt.Rows[0]["رقم الجلوس"]);
                string std_first_name = std_Dt.Rows[0]["firstName"].ToString();
                string std_full_name = std_Dt.Rows[0]["اسم الطالب"].ToString();
                byte std_grade = Convert.ToByte(std_Dt.Rows[0]["grade_Id"]);
                byte std_class = Convert.ToByte(std_Dt.Rows[0]["clas_id"]);
                byte std_relagine = Convert.ToByte(std_Dt.Rows[0]["religion_Id"]);
                byte std_gender = Convert.ToByte(std_Dt.Rows[0]["gender_Id"]);


                FRM_UPDATE_USER_DATA.Get_Update_User_Data.txt_std_code.Text = Golos.ToString();
                FRM_UPDATE_USER_DATA.Get_Update_User_Data.txt_first_name.Text = std_first_name;
                FRM_UPDATE_USER_DATA.Get_Update_User_Data.txt_std_name.Text = std_full_name;
                FRM_UPDATE_USER_DATA.Get_Update_User_Data.cmb_grade.SelectedValue = std_grade;
                FRM_UPDATE_USER_DATA.Get_Update_User_Data.cmb_class.SelectedValue = std_class;
                FRM_UPDATE_USER_DATA.Get_Update_User_Data.cmb_gender.SelectedValue = std_gender;
                FRM_UPDATE_USER_DATA.Get_Update_User_Data.cmb_relgien.SelectedValue = std_relagine;
                FRM_UPDATE_USER_DATA.Get_Update_User_Data.txt_stdCode.Text = stdCode;

                FRM_UPDATE_USER_DATA.Get_Update_User_Data.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);

            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                Waiting.End_WAit();
            }
        }

        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم";
            lbl_help.Visible = true;
        }

        private void pic_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txt_std_data.Focus();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void txt_std_data_Enter(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void txt_std_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            pic_help_MouseHover(sender, e);
            is_cmb_grade_selected = false;
            // cmb_grade_SelectedIndexChanged(sender, e);

        }

        private void txt_std_data_MouseLeave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void FRM_SITE_USER_DATA_Load(object sender, EventArgs e)
        {

            cmb_grade.SelectedValue = BL.Globals.test_grade_id;

        }

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {

            Waiting.Wait();
            if (cmb_grade.Focused == true)
            {
                is_cmb_grade_selected = true;

                byte new_grade = Convert.ToByte(cmb_grade.SelectedValue);
                DataTable users;

                // Get User Data From School DataBase
                if (BL.Globals.Get_User_Data)
                {
                    users = std.Get_Data_For_Site(new_grade);
                    dt_std_data.DataSource = users;
                    lbl_count.Text = users.Rows.Count.ToString();
                    BL.Globals.test_grade_id = Convert.ToInt32(new_grade);
                    txt_std_data.Text = "";
                    is_cmb_grade_selected = true;
                    Waiting.End_WAit();
                    return;
                }
                // Get Site Data 
                Check_data();


                users = site.Get_Users_Data(new_grade);
                dt_std_data.DataSource = users;
                lbl_count.Text = users.Rows.Count.ToString();
                BL.Globals.test_grade_id = Convert.ToInt32(new_grade);
                txt_std_data.Text = "";
                is_cmb_grade_selected = true;
                Waiting.End_WAit();
            }
            Waiting.End_WAit();
        }

        private void copy_Click(Object sender, EventArgs e)
        {
            if (this.dt_std_data.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    string pass = this.dt_std_data.CurrentRow.Cells["اسم المستخدم"].Value.ToString();
                    Clipboard.SetDataObject(pass);
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    MessageBox.Show("Clipboard could not be accessed. Please try again.");
                }
            }

        }
        private void dt_std_data_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                ContextMenu cm = new ContextMenu();
                this.ContextMenu = cm;

                cm.MenuItems.Add(new MenuItem("&Copy", new EventHandler(this.copy_Click)));

                cm.Show(this, new Point(e.X, e.Y + 100));
            }

        }

        private void btn_absent_std_Click(object sender, EventArgs e)
        {
            msg.ErrorMesg("هذا الإجراء غير متاح ..!");
        }

        public async void txt_std_data_OnValueChanged(object sender, EventArgs e)
        {
            // Cheack If Comb Grade is Changed To Cansel The Void
            if (is_cmb_grade_selected) return;

            string std_name = txt_std_data.Text;
            int grade = Convert.ToInt32(cmb_grade.SelectedValue);
            DataTable Dt;
            // Search User Data
            if (BL.Globals.Get_User_Data)
            {
                try
                {
                    Dt = std.Get_Data_For_Site(grade, std_name);
                    dt_std_data.DataSource = Dt;
                    lbl_count.Text = Dt.Rows.Count.ToString();

                }
                catch (Exception ex)
                {
                    msg.ErrorMesg(ex.Message);
                }

                return;
            }
            // Search Site Data
            bool isConncted = await InternetHelper.CheckInternetAsync();

            if (!isConncted)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }
            try
            {
                Dt = site.Get_Users_Data(std_name);
                dt_std_data.DataSource = Dt;
                lbl_count.Text = Dt.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }
    }
}
