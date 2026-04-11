using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.PL.NATIGA;
using School_Mang.BL.Common.Helper;

namespace School_Mang.PL.SITE
{
    public partial class FRM_UNMATCH_DATA : Form
    {
        new readonly BL.SITE.CLS_MANGE_SITE Site = new BL.SITE.CLS_MANGE_SITE();
        BL.Waiting Waiting = new BL.Waiting();
        BL.MSG msg = new BL.MSG();
       


        // Form Closed
        private static FRM_UNMATCH_DATA Frm_UnMatch_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            Frm_UnMatch_Data = null;
        }
        public static FRM_UNMATCH_DATA Get_Frm_UnMatch_Data
        {
            get
            {
                if (Frm_UnMatch_Data == null)
                {
                    Frm_UnMatch_Data = new FRM_UNMATCH_DATA();
                    Frm_UnMatch_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return Frm_UnMatch_Data;
            }
        }

        public FRM_UNMATCH_DATA()
        {
            InitializeComponent();

            if (Frm_UnMatch_Data == null)
            {
                Frm_UnMatch_Data = this;
            }
            Load_Data();
           
        }

        int move;
        int move_x;
        int move_y;
        public DataTable Dt_Un_Mathed;

        

        public async void Load_Data()
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

                    
                    if (Dt_Un_Mathed != null)
                    {
                        dt_std_data.DataSource = Dt_Un_Mathed;
                        if (BL.Globals.Get_Site_Data)
                        {
                            dt_std_data.Columns["user_id"].Visible = false;
                            dt_std_data.Columns["user_role_id"].Visible = false;
                            dt_std_data.Columns["user_role_id"].Visible = false;

                            dt_std_data.Columns["Golos"].HeaderText = "رقم الجلوس";
                            dt_std_data.Columns["Golos"].Width = 100;

                            dt_std_data.Columns["fullName"].HeaderText = "اسم الطالب";
                            dt_std_data.Columns["fullName"].Width = 300;

                            dt_std_data.Columns["grade_desc"].HeaderText = "الصف";

                            dt_std_data.Columns["class_desc"].HeaderText = "الفصل";

                            dt_std_data.Rows[0].Cells[1].Selected = true;
                        }
                        else
                        {
                            dt_std_data.Columns["std_code"].Visible = false;

                            dt_std_data.Columns["stdunet_name"].HeaderText = "اسم الطالب";
                            dt_std_data.Columns["stdunet_name"].Width = 80;
                            dt_std_data.Columns["GradeDesc"].HeaderText = "الصف";
                            dt_std_data.Columns["Class_Desc"].HeaderText = "الفصل";
                            dt_std_data.Columns["Golos"].HeaderText = "رقم الجلوس";

                            dt_std_data.Columns["Grade_Id"].Visible = false;
                            dt_std_data.Columns["Class_No"].Visible = false;
                            dt_std_data.Columns["Class_Id"].Visible = false;
                            dt_std_data.Columns["Religion_Id"].Visible = false;
                            dt_std_data.Columns["ReligionDesc"].Visible = false;
                            dt_std_data.Columns["Gender_Id"].Visible = false;
                            dt_std_data.Columns["GenderDesc"].Visible = false;
                            dt_std_data.Columns["Year_Id"].Visible = false;
                            dt_std_data.Columns["Year"].Visible = false;
                            dt_std_data.Columns["YearDesc"].Visible = false;
                            dt_std_data.Columns["std_date"].Visible = false;
                            dt_std_data.Columns["GradeStage"].Visible = false;
                            dt_std_data.Columns["Sery"].Visible = false;
                        }
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
            this.Close();
        }

        private async void btn_show_data_Click(object sender, EventArgs e)
        {
            int std_code = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Golos"].Value);
            bool isConncted = await InternetHelper.CheckInternetAsync();

            if (!isConncted)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }

            try
            {
                this.Hide();
                BL.Globals.From_Un_Matched = true;

                if (BL.Globals.Get_Site_Data)
                {
                    // Get Vars
                    DataTable std_Dt;
                    std_Dt = Site.Get_Users_Data(std_code);

                    int std_cod = Convert.ToInt32(std_Dt.Rows[0]["رقم الجلوس"]);
                    string std_first_name = std_Dt.Rows[0]["firstName"].ToString();
                    string std_full_name = std_Dt.Rows[0]["اسم الطالب"].ToString();
                    byte std_grade = Convert.ToByte(std_Dt.Rows[0]["grade_Id"]);
                    byte std_class = Convert.ToByte(std_Dt.Rows[0]["clas_id"]);
                    byte std_relagine = Convert.ToByte(std_Dt.Rows[0]["religion_Id"]);
                    byte std_gender = Convert.ToByte(std_Dt.Rows[0]["gender_Id"]);


                    // Open Form To Edit std

                    FRM_UPDATE_USER_DATA.Get_Update_User_Data.txt_std_code.Text = std_cod.ToString();
                    FRM_UPDATE_USER_DATA.Get_Update_User_Data.txt_first_name.Text = std_first_name;
                    FRM_UPDATE_USER_DATA.Get_Update_User_Data.txt_std_name.Text = std_full_name;
                    FRM_UPDATE_USER_DATA.Get_Update_User_Data.cmb_grade.SelectedValue = std_grade;
                    FRM_UPDATE_USER_DATA.Get_Update_User_Data.cmb_class.SelectedValue = std_class;
                    FRM_UPDATE_USER_DATA.Get_Update_User_Data.cmb_gender.SelectedValue = std_gender;
                    FRM_UPDATE_USER_DATA.Get_Update_User_Data.cmb_relgien.SelectedValue = std_relagine;
                    

                    FRM_UPDATE_USER_DATA.Get_Update_User_Data.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
                }
                else
                {
                    try
                    {  
                        // Get Vars
                        int grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
                        string code = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
                        string std_name = dt_std_data.CurrentRow.Cells["stdunet_name"].Value.ToString();
                        string golos = dt_std_data.CurrentRow.Cells["Golos"].Value.ToString();
                        string grade_desc = dt_std_data.CurrentRow.Cells["GradeDesc"].Value.ToString();
                        string class_desc = dt_std_data.CurrentRow.Cells["Class_Desc"].Value.ToString();
                        string year_desc = dt_std_data.CurrentRow.Cells["YearDesc"].Value.ToString();

                        if (golos == "") golos = "0";

                        this.Hide();

                        FRM_EDIT_GOLOS.Get_frm_Edit_Golos.golos = Convert.ToInt32(golos);
                        FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_code.Text = code;
                        FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_std_name.Text = std_name;
                        FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_golos.Text = golos;
                        FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_grade.Text = grade_desc;
                        FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_class.Text = class_desc;
                        FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_year.Text = year_desc;

                        FRM_EDIT_GOLOS.Get_frm_Edit_Golos.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);

                    }
                    catch (Exception ex)
                    {
                        msg.ErrorMesg(ex.Message);
                        Waiting.End_WAit();
                    }
                }
               
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                Waiting.End_WAit();
            }
        }


        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            btn_show_data_Click(sender, e);
        }
    }
}
