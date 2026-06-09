using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using School_Mang.BL;
using School_Mang.BL.Services;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.Common;
using School_Mang.BL.Services.STD;
using School_Mang.BL.DTO;

namespace School_Mang.PL.STD
{
    public partial class FRM_OSRAA_DATA : Form, INavigationAware
    {
        private NavigationContext _context;
        private ServiceResult<int> _result;
        public void SetNavigation(NavigationContext context)
        {
            _context = context;
        }



        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        private readonly VerifyService _verify = new VerifyService();
        private readonly GetDataService _stdData = new GetDataService();
        private readonly OsraDataService _osraData = new OsraDataService();


        int permission_id = Properties.Settings.Default.permission_id;

        // Form Closed
        private static FRM_OSRAA_DATA frm_Osrs_Data;

        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Osrs_Data = null;
        }
        public static FRM_OSRAA_DATA Get_Osra_data
        {
            get
            {
                if (frm_Osrs_Data == null)
                {
                    frm_Osrs_Data = new FRM_OSRAA_DATA();
                    frm_Osrs_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Osrs_Data;
            }
        }

        public FRM_OSRAA_DATA()
        {
            InitializeComponent();


            if (frm_Osrs_Data == null)
            {
                frm_Osrs_Data = this;
            }
            FillCombo();
            SetUserPermission();

        }

        private void FillCombo()
        {
            cmb_father_halaa.DataSource = _stdData.Get_OSRA_STAT_MALE();
            cmb_father_halaa.DisplayMember = "StatusDesc";
            cmb_father_halaa.ValueMember = "Id";

            cmb_mother_hala.DataSource = _stdData.Get_OSRA_STAT_FEMALE();
            cmb_mother_hala.DisplayMember = "StatusDesc";
            cmb_mother_hala.ValueMember = "Id";
        }

        private void SetUserPermission()
        {
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

        int move;
        int move_x;
        int move_y;

        // checked Data
        private bool Checked_Data(TextBox txt, string str)
        {
            Waiting.Start();
            if (txt.Text == "")
            {
                MSG.ErrorMesg(str);
                txt.BackColor = Color.MistyRose;
                txt.Focus();
                Waiting.Stop();
                return false;
            }
            else
            {
                Waiting.Stop();
                return true;
            }

        }

        private bool Checked_Phon(TextBox txt, int num)
        {
            Waiting.Start();
            if (txt.Text.Length != num && txt.Text != "")
            {
                MSG.ErrorMesg("تأكد من رقم الهاتف المدخل  .. ! يجب ألا يقل عن  " + num.ToString());
                txt.BackColor = Color.MistyRose;
                txt.Focus();
                Waiting.Stop();
                return false;
            }
            else
            {
                Waiting.Stop();
                return true;
            }
        }

        private bool Checked_Is_Numeric(TextBox txt)
        {
            Waiting.Start();
            Regex nonNumericRegex = new Regex(@"\D");
            if (nonNumericRegex.IsMatch(txt.Text))
            {
                txt.BackColor = Color.MistyRose;
                MSG.ErrorMesg("تأكد من القيمة المدخلة .. يسمح بالأرقام فقط ..! ");
                Waiting.Stop();
                return false;
            }
            else
            {
                Waiting.Stop();
                return true;
            }
        }

        private bool Checked_Phon_End_NO(TextBox txt)
        {
            if (txt.Text == "")
            {
                return true;
            }
            Waiting.Start();
            Regex nonNumericRegex = new Regex(@"\D");
            if (nonNumericRegex.IsMatch(txt.Text))
            {
                txt.BackColor = Color.MistyRose;
                MSG.ErrorMesg("تأكد من القيمة المدخلة .. يسمح بالأرقام فقط ..! ");
                Waiting.Stop();
                return false;
            }
            else if (txt.Text.Substring(0, 2) != "01" && txt.Text.Length == 11)
            {
                MSG.ErrorMesg("تأكد من رقم الهاتف المدخل  .. ! الرقم يجب أن يبدأ ب  01 ");
                txt.BackColor = Color.MistyRose;
                txt.Focus();
                Waiting.Stop();
                return false;
            }
            else
            {
                Waiting.Stop();
                return true;
            }
        }

        // Get Osra Data
        private void GetOsraData()
        {
            var d = _context?.StudentData;
            if (d == null) return;

            txt_father_name.Text = d.FatherName;
            txt_last_name.Text = d.FatherLastName;
            txt_father_nat.Text = d.FatherNat;
            txt_adrs.Text = d.Address;
            txt_father_moahel.Text = d.FatherMoahel;
            txt_father_wazifa.Text = d.FatherWazifa;
            txt_tel.Text = d.Tel;
            txt_father_mobil1.Text =d.FatherMobil_1;
            txt_father_mobil2.Text = d.FatherMobil_2;
            txt_mother_name.Text = d.MotherName;
            txt_mother_nat.Text = d.MotherNat;
            txt_mother_moahel.Text = d.MotherMoahel;
            txt_mother_wazifa.Text = d.MotherWazifa;
            txt_mother_mobil_1.Text = d.MotherMbil_1;
            txt_mother_mobil2.Text = d.MotherMbil_2;
            txt_memo.Text = d.Comments;
            txt_osra_code.Text = d.OsraId.ToString();
            this.BeginInvoke(new Action(() =>
            {
                cmb_father_halaa.SelectedValue = d.FatherHala;
                cmb_mother_hala.SelectedValue = d.MotherHala;
            }));

            if (_context?.StudentState.OpenFromGetStd == true)
            {
                txt_father_name.Enabled = false;
                txt_last_name.Enabled = false;
                txt_father_nat.Enabled = false;
                txt_mother_name.Enabled = false;
                txt_mother_nat.Enabled = false;
                txt_adrs.Focus();
            }
            else 
            {
                txt_father_name.Enabled = true;
                txt_last_name.Enabled = true;
                txt_father_nat.Enabled = true;
                txt_mother_name.Enabled = true;
                txt_mother_nat.Enabled = true;
            }
            FillUpdateInfo(d);
        }

        private void FillUpdateInfo(StudentDTO dto)
        {
            bool hasUpdate = !string.IsNullOrWhiteSpace(dto.UpdatedBy);

            lbl_edit_date.Visible = hasUpdate;
            lbl_edit_by.Visible = hasUpdate;
            lbl_by.Visible = hasUpdate;
            lbl_date.Visible = hasUpdate;

            if (hasUpdate)
            {
                lbl_edit_date.Text = dto.UpdatedAt?.ToString("dd/MM/yyyy");
                lbl_edit_by.Text = dto.UpdatedBy;
            }
        }

        //Verify Std Nat
        private bool Verify_Std_Nat(TextBox txt)
        {
            Waiting.Start();
            Boolean nat = false;
            try
            {
                DataTable Dt = _verify.Verify_Std_Nat(txt.Text);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        string name = Dt.Rows[0][1].ToString();
                        MSG.ErrorMesg("الرقم القومى للطالب  " + name + "  مسجل من قبل");
                        txt.BackColor = Color.MistyRose;
                        txt.Focus();
                        nat = true;
                    }
                    else
                    {
                        nat = false;
                    }
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
            Waiting.Stop();
            return nat;

        }

        private bool Verify_Osra_Nat(TextBox txt, int osra_code)
        {
            if(txt == null || txt.TextLength < 14) return false;
            bool isValidNat = true;
            bool osra_nat = false;

            Waiting.Start();
            int sana = Properties.Settings.Default.MyYear;

            try
            {
                var sen = AgeService.NatAgeHesabSen(txt.Text, sana);
            }
            catch(Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                isValidNat = false;
                osra_nat = true;
                txt.BackColor = Color.MistyRose;
                txt.Focus();
            }

           
            if(isValidNat) {  
                try
                {
                    DataTable Dt = _verify.Verify_Osra_Nat(txt.Text, osra_code);
                    if (Dt != null)
                    {
                        if (Dt.Rows.Count > 0)
                        {
                            string name = Dt.Rows[0][0].ToString();
                            MSG.ErrorMesg("الرقم القومى باسم السيد /   " + name + "  مسجل من قبل");
                            txt.BackColor = Color.MistyRose;
                            txt.Focus();
                            osra_nat = true;
                        }
                        else
                        {
                            osra_nat = false;
                        }
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

            return osra_nat;

        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();
            if (_context.OsraState.OpenFormGetOsra == true)
            {
                var frm = FRM_GET_OSRAA.Get_Osra_data;
                frm.LoadOsraData();
                frm.Visible = true;
            }

            //this.Dispose();
        }

        private void txt_father_nat_Leave(object sender, EventArgs e)
        {
            if (txt_father_nat.Text.Length < 14) 
            {
                MSG.ErrorMesg("الرقم القومى يجب ألا يقل عن 14 رقم..!");
                txt_father_nat.Focus();
                return;
            }
            if (!string.IsNullOrWhiteSpace(txt_father_nat.Text)
                                            && txt_father_nat.Text.Length == 14)
            {

                if (_context?.OsraState.AddNewOsra == true)
                {
                    Verify_Osra_Nat(txt_father_nat, 0);
                }
                else
                {
                    Verify_Osra_Nat(txt_father_nat, Convert.ToInt32(txt_osra_code.Text));
                }

                Verify_Std_Nat(txt_father_nat);
            }

        }

        private void txt_father_nat_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_father_nat.BackColor = Color.White;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_tel.BackColor = Color.White;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_father_mobil1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_father_mobil1.BackColor = Color.White;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_father_mobil2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_father_mobil2.BackColor = Color.White;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_mother_nat_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_mother_nat.BackColor = Color.White;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_mother_mobil_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_mother_mobil_1.BackColor = Color.White;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_mother_mobil2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_mother_mobil2.BackColor = Color.White;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_mother_nat_Leave(object sender, EventArgs e)
        {
            if (txt_mother_nat.Text != "" || txt_mother_nat.Text.Length == 14)
            {
                if (_context.OsraState.AddNewOsra == true)
                {
                    Verify_Osra_Nat(txt_mother_nat, 0);
                }
                else
                {
                    Verify_Osra_Nat(txt_mother_nat, Convert.ToInt32(txt_osra_code.Text));
                }
                Verify_Std_Nat(txt_mother_nat);
            }

        }
        private StudentDTO BuildOsraDto()
        {
            return new StudentDTO
            {
                FatherNat = txt_father_nat.Text,
                Address = txt_adrs.Text,
                FatherName = txt_father_name.Text,
                FatherLastName = txt_last_name.Text,
                FatherMoahel = txt_father_moahel.Text,
                FatherWazifa = txt_father_wazifa.Text,
                Tel = txt_tel.Text,
                FatherMobil_1 = txt_father_mobil1.Text,
                FatherMobil_2 = txt_father_mobil2.Text,
                FatherHala = SafeConverter.GetInt(cmb_father_halaa.SelectedValue),
                MotherNat = txt_mother_nat.Text,
                MotherName = txt_mother_name.Text,
                MotherMoahel = txt_mother_moahel.Text,
                MotherWazifa = txt_mother_wazifa.Text,
                MotherMbil_1 = txt_mother_mobil_1.Text,
                MotherMbil_2 = txt_mother_mobil2.Text,
                MotherHala = SafeConverter.GetInt(cmb_mother_hala.SelectedValue),
                Comments = txt_memo.Text,
                UserName = Properties.Settings.Default.user_name
            };
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            // Check Data

            if (!Checked_Data(txt_father_name, "يرجى إدخال اسم الأب ... !")) return;
            if (!Checked_Data(txt_last_name, "يرجى إدخال اسم العائلة ... !")) return;
            if (!Checked_Data(txt_father_nat, "يرجى إدخال الرقم القومى للأب ... !")) return;

            if (!Checked_Is_Numeric(txt_father_nat)) return;

            if (_context.OsraState.AddNewOsra == true)
            {
                Verify_Osra_Nat(txt_father_nat, 0);
            }
            else
            {
                Verify_Osra_Nat(txt_father_nat, Convert.ToInt32(txt_osra_code.Text));
            }

            if (Verify_Std_Nat(txt_father_nat)) return;

            if (!Checked_Data(txt_adrs, "يرجى إدخال العنوان ... !")) return;
            if (!Checked_Data(txt_father_moahel, "يرجى إدخال مؤهل الأب  ... !")) return;
            if (!Checked_Data(txt_father_wazifa, "يرجى إدخال وظيفة الأب  ... !")) return;
            if (!Checked_Data(txt_father_mobil1, "يرجى إدخال هاتف الأب  ... !")) return;

            if (!Checked_Phon(txt_father_mobil1, 11)) return;
            if (!Checked_Is_Numeric(txt_father_mobil1)) return;
            if (!Checked_Phon(txt_father_mobil2, 11)) return;
            if (!Checked_Is_Numeric(txt_father_mobil2)) return;
            if (!Checked_Phon(txt_tel, 7)) return;
            if (!Checked_Is_Numeric(txt_tel)) return;


            if (!Checked_Phon_End_NO(txt_father_mobil1)) return;
            if (!Checked_Phon_End_NO(txt_father_mobil2)) return;

            if (!Checked_Data(txt_mother_name, "يرجى إدخال اسم الأم  ... !")) return;
            if (!Checked_Data(txt_mother_nat, "يرجى إدخال الرقم القومى للأم  ... !")) return;

            if (!Checked_Is_Numeric(txt_mother_nat)) return;


            if (Verify_Std_Nat(txt_mother_nat)) return;


            if (!Checked_Data(txt_mother_wazifa, "يرجى إدخال وظيفة الأم  ... !")) return;
            if (!Checked_Data(txt_mother_moahel, "يرجى إدخال مؤهل الأم  ... !")) return;

            if (!Checked_Data(txt_mother_mobil_1, "يرجى إدخال هاتف الأم  ... !")) return;
            if (!Checked_Phon_End_NO(txt_mother_mobil_1)) return;
            if (!Checked_Is_Numeric(txt_mother_mobil_1)) return;

            if (_context.OsraState.AddNewOsra == true)
            {
                Verify_Osra_Nat(txt_mother_nat, 0);
            }
            else
            {
                Verify_Osra_Nat(txt_mother_nat, Convert.ToInt32(txt_osra_code.Text));
            }

            if (!Checked_Phon(txt_mother_mobil_1, 11)) return;
            if (!Checked_Phon(txt_mother_mobil2, 11)) return;
            if (!Checked_Is_Numeric(txt_mother_mobil2)) return;


            if (!Checked_Phon_End_NO(txt_mother_mobil2)) return;

            if (txt_father_nat.Text == txt_mother_nat.Text)
            {
                MSG.ErrorMesg("الأرقام القومية للوالدين متشابهة... !");
                txt_father_nat.BackColor = Color.MistyRose;
                txt_mother_nat.BackColor = Color.MistyRose;
                txt_father_nat.Focus();
                return;
            }

            if (txt_father_nat.Text == FRM_ADD_STD.getAdd_Std_Frm.txt_nat.Text)
            {
                MSG.ErrorMesg(" تم إدخال هذا الرقم للطالب .. يرجى مراجعة الأرقام القومية... !");
                txt_father_nat.BackColor = Color.MistyRose;
                txt_father_nat.Focus();
                return;
            }

            if (txt_mother_nat.Text == FRM_ADD_STD.getAdd_Std_Frm.txt_nat.Text)
            {
                MSG.ErrorMesg(" تم إدخال هذا الرقم للطالب .. يرجى مراجعة الأرقام القومية... !");
                txt_mother_nat.BackColor = Color.MistyRose;
                txt_mother_nat.Focus();
                return;
            }

          try
            {
                var osraData = BuildOsraDto();

                if (_context.OsraState.AddNewOsra == true)
                {
                    // Save Osra Data
                    int year = int.Parse(Properties.Settings.Default.MyYear.ToString().Substring(2, 2));
                    int nextYear = year + 1;
                    
                    _result = _osraData.SaveOsraData(osraData, nextYear);

                    MSG.MyMesg("تم حفظ بيانات الأسرة بنجاح ... !");
                    if (_context.OsraState.AddOsraDataToStudent == true)
                    {

                        if (_result.Success)
                        {
                            var frmStd = FRM_ADD_STD.getAdd_Std_Frm;

                            frmStd.FillOsraData(_result,
                                txt_father_name.Text,
                                txt_mother_name.Text,
                                txt_adrs.Text,
                                txt_father_wazifa.Text,
                                txt_father_mobil1.Text,
                                txt_mother_mobil_1.Text);

                            frmStd.Show();
                            this.Close();
                        }
                        else
                        {
                            MSG.ErrorMesg(_result.Message);
                        }
                    }
                    if (_context.StudentState.OpenFromGetStd == true)
                    {

                        AppNavigation.Instance.SetContext(c =>
                        {
                           c.StudentState.OpenFromGetStd = false;
                        }).Show(FRM_ADD_STD.getAdd_Std_Frm,false); // تم التحقق
                    }
                }
                else
                {
                    // Update Osra Data
                    var OsraId = SafeConverter.GetInt(txt_osra_code.Text);
                   
                    _result = _osraData.UpdateOsraService(osraData, OsraId);

                    if (_result.Success)
                    { 
                        MSG.MyMesg("تم تعديل بيانات الأسرة بنجاح ... !");
                    }
                    else
                    {
                        MSG.ErrorMesg(_result.Message);
                    }
                }

                var frmOsrs = FRM_GET_OSRAA.Get_Osra_data;
                frmOsrs.LoadAllOsraData();

                if (_context.OsraState.OpenFormGetOsra == true)
                {
                    AppNavigation.Instance
                       .SetContext(c =>
                       {
                           c.OsraState.EditOsra = true;
                       })
                       .Show(frmOsrs); // تم التحقق
                }

                this.Close();
            }
            catch (Exception ex)
           {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void txt_father_name_KeyUp(object sender, KeyEventArgs e)
        {
            txt_father_name.BackColor = Color.White;
        }

        private void txt_last_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_last_name.BackColor = Color.White;
        }

        private void txt_adrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_adrs.BackColor = Color.White;
        }

        private void txt_father_moahel_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_father_moahel.BackColor = Color.White;
        }

        private void txt_father_wazifa_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_father_wazifa.BackColor = Color.White;
        }

        private void txt_mother_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_mother_name.BackColor = Color.White;
        }

        private void txt_mother_wazifa_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_mother_wazifa.BackColor = Color.White;
        }

        private void txt_mother_moahel_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_mother_moahel.BackColor = Color.White;
        }

        private void FRM_OSRAA_DATA_Load(object sender, EventArgs e)
        {
            if (_context.OsraState.AddNewOsra == true)
            {
                label11.Text = "إضافة بيانات الأسرة";
                btn_ok.ButtonText = "إضافة";
                ActiveControl = txt_father_name;
                txt_father_name.Focus();
            }
            else
            {
                label11.Text = "تعديل البيانات ";
                btn_ok.ButtonText = "تعديل";
                ActiveControl = btn_ok;

            }
            cmb_father_halaa.SelectedIndex = 0;
            cmb_mother_hala.SelectedIndex = 0;

            string name = txt_father_name.Text;

            if (_context.OsraState.OpenFormGetOsra == true ||
                _context.StudentState.OpenFromGetStd == true)
            {
                GetOsraData();
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

        private void FRM_OSRAA_DATA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_close_b_Click(sender, e);
            }
        }
    }
}
