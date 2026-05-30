using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Extensions;
using School_Mang.BL.Services;
using School_Mang.BL.Services.STD;
using System;
using System.Data;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_GET_OSRAA : Form, INavigationAwareLoaded
    {

        private NavigationContext _context => AppNavigation.Instance.GetContext();
        private readonly OsraDataService osraData = new OsraDataService();

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
                var result = osraData.SearchOsra(txt_osra_data.Text);

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
                var result = osraData.GetOsraData();
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
                        FatherName = row.Cells["اسم الأب"].Value.ToString(),
                        Address = row.Cells["العنوان"].Value.ToString(),
                        Wazifa = row.Cells["الوظيفة"].Value.ToString(),
                        MotherName = row.Cells["اسم الأم"].Value.ToString(),
                        FatherTel = row.Cells["هاتف الأب"].Value.ToString(),
                        MotherTel = row.Cells["هاتف الأم"].Value.ToString()
                    });

                AppNavigation.Instance.
                       SetContext(c =>
                       {
                           c.OsraState.OpenFormGetOsra = true; // Update
                       })
                           .Show(frm);

                this.Hide();
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

                var result = osraData.GetOsraDataById(osrs_id);


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

                var info = osraData.GetUpdateInfo(dt);
                bool hasData = info.updatedBy != null;

                frm.lbl_edit_date.Visible = hasData;
                frm.lbl_by.Visible = hasData;
                frm.lbl_edit_by.Visible = hasData;
                frm.lbl_date.Visible = hasData;

                if (hasData)
                {
                    frm.lbl_edit_date.Text = info.updatedAt?.ToString("dd/MM/yyyy");
                    frm.lbl_edit_by.Text = info.updatedBy;
                }

                this.Hide();

                AppNavigation.Instance.
                    WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                    .SetContext(c =>
                    {
                        c.OsraState.OpenFormGetOsra = true; // Update
                        c.StudentData = new StudentDTO
                        {
                            FatherName = row["father_name"].ToString(),
                            FatherLastName = row["father_last_name"].ToString(),
                            FatherNat = row["father_nat"].ToString(),
                            FatherHala = SafeConverter.GetInt(row["father_hala"]),
                            Address = row["address"].ToString(),
                            FatherMoahel = row["father_moahel"].ToString(),
                            FatherWazifa = row["father_wazifa"].ToString(),
                            Tel = row["tel"].ToString(),
                            FatherMobil_1 = row["father_mobil_1"].ToString(),
                            FatherMobil_2 = row["father_mobil_2"].ToString(),
                            MotherName = row["mother_name"].ToString(),
                            MotherNat = row["mother_nat"].ToString(),
                            MotherMoahel = row["mother_moahel"].ToString(),
                            MotherWazifa = row["mother_wazifa"].ToString(),
                            MotherHala = SafeConverter.GetInt(row["mother_hala"]),
                            MotherMbil_1 = row["mother_mobil_1"].ToString(),
                            MotherMbil_2 = row["mother_mobil_2"].ToString(),
                            Comments = row["comments"].ToString(),
                            OsraId = SafeConverter.GetInt(row["Osraa_Id"])
                        };
                        
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

            var result = osraData.DeleteOsra(osrs_id);

            if (!result.Success)
            {
                MSG.ErrorMesg(result.Message);
                return;
            }

            var newData = osraData.GetOsraData();
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
    }
}
