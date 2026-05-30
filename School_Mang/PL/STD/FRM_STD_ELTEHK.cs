using School_Mang.BL;
using School_Mang.BL.Services;
using School_Mang.BL.Enums;
using School_Mang.BL.Extensions;
using School_Mang.BL.Models;
using School_Mang.BL.Common;
using System;
using System.Windows.Forms;
using School_Mang.BL.Common.Helper;

namespace School_Mang.PL.STD
{
    public partial class FRM_STD_ELTEHK : Form, INavigationAware, INavigationAwareLoaded
    {

        private NavigationContext _context;
        private readonly StudentSaveService _saveService = new StudentSaveService();

        public void SetNavigation(NavigationContext context)
        {
            _context = context;
            ApplyContext();
        }
        public void OnNavigatedTo()
        {
            var d = _context?.StudentData;
            if (d == null) return;
            cmb_grade.SelectedValue = d.GradeId;
            cmb_hala.SelectedValue = d.StudentStatus;
            cmb_class.DataSource = std.Get_Grad_Data(d.GradeId);
            if (d.GradeId != 10)
            {
                if (cmb_class.Items.Count > 1)
                    cmb_class.SelectedIndex = 1;
            }
        }

        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();

        int permission_id = Properties.Settings.Default.permission_id;

        // Form Closed
        private static FRM_STD_ELTEHK frm_Std_Eltehk;

        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Std_Eltehk = null;
        }
        public static FRM_STD_ELTEHK Get_Std_Eltehk
        {
            get
            {
                if (frm_Std_Eltehk == null)
                {
                    frm_Std_Eltehk = new FRM_STD_ELTEHK();
                    frm_Std_Eltehk.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Std_Eltehk;
            }
        }

        public FRM_STD_ELTEHK()
        {
            InitializeComponent();

            if (frm_Std_Eltehk == null)
            {
                frm_Std_Eltehk = this;
            }
        }

        private void ApplyContext()
        {
            LoadCombos();
            // Set User permission
            switch (permission_id)
            {
                case 3:
                    btn_new_std.Enabled = false;
                    break;
                case 1:
                case 2:
                    btn_new_std.Enabled = true;
                    break;
            }
            LoadFromContext();
        }
        public void SaveTahweel()
        {
            try
            {
                // Add Std

                var req = new StudentSaveRequest
                {
                    StdCode = txt_std_code.Text,
                    YearId = SafeConverter.GetInt(cmb_sana.SelectedValue),
                    GradeId = SafeConverter.GetInt(cmb_grade.SelectedValue),
                    StatusId = SafeConverter.GetInt(cmb_hala.SelectedValue),
                    ClassId = SafeConverter.GetInt(cmb_class.SelectedValue)
                };
                _saveService.AddToSchool(req);  
                

                if (_context?.StudentCase.Has(GetStudentCase.TaheewlToSchool) != true)
                {
                    MSG.MyMesg("تم حفظ البيانات");

                }
                else
                {
                    //MSG.MyMesg("تم حفظ طلب التحويل بنجاح .. !");
                }

                btn_new_std.Enabled = false;

                var frm = FRM_GET_STD.Get_Student;
                frm.RefreshStudents();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg("Here");

                MSG.ErrorMesg(ex.Message);
            }
        }
        private void LoadCombos()
        {
            // Fill Combos

            cmb_sana.DataSource = std.Get_years();
            cmb_sana.DisplayMember = "YearDesc";
            cmb_sana.ValueMember = "Year_Id";

            cmb_grade.DataSource = std.Get_grades();
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            cmb_hala.DataSource = std.Get_stdStat();
            cmb_hala.DisplayMember = "StatusDesc";
            cmb_hala.ValueMember = "Std_Status_Id";

            cmb_class.DataSource = std.Get_Grad_Data(1);
            cmb_class.DisplayMember = "Class_Desc";
            cmb_class.ValueMember = "Class_Id";

        }
        private void LoadFromContext()
        {
            var d = _context?.StudentData;
            if (d == null) return;

            txt_std_code.Text = d.StdCode;
            txt_std_name.Text = d.StdName;
            txt_std_nat.Text = d.Nat;
            txt_sana.Text = d.YearId.ToString();
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();

            var frm = FRM_GET_STD.Get_Student;
            frm.RefreshStudents();
        }

        private void FRM_STD_ELTEHK_Load(object sender, EventArgs e)
        {
            cmb_sana.SelectedValue = (Properties.Settings.Default.year_cod) + 1;
        }

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_class.DataSource = std.Get_Grad_Data(Convert.ToInt32(cmb_grade.SelectedValue));

        }

        public void btn_new_std_Click(object sender, EventArgs e)
        {
            SaveTahweel();
        }

        private void btn_print_elthak_Click(object sender, EventArgs e)
        {
            try
            {
                string std_code = txt_std_code.Text;
                string std_name = txt_std_name.Text;
                string std_nat = txt_std_nat.Text;
                int sana = Convert.ToInt32(txt_sana.Text) + 2020;

                this.Close();
                RPT.OpenElthakReport(std_code, std_name, std_nat, sana);

            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void FRM_STD_ELTEHK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_close_b_Click(sender, e);
            }
        }
    }
}
