using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace School_Mang.PL.STD
{
    public partial class FRM_UPDATE_SCHOOL_STD : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.MSG msg = new BL.MSG();
        BL.Waiting Waiting = new BL.Waiting();
        CLS_STD_FUNCATIONS Std_Func = new CLS_STD_FUNCATIONS();
        CLS_STD_FUNCATIONS function = new CLS_STD_FUNCATIONS();

        BL.HESAB_SEN Hesab_sen = new BL.HESAB_SEN();
        string[] sen = { };

        public int grade = 1;
        public int row_index = 0;
        int status;

        int permission_id = Properties.Settings.Default.permission_id;

        // Form Closed
        private static FRM_UPDATE_SCHOOL_STD frm_Update_School_Std;

        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Update_School_Std = null;
        }
        public static FRM_UPDATE_SCHOOL_STD Get_Update_School_Std
        {
            get
            {
                if (frm_Update_School_Std == null)
                {
                    frm_Update_School_Std = new FRM_UPDATE_SCHOOL_STD();
                    frm_Update_School_Std.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Update_School_Std;
            }
        }


        public FRM_UPDATE_SCHOOL_STD()
        {
            InitializeComponent();

            if (frm_Update_School_Std == null)
            {
                frm_Update_School_Std = this;
            }
            // Fill Combos

            cmb_sana.DataSource = std.Get_years();
            cmb_sana.DisplayMember = "YearDesc";
            cmb_sana.ValueMember = "Year_Id";

            cmb_grade.DataSource = std.Get_grades();
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            cmb_hala.DataSource = std.Get_stdStat();
            cmb_hala.DisplayMember = "StatusDesc";
            cmb_hala.ValueMember = "Std_Status_Id";

            cmb_gender.DataSource = std.Get_genders();
            cmb_gender.DisplayMember = "GenderDesc";
            cmb_gender.ValueMember = "Gender_Id";
            
            cmb_relgien.DataSource = std.Get_religion();
            cmb_relgien.DisplayMember = "ReligionDesc";
            cmb_relgien.ValueMember = "Religion_Id";

            cmb_class.DataSource = std.Get_Class_Id(grade);
            cmb_class.DisplayMember = "Class_Desc";
            cmb_class.ValueMember = "Class_Id";

            // Set User permission
            if (permission_id == 3)
            {
                btn_save_data.Enabled = false;
            }
            else
            {
                btn_save_data.Enabled = true;
            }

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

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_class.DataSource = std.Get_Class_Id(Convert.ToInt32(cmb_grade.SelectedValue));
        }

        private void btn_save_data_Click(object sender, EventArgs e)
        {

            try
            {
                // If Hala = 3 Or 4
                if(cmb_hala.Enabled == true)
                {
                    if (Convert.ToInt32(cmb_hala.SelectedValue) == 3 ||
                   Convert.ToInt32(cmb_hala.SelectedValue) == 4)
                    {
                        msg.ErrorMesg("لتحويل طالب .. يرجى تسجيل طلب تحويل أولا ..!");
                        cmb_hala.Focus();
                        cmb_hala.SelectedValue = status;
                        return;
                    }
                }
               
                // Sahab Malaf

                if(status == 6)
                {
                    if (msg.DialogeMsg("  الطالب كان مسجل سحب ملف  ..  " + txt_first_name.Text+ "  هل تريد المتابعة ؟   ") == DialogResult.Yes)
                    {
                        int year = Properties.Settings.Default.year_cod + 1;
                        int grade = Convert.ToInt32(cmb_grade.SelectedValue);
                        int new_grade = 0; 
                        int class_id = Convert.ToInt32(cmb_class.SelectedValue);
                        int new_class_id = 0;
                        switch (grade)
                        {
                            case 10:
                                new_grade = 11;
                                new_class_id = class_id + 2;
                                break;
                            case 11:
                                new_grade = 1;
                                new_class_id = class_id + 2;
                                break;

                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                                new_grade += 1;
                                new_class_id = class_id + 3;
                                break;

                            case 6:
                            case 7:
                            case 8:
                                new_grade += 1;
                                new_class_id = class_id + 2;
                                break;
                        }
                        if(grade != 9)
                        {
                            DataTable dt_school_data = std.Get_School_year_Data(year, 0, 0);
                            if(dt_school_data.Rows.Count != 0)
                            {
                                std.Add_School_Std_Data(txt_std_code.Text,
                                                      year,
                                                      new_grade,
                                                      2,
                                                      new_class_id);
                            }
                        }
                    }
                    else
                    {
                        msg.ErrorMesg("تم إلغاء عملية الحفظ");
                        cmb_hala.SelectedValue = status;
                        cmb_hala.Focus();
                        return;
                    }
                }
                if (Convert.ToInt32(cmb_hala.SelectedValue) == 6)
                {
                    if(msg.DialogeMsg("   سوف يتم سحب ملف الطالب ..   " +txt_first_name.Text)== DialogResult.Yes)
                    {
                        int year = Properties.Settings.Default.year_cod + 1;
                        std.Delete_School_Std_Data(txt_std_code.Text, year);
                    }
                    else
                    {
                        msg.ErrorMesg("تم إلغاء عملية الحفظ");
                        cmb_hala.SelectedValue = status;
                        cmb_hala.Focus();
                        return;
                    }
                }
                // Sen
                sen = Hesab_sen.Nat_HesabSen(txt_nat.Text, Convert.ToInt32(cmb_sana.GetItemText(cmb_sana.SelectedItem).Substring(0, 4)) - 1);

                string tarikh = sen[5].ToString() + "-" + sen[4].ToString() + "-" + sen[3].ToString();
                
                //Update Std_School
                std.Update_School_Std_Data(
                    txt_std_code.Text,
                    txt_first_name.Text,
                    txt_nat.Text,
                    Convert.ToDateTime(tarikh),
                    Convert.ToInt32(cmb_grade.SelectedValue),
                    Convert.ToInt32(cmb_hala.SelectedValue),
                    Convert.ToInt32(cmb_class.SelectedValue),
                    Convert.ToInt32(cmb_gender.SelectedValue),
                    Convert.ToInt32(cmb_relgien.SelectedValue),
                    Convert.ToInt32(cmb_sana.SelectedValue));

                // Update Data in Current Std Form

                BL.Globals.Update_Std_Data = false;
                FRM_CURRENT_STD.Get_Current_Std.cmb_grade_SelectedIndexChanged(sender, e);
                this.Close();
               
                FRM_CURRENT_STD.Get_Current_Std.dt_std_data.FirstDisplayedScrollingRowIndex = row_index;
                FRM_CURRENT_STD.Get_Current_Std.dt_std_data.Rows[row_index].Selected = true;
                msg.MyMesg("تم حفظ البيانات");
            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            BL.Globals.Update_Std_Data = false;

            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);

        }

        private void btn_show_data_Click(object sender, EventArgs e)
        {
            DataTable Dt;
            Dt = std.Get_osra_Data_ById(Convert.ToInt32(txt_osra_id.Text));
            try
            {
                this.Close();
                // Add Data

                FRM_OSRAA_DATA.Get_Osra_data.state = "edit_from_Update_Std";
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_name.Text = Dt.Rows[0]["father_name"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_name.Enabled = false;
                FRM_OSRAA_DATA.Get_Osra_data.txt_last_name.Text = Dt.Rows[0]["father_last_name"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_last_name.Enabled = false;
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_nat.Text = Dt.Rows[0]["father_nat"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_nat.Enabled = false;
                FRM_OSRAA_DATA.Get_Osra_data.cmb_father_halaa.SelectedValue = Dt.Rows[0]["father_hala"];
                FRM_OSRAA_DATA.Get_Osra_data.txt_adrs.Text = Dt.Rows[0]["address"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_moahel.Text = Dt.Rows[0]["father_moahel"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_wazifa.Text = Dt.Rows[0]["father_wazifa"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_tel.Text = Dt.Rows[0]["tel"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_mobil1.Text = Dt.Rows[0]["father_mobil_1"].ToString().ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_mobil2.Text = Dt.Rows[0]["father_mobil_2"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_name.Text = Dt.Rows[0]["mother_name"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_name.Enabled = false;
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_nat.Text = Dt.Rows[0]["mother_nat"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_nat.Enabled = false;
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_moahel.Text = Dt.Rows[0]["mother_moahel"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_wazifa.Text = Dt.Rows[0]["mother_wazifa"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.cmb_mother_hala.SelectedValue = Dt.Rows[0]["mother_hala"];
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_mobil_1.Text = Dt.Rows[0]["mother_mobil_1"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_mobil2.Text = Dt.Rows[0]["mother_mobil_2"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_memo.Text = Dt.Rows[0]["comments"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_osra_code.Text = Dt.Rows[0]["Osraa_Id"].ToString();

                function.Get_Update_Name_For_OSRAA_DATA(Dt);

                //this.Dispose();

                FRM_OSRAA_DATA.Get_Osra_data.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
                FRM_OSRAA_DATA.Get_Osra_data.txt_adrs.Focus();

            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void txt_naat_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_nat_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_nat.BackColor = Color.White;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_nat_Leave(object sender, EventArgs e)
        {
            Waiting.Wait();
            try
            {
                if (this.ActiveControl != btn_close)
                {
                    if (txt_nat.Text != "")
                    {
                        if (!Std_Func.Checked_Is_Numeric(txt_nat)) return;
                        if (Std_Func.Verify_Std_Nat(txt_std_code,txt_nat) == 1) return;
                        if (Std_Func.Verify_Osra_Nat(txt_nat) == 1) return;

                        sen = Hesab_sen.Nat_HesabSen(txt_nat.Text, Convert.ToInt32(cmb_sana.GetItemText(cmb_sana.SelectedItem).Substring(0, 4)) - 1);
                        if (sen != null)
                        {
                            txt_tarikh.Text = sen[3] + " / " + sen[4] + " / " + sen[5];
                            txt_sen.Text = sen[0] + " يوم - " + sen[1] + " شهر - " + sen[2] + " سنة";
                            cmb_gender.SelectedIndex = Hesab_sen.Chack_Type(txt_nat);
                        }
                        else
                        {
                            txt_nat.BackColor = Color.MistyRose;
                            Waiting.End_WAit();
                            txt_nat.Focus();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.End_WAit();
            }
            Waiting.End_WAit();
        }

        private void FRM_UPDATE_SCHOOL_STD_Load(object sender, EventArgs e)
        {
          
            txt_nat_Leave(sender, e);
            if (Convert.ToInt32(cmb_hala.SelectedValue) == 3 || Convert.ToInt32(cmb_hala.SelectedValue) == 4)
            {
                cmb_hala.Enabled = false;
            }
            else
            {
                cmb_hala.Enabled = true;
            }
        }

        private void FRM_UPDATE_SCHOOL_STD_Activated(object sender, EventArgs e)
        {
            status = Convert.ToInt32(cmb_hala.SelectedValue);
        }

        private void FRM_UPDATE_SCHOOL_STD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_close_b_Click(sender, e);
            }
        }
    }
}
