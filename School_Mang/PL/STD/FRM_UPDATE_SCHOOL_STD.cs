using School_Mang.BL;
using School_Mang.BL.Common;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using School_Mang.BL.Services;
using School_Mang.BL.Services.STD;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_UPDATE_SCHOOL_STD : Form, INavigationAware
    {
        private NavigationContext _context;
        private readonly OsraDataService _osraData = new OsraDataService();
        private readonly StudentDataMigrationService _studentData = new StudentDataMigrationService();
        private readonly StudentService _studentService = new StudentService();
        private readonly StudentSaveService _studentSave = new StudentSaveService();
        private readonly LookupService _stdData = new LookupService();
        private readonly VerifyService _verify = new VerifyService();
        private readonly TransferService _transfer = new TransferService();


        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();
            ApplyContext();
        }

        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        
        CLS_STD_FUNCATIONS Std_Func = new CLS_STD_FUNCATIONS();


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

            cmb_sana.DataSource = _stdData.Get_years();
            cmb_sana.DisplayMember = "YearDesc";
            cmb_sana.ValueMember = "Year_Id";

            cmb_grade.DataSource = _stdData.Get_grades();
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            cmb_hala.DataSource = _stdData.Get_stdStat();
            cmb_hala.DisplayMember = "StatusDesc";
            cmb_hala.ValueMember = "Std_Status_Id";

            cmb_gender.DataSource = _stdData.Get_genders();
            cmb_gender.DisplayMember = "GenderDesc";
            cmb_gender.ValueMember = "Gender_Id";

            cmb_relgien.DataSource = _stdData.Get_religion();
            cmb_relgien.DisplayMember = "ReligionDesc";
            cmb_relgien.ValueMember = "Religion_Id";

            cmb_class.DataSource = _stdData.Get_Grad_Data(grade);
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

        private void MarkError(string message)
        {
            txt_nat.BackColor = Color.MistyRose;
            MSG.ErrorMesg(message);
            txt_nat.Focus();
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
            cmb_class.DataSource = _stdData.Get_Grad_Data(Convert.ToInt32(cmb_grade.SelectedValue));
        }

        private bool ValidateTransfer()
        {
            if (!cmb_hala.Enabled)
            {
                return true;
            }
            int hala = SafeConverter.GetInt(cmb_hala.SelectedValue);
            // If Hala = 3 Or 4 Or 7 محول من - محول إلى - محول أثناء العام
                if (hala == 3 || hala == 4 || hala == 7)
                {
                    MSG.ErrorMesg("لتحويل طالب .. يرجى تسجيل طلب تحويل أولا ..!");
                    cmb_hala.Focus();
                    cmb_hala.SelectedValue = StudentCurrentHala;
                    return false;
                }
                return true;
            }

        private bool HandleRestoreSahbMalf()
        {
            if (status != 6)
                return true;

            if (MSG.DialogeMsg(
                $"الطالب كان مسجل سحب ملف .. {txt_first_name.Text} هل تريد المتابعة ؟")
                != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم إلغاء عملية الحفظ");
                cmb_hala.SelectedValue = status;
                cmb_hala.Focus();
                return false;
            }

            _transfer.RestoreSahbMalf(
                Properties.Settings.Default.year_cod + 1,
                txt_std_code.Text,
                SafeConverter.GetInt(cmb_grade.SelectedValue),
                SafeConverter.GetInt(cmb_class.SelectedValue));

            return true;
        }

        private bool HandleSahbMalf()
        {
            if (SafeConverter.GetInt(cmb_hala.SelectedValue) != 6)
                return true;

            if (MSG.DialogeMsg(
                $"سوف يتم سحب ملف الطالب .. {txt_first_name.Text}")
                != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم إلغاء عملية الحفظ");
                cmb_hala.SelectedValue = status;
                cmb_hala.Focus();
                return false;
            }

            bool currentYear = _context?.CurrentYearData ?? false;

            _transfer.SahbMalf(
                txt_std_code.Text,
                Properties.Settings.Default.year_cod + 1,
                _context.CurrentYearData);

            return true;
        }

        private ServiceResult SaveStudent()
        {
            var sen = AgeService.NatAgeHesabSen(
                txt_nat.Text,
                Convert.ToInt32(cmb_sana.GetItemText(cmb_sana.SelectedItem)
                               .Substring(0, 4)) - 1);

            DateTime birthDate = new DateTime(
                sen.BirthYear,
                sen.BirthMonth,
                sen.BirthDay);

            var data = new StudentDTO
            {
                StdCode = txt_std_code.Text,
                StdName = txt_first_name.Text,
                Nat = txt_nat.Text,
                BirthDate = birthDate,
                GradeId = SafeConverter.GetInt(cmb_grade.SelectedValue),
                StudentStatus = SafeConverter.GetInt(cmb_hala.SelectedValue),
                ClassId = SafeConverter.GetInt(cmb_class.SelectedValue),
                GenderId = SafeConverter.GetInt(cmb_gender.SelectedValue),
                ReligionId = SafeConverter.GetInt(cmb_relgien.SelectedValue),
                YearId = SafeConverter.GetInt(cmb_sana.SelectedValue),
                UserName = Properties.Settings.Default.user_name
            };

            return _studentSave.UpdateStudent(data);
        }

        private void RefreshCurrentStudentsForm()
        {
            var frm = FRM_CURRENT_STD.Get_Current_Std;

            frm.Get_School_Year_Data();

            frm.BeginInvoke(new Action(() =>
            {
                frm.SelectRow(row_index);
            }));
        }


        private void btn_save_data_Click(object sender, EventArgs e)
        {
            Waiting.Start();
            try
            {
                // If Hala = 3 Or 4 Or 7 محول من - محول إلى - محول أثناء العام
                if (!ValidateTransfer())
                    return;

                // Sahab Malaf
                if (!HandleRestoreSahbMalf())
                    return;

                if (!HandleSahbMalf())
                    return;

                // Save
                var result = SaveStudent();

                if (!result.Success)
                {
                    MSG.ErrorMesg(result.Message);
                    return;
                }

                MSG.MyMesg(result.Message);

                // Update Data in Current Std Form
                RefreshCurrentStudentsForm();

                this.Close();
            }
            catch(Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
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
            DataTable dt;
            dt = _osraData.Get_osra_Data_ById(Convert.ToInt32(txt_osra_id.Text));
            try
            {
                this.Close();
                // Add Data
                var frm = FRM_OSRAA_DATA.Get_Osra_data;
                var row = dt.Rows[0];
                var info = _osraData.GetUpdateInfo(dt);
                var data = new StudentDTO
                {
                    FatherName = SafeConverter.GetString(row["father_name"]),
                    FatherLastName = SafeConverter.GetString(row["father_last_name"]),
                    FatherNat=SafeConverter.GetString(row["father_nat"]),
                    FatherHala = SafeConverter.GetInt(row["father_hala"]),
                    Address = SafeConverter.GetString(row["address"]),
                    FatherMoahel = SafeConverter.GetString(row["father_moahel"]),
                    FatherWazifa = SafeConverter.GetString(row["father_wazifa"]),
                    Tel = SafeConverter.GetString(row["tel"]),
                    FatherMobil_1 = SafeConverter.GetString(row["father_mobil_1"]),
                    FatherMobil_2 = SafeConverter.GetString(row["father_mobil_2"]),
                    MotherName = SafeConverter.GetString(row["mother_name"]),
                    MotherNat = SafeConverter.GetString(row["mother_nat"]),
                    MotherMoahel = SafeConverter.GetString(row["mother_moahel"]),
                    MotherWazifa = SafeConverter.GetString(row["mother_wazifa"]),
                    MotherHala = SafeConverter.GetInt(row["mother_hala"]),
                    MotherMbil_1 = SafeConverter.GetString(row["mother_mobil_1"]),
                    MotherMbil_2 = SafeConverter.GetString(row["mother_mobil_2"]),
                    Comments = SafeConverter.GetString(row["comments"]),
                    OsraId = SafeConverter.GetInt(row["Osraa_Id"]),
                    UpdatedBy = info.updatedBy,
                    UpdatedAt = info.updatedAt
                };

               // function.Get_Update_Name_For_OSRAA_DATA(Dt);


                AppNavigation.Instance
                    .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                    .SetContext(c =>
                    {
                        c.StudentState.OpenFromGetStd = true;
                        c.StudentData = data;

                    }).Show(frm);
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

                        var isNumeric = _verify.ValidateIsNumeric(txt_nat.Text);

                        if (!isNumeric.Success)
                        {
                            MarkError(isNumeric.Message);
                            return;
                        }

                        var verifyStudentNationalId = _verify.VerifyStudentNationalId(
                                        txt_nat.Text,
                                        isUpdateMode ? txt_std_code.Text : "0"
                        );

                        if (!verifyStudentNationalId.Success)
                        {
                            MarkError(verifyStudentNationalId.Message);
                            return;
                        }

                        var verifyOsraNational = _verify.VerifyOsraNationalId(txt_nat.Text, 0);

                        if (!verifyOsraNational.Success)
                        {
                            MarkError(verifyOsraNational.Message);
                            return;
                        }

                        try
                        {
                            txt_nat.BackColor = Color.White;
                            var sen = AgeService.NatAgeHesabSen(txt_nat.Text, Convert.ToInt32(cmb_sana.GetItemText(cmb_sana.SelectedItem).Substring(0, 4)) - 1);
                            txt_tarikh.Text = $"{sen.BirthDay} / {sen.BirthMonth} / {sen.BirthYear}";
                            txt_sen.Text = $"{sen.Days} يوم - {sen.Months} شهر - {sen.Years} سنة";
                            cmb_gender.SelectedIndex = GetTypeService.CheckType(txt_nat);
                        }
                        catch (Exception ex) 
                        {
                            MarkError(ex.Message);
                            txt_nat.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MarkError("ادخل الرقم القومى .. !");
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
