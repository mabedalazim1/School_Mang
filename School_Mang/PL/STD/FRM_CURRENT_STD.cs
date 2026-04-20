using School_Mang.BL;
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
    public partial class FRM_CURRENT_STD : Form, INavigationAware
    {

        private NavigationContext _context;

        public void SetNavigation(NavigationContext context)
        {
            _context = context;
            ApplyContext();
        }


        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        MAIN.CLS_FUNCATIONS Func = new MAIN.CLS_FUNCATIONS();
        
        RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();

        int year_cod = Properties.Settings.Default.year_cod;
        int permission_id = Properties.Settings.Default.permission_id;

        public short grade = 0;

        // Form Closed
        private static FRM_CURRENT_STD frm_Current_Std;

        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Current_Std = null;
        }
        public static FRM_CURRENT_STD Get_Current_Std
        {
            get
            {
                if (frm_Current_Std == null)
                {
                    frm_Current_Std = new FRM_CURRENT_STD();
                    frm_Current_Std.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Current_Std;
            }
        }

        public FRM_CURRENT_STD()
        {
            InitializeComponent();

            if (frm_Current_Std == null)
            {
                frm_Current_Std = this;
            }

            ApplyContext();
        }

        private void ApplyContext()
        {
            Waiting.Start();
            // Add Grade Data
            DataTable grade_dt = std.Get_grades();
            cmb_grade.DataSource = grade_dt;
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            DataRow dr = grade_dt.NewRow();
            dr["GradeDesc"] = "الكل";
            dr["Grade_Id"] = 0;
            grade_dt.Rows.InsertAt(dr, 0);

            // Add Class Data
            Get_Class_Data(1);
            // Get School Year Data
            Get_School_Year_Data();
            var c = _context;
            if (c == null) return;

            bool isElthak = c.ElthakStd || c.ElthakStdNextYear;

            if (isElthak)
            {
                btn_talab_elthak.Location = new Point(409, 15);
                btn_del_std.Visible = false;
                btn_tahwel.Visible = false;
            }
            else
            {
                btn_del_std.Visible = true;
                btn_tahwel.Visible = true;
            }

            if (c.CurrentYearData)
            {
                btn_tahwel.Visible = true;
                btn_del_std.Location = new Point(208, 15);
            }
            else
            {
                btn_tahwel.Visible = false;
                btn_del_std.Location = new Point(278, 15);
            }
            // Set User permission
            switch (permission_id)
            {
                case 3:
                    btn_new_std.Enabled = false;
                    btn_tahwel.Enabled = false;
                    btn_del_std.Enabled = false;
                    break;
                case 2:
                    btn_new_std.Enabled = true;
                    btn_tahwel.Enabled = true;
                    btn_del_std.Enabled = false;
                    break;

                case 1:
                    btn_new_std.Enabled = true;
                    btn_tahwel.Enabled = true;
                    btn_del_std.Enabled = true;
                    break;
            }
            Waiting.Stop();
        }

        public void SelectRow(int index)
        {
            ChangeSelectedData();
            if (index < 0 || index >= dt_std_data.Rows.Count)
                return;

            dt_std_data.FirstDisplayedScrollingRowIndex = index;
            dt_std_data.Rows[index].Selected = true;
        }

        int move;
        int move_x;
        int move_y;

        #region My Voids
        // Verify Year
        private int Current_Year()
        {
            int year;
            if (_context?.CurrentYearData == true ||
               _context?.DetailsStd == true ||
                _context?.ElthakStdNextYear == true)
            {
                year = year_cod;
            }
            else
            {
                year = year_cod + 1;
            }
           
            return year;
        }


        // Get School Year Data
        public void Get_School_Year_Data()
        {
             int my_grade =Convert.ToInt32(cmb_grade.SelectedValue);
            Waiting.Start();
            DataTable dt = std.Get_School_year_Data(Current_Year(), my_grade, 0);

            dt_std_data.DataSource = dt;
            dt_std_data.Columns["std_code"].Visible = false;
            dt_std_data.Columns["Grade_Id"].Visible = false;
            dt_std_data.Columns["Religion_Id"].Visible = false;
            dt_std_data.Columns["Gender_Id"].Visible = false;
            dt_std_data.Columns["Std_Status_Id"].Visible = false;
            dt_std_data.Columns["Osraa_Id"].Visible = false;
            dt_std_data.Columns["Year_Id"].Visible = false;
            dt_std_data.Columns["Class_No"].Visible = false;
            dt_std_data.Columns["Class_Id"].Visible = false;
            dt_std_data.Columns["father_name"].Visible = false;
            dt_std_data.Columns["std_name"].Visible = false;
            dt_std_data.Columns["std_nat"].Visible = false;
            dt_std_data.Columns["year"].Visible = false;
            dt_std_data.Columns["old_grade"].Visible = false;
            dt_std_data.Columns["year_desc"].Visible = false;
            dt_std_data.Columns["Updated_At"].Visible = false;
            dt_std_data.Columns["Updated_by"].Visible = false;

            if (_context?.DetailsStd == true)
            {
                // Open From Details 

                dt_std_data.Columns["الفصل"].Visible = false;
                dt_std_data.Columns["الديانة"].Visible = false;
                dt_std_data.Columns["النوع"].Visible = false;
                dt_std_data.Columns["الحالة"].Visible = false;
                dt_std_data.Columns["العنوان"].Visible = true;
                dt_std_data.Columns["هاتف الأب"].Visible = true;
                dt_std_data.Columns["هاتف الأم"].Visible = true;
                btn_del_std.Visible = false;
                btn_talab_elthak.Visible = false;


            }
            else
            {
                // Open From School Data

                dt_std_data.Columns["الفصل"].Visible = true;
                dt_std_data.Columns["الديانة"].Visible = true;
                dt_std_data.Columns["النوع"].Visible = true;
                dt_std_data.Columns["الحالة"].Visible = true;
                dt_std_data.Columns["العنوان"].Visible = false;
                dt_std_data.Columns["هاتف الأب"].Visible = false;
                dt_std_data.Columns["هاتف الأم"].Visible = false;
                btn_del_std.Visible = true;
                btn_talab_elthak.Visible = true;
            }
            lbl_count.Text = dt.Rows.Count.ToString();

            _context?.PostAction?.Invoke();
            Waiting.Stop();
        }
        // Get Class Data
        public void Get_Class_Data(int Grade_Id, int Class_Id = 0)
        {
            Waiting.Start();
            DataTable dt = std.Get_Class_Id(Grade_Id);
            DataRow dr = dt.NewRow();
            dr["Class_Desc"] = "الكل";
            dr["Class_Id"] = 0;
            dt.Rows.InsertAt(dr, 0);

            cmb_class.DataSource = dt;
            cmb_class.DisplayMember = "Class_Desc";
            cmb_class.ValueMember = "Class_Id";
            cmb_class.SelectedIndex = 0;

            DataTable std_dt;
            std_dt = std.Get_School_year_Data(Current_Year(), Convert.ToInt32(cmb_grade.SelectedValue), Class_Id);
            lbl_count.Text = std_dt.Rows.Count.ToString();
            dt_std_data.DataSource = std_dt;
            Waiting.Stop();
        }
        // Verify Stdunet Status 
        private Boolean Verify_Std_Status()
        {
            if (Convert.ToInt32(dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value) == 3 ||
                Convert.ToInt32(dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value) == 4)
            {
                MSG.ErrorMesg("لا يمكن التعامل مع الطالب المحول .. يرجى حذف طلب التحويل أولاً.. ..!");
                return true;
            }
            else if (Convert.ToInt32(dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value) == 1)
            {
                MSG.ErrorMesg("لا يمكن التعامل مع الطالب المستجد .. يرجى تعديل حالة الطالب أولاً.. ..!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean Verify_Std_School_Code(string std_code, int year)
        {
            DataTable Dt;
            Dt = std.Verify_Std_School_Code(std_code, year);
            if (Dt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ShowDegreeStatement()
        {
            int year = Properties.Settings.Default.year_cod;
            int grade_id = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
            string std_code = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
            try
            {
                RPT.OpenDegree_Statement(year, grade_id, std_code);
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }
        }

        #endregion


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

        public void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSelectedData();
        }

        public void ChangeSelectedData()
        {
            Get_Class_Data(Convert.ToInt32(cmb_grade.SelectedValue));
            txt_std_data.Text = "";
        }
        private void pic_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.Visible = false;
        }

        private void txt_std_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم  ";
            lbl_help.Visible = true;

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

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void cmb_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable std_dt;
                std_dt = std.Get_School_year_Data(
                    Current_Year(),
                    Convert.ToInt32(cmb_grade.SelectedValue),
                    cmb_class.SelectedIndex);

                lbl_count.Text = std_dt.Rows.Count.ToString();
                dt_std_data.DataSource = std_dt;
                txt_std_data.Text = "";
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Waiting.Stop();
            }

        }

        private void FRM_CURRENT_STD_Load(object sender, EventArgs e)
        {
            if (_context?.DegreeStatement == true)
            {
                btn_talab_elthak.Visible = false;
                btn_del_std.Visible = false;
                btn_new_std.ButtonText = "بيان درجات";
            }
            else
            {
                btn_talab_elthak.Visible = true;
                if (_context?.ElthakStd == true 
                    || _context?.ElthakStdNextYear == true)
                {
                    btn_del_std.Visible = false;
                }
                else
                {
                    btn_del_std.Visible = true;
                }
                
                btn_new_std.ButtonText = "تعديل البيانات";
            }
           
            try
            {
                dt_std_data.Columns["اسم الطالب"].Width = 200;
                cmb_grade.SelectedValue = grade;
                lbl_current_year.Text = "بيانات " + Func.Year_Desc(
                                                 _context?.CurrentYearData ?? false,
                                                 _context?.DetailsStd ?? false,
                                                 _context?.ElthakStdNextYear ?? false);
                lbl_count.Text = dt_std_data.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }

        }

        private void btn_new_std_Click(object sender, EventArgs e)
        {
            
            Waiting.Start();
            // Degree Statement
            if (_context?.DegreeStatement == true)
            {
                ShowDegreeStatement();
                return;
            }

            if (dt_std_data.SelectedRows.Count > 0)
            {
                // if (Verify_Std_Status()) return;


                int grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
                try
                {
                    var frm = FRM_UPDATE_SCHOOL_STD.Get_Update_School_Std;

                    frm.txt_osra_id.Text = dt_std_data.CurrentRow.Cells["Osraa_Id"].Value.ToString();
                    frm.txt_std_code.Text = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
                    frm.txt_std_name.Text = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();

                    frm.txt_first_name.Text = dt_std_data.CurrentRow.Cells["std_name"].Value.ToString();
                    frm.txt_nat.Text = dt_std_data.CurrentRow.Cells["std_nat"].Value.ToString();

                    frm.cmb_hala.SelectedValue = dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value;
                    frm.cmb_grade.SelectedValue = dt_std_data.CurrentRow.Cells["Grade_Id"].Value;
                    frm.cmb_sana.SelectedValue = dt_std_data.CurrentRow.Cells["Year_Id"].Value;
                    frm.cmb_gender.SelectedValue = dt_std_data.CurrentRow.Cells["Gender_Id"].Value;
                    frm.grade = grade;
                    frm.cmb_class.SelectedValue = dt_std_data.CurrentRow.Cells["Class_Id"].Value;
                    frm.cmb_relgien.SelectedValue = dt_std_data.CurrentRow.Cells["Religion_Id"].Value;

                    if (dt_std_data.CurrentRow.Cells["Updated_by"].Value.ToString() != "")
                    {
                        DateTime my_date = Convert.ToDateTime(dt_std_data.CurrentRow.Cells["Updated_At"].Value.ToString());
                        frm.lbl_edit_date.Visible = true;
                        frm.lbl_by.Visible = true;
                        frm.lbl_edit_by.Visible = true;
                        frm.lbl_date.Visible = true;
                        frm.lbl_edit_date.Text = my_date.ToString("dd/MM/yyyy");
                        frm.lbl_edit_by.Text = dt_std_data.CurrentRow.Cells["Updated_by"].Value.ToString();
                    }
                    else
                    {
                        frm.lbl_edit_date.Visible = false;
                        frm.lbl_edit_by.Visible = false;
                        frm.lbl_by.Visible = false;
                        frm.lbl_date.Visible = false;
                    }

                    frm.row_index = dt_std_data.CurrentCell.RowIndex;


                   // BL.Globals.Update_Std_Data = true;

                    AppNavigation.Instance
                        .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                        .SetContext(c =>
                        {
                            c.UpdateStdData = true;
                        }).Show(frm);

                    //FRM_UPDATE_SCHOOL_STD.Get_Update_School_Std.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);


                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);
                    Waiting.Stop();
                }
            }
            else
            {
                MSG.ErrorMesg("يرجى اختيار طالب ..!");
                Waiting.Stop();
            }

            Waiting.Stop();
        }

        private void txt_std_data_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DataTable dt;
                dt = std.Search_School_year_Data(
                    Current_Year(),
                    Convert.ToInt32(cmb_grade.SelectedValue),
                    Convert.ToInt32(cmb_class.SelectedValue),
                    txt_std_data.Text);

                dt_std_data.DataSource = dt;

                lbl_count.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Waiting.Stop();
            }
        }

        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            if (_context.ElthakStd == true 
                || _context?.ElthakStdNextYear == true)
            {
                btn_talab_elthak_Click(sender, e);
            }
            else
            {
                if (permission_id == 3)
                {
                    return;
                }
                btn_new_std_Click(sender, e);
            }

        }

        private void btn_del_std_Click(object sender, EventArgs e)
        {
            if (dt_std_data.SelectedRows.Count > 0)
            {
                if (Verify_Std_Status()) return;

                string std_name = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
                string std_code = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
                int row_index = dt_std_data.CurrentCell.RowIndex;

                int selected_class = cmb_class.SelectedIndex;

                if (MSG.DialogeErrMsg("هل تريد حذف الطالب  " + std_name + "  ..؟") == DialogResult.Yes)
                {
                    std.Delete_School_Std_Data(std_code, Current_Year());

                    Get_Class_Data(Convert.ToInt32(cmb_grade.SelectedValue));
                    txt_std_data.Text = "";

                    if (row_index != 0)
                    {
                        row_index--;
                        dt_std_data.FirstDisplayedScrollingRowIndex = row_index;
                        dt_std_data.Rows[row_index].Selected = true;
                        dt_std_data.CurrentCell = dt_std_data.Rows[row_index].Cells["اسم الطالب"];
                    }

                    cmb_class.SelectedIndex = selected_class;
                    MSG.MyMesg("تم حذف الطالب  " + std_name + "...! ");


                }
                else
                {
                    MSG.ErrorMesg("تم الغاء عملية الحذف ..!");
                    return;
                }
            }
            else
            {
                MSG.ErrorMesg("يرجى اختيار طالب .. !");
            }
        }

        private void btn_tahwel_Click(object sender, EventArgs e)
        {
            if (dt_std_data.SelectedRows.Count > 0)
            {
                if (Verify_Std_Status()) return;
                Waiting.Start();
                try
                {

                    FRM_TAHEEL_STD.Get_Tahweel_Std.txt_std_code.Text = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
                    FRM_TAHEEL_STD.Get_Tahweel_Std.txt_std_name.Text = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
                    FRM_TAHEEL_STD.Get_Tahweel_Std.txt_guardian_name.Text = dt_std_data.CurrentRow.Cells["father_name"].Value.ToString();
                    FRM_TAHEEL_STD.Get_Tahweel_Std.txt_adrs.Text = dt_std_data.CurrentRow.Cells["العنوان"].Value.ToString();
                    FRM_TAHEEL_STD.Get_Tahweel_Std.txt_transfer_reason.Text = "رغبة ولى الأمر";
                    FRM_TAHEEL_STD.Get_Tahweel_Std.chk_resom_no.Checked = true;
                    FRM_TAHEEL_STD.Get_Tahweel_Std.chk_kotob_no.Checked = true;
                    FRM_TAHEEL_STD.Get_Tahweel_Std.transfer_status = 3;
                    FRM_TAHEEL_STD.Get_Tahweel_Std.lbl_mohwel.Text = "محول إلى";
                    FRM_TAHEEL_STD.Get_Tahweel_Std.grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);

                    Waiting.Stop();
                    FRM_TAHEEL_STD.Get_Tahweel_Std.ShowDialog();

                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);
                    Waiting.Stop();
                }
            }
            else
            {
                MSG.ErrorMesg("يرجى اختيار طالب .. !");
            }


            Waiting.Stop();
        }

        private void btn_talab_elthak_Click(object sender, EventArgs e)
        {

            if (dt_std_data.SelectedRows.Count > 0)
            {
                // if (Verify_Std_Status()) return;
                try
                {
                    string std_code = dt_std_data.CurrentRow.Cells[0].Value.ToString();
                    string std_name = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
                    string std_nat = dt_std_data.CurrentRow.Cells["std_nat"].Value.ToString();
                    int sana = (Convert.ToInt32(dt_std_data.CurrentRow.Cells["year"].Value)) + 2020; ;

                    int std_status = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value);
                    int grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
                    string new_grade_desc = "";
                    string year_desc = "";

                    // Get New Std (KG2 And Prim Six) Data For New Year
                    if (_context?.ElthakStdNextYear == true)
                    {
                        switch (grade)
                        {
                            case 11:
                                sana = (Convert.ToInt32(dt_std_data.CurrentRow.Cells["Year_Id"].Value) + 1) + 2020;
                                new_grade_desc = "الصف الأول الإبتدائي";
                                year_desc = std.Get_Year_Desc(sana + 1).Rows[0]["YearDesc"].ToString();
                                break;

                            case 6:
                                sana = (Convert.ToInt32(dt_std_data.CurrentRow.Cells["Year_Id"].Value)+1) + 2020;
                                new_grade_desc = "الصف الأول الإعدادي";
                                year_desc = std.Get_Year_Desc(sana + 1).Rows[0]["YearDesc"].ToString();

                                break;
                        }
                    }
                    // Get Old Std Data
                    switch (grade)
                    {
                        case 1:
                        case 7:
                            sana = (Convert.ToInt32(dt_std_data.CurrentRow.Cells["Year_Id"].Value)) + 2020;
                            new_grade_desc = dt_std_data.CurrentRow.Cells["old_grade"].Value.ToString();
                            year_desc = std.Get_Year_Desc(sana + 1).Rows[0]["YearDesc"].ToString();

                            break;
                    }

                    RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();
                    RPT.OpenElthakReport(std_code, std_name, std_nat, sana, year_desc, new_grade_desc);
                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);

                }
            }
            else
            {
                MSG.ErrorMesg("يرجى اختيار طالب .. !");
            }

        }
    }
}
