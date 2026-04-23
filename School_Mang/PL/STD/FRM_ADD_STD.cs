using School_Mang.BL;
using School_Mang.BL.Services;
using School_Mang.BL.STD;
using System;
using System.Drawing;
using System.Windows.Forms;



namespace School_Mang.PL.STD
{

    public partial class FRM_ADD_STD : Form, INavigationAware
    {
        private NavigationContext _context;
        private readonly StudentCodeService _codeService = new StudentCodeService();
        private readonly StudentSaveService _saveService = new StudentSaveService();
        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();
            ApplyContext();

        }

        public string from_status = "";

        // Data
        DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

        //Import Classes
        CLS_STD std = new BL.STD.CLS_STD();
        // Hesab Sen
        HESAB_SEN Hesab_sen = new BL.HESAB_SEN();
        string[] sen = { };



        CLS_STD_FUNCATIONS Std_Func = new CLS_STD_FUNCATIONS();

        int permission_id = Properties.Settings.Default.permission_id;

        // Form Closed
        private static FRM_ADD_STD frm;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static FRM_ADD_STD getAdd_Std_Frm
        {
            get
            {
                if (frm == null)
                {
                    frm = new FRM_ADD_STD();
                    frm.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm;
            }
        }
        public FRM_ADD_STD()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }

            ApplyContext();
        }

        private void ApplyContext()
        {
            Waiting.Start();
            try
            {
                // Fill Combos

                cmb_sana.DataSource = std.Get_years();
                cmb_sana.DisplayMember = "YearDesc";
                cmb_sana.ValueMember = "Year_Id";

                cmb_type.DataSource = std.Get_genders();
                cmb_type.DisplayMember = "GenderDesc";
                cmb_type.ValueMember = "Gender_Id";

                cmb_grade.DataSource = std.Get_grades();
                cmb_grade.DisplayMember = "GradeDesc";
                cmb_grade.ValueMember = "Grade_Id";

                cmb_national.DataSource = std.Get_nationalities();
                cmb_national.DisplayMember = "NationalityDesc";
                cmb_national.ValueMember = "Nationality_Id";

                cmb_hala.DataSource = std.Get_stdStat();
                cmb_hala.DisplayMember = "StatusDesc";
                cmb_hala.ValueMember = "Std_Status_Id";

                cmb_religion.DataSource = std.Get_religion();
                cmb_religion.DisplayMember = "ReligionDesc";
                cmb_religion.ValueMember = "Religion_Id";
                Waiting.Stop();

                // Set User permission
                switch (permission_id)
                {
                    case 3:
                        btn_ok.Enabled = false;
                        break;
                    case 1:
                    case 2:
                        btn_ok.Enabled = true;
                        break;
                }


            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.Stop();
            }
        }

        int move;
        int move_x;
        int move_y;

        // checked Data


        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void pn_top_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            move_x = e.X;
            move_y = e.Y;
        }

       
        private void SaveStdData()
        {

            try
            {
                _saveService.SaveStudent(
                                         txt_std_name.Text,
                                         txt_nat.Text,
                                         Convert.ToInt32(cmb_sana.SelectedValue),
                                         Convert.ToInt32(cmb_grade.SelectedValue),
                                         Convert.ToInt32(cmb_type.SelectedValue),
                                         Convert.ToInt32(cmb_national.SelectedValue),
                                         Convert.ToInt32(cmb_religion.SelectedValue),
                                         Convert.ToInt32(cmb_hala.SelectedValue),
                                         Convert.ToInt32(txt_osra_id.Text));

                MSG.MyMesg("تم إضافة الطالب: " + txt_std_name.Text + ": كود  " + "".ToString());
                ClearForm();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                MSG.ErrorMesg(" حدث خطأ أثناء عملية الحفظ");
                return;
            }
            finally
            {
                Waiting.Stop();
            }

        }

        private void ClearForm()
        {
            txt_nat.Clear();
            txt_sen.Clear();
            txt_std_name.Clear();
            txt_tarikh.Clear();
            txt_father_name.Clear();
            txt_father_tel.Clear();
            txt_mother_name.Clear();
            txt_mother_tel.Clear();
            txt_wazifa.Clear();
            txt_osra_id.Clear();
            txt_adrs.Clear();
            txt_nat.Focus();
        }
        //----------------------------------
        // أخر التعديل
        private void Update_Std_Data()
        {
            Waiting.Start();
            try
            {

                // Update Std Data 

                sen = Hesab_sen.Nat_HesabSen(txt_nat.Text, Convert.ToInt32(cmb_sana.GetItemText(cmb_sana.SelectedItem).Substring(0, 4)) - 1);

                string tarikh = sen[5].ToString() + "-" + sen[4].ToString() + "-" + sen[3].ToString();

                std.Update_Std_Data(txt_std_code.Text,
                        txt_std_name.Text,
                        txt_nat.Text,
                        Convert.ToDateTime(tarikh),
                        Convert.ToInt32(cmb_type.SelectedValue),
                        Convert.ToInt32(cmb_national.SelectedValue),
                        Convert.ToInt32(cmb_religion.SelectedValue),
                        Convert.ToInt32(cmb_hala.SelectedValue),
                        Convert.ToInt32(cmb_grade.SelectedValue),
                        Convert.ToInt32(cmb_sana.SelectedValue),
                        Convert.ToInt32(txt_osra_id.Text));

                MSG.MyMesg("تم تعديل بيانات الطالب: " + txt_std_name.Text);


                this.Close();
                FRM_ADD_STD.frm = null;

                AppNavigation.Instance.SetContext(c =>
                {
                    c.AddFromGetStd = false;
                }).Show<FRM_GET_STD>();

                // FRM_GET_STD frm = new FRM_GET_STD();
                // frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                MSG.ErrorMesg(" حدث خطأ أثناء عملية الحفظ");
                Waiting.Stop();

                return;

            }
            finally
            {
                Waiting.Stop();
            }

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


        private void btn_close_b_Click(object sender, EventArgs e)
        {
            if (txt_std_name.Text != "" || txt_nat.Text != "")
            {
                if (_context?.UpdateStdData != true)
                {
                    if (MSG.DialogeErrMsg("لم يتم حفظ البيانات المدخلة .. هل تريد الخروج؟") != DialogResult.Yes) return;

                }
            }

            if (_context?.UpdateStdData == true)
            {

                this.Close();
                FRM_ADD_STD.frm = null;
                this.Dispose();

                var frm = FRM_GET_STD.Get_Student;
                frm.LoadStudentData();
                frm.Visible = true;

                //FRM_GET_STD.Get_Student.cmb_sana_SelectedIndexChanged(sender, e);
                //FRM_GET_STD.Get_Student.Visible = true;
            }

            if (_context?.OpenFormGetOsra == true)
            {
                this.Close();

                var frm = FRM_GET_OSRAA.Get_Osra_data;
                frm.LoadOsraData();
                frm.Visible = true;

                // FRM_GET_OSRAA.Get_Osra_data.txt_osra_data_OnValueChanged(sender, e);
                //FRM_GET_OSRAA.Get_Osra_data.Visible = true;
            }
            else if (_context?.AddFromGetStd == true)
            {

                this.Close();
                FRM_ADD_STD.frm = null;
                this.Dispose();
                FRM_GET_STD.Get_Student.LoadStudentData();
                FRM_GET_STD.Get_Student.Visible = true;
            }
            else
            {
                this.Close();
                FRM_ADD_STD.frm = null;
                this.Dispose();
            }

        }

        private void link_lbl_osraa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppNavigation.Instance.Show(FRM_OSRAA_DATA.Get_Osra_data);

            //FRM_OSRAA_DATA.Get_Osra_data.ShowDialog();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            Waiting.Start();
            if (txt_nat.Text == "")
            {
                txt_nat.BackColor = Color.MistyRose;
                ActiveControl = txt_nat;
                MSG.ErrorMesg();
                Waiting.Stop();
                return;
            }
            else
            {
                bool isUpdateMode = _context?.UpdateStdData ?? false;

                if (!Std_Func.Checked_Is_Numeric(txt_nat)) return;
                if (Std_Func.Verify_Std_Nat(txt_std_code, txt_nat, isUpdateMode) == 1) return;
                if (Std_Func.Verify_Osra_Nat(txt_nat) == 1) return;
            }
            if (txt_std_name.Text == "")
            {
                txt_std_name.BackColor = Color.MistyRose;
                ActiveControl = txt_std_name;
                MSG.ErrorMesg("تأكد من اسم الطالب");
                Waiting.Stop();
                return;
            }

            // Chack Type
            if (Hesab_sen.Chack_Type(txt_nat) == -1)
            {
                txt_nat.BackColor = Color.MistyRose;
                txt_nat.Focus();
                Waiting.Stop();
                return;
            }
            if (Hesab_sen.Chack_Type(txt_nat) != cmb_type.SelectedIndex)
            {
                MSG.ErrorMesg("تأكد من النوع");
                cmb_type.Focus();
                cmb_type.DroppedDown = true;
                Waiting.Stop();
                return;
            }

            if (txt_father_name.Text == "")
            {
                MSG.ErrorMesg("يجب إدخال بيانات الأسرة");
                link_edit_osra.Focus();
                Waiting.Stop();
                return;
            }


            if (_context?.UpdateStdData != true)
            {
                SaveStdData();
            }
            else if (_context?.UpdateStdData == true)
            {
                Update_Std_Data();
            }

            Waiting.Stop();
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
                        bool isUpdateMode = _context?.UpdateStdData ?? false;
                        if (!Std_Func.Checked_Is_Numeric(txt_nat)) return;
                        if (Std_Func.Verify_Std_Nat(txt_std_code, txt_nat, isUpdateMode) == 1) return;
                        if (Std_Func.Verify_Osra_Nat(txt_nat) == 1) return;

                        sen = Hesab_sen.Nat_HesabSen(txt_nat.Text, Convert.ToInt32(cmb_sana.GetItemText(cmb_sana.SelectedItem).Substring(0, 4)) - 1);
                        if (sen != null)
                        {
                            txt_tarikh.Text = sen[3] + " / " + sen[4] + " / " + sen[5];
                            txt_sen.Text = sen[0] + " يوم - " + sen[1] + " شهر - " + sen[2] + " سنة";
                            cmb_type.SelectedIndex = Hesab_sen.Chack_Type(txt_nat);
                        }
                        else
                        {
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
        private void FRM_ADD_STD_Load(object sender, EventArgs e)
        {
            try
            {
                if (_context?.UpdateStdData != true || _context.AddFromGetStd)
                {
                    Waiting.Start();
                    cmb_type.SelectedIndex = 0;
                    cmb_grade.SelectedIndex = 0;
                    cmb_hala.SelectedIndex = 0;
                    cmb_national.SelectedIndex = 0;
                    cmb_religion.SelectedIndex = 0;
                    if (cmb_sana.Items.Count > 1)
                    {
                        cmb_sana.SelectedIndex = 1;
                    }
                    else
                    {
                        cmb_sana.SelectedIndex = 0;
                    }

                    this.ActiveControl = txt_nat;
                    this.txt_nat.Focus();
                }
                else
                {
                    btn_ok.ButtonText = "تعديل";
                    label11.Text = "تعديل بيانات الطالب";
                    txt_nat_Leave(sender, e);
                }
            }
            catch (Exception err)
            {
                MSG.ErrorMesg(err.Message);
                Waiting.Stop();
            }
            finally
            {
                Waiting.Stop();
            }
        }

        private void cmb_sana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_nat.Text != "")
            {
                txt_nat_Leave(sender, e);
            }
        }

        private void link_new_osra_data_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            var frm = FRM_OSRAA_DATA.Get_Osra_data;

            frm.state = "add";
            frm.student_state = "std_add_new_osra";

            AppNavigation.Instance.
                WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                .SetContext(c =>
                {
                    c.OpenFromGetStd = true;
                }).Show(FRM_OSRAA_DATA.Get_Osra_data);

            //FRM_OSRAA_DATA.Get_Osra_data.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
        }

        private void link_get_osra_data_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var frm = new FRM_GET_OSRAA();
                frm.status = "from_std";

                AppNavigation.Instance.SetContext(c =>
                {
                    c.AddOsraDataToStudent = true;
                }).Show<FRM_GET_OSRAA>(); // تم التحقق


                /* FRM_GET_OSRAA frm = new FRM_GET_OSRAA
                 {
                     status = "from_std"
                 };
                 frm.ShowDialog();
                */

            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void txt_nat_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_nat.BackColor = Color.White;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_std_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_std_name.BackColor = Color.White;
        }

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_grade.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    cmb_hala.SelectedIndex = 0;
                    break;
                default:
                    if (Properties.Settings.Default.MyYear == 2022)
                    {
                        cmb_hala.SelectedIndex = 1;
                    }
                    else
                    {
                        cmb_hala.SelectedIndex = 2;
                    }

                    break;
            }

        }

        private void FRM_ADD_STD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_close_b_Click(sender, e);
            }

        }
    }
}
