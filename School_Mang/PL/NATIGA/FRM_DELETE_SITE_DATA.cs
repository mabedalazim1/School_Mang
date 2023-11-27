using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_DELETE_SITE_DATA : Form
    {
        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();
        BL.LOGIN.CLS_LOGIN login = new BL.LOGIN.CLS_LOGIN();

        // Form Closed
        private static FRM_DELETE_SITE_DATA frm_Delete_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Delete_Data = null;
        }
        public static FRM_DELETE_SITE_DATA Get_Frm_Delete_Data
        {
            get
            {
                if (frm_Delete_Data == null)
                {
                    frm_Delete_Data = new FRM_DELETE_SITE_DATA();
                    frm_Delete_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Delete_Data;
            }
        }

        public FRM_DELETE_SITE_DATA()
        {
            if (frm_Delete_Data == null)
            {
                frm_Delete_Data = this;
            }

            InitializeComponent();
            cmb_grade.DataSource = NATEG.GET_GRADE();
            cmb_grade.DisplayMember = "grade_desc";
            cmb_grade.ValueMember = "id";

            cmb_month.DataSource = NATEG.GET_TEST_KIND();
            cmb_month.DisplayMember = "testkind_desc";
            cmb_month.ValueMember = "id";

            Add_To_Comb_Test();


        }

        private void Add_To_Comb_Test()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "التقييمات");
            comboSource.Add(2, "الإختبارات");

            cmb_test.DataSource = new BindingSource(comboSource, null);
            cmb_test.DisplayMember = "Value";
            cmb_test.ValueMember = "Key";
        }
        private void btn_close_b_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_save_data_Click(object sender, EventArgs e)
        {
           
            if(txt_user.Text =="" || txt_pass.Text == "")
            {
                msg.ErrorMesg("تأكد من اسم المستخدم وكلمة المرور ..!");
                txt_user.Focus();
                return;
            }
            else
            {
                DataTable Dt = login.Login(txt_user.Text, txt_pass.Text);
                if(Dt.Rows.Count == 0)
                {
                    msg.ErrorMesg("تأكد من اسم المستخدم وكلمة المرور ..!");
                    txt_user.Focus();
                    return;
                }
                try
                {
                    int grade = Convert.ToInt32(cmb_grade.SelectedValue);
                    int test_kind = Convert.ToInt32(cmb_month.SelectedValue);

                    Waiting.Wait();
                    switch (cmb_test.SelectedValue)
                    {
                        case 1:
                            NATEG.DeleteDegreeFromSite(grade, test_kind, 0);
                            break;
                        case 2:
                            NATEG.DeleteMarkFromSite(grade, test_kind, 0);
                            break;
                    }
                    msg.MyMesg("تم حذف البيان المحدد");
                }
                catch (Exception ex)
                {
                    msg.ErrorMesg(ex.Message);
                }
                finally
                {
                    Waiting.End_WAit();
                }
            }
        }
    }
}
