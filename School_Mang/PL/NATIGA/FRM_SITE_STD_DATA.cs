using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.Services;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_SITE_STD_DATA : Form, INavigationAware, INavigationAwareLoaded
    {
        private NavigationContext _context = new NavigationContext();

        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();
            lbl_month.Text = _context.Natiga.TestMonthName;
        }

        public async void OnNavigatedTo()
        {
           await LoadStdData();
        }

        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();

        private readonly LookupService _stdData= new LookupService();


        // Form Closed
        private static FRM_SITE_STD_DATA frm_Site_Std_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Site_Std_Data = null;
        }
        public static FRM_SITE_STD_DATA Get_Frm_Site_Std_Data
        {
            get
            {
                if (frm_Site_Std_Data == null)
                {
                    frm_Site_Std_Data = new FRM_SITE_STD_DATA();
                    frm_Site_Std_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Site_Std_Data;
            }
        }
        public FRM_SITE_STD_DATA()
        {
            InitializeComponent();

            dt_std_data.AutoGenerateColumns = true;

            if (frm_Site_Std_Data == null)
            {
                frm_Site_Std_Data = this;
            }


            DataTable grade_dt = _stdData.Get_grades();
            cmb_grade.DataSource = grade_dt;
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";
            
        }


        int move;
        int move_x;
        int move_y;



        private void ConfigureGridColumns(int gradeId, int testKind)
        {
            // إعادة الأعمدة لحالتها الأصلية قبل تطبيق إعدادات الصف الجديد
            foreach (DataGridViewColumn column in dt_std_data.Columns)
            {
                column.Visible = true;

                if (!string.IsNullOrEmpty(column.DataPropertyName))
                    column.HeaderText = column.DataPropertyName;
                else
                    column.HeaderText = column.Name;
            }

            if (testKind == 1)
            {
                switch (gradeId)
                {
                    case 10:
                    case 11:
                    case 1:
                    case 2:
                    case 3:
                        HideColumn("دراسات");
                        HideColumn("مهارات");
                        HideColumn("تكنولوجيا");
                        SetHeader("علوم", "متعدد");
                        break;

                    case 4:
                    case 5:
                    case 6:
                        HideColumn("بدنية");
                        break;

                    case 7:
                    case 8:
                    case 9:
                        HideColumn("بدنية");
                        SetHeader("مهارات", "فنية");
                        SetHeader("تكنولوجيا", "حاسب");
                        break;
                }
            }
            else if (testKind == 2)
            {
                switch (gradeId)
                {
                    case 10:
                    case 11:
                        HideColumn("دراسات");
                        HideColumn("فرنسى");
                        HideColumn("مهارات");
                        HideColumn("تكنولوجيا");
                        SetHeader("علوم", "متعدد");
                        break;

                    case 1:
                    case 2:
                    case 3:
                        HideColumn("دراسات");
                        HideColumn("مهارات");
                        HideColumn("تكنولوجيا");
                        SetHeader("علوم", "متعدد");
                        break;

                    case 4:
                    case 5:
                    case 6:
                        HideColumn("مهارات");
                        HideColumn("تكنولوجيا");
                        break;

                    case 7:
                    case 8:
                    case 9:
                        SetHeader("مهارات", "فنية");
                        SetHeader("تكنولوجيا", "حاسب");
                        break;
                }
            }

            // إخفاء الأعمدة الداخلية
            HideColumn("test_kind_Id");
            HideColumn("grade_Id");
            HideColumn("الصف");
            HideColumn("نوع الإختبار");
            HideColumn("userSchoolId");
            HideColumn("show_data");

            if (dt_std_data.Columns.Contains("اسم الطالب"))
                dt_std_data.Columns["اسم الطالب"].Width = 200;
        }

        private void HideColumn(string columnName)
        {
            if (dt_std_data.Columns.Contains(columnName))
                dt_std_data.Columns[columnName].Visible = false;
        }

        private void SetHeader(string columnName, string headerText)
        {
            if (dt_std_data.Columns.Contains(columnName))
                dt_std_data.Columns[columnName].HeaderText = headerText;
        }


        private async Task RefreshData()
        {
            await LoadStdData();
        }


        private async Task LoadStdData()
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            Waiting.Start();

            try
            {
                int test_kind = _context.Natiga.TestKind;
                int grade_id = _context.Natiga.TestGradeId;
                int test_month = _context.Natiga.TestMonth;

                if (BL.Globals.Test_Internet_Con)
                {
                    DataTable Dt;

                    dt_std_data.DataSource = null;

                    if (test_kind == 1)
                    {
                        Dt = NATEG.Get_Degree_Data(test_month, grade_id);
                    }
                    else
                    {
                        Dt = NATEG.Get_Mark_Data(test_month, grade_id);
                    }

                    dt_std_data.DataSource = Dt;

                    // إعداد الأعمدة حسب الصف ونوع الاختبار
                    ConfigureGridColumns(grade_id, test_kind);

                    lbl_count.Text = dt_std_data.Rows.Count.ToString();

                    Check_Hide_Natega();
                }
                else
                {
                    MSG.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                    this.Close();
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


        private void Check_Hide_Natega()
        {
            try
            {
                foreach (DataGridViewRow row in dt_std_data.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    bool isHidden = Convert.ToString(
                        row.Cells["show_data"].Value) == "False";

                    if (isHidden)
                    {
                        row.DefaultCellStyle.BackColor = Color.Crimson;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.SelectionBackColor = Color.OrangeRed;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = default;
                        row.DefaultCellStyle.ForeColor = default;
                        row.DefaultCellStyle.SelectionBackColor = default;
                    }
                }
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }


        private async Task Serach_Data()
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            Waiting.Start();

            try
            {
                int test_kind = _context.Natiga.TestKind;
                int grade_id = _context.Natiga.TestGradeId;
                int test_month = _context.Natiga.TestMonth;

                DataTable Dt = new DataTable();

                switch (test_kind)
                {
                    case 1:
                        Dt = NATEG.Get_Degree_Data(
                            test_month, grade_id, "yes", txt_std_data.Text);
                        break;

                    case 2:
                        Dt = NATEG.Get_Mark_Data(
                            test_month, grade_id, "yes", txt_std_data.Text);
                        break;

                    default:
                        return;
                }

                dt_std_data.DataSource = Dt;

                // تطبيق نفس إعدادات الأعمدة المستخدمة في LoadStdData
                ConfigureGridColumns(grade_id, test_kind);

                lbl_count.Text = dt_std_data.Rows.Count.ToString();

                Check_Hide_Natega();
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

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private async void FRM_SITE_STD_DATA_Load(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            cmb_grade.SelectedValue = _context.Natiga.TestGradeId;
        }


        private async void cmb_grade_DropDownClosed(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {
                if (cmb_grade.SelectedValue == null ||
                    !int.TryParse(cmb_grade.SelectedValue.ToString(), out int gradeId))
                {
                    return;
                }

                // تحديث الصف الحالي في NavigationContext
                _context.Natiga.TestGradeId = gradeId;

                // مسح نص البحث السابق
                txt_std_data.Text = "";

                // تحميل بيانات الصف الجديد
                await LoadStdData();

                if (dt_std_data.Rows.Count == 0)
                {
                    MSG.ErrorMesg("لا توجد بيانات مسجلة لهذا الصف ..!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }


        private async void txt_std_data_KeyUp(object sender, KeyEventArgs e)
        {
            await Serach_Data();
        }


        private async void btn_edit_std_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {
                if (dt_std_data.CurrentRow == null ||
                    dt_std_data.CurrentRow.IsNewRow)
                {
                    MSG.ErrorMesg("من فضلك حدد الطالب أولاً ..!");
                    return;
                }

                int test_kind_id = _context.Natiga.TestKind;

                string badnia = "0";
                string franch = "0";
                string sort_id = "0";

                var row = dt_std_data.CurrentRow;

                string code = Convert.ToString(row.Cells["userSchoolId"].Value);
                string ar = Convert.ToString(row.Cells["عربى"].Value);
                string din = Convert.ToString(row.Cells["دين"].Value);
                string english = Convert.ToString(row.Cells["انجليزى"].Value);
                string sinces = Convert.ToString(row.Cells["علوم"].Value);
                string math = Convert.ToString(row.Cells["رياضيات"].Value);
                string social = Convert.ToString(row.Cells["دراسات"].Value);
                string maharat = Convert.ToString(row.Cells["مهارات"].Value);
                string tecnolgy = Convert.ToString(row.Cells["تكنولوجيا"].Value);
                string total = Convert.ToString(row.Cells["مجموع"].Value);

                string test_kind_Id_site =
                    Convert.ToString(row.Cells["test_kind_Id"].Value);

                string grade_Id = Convert.ToString(row.Cells["grade_Id"].Value);
                string name = Convert.ToString(row.Cells["اسم الطالب"].Value);
                string grade = Convert.ToString(row.Cells["الصف"].Value);
                string test_kind = Convert.ToString(row.Cells["نوع الإختبار"].Value);

                var context = new NavigationContext();
                context.Natiga.TestGradeId = _context.Natiga.TestGradeId;

                switch (test_kind_id)
                {
                    case 1:
                        {
                            badnia = Convert.ToString(row.Cells["بدنية"].Value);

                            var frmDegree = FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree;

                            frmDegree.SetNavigation(context);

                            frmDegree.txt_cod.Text = code;
                            frmDegree.txt_ar.Text = ar;
                            frmDegree.txt_din.Text = din;
                            frmDegree.txt_english.Text = english;
                            frmDegree.txt_sinces.Text = sinces;
                            frmDegree.txt_math.Text = math;
                            frmDegree.txt_social.Text = social;
                            frmDegree.txt_badnia.Text = badnia;
                            frmDegree.txt_maharat.Text = maharat;
                            frmDegree.txt_tecnolgey.Text = tecnolgy;
                            frmDegree.txt_total.Text = total;
                            frmDegree.txt_test_kind_id.Text = test_kind_Id_site;
                            frmDegree.txt_grade_id.Text = grade_Id;
                            frmDegree.txt_name.Text = name;
                            frmDegree.txt_grade.Text = grade;
                            frmDegree.txt_test_kind.Text = test_kind;

                            if (frmDegree.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main) == DialogResult.OK)
                            {
                                await RefreshData();
                            }

                            break;
                        }

                    case 2:
                        {
                            franch = Convert.ToString(row.Cells["فرنسى"].Value);
                            sort_id = Convert.ToString(row.Cells["الترتيب"].Value);

                            var frmMark = FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark;

                            frmMark.SetNavigation(context);

                            frmMark.txt_cod.Text = code;
                            frmMark.txt_ar.Text = ar;
                            frmMark.txt_din.Text = din;
                            frmMark.txt_english.Text = english;
                            frmMark.txt_sinces.Text = sinces;
                            frmMark.txt_math.Text = math;
                            frmMark.txt_social.Text = social;
                            frmMark.txt_french.Text = franch;
                            frmMark.txt_maharat.Text = maharat;
                            frmMark.txt_tecnolgey.Text = tecnolgy;
                            frmMark.txt_total.Text = total;
                            frmMark.txt_sort.Text = sort_id;
                            frmMark.txt_test_kind_id.Text = test_kind_Id_site;
                            frmMark.txt_grade_id.Text = grade_Id;
                            frmMark.txt_name.Text = name;
                            frmMark.txt_grade.Text = grade;
                            frmMark.txt_test_kind.Text = test_kind;

                            if (frmMark.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main) == DialogResult.OK)
                            {
                                await RefreshData();
                            }

                            break;
                        }

                    default:
                        MSG.ErrorMesg("نوع الاختبار غير صحيح ..!");
                        break;
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }


        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            btn_edit_std_Click(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_count_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dt_std_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_del_std_Click(object sender, EventArgs e)
        {
            MSG.ErrorMesg("هذا الإجراء غير متاح ..!");
        }

       
        private void pn_top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pic_help_Click(object sender, EventArgs e)
        {

        }

        private async void btn_hide_data_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt_std_data.CurrentRow == null)
                    return;

                Waiting.Start();

                string std_name = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();

                if (MSG.DialogeMsg("هل تريد تعديل حالة نتيجة ... ؟ " + "\n" + std_name) == DialogResult.No)
                {
                    MSG.MyExclamationMsg("تم إلغاء الإجراء..!");
                    return;
                }

                int student_id = Convert.ToInt32(
                    dt_std_data.CurrentRow.Cells["userSchoolId"].Value);

                byte test_kind_id = Convert.ToByte(
                    dt_std_data.CurrentRow.Cells["test_kind_Id"].Value);

                string show_data = dt_std_data.CurrentRow.Cells["show_data"].Value.ToString();

                NATEG.Toggle_Hide_Data(student_id, test_kind_id, show_data);

                await Serach_Data();

                if (show_data == "False")
                {
                    MSG.MyMesg("تم إتاحة النتيجة للطالب ..!" + "\n" + std_name);
                }
                else
                {
                    MSG.MyExclamationMsg("تم حجب نتيجة الطالب ..!" + "\n" + std_name);
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

        private void dt_std_data_Click(object sender, EventArgs e)
        {
            if (dt_std_data.CurrentRow == null ||
                dt_std_data.CurrentRow.IsNewRow)
                return;

            if (Convert.ToString(
                dt_std_data.CurrentRow.Cells["show_data"].Value) != "False")
            {
                btn_hide_data.ButtonText = "حجب النتيجة";
            }
            else
            {
                btn_hide_data.ButtonText = "إلغاء الحجب";
            }
        }
    }
}
