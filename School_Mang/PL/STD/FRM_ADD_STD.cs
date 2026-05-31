using School_Mang.BL;
using School_Mang.BL.Common;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using School_Mang.BL.Models;
using School_Mang.BL.Services;
using School_Mang.BL.Services.STD;
using School_Mang.BL.STD;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace School_Mang.PL.STD
{

    public partial class FRM_ADD_STD : Form, INavigationAware
    {
        private NavigationContext _context;
        private readonly StudentSaveService _saveService = new StudentSaveService();
        private readonly StudentUpdateService _updateService = new StudentUpdateService();
        private readonly LookupService _lookUpService = new LookupService();

        private bool _isFormReady = false;
        private bool _isClosing = false;
        private bool _loading = false;
        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();
            if (_context.OsraState.OpenFormGetOsra == true)
            {
                LoadOsraData();
            }

        }

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

        }
        private void ApplyContext()
        {
            _loading = true;
            Waiting.Start();
            try
            {
                // Fill Combos

                cmb_sana.DataSource = _lookUpService.Get_years();
                cmb_sana.DisplayMember = "YearDesc";
                cmb_sana.ValueMember = "Year_Id";

                cmb_type.DataSource = _lookUpService.Get_genders();
                cmb_type.DisplayMember = "GenderDesc";
                cmb_type.ValueMember = "Gender_Id";

                cmb_grade.DataSource = _lookUpService.Get_grades();
                cmb_grade.DisplayMember = "GradeDesc";
                cmb_grade.ValueMember = "Grade_Id";

                cmb_national.DataSource = _lookUpService.Get_nationalities();
                cmb_national.DisplayMember = "NationalityDesc";
                cmb_national.ValueMember = "Nationality_Id";

                cmb_hala.DataSource = _lookUpService.Get_stdStat();
                cmb_hala.DisplayMember = "StatusDesc";
                cmb_hala.ValueMember = "Std_Status_Id";

                cmb_religion.DataSource = _lookUpService.Get_religion();
                cmb_religion.DisplayMember = "ReligionDesc";
                cmb_religion.ValueMember = "Religion_Id";

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

                _isFormReady = true;
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.Stop();
                _loading = false;
            }
        }

        int move;
        int move_x;
        int move_y;

        // checked Data

        public void FillOsraData(OperationResult<int> result, string fatherName, string motherName, string address, string wazifa, string fatherTel, string motherTel)
        {
            txt_osra_id.Text = result.Data.ToString();
            txt_father_name.Text = fatherName;
            txt_mother_name.Text = motherName;
            txt_adrs.Text = address;
            txt_wazifa.Text = wazifa;
            txt_father_tel.Text = fatherTel;
            txt_mother_tel.Text = motherTel;
        }
        public void FillOsraData(StudentDTO d)
        {
            txt_osra_id.Text = d.OsraId.ToString();
            txt_father_name.Text = d.FatherName;
            txt_mother_name.Text = d.MotherName;
            txt_adrs.Text = d.Address;
            txt_wazifa.Text = d.Wazifa;
            txt_father_tel.Text = d.FatherTel;
            txt_mother_tel.Text = d.MotherTel;
        }
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
                var req = new StudentSaveRequest
                {
                    StudentName = txt_std_name.Text,
                    NationalId = txt_nat.Text,
                    YearId = SafeConverter.GetInt(cmb_sana.SelectedValue),
                    GradeId = SafeConverter.GetInt(cmb_grade.SelectedValue),
                    GenderId = SafeConverter.GetInt(cmb_type.SelectedValue),
                    NationalityId = SafeConverter.GetInt(cmb_national.SelectedValue),
                    ReligionId = SafeConverter.GetInt(cmb_religion.SelectedValue),
                    StatusId = SafeConverter.GetInt(cmb_hala.SelectedValue),
                    OsraId = SafeConverter.GetInt(txt_osra_id.Text)
                };

                string saveCode = _saveService.SaveStudent(req);

                MSG.MyMesg("تم إضافة الطالب: " + txt_std_name.Text + ": كود  " + saveCode);
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

        private void Update_Std_Data()
        {
            Waiting.Start();
            try
            {
                // Update Std Data 
                _updateService.UpdateStudentData(
                        txt_std_code.Text,
                        txt_std_name.Text,
                        txt_nat.Text,
                        Convert.ToInt32(cmb_type.SelectedValue),
                        Convert.ToInt32(cmb_national.SelectedValue),
                        Convert.ToInt32(cmb_religion.SelectedValue),
                        Convert.ToInt32(cmb_hala.SelectedValue),
                        Convert.ToInt32(cmb_grade.SelectedValue),
                        Convert.ToInt32(cmb_sana.SelectedValue),
                        Convert.ToInt32(txt_osra_id.Text));

                MSG.MyMesg("تم تعديل بيانات الطالب: " + txt_std_name.Text);

                var frm = FRM_GET_STD.Get_Student;
                frm.SearchStudents();

                AppNavigation.Instance
                    .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                    .SetContext(c =>
                    {
                        c.StudentState.EditStudent = true;
                    })
                    .Show(frm);

                this.Close();

            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                MSG.ErrorMesg("حدث خطأ أثناء عملية الحفظ");
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

            if (txt_std_name.Text != "" && txt_nat.Text != "")
            {
                if (_context.StudentState.UpdateStdData != true)
                {
                    if (MSG.DialogeErrMsg("لم يتم حفظ البيانات المدخلة .. هل تريد الخروج؟") != DialogResult.Yes) return;

                }
            }

            _isClosing = true;

            if (_context.StudentState.UpdateStdData == true)
            {

                this.Close();
                FRM_ADD_STD.frm = null;

                var frm = FRM_GET_STD.Get_Student;

                AppNavigation.Instance
                    .SetContext(c =>
                    {
                        c.StudentState.OpenFromAddstudent = true;

                        // c.OpenFromAddstudent = true;
                    })
                    .Show(frm, false);
            }

            if (_context.OsraState.OpenFormGetOsra == true)
            {
                this.Close();
                FRM_ADD_STD.frm = null;

                var frm = FRM_GET_OSRAA.Get_Osra_data;

                AppNavigation.Instance
                    .SetContext(c =>
                    {
                        c.StudentState.OpenFromAddstudent = true;

                        //c.OpenFromAddstudent = true; // frm.LoadOsraData()
                    })
                    .Show(frm, false);
            }
            else if (_context.StudentState.AddFromGetStd == true)
            {

                this.Close();
                FRM_ADD_STD.frm = null;

                var frm = FRM_GET_STD.Get_Student;
                AppNavigation.Instance
                   .SetContext(c =>
                   {
                       c.StudentState.OpenFromAddstudent = true;

                       //c.OpenFromAddstudent = true; //frm.LoadStudentData()
                   })
                   .Show(frm, false);
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

        }
        private void ResetFieldColors()
        {
            txt_nat.BackColor = Color.White;
            txt_std_name.BackColor = Color.White;
            txt_father_name.BackColor = Color.White;
        }

        private bool ValidateNatOnly()
        {
            txt_nat.BackColor = Color.White;

            if (string.IsNullOrWhiteSpace(txt_nat.Text))
            {
                txt_nat.BackColor = Color.MistyRose;
                ActiveControl = txt_nat;
                MSG.ErrorMesg("من فضلك أدخل الرقم القومي");
                txt_nat.Focus();
                return false;
            }

            var numeric = NumericService.CheckNumeric(txt_nat.Text);
            if (!numeric.IsValid)
            {
                txt_nat.BackColor = Color.MistyRose;
                txt_nat.Focus();
                MSG.ErrorMesg(numeric.Message);
                return false;
            }
            return true;
        }

        private bool ValidateStudent()
        {
            ResetFieldColors();
            if (!ValidateNatOnly()) return false;

            var studentNat = StdValidationService.VerifyStdNat(
                        txt_std_code.Text,
                        txt_nat.Text,
                        _context.StudentState.UpdateStdData
            );

            if (!studentNat.IsValid)
            {
                txt_nat.BackColor = Color.MistyRose;
                txt_nat.Focus();
                MSG.ErrorMesg(studentNat.Message);
                return false;
            }

            var osraNat = StdValidationService.VerifyOsraNat(txt_nat.Text);

            if (!osraNat.IsValid)
            {
                txt_nat.BackColor = Color.MistyRose;
                txt_nat.Focus();
                MSG.ErrorMesg(osraNat.Message);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_std_name.Text))
            {
                txt_std_name.BackColor = Color.MistyRose;
                ActiveControl = txt_std_name;
                MSG.ErrorMesg("تأكد من اسم الطالب");
                return false;
            }

            try
            {
                int type = GetTypeService.CheckType(txt_nat);

                if (type != Convert.ToInt32(cmb_type.SelectedIndex))
                {
                    MSG.ErrorMesg("تأكد من النوع");
                    cmb_type.Focus();
                    cmb_type.DroppedDown = true;
                    return false;
                }
            }
            catch
            {
                txt_nat.BackColor = Color.MistyRose;
                txt_nat.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_father_name.Text))
            {
                MSG.ErrorMesg("يجب إدخال بيانات الأسرة");
                link_edit_osra.Focus();
                return false;
            }
            return true;
        }

        private void SubmitStudent()
        {
            if (_isClosing) return;

            Waiting.Start();
            try
            {
                if (!ValidateStudent())
                    return;

                if (_context.StudentState.UpdateStdData != true)
                    SaveStdData();
                else
                    Update_Std_Data();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nat.Text))
            {
                MSG.ErrorMesg("من فضلك أدخل الرقم القومي");
                txt_nat.Focus();
                txt_nat.BackColor = Color.MistyRose;
                return;
            }
            SubmitStudent();
        }

        private bool TryGetYearFromCombo(out int year)
        {
            year = 0;

            if (!_isFormReady)
                return false;

            if (cmb_sana.SelectedItem == null)
                return false;

            var text = cmb_sana.Text?.Trim();

            if (string.IsNullOrEmpty(text) || !text.Contains("-"))
                return false;

            if (!int.TryParse(text.Split('-')[0], out year))
                return false;

            year = year - 1;
            return true;
        }

        private void LeaveTextNat()
        {
            if (_isClosing) return;
            ResetFieldColors();

            if (string.IsNullOrWhiteSpace(txt_nat.Text))
                return;

            try
            {
                if (!ValidateNatOnly())
                    return;

                if (!TryGetYearFromCombo(out int year))
                    return;

                var sen = AgeService.NatAgeHesabSen(txt_nat.Text, year);

                txt_tarikh.Text = $"{sen.BirthDay} / {sen.BirthMonth} / {sen.BirthYear}";
                txt_sen.Text = $"{sen.Days} يوم - {sen.Months} شهر - {sen.Years} سنة";

                cmb_type.SelectedIndex = GetTypeService.CheckType(txt_nat);
            }
            catch (Exception ex)
            {
                txt_nat.BackColor = Color.MistyRose;
                txt_nat.Focus();
                MSG.ErrorMesg(ex.Message);
            }

        }

        private void txt_nat_Leave(object sender, EventArgs e)
        {
            LeaveTextNat();
        }

        private void LoadEditData()
        {
            var d = _context?.StudentData;
            if (d == null) return;

            txt_std_code.Text = d.StdCode;
            txt_nat.Text = d.Nat;
            txt_std_name.Text = d.StdName;

            txt_osra_id.Text = d.OsraId.ToString();
            txt_father_name.Text = d.FatherName;
            txt_mother_name.Text = d.MotherName;
            txt_adrs.Text = d.Address;
            txt_wazifa.Text = d.Wazifa;
            txt_father_tel.Text = d.FatherTel;
            txt_mother_tel.Text = d.MotherTel;

            this.BeginInvoke(new Action(() =>
            {
                cmb_grade.SelectedValue = d.GradeId;
                cmb_sana.SelectedValue = d.YearId;
                cmb_type.SelectedValue = d.GenderId;
                cmb_religion.SelectedValue = d.ReligionId;
                cmb_national.SelectedValue = d.NationalityId;
            }));
        }

        private void LoadOsraData()
        {
            var d = _context?.StudentData;
            if (d == null) return;

            txt_osra_id.Text = d.OsraId.ToString();
            txt_father_name.Text = d.FatherName;
            txt_mother_name.Text = d.MotherName;
            txt_adrs.Text = d.Address;
            txt_wazifa.Text = d.Wazifa;
            txt_father_tel.Text = d.FatherTel;
            txt_mother_tel.Text = d.MotherTel;
            txt_nat.Focus();
        }
        private void FRM_ADD_STD_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyContext();


                if (!_context.StudentState.UpdateStdData == true
                        || _context.StudentState.AddFromGetStd == true)
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
                    LoadEditData();
                    txt_nat_Leave(sender, e);
                }
            }
            catch (Exception err)
            {
                MSG.ErrorMesg(err.Message);
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
                LeaveTextNat();
            }
        }

        private void link_new_osra_data_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            var frm = FRM_OSRAA_DATA.Get_Osra_data;

            AppNavigation.Instance.
                WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                .SetContext(c =>
                {
                    c.StudentState.AddNewStudent = true;
                    c.StudentState.OpenFromAddstudent = true;
                    c.OsraState.AddOsraDataToStudent = true;
                    c.OsraState.AddNewOsra = true;

                    //c.AddNewStudent = true;
                    //c.AddNewOsra = true;
                    //c.OpenFromGetStd = true;
                }).Show(FRM_OSRAA_DATA.Get_Osra_data);

        }

        private void link_get_osra_data_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AppNavigation.Instance.SetContext(c =>
                {
                    c.StudentState.OpenFromAddstudent = true;
                }).Show<FRM_GET_OSRAA>(); // تم التحقق

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
            if (_loading) return;
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
