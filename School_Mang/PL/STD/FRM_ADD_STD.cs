using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.BL;
using School_Mang.BL.STD;



namespace School_Mang.PL.STD
{
    
    public partial class FRM_ADD_STD : Form
    {
        public string from_status = "";

        // Data
        DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
     
        //Import Classes
        CLS_STD std = new BL.STD.CLS_STD();
        Waiting Waiting = new BL.Waiting();
        Globals globals = new BL.Globals();
        // Hesab Sen
        HESAB_SEN Hesab_sen = new BL.HESAB_SEN();
        string[] sen = {};

        // MSG
        MSG msg =new BL.MSG();

        CLS_STD_FUNCATIONS Std_Func = new CLS_STD_FUNCATIONS();

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
            try
            {
                Waiting.Wait();
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
                    Waiting.End_WAit();
                
            }
            catch(Exception e)
            {
                msg.ErrorMesg(e.Message);
                Waiting.End_WAit();
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

        
        private void Save_Std_Data()
        {
            int count_std;
            int sdt_code;

            // Student Code
            string year = cmb_sana.Text.ToString().Substring(2, 2);
            string grade = "";
            switch (cmb_grade.SelectedValue)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:

                    grade = cmb_grade.SelectedValue.ToString() + "000";

                    break;
                case 10:
                    grade = "0100";
                    break;

                case 11:
                    grade = "0200";
                    break;

                default:

                    break;
            }

            DataTable Dt = std.GET_Code_Std_Grade(Convert.ToInt32(cmb_grade.SelectedValue), Convert.ToInt32(cmb_sana.SelectedValue), "yes");
            count_std = Convert.ToInt32(Dt.Rows[0]["count_std"]);
            sdt_code = Convert.ToInt32(year + grade) + count_std + 1;

            // Verify Student Code 

            DataTable std_Dt = std.Verify_Std_Code(Convert.ToString(sdt_code));
            if (std_Dt.Rows.Count != 0)
            {
                Dt = std.GET_Code_Std_Grade(Convert.ToInt32(cmb_grade.SelectedValue), Convert.ToInt32(cmb_sana.SelectedValue), "no");
                sdt_code = Convert.ToInt32(Dt.Rows[0]["count_std"]) + 1;
            }

            try
            {

                // Add Std Data 

                sen = Hesab_sen.Nat_HesabSen(txt_nat.Text, Convert.ToInt32(cmb_sana.GetItemText(cmb_sana.SelectedItem).Substring(0, 4)) - 1);

                string tarikh = sen[5].ToString() + "-" + sen[4].ToString() + "-" + sen[3].ToString();

                std.Add_Std_Data(Convert.ToString(sdt_code),
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

                msg.MyMesg("تم إضافة الطالب: " + txt_std_name.Text + ": كود  " + sdt_code.ToString());

                txt_nat.Text = "";
                txt_sen.Text = "";
                txt_std_name.Text = "";
                txt_tarikh.Text = "";
                txt_father_name.Text = "";
                txt_father_tel.Text = "";
                txt_mother_name.Text = "";
                txt_mother_tel.Text = "";
                txt_wazifa.Text = "";
                txt_osra_id.Text = "";
                txt_adrs.Text = "";
                txt_nat.Focus();


            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                msg.ErrorMesg(" حدث خطأ أثناء عملية الحفظ");
                Waiting.End_WAit();

                return;

            }
            finally
            {
                Waiting.End_WAit();
            }

        }

        private void Update_Std_Data()
        {
            Waiting.Wait();
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

                msg.MyMesg("تم تعديل بيانات الطالب: " + txt_std_name.Text );
                Globals.Add_From_Get_Std = false;

                this.Close();
                FRM_ADD_STD.frm = null;

                FRM_GET_STD frm = new FRM_GET_STD();
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                msg.ErrorMesg(" حدث خطأ أثناء عملية الحفظ");
                Waiting.End_WAit();

                return;

            }
            finally
            {
                Waiting.End_WAit();
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
            
            if(txt_std_name.Text!="" || txt_nat.Text != "")
            {
                if (!Globals.Update_Std_Data)
                {
                    if(msg.DialogeErrMsg("لم يتم حفظ البيانات المدخلة .. هل تريد الخروج؟") != DialogResult.Yes) return;

                }
            }

            if (Globals.Update_Std_Data)
            {
                Globals.Update_Std_Data = false;

                this.Close();
                FRM_ADD_STD.frm = null;
                this.Dispose();

                FRM_GET_STD frm = new FRM_GET_STD();
                frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
            }

            if (Globals.Open_Form_Get_osra)
            {
                Globals.Open_Form_Get_osra = false;
                this.Close();
                FRM_GET_OSRAA.Get_Osra_data.ShowDialog();
               
            }
            else if (Globals.Add_From_Get_Std)
            {
                Globals.Add_From_Get_Std = false;
                this.Close();
                FRM_ADD_STD.frm = null;
                this.Dispose();
                FRM_GET_STD frm = new FRM_GET_STD();
                frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);

            }else
            {
                this.Close();
                FRM_ADD_STD.frm = null;
                this.Dispose();
            }

        }

        private void link_lbl_osraa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //PL.STD.FRM_OSRAA frm_osraa = new FRM_OSRAA();
            //frm_osraa.ShowDialog();

            FRM_OSRAA_DATA.Get_Osra_data.ShowDialog();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            Waiting.Wait();
            if(txt_nat.Text == "")
                {
                txt_nat.BackColor = Color.MistyRose;
                ActiveControl = txt_nat;
                msg.ErrorMesg();
                Waiting.End_WAit();
                return;
            }
            else
            {
                if (!Std_Func.Checked_Is_Numeric(txt_nat)) return;
                if(Std_Func.Verify_Std_Nat(txt_std_code,txt_nat) == 1) return ;
                if (Std_Func.Verify_Osra_Nat(txt_nat) == 1) return;
            }
            if (txt_std_name.Text == "")
            {
                txt_std_name.BackColor = Color.MistyRose;
                ActiveControl = txt_std_name;
                msg.ErrorMesg("تأكد من اسم الطالب");
                Waiting.End_WAit();
                return;
            }

            // Chack Type
            if (Hesab_sen.Chack_Type(txt_nat)== -1)
            {
                txt_nat.BackColor = Color.MistyRose;
                txt_nat.Focus();
                Waiting.End_WAit();
                return;
            }
            if (Hesab_sen.Chack_Type(txt_nat) != cmb_type.SelectedIndex)
            {
                msg.ErrorMesg("تأكد من النوع");
                cmb_type.Focus();
                cmb_type.DroppedDown = true;
                Waiting.End_WAit();
                return;
            }
                
            if (txt_father_name.Text == "")
            {
                msg.ErrorMesg("يجب إدخال بيانات الأسرة");
                link_edit_osra.Focus();
                Waiting.End_WAit();
                return;
            }


            if (!Globals.Update_Std_Data)
            {
                Save_Std_Data();
            }
            else if(Globals.Update_Std_Data)
            {
                Update_Std_Data();
            }

            Waiting.End_WAit();
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
                        if(!Std_Func.Checked_Is_Numeric(txt_nat)) return;
                        if (Std_Func.Verify_Std_Nat(txt_std_code,txt_nat) == 1) return;
                        if (Std_Func.Verify_Osra_Nat(txt_nat) == 1) return;

                        sen = Hesab_sen.Nat_HesabSen(txt_nat.Text, Convert.ToInt32(cmb_sana.GetItemText(cmb_sana.SelectedItem).Substring(0, 4))-1);
                        if (sen != null)
                        {
                            txt_tarikh.Text = sen[3] + " / " + sen[4] + " / " + sen[5];
                            txt_sen.Text = sen[0] + " يوم - " + sen[1] + " شهر - " + sen[2] + " سنة";
                            cmb_type.SelectedIndex = Hesab_sen.Chack_Type(txt_nat);
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
        private void FRM_ADD_STD_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Globals.Update_Std_Data || Globals.Add_From_Get_Std)
                {
                    Waiting.Wait();
                    DAL.Open();
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
                msg.ErrorMesg(err.Message);
                Waiting.End_WAit();
            }
            finally
            {
                Waiting.End_WAit();
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
            FRM_OSRAA_DATA frm_osraa_data = new FRM_OSRAA_DATA
            {
                state = "add",
                student_state = "std_add_new_osra"
            };
            frm_osraa_data.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
        }

        private void link_get_osra_data_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Globals.Add_Osra_Data_To_Student = true;
                FRM_GET_OSRAA frm = new FRM_GET_OSRAA
                {
                    status = "from_std"
                };
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
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

        private void txt_std_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_std_name.BackColor = Color.White;
        }

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_grade.SelectedIndex)
            {
                case 0:
                case 9:
                case 10:
                    cmb_hala.SelectedIndex = 0;
                    break;
                default:
                    if(Properties.Settings.Default.MyYear == 2022)
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
    }
}
