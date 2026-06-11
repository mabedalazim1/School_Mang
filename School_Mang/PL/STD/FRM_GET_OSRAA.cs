using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Extensions;
using School_Mang.BL.Services;
using School_Mang.BL.Services.STD;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_GET_OSRAA : Form, INavigationAwareLoaded
    {

        private NavigationContext _context => AppNavigation.Instance.GetContext();
        private readonly OsraDataService _osraData = new OsraDataService();
        private bool _isDoubleClickBusy;
        public void OnNavigatedTo()
        {
            var ctx = AppNavigation.Instance.GetContext();

            if (ctx.StudentState.OpenFromAddstudent)
            {
                LoadOsraData();
            }

            if (ctx.OsraState.EditOsra)
                LoadAllOsraData();
        }


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

            LoadData();
        }

        private void LoadData()
        {
            Waiting.Start();
            try
            {
                GetPermission();
                LoadAllOsraData();

                GridHelper.SetColumnsVisibility(dt_osra_data,
                    ColumnVisibility.Hide,
                        "id", "الوظيفة", "رقم الأب القومى", "رقم الأم القومى");
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
        private void GetPermission()
        {
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
            Waiting.Start();

            try
            {
                var result = _osraData.SearchOsra(txt_osra_data.Text);

                if (!result.Success)
                {
                    MSG.ErrorMesg(result.Message);
                    return;
                }

                dt_osra_data.DataSource = result.Data;
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

        public void LoadAllOsraData()
        {

            Waiting.Start();
            try
            {
                var result = _osraData.GetOsraData();
                if (!result.Success)
                {
                    MSG.ErrorMesg(result.Message);
                    return;
                }
                dt_osra_data.DataSource = result.Data;

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
                
                    // Add Osra Data
                    frm.FillOsraData(new StudentDTO
                    {
                        OsraId = SafeConverter.GetInt(row.Cells["id"].Value),
                        FatherName = SafeConverter.GetString(row.Cells["اسم الأب"].Value),
                        Address = SafeConverter.GetString(row.Cells["العنوان"].Value),
                        Wazifa = SafeConverter.GetString(row.Cells["الوظيفة"].Value),
                        MotherName = SafeConverter.GetString(row.Cells["اسم الأم"].Value),
                        FatherTel = SafeConverter.GetString(row.Cells["هاتف الأب"].Value),
                        MotherTel = SafeConverter.GetString(row.Cells["هاتف الأم"].Value)
                    });

                AppNavigation.Instance.
                       SetContext(c =>
                       {
                           c.OsraState.OpenFormGetOsra = true; // Update
                       })
                           .Show(frm);

                frm.BringToFront();
            }

            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }
        private void btn_new_osra_Click(object sender, EventArgs e)
        {
            if (_context.OsraState.AddOsraDataToStudent == true)
            {
                FRM_ADD_STD.getAdd_Std_Frm.Hide();
            }

            this.Visible = false;

            AppNavigation.Instance
                       .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                       .SetContext(c =>
                       {
                           c.OsraState.AddNewOsra = true; // Update
                           c.OsraState.OpenFormGetOsra = true; // Update
                       })
                       .Show(FRM_OSRAA_DATA.Get_Osra_data); 
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
            if (dt_osra_data.CurrentRow == null)
            {
                MSG.ErrorMesg("برجى اختيار البيانات المراد تعديلها ... !");
                return;
            }

            var value = dt_osra_data.CurrentRow.Cells["id"].Value;
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                int osrs_id = SafeConverter.GetInt(value);

                var result = _osraData.GetOsraDataById(osrs_id);


                if (!result.Success)
                {
                    MSG.ErrorMesg(result.Message);
                    return;
                }

                var dt = result.Data;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MSG.ErrorMesg("لا توجد بيانات لعرضها");
                    return;
                }


                // Add Data
                var row = dt.Rows[0];
                var frm = FRM_OSRAA_DATA.Get_Osra_data;
                var info = _osraData.GetUpdateInfo(dt);
                var data = new StudentDTO
                {
                    FatherName = SafeConverter.GetString(row["father_name"]),
                    FatherLastName = SafeConverter.GetString(row["father_last_name"]),
                    FatherNat = SafeConverter.GetString(row["father_nat"]),
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

                this.Hide();
                
                AppNavigation.Instance.
                    WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                    .SetContext(c =>
                    {
                        c.OsraState.OpenFormGetOsra = true; // Update
                        c.StudentData = data;
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

            if (dt_osra_data.CurrentRow == null)
            {
                MSG.ErrorMesg("برجى اختيار البيانات المراد حذفها");
                return;
            }

            string name = dt_osra_data.CurrentRow.Cells["اسم الأب"].Value.ToString();
            int osrs_id = SafeConverter.GetInt(dt_osra_data.CurrentRow.Cells["id"].Value);

            var confirm = MSG.DialogeMsg($"هل تريد حذف البيانات الخاصة بالسيد / {name}");

            if (confirm != DialogResult.Yes)
                return;

            var result = _osraData.DeleteOsra(osrs_id);

            if (!result.Success)
            {
                MSG.ErrorMesg(result.Message);
                return;
            }

            var newData = _osraData.GetOsraData();
            if (!newData.Success)
            {
                MSG.ErrorMesg(newData.Message);
                return;
            }
            dt_osra_data.DataSource = newData.Data;


            MSG.ErrorMesg(result.Message);
        }

        private void dt_osra_data_DoubleClick(object sender, EventArgs e)
        {
            if (_isDoubleClickBusy) return;

            Waiting.Start();
            try
            {
                _isDoubleClickBusy = true;
                dt_osra_data.Enabled = false;

                if (permission_id == 3)
                {
                    EditOsra();
                    return;
                }

                if (_context.OsraState.AddOsraDataToStudent == true ||
                    _context.StudentState.OpenFromAddstudent == true)
                {
                    GetData();
                }
                else
                {
                    EditOsra();
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                _isDoubleClickBusy  = false;
                dt_osra_data.Enabled = true;
                Waiting.Stop();
            }
                   
        }
    }
}
