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
    public partial class FRM_STD_ELTEHK : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.MSG msg = new BL.MSG();

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

            cmb_class.DataSource = std.Get_Class_Id(1);
            cmb_class.DisplayMember = "Class_Desc";
            cmb_class.ValueMember = "Class_Id";

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
            BL.Globals.Taheewl_To_School = false;
            this.Close();
            this.Dispose();

            FRM_GET_STD.Get_Student.txt_std_data.Text = "";
            FRM_GET_STD.Get_Student.cmb_sana_SelectedIndexChanged(sender, e);
            FRM_GET_STD.Get_Student.txt_std_data.Focus();

        }

        private void FRM_STD_ELTEHK_Load(object sender, EventArgs e)
        {
            cmb_sana.SelectedValue = (Properties.Settings.Default.year_cod)+1;
        }

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_class.DataSource = std.Get_Class_Id(Convert.ToInt32(cmb_grade.SelectedValue));

        }

        public void btn_new_std_Click(object sender, EventArgs e)
        {
           
            try
            {
                //IF Tahweel To School Get New Year
                if (BL.Globals.Taheewl_To_School)
                {
                   cmb_sana.SelectedValue = (Properties.Settings.Default.year_cod) + 1;

                }
                // Add Std
                std.Add_School_Std_Data(
                    txt_std_code.Text,
                    Convert.ToInt32(cmb_sana.SelectedValue),
                    Convert.ToInt32(cmb_grade.SelectedValue),
                    Convert.ToInt32(cmb_hala.SelectedValue),
                    Convert.ToInt32(cmb_class.SelectedValue)
                    );

                    msg.MyMesg("تم حفظ البيانات");
                   
                btn_new_std.Enabled = false;
                BL.Globals.Taheewl_To_School = false;

            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }
    }
}
