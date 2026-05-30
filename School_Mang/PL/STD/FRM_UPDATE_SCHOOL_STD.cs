using School_Mang.BL;
using School_Mang.BL.Services;
using School_Mang.BL.Extensions;
using School_Mang.BL.Services.STD;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using School_Mang.BL.Enums;

namespace School_Mang.PL.STD
{
    public partial class FRM_UPDATE_SCHOOL_STD : Form, INavigationAware
    {
        private NavigationContext _context;

        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();
            ApplyContext();
        }

        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        
        CLS_STD_FUNCATIONS Std_Func = new CLS_STD_FUNCATIONS();
        CLS_STD_FUNCATIONS function = new CLS_STD_FUNCATIONS();


        public int grade = 1;
        public int row_index = 0;
        int status;
        private byte StudentCurrentHala;

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
            ApplyContext();
        }

        private void ApplyContext()
        {
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

            cmb_class.DataSource = std.Get_Grad_Data(grade);
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

        private void LoadEditData()
        {
            var d = _context?.StudentData;
            if (d == null) return;

            txt_osra_id.Text = d.OsraId.ToString();
            txt_std_code.Text = d.StdCode;
            txt_std_name.Text = d.StudentFullName;

            txt_first_name.Text = d.StdName;
            txt_nat.Text = d.Nat;

            this.BeginInvoke(new Action(() =>
            {
                cmb_hala.SelectedValue = d.StudentStatus;
                cmb_grade.SelectedValue = d.GradeId;
                cmb_sana.SelectedValue = d.Sana;
                cmb_gender.SelectedValue = d.GenderId;
                cmb_class.SelectedValue = d.ClassId;
                cmb_relgien.SelectedValue = d.ReligionId;
            }));

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
            cmb_class.DataSource = std.Get_Grad_Data(Convert.ToInt32(cmb_grade.SelectedValue));
        }

        private void btn_save_data_Click(object sender, EventArgs e)
        {

            try
            {
                // If Hala = 3 Or 4 Or 7 محول من - محول إلى - محول أثناء العام

                if (cmb_hala.Enabled == true)
                {
                    if (Convert.ToByte(cmb_hala.SelectedValue) == 3 ||
                   Convert.ToByte(cmb_hala.SelectedValue) == 4
                   || Convert.ToByte(cmb_hala.SelectedValue) == 7)
                    {
                        MSG.ErrorMesg("لتحويل طالب .. يرجى تسجيل طلب تحويل أولا ..!");
                        cmb_hala.Focus();
                        cmb_hala.SelectedValue = StudentCurrentHala;
                        return;
                    }
                }
               
                // Sahab Malaf

                if(status == 6)
                {
                    if (MSG.DialogeMsg("  الطالب كان مسجل سحب ملف  ..  " + txt_first_name.Text+ "  هل تريد المتابعة ؟   ") == DialogResult.Yes)
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
                        MSG.ErrorMesg("تم إلغاء عملية الحفظ");
                        cmb_hala.SelectedValue = status;
                        cmb_hala.Focus();
                        return;
                    }
                }
                if (Convert.ToInt32(cmb_hala.SelectedValue) == 6)
                {
                    if(MSG.DialogeMsg("   سوف يتم سحب ملف الطالب ..   " +txt_first_name.Text)== DialogResult.Yes)
                    {
                        int year = Properties.Settings.Default.year_cod + 1;
                        std.Delete_School_Std_Data(txt_std_code.Text, year);
                    }
                    else
                    {
                        MSG.ErrorMesg("تم إلغاء عملية الحفظ");
                        cmb_hala.SelectedValue = status;
                        cmb_hala.Focus();
                        return;
                    }
                }
                // Sen
                 var sen = AgeService.NatAgeHesabSen(txt_nat.Text, Convert.ToInt32(cmb_sana.GetItemText(cmb_sana.SelectedItem).Substring(0, 4)) - 1);

                DateTime birthDate = new DateTime(sen.BirthYear, sen.BirthMonth, sen.BirthDay);


                //Update Std_School
                std.Update_School_Std_Data(
                    txt_std_code.Text,
                    txt_first_name.Text,
                    txt_nat.Text,
                    birthDate,
                    Convert.ToInt32(cmb_grade.SelectedValue),
                    Convert.ToInt32(cmb_hala.SelectedValue),
                    Convert.ToInt32(cmb_class.SelectedValue),
                    Convert.ToInt32(cmb_gender.SelectedValue),
                    Convert.ToInt32(cmb_relgien.SelectedValue),
                    Convert.ToInt32(cmb_sana.SelectedValue));

                // Update Data in Current Std Form
                var frm = FRM_CURRENT_STD.Get_Current_Std;

                frm.Get_School_Year_Data();

                frm.BeginInvoke(new Action(() =>
                {
                    frm.SelectRow(row_index);
                }));

                this.Close();
                
                MSG.MyMesg("تم حفظ البيانات");
            }
            catch(Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {

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
                MSG.ErrorMesg(ex.Message);
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
            Waiting.Start();
            try
            {
                if (this.ActiveControl != btn_close)
                {
                    if (txt_nat.Text != "")
                    {
                        bool isUpdateMode = _context.StudentState.UpdateStdData;

                        if (!Std_Func.Checked_Is_Numeric(txt_nat)) return;
                        if (Std_Func.Verify_Std_Nat(txt_std_code,txt_nat,isUpdateMode) == 1) return;
                        if (Std_Func.Verify_Osra_Nat(txt_nat) == 1) return;
                        try
                        {
                            var sen = AgeService.NatAgeHesabSen(txt_nat.Text, Convert.ToInt32(cmb_sana.GetItemText(cmb_sana.SelectedItem).Substring(0, 4)) - 1);
                            txt_tarikh.Text = $"{sen.BirthDay} / {sen.BirthMonth} / {sen.BirthYear}";
                            txt_sen.Text = $"{sen.Days} يوم - {sen.Months} شهر - {sen.Years} سنة";
                            cmb_gender.SelectedIndex = GetTypeService.CheckType(txt_nat);
                        }
                        catch (Exception ex) 
                        {
                            MSG.ErrorMesg(ex.Message);
                            txt_nat.BackColor = Color.MistyRose;
                            Waiting.Stop();
                            txt_nat.Focus();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
            }
            Waiting.Stop();
        }

        private void FRM_UPDATE_SCHOOL_STD_Load(object sender, EventArgs e)
        {
            LoadEditData();
            txt_nat_Leave(sender, e);
             StudentCurrentHala = Convert.ToByte(cmb_hala.SelectedValue);

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
