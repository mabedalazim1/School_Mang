using School_Mang.BL;
using School_Mang.BL.Services;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_FINAL_DATA : Form, INavigationAware
    {
        private NavigationContext _context = new NavigationContext();
        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();
            // تجهيز الصفوف
            DataTable grade_dt = _stdData.Get_grades();

            if (_context.Natiga.EditGolos)
            {
                DataRow dr = grade_dt.NewRow();
                dr["GradeDesc"] = "الكل";
                dr["Grade_Id"] = 0;
                grade_dt.Rows.InsertAt(dr, 0);
            }

            cmb_grade.DataSource = grade_dt;
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            LoadStdData();
        }
    
       private readonly BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        
        private readonly LookupService _stdData= new LookupService();
        // Form Closed
        private static FRM_FINAL_DATA frm_Final_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Final_Data = null;
        }
        public static FRM_FINAL_DATA Get_Frm_Final_Data
        {
            get
            {
                if (frm_Final_Data == null)
                {
                    frm_Final_Data = new FRM_FINAL_DATA();
                    frm_Final_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Final_Data;
            }
        }
        public FRM_FINAL_DATA()
        {
            InitializeComponent();

            if (frm_Final_Data == null)
            {
                frm_Final_Data = this;
            }
        }

        public void RefreshData()
        {
            LoadStdData();
        }

        public void TxtChanged()
        {
            DataTable Dt;
            try
            { 
                Waiting.Start();
                if (!_context.Natiga.EditGolos)
                {
                    int grade = _context.Natiga.TestGradeId;
                    string std_name = txt_std_data.Text;
                   
                    Dt = NATEG.Get_Final_Total_Degree(grade, std_name);
                }
                else
                {
                    if (cmb_grade.SelectedValue == null)
                        return;

                    int grade = Convert.ToInt32(cmb_grade.SelectedValue);
                    Dt = NATEG.Search_Golos_Data(grade, txt_std_data.Text);
                }


                dt_std_data.DataSource = Dt;
                lbl_count.Text = Dt.Rows.Count.ToString();
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
        private void LoadStdData()
        {
            try
            {
                Waiting.Start();

                if (_context.Natiga.EditGolos)
                {
                    label11.Text = "تعديل أرقام الجلوس للطلاب ";
                    btn_amal_nesf.ButtonText = "تعديل رقم الجلوس";
                    btn_amal_akher.Visible = false;
                    btn_test_akher.Visible = false;
                    btn_absent_std.Visible = false;
                    btn_test_nesf.Visible = false;

                    btn_amal_nesf.Location = new Point(867, 8);
                    btn_close_b.Location = new Point(163, 8);

                    DataTable Dt = NATEG.Get_Golos_Edit_Data(0, "yes");
                    dt_std_data.DataSource = null;
                    dt_std_data.DataSource = Dt;
                    dt_std_data.Columns["std_code"].Visible = false;

                    lbl_count.Text = Dt.Rows.Count.ToString();
                }
                else
                {

                    label11.Text = "درجات الاختبارات النهائية";
                    btn_amal_nesf.ButtonText = "أعمال نصف العام";
                    btn_amal_akher.Visible = true;
                    btn_test_akher.Visible = true;
                    btn_absent_std.Visible = true;
                    btn_test_nesf.Visible = true;

                    btn_amal_nesf.Location = new Point(1018, 8);
                    btn_close_b.Location = new Point(7, 8);

                    int grade_id = _context.Natiga.TestGradeId; 
                    DataTable Dt = NATEG.Get_Final_Total_Degree(grade_id);
                    dt_std_data.DataSource = null;
                    dt_std_data.DataSource = Dt;

                    dt_std_data.Columns["اسم الطالب"].FillWeight = 200;
                    dt_std_data.Columns["Absent_Any"].Visible = false;

                    Check_Absent();
                    lbl_count.Text = Dt.Rows.Count.ToString();

                    ChangLayOut();
                    DisableBtn();
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

        private void ChangLayOut()
        {
            byte year = Convert.ToByte(Properties.Settings.Default.year_cod);

            int grade_id = _context.Natiga.TestGradeId;
            if (grade_id < 4 || grade_id > 9)
            {
                if(year < 4)
                {
                    btn_amal_nesf.Visible = false;
                    btn_amal_akher.Visible = false;
                    btn_test_akher.Visible = true;
                    btn_absent_std.Visible = false;
                    btn_test_nesf.Visible = false;
                    btn_test_akher.ButtonText = "تقييم أخر العام";
                }

            }
            else
            {
                btn_amal_nesf.Visible = true;
                btn_amal_akher.Visible = true;
                btn_test_akher.Visible = true;
                btn_absent_std.Visible = true;
                btn_test_nesf.Visible = true;
                btn_test_akher.ButtonText = "اختبار أخر العام";

            }


        }
        private void DisableBtn()
        {
            int grade_id = _context.Natiga.TestGradeId;
            switch (grade_id)
            {
                case 1:
                case 2:
                    btn_test_akher.Enabled = false;
                    btn_test_nesf.Enabled = false;
                    break;

                default:
                    btn_test_akher.Enabled = true;
                    btn_test_nesf.Enabled = true;
                    break;
            }
        }
        private void Check_Absent()
        {
            foreach (DataGridViewRow row in dt_std_data.Rows)
            {
                // Get Absent Student
                if (row.Cells["Absent_Any"].Value != null &&
                        row.Cells["Absent_Any"].Value.ToString() != "0")
                {
                    row.DefaultCellStyle.BackColor = Color.Crimson;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.OrangeRed;
                }

            }
        }

        private void Edit_Degree(string finalTestName, byte finalTestKind)
        {
            try
            {
                if (dt_std_data.CurrentRow == null)
                {
                    MSG.ErrorMesg("يرجى تحديد الطالب أولاً ..!");
                    return;
                }

                this.Hide();
                //BL.Globals.Final_Test_Name = Final_Test_Name;
                //BL.Globals.Final_Test_Kind = Final_Test_Kind;
                // BL.Globals.Std_Golos = Convert.ToInt32(dt_std_data.CurrentRow.Cells[0].Value);
                //FRM_FINAL_DEGREE_DATA.Get_Final_Degree_Data.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);

                var frm = new FRM_FINAL_DEGREE_DATA();

                AppNavigation.Instance
                    .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                    .SetContext(c =>
                    {
                        c.Natiga.TestGradeId = _context.Natiga.TestGradeId;
                        c.Natiga.StudentGolos = Convert.ToInt32(dt_std_data.CurrentRow.Cells[0].Value);
                        c.Natiga.FinalTestName = finalTestName;
                        c.Natiga.FinalTestKind = finalTestKind;
                    })
                    .Show(frm);

                if (frm.DialogResult == DialogResult.OK)
                    RefreshData();

                this.Show();
                this.Activate();
            }
            catch (Exception e)
            {
                this.Show();
                this.BringToFront();
                MSG.ErrorMesg(e.Message);
            }
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

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            //BL.Globals.Edit_Golos = false;

            if (!_context.Natiga.EditGolos)
            {
                var main = MAIN.FRM_MAIN.Get_Frm_Main;

                main.BeginInvoke(new Action(() =>
                {
                    var frmCount = FRM_FINAL_COUNT_DATA.Get_Frm_Final_Count_Data;

                    if (frmCount.WindowState == FormWindowState.Minimized)
                        frmCount.WindowState = FormWindowState.Normal;

                    if (!frmCount.Visible)
                        frmCount.Show();

                    frmCount.BringToFront();
                    frmCount.Activate();
                }));
            }

            Close();
        }

        private void FRM_FINAL_DATA_Load(object sender, EventArgs e)
        {
            try
            {
                if (_context.Natiga.EditGolos)
                {
                    dt_std_data.Columns["studeNtname"].Width = 350;
                    dt_std_data.Columns["studeNtname"].HeaderText = "اسم الطالب";
                    dt_std_data.Columns["Golos"].HeaderText = "رقم الجلوس";
                    dt_std_data.Columns["Golos"].Width = 150;
                    dt_std_data.Columns["GradeDesc"].HeaderText = "الصف";
                    dt_std_data.Columns["Class_Desc"].HeaderText = "الفصل";
                    dt_std_data.Columns["YearDesc"].HeaderText = "العام الدراسي";
                    cmb_grade.SelectedValue = 0;

                }
                else
                {
                    dt_std_data.Columns["اسم الطالب"].Width = 200;
                    cmb_grade.SelectedValue = Convert.ToInt32(_context.Natiga.TestGradeId);
                    Check_Absent();
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم";
            lbl_help.Visible = true;
        }

        private void pic_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.Visible = false;
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

        private void txt_std_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void txt_std_data_Leave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void txt_std_data_OnValueChanged(object sender, EventArgs e)
        { 
           TxtChanged();
        }

        public void cmb_grade_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                Waiting.Start();
                int grade = Convert.ToInt32(cmb_grade.SelectedValue);

                DataTable Dt;

                if (!_context.Natiga.EditGolos)
                {
                    Dt = NATEG.Get_Final_Total_Degree(grade);

                    if (Dt.Rows.Count == 0)
                    {
                        MSG.ErrorMesg("لا توجد بيانات مسجلة للصف المحدد ..!");
                        cmb_grade.SelectedValue = _context.Natiga.TestGradeId;
                        return;
                    }
                    else
                    {
                        _context.Natiga.TestGradeId = grade;

                        dt_std_data.DataSource = Dt;
                        lbl_count.Text = Dt.Rows.Count.ToString();
                        Check_Absent();
                    }
                }
                else
                {
                    if (cmb_grade.SelectedIndex == 0)
                    {
                        Dt = NATEG.Get_Golos_Edit_Data(grade, "yes");
                        dt_std_data.DataSource = Dt;
                    }
                    else
                    {
                        Dt = NATEG.Get_Golos_Edit_Data(grade);
                        dt_std_data.DataSource = Dt;
                    }

                    lbl_count.Text = Dt.Rows.Count.ToString();
                }

                if (!_context.Natiga.EditGolos)
                {
                    ChangLayOut();
                    DisableBtn();
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

        private void btn_amal_nesf_Click(object sender, EventArgs e)
        {
            if (dt_std_data.CurrentRow == null)
            {
                MSG.ErrorMesg("يرجى تحديد الطالب أولاً ..!");
                return;
            }

            if (_context.Natiga.EditGolos)
            {
                string code = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
                string stdName  = dt_std_data.CurrentRow.Cells["studeNtname"].Value.ToString();
                string golos = dt_std_data.CurrentRow.Cells["Golos"].Value.ToString();
                string gradeDesc = dt_std_data.CurrentRow.Cells["GradeDesc"].Value.ToString();
                string classDesc = dt_std_data.CurrentRow.Cells["Class_Desc"].Value.ToString();
                string yearDesc = dt_std_data.CurrentRow.Cells["YearDesc"].Value.ToString();
                
                if (golos == "") golos = "0";

                var frm = FRM_EDIT_GOLOS.Get_frm_Edit_Golos;
                var context = new NavigationContext();
                context.Natiga.StudentGolos = Convert.ToInt32(golos);
                frm.SetNavigation(context);

                frm.txt_code.Text = code;
                frm.txt_std_name.Text = stdName;
                frm.txt_golos.Text = golos;
                frm.txt_grade.Text = gradeDesc;
                frm.txt_class.Text = classDesc;
                frm.txt_year.Text = yearDesc;


                this.Hide();

                frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
            }
            else
            {
                Edit_Degree("أعمال نصف العام", 1);
            }
            
        }

        private void btn_test_nesf_Click(object sender, EventArgs e)
        {
            Edit_Degree("اختبار نصف العام", 2);
        }

        private void btn_amal_akher_Click(object sender, EventArgs e)
        {
            Edit_Degree("أعمال أخر العام", 3);
        }

        private void btn_test_akher_Click(object sender, EventArgs e)
        {
            Edit_Degree("اختبار أخر العام", 4);
        }

        private void btn_absent_std_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt_std_data.CurrentRow == null)
                {
                    MSG.ErrorMesg("يرجى تحديد الطالب أولاً ..!");
                    return;
                }

                int studentGolos =
                    Convert.ToInt32(dt_std_data.CurrentRow.Cells[0].Value);

                var frm = FRM_EDIT_ABSENT_STD.Get_Frm_Edit_absent_std;

                this.Hide();
                AppNavigation.Instance
                    .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main).
                    SetContext(c =>
                    {
                        c.Natiga.TestGradeId = _context.Natiga.TestGradeId;
                        c.Natiga.StudentGolos = studentGolos;
                    })
                    .Show(frm);
                if (frm.DialogResult == DialogResult.OK)
                    RefreshData();

                this.Show();
                this.Activate();

            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }
    }
}
