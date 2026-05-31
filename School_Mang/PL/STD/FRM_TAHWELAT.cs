using School_Mang.BL;
using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.BL.Services.STD;
using School_Mang.BL.Common.Helper;
using System;
using System.Data;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_TAHWELAT : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();

        private readonly TransferService _transferService = new TransferService();
        private readonly GetDataService _getData = new GetDataService();
        private readonly LookupService _stdData = new LookupService();


        private byte test_year = 0;

        int permission_id = Properties.Settings.Default.permission_id;

        private bool _isLoading = true;
        // Form Closed
        private static FRM_TAHWELAT frm_Tahwelat;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Tahwelat = null;
        }
        public static FRM_TAHWELAT Get_Frm_Tahwelat
        {
            get
            {
                if (frm_Tahwelat == null)
                {
                    frm_Tahwelat = new FRM_TAHWELAT();
                    frm_Tahwelat.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Tahwelat;
            }
        }
        public FRM_TAHWELAT()
        {
            InitializeComponent();

            if (frm_Tahwelat == null)
            {
                frm_Tahwelat = this;
            }
            // Set year val
            Globals.My_Year = Convert.ToByte(Properties.Settings.Default.year_cod);
            lbl_year_b.Text = Properties.Settings.Default.MyYear.ToString();
            LoadData();
        }


        #region My Voids
        private void LoadData()
        {
            _isLoading = true;
            this.SuspendLayout();

            Waiting.Start();

            LoadGrades();
            LoadTransfers();
            ApplyPermissions();

            Waiting.Stop();

            this.ResumeLayout();
            _isLoading = false;
        }
        private void LoadGrades()
        {
            // Add Grade Data
            var grade_dt = _stdData.Get_grades();

            DataRow dr = grade_dt.NewRow();
            dr["GradeDesc"] = "الكل";
            dr["Grade_Id"] = 0;

            grade_dt.Rows.InsertAt(dr, 0);

            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";
            cmb_grade.DataSource = grade_dt;
        }
        private void LoadTransfers()
        {
            // Get Trans  Data
            dt_std_data.DataSource = std.GET_Trans_Data(0, 3, 7);
            HideGridColumns();
        }
        private void HideGridColumns()
        {
            GridHelper.SetColumnsVisibility(dt_std_data,
                 ColumnVisibility.Hide,
                "std_code",
                "Year_Id",
                "Grade_Id",
                "Std_Status_Id",
                "adrs",
                "Kotob",
                "Resom",
                "Transfer_School",
                "Transfer_reason",
                "Guardian_name",
                "Transfer_code",
                "Class_Id",
                "Trans_After_Year");
        }
        private void ApplyPermissions()
        {
            // Set User permission
            switch (permission_id)
            {
                case 3:
                    btn_del_std.Enabled = false;
                    break;
                case 2:
                    btn_del_std.Enabled = false;
                    break;
                case 1:
                    btn_del_std.Enabled = true;
                    break;
            }
        }

        // Verify Stdunet Status 
        private Boolean Verify_Std()
        {
            if (dt_std_data.SelectedRows.Count == 0)
            {
                MSG.ErrorMesg("يرجى اختيار طالب ..!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Test_Data()
        {
            if (!_transferService.HasTransfers())
            {
                MSG.ErrorMesg("لا يوجد طلبات تحويل مسجلة هذا العام .. !");
                return;
            }
        }
        #endregion


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

        private void FRM_TAHWELAT_Load(object sender, EventArgs e)
        {
            cmb_grade.SelectedIndex = 0;

            cmb_status.SelectedIndex = 0;

            lbl_count.Text = dt_std_data.Rows.Count.ToString();

            Test_Data();

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            ChangSelectedData();
        }

        public void ChangSelectedData()
        {
            int gradeId = Convert.ToInt32(cmb_grade.SelectedValue);

            if (cmb_status.SelectedIndex == 0)
            {
                dt_std_data.DataSource = std.GET_Trans_Data(gradeId, 3, 7);
            }
            else
            {

                dt_std_data.DataSource = std.GET_Trans_Data(gradeId, 4);
            }

            lbl_count.Text = dt_std_data.Rows.Count.ToString();
            txt_std_data.Text = "";
        }
        private void cmb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_grade_SelectedIndexChanged(sender, e);
        }

        private void pic_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.Visible = false;
        }

        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم  ";
            lbl_help.Visible = true;
        }

        private void txt_std_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void txt_std_data_MouseLeave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txt_std_data.Focus();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void txt_std_data_Enter(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void txt_std_data_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var grade = Convert.ToInt32(cmb_grade.SelectedValue);
                var status = Convert.ToInt32(cmb_status.SelectedIndex + 3);
                var text = txt_std_data.Text;
                var dt = _transferService.SearchTransferData(grade, status, text);

                dt_std_data.DataSource = dt;
                lbl_count.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Waiting.Stop();
            }
        }

        private TransferEditData MapRowToTransfer(DataGridViewRow row)
        {
            return new TransferEditData
            {
                TransferCode = row.Cells["Transfer_code"].Value.ToString(),
                StdName = row.Cells["اسم الطالب"].Value.ToString(),
                StdCode = row.Cells["std_code"].Value.ToString(),
                GuardianName = row.Cells["Guardian_name"].Value.ToString(),
                Address = row.Cells["adrs"].Value.ToString(),
                Reason = row.Cells["Transfer_reason"].Value.ToString(),
                ToSchool = row.Cells["Transfer_School"].Value.ToString(),
                Resom = Convert.ToByte(row.Cells["Resom"].Value),
                Kotob = Convert.ToByte(row.Cells["Kotob"].Value),
                StatusId = Convert.ToInt32(row.Cells["Std_Status_Id"].Value),
                GradeId = Convert.ToInt32(row.Cells["Grade_Id"].Value)
            };
        }
        private void btn_new_std_Click(object sender, EventArgs e)
        {
            if (Verify_Std()) return;

            var row = dt_std_data.CurrentRow;
            var data = MapRowToTransfer(row);
            var frm = FRM_TAHEEL_STD.Get_Tahweel_Std;
            
            AppNavigation.Instance
                .SetContext(c =>
                {
                    c.StudentCase = GetStudentCase.UpdateTaheewl;
                    c.TransferData = data;
                }).Show(frm);

            // FRM_TAHEEL_STD.Get_Tahweel_Std.ShowDialog();
        }

        private DeleteTransferRequest MapRowToDelete(DataGridViewRow row , string stdName)
        {
           
            return new DeleteTransferRequest
            {
                StdCode = row.Cells["std_code"].Value.ToString(),
                StdName = stdName,
                ClassId = SafeConverter.GetInt(row.Cells["Class_Id"].Value),
                GradeId = Convert.ToInt32(row.Cells["Grade_Id"].Value),
                Year = Properties.Settings.Default.year_cod,
                TransferCode = Convert.ToInt32(row.Cells["Transfer_code"].Value),
                CurrentYear = Convert.ToInt32(row.Cells["Year_Id"].Value),
                TransAfterYear = Convert.ToBoolean(row.Cells["Trans_After_Year"].Value),
                StatusId = Convert.ToInt32(row.Cells["Std_Status_Id"].Value)
            };
        }
        private void btn_del_std_Click(object sender, EventArgs e)
        {
            if (Verify_Std())
                return;
            try
            {
                var row = dt_std_data.CurrentRow;

                string stdName = row.Cells["اسم الطالب"].Value.ToString();

                if (MSG.DialogeErrMsg("هل تريد حذف طلب التحويل للطالب / " + stdName + " ؟") != DialogResult.Yes)
                {
                    MSG.ErrorMesg("تم الغاء عملية الحذف");
                    return;
                }

                var data = MapRowToDelete(row, stdName);

                _transferService.DeleteTransfer(data);

                cmb_grade_SelectedIndexChanged(sender, e);

                MSG.MyMesg("تم حذف طلب التحويل للطالب / " + stdName);
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }


        private void btn_talab_tahewl_Click(object sender, EventArgs e)
        {
            if (Verify_Std()) return;

            
            // Get Trans Data
            var row = dt_std_data.CurrentRow;

            int grade = Convert.ToInt32(row.Cells["Grade_Id"].Value);
            int Std_Status_Id = Convert.ToInt32(row.Cells["Std_Status_Id"].Value);
            string trans_code = row.Cells["Transfer_code"].Value.ToString();
            string std_name = row.Cells["اسم الطالب"].Value.ToString();
            int sana = (Convert.ToInt32(row.Cells["Year_Id"].Value)) + 2021;
            string year_data;
            string grade_desc = "";
            bool Trans_After_Year = Convert.ToBoolean(row.Cells["Trans_After_Year"].Value);

            // Get New Year & Grade For Tahewl To School
            if (Std_Status_Id == 3 || Std_Status_Id == 7)
            {
                // If Trans After School
                if (Trans_After_Year)
                {
                    grade_desc = _getData.Get_Grade_Desc(grade).Rows[0]["GradeDesc"].ToString();
                }
                else
                {
                    //grade_desc = std.Get_Grade_Desc(grade + 1).Rows[0]["GradeDesc"].ToString();
                    grade_desc = _getData.Get_Grade_Desc(grade).Rows[0]["GradeDesc"].ToString();
                }
                year_data = _getData.Get_Year_Desc(sana + 1).Rows[0]["YearDesc"].ToString();
            }
            else
            {
                year_data = _getData.Get_Year_Desc(sana).Rows[0]["YearDesc"].ToString();

            }

            string[] year = year_data.Split('-');
            string year_desc = year[1] + "-" + year[0];

            // Open Report
            RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();
            try
            {
                if (Std_Status_Id == 3 || Std_Status_Id == 7)
                {
                    RPT.OpenTahwel_From_Report(trans_code, std_name, year_desc, grade_desc);
                }
                else
                {
                    RPT.OpenTahwel_To_Report(trans_code, std_name, year_desc);
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void btn_current_year_Click(object sender, EventArgs e)
        {
            if (test_year == 0)
            {
                //Set year val
                BL.Globals.My_Year = Convert.ToByte(Properties.Settings.Default.year_cod + 1);
                test_year = 1;
                btn_current_year.ButtonText = "العام الحالى";
                lbl_year_b.Text = (Properties.Settings.Default.MyYear + 1).ToString();
            }
            else
            {
                //Set year val
                BL.Globals.My_Year = Convert.ToByte(Properties.Settings.Default.year_cod);
                test_year = 0;
                btn_current_year.ButtonText = "العام القادم";
                lbl_year_b.Text = Properties.Settings.Default.MyYear.ToString();
            }

            cmb_grade_SelectedIndexChanged(sender, e);
            Test_Data();

        }

    }
}
