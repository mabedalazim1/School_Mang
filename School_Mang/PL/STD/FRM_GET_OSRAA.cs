using School_Mang.BL;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_GET_OSRAA : Form,  INavigationAwareLoaded
    {

        private NavigationContext _context => AppNavigation.Instance.GetContext();

        public void OnNavigatedTo()
        {
            var ctx = AppNavigation.Instance.GetContext();

            if (ctx.OsraMode.HasFlag(GetOsraMode.OpenFromAddstudent))
            {
                LoadOsraData();
            }

            if (ctx?.OsraMode.HasFlag(GetOsraMode.EditOsra) == true)
                LoadAllOsraData();
        }


        // GET Classes
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        
        DAL.TestConcation testConcation = new DAL.TestConcation();
        CLS_STD_FUNCATIONS function = new CLS_STD_FUNCATIONS();

        int permission_id = Properties.Settings.Default.permission_id;

        // Form Closed
        private static FRM_GET_OSRAA frm_Get_Osrs;

        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Get_Osrs = null;
        }
        public static FRM_GET_OSRAA Get_Osra_data
        {
            get
            {
                if (frm_Get_Osrs == null)
                {
                    frm_Get_Osrs = new FRM_GET_OSRAA();
                    frm_Get_Osrs.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Get_Osrs;
            }
        }


        public FRM_GET_OSRAA()
        {
            InitializeComponent();

            if (frm_Get_Osrs == null)
            {
                frm_Get_Osrs = this;
            }


            Waiting.Start();
            if (testConcation.IsServerConnected())
            {
                this.dt_osra_data.DataSource = std.Get_All_Osra_Data();
                dt_osra_data.Columns["id"].Visible = false;
                dt_osra_data.Columns["الوظيفة"].Visible = false;
                dt_osra_data.Columns["رقم الأب القومى"].Visible = false;
                dt_osra_data.Columns["رقم الأم القومى"].Visible = false;

            }

            // Set User permission
            switch (permission_id)
            {
                case 3:
                    btn_ok.Enabled = false;
                    btn_new_osra.Enabled = false;
                    btn_del_osra.Enabled = false;
                    btn_edit_osra.ButtonText = "عرض بيانات الأسرة ";
                    break;
                case 2:
                    btn_ok.Enabled = true;
                    btn_new_osra.Enabled = true;
                    btn_del_osra.Enabled = false;
                    btn_edit_osra.ButtonText = "تعديل بيانات أسرة ";
                    break;

                case 1:
                    btn_ok.Enabled = true;
                    btn_new_osra.Enabled = true;
                    btn_del_osra.Enabled = true;
                    btn_edit_osra.ButtonText = "تعديل بيانات أسرة ";
                    break;
            }
            Waiting.Stop();
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        int move;
        int move_x;
        int move_y;

        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }

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

        public void txt_osra_data_OnValueChanged(object sender, EventArgs e)
        {
            LoadOsraData();
        }

        public void LoadOsraData()
        {
            if (!testConcation.IsServerConnected())
            {
                MSG.ErrorMesg("تأكد من الاتصال بالسيرفر.. !");
                return;
            }
            try
            {
                DataTable Dt = new DataTable();
                Dt = std.Search_Osra_Data(txt_osra_data.Text);
                if (Dt != null)
                {
                    dt_osra_data.DataSource = Dt;
                }
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }
            finally {
                Waiting.Stop();
            }
            
        }

        public void LoadAllOsraData()
        {
            if (!testConcation.IsServerConnected())
            {
                MSG.ErrorMesg("تأكد من الاتصال بالسيرفر.. !");
                return;
            }
            try
            {
                DataTable Dt = new DataTable();
                Dt = std.Get_All_Osra_Data();
                if (Dt != null)
                {
                    dt_osra_data.DataSource = Dt;
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
        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btn_ok_Click(object sender, EventArgs e)
        {
            GetData();
            
        }
        public void GetData()
        {

            try
            {
                var row = dt_osra_data.CurrentRow;

                if (row == null)  
                    return;

                var value = row.Cells["id"]?.Value;

                if (value == null)
                    return;
                var frm = FRM_ADD_STD.getAdd_Std_Frm;

                frm.txt_osra_id.Text = value.ToString();


                frm.txt_osra_id.Text =
                    dt_osra_data.CurrentRow.Cells["id"].Value.ToString();

                frm.txt_father_name.Text =
                   dt_osra_data.CurrentRow.Cells["اسم الأب"].Value.ToString();

                frm.txt_adrs.Text =
                    dt_osra_data.CurrentRow.Cells["العنوان"].Value.ToString();

                frm.txt_wazifa.Text =
                    dt_osra_data.CurrentRow.Cells["الوظيفة"].Value.ToString();

                frm.txt_mother_name.Text =
                    dt_osra_data.CurrentRow.Cells["اسم الأم"].Value.ToString();

                frm.txt_father_tel.Text =
                    dt_osra_data.CurrentRow.Cells["هاتف الأب"].Value.ToString();

                frm.txt_mother_tel.Text =
                    dt_osra_data.CurrentRow.Cells["هاتف الأم"].Value.ToString();


                if (_context?.OsraMode.HasFlag(GetOsraMode.AddOsraDataToStudent)== true)
                {
                    this.Hide();

                    frm.txt_nat.Focus();

                }
                else if (_context?.OsraMode.HasFlag(GetOsraMode.AddNewOsra) == true)
                {
                    this.Hide();
                    AppNavigation.Instance.Show(frm);
                    frm.BringToFront();

                }
                else
                {
                    this.Hide();
                    AppNavigation.Instance.Show(frm);
                    frm.BringToFront();
                }

            }

            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }
        private void btn_new_osra_Click(object sender, EventArgs e)
        {
            if (_context?.OsraMode.HasFlag(GetOsraMode.AddOsraDataToStudent) == true)
            {
                FRM_ADD_STD.getAdd_Std_Frm.Hide();
            }

            //BL.Globals.Open_Form_Get_osra = true; // تخذف
            this.Visible = false;

            AppNavigation.Instance
                       .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                       .SetContext(c =>
                       {
                           c.OsraMode = GetOsraMode.AddNewOsra|
                                        GetOsraMode.OpenFormGetOsra;
                           //c.AddNewOsra = true;
                           //c.OpenFormGetOsra = true; 
                       })
                       .Show(FRM_OSRAA_DATA.Get_Osra_data); // تم التحقق
           

           // FRM_OSRAA_DATA.Get_Osra_data.Show(MAIN.FRM_MAIN.Get_Frm_Main);
        }



        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم أو الهاتف أو الرقم القومى";
            lbl_help.Visible = true;
        }

        private void pic_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.Visible = false;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void txt_osra_data_Leave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void txt_osra_data_Enter(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void txt_osra_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txt_osra_data.Focus();
        }

        private void EditOsra()
        {
            var value = dt_osra_data.CurrentRow.Cells[0].Value;
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                int osrs_id = Convert.ToInt32(value);
                DataTable Dt;
                Dt = std.Get_osra_Data_ById(osrs_id);

                if (Dt.Rows.Count == 0)
                {
                    MSG.ErrorMesg("لا توجد بيانات لعرضها");
                    return;
                }
                // Add Data

                var frm = FRM_OSRAA_DATA.Get_Osra_data;

                frm.txt_father_name.Text = Dt.Rows[0]["father_name"].ToString();
                frm.txt_last_name.Text = Dt.Rows[0]["father_last_name"].ToString();
                frm.txt_father_nat.Text = Dt.Rows[0]["father_nat"].ToString();
                frm.cmb_father_halaa.SelectedValue = Dt.Rows[0]["father_hala"];
                frm.txt_adrs.Text = Dt.Rows[0]["address"].ToString();
                frm.txt_father_moahel.Text = Dt.Rows[0]["father_moahel"].ToString();
                frm.txt_father_wazifa.Text = Dt.Rows[0]["father_wazifa"].ToString();
                frm.txt_tel.Text = Dt.Rows[0]["tel"].ToString();
                frm.txt_father_mobil1.Text = Dt.Rows[0]["father_mobil_1"].ToString();
                frm.txt_father_mobil2.Text = Dt.Rows[0]["father_mobil_2"].ToString();
                frm.txt_mother_name.Text = Dt.Rows[0]["mother_name"].ToString();
                frm.txt_mother_nat.Text = Dt.Rows[0]["mother_nat"].ToString();
                frm.txt_mother_moahel.Text = Dt.Rows[0]["mother_moahel"].ToString();
                frm.txt_mother_wazifa.Text = Dt.Rows[0]["mother_wazifa"].ToString();
                frm.cmb_mother_hala.SelectedValue = Dt.Rows[0]["mother_hala"];
                frm.txt_mother_mobil_1.Text = Dt.Rows[0]["mother_mobil_1"].ToString();
                frm.txt_mother_mobil2.Text = Dt.Rows[0]["mother_mobil_2"].ToString();
                frm.txt_memo.Text = Dt.Rows[0]["comments"].ToString();
                frm.txt_osra_code.Text = Dt.Rows[0]["Osraa_Id"].ToString();

                function.Get_Update_Name_For_OSRAA_DATA(Dt);

                this.Hide();

                AppNavigation.Instance.
                    WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                    .SetContext(c =>
                    {
                        c.OsraMode = GetOsraMode.OpenFormGetOsra;
                        //c.OpenFormGetOsra = true;
                    })
                    .Show(frm);
                frm.txt_adrs.Focus();

                //FRM_OSRAA_DATA.Get_Osra_data.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
            }
            else
            {
                MSG.ErrorMesg("برجى اختيار البيانات المراد تعديلها ... !");
                return;
            }
        }
        private void btn_edit_osra_Click(object sender, EventArgs e)
        {
            EditOsra();
        }

        private void btn_del_osra_Click(object sender, EventArgs e)
        {

            string name = dt_osra_data.CurrentRow.Cells["اسم الأب"].Value.ToString();

            int osrs_id = Convert.ToInt32(dt_osra_data.CurrentRow.Cells["id"].Value.ToString());
            if (osrs_id.ToString() != "")
            {
                DataTable Dt = new DataTable();
                Dt = std.Verify_Osra_Data(osrs_id);
                if (Convert.ToInt32(Dt.Rows[0]["Id"].ToString()) != 0)
                {
                    MSG.ErrorMesg("لا يمكن حذف البيانات الخاصة بالسيد /   " + name);
                }
                else
                {
                    if (MSG.DialogeMsg("هل تريد حذف البيانات الخاصة بالسيد /  " + name) == DialogResult.Yes)
                    {
                        std.Delele_Osra_Data(osrs_id);
                        this.dt_osra_data.DataSource = std.Get_All_Osra_Data();
                        MSG.ErrorMesg("تم حذف البيانات الخاصة بالسيد /   " + name);
                    }
                    else
                    {
                        MSG.ErrorMesg("تم إلغاء عملية الحذف الخاصة بالسيد /   " + name);
                        return;
                    }

                }
            }
        }

        private void dt_osra_data_DoubleClick(object sender, EventArgs e)
        {
            if (permission_id == 3)
            {
                EditOsra();
                return;
            }

            if (_context?.OsraMode.HasFlag(GetOsraMode.AddOsraDataToStudent) ==true)
            {
                btn_ok_Click(sender, e);
            }
            else
            {
                EditOsra();
            }



        }
    }
}
